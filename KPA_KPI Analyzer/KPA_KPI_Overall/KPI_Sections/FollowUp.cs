using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPI_Sections
{
    public class FollowUp
    {
        public Init_Conf_vs_Curr_Conf initConfVsCurrConf;
        public Final_Conf_Date_vs_Final_Plan finalConfDateVsFinalPlan;
        public Receipt_Date_vs_Curr_Plan_Date receiptDateVsCurrPlanDate;
        public Receipt_Date_vs_Orig_Conf_Date receiptDateVsOrigConfDate;
        public Receipt_Date_vs_Curr_Conf_Date receiptDateVsCurrConfDate;
        private double totalDays = 0;



        // Default Constructor
        public FollowUp()
        {
            initConfVsCurrConf = new Init_Conf_vs_Curr_Conf();
            finalConfDateVsFinalPlan = new Final_Conf_Date_vs_Final_Plan();
            receiptDateVsCurrPlanDate = new Receipt_Date_vs_Curr_Plan_Date();
            receiptDateVsOrigConfDate = new Receipt_Date_vs_Orig_Conf_Date();
            receiptDateVsCurrConfDate = new Receipt_Date_vs_Curr_Conf_Date();
        }





        public string Name { get { return "Follow Up"; } }


        public enum CategorNames
        {
            initConfVsCurrConf,
            finalConfDateVsFinalPlan,
            receiptDateVsCurrPlanDate,
            receiptDateVsOrigConfDate,
            receiptDateVsCurrConfDate
        }

        public string[] categoryNames =
        {
            "Initial Confirmation Date vs Current Confirmation Date",
            "Final Confirmation Date vs Final Plan Date",
            "Receipt Date vs Current Plan Date",
            "Receipt Date vs Original Confirmation Date",
            "Receipt Date vs Current Confirmation Date"
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
                // Initial Confirmation vs Current Confirmation
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

                    string[] strFirstConfDate = (dr["1st Conf Date"].ToString()).Split('/');
                    int firstConfYear = int.Parse(strFirstConfDate[2]);
                    int firstConfMonth = int.Parse(strFirstConfDate[0]);
                    int firstConfDay = int.Parse(strFirstConfDate[1]);


                    if(firstConfYear == 0 && firstConfMonth == 0 && firstConfDay == 0)
                    {
                        initConfVsCurrConf.data.PercentUnconfTotal++;
                        continue;
                    }
                    else
                    {
                        firstConfYear = int.Parse(strFirstConfDate[2]);
                        firstConfMonth = int.Parse(strFirstConfDate[0].TrimStart('0'));
                        firstConfDay = int.Parse(strFirstConfDate[1].TrimStart('0'));
                    }

                    DateTime firstConfDate = new DateTime(firstConfYear, firstConfMonth, firstConfDay);

                    string[] strDelConfDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                    int delConfYear = int.Parse(strDelConfDate[2]);
                    int delConfMonth = int.Parse(strDelConfDate[0].TrimStart('0'));
                    int delConfDay = int.Parse(strDelConfDate[1].TrimStart('0'));

                    DateTime delConfDate = new DateTime(delConfYear, delConfMonth, delConfDay);
                    double elapsedDays = (delConfDate - firstConfDate).TotalDays;
                    totalDays += elapsedDays;

                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);
                    
                    if(elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);

                    initConfVsCurrConf.data.Total++;

                    if (elapsedDays <= (-22))
                    {
                        initConfVsCurrConf.data.Minus_TwentyTwo++;
                    }
                    else if (elapsedDays > (-22) && elapsedDays <= (-15))
                    {
                        initConfVsCurrConf.data.Minus_Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays > (-15) && elapsedDays <= (-8))
                    {
                        initConfVsCurrConf.data.Minus_Eight_Fourteen++;
                    }
                    else if (elapsedDays > (-8) && elapsedDays <= (-1))
                    {
                        initConfVsCurrConf.data.Minus_One_Seven++;
                    }
                    else if (elapsedDays == 0)
                    {
                        initConfVsCurrConf.data.Zero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 7)
                    {
                        initConfVsCurrConf.data.One_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        initConfVsCurrConf.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        initConfVsCurrConf.data.Fifteen_TwentyOne++;
                    }
                    else // 22 Days or greater
                    {
                        initConfVsCurrConf.data.TwentyTwo++;
                    }
                }


                try
                {
                    initConfVsCurrConf.data.PercentUnconf = Math.Round(((double)initConfVsCurrConf.data.PercentUnconfTotal / (initConfVsCurrConf.data.Total + initConfVsCurrConf.data.PercentUnconfTotal)) * 100, 2);
                    if (double.IsNaN(initConfVsCurrConf.data.PercentUnconf))
                        initConfVsCurrConf.data.PercentUnconf = 0;

                    if (double.IsInfinity(initConfVsCurrConf.data.PercentUnconf))
                        initConfVsCurrConf.data.PercentUnconf = 100;
                }
                catch (DivideByZeroException)
                {
                    initConfVsCurrConf.data.PercentUnconf = 0;
                }



                
                try
                {
                    initConfVsCurrConf.data.Average = Math.Round(totalDays / initConfVsCurrConf.data.Total, 2);
                    if (double.IsNaN(initConfVsCurrConf.data.Average))
                        initConfVsCurrConf.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    initConfVsCurrConf.data.Average = 0;
                }
                
                totalDays = 0;


                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Final Confirmation Date vs Final Planned Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                foreach (DataRow dr in PRPO_DB_Utils.posRecCompDt.Rows)
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

                    string[] strDelConfDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                    int delConfYear = int.Parse(strDelConfDate[2]);
                    int delConfMonth = int.Parse(strDelConfDate[0]);
                    int delConfDay = int.Parse(strDelConfDate[1]);

                    if(delConfYear == 0 && delConfMonth == 0 && delConfDay == 0)
                    {
                        finalConfDateVsFinalPlan.data.PercentUnconfTotal++;
                        continue;
                    }
                    else
                    {
                        delConfYear = int.Parse(strDelConfDate[2]);
                        delConfMonth = int.Parse(strDelConfDate[0].TrimStart('0'));
                        delConfDay = int.Parse(strDelConfDate[1].TrimStart('0'));
                    }

                    DateTime delConfDate = new DateTime(delConfYear, delConfMonth, delConfDay);


                    string[] strDelDate = (dr["Delivery Date"].ToString()).Split('/');
                    int delYear = int.Parse(strDelDate[2]);
                    int delMonth = int.Parse(strDelDate[0].TrimStart('0'));
                    int delDay = int.Parse(strDelDate[1].TrimStart('0'));

                    DateTime delDate = new DateTime(delYear, delMonth, delDay);
                    double elapsedDays = (delConfDate - delDate).TotalDays;
                    totalDays += elapsedDays;

                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);

                    if (elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);


                    finalConfDateVsFinalPlan.data.Total++;


                    if (elapsedDays <= (-22))
                    {
                        finalConfDateVsFinalPlan.data.Minus_TwentyTwo++;
                    }
                    else if (elapsedDays > (-22) && elapsedDays <= (-15))
                    {
                        finalConfDateVsFinalPlan.data.Minus_Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays > (-15) && elapsedDays <= (-8))
                    {
                        finalConfDateVsFinalPlan.data.Minus_Eight_Fourteen++;
                    }
                    else if (elapsedDays > (-8) && elapsedDays <= (-1))
                    {
                        finalConfDateVsFinalPlan.data.Minus_One_Seven++;
                    }
                    else if (elapsedDays == 0)
                    {
                        finalConfDateVsFinalPlan.data.Zero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 7)
                    {
                        finalConfDateVsFinalPlan.data.One_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        finalConfDateVsFinalPlan.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        finalConfDateVsFinalPlan.data.Fifteen_TwentyOne++;
                    }
                    else // 22 Days or greater
                    {
                        finalConfDateVsFinalPlan.data.TwentyTwo++;
                    }
                }

                try
                {
                    finalConfDateVsFinalPlan.data.Average = Math.Round(totalDays / finalConfDateVsFinalPlan.data.Total, 2);
                    if (double.IsNaN(finalConfDateVsFinalPlan.data.Average))
                        finalConfDateVsFinalPlan.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    finalConfDateVsFinalPlan.data.Average = 0;
                }



                try
                {
                    finalConfDateVsFinalPlan.data.PercentUnconf = Math.Round(((double)finalConfDateVsFinalPlan.data.PercentUnconfTotal / (finalConfDateVsFinalPlan.data.Total + finalConfDateVsFinalPlan.data.PercentUnconfTotal)) * 100, 2);
                    if (double.IsNaN(finalConfDateVsFinalPlan.data.PercentUnconf))
                        finalConfDateVsFinalPlan.data.PercentUnconf = 0;

                    if (double.IsInfinity(finalConfDateVsFinalPlan.data.PercentUnconf))
                        finalConfDateVsFinalPlan.data.PercentUnconf = 100;
                }
                catch (DivideByZeroException)
                {
                    finalConfDateVsFinalPlan.data.PercentUnconf = 0;
                }

                totalDays = 0;


                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Receipt Date vs Current Planned Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in PRPO_DB_Utils.posRecCompDt.Rows)
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


                    string[] strLastPORecDate = (dr["Last PO Rec#Date"].ToString()).Split('/');
                    int lastPORecDtYear = int.Parse(strLastPORecDate[2]);
                    int lastPORecDtMonth = int.Parse(strLastPORecDate[0]);
                    int lastPORecDtDay = int.Parse(strLastPORecDate[1]);

                    DateTime lastPORecDate = new DateTime(lastPORecDtYear, lastPORecDtMonth, lastPORecDtDay);

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
                     
                    double elapsedDays = (lastPORecDate - currPlanDate).TotalDays;
                    totalDays += elapsedDays;

                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);

                    if (elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);


                    receiptDateVsCurrPlanDate.data.Total++;


                    if (elapsedDays <= (-22))
                    {
                        receiptDateVsCurrPlanDate.data.Minus_TwentyTwo++;
                    }
                    else if (elapsedDays > (-22) && elapsedDays <= (-15))
                    {
                        receiptDateVsCurrPlanDate.data.Minus_Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays > (-15) && elapsedDays <= (-8))
                    {
                        receiptDateVsCurrPlanDate.data.Minus_Eight_Fourteen++;
                    }
                    else if (elapsedDays > (-8) && elapsedDays <= (-1))
                    {
                        receiptDateVsCurrPlanDate.data.Minus_One_Seven++;
                    }
                    else if (elapsedDays == 0)
                    {
                        receiptDateVsCurrPlanDate.data.Zero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 7)
                    {
                        receiptDateVsCurrPlanDate.data.One_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        receiptDateVsCurrPlanDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        receiptDateVsCurrPlanDate.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22)
                    {
                        receiptDateVsCurrPlanDate.data.TwentyTwo++;
                    }
                }


                try
                {
                    receiptDateVsCurrPlanDate.data.Average = Math.Round(totalDays / receiptDateVsCurrPlanDate.data.Total, 2);
                    if (double.IsNaN(receiptDateVsCurrPlanDate.data.Average))
                        receiptDateVsCurrPlanDate.data.Average = 0;
                }
                catch(DivideByZeroException)
                {
                    receiptDateVsCurrPlanDate.data.Average = 0;
                }


                totalDays = 0;



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Receipt Date vs Original Confirmed Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                foreach (DataRow dr in PRPO_DB_Utils.posRecCompDt.Rows)
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

                    string[] strLastPORecDate = (dr["Last PO Rec#Date"].ToString()).Split('/');
                    int lastPORecDtYear = int.Parse(strLastPORecDate[2]);
                    int lastPORecDtMonth = int.Parse(strLastPORecDate[0]);
                    int lastPORecDtDay = int.Parse(strLastPORecDate[1]);

                    DateTime lastPORecDate = new DateTime(lastPORecDtYear, lastPORecDtMonth, lastPORecDtDay);

                    string[] strFirstConfDate = (dr["1st Conf Date"].ToString()).Split('/');
                    int firstConfYear = int.Parse(strFirstConfDate[2]);
                    int firstConfMonth = int.Parse(strFirstConfDate[0]);
                    int firstConfDay = int.Parse(strFirstConfDate[1]);

                    if (firstConfYear == 0 && firstConfMonth == 0 && firstConfDay == 0)
                    {
                        receiptDateVsOrigConfDate.data.PercentUnconfTotal++;
                        continue;
                    }
                    else
                    {
                        firstConfYear = int.Parse(strFirstConfDate[2]);
                        firstConfMonth = int.Parse(strFirstConfDate[0].TrimStart('0'));
                        firstConfDay = int.Parse(strFirstConfDate[1].TrimStart('0'));
                    }

                    DateTime firstConfDate = new DateTime(firstConfYear, firstConfMonth, firstConfDay);
                    double elapsedDays = (lastPORecDate - firstConfDate).TotalDays;
                    totalDays += elapsedDays;

                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);

                    if (elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);


                    receiptDateVsOrigConfDate.data.Total++;


                    if (elapsedDays <= (-22))
                    {
                        receiptDateVsOrigConfDate.data.Minus_TwentyTwo++;
                    }
                    else if (elapsedDays > (-22) && elapsedDays <= (-15))
                    {
                        receiptDateVsOrigConfDate.data.Minus_Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays > (-15) && elapsedDays <= (-8))
                    {
                        receiptDateVsOrigConfDate.data.Minus_Eight_Fourteen++;
                    }
                    else if (elapsedDays > (-8) && elapsedDays <= (-1))
                    {
                        receiptDateVsOrigConfDate.data.Minus_One_Seven++;
                    }
                    else if (elapsedDays == 0)
                    {
                        receiptDateVsOrigConfDate.data.Zero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 7)
                    {
                        receiptDateVsOrigConfDate.data.One_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        receiptDateVsOrigConfDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        receiptDateVsOrigConfDate.data.Fifteen_TwentyOne++;
                    }
                    else // 22 Days or greater
                    {
                        receiptDateVsOrigConfDate.data.TwentyTwo++;
                    }
                }


                try
                {
                    receiptDateVsOrigConfDate.data.Average = Math.Round(totalDays / receiptDateVsOrigConfDate.data.Total, 2);
                    if (double.IsNaN(receiptDateVsOrigConfDate.data.Average))
                        receiptDateVsOrigConfDate.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    receiptDateVsOrigConfDate.data.Average = 0;
                }



                try
                {
                    receiptDateVsOrigConfDate.data.PercentUnconf = Math.Round(((double)receiptDateVsOrigConfDate.data.PercentUnconfTotal / (receiptDateVsOrigConfDate.data.Total + receiptDateVsOrigConfDate.data.PercentUnconfTotal)) * 100, 2);
                    if (double.IsNaN(receiptDateVsOrigConfDate.data.PercentUnconf))
                        receiptDateVsOrigConfDate.data.PercentUnconf = 0;

                    if (double.IsInfinity(receiptDateVsOrigConfDate.data.PercentUnconf))
                        receiptDateVsOrigConfDate.data.PercentUnconf = 100;
                }
                catch (DivideByZeroException)
                {
                    receiptDateVsOrigConfDate.data.PercentUnconf = 0;
                }

                totalDays = 0;



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Receipt Date vs Current Confirmed Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in PRPO_DB_Utils.posRecCompDt.Rows)
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

                    string[] strLastPORecDate = (dr["Last PO Rec#Date"].ToString()).Split('/');
                    int lastPORecDtYear = int.Parse(strLastPORecDate[2]);
                    int lastPORecDtMonth = int.Parse(strLastPORecDate[0]);
                    int lastPORecDtDay = int.Parse(strLastPORecDate[1]);

                    DateTime lastPORecDate = new DateTime(lastPORecDtYear, lastPORecDtMonth, lastPORecDtDay);

                    string[] strCurrConfDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                    int currConfYear = int.Parse(strCurrConfDate[2]);
                    int currConfMonth = int.Parse(strCurrConfDate[0]);
                    int currConfDay = int.Parse(strCurrConfDate[1]);

                    if (currConfYear == 0 && currConfMonth == 0 && currConfDay == 0)
                    {
                        receiptDateVsCurrConfDate.data.PercentUnconfTotal++;
                        continue;
                    }
                    else
                    {
                        currConfYear = int.Parse(strCurrConfDate[2]);
                        currConfMonth = int.Parse(strCurrConfDate[0].TrimStart('0'));
                        currConfDay = int.Parse(strCurrConfDate[1].TrimStart('0'));
                    }

                    DateTime currConfDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                    double elapsedDays = (lastPORecDate - currConfDate).TotalDays;
                    totalDays += elapsedDays;

                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);

                    if (elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);



                    receiptDateVsCurrConfDate.data.Total++;



                    if (elapsedDays <= (-22))
                    {
                        receiptDateVsCurrConfDate.data.Minus_TwentyTwo++;
                    }
                    else if (elapsedDays > (-22) && elapsedDays <= (-15))
                    {
                        receiptDateVsCurrConfDate.data.Minus_Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays > (-15) && elapsedDays <= (-8))
                    {
                        receiptDateVsCurrConfDate.data.Minus_Eight_Fourteen++;
                    }
                    else if (elapsedDays > (-8) && elapsedDays <= (-1))
                    {
                        receiptDateVsCurrConfDate.data.Minus_One_Seven++;
                    }
                    else if (elapsedDays == 0)
                    {
                        receiptDateVsCurrConfDate.data.Zero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 7)
                    {
                        receiptDateVsCurrConfDate.data.One_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        receiptDateVsCurrConfDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        receiptDateVsCurrConfDate.data.Fifteen_TwentyOne++;
                    }
                    else // 22 Days or greater
                    {
                        receiptDateVsCurrConfDate.data.TwentyTwo++;
                    }
                }



                try
                {
                    receiptDateVsCurrConfDate.data.Average = Math.Round(totalDays / receiptDateVsCurrConfDate.data.Total, 2);
                    if (double.IsNaN(receiptDateVsCurrConfDate.data.Average))
                        receiptDateVsCurrConfDate.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    receiptDateVsCurrConfDate.data.Average = 0;
                }



                try
                {
                    receiptDateVsCurrConfDate.data.PercentUnconf = Math.Round(((double)receiptDateVsCurrConfDate.data.PercentUnconfTotal / (receiptDateVsCurrConfDate.data.Total + receiptDateVsCurrConfDate.data.PercentUnconfTotal)) * 100, 2);
                    if (double.IsNaN(receiptDateVsCurrConfDate.data.PercentUnconf))
                        receiptDateVsCurrConfDate.data.PercentUnconf = 0;

                    if (double.IsInfinity(receiptDateVsCurrConfDate.data.PercentUnconf))
                        receiptDateVsCurrConfDate.data.PercentUnconf = 100;
                }
                catch (DivideByZeroException)
                {
                    receiptDateVsCurrConfDate.data.PercentUnconf = 0;
                }



                PRPO_DB_Utils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Follow Up Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    public class Init_Conf_vs_Curr_Conf
    {
        public TempThree data;

        public Init_Conf_vs_Curr_Conf()
        {
            data = new TempThree();
        }
    }






    public class Final_Conf_Date_vs_Final_Plan
    {
        public TempThree data;

        public Final_Conf_Date_vs_Final_Plan()
        {
            data = new TempThree();
        }
    }






    public class Receipt_Date_vs_Curr_Plan_Date
    {
        public TempThree data;

        public Receipt_Date_vs_Curr_Plan_Date()
        {
            data = new TempThree();
        }
    }






    public class Receipt_Date_vs_Orig_Conf_Date
    {
        public TempThree data;

        public Receipt_Date_vs_Orig_Conf_Date()
        {
            data = new TempThree();
        }
    }






    public class Receipt_Date_vs_Curr_Conf_Date
    {
        public TempThree data;

        public Receipt_Date_vs_Curr_Conf_Date()
        {
            data = new TempThree();
        }
    }
}
