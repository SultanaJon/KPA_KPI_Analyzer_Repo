using KPA_KPI_Analyzer.KPA_KPI_Overall;
using KPA_KPI_Analyzer.KPA_KPI_Overall.KPA_Sections;
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
        }



        public enum TempOneHeaderNames
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


        
        public enum TempTwoHeaderNames
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
            TemplateOneDataGrid.Columns[(int)TempOneHeaderNames.TimeSpanOne].HeaderCell.Style.BackColor = Color.FromArgb(123, 204, 243);
            TemplateOneDataGrid.Columns[(int)TempOneHeaderNames.TimeSpanTwo].HeaderCell.Style.BackColor = Color.FromArgb(96, 189, 227);
            TemplateOneDataGrid.Columns[(int)TempOneHeaderNames.TimeSpanThree].HeaderCell.Style.BackColor = Color.FromArgb(79, 179, 208);
            TemplateOneDataGrid.Columns[(int)TempOneHeaderNames.TimeSpanFour].HeaderCell.Style.BackColor = Color.FromArgb(62, 168, 186);
            TemplateOneDataGrid.Columns[(int)TempOneHeaderNames.TimeSpanFive].HeaderCell.Style.BackColor = Color.FromArgb(50, 150, 150);
            TemplateOneDataGrid.Columns[(int)TempOneHeaderNames.TimeSpanSix].HeaderCell.Style.BackColor = Color.FromArgb(41, 132, 137);
            TemplateOneDataGrid.Columns[(int)TempOneHeaderNames.TimeSpanSeven].HeaderCell.Style.BackColor = Color.FromArgb(31, 109, 109);
            TemplateOneDataGrid.Columns[(int)TempOneHeaderNames.Average].HeaderCell.Style.BackColor = Color.FromArgb(230, 184, 183);
            TemplateOneDataGrid.Columns[(int)TempOneHeaderNames.Totals].HeaderCell.Style.BackColor = Color.FromArgb(218, 150, 148);


            TemplateTwoDataGrid.Columns[(int)TempTwoHeaderNames.Average].HeaderCell.Style.BackColor = Color.FromArgb(141, 180, 226);
            TemplateTwoDataGrid.Columns[(int)TempTwoHeaderNames.TimeSpanOne].HeaderCell.Style.BackColor = Color.FromArgb(155, 187, 89);
            TemplateTwoDataGrid.Columns[(int)TempTwoHeaderNames.TimeSpanTwo].HeaderCell.Style.BackColor = Color.FromArgb(196, 215, 155);
            TemplateTwoDataGrid.Columns[(int)TempTwoHeaderNames.TimeSpanThree].HeaderCell.Style.BackColor = Color.FromArgb(216, 228, 188);
            TemplateTwoDataGrid.Columns[(int)TempTwoHeaderNames.TimeSpanFour].HeaderCell.Style.BackColor = Color.FromArgb(235, 241, 222);
            TemplateTwoDataGrid.Columns[(int)TempTwoHeaderNames.TimeSpanFive].HeaderCell.Style.BackColor = Color.FromArgb(235, 241, 222);
            TemplateTwoDataGrid.Columns[(int)TempTwoHeaderNames.TimeSpanSix].HeaderCell.Style.BackColor = Color.FromArgb(253, 233, 217);
            TemplateTwoDataGrid.Columns[(int)TempTwoHeaderNames.TimeSpanSeven].HeaderCell.Style.BackColor = Color.FromArgb(252, 213, 180);
            TemplateTwoDataGrid.Columns[(int)TempTwoHeaderNames.TimeSpanEight].HeaderCell.Style.BackColor = Color.FromArgb(250, 191, 143);
            TemplateTwoDataGrid.Columns[(int)TempTwoHeaderNames.TimeSpanNine].HeaderCell.Style.BackColor = Color.FromArgb(151, 71, 6);
            TemplateTwoDataGrid.Columns[(int)TempTwoHeaderNames.Totals].HeaderCell.Style.BackColor = Color.FromArgb(218, 150, 148);
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
    }
}
