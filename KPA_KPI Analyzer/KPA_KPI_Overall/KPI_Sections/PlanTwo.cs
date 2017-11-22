using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPI_Sections
{
    public class PlanTwo
    {
        public MaterialDueOrigPlannedDate materialDueOrigPlanDate;
        public MaterialDueFinalPlanDate materialDueFinalPlanDate;
        private double totalDays = 0;

        // Default Constructor
        public PlanTwo()
        {
            materialDueOrigPlanDate = new MaterialDueOrigPlannedDate();
            materialDueFinalPlanDate = new MaterialDueFinalPlanDate();
        }


        public string Name { get { return "Plan"; } }


        public enum CategoryNames
        {
            materialDueOrigPlanDate,
            materialDueFinalPlanDate
        }


        public string[] categoryNames =
        {
            "Material Due Original Planned Date",
            "Material Due Final Planned Date"
        };





        /// <summary>
        /// Loads the data of a specific KPI
        /// </summary>
        /// <param name="SelectedCountry"></param>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Material Due Original Planned Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in PRPO_DB_Utils.pr2ndLvlRelDateDt.Rows)
                {
                    if (Filters.DateFilters.FilterByPrDateRange)
                    {
                        if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                        {
                            // The PR Date was not in range of the filter the user applied
                            continue;
                        }
                    }

                    if (Filters.DateFilters.FilterByPoDateRange)
                    {
                        if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                        {
                            // The PO Date was not in range of the filter the user applied.
                            continue;
                        }
                    }

                    if (Filters.DateFilters.FilterByFinalReceiptDate)
                    {
                        if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                        {
                            // The final receipt date was not in range of the filter the user applied
                            continue;
                        }
                    }

                    if (Filters.AdvancedFilters.AdvanceFiltersChanged())
                    {
                        // We have some advanced filters that the user would like to exclude.
                        if (!FilterUtils.CheckAdvancedFilters(dr))
                            continue;
                    }



                    string[] strOrigPlanDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int origPlanYear = int.Parse(strOrigPlanDate[2]);
                    int origPlanMonth = int.Parse(strOrigPlanDate[0]);
                    int origPlanDay = int.Parse(strOrigPlanDate[1]);


                    // This is a tempory fix for MEXICO TAG_MEXICO_FIX
                    // DELETE the refion below this commented code and uncomment this code.

                    //string[] strPr2ndLvlRelDt = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    //int pr2ndLvlRelYear = int.Parse(strPr2ndLvlRelDt[2]);
                    //int pr2ndLvlRelMonth = int.Parse(strPr2ndLvlRelDt[0].TrimStart('0'));
                    //int pr2ndLvlRelDay = int.Parse(strPr2ndLvlRelDt[1].TrimStart('0'));

                    #region MEXICOs TEMP FIX

                    string[] strPr2ndLvlRelDt = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    int pr2ndLvlRelYear = int.Parse(strPr2ndLvlRelDt[2]);
                    int pr2ndLvlRelMonth = int.Parse(strPr2ndLvlRelDt[0]);
                    int pr2ndLvlRelDay = int.Parse(strPr2ndLvlRelDt[1]);

                    if (pr2ndLvlRelYear == 0 && pr2ndLvlRelMonth == 0 && pr2ndLvlRelDay == 0)
                    {
                        // just ignore this bad Mexico data.
                        continue;
                    }
                    else
                    {
                        pr2ndLvlRelYear = int.Parse(strPr2ndLvlRelDt[2]);
                        pr2ndLvlRelMonth = int.Parse(strPr2ndLvlRelDt[0].TrimStart('0'));
                        pr2ndLvlRelDay = int.Parse(strPr2ndLvlRelDt[1].TrimStart('0'));
                    }

                    #endregion




                    DateTime pr2ndRelDate = new DateTime(pr2ndLvlRelYear, pr2ndLvlRelMonth, pr2ndLvlRelDay);
                    DateTime origPlanDate = new DateTime(origPlanYear, origPlanMonth, origPlanDay);

                    double elapsedDays = (origPlanDate - pr2ndRelDate).TotalDays;
                    totalDays += elapsedDays;

                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);

                    if (elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);

                    elapsedDays = (int)elapsedDays;



                    materialDueOrigPlanDate.data.Total++;



                    if (elapsedDays <= 0)
                    {
                        materialDueOrigPlanDate.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        materialDueOrigPlanDate.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        materialDueOrigPlanDate.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        materialDueOrigPlanDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        materialDueOrigPlanDate.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        materialDueOrigPlanDate.data.TwentyTwo_TwentyEight++;
                    }
                    else if (elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        materialDueOrigPlanDate.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        materialDueOrigPlanDate.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        materialDueOrigPlanDate.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50 && elapsedDays <= 56)
                    {
                        materialDueOrigPlanDate.data.Fifty_FiftySix++;
                    }
                    else // elapsed days is >= 57
                    {
                        materialDueOrigPlanDate.data.GreaterThanEqualFiftySeven++;
                    }
                }



                try
                {
                    materialDueOrigPlanDate.data.Average = Math.Round(totalDays / materialDueOrigPlanDate.data.Total, 2);
                    if (double.IsNaN(materialDueOrigPlanDate.data.Average))
                        materialDueOrigPlanDate.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    materialDueOrigPlanDate.data.Average = 0;
                }

                totalDays = 0;




                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Material Due Final Planned Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in PRPO_DB_Utils.prsOnPOsDt.Rows)
                {
                    if (Filters.DateFilters.FilterByPrDateRange)
                    {
                        if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                        {
                            // The PR Date was not in range of the filter the user applied.
                            continue;
                        }
                    }

                    if (Filters.DateFilters.FilterByPoDateRange)
                    {
                        if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                        {
                            // The PO Date was not in range of the filter the user applied.
                            continue;
                        }
                    }

                    if (Filters.DateFilters.FilterByFinalReceiptDate)
                    {
                        if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                        {
                            // The final receipt date was not in range of the filter the user applied
                            continue;
                        }
                    }

                    if (Filters.AdvancedFilters.AdvanceFiltersChanged())
                    {
                        // We have some advanced filters that the user would like to exclude.
                        if (!FilterUtils.CheckAdvancedFilters(dr))
                            continue;
                    }



                    // This is a tempory fix for MEXICO TAG_MEXICO_FIX
                    // DELETE the refion below this commented code and uncomment this code.

                    //string[] strPr2ndLvlRelDt = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    //int pr2ndLvlRelYear = int.Parse(strPr2ndLvlRelDt[2]);
                    //int pr2ndLvlRelMonth = int.Parse(strPr2ndLvlRelDt[0].TrimStart('0'));
                    //int pr2ndLvlRelDay = int.Parse(strPr2ndLvlRelDt[1].TrimStart('0'));

                    #region MEXICOs TEMP FIX

                    string[] strPr2ndLvlRelDt = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    int pr2ndLvlRelYear = int.Parse(strPr2ndLvlRelDt[2]);
                    int pr2ndLvlRelMonth = int.Parse(strPr2ndLvlRelDt[0]);
                    int pr2ndLvlRelDay = int.Parse(strPr2ndLvlRelDt[1]);

                    if (pr2ndLvlRelYear == 0 && pr2ndLvlRelMonth == 0 && pr2ndLvlRelDay == 0)
                    {
                        // just ignore this bad Mexico data.
                        continue;
                    }
                    else
                    {
                        pr2ndLvlRelYear = int.Parse(strPr2ndLvlRelDt[2]);
                        pr2ndLvlRelMonth = int.Parse(strPr2ndLvlRelDt[0].TrimStart('0'));
                        pr2ndLvlRelDay = int.Parse(strPr2ndLvlRelDt[1].TrimStart('0'));
                    }

                    #endregion

                    string[] strCurrPlanDate = (dr["Rescheduling date"].ToString()).Split('/');
                    int origPlanYear = int.Parse(strCurrPlanDate[2]);
                    int origPlanMonth = int.Parse(strCurrPlanDate[0]);
                    int origPlanDay = int.Parse(strCurrPlanDate[1]);

                    if (origPlanYear == 0 && origPlanMonth == 0 && origPlanDay == 0)
                    {
                        string[] strNewCurrPlanDelDate = (dr["Delivery Date"].ToString()).Split('/');
                        origPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                        origPlanMonth = int.Parse(strNewCurrPlanDelDate[0]);
                        origPlanDay = int.Parse(strNewCurrPlanDelDate[1]);

                        if (origPlanYear == 0 && origPlanMonth == 0 && origPlanDay == 0)
                        {
                            string[] strNewCurrPlanPrDelDate = (dr["PR Delivery Date"].ToString()).Split('/');
                            origPlanYear = int.Parse(strNewCurrPlanPrDelDate[2]);
                            origPlanMonth = int.Parse(strNewCurrPlanPrDelDate[0].TrimStart('0'));
                            origPlanDay = int.Parse(strNewCurrPlanPrDelDate[1].TrimStart('0'));
                        }
                        else
                        {
                            origPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                            origPlanMonth = int.Parse(strNewCurrPlanDelDate[0].TrimStart('0'));
                            origPlanDay = int.Parse(strNewCurrPlanDelDate[1].TrimStart('0'));
                        }
                    }
                    else
                    {
                        origPlanYear = int.Parse(strCurrPlanDate[2]);
                        origPlanMonth = int.Parse(strCurrPlanDate[0].TrimStart('0'));
                        origPlanDay = int.Parse(strCurrPlanDate[1].TrimStart('0'));
                    }

                    DateTime pr2ndRelDate = new DateTime(pr2ndLvlRelYear, pr2ndLvlRelMonth, pr2ndLvlRelDay);
                    DateTime currPlanDate = new DateTime(origPlanYear, origPlanMonth, origPlanDay);

                    double elapsedDays = (currPlanDate - pr2ndRelDate).TotalDays;
                    totalDays += elapsedDays;


                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);

                    if (elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);

                    elapsedDays = (int)elapsedDays;



                    materialDueFinalPlanDate.data.Total++;




                    if (elapsedDays <= 0)
                    {
                        materialDueFinalPlanDate.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        materialDueFinalPlanDate.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        materialDueFinalPlanDate.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        materialDueFinalPlanDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        materialDueFinalPlanDate.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        materialDueFinalPlanDate.data.TwentyTwo_TwentyEight++;
                    }
                    else if (elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        materialDueFinalPlanDate.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        materialDueFinalPlanDate.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        materialDueFinalPlanDate.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50 && elapsedDays <= 56)
                    {
                        materialDueFinalPlanDate.data.Fifty_FiftySix++;
                    }
                    else // elapsed days is >= 57
                    {
                        materialDueFinalPlanDate.data.GreaterThanEqualFiftySeven++;
                    }
                }



                try
                {
                    materialDueFinalPlanDate.data.Average = Math.Round(totalDays / materialDueFinalPlanDate.data.Total, 2);
                    if (double.IsNaN(materialDueFinalPlanDate.data.Average))
                        materialDueFinalPlanDate.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    materialDueFinalPlanDate.data.Average = 0;
                }

                totalDays = 0;
                PRPO_DB_Utils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Plan Two Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ThreadInteruptedException();
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

    public class MaterialDueOrigPlannedDate
    {
        public TempFour data;

        public MaterialDueOrigPlannedDate()
        {
            data = new TempFour();
        }
    }


    public class MaterialDueFinalPlanDate
    {
        public TempFour data;

        public MaterialDueFinalPlanDate()
        {
            data = new TempFour();
        }
    }
}
