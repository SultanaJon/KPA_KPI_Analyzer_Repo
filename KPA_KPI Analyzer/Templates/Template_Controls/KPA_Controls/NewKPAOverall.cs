using KPA_KPI_Analyzer.DataLoading;
using KPA_KPI_Analyzer.DataLoading.KPA_Data.DataTableLoader;
using KPA_KPI_Analyzer.Values;
using Reporting;
using Reporting.Interfaces;
using Reporting.KeyPerformanceActions;
using Reporting.Reports;
using Reporting.TimeSpans.Templates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPA_Controls
{
    public partial class NewKPAOverall : UserControl
    {
        #region FIELD DATA

        /// <summary>
        /// Indexers for template one's header position
        /// </summary>
        public enum TempOneValuesGridHeaderNames
        {
            Section,
            Category,
            TimeSpanOne,
            TimeSpanTwo,
            TimeSpanThree,
            TimeSpanFour,
            TimeSpanFive,
            TimeSpanSix,
            TimeSpanSeven,
            Average,
            Totals,
            Favorable
        }




        /// <summary>
        /// Indexers for template two's header position
        /// </summary>
        public enum TempTwoValuesGridHeaderNames
        {
            Section,
            Category,
            Average,
            TimeSpanOne,
            TimeSpanTwo,
            TimeSpanThree,
            TimeSpanFour,
            TimeSpanFive,
            TimeSpanSix,
            TimeSpanSeven,
            TimeSpanEight,
            TimeSpanNine,
            Totals,
            Favorable
        }

        #endregion


        /// <summary>
        /// Custom Constructor
        /// </summary>
        /// <param name="_data">The Kpa Overall Report</param>
        public NewKPAOverall()
        {
            InitializeComponent();
            ApplyValuesGridStyles();

            KPA_KPI_UI.topHandleBarModel.Performance = "KPA";

            if (ReportingCountry.TargetCountry == Country.UnitedStates)
                KPA_KPI_UI.topHandleBarModel.CurrentCountry = ReportingCountry.countries[(int)Country.UnitedStates];
            else
                KPA_KPI_UI.topHandleBarModel.CurrentCountry = ReportingCountry.countries[(int)Country.Mexico];
        }

        #region EVENTS

        /// <summary>
        /// Formats the section name of template one's datagridview
        /// </summary>
        /// <param name="sender">Template one's datagridview</param>
        /// <param name="e">The format event</param>
        private void bunifuCustomDataGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;

            if (e.ColumnIndex != 0)
                return;

            if (IsTheSameCellValueGridOne(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }





        /// <summary>
        /// Formats the section name of template two's datagridview
        /// </summary>
        /// <param name="sender">Template two's datagridview</param>
        /// <param name="e">The format event</param>
        private void bunifuCustomValuesGrid2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;

            if (e.ColumnIndex != 0)
                return;

            if (IsTheSameCellValueGridTwo(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }






        /// <summary>
        /// After the form is created, this load event will fire.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewKPAOverall_Load(object sender, EventArgs e)
        {
            LoadPlan();
            LoadPurch();
            LoadPurchSub();
            LoadPurchTotal();
            LoadFollowUp();
            LoadHotJobs();
            LoadExcessStockStock();
            LoadExcessStockOpenOrders();
            LoadCurrentPlanVsActual();

            TemplateOneValuesGrid.AutoGenerateColumns = false;
            TemplateTwoValuesGrid.AutoGenerateColumns = false;
        }






        /// <summary>
        /// Handles the event of when a cell in the Template One DataGridView is double clicked. The corresponding data will be loaded
        /// into the data viewer object.
        /// </summary>
        /// <param name="sender">the cell</param>
        /// <param name="e">the cell double click event</param>
        private void TemplateOneValuesGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (TemplateOneValuesGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == "0" || TemplateOneValuesGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("There is no data in this cell.", "Data Timespan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                switch (e.RowIndex)
                {
                    case 0: // Plan
                        HandlePlanDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 1:
                        HandlePlanDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 2: // Purch
                        HandlePurchDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 3:
                        HandlePurchDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 4:
                        HandlePurchDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 5:
                        HandlePurchDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 6: // Purch Sub
                        HandlePurchSubDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 7:
                        HandlePurchSubDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 8: // Purch Total
                        HandlePurchTotalDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 9: // Follow Up
                        HandleFollowUpDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 10:
                        HandleFollowUpDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 11:
                        HandleFollowUpDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 12: // Hot Jobs
                        HandleHotJobsDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 13:
                        HandleHotJobsDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 14:
                        HandleHotJobsDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 15: // Excess Stock - Stock
                        HandleExcessStockStock(e.RowIndex, e.ColumnIndex);
                        break;
                    case 16:
                        HandleExcessStockStock(e.RowIndex, e.ColumnIndex);
                        break;
                    case 17:
                        HandleExcessStockStock(e.RowIndex, e.ColumnIndex);
                        break;
                    case 18: // Excess Stock - Open Orders
                        HandleExcessStockOpenOrders(e.RowIndex, e.ColumnIndex);
                        break;
                    case 19:
                        HandleExcessStockOpenOrders(e.RowIndex, e.ColumnIndex);
                        break;
                    case 20:
                        HandleExcessStockOpenOrders(e.RowIndex, e.ColumnIndex);
                        break;
                }
            }
            catch (Exception)
            {
                // if the user clicks on the header dividers an index out of range excepion will be thrown. I am ignoring it.
            }
        }






        /// <summary>
        /// Handles the event of when a cell in the Template One DataGridView is double clicked. The corresponding data will be loaded
        /// into the data viewer object.
        /// </summary>
        /// <param name="sender">the cell</param>
        /// <param name="e">the cell double click event</param>
        private void TemplateTwoValuesGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (TemplateTwoValuesGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == "0" || TemplateTwoValuesGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("There is no data in this cell.", "Values Timespan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                switch (e.RowIndex)
                {
                    case 0:
                        HandleCurrentPlanVsActualDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 1:
                        HandleCurrentPlanVsActualDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                }
            }
            catch(Exception)
            {
                // if the user clicks on the header dividers an index out of range excepion will be thrown. I am ignoring it.
            }            
        }

        #endregion





        #region HELPER FUNCTIONS

        /// <summary>
        /// Sets the color of the DataGridView Header cells only.
        /// </summary>
        private void ApplyValuesGridStyles()
        {
            TemplateOneValuesGrid.Columns[(int)TempOneValuesGridHeaderNames.TimeSpanOne].HeaderCell.Style.BackColor = Color.FromArgb(123, 204, 242);
            TemplateOneValuesGrid.Columns[(int)TempOneValuesGridHeaderNames.TimeSpanOne].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateOneValuesGrid.Columns[(int)TempOneValuesGridHeaderNames.TimeSpanTwo].HeaderCell.Style.BackColor = Color.FromArgb(96, 189, 227);
            TemplateOneValuesGrid.Columns[(int)TempOneValuesGridHeaderNames.TimeSpanTwo].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateOneValuesGrid.Columns[(int)TempOneValuesGridHeaderNames.TimeSpanThree].HeaderCell.Style.BackColor = Color.FromArgb(79, 179, 208);
            TemplateOneValuesGrid.Columns[(int)TempOneValuesGridHeaderNames.TimeSpanThree].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateOneValuesGrid.Columns[(int)TempOneValuesGridHeaderNames.TimeSpanFour].HeaderCell.Style.BackColor = Color.FromArgb(62, 168, 186);
            TemplateOneValuesGrid.Columns[(int)TempOneValuesGridHeaderNames.TimeSpanFive].HeaderCell.Style.BackColor = Color.FromArgb(50, 150, 150);
            TemplateOneValuesGrid.Columns[(int)TempOneValuesGridHeaderNames.TimeSpanSix].HeaderCell.Style.BackColor = Color.FromArgb(41, 132, 137);
            TemplateOneValuesGrid.Columns[(int)TempOneValuesGridHeaderNames.TimeSpanSeven].HeaderCell.Style.BackColor = Color.FromArgb(31, 109, 109);
            TemplateOneValuesGrid.Columns[(int)TempOneValuesGridHeaderNames.Average].HeaderCell.Style.BackColor = Color.FromArgb(230, 184, 182);
            TemplateOneValuesGrid.Columns[(int)TempOneValuesGridHeaderNames.Totals].HeaderCell.Style.BackColor = Color.FromArgb(218, 150, 148);
            TemplateOneValuesGrid.Columns[(int)TempOneValuesGridHeaderNames.Favorable].HeaderCell.Style.BackColor = Color.FromArgb(169, 208, 142);
            TemplateOneValuesGrid.Columns[(int)TempOneValuesGridHeaderNames.Favorable].HeaderCell.Style.ForeColor = Color.White;



            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.Average].HeaderCell.Style.BackColor = Color.FromArgb(141, 180, 226);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.TimeSpanOne].HeaderCell.Style.BackColor = Color.FromArgb(155, 187, 89);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.TimeSpanTwo].HeaderCell.Style.BackColor = Color.FromArgb(196, 215, 155);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.TimeSpanTwo].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.TimeSpanThree].HeaderCell.Style.BackColor = Color.FromArgb(216, 228, 188);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.TimeSpanThree].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.TimeSpanFour].HeaderCell.Style.BackColor = Color.FromArgb(235, 241, 221);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.TimeSpanFour].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.TimeSpanFive].HeaderCell.Style.BackColor = Color.FromArgb(235, 241, 221);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.TimeSpanFive].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.TimeSpanSix].HeaderCell.Style.BackColor = Color.FromArgb(253, 233, 217);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.TimeSpanSix].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.TimeSpanSeven].HeaderCell.Style.BackColor = Color.FromArgb(252, 213, 180);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.TimeSpanSeven].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.TimeSpanEight].HeaderCell.Style.BackColor = Color.FromArgb(250, 191, 142);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.TimeSpanEight].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.TimeSpanNine].HeaderCell.Style.BackColor = Color.FromArgb(151, 71, 6);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.Totals].HeaderCell.Style.BackColor = Color.FromArgb(218, 150, 148);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.Favorable].HeaderCell.Style.BackColor = Color.FromArgb(169, 208, 142);
            TemplateTwoValuesGrid.Columns[(int)TempTwoValuesGridHeaderNames.Favorable].HeaderCell.Style.ForeColor = Color.White;
        }





        /// <summary>
        /// Removes duplicate section names from template one's datagridview.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        bool IsTheSameCellValueGridOne(int column, int row)
        {
            DataGridViewCell cell1 = TemplateOneValuesGrid[column, row];
            DataGridViewCell cell2 = TemplateOneValuesGrid[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }






        /// <summary>
        /// Removes duplicate section names from template two's datagridview.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        bool IsTheSameCellValueGridTwo(int column, int row)
        {
            DataGridViewCell cell1 = TemplateTwoValuesGrid[column, row];
            DataGridViewCell cell2 = TemplateTwoValuesGrid[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }






        /// <summary>
        /// Loads all of the KPA Plan data into the datagridview.
        /// </summary>
        private void LoadPlan()
        {
            // Get List of template one data for this KPA
            List<string> rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.Plan_PrsAgingNotReleased].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.Plan_PrsAgingNotReleased].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());


            // Get List of template one data for this KPA
            rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.Plan_MaterialDue].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.Plan_MaterialDue].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());
        }






        /// <summary>
        /// Loads all of the KPA Purch data into the datagridview.
        /// </summary>
        private void LoadPurch()
        {
            // Get List of template one data for this KPA
            List<string> rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.Purch_PRsAgingReleased].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.Purch_PRsAgingReleased].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());


            // Get List of template one data for this KPA
            rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.Purch_PoFirstRelease].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.Purch_PoFirstRelease].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());


            // Get List of template one data for this KPA
            rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.Purch_PoPrevRelease].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.Purch_PoPrevRelease].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());


            // Get List of template one data for this KPA
            rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.Purch_NoConfirmation].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.Purch_NoConfirmation].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());
        }






        /// <summary>
        /// Loads all of the KPA Purch Sub data into the datagridview.
        /// </summary>
        private void LoadPurchSub()
        {
            // Get List of template one data for this KPA
            List<string> rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.PurchSub_PrReleaseToPoRelease].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.PurchSub_PrReleaseToPoRelease].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());


            // Get List of template one data for this KPA
            rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.PurchSub_PoCreationToConfirmationEntry].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.PurchSub_PoCreationToConfirmationEntry].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());
        }






        /// <summary>
        /// Loads all of the KPA Purch Total data into the datagridview.
        /// </summary>
        private void LoadPurchTotal()
        {
            // Get List of template one data for this KPA
            List<string> rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.PurchTotal_PrReleaseToConfirmationEntry].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.PurchTotal_PrReleaseToConfirmationEntry].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());
        }






        /// <summary>
        /// Loads all of the KPA Follow Up data into the datagridview.
        /// </summary>
        private void LoadFollowUp()
        {
            // Get List of template one data for this KPA
            List<string> rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.FollowUp_ConfirmedDateVsPlanDate].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.FollowUp_ConfirmedDateVsPlanDate].TemplateBlock as TemplateOne).GetTemplateData()));
            rowData.Add(string.Format("{0:n0}", (KpaOverallReport.Actions[(int)KpaOption.FollowUp_ConfirmedDateVsPlanDate] as IFavorable).PercentFavorable + "%"));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());

            // Get List of template one data for this KPA
            rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.FollowUp_ConfirmedDateForUpcomingDeliveries].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.FollowUp_ConfirmedDateForUpcomingDeliveries].TemplateBlock as TemplateOne).GetTemplateData()));
            rowData.Add((string.Format("{0:n}", (KpaOverallReport.Actions[(int)KpaOption.FollowUp_ConfirmedDateForUpcomingDeliveries] as IFavorable).PercentFavorable + "%")));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());

            // Get List of template one data for this KPA
            rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.FollowUp_DueTodayOrLateToConfirmed].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.FollowUp_DueTodayOrLateToConfirmed].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());
        }






        /// <summary>
        /// Loads all of the KPA Hot Jobs data into the datagridview.
        /// </summary>
        private void LoadHotJobs()
        {
            // Get List of template one data for this KPA
            List<string> rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.HotJobs_PrsNotOnPo].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.HotJobs_PrsNotOnPo].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());


            // Get List of template one data for this KPA
            rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.HotJobs_NoConfirmations].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.HotJobs_NoConfirmations].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());


            // Get List of template one data for this KPA
            rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.HotJobs_LateToConfirmed].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.HotJobs_LateToConfirmed].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());
        }






        /// <summary>
        /// Loads all of the KPA Excess Stock - Stock data into the datagridview.
        /// </summary>
        private void LoadExcessStockStock()
        {
            // Get List of template one data for this KPA
            List<string> rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.ExcessStockStock_PrsAgingNotReleased].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.ExcessStockStock_PrsAgingNotReleased].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());


            // Get List of template one data for this KPA
            rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.ExcessStockStock_PrsAgingReleased].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.ExcessStockStock_PrsAgingReleased].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());


            // Get List of template one data for this KPA
            rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.ExcessStockStock_PoCreationTruDelivery].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.ExcessStockStock_PoCreationTruDelivery].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());
        }






        /// <summary>
        /// Loads all of the KPA Excess Stock - Open Orders data into the datagridview.
        /// </summary>
        private void LoadExcessStockOpenOrders()
        {
            // Get List of template one data for this KPA
            List<string> rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.ExcessStockOpenOrders_PrsAgingNotReleased].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.ExcessStockOpenOrders_PrsAgingNotReleased].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());


            // Get List of template one data for this KPA
            rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.ExcessStockOpenOrders_PrsAgingReleased].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.ExcessStockOpenOrders_PrsAgingReleased].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());


            // Get List of template one data for this KPA
            rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.ExcessStockOpenOrders_PoCreationTruDelivery].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.ExcessStockOpenOrders_PoCreationTruDelivery].TemplateBlock as TemplateOne).GetTemplateData()));

            // Add the row to the data grid view control
            TemplateOneValuesGrid.Rows.Add(rowData.ToArray());
        }






        /// <summary>
        /// Loads all of the KPA Current Plan vs Actual data into the datagridview.
        /// </summary>
        private void LoadCurrentPlanVsActual()
        {
            // Get List of template two data for this KPA
            List<string> rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.CurrentPlanVsActual_CurrentPlanDateVsCurrentConfirmationDate].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.CurrentPlanVsActual_CurrentPlanDateVsCurrentConfirmationDate].TemplateBlock as TemplateTwo).GetTemplateData()));
            rowData.Add((string.Format("{0:n0}", (KpaOverallReport.Actions[(int)KpaOption.CurrentPlanVsActual_CurrentPlanDateVsCurrentConfirmationDate] as IFavorable).PercentFavorable + "%")));

            // Add the row to the data grid view control
            TemplateTwoValuesGrid.Rows.Add(rowData.ToArray());

            // Get List of template two data for this KPA
            rowData = new List<string>(KpaOverallReport.Actions[(int)KpaOption.CurrentPlanVsActual_CurrentPlanDateVsCurrentConfirmationDateForHotJobs].Details);
            rowData.AddRange(new List<string>((KpaOverallReport.Actions[(int)KpaOption.CurrentPlanVsActual_CurrentPlanDateVsCurrentConfirmationDateForHotJobs].TemplateBlock as TemplateTwo).GetTemplateData()));
            rowData.Add((string.Format("{0:n0}", (KpaOverallReport.Actions[(int)KpaOption.CurrentPlanVsActual_CurrentPlanDateVsCurrentConfirmationDateForHotJobs] as IFavorable).PercentFavorable + "%")));

            // Add the row to the data grid view control
            TemplateTwoValuesGrid.Rows.Add(rowData.ToArray());
        }




        /// <summary>
        /// Loads calls the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandlePlanDataTableLoading(int rowIndex, int columnIndex)
        {
            using (DataViewer dv = new DataViewer())
            { 
                switch (rowIndex)
                {
                    case 0: // PRs Aging (Not Released)
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.DataLoader += KpaDataTableLoader.Plan.LoadPRsAgingNotRelDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.DataLoader += KpaDataTableLoader.Plan.LoadPRsAgingNotRelDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days
                                dv.DataLoader += KpaDataTableLoader.Plan.LoadPRsAgingNotRelDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days
                                dv.DataLoader += KpaDataTableLoader.Plan.LoadPRsAgingNotRelDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 Days
                                dv.DataLoader += KpaDataTableLoader.Plan.LoadPRsAgingNotRelDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.DataLoader += KpaDataTableLoader.Plan.LoadPRsAgingNotRelDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days
                                dv.DataLoader += KpaDataTableLoader.Plan.LoadPRsAgingNotRelDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals
                                dv.DataLoader += KpaDataTableLoader.Plan.LoadPRsAgingNotRelDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        break;
                    case 1: // Material Due
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.DataLoader += KpaDataTableLoader.Plan.LoadMaterialDueDataTable;
                               dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.DataLoader += KpaDataTableLoader.Plan.LoadMaterialDueDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days
                                dv.DataLoader += KpaDataTableLoader.Plan.LoadMaterialDueDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days
                                dv.DataLoader += KpaDataTableLoader.Plan.LoadMaterialDueDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 Days
                                dv.DataLoader += KpaDataTableLoader.Plan.LoadMaterialDueDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.DataLoader += KpaDataTableLoader.Plan.LoadMaterialDueDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days
                                dv.DataLoader += KpaDataTableLoader.Plan.LoadMaterialDueDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals
                                dv.DataLoader += KpaDataTableLoader.Plan.LoadMaterialDueDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        break;
                }

                dv.ShowDialog();
            }
        }






        /// <summary>
        /// Loads calls the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandlePurchDataTableLoading(int rowIndex, int columnIndex)
        {
            using (DataViewer dv = new DataViewer())
            {
                switch (rowIndex)
                {
                    case 2: // PRs Aging (Released)
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPrsAgingReleasedDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPrsAgingReleasedDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days  
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPrsAgingReleasedDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days 
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPrsAgingReleasedDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPrsAgingReleasedDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPrsAgingReleasedDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days    
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPrsAgingReleasedDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals     
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPrsAgingReleasedDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        break;
                    case 3: // PO First Release
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPoFirstReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPoFirstReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPoFirstReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPoFirstReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPoFirstReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPoFirstReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPoFirstReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPoFirstReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        break;
                    case 4: // PO Prev Release
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPoPrevReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPoPrevReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPoPrevReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPoPrevReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPoPrevReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPoPrevReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPoPrevReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadPoPrevReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        break;
                    case 5: // No Confirmation
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadNoConfirmationsDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadNoConfirmationsDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadNoConfirmationsDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadNoConfirmationsDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadNoConfirmationsDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadNoConfirmationsDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadNoConfirmationsDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals
                                dv.DataLoader += KpaDataTableLoader.Purch.LoadNoConfirmationsDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        break;
                }
                dv.ShowDialog();
            }

        }






        /// <summary>
        /// Loads calls the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandlePurchSubDataTableLoading(int rowIndex, int columnIndex)
        {
            using (DataViewer dv = new DataViewer())
            { 
                switch (rowIndex)
                {
                    case 6: // PR Release to Po Release
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.DataLoader += KpaDataTableLoader.PurchSub.LoadPrReleaseToPoReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.DataLoader += KpaDataTableLoader.PurchSub.LoadPrReleaseToPoReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days  
                                dv.DataLoader += KpaDataTableLoader.PurchSub.LoadPrReleaseToPoReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days 
                                dv.DataLoader += KpaDataTableLoader.PurchSub.LoadPrReleaseToPoReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 
                                dv.DataLoader += KpaDataTableLoader.PurchSub.LoadPrReleaseToPoReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.DataLoader += KpaDataTableLoader.PurchSub.LoadPrReleaseToPoReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days    
                                dv.DataLoader += KpaDataTableLoader.PurchSub.LoadPrReleaseToPoReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average     
                                return;
                            case 10: // Totals     
                                dv.DataLoader += KpaDataTableLoader.PurchSub.LoadPrReleaseToPoReleaseDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        break;
                    case 7: // PO Creation to Confirmation Entry
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.DataLoader += KpaDataTableLoader.PurchSub.LoadPoCreationToConfirmationEntryDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.DataLoader += KpaDataTableLoader.PurchSub.LoadPoCreationToConfirmationEntryDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days
                                dv.DataLoader += KpaDataTableLoader.PurchSub.LoadPoCreationToConfirmationEntryDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days
                                dv.DataLoader += KpaDataTableLoader.PurchSub.LoadPoCreationToConfirmationEntryDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 Days
                                dv.DataLoader += KpaDataTableLoader.PurchSub.LoadPoCreationToConfirmationEntryDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.DataLoader += KpaDataTableLoader.PurchSub.LoadPoCreationToConfirmationEntryDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days
                                dv.DataLoader += KpaDataTableLoader.PurchSub.LoadPoCreationToConfirmationEntryDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals
                                dv.DataLoader += KpaDataTableLoader.PurchSub.LoadPoCreationToConfirmationEntryDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        break;
                }
                dv.ShowDialog();
            }
        }






        /// <summary>
        /// Loads calls the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandlePurchTotalDataTableLoading(int rowIndex, int columnIndex)
        {
            using (DataViewer dv = new DataViewer())
            { 
                switch (rowIndex)
                {
                    case 8: // PR Release to Confirmation Entry
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.DataLoader += KpaDataTableLoader.PurchTotal.LoadPrReleaseToConfEntryDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.DataLoader += KpaDataTableLoader.PurchTotal.LoadPrReleaseToConfEntryDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days  
                                dv.DataLoader += KpaDataTableLoader.PurchTotal.LoadPrReleaseToConfEntryDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days 
                                dv.DataLoader += KpaDataTableLoader.PurchTotal.LoadPrReleaseToConfEntryDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 
                                dv.DataLoader += KpaDataTableLoader.PurchTotal.LoadPrReleaseToConfEntryDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.DataLoader += KpaDataTableLoader.PurchTotal.LoadPrReleaseToConfEntryDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days    
                                dv.DataLoader += KpaDataTableLoader.PurchTotal.LoadPrReleaseToConfEntryDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average     
                                return;
                            case 10: // Totals     
                                dv.DataLoader += KpaDataTableLoader.PurchTotal.LoadPrReleaseToConfEntryDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        break;
                }
                dv.ShowDialog();
            }
        }






        /// <summary>
        /// Loads calls the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandleFollowUpDataTableLoading(int rowIndex, int columnIndex)
        {
            using (DataViewer dv = new DataViewer())
            {
                switch (rowIndex)
                {
                    case 9: // Confirmed Date vs Plan Date
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadConfirmedVsPlanDateDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadConfirmedVsPlanDateDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days  
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadConfirmedVsPlanDateDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days 
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadConfirmedVsPlanDateDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadConfirmedVsPlanDateDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadConfirmedVsPlanDateDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days    
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadConfirmedVsPlanDateDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average     
                                return;
                            case 10: // Totals     
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadConfirmedVsPlanDateDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                            case 11: // This is % Favorable. We want to ignore any cell double clicks.
                                return;
                        }
                        break;
                    case 10: // Confirmed Date for Upcoming Deliveries
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadConfirmedDateForUpcomingDeliveriesDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadConfirmedDateForUpcomingDeliveriesDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadConfirmedDateForUpcomingDeliveriesDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadConfirmedDateForUpcomingDeliveriesDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadConfirmedDateForUpcomingDeliveriesDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadConfirmedDateForUpcomingDeliveriesDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadConfirmedDateForUpcomingDeliveriesDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadConfirmedDateForUpcomingDeliveriesDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                            case 11: // This is % Favorable. We want to ignore any cell double clicks.
                                return;
                        }
                        break;
                    case 11: // Late to Confirmed
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadDueTodayOrLateToConfirmed;
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadDueTodayOrLateToConfirmed;
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadDueTodayOrLateToConfirmed;
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadDueTodayOrLateToConfirmed;
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadDueTodayOrLateToConfirmed;
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadDueTodayOrLateToConfirmed;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadDueTodayOrLateToConfirmed;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadDueTodayOrLateToConfirmed;
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        break;
                }
                dv.ShowDialog();
            }
        }






        /// <summary>
        /// Loads calls the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="lcoumnIndex">The column index of the clicked cell</param>
        private void HandleHotJobsDataTableLoading(int rowIndex, int columnIndex)
        {
            using (DataViewer dv = new DataViewer())
            {
                switch (rowIndex)
                {
                    case 12: // PRs (Not on PO) - Hot Jobs Only
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadPRsNotOnPODataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadPRsNotOnPODataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days  
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadPRsNotOnPODataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days 
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadPRsNotOnPODataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadPRsNotOnPODataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadPRsNotOnPODataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days    
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadPRsNotOnPODataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average     
                                return;
                            case 10: // Totals     
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadPRsNotOnPODataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        break;
                    case 13: // No Confirmations - Hot Jobs Only
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadNoConfirmationDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadNoConfirmationDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadNoConfirmationDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadNoConfirmationDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 Days
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadNoConfirmationDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadNoConfirmationDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadNoConfirmationDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadNoConfirmationDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        break;
                    case 14: // Late to Confirmed - Hot Jobs Only
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadLateToConfirmedDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadLateToConfirmedDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadLateToConfirmedDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadLateToConfirmedDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 Days
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadLateToConfirmedDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadLateToConfirmedDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadLateToConfirmedDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals
                                dv.DataLoader += KpaDataTableLoader.HotJobs.LoadLateToConfirmedDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        break;
                }
                dv.ShowDialog();
            }
        }






        /// <summary>
        /// Loads calls the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandleExcessStockStock(int rowIndex, int columnIndex)
        {
            using (DataViewer dv = new DataViewer())
            {
                switch (rowIndex)
                {
                    case 15: // PRs Aging (Not Released)
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 Days
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        dv.DataLoader += KpaDataTableLoader.ExcessStock_Stock.LoadPrsAgingNotReleased;
                        break;
                    case 16: // PRs Aging (Released)
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days  
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days 
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days    
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals     
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        dv.DataLoader += KpaDataTableLoader.ExcessStock_Stock.LoadPrsAgingReleased;
                        break;
                    case 17: // PO Creation Date to Confirmation Entry Date
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 Days
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        dv.DataLoader += KpaDataTableLoader.ExcessStock_Stock.LoadPoConfThruDeliv;
                        break;
                }
                dv.ShowDialog();
            }
        }






        /// <summary>
        /// Loads calls the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandleExcessStockOpenOrders(int rowIndex, int columnIndex)
        {
            using (DataViewer dv = new DataViewer())
            {
                switch (rowIndex)
                {
                    case 18: // PRs Aging (Not Released)
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 Days
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        dv.DataLoader += KpaDataTableLoader.ExcessStock_OpenOrders.LoadPrsAgingNotReleased;
                        break;
                    case 19: // PRs Aging (Released)
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days  
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days 
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days    
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals     
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        dv.DataLoader += KpaDataTableLoader.ExcessStock_OpenOrders.LoadPrsAgingReleased;
                        break;
                    case 20: // PO Creation Date to Confirmation Entry Date
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // <= 0 Days
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 Days
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals
                                dv.ColumnTag = (int)TempOne.DataViews.Total;
                                break;
                        }
                        dv.DataLoader += KpaDataTableLoader.ExcessStock_OpenOrders.LoadPoConfThruDeliv;
                        break;
                }
                dv.ShowDialog();
            }
        }






        /// <summary>
        /// Loads calls the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandleCurrentPlanVsActualDataTableLoading(int rowIndex, int columnIndex)
        {
            using (DataViewer dv = new DataViewer())
            { 
                switch (rowIndex)
                {
                    case 0: // Current Plan Date vs Current Confirmation Date
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                            case 2: // Average
                                return;
                            case 3: // <-3 Weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrentPlanVsCurrentConfDateDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.LessThanMinusThree;
                                break;
                            case 4: // >= -3 weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrentPlanVsCurrentConfDateDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.GreaterThanEqualMinusThree;
                                break;
                            case 5: // >= -2 1weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrentPlanVsCurrentConfDateDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.GreaterThanEqualMinusTwo;
                                break;
                            case 6:// >= -1 3weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrentPlanVsCurrentConfDateDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.GreaterThanEqualMinusOne;
                                break;
                            case 7: // 0 Weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrentPlanVsCurrentConfDateDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.ZeroWeeks;
                                break;
                            case 8: // <= 1 Weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrentPlanVsCurrentConfDateDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.LessThanEqualOneWeek;
                                break;
                            case 9: // <= 2 Weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrentPlanVsCurrentConfDateDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.LessThanEqualTwoWeeks;
                                break;
                            case 10: // <= 3 Weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrentPlanVsCurrentConfDateDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.LessThanEqualThreeWeeks;
                                break;
                            case 11: // > 3 Weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrentPlanVsCurrentConfDateDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.GreaterThanThreeWeeks;
                                break;
                            case 12: // Total
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrentPlanVsCurrentConfDateDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.Total;
                                break;
                            case 13: // This is % Favorable. We want to ignore any cell double clicks.
                                return;
                        }
                        break;
                    case 1: // Current Plan Date vs Current Confirmation Date - Hot Jobs Only
                        switch (columnIndex)
                        {
                            case 0:
                            case 1:
                            case 2: // Average
                                return;
                            case 3: // <-3 Weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrPlandDateVsCurrConfDateOpenPOs_HotJobsDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.LessThanMinusThree;
                                break;
                            case 4: // >= -3 weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrPlandDateVsCurrConfDateOpenPOs_HotJobsDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.GreaterThanEqualMinusThree;
                                break;
                            case 5: // >= -2 1weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrPlandDateVsCurrConfDateOpenPOs_HotJobsDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.GreaterThanEqualMinusTwo;
                                break;
                            case 6:// >= -1 3weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrPlandDateVsCurrConfDateOpenPOs_HotJobsDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.GreaterThanEqualMinusOne;
                                break;
                            case 7: // 0 Weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrPlandDateVsCurrConfDateOpenPOs_HotJobsDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.ZeroWeeks;
                                break;
                            case 8: // <= 1 Weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrPlandDateVsCurrConfDateOpenPOs_HotJobsDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.LessThanEqualOneWeek;
                                break;
                            case 9: // <= 2 Weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrPlandDateVsCurrConfDateOpenPOs_HotJobsDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.LessThanEqualTwoWeeks;
                                break;
                            case 10: // <= 3 Weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrPlandDateVsCurrConfDateOpenPOs_HotJobsDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.LessThanEqualThreeWeeks;
                                break;
                            case 11: // > 3 Weeks
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrPlandDateVsCurrConfDateOpenPOs_HotJobsDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.GreaterThanThreeWeeks;
                                break;
                            case 12: // Total
                                dv.DataLoader += KpaDataTableLoader.CurrentPlanVsActual.LoadCurrPlandDateVsCurrConfDateOpenPOs_HotJobsDataTable;
                                dv.ColumnTag = (int)TempTwo.DataViews.Total;
                                break;
                            case 13: // This is % Favorable. We want to ignore any cell double clicks.
                                return;
                        }
                        break;
                }
                dv.ShowDialog();
            }
        }

        #endregion
    }
}
