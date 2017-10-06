using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPI_Sections
{
    public class Plan
    {
        public PR_Plan_Date_Curr_Plan prPlanDateVsCurrPlan;
        public Orig_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead origPlanDateMinus2ndLvlRelDateVsCodedLead;
        public Curr_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead currPlanDateMinus2ndLvlRelDateVsCodedLead;
        private double totalDays = 0;



        // Default Constructor
        public Plan()
        {
            prPlanDateVsCurrPlan = new PR_Plan_Date_Curr_Plan();
            origPlanDateMinus2ndLvlRelDateVsCodedLead = new Orig_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead();
            currPlanDateMinus2ndLvlRelDateVsCodedLead = new Curr_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead();
        }



        public string Name { get { return "Plan"; } }


        public enum CategorNames
        {
            prPlanDateVsCurrPlan,
            origPlanDateMinus2ndLvlRelDateVsCodedLead,
            currPlanDateMinus2ndLvlRelDateVsCodedLead,
        }

        public string[] categoryNames =
        {
            "PR Plan Date vs Current Plan Date",
            "(Original Plan Date - 2nd Lvl Release Date) vs Coded Lead-Time",
            "(Current Plan Date - 2nd Lvl Release Date) vs Coded Lead-Time",
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


                    prPlanDateVsCurrPlan.data.Total++;




                    if (elapsedDays <= (-22))
                    {
                        prPlanDateVsCurrPlan.data.Minus_TwentyTwo++;
                    }
                    else if (elapsedDays > (-22) && elapsedDays <= (-15))
                    {
                        prPlanDateVsCurrPlan.data.Minus_Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays > (-15) && elapsedDays <= (-8))
                    {
                        prPlanDateVsCurrPlan.data.Minus_Eight_Fourteen++;
                    }
                    else if (elapsedDays > (-8) && elapsedDays <= (-1))
                    {
                        prPlanDateVsCurrPlan.data.Minus_One_Seven++;
                    }
                    else if (elapsedDays == 0)
                    {
                        prPlanDateVsCurrPlan.data.Zero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 7)
                    {
                        prPlanDateVsCurrPlan.data.One_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        prPlanDateVsCurrPlan.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        prPlanDateVsCurrPlan.data.Fifteen_TwentyOne++;
                    }
                    else // 22 Days or greater
                    {
                        prPlanDateVsCurrPlan.data.TwentyTwo++;
                    }
                }



                try
                {
                    prPlanDateVsCurrPlan.data.Average = Math.Round(totalDays / prPlanDateVsCurrPlan.data.Total, 2);
                    if (double.IsNaN(prPlanDateVsCurrPlan.data.Average))
                        prPlanDateVsCurrPlan.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    prPlanDateVsCurrPlan.data.Average = 0;
                }

                totalDays = 0;



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // (Original Planned Date - 2nd Lvl Release Date) vs Coded Lead-time
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



                    string[] strPrPlanDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int delConfYear = int.Parse(strPrPlanDate[2]);
                    int delConfMonth = int.Parse(strPrPlanDate[0].TrimStart('0'));
                    int delConfDay = int.Parse(strPrPlanDate[1].TrimStart('0'));


                    string[] strPr2ndLvlRelDt = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    int pr2ndLvlRelYear = int.Parse(strPr2ndLvlRelDt[2]);
                    int pr2ndLvlRelMonth = int.Parse(strPr2ndLvlRelDt[0].TrimStart('0'));
                    int pr2ndLvlRelDay = int.Parse(strPr2ndLvlRelDt[1].TrimStart('0'));


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



                    string[] strPr2ndLvlRelDt = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    int pr2ndLvlRelYear = int.Parse(strPr2ndLvlRelDt[2]);
                    int pr2ndLvlRelMonth = int.Parse(strPr2ndLvlRelDt[0].TrimStart('0'));
                    int pr2ndLvlRelDay = int.Parse(strPr2ndLvlRelDt[1].TrimStart('0'));


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


                PRPO_DB_Utils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Plan Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    public class PR_Plan_Date_Curr_Plan
    {
        public TempThree data;

        public PR_Plan_Date_Curr_Plan()
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
