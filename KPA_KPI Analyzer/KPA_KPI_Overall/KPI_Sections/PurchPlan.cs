using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPI_Sections
{
    public class PurchPlan
    {
        public Po_Rel_vs_PR_Del_Date poRelVsPRDelDate;
        public PR_2nd_Lvl_Rel_Orig_Plan_Del_Date pr2ndLvlRelOrigPlanDelDate;
        private double totalDays = 0;
        string[] strPoLineFirstRelDate;





        // Default Constructor
        public PurchPlan()
        {
            poRelVsPRDelDate = new Po_Rel_vs_PR_Del_Date();
            pr2ndLvlRelOrigPlanDelDate = new PR_2nd_Lvl_Rel_Orig_Plan_Del_Date();
        }




        public string Name { get { return "Purch Plan"; } }


        public enum CategorNames
        {
            poRelVsPRDelDate,
            pr2ndLvlRelOrigPlanDelDate
        }

        public string[] categoryNames =
        {
            "PO Release vs PR Delivery Date",
            "PR 2nd Lvl Release Date to Original Planned Delivery Date",
        };





        /// <summary>
        /// Loads the data for the specifc KPI
        /// </summary>
        /// <param name="SelectedCountry"></param>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PO Release vs PR Delivery Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in PRPO_DB_Utils.prsOnPOsDt.Rows)
                {
                    if (Filters.FilterByPrDateRange)
                    {
                        if (!FilterUtils.PrDateInRange(dr))
                        {
                            // The PR Date was not in range of the filter the user applied.
                            continue;
                        }
                    }

                    if (Filters.FilterByPoDateRange)
                    {
                        if (!FilterUtils.PoCreateDateInRange(dr))
                        {
                            // The PO Date was not in range of the filter the user applied.
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
                        poRelVsPRDelDate.data.GreaterThanEqualFiftySeven++;
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
                foreach (DataRow dr in PRPO_DB_Utils.pr2ndLvlRelDateDt.Rows)
                {
                    if (Filters.FilterByPrDateRange)
                    {
                        if (!FilterUtils.PrDateInRange(dr))
                        {
                            // The PR Date was not in range of the filter the user applied.
                            continue;
                        }
                    }

                    if (Filters.FilterByPoDateRange)
                    {
                        if (!FilterUtils.PoCreateDateInRange(dr))
                        {
                            // The PO Date was not in range of the filter the user applied.
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
                        pr2ndLvlRelOrigPlanDelDate.data.GreaterThanEqualFiftySeven++;
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

                PRPO_DB_Utils.UpdateLoadProgress();
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
