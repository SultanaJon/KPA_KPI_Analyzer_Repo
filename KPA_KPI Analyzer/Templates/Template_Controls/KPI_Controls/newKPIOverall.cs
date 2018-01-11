using KPA_KPI_Analyzer.DataLoading;
using KPA_KPI_Analyzer.DataLoading.KPI_Data.DataTableLoader;
using KPA_KPI_Analyzer.Values;
using Reporting;
using Reporting.KeyPerformanceIndicators;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPI_Controls
{
    public partial class NewKPIOverall : UserControl
    {

        /// <summary>
        /// 
        /// </summary>
        public enum TempThreeHeaderNames
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
            Total,
            PercentUnconf,
            Favorable
        }


        /// <summary>
        /// 
        /// </summary>
        public enum TempFourHeaderNames
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
            TimeSpanTen,
            TimeSpanEleven,
            Total,
            PercentUnconf
        }


        /// <summary>
        /// 
        /// </summary>
        public enum TempFiveHeaderNames
        {
            Section,
            Category,
            TotalValue,
            TimeSpanOne,
            TimeSpanTwo,
            TimeSpanThree,
            TimeSpanFour,
            TimeSpanFive,
            TimeSpanSix,
            TimeSpanSeven,
            TimeSpanEight,
            TimeSpanNine,
            TimeSpanTen,
            Total,
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_data"></param>
        public NewKPIOverall()
        {
            InitializeComponent();
            ApplyDataGridStyles();


            Globals.CurrPerformance = "KPI";

            if (ReportingCountry.TargetCountry == Country.UnitedStates)
                Globals.CurrCountry = ReportingCountry.countries[(int)Country.UnitedStates];
            else
                Globals.CurrCountry = ReportingCountry.countries[(int)Country.Mexico];
        }








        /// <summary>
        /// Sets the color of the DataGridView Header cells only.
        /// </summary>
        private void ApplyDataGridStyles()
        {
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.Average].HeaderCell.Style.BackColor = Color.FromArgb(141, 180, 226);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanOne].HeaderCell.Style.BackColor = Color.FromArgb(155, 187, 89);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanTwo].HeaderCell.Style.BackColor = Color.FromArgb(196, 215, 155);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanTwo].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanThree].HeaderCell.Style.BackColor = Color.FromArgb(216, 228, 188);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanThree].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanFour].HeaderCell.Style.BackColor = Color.FromArgb(235, 241, 222);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanFour].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanFive].HeaderCell.Style.BackColor = Color.White;
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanFive].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanSix].HeaderCell.Style.BackColor = Color.FromArgb(253, 233, 217);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanSix].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanSeven].HeaderCell.Style.BackColor = Color.FromArgb(252, 213, 180);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanSeven].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanEight].HeaderCell.Style.BackColor = Color.FromArgb(250, 191, 143);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanEight].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanNine].HeaderCell.Style.BackColor = Color.FromArgb(246, 144, 60);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.Total].HeaderCell.Style.BackColor = Color.FromArgb(103, 65, 114);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.PercentUnconf].HeaderCell.Style.BackColor = Color.IndianRed;
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.Favorable].HeaderCell.Style.BackColor = Color.FromArgb(169, 208, 142);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.Favorable].HeaderCell.Style.ForeColor = Color.White;

            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.Average].HeaderCell.Style.BackColor = Color.FromArgb(141, 180, 226);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanOne].HeaderCell.Style.BackColor = Color.FromArgb(252, 213, 180);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanOne].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanTwo].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanTwo].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanThree].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanThree].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanFour].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanFour].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanFive].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanFive].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanSix].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanSix].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanSeven].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanSeven].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanEight].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanEight].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanNine].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanNine].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanTen].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanTen].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanEleven].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanEleven].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.Total].HeaderCell.Style.BackColor = Color.FromArgb(103, 65, 114);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.PercentUnconf].HeaderCell.Style.BackColor = Color.IndianRed;


            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TotalValue].HeaderCell.Style.BackColor = Color.FromArgb(141, 180, 226);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanOne].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanOne].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanTwo].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanTwo].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanThree].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanThree].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanFour].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanFour].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanFive].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanFive].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanSix].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanSix].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanSeven].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanSeven].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanEight].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanEight].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanNine].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanNine].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanTen].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanTen].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.Total].HeaderCell.Style.BackColor = Color.FromArgb(103, 65, 114);
        }







        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        bool IsTheSameCellValueGridOne(int column, int row)
        {
            DataGridViewCell cell1 = TemplateThreeDataGrid[column, row];
            DataGridViewCell cell2 = TemplateThreeDataGrid[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }






        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        bool IsTheSameCellValueGridTwo(int column, int row)
        {
            DataGridViewCell cell1 = TemplateFourDataGrid[column, row];
            DataGridViewCell cell2 = TemplateFourDataGrid[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        bool IsTheSameCellValueGridThree(int column, int row)
        {
            DataGridViewCell cell1 = TemplateFiveDataGrid[column, row];
            DataGridViewCell cell2 = TemplateFiveDataGrid[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }






        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bunifuCustomDataGrid2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bunifuCustomDataGrid3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;

            if (e.ColumnIndex != 0)
                return;

            if (IsTheSameCellValueGridThree(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }






        /// <summary>
        // Load all the function that load all the data into the datagridviews.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewKPIOverall_Load(object sender, EventArgs e)
        {
            LoadPlan();
            LoadPurch();
            LoadFollowUp();
            LoadPlanTwo();
            LoadPurchTwo();
            LoadPurchSub();
            LoadPurchTotal();
            LoadPurchPlan();
            LoadOther();

            TemplateThreeDataGrid.AutoGenerateColumns = false;
            TemplateFourDataGrid.AutoGenerateColumns = false;
            TemplateFiveDataGrid.AutoGenerateColumns = false;
        }







        /// <summary>
        /// Loads all of the KPA Plan data into the datagridview.
        /// </summary>
        private void LoadPlan()
        {
            // Get List of template one data for this KPA
            List<string> rowData = new List<string>((Report.Indicators[(int)KpiOption.Plan_CurrentPlanDateVsPrPlanDate]
                as Reporting.KeyPerformanceIndicators.Plan.CurrentPlanDateVsPRPlanDate).GetTemplateData());

            // Add the row to the data grid view control
            TemplateThreeDataGrid.Rows.Add(rowData.ToArray());



            // Get List of template one data for this KPA
            rowData = new List<string>((Report.Indicators[(int)KpiOption.Plan_OrigPlanDateMinusPrFullReleaseDateVsCodedLead]
                as Reporting.KeyPerformanceIndicators.Plan.OriginalPlanDateTo2ndLvlReleaseDateVsCodedLead).GetTemplateData());

            // Add the row to the data grid view control
            TemplateThreeDataGrid.Rows.Add(rowData.ToArray());



            // Get List of template one data for this KPA
            rowData = new List<string>((Report.Indicators[(int)KpiOption.Plan_CurrentPlanDateMinusPrFullReleaseDateVsCodedLead]
                as Reporting.KeyPerformanceIndicators.Plan.CurrentPlanDateTo2ndLvlReleaseDateVsCodedLead).GetTemplateData());

            // Add the row to the data grid view control
            TemplateThreeDataGrid.Rows.Add(rowData.ToArray());
        }







        /// <summary>
        /// Loads all of the KPA Purch data into the datagridview.
        /// </summary>
        private void LoadPurch()
        {
            // Get List of template one data for this KPA
            List<string> rowData = new List<string>((Report.Indicators[(int)KpiOption.Purch_InitialConfirmationDateVsPrPlanDate]
                as Reporting.KeyPerformanceIndicators.Purch.InitialConfirmationDateVsPRPlanDate).GetTemplateData());

            // Add the row to the data grid view control
            TemplateThreeDataGrid.Rows.Add(rowData.ToArray());        
        }







        /// <summary>
        /// Loads all of the KPA Purch Sub data into the datagridview.
        /// </summary>
        private void LoadFollowUp()
        {
            // Get List of template one data for this KPA
            List<string> rowData = new List<string>((Report.Indicators[(int)KpiOption.FollowUp_CurrentConfirmationDateVsInitialConfirmationDate]
                as Reporting.KeyPerformanceIndicators.FollowUp.CurrentConfirmationDateVsInitialConfirmationDate).GetTemplateData());

            // Add the row to the data grid view control
            TemplateThreeDataGrid.Rows.Add(rowData.ToArray());

            // Get List of template one data for this KPA
            rowData = new List<string>((Report.Indicators[(int)KpiOption.FollowUp_FinalConfirmationDateVsInitialConfirmationDate]
                as Reporting.KeyPerformanceIndicators.FollowUp.FinalConfirmationDateVsFinalPlanDate).GetTemplateData());

            // Add the row to the data grid view control
            TemplateThreeDataGrid.Rows.Add(rowData.ToArray());

            // Get List of template one data for this KPA
            rowData = new List<string>((Report.Indicators[(int)KpiOption.FollowUp_ReceiptDateVsCurrentPlanDate]
                as Reporting.KeyPerformanceIndicators.FollowUp.ReceiptDateVsCurrentPlanDate).GetTemplateData());

            // Add the row to the data grid view control
            TemplateThreeDataGrid.Rows.Add(rowData.ToArray());

            // Get List of template one data for this KPA
            rowData = new List<string>((Report.Indicators[(int)KpiOption.FollowUp_ReceiptDateVsOriginalConfirmationDate]
                as Reporting.KeyPerformanceIndicators.FollowUp.ReceiptDateVsOriginalConfirmationDate).GetTemplateData());

            // Add the row to the data grid view control
            TemplateThreeDataGrid.Rows.Add(rowData.ToArray());

            // Get List of template one data for this KPA
            rowData = new List<string>((Report.Indicators[(int)KpiOption.FollowUp_ReceiptDateVsCurrentConfirmationDate]
                as Reporting.KeyPerformanceIndicators.FollowUp.ReceiptDateVsCurrentConfirmationDate).GetTemplateData());

            // Add the row to the data grid view control
            TemplateThreeDataGrid.Rows.Add(rowData.ToArray());
        }





        /// <summary>
        /// Loads all of the KPA Purch Total data into the datagridview.
        /// </summary>
        private void LoadPlanTwo()
        {
            // Get List of template one data for this KPA
            List<string> rowData = new List<string>((Report.Indicators[(int)KpiOption.PlanTwo_MaterialDueOriginalPlannedDate]
                as Reporting.KeyPerformanceIndicators.PlanTwo.MaterialDueOriginalPlannedDate).GetTemplateData());

            // Add the row to the data grid view control
            TemplateFourDataGrid.Rows.Add(rowData.ToArray());

            // Get List of template one data for this KPA
            rowData = new List<string>((Report.Indicators[(int)KpiOption.PlanTwo_MaterialDueFinalPlannedDate]
                as Reporting.KeyPerformanceIndicators.PlanTwo.MaterialDueFinalPlannedDate).GetTemplateData());

            // Add the row to the data grid view control
            TemplateFourDataGrid.Rows.Add(rowData.ToArray());
        }





        /// <summary>
        /// Loads all of the KPA Purch Plan data into the datagridview.
        /// </summary>
        private void LoadPurchTwo()
        {
            // Get List of template one data for this KPA
            List<string> rowData = new List<string>((Report.Indicators[(int)KpiOption.PurchTwo_PrFullyReleaseDateVsPoCreationDate]
                as Reporting.KeyPerformanceIndicators.PurchTwo.PR2ndLvlReleaseDateVsPOCreationDate).GetTemplateData());

            // Add the row to the data grid view control
            TemplateFourDataGrid.Rows.Add(rowData.ToArray());

            // Get List of template one data for this KPA
            rowData = new List<string>((Report.Indicators[(int)KpiOption.PurchTwo_PoCreationDateVsPoReleaseDate]
                as Reporting.KeyPerformanceIndicators.PurchTwo.POCreationDateVsPOReleaseDate).GetTemplateData());

            // Add the row to the data grid view control
            TemplateFourDataGrid.Rows.Add(rowData.ToArray());

            // Get List of template one data for this KPA
            rowData = new List<string>((Report.Indicators[(int)KpiOption.PurchTwo_PoReleaseDateVsPoConfirmationDate]
                as Reporting.KeyPerformanceIndicators.PurchTwo.POReleaseDateVsPOConfirmationDate).GetTemplateData());

            // Add the row to the data grid view control
            TemplateFourDataGrid.Rows.Add(rowData.ToArray());
        }





        /// <summary>
        /// Loads all of the KPA Follow Up data into the datagridview.
        /// </summary>
        private void LoadPurchSub()
        {
            // Get List of template one data for this KPA
            List<string> rowData = new List<string>((Report.Indicators[(int)KpiOption.PurchSub_PrReleaseVsPoReleaseDate]
                as Reporting.KeyPerformanceIndicators.PurchSub.PRReleaseDateVsPOReleaseDate).GetTemplateData());

            // Add the row to the data grid view control
            TemplateFourDataGrid.Rows.Add(rowData.ToArray());

            // Get List of template one data for this KPA
            rowData = new List<string>((Report.Indicators[(int)KpiOption.PurchSub_PoCreationDateVsConfirmationEntryDate]
                as Reporting.KeyPerformanceIndicators.PurchSub.POCreationDateVsConfirmationEntry).GetTemplateData());

            // Add the row to the data grid view control
            TemplateFourDataGrid.Rows.Add(rowData.ToArray());
        }





        /// <summary>
        /// Loads all of the KPA Cancellations data into the datagridview.
        /// </summary>
        private void LoadPurchTotal()
        {
            // Get List of template one data for this KPA
            List<string> rowData = new List<string>((Report.Indicators[(int)KpiOption.PurchTotal_PrReleaseDateToConfirmationEntryDate]
                as Reporting.KeyPerformanceIndicators.PurchTotal.PRReleaseDateToConfirmationEntry).GetTemplateData());

            // Add the row to the data grid view control
            TemplateFourDataGrid.Rows.Add(rowData.ToArray());
        }





        /// <summary>
        /// Loads all of the NCRs Plan data into the datagridview.
        /// </summary>
        private void LoadPurchPlan()
        {
            // Get List of template one data for this KPA
            List<string> rowData = new List<string>((Report.Indicators[(int)KpiOption.PurchPlan_PoReleaseVsPrDeliveryDate]
                as Reporting.KeyPerformanceIndicators.PurchPlan.POReleaseVsPRDeliveryDate).GetTemplateData());

            // Add the row to the data grid view control
            TemplateFourDataGrid.Rows.Add(rowData.ToArray());
        }





        /// <summary>
        /// Loads all of the KPA Excess Stock - Stock data into the datagridview.
        /// </summary>
        private void LoadOther()
        {
            // Get List of template one data for this KPA
            List<string> rowData = new List<string>((Report.Indicators[(int)KpiOption.Other_PrsCreated]
                as Reporting.KeyPerformanceIndicators.Other.PRsCreated).GetTemplateData());

            // Add the row to the data grid view control
            TemplateFiveDataGrid.Rows.Add(rowData.ToArray());

            rowData = new List<string>((Report.Indicators[(int)KpiOption.Other_PrsReleased]
                as Reporting.KeyPerformanceIndicators.Other.PRsReleased).GetTemplateData());

            // Add the row to the data grid view control
            TemplateFiveDataGrid.Rows.Add(rowData.ToArray());

            rowData = new List<string>((Report.Indicators[(int)KpiOption.Other_TotalSpend]
                as Reporting.KeyPerformanceIndicators.Other.TotalSpend).GetTemplateData());

            // Add the row to the data grid view control
            TemplateFiveDataGrid.Rows.Add(rowData.ToArray());

            rowData = new List<string>((Report.Indicators[(int)KpiOption.Other_PrValueVsPoValue]
                as Reporting.KeyPerformanceIndicators.Other.PRValueVsPOValue).GetTemplateData());

            // Add the row to the data grid view control
            TemplateFiveDataGrid.Rows.Add(rowData.ToArray());

            rowData = new List<string>((Report.Indicators[(int)KpiOption.Other_HotJobPRs]
                 as Reporting.KeyPerformanceIndicators.Other.HotJobPRs).GetTemplateData());

            // Add the row to the data grid view control
            TemplateFiveDataGrid.Rows.Add(rowData.ToArray());
        }









        /// <summary>
        /// Handles the event of when a cell in the Template One DataGridView is double clicked. The corresponding data will be loaded
        /// into the data viewer object.
        /// </summary>
        /// <param name="sender">the cell</param>
        /// <param name="e">the cell double click event</param>
        private void TemplateThreeDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (TemplateThreeDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == "0" || TemplateThreeDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == "$0.00" || TemplateThreeDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("There is no data in this cell", "Data Timespan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                switch (e.RowIndex)
                {
                    case 0: // Plan
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.Plan];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.Plan][(int)Values.Categories.KpiCategory.Plan.CurrentPlanDateVsPrPlanDate];
                        HandlePlanDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 1:
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.Plan];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.Plan][(int)Values.Categories.KpiCategory.Plan.OriginalPlanDate2ndLvlReleaseDatevsCodedLeadTime];
                        HandlePlanDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 2:
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.Plan];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.Plan][(int)Values.Categories.KpiCategory.Plan.CurrentPlanDate2ndLvlReleaseDatevsCodedLeadTime];
                        HandlePlanDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 3: // Purch
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.Purch];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.Purch][(int)Values.Categories.KpiCategory.Purch.InitialConfirmationDatevsPRPlanDate];
                        HandlePurchDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 4: // Follow Up
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.FollowUp];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.FollowUp][(int)Values.Categories.KpiCategory.FollowUp.CurrentConfDateVsInitialConfDate];
                        HandleFollowUpDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 5:
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.FollowUp];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.FollowUp][(int)Values.Categories.KpiCategory.FollowUp.FinalConfirmationDatevsFinalPlanDate];
                        HandleFollowUpDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 6:
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.FollowUp];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.FollowUp][(int)Values.Categories.KpiCategory.FollowUp.ReceiptDatevsCurrentPlanDate];
                        HandleFollowUpDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 7:
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.FollowUp];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.FollowUp][(int)Values.Categories.KpiCategory.FollowUp.ReceiptDatevsOriginalConfirmationDate];
                        HandleFollowUpDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 8:
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.FollowUp];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.FollowUp][(int)Values.Categories.KpiCategory.FollowUp.ReceiptDatevsCurrentConfirmationDate];
                        HandleFollowUpDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                }
            }
            catch(Exception)
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
        private void TemplateFourDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (TemplateFourDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == "0" || TemplateFourDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == "$0.00" || TemplateFourDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("There is no data in this cell", "Data Timespan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                switch (e.RowIndex)
                {
                    case 0: 
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.PlanTwo];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.PlanTwo][(int)Values.Categories.KpiCategory.PlanTwo.MaterialDueOriginalPlanDate];
                        HandlePlanTwoDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 1:
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.PlanTwo];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.PlanTwo][(int)Values.Categories.KpiCategory.PlanTwo.MaterialDueFinalPlannedDate];
                        HandlePlanTwoDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 2: // 4 - 5 = Purch Two
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.PurchTwo];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.PurchTwo][(int)Values.Categories.KpiCategory.PurchTwo.PR2ndLvlReleaseDatevsPOCreationDate];
                        HandlePurchTwoDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 3:
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.PurchTwo];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.PurchTwo][(int)Values.Categories.KpiCategory.PurchTwo.POCreationDatevsPOReleaseDate];
                        HandlePurchTwoDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 4:
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.PurchTwo];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.PurchTwo][(int)Values.Categories.KpiCategory.PurchTwo.POReleaseDatevsPOConfirmationDate];
                        HandlePurchTwoDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 5: // 7 - 8 Purch Sub
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.PurchSub];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.PurchSub][(int)Values.Categories.KpiCategory.PurchSub.PRReleaseDatevsPOReleaseDate];
                        HandlePurchSubDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 6:
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.PurchSub];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.PurchSub][(int)Values.Categories.KpiCategory.PurchSub.POCreationDatevsConfirmationEntryDate];
                        HandlePurchSubDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 7: // Purch Total
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.PurchTotal];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.PurchTotal][(int)Values.Categories.KpiCategory.PurchTotal.PRReleaseDatetoConfirmationEntryDate];
                        HandlePurchTotalDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 8: // 10 - 11 = Purch Plan
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.PurchPlan];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.PurchPlan][(int)Values.Categories.KpiCategory.PurchPlan.POReleasevsPRDeliveryDate];
                        HandlePurchPlanDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                }
            }
            catch(Exception)
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
        private void TemplateFiveDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (TemplateFiveDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == "0" || TemplateFiveDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == "$0.00" || TemplateFiveDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == String.Empty)
                {
                    MessageBox.Show("There is no data in this cell", "Data Timespan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                switch(e.RowIndex)
                {
                    case 0:
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.Other];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.Other][(int)Values.Categories.KpiCategory.Other.PRsCreated];
                        HandleOtherDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 1:
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.Other];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.Other][(int)Values.Categories.KpiCategory.Other.PRsReleased];
                        HandleOtherDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 2:
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.Other];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.Other][(int)Values.Categories.KpiCategory.Other.TotalSpend];
                        HandleOtherDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 3:
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.Other];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.Other][(int)Values.Categories.KpiCategory.Other.PRValuevsPOValue];
                        HandleOtherDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 4:
                        Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.Other];
                        Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.Other][(int)Values.Categories.KpiCategory.Other.HotJobPRs];
                        HandleOtherDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                }
            }
            catch(Exception)
            {
                // if the user clicks on the header dividers an index out of range excepion will be thrown. I am ignoring it.
            }
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
                    case 0: // PR Plan Date vs Current Plan Date
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                            case 2: // Average
                                return;
                            case 3: // <= -22 Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_TwentyTwo;
                                break;
                            case 4: // -(15 - 21) Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Fifteen_TwentyOne;
                                break;
                            case 5: // -(8 - 14) Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Eight_Fourteen;
                                break;
                            case 6: // -(1 - 7) Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_One_Seven;
                                break;
                            case 7: // 0 days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Zero;
                                break;
                            case 8: // 1 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.One_Seven;
                                break;
                            case 9: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Eight_Fourteen;
                                break;
                            case 10: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Fifteen_TwentyOne;
                                break;
                            case 11: // >= 22 Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.TwentyTwo;
                                break;
                            case 12: // Total
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Total;
                                break;
                            case 13: // empy cell for % unconfirmed. This is not being recorded for this KPI
                            case 14: // This is % Favorable and we want to ignore any cell double clicks.
                                return;
                        }
                        break;
                    case 1: // (Original Plan Date - 2nd Lvl Rel Date) vs Coded Lead-time
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                            case 2: // Average
                                return;
                            case 3: // <= -22 Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_TwentyTwo;
                                break;
                            case 4: // -(15 - 21) Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Fifteen_TwentyOne;
                                break;
                            case 5: // -(8 - 14) Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Eight_Fourteen;
                                break;
                            case 6: // -(1 - 7) Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_One_Seven;
                                break;
                            case 7: // 0 days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Zero;
                                break;
                            case 8: // 1 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.One_Seven;
                                break;
                            case 9: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Eight_Fourteen;
                                break;
                            case 10: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Fifteen_TwentyOne;
                                break;
                            case 11: // >= 22 Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.TwentyTwo;
                                break;
                            case 12: // Total
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Total;
                                break;
                            case 13: // empy cell for % unconfirmed. This is not being recorded for this KPI
                            case 14: // This is % Favorable and we want to ignore any cell double clicks.
                                return;
                        }
                        break;
                    case 2: // (Current Plan Date - 2nd Lvl Rel Date) vs Coded Lead-time
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                            case 2: // Average
                                return;
                            case 3: // <= -22 Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_TwentyTwo;
                                break;
                            case 4: // -(15 - 21) Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Fifteen_TwentyOne;
                                break;
                            case 5: // -(8 - 14) Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Eight_Fourteen;
                                break;
                            case 6: // -(1 - 7) Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_One_Seven;
                                break;
                            case 7: // 0 days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Zero;
                                break;
                            case 8: // 1 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.One_Seven;
                                break;
                            case 9: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Eight_Fourteen;
                                break;
                            case 10: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Fifteen_TwentyOne;
                                break;
                            case 11: // >= 22 Days
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.TwentyTwo;
                                break;
                            case 12: // Total
                                dv.DataLoader += KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Total;
                                break;
                            case 13: // empy cell for % unconfirmed. This is not being recorded for this KPI
                            case 14: // This is % Favorable and we want to ignore any cell double clicks.
                                return;
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
                    case 3:
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                            case 2: // Average
                                return;
                            case 3: // <= -22 Days
                                dv.DataLoader += KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_TwentyTwo;
                                break;
                            case 4: // -(15 - 21) Days
                                dv.DataLoader += KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Fifteen_TwentyOne;
                                break;
                            case 5: // -(8 - 14) Days
                                dv.DataLoader += KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Eight_Fourteen;
                                break;
                            case 6: // -(1 - 7) Days
                                dv.DataLoader += KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_One_Seven;
                                break;
                            case 7: // 0 days
                                dv.DataLoader += KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Zero;
                                break;
                            case 8: // 1 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.One_Seven;
                                break;
                            case 9: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Eight_Fourteen;
                                break;
                            case 10: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Fifteen_TwentyOne;
                                break;
                            case 11: // >= 22 Days
                                dv.DataLoader += KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.TwentyTwo;
                                break;
                            case 12: // Total
                                dv.DataLoader += KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Total;
                                break;
                            case 13: // Percent Unconfirmed
                                dv.DataLoader += KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.PercentUnconf;
                                break;
                            case 14: // This is % Favorable and we want to ignore any cell double clicks.
                                return;
                        }
                        break;
                }
                dv.ShowDialog();
            }
        }






        /// <summary>
        /// Loads cells the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandleFollowUpDataTableLoading(int rowIndex, int columnIndex)
        {
            using (DataViewer dv = new DataViewer())
            { 
                switch (rowIndex)
                {
                    case 4: // Initial Confirmation Date vs current Confirmation Date
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                            case 2: // Average
                                return;
                            case 3: // <= -22 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadCurrConfVsInitConfDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_TwentyTwo;
                                break;
                            case 4: // -(15 - 21) Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadCurrConfVsInitConfDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Fifteen_TwentyOne;
                                break;
                            case 5: // -(8 - 14) Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadCurrConfVsInitConfDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Eight_Fourteen;
                                break;
                            case 6: // -(1 - 7) Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadCurrConfVsInitConfDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_One_Seven;
                                break;
                            case 7: // 0 days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadCurrConfVsInitConfDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Zero;
                                break;
                            case 8: // 1 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadCurrConfVsInitConfDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.One_Seven;
                                break;
                            case 9: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadCurrConfVsInitConfDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Eight_Fourteen;
                                break;
                            case 10: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadCurrConfVsInitConfDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Fifteen_TwentyOne;
                                break;
                            case 11: // >= 22 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadCurrConfVsInitConfDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.TwentyTwo;
                                break;
                            case 12: // Total
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadCurrConfVsInitConfDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Total;
                                break;
                            case 13: // Percent Unconfirmed
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadCurrConfVsInitConfDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.PercentUnconf;
                                break;
                            case 14: // This is % Favorable and we want to ignore any cell double clicks.
                                return;
                        }
                        break;
                    case 5: // Final Confirmation Date vs Final Plan Date
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // Average
                                return;
                            case 3: // <= -22 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_TwentyTwo;
                                break;
                            case 4: // -(15 - 21) Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Fifteen_TwentyOne;
                                break;
                            case 5: // -(8 - 14) Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Eight_Fourteen;
                                break;
                            case 6: // -(1 - 7) Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_One_Seven;
                                break;
                            case 7: // 0 days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Zero;
                                break;
                            case 8: // 1 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.One_Seven;
                                break;
                            case 9: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Eight_Fourteen;
                                break;
                            case 10: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Fifteen_TwentyOne;
                                break;
                            case 11: // >= 22 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.TwentyTwo;
                                break;
                            case 12: // Total
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Total;
                                break;
                            case 13: // Percent Unconfirmed
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.PercentUnconf;
                                break;
                            case 14: // This is % Favorable and we want to ignore any cell double clicks.
                                return;
                        }
                        break;
                    case 6: // Receipt Date vs Current Plan Date
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // Average
                                return;
                            case 3: // <= -22 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_TwentyTwo;
                                break;
                            case 4: // -(15 - 21) Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Fifteen_TwentyOne;
                                break;
                            case 5: // -(8 - 14) Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Eight_Fourteen;
                                break;
                            case 6: // -(1 - 7) Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_One_Seven;
                                break;
                            case 7: // 0 days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Zero;
                                break;
                            case 8: // 1 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.One_Seven;
                                break;
                            case 9: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Eight_Fourteen;
                                break;
                            case 10: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Fifteen_TwentyOne;
                                break;
                            case 11: // >= 22 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.TwentyTwo;
                                break;
                            case 12: // Total
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Total;
                                break;
                            case 13: // empy cell for % unconfirmed. This is not being recorded for this KPI
                            case 14: // This is % Favorable and we want to ignore any cell double clicks.
                                return;
                        }
                        break;
                    case 7: // Receipt Date vs Original Confirmation Date
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // Average
                                return;
                            case 3: // <= -22 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_TwentyTwo;
                                break;
                            case 4: // -(15 - 21) Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Fifteen_TwentyOne;
                                break;
                            case 5: // -(8 - 14) Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Eight_Fourteen;
                                break;
                            case 6: // -(1 - 7) Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_One_Seven;
                                break;
                            case 7: // 0 days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Zero;
                                break;
                            case 8: // 1 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.One_Seven;
                                break;
                            case 9: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Eight_Fourteen;
                                break;
                            case 10: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Fifteen_TwentyOne;
                                break;
                            case 11: // >= 22 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.TwentyTwo;
                                break;
                            case 12: // Total
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Total;
                                break;
                            case 13: // Percent Unconfirmed
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.PercentUnconf;
                                break;
                            case 14: // This is % Favorable and we want to ignore any cell double clicks.
                                return;
                        }
                        break;
                    case 8: // Receipt Date vs Current Confirmation Date
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // Average
                                return;
                            case 3: // <= -22 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_TwentyTwo;
                                break;
                            case 4: // -(15 - 21) Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Fifteen_TwentyOne;
                                break;
                            case 5: // -(8 - 14) Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_Eight_Fourteen;
                                break;
                            case 6: // -(1 - 7) Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Minus_One_Seven;
                                break;
                            case 7: // 0 days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Zero;
                                break;
                            case 8: // 1 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.One_Seven;
                                break;
                            case 9: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Eight_Fourteen;
                                break;
                            case 10: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Fifteen_TwentyOne;
                                break;
                            case 11: // >= 22 Days
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.TwentyTwo;
                                break;
                            case 12: // Total
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.Total;
                                break;
                            case 13: // Percent Unconfirmed
                                dv.DataLoader += KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable;
                                dv.ColumnTag = (int)TempThree.DataViews.PercentUnconf;
                                break;
                            case 14: // This is % Favorable and we want to ignore any cell double clicks.
                                return;
                        }
                        break;
                }
                dv.ShowDialog();
            }
        }







        /// <summary>
        /// Loads cells the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandlePlanTwoDataTableLoading(int rowIndex, int columnIndex)
        {
            using (DataViewer dv = new DataViewer())
            {
                switch(rowIndex)
                {
                    case 0: // Material Due (Original Planned Date)
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                            case 2: // Average
                                return;
                            case 3: // <= 0 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueOrigPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.LessThanZero;
                                break;
                            case 4: // 1 - 3 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueOrigPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.One_Three;
                                break;
                            case 5: // 4 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueOrigPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.Four_Seven;
                                break;
                            case 6: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueOrigPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.Eight_Fourteen;
                                break;
                            case 7: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueOrigPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifteen_TwentyOne;
                                break;
                            case 8: // 22 - 28 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueOrigPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 9: // 29 - 35 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueOrigPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.TwentyNine_ThirtyFive;
                                break;
                            case 10: // 36 - 42 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueOrigPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.ThirtySix_FourtyTwo;
                                break;
                            case 11: // 43 - 49 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueOrigPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.FourtyThree_FourtyNine;
                                break;
                            case 12: // 50 - 56 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueOrigPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifty_FiftySix;
                                break;
                            case 13: // 57+ Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueOrigPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.GreaterThanEqualFiftySeven;
                                break;
                            case 14: // Total
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueOrigPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.Total;
                                break;
                        }
                        break;
                    case 1: // Material Due (Final Planned Date)
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // Average
                                return;
                            case 3: // <= 0 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueFinalPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.LessThanZero;
                                break;
                            case 4: // 1 - 3 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueFinalPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.One_Three;
                                break;
                            case 5: // 4 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueFinalPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.Four_Seven;
                                break;
                            case 6: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueFinalPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.Eight_Fourteen;
                                break;
                            case 7: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueFinalPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifteen_TwentyOne;
                                break;
                            case 8: // 22 - 28 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueFinalPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 9: // 29 - 35 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueFinalPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.TwentyNine_ThirtyFive;
                                break;
                            case 10: // 36 - 42 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueFinalPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.ThirtySix_FourtyTwo;
                                break;
                            case 11: // 43 - 49 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueFinalPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.FourtyThree_FourtyNine;
                                break;
                            case 12: // 50 - 56 Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueFinalPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifty_FiftySix;
                                break;
                            case 13: // 57+ Days
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueFinalPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.GreaterThanEqualFiftySeven;
                                break;
                            case 14: // Total
                                dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueFinalPlanDate;
                                dv.ColumnTag = (int)TempFour.DataViews.Total;
                                break;
                        }
                        break;
                }
                dv.ShowDialog();
            }
        }






        /// <summary>
        /// Loads cells the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandlePurchTwoDataTableLoading(int rowIndex, int columnIndex)
        {
            using (DataViewer dv = new DataViewer())
            {
                switch (rowIndex)
                {
                    case 2: // PR 2nd Lvl Release Date vs PO Creation Date
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // Average
                                return;
                            case 3: // <= 0 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.LessThanZero;
                                break;
                            case 4: // 1 - 3 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.One_Three;
                                break;
                            case 5: // 4 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Four_Seven;
                                break;
                            case 6: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Eight_Fourteen;
                                break;
                            case 7: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifteen_TwentyOne;
                                break;
                            case 8: // 22 - 28 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 9: // 29 - 35 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.TwentyNine_ThirtyFive;
                                break;
                            case 10: // 36 - 42 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.ThirtySix_FourtyTwo;
                                break;
                            case 11: // 43 - 49 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.FourtyThree_FourtyNine;
                                break;
                            case 12: // 50 - 56 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifty_FiftySix;
                                break;
                            case 13: // 57+ Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.GreaterThanEqualFiftySeven;
                                break;
                            case 14: // Total
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Total;
                                break;
                        }
                        break;
                    case 3: // PO Creation Date vs PO Release Date
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // Average
                                return;
                            case 3: // <= 0 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.LessThanZero;
                                break;
                            case 4: // 1 - 3 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.One_Three;
                                break;
                            case 5: // 4 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Four_Seven;
                                break;
                            case 6: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Eight_Fourteen;
                                break;
                            case 7: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifteen_TwentyOne;
                                break;
                            case 8: // 22 - 28 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 9: // 29 - 35 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable;
                                    dv.ColumnTag = (int)TempFour.DataViews.TwentyNine_ThirtyFive;
                                break;
                            case 10: // 36 - 42 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.ThirtySix_FourtyTwo;
                                break;
                            case 11: // 43 - 49 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.FourtyThree_FourtyNine;
                                break;
                            case 12: // 50 - 56 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifty_FiftySix;
                                break;
                            case 13: // 57+ Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.GreaterThanEqualFiftySeven;
                                break;
                            case 14: // Total
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Total;
                                break;
                        }
                        break;
                    case 4: // PO Rleaese Date vs PO Confirmation Date
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // Average
                                return;
                            case 3: // <= 0 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.LessThanZero;
                                break;
                            case 4: // 1 - 3 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.One_Three;
                                break;
                            case 5: // 4 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Four_Seven;
                                break;
                            case 6: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Eight_Fourteen;
                                break;
                            case 7: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifteen_TwentyOne;
                                break;
                            case 8: // 22 - 28 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 9: // 29 - 35 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.TwentyNine_ThirtyFive;
                                break;
                            case 10: // 36 - 42 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.ThirtySix_FourtyTwo;
                                break;
                            case 11: // 43 - 49 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.FourtyThree_FourtyNine;
                                break;
                            case 12: // 50 - 56 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifty_FiftySix;
                                break;
                            case 13: // 57+ Days
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.GreaterThanEqualFiftySeven;
                                break;
                            case 14: // Total
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Total;
                                break;
                            case 15: // Percent Unconfirmed
                                dv.DataLoader += KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.PercentUnconf;
                                break;
                        }
                        break;
                }
                dv.ShowDialog();
            }
        }






        /// <summary>
        /// Loads cells the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandlePurchSubDataTableLoading(int rowIndex, int columnIndex)
        {
            using (DataViewer dv = new DataViewer())
            { 
                switch (rowIndex)
                {
                    case 5: // PR Release Date vs PO Release Date
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // Average
                                return;
                            case 3: // <= 0 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.LessThanZero;
                                break;
                            case 4: // 1 - 3 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.One_Three;
                                break;
                            case 5: // 4 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Four_Seven;
                                break;
                            case 6: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Eight_Fourteen;
                                break;
                            case 7: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifteen_TwentyOne;
                                break;
                            case 8: // 22 - 28 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 9: // 29 - 35 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.TwentyNine_ThirtyFive;
                                break;
                            case 10: // 36 - 42 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.ThirtySix_FourtyTwo;
                                break;
                            case 11: // 43 - 49 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.FourtyThree_FourtyNine;
                                break;
                            case 12: // 50 - 56 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifty_FiftySix;
                                break;
                            case 13: // 57+ Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.GreaterThanEqualFiftySeven;
                                break;
                            case 14: // Total
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Total;
                                break;
                        }
                        break;
                    case 6: // PO Creation Date vs Confirmation Entry Date
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // Average
                                return;
                            case 3: // <= 0 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPoCreationVsConfEntryDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.LessThanZero;
                                break;
                            case 4: // 1 - 3 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPoCreationVsConfEntryDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.One_Three;
                                break;
                            case 5: // 4 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPoCreationVsConfEntryDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Four_Seven;
                                break;
                            case 6: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPoCreationVsConfEntryDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Eight_Fourteen;
                                break;
                            case 7: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPoCreationVsConfEntryDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifteen_TwentyOne;
                                break;
                            case 8: // 22 - 28 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPoCreationVsConfEntryDateDataTable;
                                    dv.ColumnTag = (int)TempFour.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 9: // 29 - 35 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPoCreationVsConfEntryDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.TwentyNine_ThirtyFive;
                                break;
                            case 10: // 36 - 42 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPoCreationVsConfEntryDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.ThirtySix_FourtyTwo;
                                break;
                            case 11: // 43 - 49 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPoCreationVsConfEntryDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.FourtyThree_FourtyNine;
                                break;
                            case 12: // 50 - 56 Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPoCreationVsConfEntryDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifty_FiftySix;
                                break;
                            case 13: // 57+ Days
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPoCreationVsConfEntryDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.GreaterThanEqualFiftySeven;
                                break;
                            case 14: // Total
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPoCreationVsConfEntryDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Total;
                                break;
                            case 15: // Percent Unconfirmed
                                dv.DataLoader += KpiDataTableLoader.PurchSub.LoadPoCreationVsConfEntryDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.PercentUnconf;
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
                    case 7: // Pr Release Date to Confirmation Entry Date
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // Average
                                return;
                            case 3: // <= 0 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.LessThanZero;
                                break;
                            case 4: // 1 - 3 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.One_Three;
                                break;
                            case 5: // 4 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Four_Seven;
                                break;
                            case 6: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Eight_Fourteen;
                                break;
                            case 7: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifteen_TwentyOne;
                                break;
                            case 8: // 22 - 28 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 9: // 29 - 35 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.TwentyNine_ThirtyFive;
                                break;
                            case 10: // 36 - 42 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.ThirtySix_FourtyTwo;
                                break;
                            case 11: // 43 - 49 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.FourtyThree_FourtyNine;
                                break;
                            case 12: // 50 - 56 Days
                                dv.DataLoader += KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifty_FiftySix;
                                break;
                            case 13: // 57+ Days
                                dv.DataLoader += KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.GreaterThanEqualFiftySeven;
                                break;
                            case 14: // Total
                                dv.DataLoader += KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Total;
                                break;
                            case 15: // Percent Unconfirmed
                                dv.DataLoader += KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.PercentUnconf;
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
        private void HandlePurchPlanDataTableLoading(int rowIndex, int columnIndex)
        {
            using (DataViewer dv = new DataViewer())
            { 
                switch (rowIndex)
                {
                    case 8: // PO Release vs PR Delivery Date
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // Average
                                return;
                            case 3: // <= 0 Days
                                dv.DataLoader += KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.LessThanZero;
                                break;
                            case 4: // 1 - 3 Days
                                dv.DataLoader += KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.One_Three;
                                break;
                            case 5: // 4 - 7 Days
                                dv.DataLoader += KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Four_Seven;
                                break;
                            case 6: // 8 - 14 Days
                                dv.DataLoader += KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Eight_Fourteen;
                                break;
                            case 7: // 15 - 21 Days
                                dv.DataLoader += KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifteen_TwentyOne;
                                break;
                            case 8: // 22 - 28 Days
                                dv.DataLoader += KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 9: // 29 - 35 Days
                                dv.DataLoader += KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.TwentyNine_ThirtyFive;
                                break;
                            case 10: // 36 - 42 Days
                                dv.DataLoader += KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.ThirtySix_FourtyTwo;
                                break;
                            case 11: // 43 - 49 Days
                                dv.DataLoader += KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.FourtyThree_FourtyNine;
                                break;
                            case 12: // 50 - 56 Days
                                dv.DataLoader += KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Fifty_FiftySix;
                                break;
                            case 13: // 57+ Days
                                dv.DataLoader += KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.GreaterThanEqualFiftySeven;
                                break;
                            case 14: // Total
                                dv.DataLoader += KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable;
                                dv.ColumnTag = (int)TempFour.DataViews.Total;
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
        private void HandleOtherDataTableLoading(int rowIndex, int columnIndex)
        {
            using (DataViewer dv = new DataViewer())
            { 
                switch (rowIndex)
                {
                    case 0: // PRs Created
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // total value. The user can just click total to view all the data.
                                return;
                            case 3: // >= 0 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsCreated;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanZeroWeeks;
                                break;
                            case 4: // >= -1 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsCreated;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusOneWeeks;
                                break;
                            case 5: // >= -2 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsCreated;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusTwoWeeks;
                                break;
                            case 6: // >= -3 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsCreated;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusThreeWeeks;
                                break;
                            case 7: // >= -4 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsCreated;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusFourWeeks;
                                break;
                            case 8: // >= -5 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsCreated;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusFiveWeeks;
                                break;
                            case 9: // >= -6 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsCreated;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusSixWeeks;
                                break;
                            case 10: // >= -7 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsCreated;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusSevenWeeks;
                                break;
                            case 11: // >= -8 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsCreated;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusEightWeeks;
                                break;
                            case 12: // < -8 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsCreated;
                                dv.ColumnTag = (int)TempFive.DataViews.LessThanEightWeeks;
                                break;
                            case 13: // Total
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsCreated;
                                dv.ColumnTag = (int)TempFive.DataViews.Total;
                                break;
                        }
                        break;
                    case 1: // PRs Released
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // total value. The user can just click total to view all the data.
                                return;
                            case 3: // >= 0 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsReleased;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanZeroWeeks;
                                break;
                            case 4: // >= -1 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsReleased;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusOneWeeks;
                                break;
                            case 5: // >= -2 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsReleased;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusTwoWeeks;
                                break;
                            case 6: // >= -3 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsReleased;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusThreeWeeks;
                                break;
                            case 7: // >= -4 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsReleased;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusFourWeeks;
                                break;
                            case 8: // >= -5 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsReleased;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusFiveWeeks;
                                break;
                            case 9: // >= -6 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsReleased;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusSixWeeks;
                                break;
                            case 10: // >= -7 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsReleased;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusSevenWeeks;
                                break;
                            case 11: // >= -8 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsReleased;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusEightWeeks;
                                break;
                            case 12: // < -8 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsReleased;
                                dv.ColumnTag = (int)TempFive.DataViews.LessThanEightWeeks;
                                break;
                            case 13: // Total
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrsReleased;
                                dv.ColumnTag = (int)TempFive.DataViews.Total;
                                break;
                        }
                        break;
                    case 2: // Total Spend
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // total value. The user can just click total to view all the data.
                                return;
                            case 3: // >= 0 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadTotalSpend;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanZeroWeeks;
                                break;
                            case 4: // >= -1 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadTotalSpend;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusOneWeeks;
                                break;
                            case 5: // >= -2 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadTotalSpend;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusTwoWeeks;
                                break;
                            case 6: // >= -3 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadTotalSpend;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusThreeWeeks;
                                break;
                            case 7: // >= -4 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadTotalSpend;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusFourWeeks;
                                break;
                            case 8: // >= -5 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadTotalSpend;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusFiveWeeks;
                                break;
                            case 9: // >= -6 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadTotalSpend;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusSixWeeks;
                                break;
                            case 10: // >= -7 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadTotalSpend;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusSevenWeeks;
                                break;
                            case 11: // >= -8 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadTotalSpend;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusEightWeeks;
                                break;
                            case 12: // < -8 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadTotalSpend;
                                dv.ColumnTag = (int)TempFive.DataViews.LessThanEightWeeks;
                                break;
                            case 13: // Total
                                dv.DataLoader += KpiDataTableLoader.Other.LoadTotalSpend;
                                dv.ColumnTag = (int)TempFive.DataViews.Total;
                                break;
                        }
                        break;
                    case 3: // PR Value vs PO Value
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // total value. The user can just click total to view all the data.
                                return;
                            case 3: // >= 0 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrVsPoValue;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanZeroWeeks;
                                break;
                            case 4: // >= -1 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrVsPoValue;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusOneWeeks;
                                break;
                            case 5: // >= -2 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrVsPoValue;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusTwoWeeks;
                                break;
                            case 6: // >= -3 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrVsPoValue;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusThreeWeeks;
                                break;
                            case 7: // >= -4 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrVsPoValue;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusFourWeeks;
                                break;
                            case 8: // >= -5 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrVsPoValue;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusFiveWeeks;
                                break;
                            case 9: // >= -6 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrVsPoValue;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusSixWeeks;
                                break;
                            case 10: // >= -7 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrVsPoValue;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusSevenWeeks;
                                break;
                            case 11: // >= -8 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrVsPoValue;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusEightWeeks;
                                break;
                            case 12: // < -8 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrVsPoValue;
                                dv.ColumnTag = (int)TempFive.DataViews.LessThanEightWeeks;
                                break;
                            case 13: // Total
                                dv.DataLoader += KpiDataTableLoader.Other.LoadPrVsPoValue;
                                dv.ColumnTag = (int)TempFive.DataViews.Total;
                                break;
                        }
                        break;
                    case 4: // Hot Job PRs 
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
                            case 2: // total value. The user can just click total to view all the data.
                                return;
                            case 3: // >= 0 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadHotJobPrs;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanZeroWeeks;
                                break;
                            case 4: // >= -1 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadHotJobPrs;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusOneWeeks;
                                break;
                            case 5: // >= -2 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadHotJobPrs;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusTwoWeeks;
                                break;
                            case 6: // >= -3 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadHotJobPrs;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusThreeWeeks;
                                break;
                            case 7: // >= -4 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadHotJobPrs;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusFourWeeks;
                                break;
                            case 8: // >= -5 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadHotJobPrs;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusFiveWeeks;
                                break;
                            case 9: // >= -6 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadHotJobPrs;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusSixWeeks;
                                break;
                            case 10: // >= -7 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadHotJobPrs;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusSevenWeeks;
                                break;
                            case 11: // >= -8 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadHotJobPrs;
                                dv.ColumnTag = (int)TempFive.DataViews.GreaterThanMinusEightWeeks;
                                break;
                            case 12: // < -8 Weeks
                                dv.DataLoader += KpiDataTableLoader.Other.LoadHotJobPrs;
                                dv.ColumnTag = (int)TempFive.DataViews.LessThanEightWeeks;
                                break;
                            case 13: // Total
                                dv.DataLoader += KpiDataTableLoader.Other.LoadHotJobPrs;
                                dv.ColumnTag = (int)TempFive.DataViews.Total;
                                break;
                        }
                        break;
                }
                dv.ShowDialog();
            }
        }
    }
}
