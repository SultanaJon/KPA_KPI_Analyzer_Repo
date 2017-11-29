using KPA_KPI_Analyzer.Database;
using KPA_KPI_Analyzer.FilterFeeature;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.DataLoading.KPA_Data.DataTableLoader
{
    public static class KpaDataTableLoader
    {
        private static DataTable dt;
        private static OleDbCommand cmd;
        private static OleDbDataAdapter da;

        public static class Plan
        {
            private static DataTable prsAgingNotRelDt;
            private static DataTable MaterialDueDt;

            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPRsAgingNotRelDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    prsAgingNotRelDt = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.PlanQueries.GetPrsAgingNotReleased() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    prsAgingNotRelDt = dt.Clone();



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



                        string[] reqCreationDate = (dr["Requisn Date"].ToString()).Split('/');
                        int year = int.Parse(reqCreationDate[2]);
                        int month = int.Parse(reqCreationDate[0].TrimStart('0'));
                        int day = int.Parse(reqCreationDate[1].TrimStart('0'));

                        DateTime reqDate = new DateTime(year, month, day);
                        double elapsedDays = (int)(DateTime.Now - reqDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                prsAgingNotRelDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = prsAgingNotRelDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    prsAgingNotRelDt.Rows.Clear();
                    prsAgingNotRelDt = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadMaterialDueDataTable(int tag)
            {
                try
                { 
                    dt = new DataTable();
                    MaterialDueDt = new DataTable();

                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.PlanQueries.GetMaterialDue() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    MaterialDueDt = dt.Clone();

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

                        string[] strCurrReqDate = (dr["PR Delivery Date"].ToString()).Split('/');
                        int year = int.Parse(strCurrReqDate[2]);
                        int month = int.Parse(strCurrReqDate[0].TrimStart('0'));
                        int day = int.Parse(strCurrReqDate[1].TrimStart('0'));

                        DateTime currReqDate = new DateTime(year, month, day);
                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (int)(currReqDate - today).TotalDays;


                        switch (tag)
                        {
                            case 0:
                                MaterialDueDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    MaterialDueDt.ImportRow(dr);
                                }
                                break;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    MaterialDueDt.ImportRow(dr);
                                }
                                break;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    MaterialDueDt.ImportRow(dr);
                                }
                                break;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    MaterialDueDt.ImportRow(dr);
                                }
                                break;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    MaterialDueDt.ImportRow(dr);
                                }
                                break;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    MaterialDueDt.ImportRow(dr);
                                }
                                break;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    MaterialDueDt.ImportRow(dr);
                                }
                                break;
                            default:
                                break;
                        }
                    }

                    DataViewerUtils.Data = MaterialDueDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    MaterialDueDt.Rows.Clear();
                    MaterialDueDt = null;
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

        public static class Purch
        {
            private static DataTable prsAgingRelDt;
            private static DataTable poFirstRelDt;
            private static DataTable poPrevRelDt;
            private static DataTable noConfirmationsDt;

            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPrsAgingReleasedDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    prsAgingRelDt = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.PurchQueries.GetPrsAgingReleased() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    prsAgingRelDt = dt.Clone();


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


                        string[] strDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                        int year = int.Parse(strDate[2]);
                        int month = int.Parse(strDate[0].TrimStart('0'));
                        int day = int.Parse(strDate[1].TrimStart('0'));

                        DateTime date = new DateTime(year, month, day);
                        double elapsedDays = (int)(DateTime.Now - date).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                prsAgingRelDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = prsAgingRelDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    prsAgingRelDt.Rows.Clear();
                    prsAgingRelDt = null;
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
            public static void LoadPoFirstReleaseDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    poFirstRelDt = new DataTable();

                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.PurchQueries.GetPoFirstRelease() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    poFirstRelDt = dt.Clone();


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

                        string[] strDate = (dr["PO Line Creat#DT"].ToString()).Split('/');
                        int year = int.Parse(strDate[2]);
                        int month = int.Parse(strDate[0].TrimStart('0'));
                        int day = int.Parse(strDate[1].TrimStart('0'));

                        DateTime date = new DateTime(year, month, day);
                        double elapsedDays = (int)(DateTime.Now - date).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                poFirstRelDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    poFirstRelDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    poFirstRelDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    poFirstRelDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    poFirstRelDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    poFirstRelDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    poFirstRelDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    poFirstRelDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = poFirstRelDt.Copy();
                    DataViewerUtils.DataLoaded = true;


                    poFirstRelDt.Rows.Clear();
                    poFirstRelDt = null;
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
            public static void LoadPoPrevReleaseDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    poPrevRelDt = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.PurchQueries.GetPoPrevRelease() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    poPrevRelDt = dt.Clone();



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


                        string[] strDate = (dr["PO Line Creat#DT"].ToString()).Split('/');
                        int year = int.Parse(strDate[2]);
                        int month = int.Parse(strDate[0].TrimStart('0'));
                        int day = int.Parse(strDate[1].TrimStart('0'));

                        DateTime date = new DateTime(year, month, day);
                        double elapsedDays = (int)(DateTime.Now - date).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                poPrevRelDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    poPrevRelDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    poPrevRelDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    poPrevRelDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    poPrevRelDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    poPrevRelDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    poPrevRelDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    poPrevRelDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = poPrevRelDt.Copy();
                    DataViewerUtils.DataLoaded = true;


                    poPrevRelDt.Rows.Clear();
                    poPrevRelDt = null;
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
            public static void LoadNoConfirmationsDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    noConfirmationsDt = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.PurchQueries.GetNoConfirmations() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    noConfirmationsDt = dt.Clone();



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

                        string[] strDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                        int year = int.Parse(strDate[2]);
                        int month = int.Parse(strDate[0].TrimStart('0'));
                        int day = int.Parse(strDate[1].TrimStart('0'));

                        DateTime date = new DateTime(year, month, day);
                        double elapsedDays = (int)(DateTime.Now - date).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                noConfirmationsDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    noConfirmationsDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    noConfirmationsDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    noConfirmationsDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    noConfirmationsDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    noConfirmationsDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    noConfirmationsDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    noConfirmationsDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = noConfirmationsDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    noConfirmationsDt.Rows.Clear();
                    noConfirmationsDt = null;
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

        public static class PurchSub
        {
            private static DataTable prRelPoRelDt;
            private static DataTable poCreatConfEntryDt;

            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPrReleaseToPoReleaseDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    prRelPoRelDt = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.PurchSubQueries.GetPrReleaseToPoRelease() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    prRelPoRelDt = dt.Clone();



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


                        string[] strDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                        int year = int.Parse(strDate[2]);
                        int month = int.Parse(strDate[0].TrimStart('0'));
                        int day = int.Parse(strDate[1].TrimStart('0'));

                        DateTime date = new DateTime(year, month, day);
                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (int)(today - date).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                prRelPoRelDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    prRelPoRelDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    prRelPoRelDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    prRelPoRelDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    prRelPoRelDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    prRelPoRelDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    prRelPoRelDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    prRelPoRelDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = prRelPoRelDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    prRelPoRelDt.Rows.Clear();
                    prRelPoRelDt = null;
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
            public static void LoadPoCreationToConfirmationEntryDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    poCreatConfEntryDt = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.PurchSubQueries.GetPoCreationToConfirmationEntry() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    poCreatConfEntryDt = dt.Clone();


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

                        string[] strDate = (dr["PO Line Creat#DT"].ToString()).Split('/');
                        int year = int.Parse(strDate[2]);
                        int month = int.Parse(strDate[0].TrimStart('0'));
                        int day = int.Parse(strDate[1].TrimStart('0'));

                        DateTime date = new DateTime(year, month, day);
                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (int)(today - date).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                poCreatConfEntryDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    poCreatConfEntryDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    poCreatConfEntryDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    poCreatConfEntryDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    poCreatConfEntryDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    poCreatConfEntryDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    poCreatConfEntryDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    poCreatConfEntryDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = poCreatConfEntryDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    poCreatConfEntryDt.Rows.Clear();
                    poCreatConfEntryDt = null;
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

        public static class PurchTotal
        {
            private static DataTable prRelConfEntry;


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPrReleaseToConfEntryDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    prRelConfEntry = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.PurchTotalQueries.GetPrReleaseToConfirmationEntry() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    prRelConfEntry = dt.Clone();


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


                        string[] strDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                        int year = int.Parse(strDate[2]);
                        int month = int.Parse(strDate[0].TrimStart('0'));
                        int day = int.Parse(strDate[1].TrimStart('0'));

                        DateTime date = new DateTime(year, month, day);
                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (int)(today - date).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                prRelConfEntry.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    prRelConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    prRelConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    prRelConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    prRelConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    prRelConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    prRelConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    prRelConfEntry.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = prRelConfEntry.Copy();
                    DataViewerUtils.DataLoaded = true;

                    prRelConfEntry.Rows.Clear();
                    prRelConfEntry = null;
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

        public static class FollowUp
        {
            private static DataTable confVsPlanDateDt;
            private static DataTable poFirsconfDateUpDelDt;
            private static DataTable LateConfDateDt;
            

            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadConfirmedVsPlanDateDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    confVsPlanDateDt = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.FollowUpQueries.GetConfirmedDateVsPlanDate() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    confVsPlanDateDt = dt.Clone();



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


                        string[] strCurrConfDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                        int delConfYear = int.Parse(strCurrConfDate[2]);
                        int delConfMonth = int.Parse(strCurrConfDate[0].TrimStart('0'));
                        int delConfDay = int.Parse(strCurrConfDate[1].TrimStart('0'));

                        DateTime delConfDate = new DateTime(delConfYear, delConfMonth, delConfDay);

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
                        double elapsedDays = (int)(delConfDate - currPlanDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                confVsPlanDateDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    confVsPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    confVsPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    confVsPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    confVsPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    confVsPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    confVsPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    confVsPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = confVsPlanDateDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    confVsPlanDateDt.Rows.Clear();
                    confVsPlanDateDt = null;
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
            public static void LoadConfirmedDateForUpcomingDeliveriesDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    poFirsconfDateUpDelDt = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.FollowUpQueries.GetConfrimedDateForUpcomingDeliveries() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    poFirsconfDateUpDelDt = dt.Clone();

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

                        DateTime date = new DateTime(year, month, day);
                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (int)(date - today).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                poFirsconfDateUpDelDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    poFirsconfDateUpDelDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    poFirsconfDateUpDelDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    poFirsconfDateUpDelDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    poFirsconfDateUpDelDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    poFirsconfDateUpDelDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    poFirsconfDateUpDelDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    poFirsconfDateUpDelDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = poFirsconfDateUpDelDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    poFirsconfDateUpDelDt.Rows.Clear();
                    poFirsconfDateUpDelDt = null;
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
            public static void LoadDueTodayOrLateToConfirmed(int tag)
            {
                try
                {
                    dt = new DataTable();
                    LateConfDateDt = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.FollowUpQueries.GetDueTodayOrLateToConfirmed() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    LateConfDateDt = dt.Clone();


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

                        DateTime date = new DateTime(year, month, day);
                        DateTime today = DateTime.Now.Date;

                        if (date > today)
                            continue;

                        double elapsedDays = (int)(today - date).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                LateConfDateDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    LateConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    LateConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    LateConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    LateConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    LateConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    LateConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    LateConfDateDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = LateConfDateDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    LateConfDateDt.Rows.Clear();
                    LateConfDateDt = null;
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

        public static class HotJobs
        {
            private static DataTable prsNotonPOHotJob;
            private static DataTable noConfirmations;
            private static DataTable lateToConfirmed;



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPRsNotOnPODataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    prsNotonPOHotJob = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.HotJobsQueries.GetPrsNotOnPo() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    prsNotonPOHotJob = dt.Clone();



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


                        string[] strDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                        int year = int.Parse(strDate[2]);
                        int month = int.Parse(strDate[0].TrimStart('0'));
                        int day = int.Parse(strDate[1].TrimStart('0'));

                        DateTime secLvlRelDt = new DateTime(year, month, day);
                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (int)(today - secLvlRelDt).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                prsNotonPOHotJob.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    prsNotonPOHotJob.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    prsNotonPOHotJob.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    prsNotonPOHotJob.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    prsNotonPOHotJob.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    prsNotonPOHotJob.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    prsNotonPOHotJob.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    prsNotonPOHotJob.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = prsNotonPOHotJob.Copy();
                    DataViewerUtils.DataLoaded = true;

                    prsNotonPOHotJob.Rows.Clear();
                    prsNotonPOHotJob = null;
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
            public static void LoadNoConfirmationDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    noConfirmations = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.HotJobsQueries.GetNoConfirmations() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    noConfirmations = dt.Clone();


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

                        string[] strDate = (dr["PO Line Creat#DT"].ToString()).Split('/');
                        int year = int.Parse(strDate[2]);
                        int month = int.Parse(strDate[0].TrimStart('0'));
                        int day = int.Parse(strDate[1].TrimStart('0'));

                        DateTime date = new DateTime(year, month, day);
                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (int)(today - date).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                noConfirmations.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    noConfirmations.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    noConfirmations.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    noConfirmations.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    noConfirmations.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    noConfirmations.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    noConfirmations.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    noConfirmations.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = noConfirmations.Copy();
                    DataViewerUtils.DataLoaded = true;

                    noConfirmations.Rows.Clear();
                    noConfirmations = null;
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
            public static void LoadLateToConfirmedDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    lateToConfirmed = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.HotJobsQueries.GetLateToConfirmed() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    lateToConfirmed = dt.Clone();


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

                        DateTime delConfDate = new DateTime(year, month, day);
                        DateTime today = DateTime.Now.Date;

                        if (!(delConfDate < today))
                            continue;

                        double elapsedDays = (today - delConfDate).TotalDays;
                        elapsedDays = (int)elapsedDays;



                        switch (tag)
                        {
                            case 0:
                                lateToConfirmed.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    lateToConfirmed.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    lateToConfirmed.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    lateToConfirmed.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    lateToConfirmed.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    lateToConfirmed.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    lateToConfirmed.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    lateToConfirmed.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = lateToConfirmed.Copy();
                    DataViewerUtils.DataLoaded = true;

                    lateToConfirmed.Rows.Clear();
                    lateToConfirmed = null;
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

        public static class ExcessStock_Stock
        {
            private static DataTable prsAgingNotRelDt;
            private static DataTable prsAgingRelDt;
            private static DataTable poConfThruDeliv;

            public static void LoadPrsAgingNotReleased(int tag)
            {
                try
                {
                    dt = new DataTable();
                    prsAgingNotRelDt = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.ExcessStockStockQueries.GetPrsAgingNotReleased() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    prsAgingNotRelDt = dt.Clone();



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

                        string[] strCurrReqDate = (dr["PR Delivery Date"].ToString()).Split('/');
                        int year = int.Parse(strCurrReqDate[2]);
                        int month = int.Parse(strCurrReqDate[0].TrimStart('0'));
                        int day = int.Parse(strCurrReqDate[1].TrimStart('0'));

                        DateTime currReqDate = new DateTime(year, month, day);
                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (currReqDate - today).TotalDays;
                        elapsedDays = (int)elapsedDays;

                        switch (tag)
                        {
                            case 0:
                                prsAgingNotRelDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    DataViewerUtils.Data = prsAgingNotRelDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    prsAgingNotRelDt.Rows.Clear();
                    prsAgingNotRelDt = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            public static void LoadPrsAgingReleased(int tag)
            {
                try
                {
                    dt = new DataTable();
                    prsAgingRelDt = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.ExcessStockStockQueries.GetPrsAgingReleased() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    prsAgingRelDt = dt.Clone();


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

                        string[] strDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                        int year = int.Parse(strDate[2]);
                        int month = int.Parse(strDate[0].TrimStart('0'));
                        int day = int.Parse(strDate[1].TrimStart('0'));

                        DateTime date = new DateTime(year, month, day);
                        double elapsedDays = (int)(DateTime.Now - date).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                prsAgingRelDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = prsAgingRelDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    prsAgingRelDt.Rows.Clear();
                    prsAgingRelDt = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            public static void LoadPoConfThruDeliv(int tag)
            {
                try
                {
                    dt = new DataTable();
                    poConfThruDeliv = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.ExcessStockStockQueries.GetPoCreationThruDelivery() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    poConfThruDeliv = dt.Clone();


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

                        string[] strDate = (dr["PO Line Creat#DT"].ToString()).Split('/');
                        int year = int.Parse(strDate[2]);
                        int month = int.Parse(strDate[0].TrimStart('0'));
                        int day = int.Parse(strDate[1].TrimStart('0'));

                        DateTime date = new DateTime(year, month, day);
                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (int)(today - date).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                poConfThruDeliv.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    poConfThruDeliv.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    poConfThruDeliv.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    poConfThruDeliv.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    poConfThruDeliv.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    poConfThruDeliv.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    poConfThruDeliv.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    poConfThruDeliv.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = poConfThruDeliv.Copy();
                    DataViewerUtils.DataLoaded = true;

                    poConfThruDeliv.Rows.Clear();
                    poConfThruDeliv = null;
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

        public static class ExcessStock_OpenOrders
        {
            private static DataTable prsAgingNotRelDt;
            private static DataTable prsAgingRelDt;
            private static DataTable poConfThruDeliv;

            public static void LoadPrsAgingNotReleased(int tag)
            {
                try
                {
                    dt = new DataTable();
                    prsAgingNotRelDt = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.ExcessStockOpenOrdersQueries.GetPrsAgingNotReleased(), DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    prsAgingNotRelDt = dt.Clone();



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

                        string[] reqCreationDate = (dr["Requisn Date"].ToString()).Split('/');
                        int year = int.Parse(reqCreationDate[2]);
                        int month = int.Parse(reqCreationDate[0].TrimStart('0'));
                        int day = int.Parse(reqCreationDate[1].TrimStart('0'));

                        DateTime reqDate = new DateTime(year, month, day);
                        double elapsedDays = (int)(DateTime.Now - reqDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                prsAgingNotRelDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    prsAgingNotRelDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = prsAgingNotRelDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    prsAgingNotRelDt.Rows.Clear();
                    prsAgingNotRelDt = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            public static void LoadPrsAgingReleased(int tag)
            {
                try
                {
                    dt = new DataTable();
                    prsAgingRelDt = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.ExcessStockOpenOrdersQueries.GetPrsAgingReleased() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    prsAgingRelDt = dt.Clone();


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

                        string[] strDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                        int year = int.Parse(strDate[2]);
                        int month = int.Parse(strDate[0].TrimStart('0'));
                        int day = int.Parse(strDate[1].TrimStart('0'));

                        DateTime date = new DateTime(year, month, day);
                        double elapsedDays = (int)(DateTime.Now - date).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                prsAgingRelDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    prsAgingRelDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = prsAgingRelDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    prsAgingRelDt.Rows.Clear();
                    prsAgingRelDt = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            public static void LoadPoConfThruDeliv(int tag)
            {
                try
                {
                    dt = new DataTable();
                    poConfThruDeliv = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.ExcessStockOpenOrdersQueries.GetPoCreationThruDelivery() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);


                    poConfThruDeliv = dt.Clone();


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

                        string[] strDate = (dr["PO Line Creat#DT"].ToString()).Split('/');
                        int year = int.Parse(strDate[2]);
                        int month = int.Parse(strDate[0].TrimStart('0'));
                        int day = int.Parse(strDate[1].TrimStart('0'));

                        DateTime date = new DateTime(year, month, day);
                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (int)(today - date).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                poConfThruDeliv.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    poConfThruDeliv.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    poConfThruDeliv.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    poConfThruDeliv.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    poConfThruDeliv.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    poConfThruDeliv.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    poConfThruDeliv.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29)
                                {
                                    poConfThruDeliv.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = poConfThruDeliv.Copy();
                    DataViewerUtils.DataLoaded = true;

                    poConfThruDeliv.Rows.Clear();
                    poConfThruDeliv = null;
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

        public static class CurrentPlanVsActual
        {                                                       
            private static DataTable currPlanDateVsCurrConfDateDt;
            private static DataTable currPlanDateVsCurrConfDateDtHotJobs;


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadCurrentPlanVsCurrentConfDateDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    currPlanDateVsCurrConfDateDt = new DataTable();

                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.CurrentPlanVsActualQueries.GetCurrentPlanDateVsCurrentConfirmationDate() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    currPlanDateVsCurrConfDateDt = dt.Clone();



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
                        double elapsedDays = (int)(confDate - currPlanDate).TotalDays;

                        int weeks = 0;
                        if (elapsedDays < 0)
                            weeks = (int)Math.Floor(elapsedDays / 7);
                        else if (elapsedDays == 0)
                            weeks = 0;
                        else
                            weeks = (int)Math.Ceiling(elapsedDays / 7);

                        switch (tag)
                        {
                            case 0:
                                currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                break;
                            case 1:
                                if (weeks < (-3))
                                {
                                    currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (weeks >= (-3) && weeks < (-2))
                                {
                                    currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (weeks >= (-2) && weeks < (-1))
                                {
                                    currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (weeks >= (-1) && weeks < 0)
                                {
                                    currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (weeks == 0)
                                {
                                    currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (weeks > 0 && weeks <= 1)
                                {
                                    currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (weeks > 1 && weeks <= 2)
                                {
                                    currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (weeks > 2 && weeks <= 3)
                                {
                                    currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (weeks > 3)
                                {
                                    currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }


                    DataViewerUtils.Data = currPlanDateVsCurrConfDateDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    currPlanDateVsCurrConfDateDt.Rows.Clear();
                    currPlanDateVsCurrConfDateDt = null;
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
            public static void LoadCurrPlandDateVsCurrConfDateOpenPOs_HotJobsDataTable(int tag)
            {
                try
                {
                    dt = new DataTable();
                    currPlanDateVsCurrConfDateDtHotJobs = new DataTable();
                    cmd = new OleDbCommand(Database.QueryManager.KpaQueries.CurrentPlanVsActualQueries.GetCurrentPlanDateVsCurrentConfirmationDateForHotJobs() + Filters.FilterQuery, DatabaseUtils.DatabaseConnection);

                    da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    currPlanDateVsCurrConfDateDtHotJobs = dt.Clone();



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
                        double elapsedDays = (int)(confDate - currPlanDate).TotalDays;


                        int weeks = 0;
                        if (elapsedDays < 0)
                            weeks = (int)Math.Floor(elapsedDays / 7);
                        else if (elapsedDays == 0)
                            weeks = 0;
                        else
                            weeks = (int)Math.Ceiling(elapsedDays / 7);

                        switch (tag)
                        {
                            case 0:
                                currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                break;
                            case 1:
                                if (weeks < (-3))
                                {
                                    currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (weeks >= (-3) && weeks < (-2))
                                {
                                    currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (weeks >= (-2) && weeks < (-1))
                                {
                                    currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (weeks >= (-1) && weeks < 0)
                                {
                                    currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (weeks == 0)
                                {
                                    currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (weeks > 0 && weeks <= 1)
                                {
                                    currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (weeks > 1 && weeks <= 2)
                                {
                                    currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (weeks > 2 && weeks <= 3)
                                {
                                    currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (weeks > 3)
                                {
                                    currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = currPlanDateVsCurrConfDateDtHotJobs.Copy();
                    DataViewerUtils.DataLoaded = true;

                    currPlanDateVsCurrConfDateDtHotJobs.Rows.Clear();
                    currPlanDateVsCurrConfDateDtHotJobs = null;
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
