using KPA_KPI_Analyzer.Database;
using KPA_KPI_Analyzer.Filters;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPI_Sections
{
    public class Plan
    {
        public CurrPlanDateVsPrPlanDate currPlanDateVsPrPlanDate;
        public Orig_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead origPlanDateMinus2ndLvlRelDateVsCodedLead;
        public Curr_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead currPlanDateMinus2ndLvlRelDateVsCodedLead;
        private double totalDays = 0;



        // Default Constructor
        public Plan()
        {
            currPlanDateVsPrPlanDate = new CurrPlanDateVsPrPlanDate();
            origPlanDateMinus2ndLvlRelDateVsCodedLead = new Orig_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead();
            currPlanDateMinus2ndLvlRelDateVsCodedLead = new Curr_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead();
        }



        public string Name { get { return "Plan"; } }


        public enum CategorNames
        {
            currPlanVsPrPlanDate,
            origPlanDateMinus2ndLvlRelDateVsCodedLead,
            currPlanDateMinus2ndLvlRelDateVsCodedLead
        }



        public string[] categoryNames =
        {
            "Current Plan Date vs PR Plan Date",
            "(Original Plan Date - 2nd Lvl Release Date) vs Coded Lead-Time",
            "(Current Plan Date - 2nd Lvl Release Date) vs Coded Lead-Time"
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
                // PR Plan Date vs Current Plan Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in DatabaseUtils.prsOnPOsDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strPrPlanDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int delConfYear = int.Parse(strPrPlanDate[2]);
                    int delConfMonth = int.Parse(strPrPlanDate[0].TrimStart('0'));
                    int delConfDay = int.Parse(strPrPlanDate[1].TrimStart('0'));

                    DateTime prPlanDate = new DateTime(delConfYear, delConfMonth, delConfDay);

                    string[] strCurrPlanDate = (dr["Rescheduling date"].ToString()).Split('/');
                    int currConfYear = int.Parse(strCurrPlanDate[2]);
                    int currConfMonth = int.Parse(strCurrPlanDate[0]);
                    int currConfDay = int.Parse(strCurrPlanDate[1]);

                    if (currConfYear == 0 && currConfMonth == 0 && currConfDay == 0)
                    {
                        string[] strNewCurrConfDate = (dr["Delivery Date"].ToString()).Split('/');
                        currConfYear = int.Parse(strNewCurrConfDate[2]);
                        currConfMonth = int.Parse(strNewCurrConfDate[0].TrimStart('0'));
                        currConfDay = int.Parse(strNewCurrConfDate[1].TrimStart('0'));
                    }
                    else
                    {
                        currConfYear = int.Parse(strCurrPlanDate[2]);
                        currConfMonth = int.Parse(strCurrPlanDate[0].TrimStart('0'));
                        currConfDay = int.Parse(strCurrPlanDate[1].TrimStart('0'));
                    }

                    DateTime reqDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                    double elapsedDays = (reqDate - prPlanDate).TotalDays;
                    totalDays += elapsedDays;

                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);

                    if (elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);

                    elapsedDays = (int)elapsedDays;


                    currPlanDateVsPrPlanDate.data.Total++;




                    if (elapsedDays <= (-22))
                    {
                        currPlanDateVsPrPlanDate.data.Minus_TwentyTwo++;
                    }
                    else if (elapsedDays > (-22) && elapsedDays <= (-15))
                    {
                        currPlanDateVsPrPlanDate.data.Minus_Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays > (-15) && elapsedDays <= (-8))
                    {
                        currPlanDateVsPrPlanDate.data.Minus_Eight_Fourteen++;
                    }
                    else if (elapsedDays > (-8) && elapsedDays <= (-1))
                    {
                        currPlanDateVsPrPlanDate.data.Minus_One_Seven++;
                    }
                    else if (elapsedDays == 0)
                    {
                        currPlanDateVsPrPlanDate.data.Zero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 7)
                    {
                        currPlanDateVsPrPlanDate.data.One_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        currPlanDateVsPrPlanDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        currPlanDateVsPrPlanDate.data.Fifteen_TwentyOne++;
                    }
                    else // 22 Days or greater
                    {
                        currPlanDateVsPrPlanDate.data.TwentyTwo++;
                    }
                }



                try
                {
                    currPlanDateVsPrPlanDate.data.Average = Math.Round(totalDays / currPlanDateVsPrPlanDate.data.Total, 2);
                    if (double.IsNaN(currPlanDateVsPrPlanDate.data.Average))
                        currPlanDateVsPrPlanDate.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    currPlanDateVsPrPlanDate.data.Average = 0;
                }

                totalDays = 0;



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // (Original Planned Date - 2nd Lvl Release Date) vs Coded Lead-time
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in DatabaseUtils.pr2ndLvlRelDateDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }



                    string[] strPrPlanDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int delConfYear = int.Parse(strPrPlanDate[2]);
                    int delConfMonth = int.Parse(strPrPlanDate[0].TrimStart('0'));
                    int delConfDay = int.Parse(strPrPlanDate[1].TrimStart('0'));



                    // This is a tempory fix for MEXICO
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

                    DateTime prPlanDate = new DateTime(delConfYear, delConfMonth, delConfDay);
                    DateTime pr2ndRelDate = new DateTime(pr2ndLvlRelYear, pr2ndLvlRelMonth, pr2ndLvlRelDay);
                    int commCodeLeadTime = int.Parse(dr["Pl# Deliv# Time"].ToString());

                    double elapsedDays = (prPlanDate - pr2ndRelDate).TotalDays;
                    elapsedDays -= commCodeLeadTime;
                    totalDays += elapsedDays;


                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);

                    if (elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);

                    elapsedDays = (int)elapsedDays;


                    origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Total++;



                    if (elapsedDays <= (-22))
                    {
                        origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_TwentyTwo++;
                    }
                    else if (elapsedDays > (-22) && elapsedDays <= (-15))
                    {
                        origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays > (-15) && elapsedDays <= (-8))
                    {
                        origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Eight_Fourteen++;
                    }
                    else if (elapsedDays > (-8) && elapsedDays <= (-1))
                    {
                        origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_One_Seven++;
                    }
                    else if (elapsedDays == 0)
                    {
                        origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Zero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 7)
                    {
                        origPlanDateMinus2ndLvlRelDateVsCodedLead.data.One_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Fifteen_TwentyOne++;
                    }
                    else // 22 Days or greater
                    {
                        origPlanDateMinus2ndLvlRelDateVsCodedLead.data.TwentyTwo++;
                    }
                }



                try
                {
                    origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Average = Math.Round(totalDays / origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Total, 2);
                    if (double.IsNaN(origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Average))
                        origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Average = 0;
                }

                totalDays = 0;





                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // (Current Planned Date - 2nd Lvl Release Date) vs Coded Lead-Time
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in DatabaseUtils.pr2ndLvlRelDateDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
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
                    int currPlanYear = int.Parse(strCurrPlanDate[2]);
                    int currPlanMonth = int.Parse(strCurrPlanDate[0]);
                    int currPlanDay = int.Parse(strCurrPlanDate[1]);

                    if (currPlanYear == 0 && currPlanMonth == 0 && currPlanDay == 0)
                    {
                        string[] strNewCurrPlanDelDate = (dr["Delivery Date"].ToString()).Split('/');
                        currPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                        currPlanMonth = int.Parse(strNewCurrPlanDelDate[0]);
                        currPlanDay = int.Parse(strNewCurrPlanDelDate[1]);

                        if (currPlanYear == 0 && currPlanMonth == 0 && currPlanDay == 0)
                        {
                            string[] strNewCurrPlanPrDelDate = (dr["PR Delivery Date"].ToString()).Split('/');
                            currPlanYear = int.Parse(strNewCurrPlanPrDelDate[2]);
                            currPlanMonth = int.Parse(strNewCurrPlanPrDelDate[0].TrimStart('0'));
                            currPlanDay = int.Parse(strNewCurrPlanPrDelDate[1].TrimStart('0'));
                        }
                        else
                        {
                            currPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                            currPlanMonth = int.Parse(strNewCurrPlanDelDate[0].TrimStart('0'));
                            currPlanDay = int.Parse(strNewCurrPlanDelDate[1].TrimStart('0'));
                        }
                    }
                    else
                    {
                        currPlanYear = int.Parse(strCurrPlanDate[2]);
                        currPlanMonth = int.Parse(strCurrPlanDate[0].TrimStart('0'));
                        currPlanDay = int.Parse(strCurrPlanDate[1].TrimStart('0'));
                    }

                    DateTime pr2ndRelDate = new DateTime(pr2ndLvlRelYear, pr2ndLvlRelMonth, pr2ndLvlRelDay);
                    DateTime currPlanDate = new DateTime(currPlanYear, currPlanMonth, currPlanDay);
                    int commCodedLeadTime = int.Parse(dr["Pl# Deliv# Time"].ToString());

                    double elapsedDays = (currPlanDate - pr2ndRelDate).TotalDays;
                    elapsedDays -= commCodedLeadTime;
                    totalDays += elapsedDays;

                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);

                    if (elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);

                    elapsedDays = (int)elapsedDays;



                    currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Total++;




                    if (elapsedDays <= (-22))
                    {
                        currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_TwentyTwo++;
                    }
                    else if (elapsedDays > (-22) && elapsedDays <= (-15))
                    {
                        currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays > (-15) && elapsedDays <= (-8))
                    {
                        currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Eight_Fourteen++;
                    }
                    else if (elapsedDays > (-8) && elapsedDays <= (-1))
                    {
                        currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_One_Seven++;
                    }
                    else if (elapsedDays == 0)
                    {
                        currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Zero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 7)
                    {
                        currPlanDateMinus2ndLvlRelDateVsCodedLead.data.One_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Fifteen_TwentyOne++;
                    }
                    else // 22 Days or greater
                    {
                        currPlanDateMinus2ndLvlRelDateVsCodedLead.data.TwentyTwo++;
                    }
                }



                try
                {
                    currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Average = Math.Round(totalDays / currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Total, 2);
                    if (double.IsNaN(currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Average))
                        currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Average = 0;
                }

                totalDays = 0;


                DatabaseUtils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Plan Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ThreadInteruptedException();
            }
        }
    }




    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //
    //  The below classes act as a specific KPA category that fall under a specific KPA section.
    //
    //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class CurrPlanDateVsPrPlanDate
    {
        public TempThree data;

        public CurrPlanDateVsPrPlanDate()
        {
            data = new TempThree();
        }
    }



    public class Orig_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead
    {
        public TempThree data;

        public Orig_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead()
        {
            data = new TempThree();
        }
    }



    public class Curr_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead
    {
        public TempThree data;

        public Curr_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead()
        {
            data = new TempThree();
        }
    }
}
