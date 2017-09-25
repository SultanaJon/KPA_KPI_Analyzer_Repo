using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KPA_KPI_Analyzer.KPA_KPI_Overall;
using KPA_KPI_Analyzer.KPA_KPI_Overall.KPA_Sections;

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
            bunifuCustomDataGrid1.Columns[(int)TempOneHeaderNames.TimeSpanOne].HeaderCell.Style.BackColor = Color.FromArgb(123, 204, 243);
            bunifuCustomDataGrid1.Columns[(int)TempOneHeaderNames.TimeSpanTwo].HeaderCell.Style.BackColor = Color.FromArgb(96, 189, 227);
            bunifuCustomDataGrid1.Columns[(int)TempOneHeaderNames.TimeSpanThree].HeaderCell.Style.BackColor = Color.FromArgb(79, 179, 208);
            bunifuCustomDataGrid1.Columns[(int)TempOneHeaderNames.TimeSpanFour].HeaderCell.Style.BackColor = Color.FromArgb(62, 168, 186);
            bunifuCustomDataGrid1.Columns[(int)TempOneHeaderNames.TimeSpanFive].HeaderCell.Style.BackColor = Color.FromArgb(50, 150, 150);
            bunifuCustomDataGrid1.Columns[(int)TempOneHeaderNames.TimeSpanSix].HeaderCell.Style.BackColor = Color.FromArgb(41, 132, 137);
            bunifuCustomDataGrid1.Columns[(int)TempOneHeaderNames.TimeSpanSeven].HeaderCell.Style.BackColor = Color.FromArgb(31, 109, 109);
            bunifuCustomDataGrid1.Columns[(int)TempOneHeaderNames.Average].HeaderCell.Style.BackColor = Color.FromArgb(230, 184, 183);
            bunifuCustomDataGrid1.Columns[(int)TempOneHeaderNames.Totals].HeaderCell.Style.BackColor = Color.FromArgb(218, 150, 148);


            bunifuCustomDataGrid2.Columns[(int)TempTwoHeaderNames.Average].HeaderCell.Style.BackColor = Color.FromArgb(141, 180, 226);
            bunifuCustomDataGrid2.Columns[(int)TempTwoHeaderNames.TimeSpanOne].HeaderCell.Style.BackColor = Color.FromArgb(155, 187, 89);
            bunifuCustomDataGrid2.Columns[(int)TempTwoHeaderNames.TimeSpanTwo].HeaderCell.Style.BackColor = Color.FromArgb(196, 215, 155);
            bunifuCustomDataGrid2.Columns[(int)TempTwoHeaderNames.TimeSpanThree].HeaderCell.Style.BackColor = Color.FromArgb(216, 228, 188);
            bunifuCustomDataGrid2.Columns[(int)TempTwoHeaderNames.TimeSpanFour].HeaderCell.Style.BackColor = Color.FromArgb(235, 241, 222);
            bunifuCustomDataGrid2.Columns[(int)TempTwoHeaderNames.TimeSpanFive].HeaderCell.Style.BackColor = Color.FromArgb(235, 241, 222);
            bunifuCustomDataGrid2.Columns[(int)TempTwoHeaderNames.TimeSpanSix].HeaderCell.Style.BackColor = Color.FromArgb(253, 233, 217);
            bunifuCustomDataGrid2.Columns[(int)TempTwoHeaderNames.TimeSpanSeven].HeaderCell.Style.BackColor = Color.FromArgb(252, 213, 180);
            bunifuCustomDataGrid2.Columns[(int)TempTwoHeaderNames.TimeSpanEight].HeaderCell.Style.BackColor = Color.FromArgb(250, 191, 143);
            bunifuCustomDataGrid2.Columns[(int)TempTwoHeaderNames.TimeSpanNine].HeaderCell.Style.BackColor = Color.FromArgb(151, 71, 6);
            bunifuCustomDataGrid2.Columns[(int)TempTwoHeaderNames.Totals].HeaderCell.Style.BackColor = Color.FromArgb(218, 150, 148);
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
        }




        /// <summary>
        /// Loads all of the KPA Plan data into the datagridview.
        /// </summary>
        private void LoadPlan()
        {
            string[] row = { data.kpa.plan.Name, data.kpa.plan.categoryNames[(int)Plan.CategorNames.PlannedOrderAging], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            bunifuCustomDataGrid1.Rows.Add(row);

            row = new string[]{
                data.kpa.plan.Name,
                data.kpa.plan.categoryNames[(int)Plan.CategorNames.PrsAgingNotReleased],
                data.kpa.plan.prsAgingNotRel.data.LessThanZero.ToString(),
                data.kpa.plan.prsAgingNotRel.data.One_Three.ToString(),
                data.kpa.plan.prsAgingNotRel.data.Four_Seven.ToString(),
                data.kpa.plan.prsAgingNotRel.data.Eight_Fourteen.ToString(),
                data.kpa.plan.prsAgingNotRel.data.Fifteen_TwentyOne.ToString(),
                data.kpa.plan.prsAgingNotRel.data.TwentyTwo_TwentyEight.ToString(),
                data.kpa.plan.prsAgingNotRel.data.TwentyNinePlus.ToString(),
                data.kpa.plan.prsAgingNotRel.data.Average.ToString(),
                data.kpa.plan.prsAgingNotRel.data.Total.ToString()
            };
            bunifuCustomDataGrid1.Rows.Add(row);


            row = new string[]{
                data.kpa.plan.Name,
                data.kpa.plan.categoryNames[(int)Plan.CategorNames.MaterialDue],
                data.kpa.plan.matDueDate.data.LessThanZero.ToString(),
                data.kpa.plan.matDueDate.data.One_Three.ToString(),
                data.kpa.plan.matDueDate.data.Four_Seven.ToString(),
                data.kpa.plan.matDueDate.data.Eight_Fourteen.ToString(),
                data.kpa.plan.matDueDate.data.Fifteen_TwentyOne.ToString(),
                data.kpa.plan.matDueDate.data.TwentyTwo_TwentyEight.ToString(),
                data.kpa.plan.matDueDate.data.TwentyNinePlus.ToString(),
                data.kpa.plan.matDueDate.data.Average.ToString(),
                data.kpa.plan.matDueDate.data.Total.ToString()
            };
            bunifuCustomDataGrid1.Rows.Add(row);
        }



        /// <summary>
        /// Loads all of the KPA Purch data into the datagridview.
        /// </summary>
        private void LoadPurch()
        {
            string[] row = {
                data.kpa.purch.Name,
                data.kpa.purch.categoryNames[(int)Purch.CategorNames.PRsAgingReleased],
                data.kpa.purch.prsAgingRel.data.LessThanZero.ToString(),
                data.kpa.purch.prsAgingRel.data.One_Three.ToString(),
                data.kpa.purch.prsAgingRel.data.Four_Seven.ToString(),
                data.kpa.purch.prsAgingRel.data.Eight_Fourteen.ToString(),
                data.kpa.purch.prsAgingRel.data.Fifteen_TwentyOne.ToString(),
                data.kpa.purch.prsAgingRel.data.TwentyTwo_TwentyEight.ToString(),
                data.kpa.purch.prsAgingRel.data.TwentyNinePlus.ToString(),
                data.kpa.purch.prsAgingRel.data.Average.ToString(),
                data.kpa.purch.prsAgingRel.data.Total.ToString()
            };
            bunifuCustomDataGrid1.Rows.Add(row);


            row = new string[]{
                data.kpa.purch.Name,
                data.kpa.purch.categoryNames[(int)Purch.CategorNames.POFirstRelease],
                data.kpa.purch.poFirstRel.data.LessThanZero.ToString(),
                data.kpa.purch.poFirstRel.data.One_Three.ToString(),
                data.kpa.purch.poFirstRel.data.Four_Seven.ToString(),
                data.kpa.purch.poFirstRel.data.Eight_Fourteen.ToString(),
                data.kpa.purch.poFirstRel.data.Fifteen_TwentyOne.ToString(),
                data.kpa.purch.poFirstRel.data.TwentyTwo_TwentyEight.ToString(),
                data.kpa.purch.poFirstRel.data.TwentyNinePlus.ToString(),
                data.kpa.purch.poFirstRel.data.Average.ToString(),
                data.kpa.purch.poFirstRel.data.Total.ToString()
            };
            bunifuCustomDataGrid1.Rows.Add(row);


            row = new string[]{
                data.kpa.purch.Name,
                data.kpa.purch.categoryNames[(int)Purch.CategorNames.POPrevRelease],
                data.kpa.purch.poPrevRel.data.LessThanZero.ToString(),
                data.kpa.purch.poPrevRel.data.One_Three.ToString(),
                data.kpa.purch.poPrevRel.data.Four_Seven.ToString(),
                data.kpa.purch.poPrevRel.data.Eight_Fourteen.ToString(),
                data.kpa.purch.poPrevRel.data.Fifteen_TwentyOne.ToString(),
                data.kpa.purch.poPrevRel.data.TwentyTwo_TwentyEight.ToString(),
                data.kpa.purch.poPrevRel.data.TwentyNinePlus.ToString(),
                data.kpa.purch.poPrevRel.data.Average.ToString(),
                data.kpa.purch.poPrevRel.data.Total.ToString()
            };
            bunifuCustomDataGrid1.Rows.Add(row);


            row = new string[]{
                data.kpa.purch.Name,
                data.kpa.purch.categoryNames[(int)Purch.CategorNames.NoConfirmation],
                data.kpa.purch.noConfirmation.data.LessThanZero.ToString(),
                data.kpa.purch.noConfirmation.data.One_Three.ToString(),
                data.kpa.purch.noConfirmation.data.Four_Seven.ToString(),
                data.kpa.purch.noConfirmation.data.Eight_Fourteen.ToString(),
                data.kpa.purch.noConfirmation.data.Fifteen_TwentyOne.ToString(),
                data.kpa.purch.noConfirmation.data.TwentyTwo_TwentyEight.ToString(),
                data.kpa.purch.noConfirmation.data.TwentyNinePlus.ToString(),
                data.kpa.purch.noConfirmation.data.Average.ToString(),
                data.kpa.purch.noConfirmation.data.Total.ToString()
            };
            bunifuCustomDataGrid1.Rows.Add(row);
        }



        /// <summary>
        /// Loads all of the KPA Purch Sub data into the datagridview.
        /// </summary>
        private void LoadPurchSub()
        {
            string[] row = {
                data.kpa.purchSub.Name,
                data.kpa.purchSub.categoryNames[(int)Purch_Sub.CategorNames.PrReleasePoRelease],
                data.kpa.purchSub.prRelToPORel.data.LessThanZero.ToString(),
                data.kpa.purchSub.prRelToPORel.data.One_Three.ToString(),
                data.kpa.purchSub.prRelToPORel.data.Four_Seven.ToString(),
                data.kpa.purchSub.prRelToPORel.data.Eight_Fourteen.ToString(),
                data.kpa.purchSub.prRelToPORel.data.Fifteen_TwentyOne.ToString(),
                data.kpa.purchSub.prRelToPORel.data.TwentyTwo_TwentyEight.ToString(),
                data.kpa.purchSub.prRelToPORel.data.TwentyNinePlus.ToString(),
                data.kpa.purchSub.prRelToPORel.data.Average.ToString(),
                data.kpa.purchSub.prRelToPORel.data.Total.ToString()
            };
            bunifuCustomDataGrid1.Rows.Add(row);


            row = new string[]{
                data.kpa.purchSub.Name,
                data.kpa.purchSub.categoryNames[(int)Purch_Sub.CategorNames.PoCreationConfirmationEntry],
                data.kpa.purchSub.POCreatToConfEntry.data.LessThanZero.ToString(),
                data.kpa.purchSub.POCreatToConfEntry.data.One_Three.ToString(),
                data.kpa.purchSub.POCreatToConfEntry.data.Four_Seven.ToString(),
                data.kpa.purchSub.POCreatToConfEntry.data.Eight_Fourteen.ToString(),
                data.kpa.purchSub.POCreatToConfEntry.data.Fifteen_TwentyOne.ToString(),
                data.kpa.purchSub.POCreatToConfEntry.data.TwentyTwo_TwentyEight.ToString(),
                data.kpa.purchSub.POCreatToConfEntry.data.TwentyNinePlus.ToString(),
                data.kpa.purchSub.POCreatToConfEntry.data.Average.ToString(),
                data.kpa.purchSub.POCreatToConfEntry.data.Total.ToString()
            };
            bunifuCustomDataGrid1.Rows.Add(row);
        }


        /// <summary>
        /// Loads all of the KPA Purch Total data into the datagridview.
        /// </summary>
        private void LoadPurchTotal()
        {
            string[] row = {
                data.kpa.purchTotal.Name,
                data.kpa.purchTotal.categoryNames[(int)Purch_Total.CategorNames.PrReleaseConfEntry],
                data.kpa.purchTotal.prRelConfEntry.data.LessThanZero.ToString(),
                data.kpa.purchTotal.prRelConfEntry.data.One_Three.ToString(),
                data.kpa.purchTotal.prRelConfEntry.data.Four_Seven.ToString(),
                data.kpa.purchTotal.prRelConfEntry.data.Eight_Fourteen.ToString(),
                data.kpa.purchTotal.prRelConfEntry.data.Fifteen_TwentyOne.ToString(),
                data.kpa.purchTotal.prRelConfEntry.data.TwentyTwo_TwentyEight.ToString(),
                data.kpa.purchTotal.prRelConfEntry.data.TwentyNinePlus.ToString(),
                data.kpa.purchTotal.prRelConfEntry.data.Average.ToString(),
                data.kpa.purchTotal.prRelConfEntry.data.Total.ToString()
            };
            bunifuCustomDataGrid1.Rows.Add(row);
        }

        /// <summary>
        /// Loads all of the KPA Purch Plan data into the datagridview.
        /// </summary>
        private void LoadPurchPlanTotal()
        {
            string[] row = { data.kpa.purchPlanTotal.Name, data.kpa.purchPlanTotal.categoryNames[(int)Purch_Plan_Total.CategorNames.PurchPlanTotalAging], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            bunifuCustomDataGrid1.Rows.Add(row);
        }

        /// <summary>
        /// Loads all of the KPA Follow Up data into the datagridview.
        /// </summary>
        private void LoadFollowUp()
        {
            string[] row = {
                data.kpa.followUp.Name,
                data.kpa.followUp.categoryNames[(int)Follow_Up.CategorNames.ConfirmedDateVsPlanDate],
                data.kpa.followUp.confDateVsPlanDate.data.LessThanZero.ToString(),
                data.kpa.followUp.confDateVsPlanDate.data.One_Three.ToString(),
                data.kpa.followUp.confDateVsPlanDate.data.Four_Seven.ToString(),
                data.kpa.followUp.confDateVsPlanDate.data.Eight_Fourteen.ToString(),
                data.kpa.followUp.confDateVsPlanDate.data.Fifteen_TwentyOne.ToString(),
                data.kpa.followUp.confDateVsPlanDate.data.TwentyTwo_TwentyEight.ToString(),
                data.kpa.followUp.confDateVsPlanDate.data.TwentyNinePlus.ToString(),
                data.kpa.followUp.confDateVsPlanDate.data.Average.ToString(),
                data.kpa.followUp.confDateVsPlanDate.data.Total.ToString()
            };
            bunifuCustomDataGrid1.Rows.Add(row);

            row = new string[]{
                data.kpa.followUp.Name,
                data.kpa.followUp.categoryNames[(int)Follow_Up.CategorNames.ConfirmedDateForUpcomingDel],
                data.kpa.followUp.ConfDateForUpcomingDel.data.LessThanZero.ToString(),
                data.kpa.followUp.ConfDateForUpcomingDel.data.One_Three.ToString(),
                data.kpa.followUp.ConfDateForUpcomingDel.data.Four_Seven.ToString(),
                data.kpa.followUp.ConfDateForUpcomingDel.data.Eight_Fourteen.ToString(),
                data.kpa.followUp.ConfDateForUpcomingDel.data.Fifteen_TwentyOne.ToString(),
                data.kpa.followUp.ConfDateForUpcomingDel.data.TwentyTwo_TwentyEight.ToString(),
                data.kpa.followUp.ConfDateForUpcomingDel.data.TwentyNinePlus.ToString(),
                data.kpa.followUp.ConfDateForUpcomingDel.data.Average.ToString(),
                data.kpa.followUp.ConfDateForUpcomingDel.data.Total.ToString()
            };
            bunifuCustomDataGrid1.Rows.Add(row);

            row = new string[]{
                data.kpa.followUp.Name,
                data.kpa.followUp.categoryNames[(int)Follow_Up.CategorNames.LateToConfirmed],
                data.kpa.followUp.LateToConfDate.data.LessThanZero.ToString(),
                data.kpa.followUp.LateToConfDate.data.One_Three.ToString(),
                data.kpa.followUp.LateToConfDate.data.Four_Seven.ToString(),
                data.kpa.followUp.LateToConfDate.data.Eight_Fourteen.ToString(),
                data.kpa.followUp.LateToConfDate.data.Fifteen_TwentyOne.ToString(),
                data.kpa.followUp.LateToConfDate.data.TwentyTwo_TwentyEight.ToString(),
                data.kpa.followUp.LateToConfDate.data.TwentyNinePlus.ToString(),
                data.kpa.followUp.LateToConfDate.data.Average.ToString(),
                data.kpa.followUp.LateToConfDate.data.Total.ToString()
            };
            bunifuCustomDataGrid1.Rows.Add(row);
        }

        /// <summary>
        /// Loads all of the KPA Cancellations data into the datagridview.
        /// </summary>
        private void LoadCancellations()
        {
            string[] row = { data.kpa.cancellations.Name, data.kpa.cancellations.categoryNames[(int)Cancellations.CategorNames.CancellationCount], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            bunifuCustomDataGrid1.Rows.Add(row);
            row = new string[]{ data.kpa.cancellations.Name, data.kpa.cancellations.categoryNames[(int)Cancellations.CategorNames.CancellationValue], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            bunifuCustomDataGrid1.Rows.Add(row);
        }

        /// <summary>
        /// Loads all of the NCRs Plan data into the datagridview.
        /// </summary>
        private void LoadNCRs()
        {
            string[] row = { data.kpa.ncrs.Name, data.kpa.ncrs.categoryNames[(int)NCRs.CategorNames.OpenNCRs], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            bunifuCustomDataGrid1.Rows.Add(row);
            row = new string[]{ data.kpa.ncrs.Name, data.kpa.ncrs.categoryNames[(int)NCRs.CategorNames.OpenNCRValues], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            bunifuCustomDataGrid1.Rows.Add(row);
        }

        /// <summary>
        /// Loads all of the KPA Hot Jobs data into the datagridview.
        /// </summary>
        private void LoadHotJobs()
        {
            string[] row = {
                data.kpa.hotJobs.Name,
                data.kpa.hotJobs.categoryNames[(int)Hot_Jobs.CategorNames.PrsNotOnPo],
                data.kpa.hotJobs.prsNotOnPO.data.LessThanZero.ToString(),
                data.kpa.hotJobs.prsNotOnPO.data.One_Three.ToString(),
                data.kpa.hotJobs.prsNotOnPO.data.Four_Seven.ToString(),
                data.kpa.hotJobs.prsNotOnPO.data.Eight_Fourteen.ToString(),
                data.kpa.hotJobs.prsNotOnPO.data.Fifteen_TwentyOne.ToString(),
                data.kpa.hotJobs.prsNotOnPO.data.TwentyTwo_TwentyEight.ToString(),
                data.kpa.hotJobs.prsNotOnPO.data.TwentyNinePlus.ToString(),
                data.kpa.hotJobs.prsNotOnPO.data.Average.ToString(),
                data.kpa.hotJobs.prsNotOnPO.data.Total.ToString()
            };
            bunifuCustomDataGrid1.Rows.Add(row);

            row = new string[]{
                data.kpa.hotJobs.Name,
                data.kpa.hotJobs.categoryNames[(int)Hot_Jobs.CategorNames.NoConfirmation],
                data.kpa.hotJobs.noConfirmation.data.LessThanZero.ToString(),
                data.kpa.hotJobs.noConfirmation.data.One_Three.ToString(),
                data.kpa.hotJobs.noConfirmation.data.Four_Seven.ToString(),
                data.kpa.hotJobs.noConfirmation.data.Eight_Fourteen.ToString(),
                data.kpa.hotJobs.noConfirmation.data.Fifteen_TwentyOne.ToString(),
                data.kpa.hotJobs.noConfirmation.data.TwentyTwo_TwentyEight.ToString(),
                data.kpa.hotJobs.noConfirmation.data.TwentyNinePlus.ToString(),
                data.kpa.hotJobs.noConfirmation.data.Average.ToString(),
                data.kpa.hotJobs.noConfirmation.data.Total.ToString()
            };
            bunifuCustomDataGrid1.Rows.Add(row);

            row = new string[]{
                data.kpa.hotJobs.Name,
                data.kpa.hotJobs.categoryNames[(int)Hot_Jobs.CategorNames.LateToConfirmed],
                data.kpa.hotJobs.lateToConfirmed.data.LessThanZero.ToString(),
                data.kpa.hotJobs.lateToConfirmed.data.One_Three.ToString(),
                data.kpa.hotJobs.lateToConfirmed.data.Four_Seven.ToString(),
                data.kpa.hotJobs.lateToConfirmed.data.Eight_Fourteen.ToString(),
                data.kpa.hotJobs.lateToConfirmed.data.Fifteen_TwentyOne.ToString(),
                data.kpa.hotJobs.lateToConfirmed.data.TwentyTwo_TwentyEight.ToString(),
                data.kpa.hotJobs.lateToConfirmed.data.TwentyNinePlus.ToString(),
                data.kpa.hotJobs.lateToConfirmed.data.Average.ToString(),
                data.kpa.hotJobs.lateToConfirmed.data.Total.ToString()
            };
            bunifuCustomDataGrid1.Rows.Add(row);
        }


        /// <summary>
        /// Loads all of the KPA Excess Stock - Stock data into the datagridview.
        /// </summary>
        private void LoadExcessStockStock()
        {
            string[] row = { data.kpa.excessStockStock.Name, data.kpa.excessStockStock.categoryNames[(int)Excess_Stock_Stock.CategorNames.PrsAgingNotReleased], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            bunifuCustomDataGrid1.Rows.Add(row);
            row = new string[]{ data.kpa.excessStockStock.Name, data.kpa.excessStockStock.categoryNames[(int)Excess_Stock_Stock.CategorNames.PrsAgingReleased], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            bunifuCustomDataGrid1.Rows.Add(row);
            row = new string[] { data.kpa.excessStockStock.Name, data.kpa.excessStockStock.categoryNames[(int)Excess_Stock_Stock.CategorNames.PoCreationToConfirmationEntry], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            bunifuCustomDataGrid1.Rows.Add(row);
            row = new string[]{ data.kpa.excessStockStock.Name, data.kpa.excessStockStock.categoryNames[(int)Excess_Stock_Stock.CategorNames.ConfirmedVsPlanDate], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            bunifuCustomDataGrid1.Rows.Add(row);
            row = new string[]{ data.kpa.excessStockStock.Name, data.kpa.excessStockStock.categoryNames[(int)Excess_Stock_Stock.CategorNames.ConfirmedDateForUpcomingDeliveries], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            bunifuCustomDataGrid1.Rows.Add(row);
        }

        /// <summary>
        /// Loads all of the KPA Excess Stock - Open Orders data into the datagridview.
        /// </summary>
        private void LoadExcessStockOpenOrders()
        {
            string[] row = { data.kpa.excessStockOpenOrders.Name, data.kpa.excessStockOpenOrders.categoryNames[(int)Excess_Stock_Open_Order.CategorNames.PrsAgingNotReleased], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            bunifuCustomDataGrid1.Rows.Add(row);
            row = new string[]{ data.kpa.excessStockOpenOrders.Name, data.kpa.excessStockOpenOrders.categoryNames[(int)Excess_Stock_Open_Order.CategorNames.PrsAgingReleased], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            bunifuCustomDataGrid1.Rows.Add(row);
            row = new string[]{ data.kpa.excessStockOpenOrders.Name, data.kpa.excessStockOpenOrders.categoryNames[(int)Excess_Stock_Open_Order.CategorNames.PoCreationToConfirmationEntry], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            bunifuCustomDataGrid1.Rows.Add(row);
            row = new string[]{ data.kpa.excessStockOpenOrders.Name, data.kpa.excessStockOpenOrders.categoryNames[(int)Excess_Stock_Open_Order.CategorNames.ConfirmedVsPlanDate], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            bunifuCustomDataGrid1.Rows.Add(row);
            row = new string[]{ data.kpa.excessStockOpenOrders.Name, data.kpa.excessStockOpenOrders.categoryNames[(int)Excess_Stock_Open_Order.CategorNames.ConfirmedDateForUpcomingDeliveries], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            bunifuCustomDataGrid1.Rows.Add(row);
        }


        /// <summary>
        /// Loads all of the KPA Current Plan vs Actual data into the datagridview.
        /// </summary>
        private void LoadCurrentPlanVsActual()
        {
            string[] row = {
                data.kpa.currPlanVsActual.Name,
                data.kpa.currPlanVsActual.categoryNames[(int)Current_Plan_vs_Actual.CategorNames.CurrPlanDateVsCurrConfDate],
                data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.Average.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanMinusThree.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusThree.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusTwo.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusOne.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.ZeroWeeks.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualOneWeek.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualTwoWeeks.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualThreeWeeks.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanThreeWeeks.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.Total.ToString(),
            };
            bunifuCustomDataGrid2.Rows.Add(row);

            row = new string[]{
                data.kpa.currPlanVsActual.Name,
                data.kpa.currPlanVsActual.categoryNames[(int)Current_Plan_vs_Actual.CategorNames.CurrPlanDateVsCurrConfDate_HJsOnly],
                data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.Average.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanMinusThree.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusThree.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusTwo.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusOne.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.ZeroWeeks.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualOneWeek.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualTwoWeeks.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualThreeWeeks.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanThreeWeeks.ToString(),
                data.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.Total.ToString(),
            };
            bunifuCustomDataGrid2.Rows.Add(row);
        }
    }
}
