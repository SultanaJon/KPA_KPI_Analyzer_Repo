﻿using DataAccessLibrary;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DataAccessLibrary.Exceptions;

namespace KPA_KPI_Analyzer.Overall_Data.KPA_Sections
{
    public class Follow_Up
    {
        public Conf_vs_Plan_Date confDateVsPlanDate;
        public Conf_Date_Upcoming_Del ConfDateForUpcomingDel;
        public Late_Conf_Date LateToConfDate;
        private double totalDays = 0;
        private DataTable dt;


        // Default Constructor
        public Follow_Up()
        {
            confDateVsPlanDate = new Conf_vs_Plan_Date();
            ConfDateForUpcomingDel = new Conf_Date_Upcoming_Del();
            LateToConfDate = new Late_Conf_Date();
        }



        public string Name { get { return "Follow Up"; } }


        public enum CategorNames
        {
            ConfirmedDateVsPlanDate,
            ConfirmedDateForUpcomingDel,
            LateToConfirmed
        }

        public string[] categoryNames =
        {
            "Confirmed Date vs Plan Date",
            "Confirmed Date for Upcoming Deliveries",
            "Due Today or Late to Confirmed"
        };



        /// <summary>
        /// Loads the data for the specific KPA
        /// </summary>
        /// <param name="SelectedCountry"></param>
        public void LoadData()
        {
            try
            {

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Confirmed vs Plan Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = KpaUtils.FollowUpQueries.GetConfirmedDateVsPlanDate();


                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }


                    string[] strCurrConfDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
                    int delConfYear = int.Parse(strCurrConfDate[2]);
                    int delConfMonth = int.Parse(strCurrConfDate[0].TrimStart('0'));
                    int delConfDay = int.Parse(strCurrConfDate[1].TrimStart('0'));

                    DateTime delConfDate = new DateTime(delConfYear, delConfMonth, delConfDay);

                    string[] strCurrPlanDate = (dr["Rescheduling date"].ToString()).Split('/');
                    int currConfYear = int.Parse(strCurrPlanDate[2]);
                    int currConfMonth = int.Parse(strCurrPlanDate[0]);
                    int currConfDay = int.Parse(strCurrPlanDate[1]);

                    if(currConfYear == 0 && currConfMonth == 0 && currConfDay == 0)
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

                    DateTime currPlanDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                    double elapsedDays = (delConfDate - currPlanDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    confDateVsPlanDate.data.Total++;

                    if (elapsedDays <= 0)
                    {
                        confDateVsPlanDate.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        confDateVsPlanDate.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        confDateVsPlanDate.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        confDateVsPlanDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        confDateVsPlanDate.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        confDateVsPlanDate.data.TwentyTwo_TwentyEight++;
                    }
                    else // 29+
                    {
                        confDateVsPlanDate.data.TwentyNinePlus++;
                    }
                }

                try
                {
                    confDateVsPlanDate.data.Average = Math.Round(totalDays / confDateVsPlanDate.data.Total, 2);
                    if (double.IsNaN(confDateVsPlanDate.data.Average))
                        confDateVsPlanDate.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    confDateVsPlanDate.data.Average = 0;
                }
                totalDays = 0;





                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Confirmed Date for Upcoing Deliveries
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = KpaUtils.FollowUpQueries.GetConfrimedDateForUpcomingDeliveries();

                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }



                    string[] strDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime date = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (date - today).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    ConfDateForUpcomingDel.data.Total++;


                    if (elapsedDays <= 0)
                    {
                        ConfDateForUpcomingDel.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        ConfDateForUpcomingDel.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        ConfDateForUpcomingDel.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        ConfDateForUpcomingDel.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        ConfDateForUpcomingDel.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        ConfDateForUpcomingDel.data.TwentyTwo_TwentyEight++;
                    }
                    else // 29+
                    {
                        ConfDateForUpcomingDel.data.TwentyNinePlus++;
                    }
                }

                try
                {
                    ConfDateForUpcomingDel.data.Average = Math.Round(totalDays / ConfDateForUpcomingDel.data.Total, 2);
                    if (double.IsNaN(ConfDateForUpcomingDel.data.Average))
                        ConfDateForUpcomingDel.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    ConfDateForUpcomingDel.data.Average = 0;
                }
                totalDays = 0;


                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Due Today or Late to Confrimed
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = KpaUtils.FollowUpQueries.GetDueTodayOrLateToConfirmed();


                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime date = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;

                    if (date > today)
                        continue;

                    double elapsedDays = (today - date).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    LateToConfDate.data.Total++;


                    if (elapsedDays <= 0)
                    {
                        LateToConfDate.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        LateToConfDate.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        LateToConfDate.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        LateToConfDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        LateToConfDate.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        LateToConfDate.data.TwentyTwo_TwentyEight++;
                    }
                    else // 29+
                    {
                        LateToConfDate.data.TwentyNinePlus++;
                    }
                }

                try
                {
                    LateToConfDate.data.Average = Math.Round(totalDays / LateToConfDate.data.Total, 2);
                    if (double.IsNaN(LateToConfDate.data.Average))
                        LateToConfDate.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    LateToConfDate.data.Average = 0;
                }

                totalDays = 0;


                // Get the favorable percentages for:
                //  - Confirmed Date vs Plan Date
                //  - Confirmed date for upcoming deliveries.
                GatherFavorablePercentages();

                DatabaseManager.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Follow Up Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ThreadInteruptedException();
            }
            finally
            {
                totalDays = 0;
                dt.Rows.Clear();
                dt = null;
                GC.Collect();
            }
        }




        /// <summary>
        /// Get the favorable percentages for the KPAs
        /// </summary>
        public void GatherFavorablePercentages()
        {
            confDateVsPlanDate.CalculatePercentFavorable();
            ConfDateForUpcomingDel.CalculatePercentFavorable(LateToConfDate.data.LessThanZero);
        }
            




        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        //
        //  The below classes act as a specific KPA category that fall under a specific KPA section.
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public class Conf_vs_Plan_Date
        {
            public TempOne data;

            public Conf_vs_Plan_Date()
            {
                data = new TempOne();
            }


            /// <summary>
            /// Get the percentage of favorable records.
            /// </summary>
            public void CalculatePercentFavorable()
            {
                if (data.Total != 0)
                {
                    // calculate the Percent Favorable
                    data.PercentFavorable = Math.Round(((double)data.LessThanZero / data.Total) * 100, 2);
                }
            }
        }





        public class Conf_Date_Upcoming_Del
        {
            public TempOne data;

            public Conf_Date_Upcoming_Del()
            {
                data = new TempOne();
            }



            /// <summary>
            /// Get the percentage of favorable records.
            /// </summary>
            /// <param name="LessThanZeroDueToday">The Less than zero time span count from due today or late to confirmed.</param>
            public void CalculatePercentFavorable(double LessThanZeroDueToday)
            {
                if (data.Total != 0)
                {
                    double favorableTimeSpanCounts = data.One_Three + data.Four_Seven + data.Eight_Fourteen + data.Fifteen_TwentyOne + data.TwentyTwo_TwentyEight + data.TwentyNinePlus;
                    double totalFavorable = favorableTimeSpanCounts + LessThanZeroDueToday;

                    // calculate the Percent Favorable
                    data.PercentFavorable = Math.Round((totalFavorable / data.Total) * 100, 2);
                }
            }
        }





        public class Late_Conf_Date
        {
            public TempOne data;

            public Late_Conf_Date()
            {
                data = new TempOne();
            }
        }
    }
}
