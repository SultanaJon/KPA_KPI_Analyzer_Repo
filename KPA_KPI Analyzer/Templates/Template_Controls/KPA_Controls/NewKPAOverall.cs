using KPA_KPI_Analyzer.DataLoading.KPA_Data.DataTableLoader;
using KPA_KPI_Analyzer.KPA_KPI_Overall;
using KPA_KPI_Analyzer.KPA_KPI_Overall.KPA_Sections;
using KPA_KPI_Analyzer.Values;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPA_Controls
{
    public partial class NewKPAOverall : UserControl
    {
        private Overall data;

        public NewKPAOverall(Overall _data)
        {
            InitializeComponent();
            ApplyDataGridStyles();
            data = _data;
            Globals.CurrPerformance = "KPA";

            if (Globals.SelectedCountry == DataImporter.Access.AccessInfo.MainTables.US_PRPO)
                Globals.CurrCountry = Globals.countries[(int)Globals.Countries.UnitedStates];
            else
                Globals.CurrCountry = Globals.countries[(int)Globals.Countries.Mexico];
        }



        public enum TempOneDataGridHeaderNames
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
            Totals
        }


        

        /// <summary>
        /// 
        /// </summary>
        public enum TempTwoDataGridHeaderNames
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
            Totals
        }






        /// <summary>
        /// Sets the color of the DataGridView Header cells only.
        /// </summary>
        private void ApplyDataGridStyles()
        {
            TemplateOneDataGrid.Columns[(int)TempOneDataGridHeaderNames.TimeSpanOne].HeaderCell.Style.BackColor = Color.FromArgb(123, 204, 242);
            TemplateOneDataGrid.Columns[(int)TempOneDataGridHeaderNames.TimeSpanOne].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateOneDataGrid.Columns[(int)TempOneDataGridHeaderNames.TimeSpanTwo].HeaderCell.Style.BackColor = Color.FromArgb(96, 189, 227);
            TemplateOneDataGrid.Columns[(int)TempOneDataGridHeaderNames.TimeSpanTwo].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateOneDataGrid.Columns[(int)TempOneDataGridHeaderNames.TimeSpanThree].HeaderCell.Style.BackColor = Color.FromArgb(79, 179, 208);
            TemplateOneDataGrid.Columns[(int)TempOneDataGridHeaderNames.TimeSpanThree].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateOneDataGrid.Columns[(int)TempOneDataGridHeaderNames.TimeSpanFour].HeaderCell.Style.BackColor = Color.FromArgb(62, 168, 186);
            TemplateOneDataGrid.Columns[(int)TempOneDataGridHeaderNames.TimeSpanFive].HeaderCell.Style.BackColor = Color.FromArgb(50, 150, 150);
            TemplateOneDataGrid.Columns[(int)TempOneDataGridHeaderNames.TimeSpanSix].HeaderCell.Style.BackColor = Color.FromArgb(41, 132, 137);
            TemplateOneDataGrid.Columns[(int)TempOneDataGridHeaderNames.TimeSpanSeven].HeaderCell.Style.BackColor = Color.FromArgb(31, 109, 109);
            TemplateOneDataGrid.Columns[(int)TempOneDataGridHeaderNames.Average].HeaderCell.Style.BackColor = Color.FromArgb(230, 184, 182);
            TemplateOneDataGrid.Columns[(int)TempOneDataGridHeaderNames.Totals].HeaderCell.Style.BackColor = Color.FromArgb(218, 150, 148);


            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.Average].HeaderCell.Style.BackColor = Color.FromArgb(141, 180, 226);
            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.TimeSpanOne].HeaderCell.Style.BackColor = Color.FromArgb(155, 187, 89);
            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.TimeSpanTwo].HeaderCell.Style.BackColor = Color.FromArgb(196, 215, 155);
            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.TimeSpanTwo].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.TimeSpanThree].HeaderCell.Style.BackColor = Color.FromArgb(216, 228, 188);
            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.TimeSpanThree].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.TimeSpanFour].HeaderCell.Style.BackColor = Color.FromArgb(235, 241, 221);
            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.TimeSpanFour].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.TimeSpanFive].HeaderCell.Style.BackColor = Color.FromArgb(235, 241, 221);
            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.TimeSpanFive].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.TimeSpanSix].HeaderCell.Style.BackColor = Color.FromArgb(253, 233, 217);
            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.TimeSpanSix].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.TimeSpanSeven].HeaderCell.Style.BackColor = Color.FromArgb(252, 213, 180);
            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.TimeSpanSeven].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.TimeSpanEight].HeaderCell.Style.BackColor = Color.FromArgb(250, 191, 142);
            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.TimeSpanEight].HeaderCell.Style.ForeColor = Color.FromArgb(36, 41, 46);
            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.TimeSpanNine].HeaderCell.Style.BackColor = Color.FromArgb(151, 71, 6);
            TemplateTwoDataGrid.Columns[(int)TempTwoDataGridHeaderNames.Totals].HeaderCell.Style.BackColor = Color.FromArgb(218, 150, 148);
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        bool IsTheSameCellValueGridOne(int column, int row)
        {
            DataGridViewCell cell1 = TemplateOneDataGrid[column, row];
            DataGridViewCell cell2 = TemplateOneDataGrid[column, row - 1];
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
            DataGridViewCell cell1 = TemplateTwoDataGrid[column, row];
            DataGridViewCell cell2 = TemplateTwoDataGrid[column, row - 1];
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





        // Load all the function that load all the data into the datagridviews.
        private void NewKPAOverall_Load(object sender, EventArgs e)
        {
            LoadPlan();
            LoadPurch();
            LoadPurchSub();
            LoadPurchTotal();
            LoadPurchPlanTotal();
            LoadFollowUp();
            LoadCancellations();
            LoadNCRs();
            LoadHotJobs();
            LoadExcessStockStock();
            LoadExcessStockOpenOrders();
            LoadCurrentPlanVsActual();

            TemplateOneDataGrid.AutoGenerateColumns = false;
            TemplateTwoDataGrid.AutoGenerateColumns = false;
        }




        /// <summary>
        /// Loads all of the KPA Plan data into the datagridview.
        /// </summary>
        private void LoadPlan()
        {
            string[] row = { data.kpa.plan.Name, data.kpa.plan.categoryNames[(int)Plan.CategorNames.PlannedOrderAging], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateOneDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpa.plan.Name,
                data.kpa.plan.categoryNames[(int)Plan.CategorNames.PrsAgingNotReleased],
                string.Format("{0:n0}", data.kpa.plan.prsAgingNotRel.data.LessThanZero),
                string.Format("{0:n0}", data.kpa.plan.prsAgingNotRel.data.One_Three),
                string.Format("{0:n0}", data.kpa.plan.prsAgingNotRel.data.Four_Seven),
                string.Format("{0:n0}", data.kpa.plan.prsAgingNotRel.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpa.plan.prsAgingNotRel.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpa.plan.prsAgingNotRel.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpa.plan.prsAgingNotRel.data.TwentyNinePlus),
                string.Format("{0:n}", data.kpa.plan.prsAgingNotRel.data.Average),
                string.Format("{0:n0}", data.kpa.plan.prsAgingNotRel.data.Total)
            };
            TemplateOneDataGrid.Rows.Add(row);


            row = new string[]{
                data.kpa.plan.Name,
                data.kpa.plan.categoryNames[(int)Plan.CategorNames.MaterialDue],
                string.Format("{0:n0}", data.kpa.plan.matDueDate.data.LessThanZero),
                string.Format("{0:n0}", data.kpa.plan.matDueDate.data.One_Three),
                string.Format("{0:n0}", data.kpa.plan.matDueDate.data.Four_Seven),
                string.Format("{0:n0}", data.kpa.plan.matDueDate.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpa.plan.matDueDate.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpa.plan.matDueDate.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpa.plan.matDueDate.data.TwentyNinePlus),
                string.Format("{0:n}", data.kpa.plan.matDueDate.data.Average),
                string.Format("{0:n0}", data.kpa.plan.matDueDate.data.Total)
            };
            TemplateOneDataGrid.Rows.Add(row);
        }



        /// <summary>
        /// Loads all of the KPA Purch data into the datagridview.
        /// </summary>
        private void LoadPurch()
        {
            string[] row = {
                data.kpa.purch.Name,
                data.kpa.purch.categoryNames[(int)Purch.CategorNames.PRsAgingReleased],
                string.Format("{0:n0}", data.kpa.purch.prsAgingRel.data.LessThanZero),
                string.Format("{0:n0}", data.kpa.purch.prsAgingRel.data.One_Three),
                string.Format("{0:n0}", data.kpa.purch.prsAgingRel.data.Four_Seven),
                string.Format("{0:n0}", data.kpa.purch.prsAgingRel.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpa.purch.prsAgingRel.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpa.purch.prsAgingRel.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpa.purch.prsAgingRel.data.TwentyNinePlus),
                string.Format("{0:n}", data.kpa.purch.prsAgingRel.data.Average),
                string.Format("{0:n0}", data.kpa.purch.prsAgingRel.data.Total)
            };
            TemplateOneDataGrid.Rows.Add(row);


            row = new string[]{
                data.kpa.purch.Name,
                data.kpa.purch.categoryNames[(int)Purch.CategorNames.POFirstRelease],
                string.Format("{0:n0}", data.kpa.purch.poFirstRel.data.LessThanZero),
                string.Format("{0:n0}", data.kpa.purch.poFirstRel.data.One_Three),
                string.Format("{0:n0}", data.kpa.purch.poFirstRel.data.Four_Seven),
                string.Format("{0:n0}", data.kpa.purch.poFirstRel.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpa.purch.poFirstRel.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpa.purch.poFirstRel.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpa.purch.poFirstRel.data.TwentyNinePlus),
                string.Format("{0:n}", data.kpa.purch.poFirstRel.data.Average),
                string.Format("{0:n0}", data.kpa.purch.poFirstRel.data.Total)
            };
            TemplateOneDataGrid.Rows.Add(row);


            row = new string[]{
                data.kpa.purch.Name,
                data.kpa.purch.categoryNames[(int)Purch.CategorNames.POPrevRelease],
                string.Format("{0:n0}", data.kpa.purch.poPrevRel.data.LessThanZero),
                string.Format("{0:n0}", data.kpa.purch.poPrevRel.data.One_Three),
                string.Format("{0:n0}", data.kpa.purch.poPrevRel.data.Four_Seven),
                string.Format("{0:n0}", data.kpa.purch.poPrevRel.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpa.purch.poPrevRel.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpa.purch.poPrevRel.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpa.purch.poPrevRel.data.TwentyNinePlus),
                string.Format("{0:n}", data.kpa.purch.poPrevRel.data.Average),
                string.Format("{0:n0}", data.kpa.purch.poPrevRel.data.Total)
            };
            TemplateOneDataGrid.Rows.Add(row);


            row = new string[]{
                data.kpa.purch.Name,
                data.kpa.purch.categoryNames[(int)Purch.CategorNames.NoConfirmation],
                string.Format("{0:n0}", data.kpa.purch.noConfirmation.data.LessThanZero),
                string.Format("{0:n0}", data.kpa.purch.noConfirmation.data.One_Three),
                string.Format("{0:n0}", data.kpa.purch.noConfirmation.data.Four_Seven),
                string.Format("{0:n0}", data.kpa.purch.noConfirmation.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpa.purch.noConfirmation.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpa.purch.noConfirmation.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpa.purch.noConfirmation.data.TwentyNinePlus),
                string.Format("{0:n}", data.kpa.purch.noConfirmation.data.Average),
                string.Format("{0:n0}", data.kpa.purch.noConfirmation.data.Total)
            };
            TemplateOneDataGrid.Rows.Add(row);
        }



        /// <summary>
        /// Loads all of the KPA Purch Sub data into the datagridview.
        /// </summary>
        private void LoadPurchSub()
        {
            string[] row = {
                data.kpa.purchSub.Name,
                data.kpa.purchSub.categoryNames[(int)Purch_Sub.CategorNames.PrReleasePoRelease],
                string.Format("{0:n0}", data.kpa.purchSub.prRelToPORel.data.LessThanZero),
                string.Format("{0:n0}", data.kpa.purchSub.prRelToPORel.data.One_Three),
                string.Format("{0:n0}", data.kpa.purchSub.prRelToPORel.data.Four_Seven),
                string.Format("{0:n0}", data.kpa.purchSub.prRelToPORel.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpa.purchSub.prRelToPORel.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpa.purchSub.prRelToPORel.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpa.purchSub.prRelToPORel.data.TwentyNinePlus),
                string.Format("{0:n}", data.kpa.purchSub.prRelToPORel.data.Average),
                string.Format("{0:n0}", data.kpa.purchSub.prRelToPORel.data.Total)
            };
            TemplateOneDataGrid.Rows.Add(row);


            row = new string[]{
                data.kpa.purchSub.Name,
                data.kpa.purchSub.categoryNames[(int)Purch_Sub.CategorNames.PoCreationConfirmationEntry],
                string.Format("{0:n0}", data.kpa.purchSub.POCreatToConfEntry.data.LessThanZero),
                string.Format("{0:n0}", data.kpa.purchSub.POCreatToConfEntry.data.One_Three),
                string.Format("{0:n0}", data.kpa.purchSub.POCreatToConfEntry.data.Four_Seven),
                string.Format("{0:n0}", data.kpa.purchSub.POCreatToConfEntry.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpa.purchSub.POCreatToConfEntry.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpa.purchSub.POCreatToConfEntry.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpa.purchSub.POCreatToConfEntry.data.TwentyNinePlus),
                string.Format("{0:n}", data.kpa.purchSub.POCreatToConfEntry.data.Average),
                string.Format("{0:n0}", data.kpa.purchSub.POCreatToConfEntry.data.Total)
            };
            TemplateOneDataGrid.Rows.Add(row);
        }


        /// <summary>
        /// Loads all of the KPA Purch Total data into the datagridview.
        /// </summary>
        private void LoadPurchTotal()
        {
            string[] row = {
                data.kpa.purchTotal.Name,
                data.kpa.purchTotal.categoryNames[(int)Purch_Total.CategorNames.PrReleaseConfEntry],
                string.Format("{0:n0}", data.kpa.purchTotal.prRelConfEntry.data.LessThanZero),
                string.Format("{0:n0}", data.kpa.purchTotal.prRelConfEntry.data.One_Three),
                string.Format("{0:n0}", data.kpa.purchTotal.prRelConfEntry.data.Four_Seven),
                string.Format("{0:n0}", data.kpa.purchTotal.prRelConfEntry.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpa.purchTotal.prRelConfEntry.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpa.purchTotal.prRelConfEntry.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpa.purchTotal.prRelConfEntry.data.TwentyNinePlus),
                string.Format("{0:n}", data.kpa.purchTotal.prRelConfEntry.data.Average),
                string.Format("{0:n0}", data.kpa.purchTotal.prRelConfEntry.data.Total)
            };
            TemplateOneDataGrid.Rows.Add(row);
        }

        /// <summary>
        /// Loads all of the KPA Purch Plan data into the datagridview.
        /// </summary>
        private void LoadPurchPlanTotal()
        {
            string[] row = { data.kpa.purchPlanTotal.Name, data.kpa.purchPlanTotal.categoryNames[(int)Purch_Plan_Total.CategorNames.PurchPlanTotalAging], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateOneDataGrid.Rows.Add(row);
        }

        /// <summary>
        /// Loads all of the KPA Follow Up data into the datagridview.
        /// </summary>
        private void LoadFollowUp()
        {
            string[] row = {
                data.kpa.followUp.Name,
                data.kpa.followUp.categoryNames[(int)Follow_Up.CategorNames.ConfirmedDateVsPlanDate],
                string.Format("{0:n0}", data.kpa.followUp.confDateVsPlanDate.data.LessThanZero),
                string.Format("{0:n0}", data.kpa.followUp.confDateVsPlanDate.data.One_Three),
                string.Format("{0:n0}", data.kpa.followUp.confDateVsPlanDate.data.Four_Seven),
                string.Format("{0:n0}", data.kpa.followUp.confDateVsPlanDate.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpa.followUp.confDateVsPlanDate.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpa.followUp.confDateVsPlanDate.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpa.followUp.confDateVsPlanDate.data.TwentyNinePlus),
                string.Format("{0:n}", data.kpa.followUp.confDateVsPlanDate.data.Average),
                string.Format("{0:n0}", data.kpa.followUp.confDateVsPlanDate.data.Total)
            };
            TemplateOneDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpa.followUp.Name,
                data.kpa.followUp.categoryNames[(int)Follow_Up.CategorNames.ConfirmedDateForUpcomingDel],
                string.Format("{0:n0}", data.kpa.followUp.ConfDateForUpcomingDel.data.LessThanZero),
                string.Format("{0:n0}", data.kpa.followUp.ConfDateForUpcomingDel.data.One_Three),
                string.Format("{0:n0}", data.kpa.followUp.ConfDateForUpcomingDel.data.Four_Seven),
                string.Format("{0:n0}", data.kpa.followUp.ConfDateForUpcomingDel.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpa.followUp.ConfDateForUpcomingDel.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpa.followUp.ConfDateForUpcomingDel.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpa.followUp.ConfDateForUpcomingDel.data.TwentyNinePlus),
                string.Format("{0:n}", data.kpa.followUp.ConfDateForUpcomingDel.data.Average),
                string.Format("{0:n0}", data.kpa.followUp.ConfDateForUpcomingDel.data.Total)
            };
            TemplateOneDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpa.followUp.Name,
                data.kpa.followUp.categoryNames[(int)Follow_Up.CategorNames.LateToConfirmed],
                string.Format("{0:n0}", data.kpa.followUp.LateToConfDate.data.LessThanZero),
                string.Format("{0:n0}", data.kpa.followUp.LateToConfDate.data.One_Three),
                string.Format("{0:n0}", data.kpa.followUp.LateToConfDate.data.Four_Seven),
                string.Format("{0:n0}", data.kpa.followUp.LateToConfDate.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpa.followUp.LateToConfDate.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpa.followUp.LateToConfDate.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpa.followUp.LateToConfDate.data.TwentyNinePlus),
                string.Format("{0:n}", data.kpa.followUp.LateToConfDate.data.Average),
                string.Format("{0:n0}", data.kpa.followUp.LateToConfDate.data.Total)
            };
            TemplateOneDataGrid.Rows.Add(row);
        }

        /// <summary>
        /// Loads all of the KPA Cancellations data into the datagridview.
        /// </summary>
        private void LoadCancellations()
        {
            string[] row = { data.kpa.cancellations.Name, data.kpa.cancellations.categoryNames[(int)Cancellations.CategorNames.CancellationCount], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateOneDataGrid.Rows.Add(row);
            row = new string[]{ data.kpa.cancellations.Name, data.kpa.cancellations.categoryNames[(int)Cancellations.CategorNames.CancellationValue], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateOneDataGrid.Rows.Add(row);
        }

        /// <summary>
        /// Loads all of the NCRs Plan data into the datagridview.
        /// </summary>
        private void LoadNCRs()
        {
            string[] row = { data.kpa.ncrs.Name, data.kpa.ncrs.categoryNames[(int)NCRs.CategorNames.OpenNCRs], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateOneDataGrid.Rows.Add(row);
            row = new string[]{ data.kpa.ncrs.Name, data.kpa.ncrs.categoryNames[(int)NCRs.CategorNames.OpenNCRValues], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateOneDataGrid.Rows.Add(row);
        }

        /// <summary>
        /// Loads all of the KPA Hot Jobs data into the datagridview.
        /// </summary>
        private void LoadHotJobs()
        {
            string[] row = {
                data.kpa.hotJobs.Name,
                data.kpa.hotJobs.categoryNames[(int)Hot_Jobs.CategorNames.PrsNotOnPo],
                string.Format("{0:n0}", data.kpa.hotJobs.prsNotOnPO.data.LessThanZero),
                string.Format("{0:n0}", data.kpa.hotJobs.prsNotOnPO.data.One_Three),
                string.Format("{0:n0}", data.kpa.hotJobs.prsNotOnPO.data.Four_Seven),
                string.Format("{0:n0}", data.kpa.hotJobs.prsNotOnPO.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpa.hotJobs.prsNotOnPO.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpa.hotJobs.prsNotOnPO.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpa.hotJobs.prsNotOnPO.data.TwentyNinePlus),
                string.Format("{0:n}", data.kpa.hotJobs.prsNotOnPO.data.Average),
                string.Format("{0:n0}", data.kpa.hotJobs.prsNotOnPO.data.Total)
            };
            TemplateOneDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpa.hotJobs.Name,
                data.kpa.hotJobs.categoryNames[(int)Hot_Jobs.CategorNames.NoConfirmation],
                string.Format("{0:n0}", data.kpa.hotJobs.noConfirmation.data.LessThanZero),
                string.Format("{0:n0}", data.kpa.hotJobs.noConfirmation.data.One_Three),
                string.Format("{0:n0}", data.kpa.hotJobs.noConfirmation.data.Four_Seven),
                string.Format("{0:n0}", data.kpa.hotJobs.noConfirmation.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpa.hotJobs.noConfirmation.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpa.hotJobs.noConfirmation.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpa.hotJobs.noConfirmation.data.TwentyNinePlus),
                string.Format("{0:n}", data.kpa.hotJobs.noConfirmation.data.Average),
                string.Format("{0:n0}", data.kpa.hotJobs.noConfirmation.data.Total)
            };
            TemplateOneDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpa.hotJobs.Name,
                data.kpa.hotJobs.categoryNames[(int)Hot_Jobs.CategorNames.LateToConfirmed],
                string.Format("{0:n0}", data.kpa.hotJobs.lateToConfirmed.data.LessThanZero),
                string.Format("{0:n0}", data.kpa.hotJobs.lateToConfirmed.data.One_Three),
                string.Format("{0:n0}", data.kpa.hotJobs.lateToConfirmed.data.Four_Seven),
                string.Format("{0:n0}", data.kpa.hotJobs.lateToConfirmed.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpa.hotJobs.lateToConfirmed.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpa.hotJobs.lateToConfirmed.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpa.hotJobs.lateToConfirmed.data.TwentyNinePlus),
                string.Format("{0:n}", data.kpa.hotJobs.lateToConfirmed.data.Average),
                string.Format("{0:n0}", data.kpa.hotJobs.lateToConfirmed.data.Total)
            };
            TemplateOneDataGrid.Rows.Add(row);
        }


        /// <summary>
        /// Loads all of the KPA Excess Stock - Stock data into the datagridview.
        /// </summary>
        private void LoadExcessStockStock()
        {
            string[] row = { data.kpa.excessStockStock.Name, data.kpa.excessStockStock.categoryNames[(int)Excess_Stock_Stock.CategorNames.PrsAgingNotReleased], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateOneDataGrid.Rows.Add(row);
            row = new string[]{ data.kpa.excessStockStock.Name, data.kpa.excessStockStock.categoryNames[(int)Excess_Stock_Stock.CategorNames.PrsAgingReleased], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateOneDataGrid.Rows.Add(row);
            row = new string[] { data.kpa.excessStockStock.Name, data.kpa.excessStockStock.categoryNames[(int)Excess_Stock_Stock.CategorNames.PoCreationToConfirmationEntry], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateOneDataGrid.Rows.Add(row);
            row = new string[]{ data.kpa.excessStockStock.Name, data.kpa.excessStockStock.categoryNames[(int)Excess_Stock_Stock.CategorNames.ConfirmedVsPlanDate], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateOneDataGrid.Rows.Add(row);
            row = new string[]{ data.kpa.excessStockStock.Name, data.kpa.excessStockStock.categoryNames[(int)Excess_Stock_Stock.CategorNames.ConfirmedDateForUpcomingDeliveries], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateOneDataGrid.Rows.Add(row);
        }

        /// <summary>
        /// Loads all of the KPA Excess Stock - Open Orders data into the datagridview.
        /// </summary>
        private void LoadExcessStockOpenOrders()
        {
            string[] row = { data.kpa.excessStockOpenOrders.Name, data.kpa.excessStockOpenOrders.categoryNames[(int)Excess_Stock_Open_Order.CategorNames.PrsAgingNotReleased], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateOneDataGrid.Rows.Add(row);
            row = new string[]{ data.kpa.excessStockOpenOrders.Name, data.kpa.excessStockOpenOrders.categoryNames[(int)Excess_Stock_Open_Order.CategorNames.PrsAgingReleased], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateOneDataGrid.Rows.Add(row);
            row = new string[]{ data.kpa.excessStockOpenOrders.Name, data.kpa.excessStockOpenOrders.categoryNames[(int)Excess_Stock_Open_Order.CategorNames.PoCreationToConfirmationEntry], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateOneDataGrid.Rows.Add(row);
            row = new string[]{ data.kpa.excessStockOpenOrders.Name, data.kpa.excessStockOpenOrders.categoryNames[(int)Excess_Stock_Open_Order.CategorNames.ConfirmedVsPlanDate], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateOneDataGrid.Rows.Add(row);
            row = new string[]{ data.kpa.excessStockOpenOrders.Name, data.kpa.excessStockOpenOrders.categoryNames[(int)Excess_Stock_Open_Order.CategorNames.ConfirmedDateForUpcomingDeliveries], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateOneDataGrid.Rows.Add(row);
        }


        /// <summary>
        /// Loads all of the KPA Current Plan vs Actual data into the datagridview.
        /// </summary>
        private void LoadCurrentPlanVsActual()
        {
            string[] row = {
                data.kpa.currPlanVsActual.Name,
                data.kpa.currPlanVsActual.categoryNames[(int)Current_Plan_vs_Actual.CategorNames.CurrPlanDateVsCurrConfDate],
                string.Format("{0:n}", data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.Average),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanMinusThree),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusThree),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusTwo),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusOne),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.ZeroWeeks),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualOneWeek),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualTwoWeeks),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualThreeWeeks),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanThreeWeeks),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.Total)
            };
            TemplateTwoDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpa.currPlanVsActual.Name,
                data.kpa.currPlanVsActual.categoryNames[(int)Current_Plan_vs_Actual.CategorNames.CurrPlanDateVsCurrConfDate_HJsOnly],
                string.Format("{0:n}", data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.Average),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanMinusThree),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusThree),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusTwo),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusOne),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.ZeroWeeks),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualOneWeek),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualTwoWeeks),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualThreeWeeks),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanThreeWeeks),
                string.Format("{0:n0}", data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.Total)
            };
            TemplateTwoDataGrid.Rows.Add(row);
        }



        


        /// <summary>
        /// Handles the event of when a cell in the Template One DataGridView is double clicked. The corresponding data will be loaded
        /// into the data viewer object.
        /// </summary>
        /// <param name="sender">the cell</param>
        /// <param name="e">the cell double click event</param>
        private void TemplateOneDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (TemplateOneDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == "0" || TemplateOneDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("There is no data in this cell.", "Data Timespan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                switch (e.RowIndex)
                {
                    case 0: // 0 - 3 = Plan
                        break; // not yet created
                    case 1:
                        Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.Plan];
                        Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.Plan][(int)Globals.KPA_Categories.Plan.PRsAgingNotRel];
                        HandlePlanDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 2:
                        Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.Plan];
                        Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.Plan][(int)Globals.KPA_Categories.Plan.MaterialDue];
                        HandlePlanDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 3: // 3 - 6 = Purch
                        Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.Purch];
                        Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.Purch][(int)Globals.KPA_Categories.Purch.PRsAgingRel];
                        HandlePurchDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 4:
                        Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.Purch];
                        Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.Purch][(int)Globals.KPA_Categories.Purch.POFirstRelease];
                        HandlePurchDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 5:
                        Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.Purch];
                        Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.Purch][(int)Globals.KPA_Categories.Purch.POPrevRelease];
                        HandlePurchDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 6:
                        Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.Purch];
                        Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.Purch][(int)Globals.KPA_Categories.Purch.NoConfirmation];
                        HandlePurchDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 7: // 7 - 8 = PurchSub
                        Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.PurchSub];
                        Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.PurchSub][(int)Globals.KPA_Categories.PurchSub.PRReleasePORelease];
                        HandlePurchSubDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 8:
                        Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.PurchSub];
                        Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.PurchSub][(int)Globals.KPA_Categories.PurchSub.POCreationCOnfEntry];
                        HandlePurchSubDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 9: // Purch Total
                        Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.PurchTotal];
                        Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.PurchTotal][(int)Globals.KPA_Categories.PurchTotal.PRRelConfEntry];
                        HandlePurchTotalDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 10: // Purch Plan Total
                        break; // Not yet created
                    case 11: // 12 - 14 = Follow Up
                        Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.FollowUp];
                        Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.FollowUp][(int)Globals.KPA_Categories.FollowUp.ConfPlanDate];
                        HandleFollowUpDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 12:
                        Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.FollowUp];
                        Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.FollowUp][(int)Globals.KPA_Categories.FollowUp.ConfDateUpcomingDel];
                        HandleFollowUpDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 13:
                        Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.FollowUp];
                        Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.FollowUp][(int)Globals.KPA_Categories.FollowUp.DueTodayLateConf];
                        HandleFollowUpDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 14: // 15 - 16 Cancellations
                    case 15:
                        break;
                    case 16: // 17 - 18 = NCRs
                    case 17:
                        break; // not yet created
                    case 18: // 19 - 21 = Hot Jobs
                        Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.HotJobs];
                        Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.HotJobs][(int)Globals.KPA_Categories.HotJobs.PrsNotonPO];
                        HandleHotJobsDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 19:
                        Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.HotJobs];
                        Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.HotJobs][(int)Globals.KPA_Categories.HotJobs.NoConfirmations];
                        HandleHotJobsDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 20:
                        Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.HotJobs];
                        Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.HotJobs][(int)Globals.KPA_Categories.HotJobs.LateToConfirmed];
                        HandleHotJobsDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 21: // 22 - 26 = Excess Stock - Stock
                    case 22:
                    case 23:
                    case 24:
                    case 25:
                        break; // not yet created
                    case 26: // 27 - 31 = Excess Stock - Open Orders
                    case 27:
                    case 28:
                    case 29:
                    case 30:
                        break; // not yet created
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
        private void TemplateTwoDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (TemplateTwoDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == "0" || TemplateTwoDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("There is no data in this cell.", "Data Timespan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                switch (e.RowIndex)
                {
                    case 0:
                        Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.CurrPlanActual];
                        Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.CurrPlanActual][(int)Globals.KPA_Categories.CurrPlanVsActual.CurrPlanDateCurrConfDateOpenPO];
                        HandleCurrentPlanVsActualDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 1:
                        Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.CurrPlanActual];
                        Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.CurrPlanActual][(int)Globals.KPA_Categories.CurrPlanVsActual.CurrPlanDateCurrConfDateOpenPOHotJobs];
                        HandleCurrentPlanVsActualDataTableLoading(e.RowIndex, e.ColumnIndex);
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
                    case 0:
                        break;
                    case 1: // PRs Aging (Not Released)
                        switch (columnIndex)
                        {
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
                    case 2: // Material Due
                        switch (columnIndex)
                        {
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
                    case 3: // PRs Aging (Released)
                        switch (columnIndex)
                        {
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
                    case 4: // PO First Release
                        switch (columnIndex)
                        {
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
                    case 5: // PO Prev Release
                        switch (columnIndex)
                        {
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
                    case 6: // No Confirmation
                        switch (columnIndex)
                        {
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
                    case 7: // PR Release to Po Release
                        switch (columnIndex)
                        {
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
                    case 8: // PO Creation to Confirmation Entry
                        switch (columnIndex)
                        {
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
                    case 9: // PR Release to Confirmation Entry
                        switch (columnIndex)
                        {
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
                    case 11: // Confirmed Date vs Plan Date
                        switch (columnIndex)
                        {
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
                        }
                        break;
                    case 12: // Confirmed Date for Upcoming Deliveries
                        switch (columnIndex)
                        {
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
                        }
                        break;
                    case 13: // Late to Confirmed
                        switch (columnIndex)
                        {
                            case 2: // <= 0 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadLateToConfirmedDateDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.LessThanZero;
                                break;
                            case 3: // 1 - 3 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadLateToConfirmedDateDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.One_Three;
                                break;
                            case 4: // 4 - 7 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadLateToConfirmedDateDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Four_Seven;
                                break;
                            case 5: // 8 - 14 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadLateToConfirmedDateDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Eight_Fourteen;
                                break;
                            case 6: // 15 - 21 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadLateToConfirmedDateDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.Fifteen_TwentyOne;
                                break;
                            case 7: // 22 - 28 Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadLateToConfirmedDateDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyTwo_TwentyEight;
                                break;
                            case 8: // 29+ Days
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadLateToConfirmedDateDataTable;
                                dv.ColumnTag = (int)TempOne.DataViews.TwentyNinePlus;
                                break;
                            case 9: // Average
                                return;
                            case 10: // Totals
                                dv.DataLoader += KpaDataTableLoader.FollowUp.LoadLateToConfirmedDateDataTable;
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
        private void HandleHotJobsDataTableLoading(int rowIndex, int columnIndex)
        {
            using (DataViewer dv = new DataViewer())
            {
                switch (rowIndex)
                {
                    case 18: // PRs (Not on PO) - Hot Jobs Only
                        switch (columnIndex)
                        {
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
                    case 19: // No Confirmations - Hot Jobs Only
                        switch (columnIndex)
                        {
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
                    case 20: // Late to Confirmed - Hot Jobs Only
                        switch (columnIndex)
                        {
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
        private void HandleCurrentPlanVsActualDataTableLoading(int rowIndex, int columnIndex)
        {
            using (DataViewer dv = new DataViewer())
            { 
                switch (rowIndex)
                {
                    case 0: // Current Plan Date vs Current Confirmation Date
                        switch (columnIndex)
                        {
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
                        }
                        break;
                    case 1: // Current Plan Date vs Current Confirmation Date - Hot Jobs Only
                        switch (columnIndex)
                        {
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
                        }
                        break;
                }
                dv.ShowDialog();
            }
        }

    }
}
