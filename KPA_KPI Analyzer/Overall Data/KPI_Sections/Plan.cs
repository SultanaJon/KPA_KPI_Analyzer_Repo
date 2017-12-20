using KPA_KPI_Analyzer.Database;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Overall_Data.KPI_Sections
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
            "(Original Plan Date - PR Fully Released Date) vs Coded Lead-Time",
            "(Current Plan Date - PR Fully Released Date) vs Coded Lead-Time"
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



                    #region EVASO_BUT_NOT_FULLY_RELEASED_CHECK

                    string[] strPrFullyRelDate = (dr["PR Fully Rel Date"].ToString()).Split('/');
                    int prFullyRelYear = int.Parse(strPrFullyRelDate[2]);
                    int prFullyRelMonth = int.Parse(strPrFullyRelDate[0]);
                    int prFullyRelDay = int.Parse(strPrFullyRelDate[1]);


                    if (prFullyRelYear == 0 && prFullyRelMonth == 0 && prFullyRelDay == 0)
                    {
                        // This PR line or PR in general might have been delted
                        continue;
                    }


                    #endregion

                    DateTime prFullyRelDt = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);
                    DateTime prPlanDate = new DateTime(delConfYear, delConfMonth, delConfDay);
                    int commCodeLeadTime = int.Parse(dr["Pl# Deliv# Time"].ToString());

                    double elapsedDays = (prPlanDate - prFullyRelDt).TotalDays;
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



                    #region EVASO_BUT_NOT_FULLY_RELEASED_CHECK

                    string[] strPrFullyRelDate = (dr["PR Fully Rel Date"].ToString()).Split('/');
                    int prFullyRelYear = int.Parse(strPrFullyRelDate[2]);
                    int prFullyRelMonth = int.Parse(strPrFullyRelDate[0]);
                    int prFullyRelDay = int.Parse(strPrFullyRelDate[1]);


                    if (prFullyRelYear == 0 && prFullyRelMonth == 0 && prFullyRelDay == 0)
                    {
                        // This PR line or PR in general might have been delted
                        continue;
                    }


                    #endregion

                    DateTime prFullyRelDt = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);


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

                    DateTime currPlanDate = new DateTime(currPlanYear, currPlanMonth, currPlanDay);
                    int commCodedLeadTime = int.Parse(dr["Pl# Deliv# Time"].ToString());

                    double elapsedDays = (currPlanDate - prFullyRelDt).TotalDays;
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


                // Get the percent favorable for these KPIs
                GatherPercentFavorable();

                DatabaseUtils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Plan Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ThreadInteruptedException();
            }
        }






        /// <summary>
        /// Gather the percent favorable for these KPIs.
        /// </summary>
        public void GatherPercentFavorable()
        {
            currPlanDateVsPrPlanDate.CalculatePercentFavorable();
            origPlanDateMinus2ndLvlRelDateVsCodedLead.CalculatePercentFavorable();
            currPlanDateMinus2ndLvlRelDateVsCodedLead.CalculatePercentFavorable();
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




        /// <summary>
        /// Get the percentage of favorable records.
        /// </summary>
        public void CalculatePercentFavorable()
        {
            if (data.Total != 0)
            {
                // Sum up the favorable time spans
                double favorableTimeSpans = data.Zero + data.One_Seven + data.Eight_Fourteen + data.Fifteen_TwentyOne + data.TwentyTwo;

                // calculate the Percent Favorable
                data.PercentFavorable = Math.Round((favorableTimeSpans / data.Total) * 100, 2);
            }
        }
    }



    public class Orig_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead
    {
        public TempThree data;

        public Orig_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead()
        {
            data = new TempThree();
        }



        /// <summary>
        /// Calculates the Percent of favorable line items within the data.
        /// </summary>
        public void CalculatePercentFavorable()
        {
            if (data.Total != 0)
            {
                // Get the favorable timespans
                double favorableTimeSpans = data.Zero + data.One_Seven + data.Eight_Fourteen + data.Fifteen_TwentyOne + data.TwentyTwo;

                // calculate the Percent Favorable
                data.PercentFavorable = Math.Round((favorableTimeSpans / data.Total) * 100, 2);
            }
        }
    }



    public class Curr_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead
    {
        public TempThree data;

        public Curr_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead()
        {
            data = new TempThree();
        }




        /// <summary>
        /// Calculates the percent of favorable line items within the data.
        /// </summary>
        public void CalculatePercentFavorable()
        {
            if (data.Total != 0)
            {
                // Get the favorable timespans
                double favorableTimeSpans = data.Zero + data.One_Seven + data.Eight_Fourteen + data.Fifteen_TwentyOne + data.TwentyTwo;


                // calculate the Percent Favorable
                data.PercentFavorable = Math.Round((favorableTimeSpans / data.Total) * 100, 2);
            }
        }
    }
}
