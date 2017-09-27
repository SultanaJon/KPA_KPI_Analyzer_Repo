using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.Diagnostics;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPI_Sections
{
    public class PurchTwo
    {
        public PR_2nd_Lvl_Rel_Vs_PO_Creation pr2ndLvlRelVsPOCreation;
        public PO_Creation_vs_PO_Release poCreationVsPORel;
        public PO_Release_Vs_PO_Conf poRelVsPOConf;
        private double totalDays = 0;




        // Default Constructor
        public PurchTwo()
        {
            pr2ndLvlRelVsPOCreation = new PR_2nd_Lvl_Rel_Vs_PO_Creation();
            poCreationVsPORel = new PO_Creation_vs_PO_Release();
            poRelVsPOConf = new PO_Release_Vs_PO_Conf();
        }


        public string Name { get { return "Purch"; } }


        public enum CategorNames
        {
            pr2ndLvlRelVsPOCreation,
            poCreationVsPORel,
            poRelVsPOConf,
        }

        public string[] categoryNames =
        {
            "PR 2nd Lvl Release Date vs PO Creation Date",
            "PO Creation Date vs PO Release Date",
            "PO Release Date vs PO Confirmation Date",
        };






        /// <summary>
        /// Loads the data for the specific KPI
        /// </summary>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PR 2nd Level Release vs PO Creation
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in PRPO_DB_Utils.prsOnPOsDt.Rows)
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



                    string[] strPOLineCreateDate = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int poCreateDtYear = int.Parse(strPOLineCreateDate[2]);
                    int poCreateDtMonth = int.Parse(strPOLineCreateDate[0].TrimStart('0'));
                    int poCreateDtDay = int.Parse(strPOLineCreateDate[1].TrimStart('0'));

                    DateTime poLineCreateDate = new DateTime(poCreateDtYear, poCreateDtMonth, poCreateDtDay);

                    string[] strPR2ndLvlRelDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    int secLvlRelYear = int.Parse(strPR2ndLvlRelDate[2]);
                    int secLvlRelMonth = int.Parse(strPR2ndLvlRelDate[0].TrimStart('0'));
                    int secLvlRelDay = int.Parse(strPR2ndLvlRelDate[1].TrimStart('0'));

                    DateTime pr2ndLvlRelDate = new DateTime(secLvlRelYear, secLvlRelMonth, secLvlRelDay);
                    double elapsedDays = (poLineCreateDate - pr2ndLvlRelDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    pr2ndLvlRelVsPOCreation.data.Total++;


                    if (elapsedDays <= 0)
                    {
                        pr2ndLvlRelVsPOCreation.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        pr2ndLvlRelVsPOCreation.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        pr2ndLvlRelVsPOCreation.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        pr2ndLvlRelVsPOCreation.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        pr2ndLvlRelVsPOCreation.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        pr2ndLvlRelVsPOCreation.data.TwentyTwo_TwentyEight++;
                    }
                    else if(elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        pr2ndLvlRelVsPOCreation.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        pr2ndLvlRelVsPOCreation.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        pr2ndLvlRelVsPOCreation.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50 && elapsedDays <= 56)
                    {
                        pr2ndLvlRelVsPOCreation.data.Fifty_FiftySix++;
                    }
                    else // elapsed days is >= 57
                    {
                        pr2ndLvlRelVsPOCreation.data.greaterThanEqualFiftySeven++;
                    }
                }

                try
                {
                    pr2ndLvlRelVsPOCreation.data.Average = Math.Round(totalDays / pr2ndLvlRelVsPOCreation.data.Total, 2);
                    if (double.IsNaN(pr2ndLvlRelVsPOCreation.data.Average))
                        pr2ndLvlRelVsPOCreation.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    pr2ndLvlRelVsPOCreation.data.Average = 0;
                }


                totalDays = 0;



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PO Creation vs PO Release
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in PRPO_DB_Utils.prsOnPOsDt.Rows)
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



                    string[] strPOLine1stRelDt = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                    int poLine1stRelDtYear = int.Parse(strPOLine1stRelDt[2]);
                    int poLine1stRelDtMonth = int.Parse(strPOLine1stRelDt[0]);
                    int poLine1stRelDtDay = int.Parse(strPOLine1stRelDt[1]);

                    if(poLine1stRelDtYear == 0 && poLine1stRelDtMonth == 0 && poLine1stRelDtDay == 0)
                    {
                        
                        continue;
                    }
                    else
                    {
                        poCreationVsPORel.data.Total++;
                        poLine1stRelDtYear = int.Parse(strPOLine1stRelDt[2]);
                        poLine1stRelDtMonth = int.Parse(strPOLine1stRelDt[0].TrimStart('0'));
                        poLine1stRelDtDay = int.Parse(strPOLine1stRelDt[1].TrimStart('0'));
                    }

                    DateTime poLine1stRelDate = new DateTime(poLine1stRelDtYear, poLine1stRelDtMonth, poLine1stRelDtDay);

                    string[] strPOLineCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int poOLineCreateDtYear = int.Parse(strPOLineCreateDt[2]);
                    int poOLineCreateDtMonth = int.Parse(strPOLineCreateDt[0].TrimStart('0'));
                    int poOLineCreateDtDay = int.Parse(strPOLineCreateDt[1].TrimStart('0'));

                    DateTime poCreateDate = new DateTime(poOLineCreateDtYear, poOLineCreateDtMonth, poOLineCreateDtDay);
                    double elapsedDays = (poLine1stRelDate - poCreateDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    if (elapsedDays <= 0)
                    {
                        poCreationVsPORel.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        poCreationVsPORel.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        poCreationVsPORel.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        poCreationVsPORel.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        poCreationVsPORel.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        poCreationVsPORel.data.TwentyTwo_TwentyEight++;
                    }
                    else if (elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        poCreationVsPORel.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        poCreationVsPORel.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        poCreationVsPORel.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50 && elapsedDays <= 56)
                    {
                        poCreationVsPORel.data.Fifty_FiftySix++;
                    }
                    else // elapsed days is >= 57
                    {
                        poCreationVsPORel.data.greaterThanEqualFiftySeven++;
                    }
                }


                try
                {
                    poCreationVsPORel.data.Average = Math.Round(totalDays / poCreationVsPORel.data.Total, 2);
                    if (double.IsNaN(poCreationVsPORel.data.Average))
                        poCreationVsPORel.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    poCreationVsPORel.data.Average = 0;
                }


                totalDays = 0;





                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PO Release vs PO Confirm
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in PRPO_DB_Utils.prsOnPOsDt.Rows)
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




                    string[] strPOLineFirstRelDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                    int poLineFirstRelDateYear = int.Parse(strPOLineFirstRelDate[2]);
                    int poLineFirstRelDateMonth = int.Parse(strPOLineFirstRelDate[0]);
                    int poLineFirstRelDateDay = int.Parse(strPOLineFirstRelDate[1]);

                    if(poLineFirstRelDateYear == 0 && poLineFirstRelDateMonth == 0 && poLineFirstRelDateDay == 0)
                    {
                        continue;
                    }
                    else
                    {
                        poLineFirstRelDateYear = int.Parse(strPOLineFirstRelDate[2]);
                        poLineFirstRelDateMonth = int.Parse(strPOLineFirstRelDate[0].TrimStart('0'));
                        poLineFirstRelDateDay = int.Parse(strPOLineFirstRelDate[1].TrimStart('0'));
                    }

                    DateTime poLineFirstRelDate = new DateTime(poLineFirstRelDateYear, poLineFirstRelDateMonth, poLineFirstRelDateDay);

                    string[] strPOLineFirstConfCreateDate = (dr["1st Conf Creation Da"].ToString()).Split('/');
                    int poLineFirstConfCreateYear = int.Parse(strPOLineFirstConfCreateDate[2]);
                    int poLineFirstConfCreateMonth = int.Parse(strPOLineFirstConfCreateDate[0]);
                    int poLineFirstConfCreateDay = int.Parse(strPOLineFirstConfCreateDate[1]);


                    if(poLineFirstConfCreateYear == 0 && poLineFirstConfCreateMonth == 0 && poLineFirstConfCreateDay == 0)
                    {
                        poRelVsPOConf.data.PercentUnconfTotal++;
                        continue;
                    }
                    else
                    {
                        poLineFirstConfCreateYear = int.Parse(strPOLineFirstConfCreateDate[2]);
                        poLineFirstConfCreateMonth = int.Parse(strPOLineFirstConfCreateDate[0].TrimStart('0'));
                        poLineFirstConfCreateDay = int.Parse(strPOLineFirstConfCreateDate[1].TrimStart('0'));
                    }

                    poRelVsPOConf.data.Total++;

                    DateTime poLineFirstConfCreateDt = new DateTime(poLineFirstConfCreateYear, poLineFirstConfCreateMonth, poLineFirstConfCreateDay);

                    double elapsedDays = (poLineFirstConfCreateDt - poLineFirstRelDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    if (elapsedDays <= 0)
                    {
                        poRelVsPOConf.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        poRelVsPOConf.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        poRelVsPOConf.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        poRelVsPOConf.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        poRelVsPOConf.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        poRelVsPOConf.data.TwentyTwo_TwentyEight++;
                    }
                    else if (elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        poRelVsPOConf.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        poRelVsPOConf.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        poRelVsPOConf.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50 && elapsedDays <= 56)
                    {
                        poRelVsPOConf.data.Fifty_FiftySix++;
                    }
                    else // elapsed days is >= 57
                    {
                        poRelVsPOConf.data.greaterThanEqualFiftySeven++;
                    }
                }


                try
                {
                    poRelVsPOConf.data.Average = Math.Round(totalDays / poRelVsPOConf.data.Total, 2);
                    if (double.IsNaN(poRelVsPOConf.data.Average))
                        poRelVsPOConf.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    poRelVsPOConf.data.Average = 0;
                }

                try
                {
                    poRelVsPOConf.data.PercentUnconf = Math.Round(((double)poRelVsPOConf.data.PercentUnconfTotal / poRelVsPOConf.data.Total) * 100, 2);

                    if (double.IsNaN(poRelVsPOConf.data.PercentUnconf))
                        poRelVsPOConf.data.PercentUnconf = 0;

                    if (double.IsInfinity(poRelVsPOConf.data.PercentUnconf))
                        poRelVsPOConf.data.PercentUnconf = 100;
                }
                catch (DivideByZeroException)
                {
                    poRelVsPOConf.data.PercentUnconf = 0;
                }


                PRPO_DB_Utils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Purch Two Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    public class PR_2nd_Lvl_Rel_Vs_PO_Creation
    {
        public TempFour data;

        public PR_2nd_Lvl_Rel_Vs_PO_Creation()
        {
            data = new TempFour();
        }
    }






    public class PO_Creation_vs_PO_Release
    {
        public TempFour data;

        public PO_Creation_vs_PO_Release()
        {
            data = new TempFour();
        }
    }






    public class PO_Release_Vs_PO_Conf
    {
        public TempFour data;

        public PO_Release_Vs_PO_Conf()
        {
            data = new TempFour();
        }
    }
}
