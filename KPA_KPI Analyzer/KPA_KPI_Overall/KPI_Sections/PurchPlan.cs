using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.Diagnostics;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPI_Sections
{
    public class PurchPlan
    {
        public Po_Rel_vs_PR_Del_Date poRelVsPRDelDate;
        public PR_2nd_Lvl_Rel_Orig_Plan_Del_Date pr2ndLvlRelOrigPlanDelDate;
        private double totalDays = 0;
        string[] strPoLineFirstRelDate;



        public delegate void ReportProgressHandler(string mesage);
        public event ReportProgressHandler ReportPogress;





        // Default Constructor
        public PurchPlan()
        {
            poRelVsPRDelDate = new Po_Rel_vs_PR_Del_Date();
            pr2ndLvlRelOrigPlanDelDate = new PR_2nd_Lvl_Rel_Orig_Plan_Del_Date();
        }






        /// <summary>
        /// Loads the data for the specifc KPI
        /// </summary>
        /// <param name="Overall.SelectedCountry"></param>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PO Release vs PR Delivery Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in Overall.prsOnPOsDt.Rows)
                {
                    if (Filters.FilterByPrDateRange)
                    {
                        // The user wants to filter by PR date range
                        string[] requisnDate = (dr["Requisn Date"].ToString()).Split('/');
                        int reqYear = int.Parse(requisnDate[2]);
                        int reqMonth = int.Parse(requisnDate[0].TrimStart('0'));
                        int reqDay = int.Parse(requisnDate[1].TrimStart('0'));
                        DateTime reqTestDate = new DateTime(reqYear, reqMonth, reqDay);

                        if (reqTestDate < Filters.PrFromDate || reqTestDate > Filters.PrToDate)
                        {
                            // The PR date is not within the PR date range.
                            continue;
                        }
                    }

                    if (Filters.FilterByPoDateRange)
                    {
                        // The user wnats to filter by PO date range
                        string[] strPODate = (dr["PO Date"].ToString()).Split('/');
                        int poYear = int.Parse(strPODate[2]);
                        int poMonth = int.Parse(strPODate[0]);
                        int poDay = int.Parse(strPODate[1]);

                        if (poYear == 0 && poMonth == 0 && poDay == 0)
                        {
                            // This record is not a PO so we dont care about it
                            continue;
                        }
                        else
                        {
                            poYear = int.Parse(strPODate[2]);
                            poMonth = int.Parse(strPODate[0].TrimStart('0'));
                            poDay = int.Parse(strPODate[1].TrimStart('0'));
                        }

                        DateTime poTestDate = new DateTime(poYear, poMonth, poDay);

                        if (poTestDate < Filters.PoFromDate || poTestDate > Filters.PoToDate)
                        {
                            // The PO date is not within the PO date range.
                            continue;
                        }
                    }



                    strPoLineFirstRelDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                    int poLineFirstRelYear = int.Parse(strPoLineFirstRelDate[2]);
                    int poLineFirstRelMonth = int.Parse(strPoLineFirstRelDate[0]);
                    int poLineFirstRelDay = int.Parse(strPoLineFirstRelDate[1]);

                    if (poLineFirstRelYear == 0 && poLineFirstRelMonth == 0 && poLineFirstRelDay == 0)
                    {
                        continue;
                    }
                    else
                    {
                        poRelVsPRDelDate.data.Total++;
                        poLineFirstRelYear = int.Parse(strPoLineFirstRelDate[2]);
                        poLineFirstRelMonth = int.Parse(strPoLineFirstRelDate[0].TrimStart('0'));
                        poLineFirstRelDay = int.Parse(strPoLineFirstRelDate[1].TrimStart('0'));
                    }

                    DateTime poLineFirstRelDate = new DateTime(poLineFirstRelYear, poLineFirstRelMonth, poLineFirstRelDay);

                    string[] strPRDelDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int prDelYear = int.Parse(strPRDelDate[2]);
                    int prDelMonth = int.Parse(strPRDelDate[0].TrimStart('0'));
                    int prDelDay = int.Parse(strPRDelDate[1].TrimStart('0'));

                    DateTime prDelDate = new DateTime(prDelYear, prDelMonth, prDelDay);
                    double elapsedDays = (prDelDate - poLineFirstRelDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    if (elapsedDays <= 0)
                    {
                        poRelVsPRDelDate.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        poRelVsPRDelDate.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        poRelVsPRDelDate.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        poRelVsPRDelDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        poRelVsPRDelDate.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        poRelVsPRDelDate.data.TwentyTwo_TwentyEight++;
                    }
                    else if (elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        poRelVsPRDelDate.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        poRelVsPRDelDate.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        poRelVsPRDelDate.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50 && elapsedDays <= 56)
                    {
                        poRelVsPRDelDate.data.Fifty_FiftySix++;
                    }
                    else // elapsed days >= 57
                    {
                        poRelVsPRDelDate.data.greaterThanEqualFiftySeven++;
                    }
                }


                try
                {
                    poRelVsPRDelDate.data.Average = Math.Round(totalDays / poRelVsPRDelDate.data.Total, 2);
                    if (double.IsNaN(poRelVsPRDelDate.data.Average))
                        poRelVsPRDelDate.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    poRelVsPRDelDate.data.Average = 0;
                }
                
                totalDays = 0;



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PR 2nd Lvl Release to Original Planned Delivery Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in Overall.pr2ndLvlRelDateDt.Rows)
                {
                    if (Filters.FilterByPrDateRange)
                    {
                        // The user wants to filter by PR date range
                        string[] requisnDate = (dr["Requisn Date"].ToString()).Split('/');
                        int reqYear = int.Parse(requisnDate[2]);
                        int reqMonth = int.Parse(requisnDate[0].TrimStart('0'));
                        int reqDay = int.Parse(requisnDate[1].TrimStart('0'));
                        DateTime reqTestDate = new DateTime(reqYear, reqMonth, reqDay);

                        if (reqTestDate < Filters.PrFromDate || reqTestDate > Filters.PrToDate)
                        {
                            // The PR date is not within the PR date range.
                            continue;
                        }
                    }

                    if (Filters.FilterByPoDateRange)
                    {
                        // The user wnats to filter by PO date range
                        string[] strPODate = (dr["PO Date"].ToString()).Split('/');
                        int poYear = int.Parse(strPODate[2]);
                        int poMonth = int.Parse(strPODate[0]);
                        int poDay = int.Parse(strPODate[1]);

                        if (poYear == 0 && poMonth == 0 && poDay == 0)
                        {
                            // This record is not a PO so we dont care about it
                            continue;
                        }
                        else
                        {
                            poYear = int.Parse(strPODate[2]);
                            poMonth = int.Parse(strPODate[0].TrimStart('0'));
                            poDay = int.Parse(strPODate[1].TrimStart('0'));
                        }

                        DateTime poTestDate = new DateTime(poYear, poMonth, poDay);

                        if (poTestDate < Filters.PoFromDate || poTestDate > Filters.PoToDate)
                        {
                            // The PO date is not within the PO date range.
                            continue;
                        }
                    }




                    string[] strPR2ndLvlRelDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    int pr2ndLvlRelYear = int.Parse(strPR2ndLvlRelDate[2]);
                    int pr2ndLvlRelMonth = int.Parse(strPR2ndLvlRelDate[0]);
                    int pr2ndLvlRelDay = int.Parse(strPR2ndLvlRelDate[1]);

                    if (pr2ndLvlRelYear == 0 && pr2ndLvlRelMonth == 0 && pr2ndLvlRelDay == 0)
                    {
                        continue;
                    }
                    else
                    {
                        pr2ndLvlRelOrigPlanDelDate.data.Total++;
                        pr2ndLvlRelYear = int.Parse(strPR2ndLvlRelDate[2]);
                        pr2ndLvlRelMonth = int.Parse(strPR2ndLvlRelDate[0].TrimStart('0'));
                        pr2ndLvlRelDay = int.Parse(strPR2ndLvlRelDate[1].TrimStart('0'));
                    }
                    DateTime pr2ndLvlRelDate = new DateTime(pr2ndLvlRelYear, pr2ndLvlRelMonth, pr2ndLvlRelDay);

                    string[] strPRDelDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int prDelYear = int.Parse(strPRDelDate[2]);
                    int prDelMonth = int.Parse(strPRDelDate[0].TrimStart('0'));
                    int prDelDay = int.Parse(strPRDelDate[1].TrimStart('0'));

                    DateTime prDelDate = new DateTime(prDelYear, prDelMonth, prDelDay);
                    double elapsedDays = (prDelDate - pr2ndLvlRelDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    if (elapsedDays <= 0)
                    {
                        pr2ndLvlRelOrigPlanDelDate.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        pr2ndLvlRelOrigPlanDelDate.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        pr2ndLvlRelOrigPlanDelDate.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        pr2ndLvlRelOrigPlanDelDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        pr2ndLvlRelOrigPlanDelDate.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        pr2ndLvlRelOrigPlanDelDate.data.TwentyTwo_TwentyEight++;
                    }
                    else if (elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        pr2ndLvlRelOrigPlanDelDate.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        pr2ndLvlRelOrigPlanDelDate.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        pr2ndLvlRelOrigPlanDelDate.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50 && elapsedDays <= 56)
                    {
                        pr2ndLvlRelOrigPlanDelDate.data.Fifty_FiftySix++;
                    }
                    else // elapsed days >= 57
                    {
                        pr2ndLvlRelOrigPlanDelDate.data.greaterThanEqualFiftySeven++;
                    }
                }

                try
                {
                    pr2ndLvlRelOrigPlanDelDate.data.Average = Math.Round(totalDays / pr2ndLvlRelOrigPlanDelDate.data.Total, 2);
                    if (double.IsNaN(pr2ndLvlRelOrigPlanDelDate.data.Average))
                        pr2ndLvlRelOrigPlanDelDate.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    pr2ndLvlRelOrigPlanDelDate.data.Average = 0;
                }
                totalDays = 0;

                PRPO_DB_Utils.CompletedDataLoads++;
                MethodInvoker del = delegate
                {
                    PRPO_DB_Utils.UpdateDataLoadProgress();
                };
                del.Invoke();
                ReportPogress("KPI - Purch Plan Completed " + PRPO_DB_Utils.CompletedDataLoads);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Purch Plan Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }







    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //
    //  The below classes act as a specific KPA category that fall under a specific KPA section.
    //
    //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Po_Rel_vs_PR_Del_Date
    {
        public TempFour data;

        public Po_Rel_vs_PR_Del_Date()
        {
            data = new TempFour();
        }
    }






    public class PR_2nd_Lvl_Rel_Orig_Plan_Del_Date
    {
        public TempFour data;

        public PR_2nd_Lvl_Rel_Orig_Plan_Del_Date()
        {
            data = new TempFour();
        }
    }
}
