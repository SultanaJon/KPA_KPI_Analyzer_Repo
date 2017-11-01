using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.FilterFeeature;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.DataLoading.KPI_Data.DataTableLoader
{
    public static class KpiDataTableLoader
    {
        private static DataTable dt;
        private static OleDbCommand cmd;
        private static OleDbDataAdapter da;
        private static DataTable unconfirmed;


        internal static class Plan
        {
            private static DataTable prPlanDateVsCurrPlanDt;
            private static DataTable OrigPlan2ndLvlRel_CodedLeadTime;
            private static DataTable CurrPlan2ndLvlRel_CodedLeadTime;


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadPrPlanDateVsCurrentPlanDateDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    prPlanDateVsCurrPlanDt = new DataTable();
                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.AllPOs) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    prPlanDateVsCurrPlanDt = dt.Clone();


                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
                        }

                        string[] strPrPlanDate = (dr["PR Delivery Date"].ToString()).Split('/');
                        int delConfYear = int.Parse(strPrPlanDate[2]);
                        int delConfMonth = int.Parse(strPrPlanDate[0].TrimStart('0'));
                        int delConfDay = int.Parse(strPrPlanDate[1].TrimStart('0'));

                        DateTime prPlanDate = new DateTime(delConfYear, delConfMonth, delConfDay);

                        string[] strCurrPlanDate = (dr["Rescheduling date"].ToString()).Split('/');
                        int currPlanYear = int.Parse(strCurrPlanDate[2]);
                        int currPlanMonth = int.Parse(strCurrPlanDate[0]);
                        int currPlanDay = int.Parse(strCurrPlanDate[1]);

                        if (currPlanYear == 0 && currPlanMonth == 0 && currPlanDay == 0)
                        {
                            string[] strNewCurrConfDate = (dr["Delivery Date"].ToString()).Split('/');
                            currPlanYear = int.Parse(strNewCurrConfDate[2]);
                            currPlanMonth = int.Parse(strNewCurrConfDate[0].TrimStart('0'));
                            currPlanDay = int.Parse(strNewCurrConfDate[1].TrimStart('0'));
                        }
                        else
                        {
                            currPlanYear = int.Parse(strCurrPlanDate[2]);
                            currPlanMonth = int.Parse(strCurrPlanDate[0].TrimStart('0'));
                            currPlanDay = int.Parse(strCurrPlanDate[1].TrimStart('0'));
                        }

                        DateTime reqDate = new DateTime(currPlanYear, currPlanMonth, currPlanDay);
                        double elapsedDays = (reqDate - prPlanDate).TotalDays;

                        if (elapsedDays < 0)
                            elapsedDays = Math.Floor(elapsedDays);

                        if (elapsedDays > 0)
                            elapsedDays = Math.Ceiling(elapsedDays);

                        elapsedDays = (int)elapsedDays;

                        switch (tag)
                        {
                            case 0:
                                prPlanDateVsCurrPlanDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= (-22))
                                {
                                    prPlanDateVsCurrPlanDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays > (-22) && elapsedDays <= (-15))
                                {
                                    prPlanDateVsCurrPlanDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays > (-15) && elapsedDays <= (-8))
                                {
                                    prPlanDateVsCurrPlanDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays > (-8) && elapsedDays <= (-1))
                                {
                                    prPlanDateVsCurrPlanDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays == 0)
                                {
                                    prPlanDateVsCurrPlanDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 1 && elapsedDays <= 7)
                                {
                                    prPlanDateVsCurrPlanDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    prPlanDateVsCurrPlanDt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    prPlanDateVsCurrPlanDt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 22)
                                {
                                    prPlanDateVsCurrPlanDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = prPlanDateVsCurrPlanDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    prPlanDateVsCurrPlanDt.Rows.Clear();
                    prPlanDateVsCurrPlanDt = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    OrigPlan2ndLvlRel_CodedLeadTime = new DataTable();

                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.PR_2ndLvlRel) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    OrigPlan2ndLvlRel_CodedLeadTime = dt.Clone();


                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }


                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
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

                        if (elapsedDays < 0)
                            elapsedDays = Math.Floor(elapsedDays);

                        if (elapsedDays > 0)
                            elapsedDays = Math.Ceiling(elapsedDays);

                        elapsedDays = (int)elapsedDays;

                        switch (tag)
                        {
                            case 0:
                                OrigPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= (-22))
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays > (-22) && elapsedDays <= (-15))
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays > (-15) && elapsedDays <= (-8))
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays > (-8) && elapsedDays <= (-1))
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays == 0)
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 1 && elapsedDays <= 7)
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 22)
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = OrigPlan2ndLvlRel_CodedLeadTime.Copy();
                    DataViewerUtils.DataLoaded = true;

                    OrigPlan2ndLvlRel_CodedLeadTime.Rows.Clear();
                    OrigPlan2ndLvlRel_CodedLeadTime = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }




            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    CurrPlan2ndLvlRel_CodedLeadTime = new DataTable();

                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.PR_2ndLvlRel) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    CurrPlan2ndLvlRel_CodedLeadTime = dt.Clone();


                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
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

                        if (elapsedDays < 0)
                            elapsedDays = Math.Floor(elapsedDays);

                        if (elapsedDays > 0)
                            elapsedDays = Math.Ceiling(elapsedDays);

                        elapsedDays = (int)elapsedDays;

                        switch (tag)
                        {
                            case 0:
                                CurrPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= (-22))
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays > (-22) && elapsedDays <= (-15))
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays > (-15) && elapsedDays <= (-8))
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays > (-8) && elapsedDays <= (-1))
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays == 0)
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 1 && elapsedDays <= 7)
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 22)
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTime.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = CurrPlan2ndLvlRel_CodedLeadTime.Copy();
                    DataViewerUtils.DataLoaded = true;

                    CurrPlan2ndLvlRel_CodedLeadTime.Rows.Clear();
                    CurrPlan2ndLvlRel_CodedLeadTime = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        internal static class Purch
        {
            private static DataTable initConfVsPrPlanDateDt;


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadInitialConfVsPrPlanDateDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    initConfVsPrPlanDateDt = new DataTable();
                    unconfirmed = new DataTable();
                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.AllPOs) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    initConfVsPrPlanDateDt = dt.Clone();
                    unconfirmed = dt.Clone();

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
                        }


                        string[] strFirstConfDate = (dr["1st Conf Date"].ToString()).Split('/');
                        int firstConfYear = int.Parse(strFirstConfDate[2]);
                        int firstConfMonth = int.Parse(strFirstConfDate[0]);
                        int firstConfDay = int.Parse(strFirstConfDate[1]);

                        if (firstConfYear == 0 && firstConfMonth == 0 && firstConfDay == 0)
                        {
                            unconfirmed.ImportRow(dr);
                            continue;
                        }
                        else
                        {
                            firstConfYear = int.Parse(strFirstConfDate[2]);
                            firstConfMonth = int.Parse(strFirstConfDate[0].TrimStart('0'));
                            firstConfDay = int.Parse(strFirstConfDate[1].TrimStart('0'));
                        }

                        DateTime firstConfDate = new DateTime(firstConfYear, firstConfMonth, firstConfDay);

                        string[] strPRPlanDate = (dr["PR Delivery Date"].ToString()).Split('/');
                        int prDelYear = int.Parse(strPRPlanDate[2]);
                        int prDelMonth = int.Parse(strPRPlanDate[0].TrimStart('0'));
                        int prDelDay = int.Parse(strPRPlanDate[1].TrimStart('0'));

                        DateTime prPlanDate = new DateTime(prDelYear, prDelMonth, prDelDay);
                        double elapsedDays = (int)(firstConfDate - prPlanDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                initConfVsPrPlanDateDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= (-22))
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays > (-22) && elapsedDays <= (-15))
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays > (-15) && elapsedDays <= (-8))
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays > (-8) && elapsedDays <= (-1))
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays == 0)
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 1 && elapsedDays <= 7)
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 22)
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    if (tag != 10)
                    {
                        DataViewerUtils.Data = initConfVsPrPlanDateDt.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }
                    else
                    {
                        DataViewerUtils.Data = unconfirmed.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }



                    if (initConfVsPrPlanDateDt != null)
                    {
                        initConfVsPrPlanDateDt.Rows.Clear();
                        initConfVsPrPlanDateDt = null;
                    }

                    if (unconfirmed != null)
                    {
                        unconfirmed.Rows.Clear();
                        unconfirmed = null;
                    }


                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }                
            }
        }


        internal static class FollowUp
        {
            private static DataTable initConfVsCurrConf;
            private static DataTable finalConfDateVsFinalPlanDateDt;
            private static DataTable recDateVsCurrPlanDateDt;
            private static DataTable recDateVsOrigConfDateDt;
            private static DataTable recDateVsCurrConfDateDt;


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadInitConfVsCurrConfDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    initConfVsCurrConf = new DataTable();
                    unconfirmed = new DataTable();

                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.POLinesRecComplete) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);



                    initConfVsCurrConf = dt.Clone();
                    unconfirmed = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
                        }

                        string[] strFirstConfDate = (dr["1st Conf Date"].ToString()).Split('/');
                        int firstConfYear = int.Parse(strFirstConfDate[2]);
                        int firstConfMonth = int.Parse(strFirstConfDate[0]);
                        int firstConfDay = int.Parse(strFirstConfDate[1]);


                        if (firstConfYear == 0 && firstConfMonth == 0 && firstConfDay == 0)
                        {
                            unconfirmed.ImportRow(dr);
                            continue;
                        }
                        else
                        {
                            firstConfYear = int.Parse(strFirstConfDate[2]);
                            firstConfMonth = int.Parse(strFirstConfDate[0].TrimStart('0'));
                            firstConfDay = int.Parse(strFirstConfDate[1].TrimStart('0'));
                        }

                        DateTime firstConfDate = new DateTime(firstConfYear, firstConfMonth, firstConfDay);

                        string[] strDdelConfDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                        int delConfYear = int.Parse(strDdelConfDate[2]);
                        int delConfMonth = int.Parse(strDdelConfDate[0].TrimStart('0'));
                        int delConfDay = int.Parse(strDdelConfDate[1].TrimStart('0'));

                        DateTime delConfDate = new DateTime(delConfYear, delConfMonth, delConfDay);
                        double elapsedDays = (delConfDate - firstConfDate).TotalDays;

                        if (elapsedDays < 0)
                            elapsedDays = Math.Floor(elapsedDays);

                        if (elapsedDays > 0)
                            elapsedDays = Math.Ceiling(elapsedDays);

                        switch (tag)
                        {
                            case 0:
                                initConfVsCurrConf.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= (-22))
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays > (-22) && elapsedDays <= (-15))
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays > (-15) && elapsedDays <= (-8))
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays > (-8) && elapsedDays <= (-1))
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays == 0)
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 1 && elapsedDays <= 7)
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 22)
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    if (tag != 10)
                    {
                        DataViewerUtils.Data = initConfVsCurrConf.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }
                    else
                    {
                        DataViewerUtils.Data = unconfirmed.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }


                    if(initConfVsCurrConf != null)
                    {
                        initConfVsCurrConf.Rows.Clear();
                        initConfVsCurrConf = null;
                    }

                    if(unconfirmed != null)
                    {
                        unconfirmed.Rows.Clear();
                        unconfirmed = null;
                    }


                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadFinalConfDateVsFinalPlanDateDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    finalConfDateVsFinalPlanDateDt = new DataTable();
                    unconfirmed = new DataTable();

                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.POLinesRecComplete) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    finalConfDateVsFinalPlanDateDt = dt.Clone();
                    unconfirmed = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
                        }

                        string[] strDelConfDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                        int delConfYear = int.Parse(strDelConfDate[2]);
                        int delConfMonth = int.Parse(strDelConfDate[0]);
                        int delConfDay = int.Parse(strDelConfDate[1]);

                        if (delConfYear == 0 && delConfMonth == 0 && delConfDay == 0)
                        {
                            unconfirmed.ImportRow(dr);
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

                        if (elapsedDays < 0)
                            elapsedDays = Math.Floor(elapsedDays);

                        if (elapsedDays > 0)
                            elapsedDays = Math.Ceiling(elapsedDays);

                        switch (tag)
                        {
                            case 0:
                                finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= (-22))
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays > (-22) && elapsedDays <= (-15))
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays > (-15) && elapsedDays <= (-8))
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays > (-8) && elapsedDays <= (-1))
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays == 0)
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 1 && elapsedDays <= 7)
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 22)
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    if (tag != 10)
                    {
                        DataViewerUtils.Data = finalConfDateVsFinalPlanDateDt.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }
                    else
                    {
                        DataViewerUtils.Data = unconfirmed.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }


                    if (finalConfDateVsFinalPlanDateDt != null)
                    {
                        finalConfDateVsFinalPlanDateDt.Rows.Clear();
                        finalConfDateVsFinalPlanDateDt = null;
                    }

                    if (unconfirmed != null)
                    {
                        unconfirmed.Rows.Clear();
                        unconfirmed = null;
                    }


                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadRecDateVsCurrPlanDateDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    recDateVsCurrPlanDateDt = new DataTable();

                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.POLinesRecComplete) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    recDateVsCurrPlanDateDt = dt.Clone();

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
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

                        if (elapsedDays < 0)
                            elapsedDays = Math.Floor(elapsedDays);

                        if (elapsedDays > 0)
                            elapsedDays = Math.Ceiling(elapsedDays);

                        switch (tag)
                        {
                            case 0:
                                recDateVsCurrPlanDateDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= (-22))
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays > (-22) && elapsedDays <= (-15))
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays > (-15) && elapsedDays <= (-8))
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays > (-8) && elapsedDays <= (-1))
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays == 0)
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 1 && elapsedDays <= 7)
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 22)
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    DataViewerUtils.Data = recDateVsCurrPlanDateDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    recDateVsCurrPlanDateDt.Rows.Clear();
                    recDateVsCurrPlanDateDt = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>s
            internal static void LoadRecDateVsOrigConfDateDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    recDateVsOrigConfDateDt = new DataTable();
                    unconfirmed = new DataTable();

                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.POLinesRecComplete) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    recDateVsOrigConfDateDt = dt.Clone();
                    unconfirmed = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
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
                            unconfirmed.ImportRow(dr);
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

                        if (elapsedDays < 0)
                            elapsedDays = Math.Floor(elapsedDays);

                        if (elapsedDays > 0)
                            elapsedDays = Math.Ceiling(elapsedDays);

                        switch (tag)
                        {
                            case 0:
                                recDateVsOrigConfDateDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= (-22))
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays > (-22) && elapsedDays <= (-15))
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays > (-15) && elapsedDays <= (-8))
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays > (-8) && elapsedDays <= (-1))
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays == 0)
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 1 && elapsedDays <= 7)
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 22)
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    if (tag != 10)
                    {
                        DataViewerUtils.Data = recDateVsOrigConfDateDt.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }
                    else
                    {
                        DataViewerUtils.Data = unconfirmed.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }


                    if (recDateVsOrigConfDateDt != null)
                    {
                        recDateVsOrigConfDateDt.Rows.Clear();
                        recDateVsOrigConfDateDt = null;
                    }

                    if (unconfirmed != null)
                    {
                        unconfirmed.Rows.Clear();
                        unconfirmed = null;
                    }

                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadRecDateVsCurrConfDateDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    recDateVsCurrConfDateDt = new DataTable();
                    unconfirmed = new DataTable();
                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.POLinesRecComplete) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    recDateVsCurrConfDateDt = dt.Clone();
                    unconfirmed = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
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
                            unconfirmed.ImportRow(dr);
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

                        if (elapsedDays < 0)
                            elapsedDays = Math.Floor(elapsedDays);

                        if (elapsedDays > 0)
                            elapsedDays = Math.Ceiling(elapsedDays);

                        switch (tag)
                        {
                            case 0:
                                recDateVsCurrConfDateDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= (-22))
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays > (-22) && elapsedDays <= (-15))
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays > (-15) && elapsedDays <= (-8))
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays > (-8) && elapsedDays <= (-1))
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays == 0)
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 1 && elapsedDays <= 7)
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 22)
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    if (tag != 10)
                    {
                        DataViewerUtils.Data = recDateVsCurrConfDateDt.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }
                    else
                    {
                        DataViewerUtils.Data = unconfirmed.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }


                    if (recDateVsCurrConfDateDt != null)
                    {
                        recDateVsCurrConfDateDt.Rows.Clear();
                        recDateVsCurrConfDateDt = null;
                    }

                    if (unconfirmed != null)
                    {
                        unconfirmed.Rows.Clear();
                        unconfirmed = null;
                    }

                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        internal static class PlanTwo
        {

        }



        internal static class PurchTwo
        {
            private static DataTable pr2ndLvlRelVsPoCreate;
            private static DataTable poCreateVsPORel;
            private static DataTable poRelVsPoConf;

            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadPr2ndLvlRelVsPOCreationDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    pr2ndLvlRelVsPoCreate = new DataTable();
                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.AllPOs) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    pr2ndLvlRelVsPoCreate = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }


                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
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
                        double elapsedDays = (int)(poLineCreateDate - pr2ndLvlRelDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = pr2ndLvlRelVsPoCreate.Copy();
                    DataViewerUtils.DataLoaded = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    pr2ndLvlRelVsPoCreate.Rows.Clear();
                    pr2ndLvlRelVsPoCreate = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }


            }



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadPoCreationVsPoReleaseDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    poCreateVsPORel = new DataTable();
                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.AllPOs) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    poCreateVsPORel = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
                        }

                        string[] strPOLine1stRelDt = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                        int poLine1stRelDtYear = int.Parse(strPOLine1stRelDt[2]);
                        int poLine1stRelDtMonth = int.Parse(strPOLine1stRelDt[0]);
                        int poLine1stRelDtDay = int.Parse(strPOLine1stRelDt[1]);

                        if (poLine1stRelDtYear == 0 && poLine1stRelDtMonth == 0 && poLine1stRelDtDay == 0)
                        {
                            continue;
                        }
                        else
                        {
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
                        double elapsedDays = (int)(poLine1stRelDate - poCreateDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                poCreateVsPORel.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = poCreateVsPORel.Copy();
                    DataViewerUtils.DataLoaded = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    poCreateVsPORel.Rows.Clear();
                    poCreateVsPORel = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }


            }




            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadPoReleaseVsPoConfDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    poRelVsPoConf = new DataTable();
                    unconfirmed = new DataTable();
                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.AllPOs) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    poRelVsPoConf = dt.Clone();
                    unconfirmed = dt.Clone();

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
                        }

                        string[] strPOLineFirstRelDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                        int poLineFirstRelDateYear = int.Parse(strPOLineFirstRelDate[2]);
                        int poLineFirstRelDateMonth = int.Parse(strPOLineFirstRelDate[0]);
                        int poLineFirstRelDateDay = int.Parse(strPOLineFirstRelDate[1]);

                        if (poLineFirstRelDateYear == 0 && poLineFirstRelDateMonth == 0 && poLineFirstRelDateDay == 0)
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


                        if (poLineFirstConfCreateYear == 0 && poLineFirstConfCreateMonth == 0 && poLineFirstConfCreateDay == 0)
                        {
                            unconfirmed.ImportRow(dr);
                            continue;
                        }
                        else
                        {
                            poLineFirstConfCreateYear = int.Parse(strPOLineFirstConfCreateDate[2]);
                            poLineFirstConfCreateMonth = int.Parse(strPOLineFirstConfCreateDate[0].TrimStart('0'));
                            poLineFirstConfCreateDay = int.Parse(strPOLineFirstConfCreateDate[1].TrimStart('0'));
                        }

                        DateTime poLineFirstConfCreateDt = new DateTime(poLineFirstConfCreateYear, poLineFirstConfCreateMonth, poLineFirstConfCreateDay);

                        double elapsedDays = (int)(poLineFirstConfCreateDt - poLineFirstRelDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                poRelVsPoConf.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    if (tag != 12)
                    {
                        DataViewerUtils.Data = poRelVsPoConf.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }
                    else
                    {
                        DataViewerUtils.Data = unconfirmed.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }


                    if (poRelVsPoConf != null)
                    {
                        poRelVsPoConf.Rows.Clear();
                        poRelVsPoConf = null;
                    }

                    if (unconfirmed != null)
                    {
                        unconfirmed.Rows.Clear();
                        unconfirmed = null;
                    }

                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        internal static class PurchSub
        {
            private static DataTable prRelVsPORel;
            private static DataTable poCreateVsConfEntry;


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadPrRelVsPoRelDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    prRelVsPORel = new DataTable();

                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.AllPOs) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    prRelVsPORel = dt.Clone();


                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
                        }


                        string[] strPOLineFirstRelDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                        int poLineFirstRelYear = int.Parse(strPOLineFirstRelDate[2]);
                        int poLineFirstRelMonth = int.Parse(strPOLineFirstRelDate[0]);
                        int poLineFirstRelDay = int.Parse(strPOLineFirstRelDate[1]);

                        if (poLineFirstRelYear == 0 && poLineFirstRelMonth == 0 && poLineFirstRelDay == 0)
                        {
                            continue;
                        }
                        else
                        {
                            poLineFirstRelYear = int.Parse(strPOLineFirstRelDate[2]);
                            poLineFirstRelMonth = int.Parse(strPOLineFirstRelDate[0].TrimStart('0'));
                            poLineFirstRelDay = int.Parse(strPOLineFirstRelDate[1].TrimStart('0'));
                        }

                        DateTime poLineFirstRelDate = new DateTime(poLineFirstRelYear, poLineFirstRelMonth, poLineFirstRelDay);

                        string[] strPR2ndLvlRelDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                        int secLvlRelYear = int.Parse(strPR2ndLvlRelDate[2]);
                        int secLvlRelMonth = int.Parse(strPR2ndLvlRelDate[0].TrimStart('0'));
                        int secLvlRelDay = int.Parse(strPR2ndLvlRelDate[1].TrimStart('0'));

                        DateTime pr2ndLvlRelDate = new DateTime(secLvlRelYear, secLvlRelMonth, secLvlRelDay);
                        double elapsedDays = (int)(poLineFirstRelDate - pr2ndLvlRelDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                prRelVsPORel.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = prRelVsPORel.Copy();
                    DataViewerUtils.DataLoaded = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    prRelVsPORel.Rows.Clear();
                    prRelVsPORel = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }


            }



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadPoCreationVsConfEntryDateDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    poCreateVsConfEntry = new DataTable();
                    unconfirmed = new DataTable();

                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.AllPOs) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    poCreateVsConfEntry = dt.Clone();
                    unconfirmed = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
                        }

                        string[] strFirstConCreatefDate = (dr["1st Conf Creation Da"].ToString()).Split('/');
                        int poLineFirstConCreatefYear = int.Parse(strFirstConCreatefDate[2]);
                        int poLineFirstConfCreateMonth = int.Parse(strFirstConCreatefDate[0]);
                        int poLineFirstConfCreateDay = int.Parse(strFirstConCreatefDate[1]);

                        if (poLineFirstConCreatefYear == 0 && poLineFirstConfCreateMonth == 0 && poLineFirstConfCreateDay == 0)
                        {
                            unconfirmed.ImportRow(dr);
                            continue;
                        }
                        else
                        {
                            poLineFirstConCreatefYear = int.Parse(strFirstConCreatefDate[2]);
                            poLineFirstConfCreateMonth = int.Parse(strFirstConCreatefDate[0]);
                            poLineFirstConfCreateDay = int.Parse(strFirstConCreatefDate[1]);
                        }


                        DateTime initialConfCreateDate = new DateTime(poLineFirstConCreatefYear, poLineFirstConfCreateMonth, poLineFirstConfCreateDay);

                        string[] strPOLineCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                        int poLineCreateYear = int.Parse(strPOLineCreateDt[2]);
                        int poLineCreateMonth = int.Parse(strPOLineCreateDt[0].TrimStart('0'));
                        int poLineCreateDay = int.Parse(strPOLineCreateDt[1].TrimStart('0'));

                        DateTime poLineItemCreateDate = new DateTime(poLineCreateYear, poLineCreateMonth, poLineCreateDay);

                        double elapsedDays = (int)(initialConfCreateDate - poLineItemCreateDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                poCreateVsConfEntry.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    if (tag != 12)
                    {
                        DataViewerUtils.Data = poCreateVsConfEntry.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }
                    else
                    {
                        DataViewerUtils.Data = unconfirmed.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }


                    if (poCreateVsConfEntry != null)
                    {
                        poCreateVsConfEntry.Rows.Clear();
                        poCreateVsConfEntry = null;
                    }

                    if (unconfirmed != null)
                    {
                        unconfirmed.Rows.Clear();
                        unconfirmed = null;
                    }

                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        internal static class PurchTotal
        {
            private static DataTable prReleaseConfEntry;

            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadPrReleaseConfEntryDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    prReleaseConfEntry = new DataTable();
                    unconfirmed = new DataTable();
                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.AllPOs) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    prReleaseConfEntry = dt.Clone();
                    unconfirmed = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
                        }


                        string[] strfirstConfCreateDt = (dr["1st Conf Creation Da"].ToString()).Split('/');
                        int firstConfCreateYear = int.Parse(strfirstConfCreateDt[2]);
                        int firstConfCreateMonth = int.Parse(strfirstConfCreateDt[0]);
                        int firstConfCreateDay = int.Parse(strfirstConfCreateDt[1]);

                        if (firstConfCreateYear == 0 && firstConfCreateMonth == 0 & firstConfCreateDay == 0)
                        {
                            unconfirmed.ImportRow(dr);
                            continue;
                        }
                        else
                        {
                            firstConfCreateYear = int.Parse(strfirstConfCreateDt[2]);
                            firstConfCreateMonth = int.Parse(strfirstConfCreateDt[0].TrimStart('0'));
                            firstConfCreateDay = int.Parse(strfirstConfCreateDt[1].TrimStart('0'));
                        }

                        DateTime poLineConfCreateDate = new DateTime(firstConfCreateYear, firstConfCreateMonth, firstConfCreateDay);

                        string[] strPR2ndLvlRelDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                        int secLvlRelYear = int.Parse(strPR2ndLvlRelDate[2]);
                        int secLvlRelMonth = int.Parse(strPR2ndLvlRelDate[0].TrimStart('0'));
                        int secLvlRelDay = int.Parse(strPR2ndLvlRelDate[1].TrimStart('0'));

                        DateTime pr2ndLvlRelDate = new DateTime(secLvlRelYear, secLvlRelMonth, secLvlRelDay);
                        double elapsedDays = (int)(poLineConfCreateDate - pr2ndLvlRelDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                prReleaseConfEntry.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    if (tag != 12)
                    {
                        DataViewerUtils.Data = prReleaseConfEntry.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }
                    else
                    {
                        DataViewerUtils.Data = unconfirmed.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }



                    if (prReleaseConfEntry != null)
                    {
                        prReleaseConfEntry.Rows.Clear();
                        prReleaseConfEntry = null;
                    }

                    if (unconfirmed != null)
                    {
                        unconfirmed.Rows.Clear();
                        unconfirmed = null;
                    }


                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        internal static class PurchPlan
        {
            private static DataTable poRelVsPRDelDateDt;
            private static DataTable pr2ndLvlRelOrigPlanDelDateDt;
            private static string[] strPoLineFirstRelDate;

            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadPoRelVsPrDelDateDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    poRelVsPRDelDateDt = new DataTable();

                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.AllPOs) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    poRelVsPRDelDateDt = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }


                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
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
                        double elapsedDays = (int)(prDelDate - poLineFirstRelDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                poRelVsPRDelDateDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = poRelVsPRDelDateDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    poRelVsPRDelDateDt.Rows.Clear();
                    poRelVsPRDelDateDt = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadPr2ndLvlRelOrigPlanDateDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    pr2ndLvlRelOrigPlanDelDateDt = new DataTable();
                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.PR_2ndLvlRel) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    pr2ndLvlRelOrigPlanDelDateDt = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
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
                        double elapsedDays = (int)(prDelDate - pr2ndLvlRelDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = pr2ndLvlRelOrigPlanDelDateDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    pr2ndLvlRelOrigPlanDelDateDt.Rows.Clear();
                    pr2ndLvlRelOrigPlanDelDateDt = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        internal static class PurchPlanTotal
        {

        }


        internal static class Other
        {
            private static DataTable prsCreated;
            private static DataTable prReleased;
            private static DataTable totalSpend;
            private static DataTable prVsPOValue;
            private static DataTable hotJobPRs;


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadPrsCreated(int tag)
            {
                try
                {
                    dt = new DataTable();
                    prsCreated = new DataTable();
                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.AllData) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);


                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    prsCreated = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
                        }

                        string[] strReqDate = (dr["Requisn Date"].ToString()).Split('/');
                        int reqDateYear = int.Parse(strReqDate[2]);
                        int reqDateMonth = int.Parse(strReqDate[0].TrimStart('0'));
                        int reqDateDay = int.Parse(strReqDate[1].TrimStart('0'));

                        DateTime prReqDate = new DateTime(reqDateYear, reqDateMonth, reqDateDay);

                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (prReqDate - today).TotalDays;
                        double weeks = Math.Floor(elapsedDays / 7);

                        switch (tag)
                        {
                            case 0:
                                prsCreated.ImportRow(dr);
                                break;
                            case 1:
                                if (weeks >= 0)
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (weeks >= (-1) && weeks < 0)
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (weeks >= (-2) && weeks < (-1))
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (weeks >= (-3) && weeks < (-2))
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (weeks >= (-4) && weeks < (-3))
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (weeks >= (-5) && weeks < (-4))
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (weeks >= (-6) && weeks < (-5))
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (weeks >= (-7) && weeks < (-6))
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (weeks >= (-8) && weeks < (-7))
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (weeks < (-8))
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = prsCreated.Copy();
                    DataViewerUtils.DataLoaded = true;

                    prsCreated.Rows.Clear();
                    prsCreated = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }




            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadPrsReleased(int tag)
            {
                try
                {
                    dt = new DataTable();
                    prReleased = new DataTable();

                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.PR_2ndLvlRel) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    prReleased = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
                        }

                        string[] strPr2ndLvlRelDt = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                        int pr2ndLvlRelDtYear = int.Parse(strPr2ndLvlRelDt[2]);
                        int pr2ndLvlRelDtMonth = int.Parse(strPr2ndLvlRelDt[0].TrimStart('0'));
                        int pr2ndLvlRelDtDay = int.Parse(strPr2ndLvlRelDt[1].TrimStart('0'));

                        DateTime pr2ndLvlRelDt = new DateTime(pr2ndLvlRelDtYear, pr2ndLvlRelDtMonth, pr2ndLvlRelDtDay);
                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (pr2ndLvlRelDt - today).TotalDays;
                        double weeks = Math.Floor(elapsedDays / 7);

                        switch (tag)
                        {
                            case 0:
                                prReleased.ImportRow(dr);
                                break;
                            case 1:
                                if (weeks >= 0)
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (weeks >= (-1) && weeks < 0)
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (weeks >= (-2) && weeks < (-1))
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (weeks >= (-3) && weeks < (-2))
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (weeks >= (-4) && weeks < (-3))
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (weeks >= (-5) && weeks < (-4))
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (weeks >= (-6) && weeks < (-5))
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (weeks >= (-7) && weeks < (-6))
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (weeks >= (-8) && weeks < (-7))
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (weeks < (-8))
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = prReleased.Copy();
                    DataViewerUtils.DataLoaded = true;

                    prReleased.Rows.Clear();
                    prReleased = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }




            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadTotalSpend(int tag)
            {
                try
                {
                    dt = new DataTable();
                    totalSpend = new DataTable();
                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.AllPOs) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    totalSpend = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
                        }

                        string[] strPoCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                        int poCreateDtYear = int.Parse(strPoCreateDt[2]);
                        int poCreateDtMonth = int.Parse(strPoCreateDt[0].TrimStart('0'));
                        int poCreateDtDay = int.Parse(strPoCreateDt[1].TrimStart('0'));

                        DateTime poCreateDate = new DateTime(poCreateDtYear, poCreateDtMonth, poCreateDtDay);
                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (poCreateDate - today).TotalDays;
                        double weeks = Math.Floor(elapsedDays / 7);

                        switch (tag)
                        {
                            case 0:
                                totalSpend.ImportRow(dr);
                                break;
                            case 1:
                                if (weeks >= 0)
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (weeks >= (-1) && weeks < 0)
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (weeks >= (-2) && weeks < (-1))
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (weeks >= (-3) && weeks < (-2))
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (weeks >= (-4) && weeks < (-3))
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (weeks >= (-5) && weeks < (-4))
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (weeks >= (-6) && weeks < (-5))
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (weeks >= (-7) && weeks < (-6))
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (weeks >= (-8) && weeks < (-7))
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (weeks < (-8))
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = totalSpend.Copy();
                    DataViewerUtils.DataLoaded = true;

                    totalSpend.Rows.Clear();
                    totalSpend = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadPrVsPoValue(int tag)
            {
                try
                {
                    dt = new DataTable();
                    prVsPOValue = new DataTable();

                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.AllPOs) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    prVsPOValue = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }


                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
                        }

                        string[] strPoCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                        int poCreateDtYear = int.Parse(strPoCreateDt[2]);
                        int poCreateDtMonth = int.Parse(strPoCreateDt[0].TrimStart('0'));
                        int poCreateDtDay = int.Parse(strPoCreateDt[1].TrimStart('0'));

                        DateTime poCreateDate = new DateTime(poCreateDtYear, poCreateDtMonth, poCreateDtDay);

                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (poCreateDate - today).TotalDays;
                        double weeks = Math.Floor(elapsedDays / 7);

                        switch (tag)
                        {
                            case 0:
                                prVsPOValue.ImportRow(dr);
                                break;
                            case 1:
                                if (weeks >= 0)
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (weeks >= (-1) && weeks < 0)
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (weeks >= (-2) && weeks < (-1))
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (weeks >= (-3) && weeks < (-2))
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (weeks >= (-4) && weeks < (-3))
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (weeks >= (-5) && weeks < (-4))
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (weeks >= (-6) && weeks < (-5))
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (weeks >= (-7) && weeks < (-6))
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (weeks >= (-8) && weeks < (-7))
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (weeks < (-8))
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = prVsPOValue.Copy();
                    DataViewerUtils.DataLoaded = true;

                    prVsPOValue.Rows.Clear();
                    prVsPOValue = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            internal static void LoadHotJobPrs(int tag)
            {
                try
                {
                    dt = new DataTable();
                    hotJobPRs = new DataTable();
                    cmd = new OleDbCommand(PRPOCommands.GetQuery(PRPOCommands.DatabaseTables.TableNames.AllData) + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);


                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    hotJobPRs = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Filters.FilterByPrDateRange)
                        {
                            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                            {
                                // The PR Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByPoDateRange)
                        {
                            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                            {
                                // The PO Date was not in range of the filter the user applied.
                                continue;
                            }
                        }

                        if (Filters.FilterByFinalReceiptDate)
                        {
                            if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                            {
                                // The final receipt date was not in range of the filter the user applied
                                continue;
                            }
                        }

                        if (AdvancedFilters.AdvanceFiltersChanged())
                        {
                            // We have some advanced filters that the user would like to exclude.
                            if (!FilterUtils.CheckAdvancedFilters(dr))
                                continue;
                        }

                        if (dr["Purch# Group"].ToString() != "UHJ")
                            continue;

                        string[] strPrReqDt = (dr["Requisn Date"].ToString()).Split('/');
                        int reqDateYear = int.Parse(strPrReqDt[2]);
                        int reqDateMonth = int.Parse(strPrReqDt[0].TrimStart('0'));
                        int reqDateDay = int.Parse(strPrReqDt[1].TrimStart('0'));

                        DateTime reqDate = new DateTime(reqDateYear, reqDateMonth, reqDateDay);
                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (reqDate - today).TotalDays;
                        double weeks = Math.Floor(elapsedDays / 7);

                        switch (tag)
                        {
                            case 0:
                                hotJobPRs.ImportRow(dr);
                                break;
                            case 1:
                                if (weeks >= 0)
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (weeks >= (-1) && weeks < 0)
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (weeks >= (-2) && weeks < (-1))
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (weeks >= (-3) && weeks < (-2))
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (weeks >= (-4) && weeks < (-3))
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (weeks >= (-5) && weeks < (-4))
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (weeks >= (-6) && weeks < (-5))
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (weeks >= (-7) && weeks < (-6))
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (weeks >= (-8) && weeks < (-7))
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (weeks < (-8))
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = hotJobPRs.Copy();
                    DataViewerUtils.DataLoaded = true;

                    hotJobPRs.Rows.Clear();
                    hotJobPRs = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
