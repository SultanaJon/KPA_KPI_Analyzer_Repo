using KPA_KPI_Analyzer.Database;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPA_Sections
{
    public class Current_Plan_vs_Actual
    {
        public Curr_Plan_Date_vs_Curr_Conf_Date_OpenPOs currPlanDateCurrConfDate;
        public Curr_Plan_Date_vs_Curr_Conf_Date_OpenPOs_HotJobs currPlanDateCurrConfDateHotJobs;
        private double totalDays = 0;
        private DataTable dt;
        private OleDbCommand cmd;
        private OleDbDataAdapter da;




        public Current_Plan_vs_Actual()
        {
            currPlanDateCurrConfDate = new Curr_Plan_Date_vs_Curr_Conf_Date_OpenPOs();
            currPlanDateCurrConfDateHotJobs = new Curr_Plan_Date_vs_Curr_Conf_Date_OpenPOs_HotJobs();
        }






        public string Name { get { return "Current Plan vs Actual"; } }


        public enum CategorNames
        {
            CurrPlanDateVsCurrConfDate,
            CurrPlanDateVsCurrConfDate_HJsOnly,
        }

        public string[] categoryNames =
        {
            "Current Plan Date vs Current Confirmation Date",
            "Current Plan Date vs Current Confirmation Date - Hot Jobs Only",
        };




        /// <summary>
        /// Loads the data of the specific KPA.
        /// </summary>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Current Planned Date vs Current Confirmation Date (Open POs)
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = new DataTable();
                cmd = new OleDbCommand(Database.QueryManager.KpaQueries.CurrentPlanVsActualQueries.GetCurrentPlanDateVsCurrentConfirmationDate() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);
                da = new OleDbDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
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


                    string[] strDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime confDate = new DateTime(year, month, day);


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

                    DateTime currPlanDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                    double elapsedDays = (confDate - currPlanDate).TotalDays;

                    // Our time spans are in weeks but we want to catch the average amount of days.
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    int weeks = 0;
                    if (elapsedDays < 0)
                        weeks = (int)Math.Floor(elapsedDays / 7);
                    else if (elapsedDays == 0)
                        weeks = 0;
                    else // elapsed days > 0
                        weeks = (int)Math.Ceiling(elapsedDays / 7);

                    currPlanDateCurrConfDate.data.Total++;

                    if (weeks < (-3))
                    {
                        currPlanDateCurrConfDate.data.LessThanMinusThree++;
                    }
                    else if (weeks >= (-3) && weeks < (-2))
                    {
                        currPlanDateCurrConfDate.data.GreaterThanEqualMinusThree++;
                    }
                    else if (weeks >= (-2) && weeks < (-1))
                    {
                        currPlanDateCurrConfDate.data.GreaterThanEqualMinusTwo++;
                    }
                    else if (weeks >= (-1) && weeks < 0)
                    {
                        currPlanDateCurrConfDate.data.GreaterThanEqualMinusOne++;
                    }
                    else if (weeks == 0)
                    {
                        currPlanDateCurrConfDate.data.ZeroWeeks++;
                    }
                    else if (weeks > 0 && weeks <= 1)
                    {
                        currPlanDateCurrConfDate.data.LessThanEqualOneWeek++;
                    }
                    else if (weeks > 1 && weeks <= 2)
                    {
                        currPlanDateCurrConfDate.data.LessThanEqualTwoWeeks++;
                    }
                    else if (weeks > 2 && weeks <= 3)
                    {
                        currPlanDateCurrConfDate.data.LessThanEqualThreeWeeks++;
                    }
                    else // Greater than 3 weeks
                    {
                        currPlanDateCurrConfDate.data.GreaterThanThreeWeeks++;
                    }
                }

                try
                {
                    currPlanDateCurrConfDate.data.Average = Math.Round(totalDays / currPlanDateCurrConfDate.data.Total, 2);
                    if (double.IsNaN(currPlanDateCurrConfDate.data.Average))
                        currPlanDateCurrConfDate.data.Average = 0;
                }
                catch(DivideByZeroException)
                {
                    currPlanDateCurrConfDate.data.Average = 0;
                }

                totalDays = 0;




                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Current Planned Date vs Current Confirmation Date (Open POs)
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = new DataTable();
                cmd = new OleDbCommand(Database.QueryManager.KpaQueries.CurrentPlanVsActualQueries.GetCurrentPlanDateVsCurrentConfirmationDateForHotJobs() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);
                da = new OleDbDataAdapter(cmd);
                da.Fill(dt);


                foreach (DataRow dr in dt.Rows)
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

                    string[] strDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime confDate = new DateTime(year, month, day);

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

                    DateTime currPlanDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                    double elapsedDays = (confDate - currPlanDate).TotalDays; // keep this a double so we can calculate an acccurate average


                    // Our time spans are in weeks but we want to catch the average amount of days.
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    int weeks = 0;
                    if (elapsedDays < 0)
                        weeks = (int)Math.Floor(elapsedDays / 7);
                    else if (elapsedDays == 0)
                        weeks = 0;
                    else
                        weeks = (int)Math.Ceiling(elapsedDays / 7);

                    currPlanDateCurrConfDateHotJobs.data.Total++;

                    if (weeks < (-3))
                    {
                        currPlanDateCurrConfDateHotJobs.data.LessThanMinusThree++;
                    }
                    else if (weeks >= (-3) && weeks < (-2))
                    {
                        currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusThree++;
                    }
                    else if (weeks >= (-2) && weeks < (-1))
                    {
                        currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusTwo++;
                    }
                    else if (weeks >= (-1) && weeks < 0)
                    {
                        currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusOne++;
                    }
                    else if (weeks == 0)
                    {
                        currPlanDateCurrConfDateHotJobs.data.ZeroWeeks++;
                    }
                    else if (weeks > 0 && weeks <= 1)
                    {
                        currPlanDateCurrConfDateHotJobs.data.LessThanEqualOneWeek++;
                    }
                    else if (weeks > 1 && weeks <= 2)
                    {
                        currPlanDateCurrConfDateHotJobs.data.LessThanEqualTwoWeeks++;
                    }
                    else if (weeks > 2 && weeks <= 3)
                    {
                        currPlanDateCurrConfDateHotJobs.data.LessThanEqualThreeWeeks++;
                    }
                    else // Greater than 3 weeks
                    {
                        currPlanDateCurrConfDateHotJobs.data.GreaterThanThreeWeeks++;
                    }
                }

                try
                {
                    currPlanDateCurrConfDateHotJobs.data.Average = Math.Round(totalDays / currPlanDateCurrConfDateHotJobs.data.Total, 2);
                    if (double.IsNaN(currPlanDateCurrConfDateHotJobs.data.Average))
                        currPlanDateCurrConfDateHotJobs.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    currPlanDateCurrConfDateHotJobs.data.Average = 0;
                }

                DatabaseUtils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Current Plan vs Actual Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }





    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //
    //  The below classes act as a specific KPA category that fall under a specific KPA section.
    //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Curr_Plan_Date_vs_Curr_Conf_Date_OpenPOs
    {
        public TempTwo data;

        public Curr_Plan_Date_vs_Curr_Conf_Date_OpenPOs()
        {
            data = new TempTwo();
        }
    }






    public class Curr_Plan_Date_vs_Curr_Conf_Date_OpenPOs_HotJobs
    {
        public TempTwo data;

        public Curr_Plan_Date_vs_Curr_Conf_Date_OpenPOs_HotJobs()
        {
            data = new TempTwo();
        }
    }
}
