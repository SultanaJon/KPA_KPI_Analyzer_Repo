﻿using Excel_Access_Tools.Access;
using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPA_Sections
{
    public class Follow_Up
    {
        public Conf_vs_Plan_Date confDateVsPlanDate;
        public Conf_Date_Upcoming_Del ConfDateForUpcomingDel;
        //public Late_Conf_Date LateToConfDate;
        private double totalDays = 0;

        // Default Constructor
        public Follow_Up()
        {
            confDateVsPlanDate = new Conf_vs_Plan_Date();
            ConfDateForUpcomingDel = new Conf_Date_Upcoming_Del();
            //LateToConfDate = new Late_Conf_Date();
        }



        /// <summary>
        /// Loads the data for the specific KPA
        /// </summary>
        /// <param name="Overall.SelectedCountry"></param>
        public void LoadData()
        {
            try
            {

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Confirmed vs Plan Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                DataTable dt = new DataTable();
                OleDbCommand cmd;
                if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_FollowUp_ConfPlanDate] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                else
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_FollowUp_ConfPlanDate] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);

                confDateVsPlanDate.data.Total = dt.Rows.Count;

                foreach (DataRow dr in dt.Rows)
                {
                    string[] strCurrConfDate = (dr["Del#Conf#Date"].ToString()).Split('/');
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
                dt = new DataTable();
                if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_FollowUp_ConfDateUpcomingDel] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                else
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_FollowUp_ConfDateUpcomingDel] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);

                da = new OleDbDataAdapter(cmd);
                da.Fill(dt);

                ConfDateForUpcomingDel.data.Total = dt.Rows.Count;

                foreach (DataRow dr in dt.Rows)
                {
                    string[] strDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime date = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (date - today).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;


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
                }
                catch (DivideByZeroException)
                {
                    ConfDateForUpcomingDel.data.Average = 0;
                }
                totalDays = 0;
                PRPO_DB_Utils.CompletedDataLoads++;
                MethodInvoker del = delegate
                {
                    PRPO_DB_Utils.UpdateDataLoadProgress();
                };
                del.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Follow Up Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        }





        public class Conf_Date_Upcoming_Del
        {
            public TempOne data;

            public Conf_Date_Upcoming_Del()
            {
                data = new TempOne();
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
