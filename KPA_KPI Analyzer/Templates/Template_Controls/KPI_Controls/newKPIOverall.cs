using KPA_KPI_Analyzer.KPA_KPI_Overall;
using KPA_KPI_Analyzer.KPA_KPI_Overall.KPI_Sections;
using System;
using System.Drawing;
using System.Windows.Forms;
using KPA_KPI_Analyzer.DataLoading.KPI_Data.DataTableLoader;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPI_Controls
{
    public partial class NewKPIOverall : UserControl
    {
        private Overall data;

        public NewKPIOverall(Overall _data)
        {
            InitializeComponent();
            ApplyDataGridStyles();
            data = _data;
        }



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
            PercentUnconf
        }



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
        /// Sets the color of the DataGridView Header cells only.
        /// </summary>
        private void ApplyDataGridStyles()
        {
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.Average].HeaderCell.Style.BackColor = Color.FromArgb(141, 180, 226);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanOne].HeaderCell.Style.BackColor = Color.FromArgb(155, 187, 89);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanTwo].HeaderCell.Style.BackColor = Color.FromArgb(196, 215, 155);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanThree].HeaderCell.Style.BackColor = Color.FromArgb(216, 228, 188);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanFour].HeaderCell.Style.BackColor = Color.FromArgb(235, 241, 222);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanFive].HeaderCell.Style.BackColor = Color.White;
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanFive].HeaderCell.Style.ForeColor = Color.Black;
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanSix].HeaderCell.Style.BackColor = Color.FromArgb(253, 233, 217);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanSeven].HeaderCell.Style.BackColor = Color.FromArgb(252, 213, 180);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanEight].HeaderCell.Style.BackColor = Color.FromArgb(250, 191, 143);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.TimeSpanNine].HeaderCell.Style.BackColor = Color.FromArgb(246, 144, 60);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.Total].HeaderCell.Style.BackColor = Color.FromArgb(103, 65, 114);
            TemplateThreeDataGrid.Columns[(int)TempThreeHeaderNames.PercentUnconf].HeaderCell.Style.BackColor = Color.IndianRed;


            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.Average].HeaderCell.Style.BackColor = Color.FromArgb(141, 180, 226);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanOne].HeaderCell.Style.BackColor = Color.FromArgb(252, 213, 180);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanTwo].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanThree].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanFour].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanFive].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanSix].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanSeven].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanEight].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanNine].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanTen].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.TimeSpanEleven].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.Total].HeaderCell.Style.BackColor = Color.FromArgb(103, 65, 114);
            TemplateFourDataGrid.Columns[(int)TempFourHeaderNames.PercentUnconf].HeaderCell.Style.BackColor = Color.IndianRed;


            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TotalValue].HeaderCell.Style.BackColor = Color.FromArgb(141, 180, 226);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanOne].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanTwo].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanThree].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanFour].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanFive].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanSix].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanSeven].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanEight].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanNine].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
            TemplateFiveDataGrid.Columns[(int)TempFiveHeaderNames.TimeSpanTen].HeaderCell.Style.BackColor = Color.FromArgb(197, 217, 241);
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







        // Load all the function that load all the data into the datagridviews.
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
            LoadPurchPlanTotal();
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
            string[] row = new string[]{
                data.kpi.plan.Name,
                data.kpi.plan.categoryNames[(int)Plan.CategorNames.prPlanDateVsCurrPlan],
                string.Format("{0:n}", data.kpi.plan.prPlanDateVsCurrPlan.data.Average),
                string.Format("{0:n0}", data.kpi.plan.prPlanDateVsCurrPlan.data.Minus_TwentyTwo),
                string.Format("{0:n0}", data.kpi.plan.prPlanDateVsCurrPlan.data.Minus_Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.plan.prPlanDateVsCurrPlan.data.Minus_Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.plan.prPlanDateVsCurrPlan.data.Minus_One_Seven),
                string.Format("{0:n0}", data.kpi.plan.prPlanDateVsCurrPlan.data.Zero),
                string.Format("{0:n0}", data.kpi.plan.prPlanDateVsCurrPlan.data.One_Seven),
                string.Format("{0:n0}", data.kpi.plan.prPlanDateVsCurrPlan.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.plan.prPlanDateVsCurrPlan.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.plan.prPlanDateVsCurrPlan.data.TwentyTwo),
                string.Format("{0:n0}", data.kpi.plan.prPlanDateVsCurrPlan.data.Total)
            };
            TemplateThreeDataGrid.Rows.Add(row);



            row = new string[]{
                data.kpi.plan.Name,
                data.kpi.plan.categoryNames[(int)Plan.CategorNames.origPlanDateMinus2ndLvlRelDateVsCodedLead],
                string.Format("{0:n}", data.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Average),
                string.Format("{0:n0}", data.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_TwentyTwo),
                string.Format("{0:n0}", data.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_One_Seven),
                string.Format("{0:n0}", data.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Zero),
                string.Format("{0:n0}", data.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.One_Seven),
                string.Format("{0:n0}", data.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.TwentyTwo),
                string.Format("{0:n0}", data.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Total)
            };
            TemplateThreeDataGrid.Rows.Add(row);


            row = new string[]{
                data.kpi.plan.Name,
                data.kpi.plan.categoryNames[(int)Plan.CategorNames.currPlanDateMinus2ndLvlRelDateVsCodedLead],
                string.Format("{0:n}", data.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Average),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_TwentyTwo),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_One_Seven),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Zero),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.One_Seven),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.TwentyTwo),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Total)
            };
            TemplateThreeDataGrid.Rows.Add(row);
        }







        /// <summary>
        /// Loads all of the KPA Purch data into the datagridview.
        /// </summary>
        private void LoadPurch()
        {
            string[] row = new string[]{
                data.kpi.purch.Name,
                data.kpi.purch.categoryNames[(int)Purch.CategorNames.initConfVsPRPlanDate],
                string.Format("{0:n}", data.kpi.purch.initConfVsPRPlanDate.data.Average),
                string.Format("{0:n0}", data.kpi.purch.initConfVsPRPlanDate.data.Minus_TwentyTwo),
                string.Format("{0:n0}", data.kpi.purch.initConfVsPRPlanDate.data.Minus_Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.purch.initConfVsPRPlanDate.data.Minus_Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.purch.initConfVsPRPlanDate.data.Minus_One_Seven),
                string.Format("{0:n0}", data.kpi.purch.initConfVsPRPlanDate.data.Zero),
                string.Format("{0:n0}", data.kpi.purch.initConfVsPRPlanDate.data.One_Seven),
                string.Format("{0:n0}", data.kpi.purch.initConfVsPRPlanDate.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.purch.initConfVsPRPlanDate.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.purch.initConfVsPRPlanDate.data.TwentyTwo),
                string.Format("{0:n0}", data.kpi.purch.initConfVsPRPlanDate.data.Total),
                string.Format("{0:n}", data.kpi.purch.initConfVsPRPlanDate.data.PercentUnconf + "%")
            };
            TemplateThreeDataGrid.Rows.Add(row);
        }







        /// <summary>
        /// Loads all of the KPA Purch Sub data into the datagridview.
        /// </summary>
        private void LoadFollowUp()
        {
            string[] row = new string[]{
                data.kpi.followUp.Name,
                data.kpi.followUp.categoryNames[(int)FollowUp.CategorNames.initConfVsCurrConf],
                string.Format("{0:n}", data.kpi.followUp.initConfVsCurrConf.data.Average),
                string.Format("{0:n0}", data.kpi.followUp.initConfVsCurrConf.data.Minus_TwentyTwo),
                string.Format("{0:n0}", data.kpi.followUp.initConfVsCurrConf.data.Minus_Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.followUp.initConfVsCurrConf.data.Minus_Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.followUp.initConfVsCurrConf.data.Minus_One_Seven),
                string.Format("{0:n0}", data.kpi.followUp.initConfVsCurrConf.data.Zero),
                string.Format("{0:n0}", data.kpi.followUp.initConfVsCurrConf.data.One_Seven),
                string.Format("{0:n0}", data.kpi.followUp.initConfVsCurrConf.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.followUp.initConfVsCurrConf.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.followUp.initConfVsCurrConf.data.TwentyTwo),
                string.Format("{0:n0}", data.kpi.followUp.initConfVsCurrConf.data.Total),
                string.Format("{0:n}", data.kpi.followUp.initConfVsCurrConf.data.PercentUnconf + "%")

            };
            TemplateThreeDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpi.followUp.Name,
                data.kpi.followUp.categoryNames[(int)FollowUp.CategorNames.finalConfDateVsFinalPlan],
                string.Format("{0:n}", data.kpi.followUp.finalConfDateVsFinalPlan.data.Average),
                string.Format("{0:n0}", data.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_TwentyTwo),
                string.Format("{0:n0}", data.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_One_Seven),
                string.Format("{0:n0}", data.kpi.followUp.finalConfDateVsFinalPlan.data.Zero),
                string.Format("{0:n0}", data.kpi.followUp.finalConfDateVsFinalPlan.data.One_Seven),
                string.Format("{0:n0}", data.kpi.followUp.finalConfDateVsFinalPlan.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.followUp.finalConfDateVsFinalPlan.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.followUp.finalConfDateVsFinalPlan.data.TwentyTwo),
                string.Format("{0:n0}", data.kpi.followUp.finalConfDateVsFinalPlan.data.Total),
                string.Format("{0:n}", data.kpi.followUp.finalConfDateVsFinalPlan.data.PercentUnconf + "%")

            };
            TemplateThreeDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpi.followUp.Name,
                data.kpi.followUp.categoryNames[(int)FollowUp.CategorNames.receiptDateVsCurrPlanDate],
                string.Format("{0:n}", data.kpi.followUp.receiptDateVsCurrPlanDate.data.Average),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_TwentyTwo),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_One_Seven),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrPlanDate.data.Zero),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrPlanDate.data.One_Seven),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrPlanDate.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrPlanDate.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrPlanDate.data.TwentyTwo),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrPlanDate.data.Total)

            };
            TemplateThreeDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpi.followUp.Name,
                data.kpi.followUp.categoryNames[(int)FollowUp.CategorNames.receiptDateVsOrigConfDate],
                string.Format("{0:n}", data.kpi.followUp.receiptDateVsOrigConfDate.data.Average),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_TwentyTwo),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_One_Seven),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsOrigConfDate.data.Zero),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsOrigConfDate.data.One_Seven),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsOrigConfDate.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsOrigConfDate.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsOrigConfDate.data.TwentyTwo),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsOrigConfDate.data.Total),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsOrigConfDate.data.PercentUnconf + "%")
            };
            TemplateThreeDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpi.followUp.Name,
                data.kpi.followUp.categoryNames[(int)FollowUp.CategorNames.receiptDateVsCurrConfDate],
                string.Format("{0:n}", data.kpi.followUp.receiptDateVsCurrConfDate.data.Average),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_TwentyTwo),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_One_Seven),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrConfDate.data.Zero),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrConfDate.data.One_Seven),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrConfDate.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrConfDate.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrConfDate.data.TwentyTwo),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrConfDate.data.Total),
                string.Format("{0:n0}", data.kpi.followUp.receiptDateVsCurrConfDate.data.PercentUnconf + "%")

            };
            TemplateThreeDataGrid.Rows.Add(row);
        }





        /// <summary>
        /// Loads all of the KPA Purch Total data into the datagridview.
        /// </summary>
        private void LoadPlanTwo()
        {
            string[] row = { data.kpi.planTwo.Name, data.kpi.planTwo.categoryNames[(int)PlanTwo.CategorNames.prPlanDateVsPR2ndLvlRel], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateFourDataGrid.Rows.Add(row);

            row = new string[]{ data.kpi.planTwo.Name, data.kpi.planTwo.categoryNames[(int)PlanTwo.CategorNames.planOrderCreatVs2ndLvlRel], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateFourDataGrid.Rows.Add(row);
        }





        /// <summary>
        /// Loads all of the KPA Purch Plan data into the datagridview.
        /// </summary>
        private void LoadPurchTwo()
        {
            string[] row = new string[]{
                data.kpi.purchTwo.Name,
                data.kpi.purchTwo.categoryNames[(int)PurchTwo.CategorNames.pr2ndLvlRelVsPOCreation],
                string.Format("{0:n}", data.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.Average),
                string.Format("{0:n0}", data.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.LessThanZero),
                string.Format("{0:n0}", data.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.One_Three),
                string.Format("{0:n0}", data.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.Four_Seven),
                string.Format("{0:n0}", data.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.TwentyNine_ThirtyFive),
                string.Format("{0:n0}", data.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.ThirtySix_FourtyTwo),
                string.Format("{0:n0}", data.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.FourtyThree_FourtyNine),
                string.Format("{0:n0}", data.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.Fifty_FiftySix),
                string.Format("{0:n0}", data.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.GreaterThanEqualFiftySeven),
                string.Format("{0:n0}", data.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.Total)
            };
            TemplateFourDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpi.purchTwo.Name,
                data.kpi.purchTwo.categoryNames[(int)PurchTwo.CategorNames.poCreationVsPORel],
                string.Format("{0:n}", data.kpi.purchTwo.poCreationVsPORel.data.Average),
                string.Format("{0:n0}", data.kpi.purchTwo.poCreationVsPORel.data.LessThanZero),
                string.Format("{0:n0}", data.kpi.purchTwo.poCreationVsPORel.data.One_Three),
                string.Format("{0:n0}", data.kpi.purchTwo.poCreationVsPORel.data.Four_Seven),
                string.Format("{0:n0}", data.kpi.purchTwo.poCreationVsPORel.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.purchTwo.poCreationVsPORel.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.purchTwo.poCreationVsPORel.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpi.purchTwo.poCreationVsPORel.data.TwentyNine_ThirtyFive),
                string.Format("{0:n0}", data.kpi.purchTwo.poCreationVsPORel.data.ThirtySix_FourtyTwo),
                string.Format("{0:n0}", data.kpi.purchTwo.poCreationVsPORel.data.FourtyThree_FourtyNine),
                string.Format("{0:n0}", data.kpi.purchTwo.poCreationVsPORel.data.Fifty_FiftySix),
                string.Format("{0:n0}", data.kpi.purchTwo.poCreationVsPORel.data.GreaterThanEqualFiftySeven),
                string.Format("{0:n0}", data.kpi.purchTwo.poCreationVsPORel.data.Total)
            };
            TemplateFourDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpi.purchTwo.Name,
                data.kpi.purchTwo.categoryNames[(int)PurchTwo.CategorNames.poRelVsPOConf],
                string.Format("{0:n}", data.kpi.purchTwo.poRelVsPOConf.data.Average),
                string.Format("{0:n0}", data.kpi.purchTwo.poRelVsPOConf.data.LessThanZero),
                string.Format("{0:n0}", data.kpi.purchTwo.poRelVsPOConf.data.One_Three),
                string.Format("{0:n0}", data.kpi.purchTwo.poRelVsPOConf.data.Four_Seven),
                string.Format("{0:n0}", data.kpi.purchTwo.poRelVsPOConf.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.purchTwo.poRelVsPOConf.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.purchTwo.poRelVsPOConf.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpi.purchTwo.poRelVsPOConf.data.TwentyNine_ThirtyFive),
                string.Format("{0:n0}", data.kpi.purchTwo.poRelVsPOConf.data.ThirtySix_FourtyTwo),
                string.Format("{0:n0}", data.kpi.purchTwo.poRelVsPOConf.data.FourtyThree_FourtyNine),
                string.Format("{0:n0}", data.kpi.purchTwo.poRelVsPOConf.data.Fifty_FiftySix),
                string.Format("{0:n0}", data.kpi.purchTwo.poRelVsPOConf.data.GreaterThanEqualFiftySeven),
                string.Format("{0:n0}", data.kpi.purchTwo.poRelVsPOConf.data.Total),
                string.Format("{0:n0}", data.kpi.purchTwo.poRelVsPOConf.data.PercentUnconf + "%")
            };
            TemplateFourDataGrid.Rows.Add(row);
        }





        /// <summary>
        /// Loads all of the KPA Follow Up data into the datagridview.
        /// </summary>
        private void LoadPurchSub()
        {
            string[] row = new string[]{
                data.kpi.purchSub.Name,
                data.kpi.purchSub.categoryNames[(int)PurchSub.CategorNames.prRelVsPORel],
                string.Format("{0:n}", data.kpi.purchSub.prRelVsPORel.data.Average),
                string.Format("{0:n0}", data.kpi.purchSub.prRelVsPORel.data.LessThanZero),
                string.Format("{0:n0}", data.kpi.purchSub.prRelVsPORel.data.One_Three),
                string.Format("{0:n0}", data.kpi.purchSub.prRelVsPORel.data.Four_Seven),
                string.Format("{0:n0}", data.kpi.purchSub.prRelVsPORel.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.purchSub.prRelVsPORel.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.purchSub.prRelVsPORel.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpi.purchSub.prRelVsPORel.data.TwentyNine_ThirtyFive),
                string.Format("{0:n0}", data.kpi.purchSub.prRelVsPORel.data.ThirtySix_FourtyTwo),
                string.Format("{0:n0}", data.kpi.purchSub.prRelVsPORel.data.FourtyThree_FourtyNine),
                string.Format("{0:n0}", data.kpi.purchSub.prRelVsPORel.data.Fifty_FiftySix),
                string.Format("{0:n0}", data.kpi.purchSub.prRelVsPORel.data.GreaterThanEqualFiftySeven),
                string.Format("{0:n0}", data.kpi.purchSub.prRelVsPORel.data.Total)
            };
            TemplateFourDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpi.purchSub.Name,
                data.kpi.purchSub.categoryNames[(int)PurchSub.CategorNames.poCreateVsConfEntry],
                string.Format("{0:n}", data.kpi.purchSub.poCreateVsConfEntry.data.Average),
                string.Format("{0:n0}", data.kpi.purchSub.poCreateVsConfEntry.data.LessThanZero),
                string.Format("{0:n0}", data.kpi.purchSub.poCreateVsConfEntry.data.One_Three),
                string.Format("{0:n0}", data.kpi.purchSub.poCreateVsConfEntry.data.Four_Seven),
                string.Format("{0:n0}", data.kpi.purchSub.poCreateVsConfEntry.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.purchSub.poCreateVsConfEntry.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.purchSub.poCreateVsConfEntry.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpi.purchSub.poCreateVsConfEntry.data.TwentyNine_ThirtyFive),
                string.Format("{0:n0}", data.kpi.purchSub.poCreateVsConfEntry.data.ThirtySix_FourtyTwo),
                string.Format("{0:n0}", data.kpi.purchSub.poCreateVsConfEntry.data.FourtyThree_FourtyNine),
                string.Format("{0:n0}", data.kpi.purchSub.poCreateVsConfEntry.data.Fifty_FiftySix),
                string.Format("{0:n0}", data.kpi.purchSub.poCreateVsConfEntry.data.GreaterThanEqualFiftySeven),
                string.Format("{0:n0}", data.kpi.purchSub.poCreateVsConfEntry.data.Total),
                string.Format("{0:n0}", data.kpi.purchSub.poCreateVsConfEntry.data.PercentUnconf + "%")
            };
            TemplateFourDataGrid.Rows.Add(row);
        }





        /// <summary>
        /// Loads all of the KPA Cancellations data into the datagridview.
        /// </summary>
        private void LoadPurchTotal()
        {
            string[] row = new string[]{
                data.kpi.purchTotal.Name,
                data.kpi.purchTotal.categoryNames[(int)PurchTotal.CategorNames.prRelConfEntry],
                string.Format("{0:n}", data.kpi.purchTotal.prRelConfEntry.data.Average),
                string.Format("{0:n0}", data.kpi.purchTotal.prRelConfEntry.data.LessThanZero),
                string.Format("{0:n0}", data.kpi.purchTotal.prRelConfEntry.data.One_Three),
                string.Format("{0:n0}", data.kpi.purchTotal.prRelConfEntry.data.Four_Seven),
                string.Format("{0:n0}", data.kpi.purchTotal.prRelConfEntry.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.purchTotal.prRelConfEntry.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.purchTotal.prRelConfEntry.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpi.purchTotal.prRelConfEntry.data.TwentyNine_ThirtyFive),
                string.Format("{0:n0}", data.kpi.purchTotal.prRelConfEntry.data.ThirtySix_FourtyTwo),
                string.Format("{0:n0}", data.kpi.purchTotal.prRelConfEntry.data.FourtyThree_FourtyNine),
                string.Format("{0:n0}", data.kpi.purchTotal.prRelConfEntry.data.Fifty_FiftySix),
                string.Format("{0:n0}", data.kpi.purchTotal.prRelConfEntry.data.GreaterThanEqualFiftySeven),
                string.Format("{0:n0}", data.kpi.purchTotal.prRelConfEntry.data.Total),
                string.Format("{0:n0}", data.kpi.purchTotal.prRelConfEntry.data.PercentUnconf + "%")
            };
            TemplateFourDataGrid.Rows.Add(row);
        }





        /// <summary>
        /// Loads all of the NCRs Plan data into the datagridview.
        /// </summary>
        private void LoadPurchPlan()
        {
            string[] row = new string[]{
                data.kpi.purchPlan.Name,
                data.kpi.purchPlan.categoryNames[(int)PurchPlan.CategorNames.poRelVsPRDelDate],
                string.Format("{0:n}", data.kpi.purchPlan.poRelVsPRDelDate.data.Average),
                string.Format("{0:n0}", data.kpi.purchPlan.poRelVsPRDelDate.data.LessThanZero),
                string.Format("{0:n0}", data.kpi.purchPlan.poRelVsPRDelDate.data.One_Three),
                string.Format("{0:n0}", data.kpi.purchPlan.poRelVsPRDelDate.data.Four_Seven),
                string.Format("{0:n0}", data.kpi.purchPlan.poRelVsPRDelDate.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.purchPlan.poRelVsPRDelDate.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.purchPlan.poRelVsPRDelDate.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpi.purchPlan.poRelVsPRDelDate.data.TwentyNine_ThirtyFive),
                string.Format("{0:n0}", data.kpi.purchPlan.poRelVsPRDelDate.data.ThirtySix_FourtyTwo),
                string.Format("{0:n0}", data.kpi.purchPlan.poRelVsPRDelDate.data.FourtyThree_FourtyNine),
                string.Format("{0:n0}", data.kpi.purchPlan.poRelVsPRDelDate.data.Fifty_FiftySix),
                string.Format("{0:n0}", data.kpi.purchPlan.poRelVsPRDelDate.data.GreaterThanEqualFiftySeven),
                string.Format("{0:n0}", data.kpi.purchPlan.poRelVsPRDelDate.data.Total)
            };
            TemplateFourDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpi.purchPlan.Name,
                data.kpi.purchPlan.categoryNames[(int)PurchPlan.CategorNames.pr2ndLvlRelOrigPlanDelDate],
                string.Format("{0:n}", data.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.Average),
                string.Format("{0:n0}", data.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.LessThanZero),
                string.Format("{0:n0}", data.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.One_Three),
                string.Format("{0:n0}", data.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.Four_Seven),
                string.Format("{0:n0}", data.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.TwentyNine_ThirtyFive),
                string.Format("{0:n0}", data.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.ThirtySix_FourtyTwo),
                string.Format("{0:n0}", data.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.FourtyThree_FourtyNine),
                string.Format("{0:n0}", data.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.Fifty_FiftySix),
                string.Format("{0:n0}", data.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.GreaterThanEqualFiftySeven),
                string.Format("{0:n0}", data.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.Total)
            };
            TemplateFourDataGrid.Rows.Add(row);
        }





        /// <summary>
        /// Loads all of the KPA Hot Jobs data into the datagridview.
        /// </summary>
        private void LoadPurchPlanTotal()
        {
            string[] row = { data.kpi.purchPlanTotal.Name, data.kpi.purchPlanTotal.categoryNames[(int)PurchPlanTotal.CategorNames.planOrderCreationVsConfEntry], "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            TemplateFourDataGrid.Rows.Add(row);
        }





        /// <summary>
        /// Loads all of the KPA Excess Stock - Stock data into the datagridview.
        /// </summary>
        private void LoadOther()
        {
            string[] row = new string[]{
                data.kpi.other.Name,
                data.kpi.other.categoryNames[(int)Other.CategorNames.prsCreated],
                "$" + string.Format("{0:n}", data.kpi.other.prsCreated.data.TotalValue),
                "$" + string.Format("{0:n}", data.kpi.other.prsCreated.data.GreaterThanZeroWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsCreated.data.GreaterThanMinusOneWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsCreated.data.GreaterThanMinusTwoWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsCreated.data.GreaterThanMinusThreeWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsCreated.data.GreaterThanMinusFourWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsCreated.data.GreaterThanMinusFiveWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsCreated.data.GreaterThanMinusSixWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsCreated.data.GreaterThanMinusSevenWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsCreated.data.GreaterThanMinusEightWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsCreated.data.LessThanEightWeeks),
                string.Format("{0:n0}", data.kpi.other.prsCreated.data.Total)
            };
            TemplateFiveDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpi.other.Name,
                data.kpi.other.categoryNames[(int)Other.CategorNames.prsReleased],
                "$" + string.Format("{0:n}", data.kpi.other.prsReleased.data.TotalValue),
                "$" + string.Format("{0:n}", data.kpi.other.prsReleased.data.GreaterThanZeroWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsReleased.data.GreaterThanMinusOneWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsReleased.data.GreaterThanMinusTwoWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsReleased.data.GreaterThanMinusThreeWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsReleased.data.GreaterThanMinusFourWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsReleased.data.GreaterThanMinusFiveWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsReleased.data.GreaterThanMinusSixWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsReleased.data.GreaterThanMinusSevenWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsReleased.data.GreaterThanMinusEightWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prsReleased.data.LessThanEightWeeks),
                string.Format("{0:n0}", data.kpi.other.prsReleased.data.Total)
            };
            TemplateFiveDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpi.other.Name,
                data.kpi.other.categoryNames[(int)Other.CategorNames.totalSpend],
                "$" + string.Format("{0:n}", data.kpi.other.totalSpend.data.TotalValue),
                "$" + string.Format("{0:n}", data.kpi.other.totalSpend.data.GreaterThanZeroWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.totalSpend.data.GreaterThanMinusOneWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.totalSpend.data.GreaterThanMinusTwoWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.totalSpend.data.GreaterThanMinusThreeWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.totalSpend.data.GreaterThanMinusFourWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.totalSpend.data.GreaterThanMinusFiveWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.totalSpend.data.GreaterThanMinusSixWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.totalSpend.data.GreaterThanMinusSevenWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.totalSpend.data.GreaterThanMinusEightWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.totalSpend.data.LessThanEightWeeks),
                string.Format("{0:n0}", data.kpi.other.totalSpend.data.Total)
            };
            TemplateFiveDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpi.other.Name,
                data.kpi.other.categoryNames[(int)Other.CategorNames.prVsPOValue],
                "$" + string.Format("{0:n}", data.kpi.other.prVsPOValue.data.TotalValue),
                "$" + string.Format("{0:n}", data.kpi.other.prVsPOValue.data.GreaterThanZeroWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prVsPOValue.data.GreaterThanMinusOneWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prVsPOValue.data.GreaterThanMinusTwoWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prVsPOValue.data.GreaterThanMinusThreeWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prVsPOValue.data.GreaterThanMinusFourWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prVsPOValue.data.GreaterThanMinusFiveWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prVsPOValue.data.GreaterThanMinusSixWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prVsPOValue.data.GreaterThanMinusSevenWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prVsPOValue.data.GreaterThanMinusEightWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.prVsPOValue.data.LessThanEightWeeks),
                string.Format("{0:n0}", data.kpi.other.prVsPOValue.data.Total)
            };
            TemplateFiveDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpi.other.Name,
                data.kpi.other.categoryNames[(int)Other.CategorNames.hotJobPrs],
                "$" + string.Format("{0:n}", data.kpi.other.hotJobPrs.data.TotalValue),
                "$" + string.Format("{0:n}", data.kpi.other.hotJobPrs.data.GreaterThanZeroWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.hotJobPrs.data.GreaterThanMinusOneWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.hotJobPrs.data.GreaterThanMinusTwoWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.hotJobPrs.data.GreaterThanMinusThreeWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.hotJobPrs.data.GreaterThanMinusFourWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.hotJobPrs.data.GreaterThanMinusFiveWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.hotJobPrs.data.GreaterThanMinusSixWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.hotJobPrs.data.GreaterThanMinusSevenWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.hotJobPrs.data.GreaterThanMinusEightWeeks),
                "$" + string.Format("{0:n}", data.kpi.other.hotJobPrs.data.LessThanEightWeeks),
                string.Format("{0:n0}", data.kpi.other.hotJobPrs.data.Total)
            };
            TemplateFiveDataGrid.Rows.Add(row);
        }









        /// <summary>
        /// Handles the event of when a cell in the Template One DataGridView is double clicked. The corresponding data will be loaded
        /// into the data viewer object.
        /// </summary>
        /// <param name="sender">the cell</param>
        /// <param name="e">the cell double click event</param>
        private void TemplateThreeDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(TemplateThreeDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == "0" || TemplateThreeDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == "$0.00")
            {
                MessageBox.Show("There is no data in this cell", "Data Timespan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            switch (e.RowIndex)
            {
                case 0: // 0 - 2 = Plan
                case 1:
                case 2:
                    HandlePlanDataTableLoading(e.RowIndex, e.ColumnIndex);
                    break;
                case 3: // Purch
                    HandlePurchDataTableLoading(e.RowIndex, e.ColumnIndex);
                    break;
                case 4: // 4 - 8 = Follow Up
                case 5:
                case 6:
                case 7:
                case 8:
                    HandleFollowUpDataTableLoading(e.RowIndex, e.ColumnIndex);
                    break;
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
            if (TemplateFourDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == "0" || TemplateFourDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == "$0.00")
            {
                MessageBox.Show("There is no data in this cell", "Data Timespan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            switch (e.RowIndex)
            {
                case 0: // 0 - 1 = Plan Two
                case 1:
                    break;
                case 2: // 2 - 4 = Purch Two
                case 3:
                case 4:
                    HandlePurchTwoDataTableLoading(e.RowIndex, e.ColumnIndex);
                    break;
                case 5: // 5 - 6 Purch Sub
                case 6:
                    HandlePurchSubDataTableLoading(e.RowIndex, e.ColumnIndex);
                    break;
                case 7: // Purch Total
                    HandlePurchTotalDataTableLoading(e.RowIndex, e.ColumnIndex);
                    break;
                case 8: // 8 - 9 = Purch Plan
                case 9:
                    HandlePurchPlanDataTableLoading(e.RowIndex, e.ColumnIndex);
                    break;
                case 10: // Purch Plan Total
                    break;
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
            if (TemplateFiveDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == "0" || TemplateFiveDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() == "$0.00")
            {
                MessageBox.Show("There is no data in this cell", "Data Timespan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            HandleOtherDataTableLoading(e.RowIndex, e.ColumnIndex);
        }








        /// <summary>
        /// Loads calls the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandlePlanDataTableLoading(int rowIndex, int columnIndex)
        {
            switch(rowIndex)
            {
                case 0: // PR Plan Date vs Current Plan Date
                    switch(columnIndex)
                    {
                        case 3: // <= -22 Days
                            KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable((int)TempThree.DataViews.Minus_TwentyTwo);
                            break;
                        case 4: // -(15 - 21) Days
                            KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable((int)TempThree.DataViews.Minus_Fifteen_TwentyOne);
                            break;
                        case 5: // -(8 - 14) Days
                            KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable((int)TempThree.DataViews.Minus_Eight_Fourteen);
                            break;
                        case 6: // -(1 - 7) Days
                            KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable((int)TempThree.DataViews.Minus_One_Seven);
                            break;
                        case 7: // 0 days
                            KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable((int)TempThree.DataViews.Zero);
                            break;
                        case 8: // 1 - 7 Days
                            KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable((int)TempThree.DataViews.One_Seven);
                            break;
                        case 9: // 8 - 14 Days
                            KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable((int)TempThree.DataViews.Eight_Fourteen);
                            break;
                        case 10: // 15 - 21 Days
                            KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable((int)TempThree.DataViews.Fifteen_TwentyOne);
                            break;
                        case 11: // >= 22 Days
                            KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable((int)TempThree.DataViews.TwentyTwo);
                            break;
                        case 12: // Total
                            KpiDataTableLoader.Plan.LoadPrPlanDateVsCurrentPlanDateDataTable((int)TempThree.DataViews.Total);
                            break;
                    }
                    break;
                case 1: // (Original Plan Date - 2nd Lvl Rel Date) vs Coded Lead-time
                    switch (columnIndex)
                    {
                        case 3: // <= -22 Days
                            KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.Minus_TwentyTwo);
                            break;
                        case 4: // -(15 - 21) Days
                            KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.Minus_Fifteen_TwentyOne);
                            break;
                        case 5: // -(8 - 14) Days
                            KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.Minus_Eight_Fourteen);
                            break;
                        case 6: // -(1 - 7) Days
                            KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.Minus_One_Seven);
                            break;
                        case 7: // 0 days
                            KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.Zero);
                            break;
                        case 8: // 1 - 7 Days
                            KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.One_Seven);
                            break;
                        case 9: // 8 - 14 Days
                            KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.Eight_Fourteen);
                            break;
                        case 10: // 15 - 21 Days
                            KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.Fifteen_TwentyOne);
                            break;
                        case 11: // >= 22 Days
                            KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.TwentyTwo);
                            break;
                        case 12: // Total
                            KpiDataTableLoader.Plan.LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.Total);
                            break;
                    }
                    break;
                case 2: // (Current Plan Date - 2nd Lvl Rel Date) vs Coded Lead-time
                    switch (columnIndex)
                    {
                        case 3: // <= -22 Days
                            KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.Minus_TwentyTwo);
                            break;
                        case 4: // -(15 - 21) Days
                            KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.Minus_Fifteen_TwentyOne);
                            break;
                        case 5: // -(8 - 14) Days
                            KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.Minus_Eight_Fourteen);
                            break;
                        case 6: // -(1 - 7) Days
                            KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.Minus_One_Seven);
                            break;
                        case 7: // 0 days
                            KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.Zero);
                            break;
                        case 8: // 1 - 7 Days
                            KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.One_Seven);
                            break;
                        case 9: // 8 - 14 Days
                            KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.Eight_Fourteen);
                            break;
                        case 10: // 15 - 21 Days
                            KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.Fifteen_TwentyOne);
                            break;
                        case 11: // >= 22 Days
                            KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.TwentyTwo);
                            break;
                        case 12: // Total
                            KpiDataTableLoader.Plan.LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable((int)TempThree.DataViews.Total);
                            break;
                    }
                    break;
            }
        }






        /// <summary>
        /// Loads calls the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandlePurchDataTableLoading(int rowIndex, int columnIndex)
        {
            switch (rowIndex)
            {
                case 3:
                    switch (columnIndex)
                    {
                        case 3: // <= -22 Days
                            KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable((int)TempThree.DataViews.Minus_TwentyTwo);
                            break;
                        case 4: // -(15 - 21) Days
                            KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable((int)TempThree.DataViews.Minus_Fifteen_TwentyOne);
                            break;
                        case 5: // -(8 - 14) Days
                            KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable((int)TempThree.DataViews.Minus_Eight_Fourteen);
                            break;
                        case 6: // -(1 - 7) Days
                            KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable((int)TempThree.DataViews.Minus_One_Seven);
                            break;
                        case 7: // 0 days
                            KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable((int)TempThree.DataViews.Zero);
                            break;
                        case 8: // 1 - 7 Days
                            KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable((int)TempThree.DataViews.One_Seven);
                            break;
                        case 9: // 8 - 14 Days
                            KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable((int)TempThree.DataViews.Eight_Fourteen);
                            break;
                        case 10: // 15 - 21 Days
                            KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable((int)TempThree.DataViews.Fifteen_TwentyOne);
                            break;
                        case 11: // >= 22 Days
                            KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable((int)TempThree.DataViews.TwentyTwo);
                            break;
                        case 12: // Total
                            KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable((int)TempThree.DataViews.Total);
                            break;
                        case 13: // Percent Unconfirmed
                            KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable((int)TempThree.DataViews.PercentUnconf);
                            break;
                    }
                    break;
            }
        }






        /// <summary>
        /// Loads calls the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandleFollowUpDataTableLoading(int rowIndex, int columnIndex)
        {
            switch(rowIndex)
            {
                case 4: // Initial Confirmation Date vs current Confirmation Date
                    switch (columnIndex)
                    {
                        case 3: // <= -22 Days
                            KpiDataTableLoader.FollowUp.LoadInitConfVsCurrConfDataTable((int)TempThree.DataViews.Minus_TwentyTwo);
                            break;
                        case 4: // -(15 - 21) Days
                            KpiDataTableLoader.FollowUp.LoadInitConfVsCurrConfDataTable((int)TempThree.DataViews.Minus_Fifteen_TwentyOne);
                            break;
                        case 5: // -(8 - 14) Days
                            KpiDataTableLoader.FollowUp.LoadInitConfVsCurrConfDataTable((int)TempThree.DataViews.Minus_Eight_Fourteen);
                            break;
                        case 6: // -(1 - 7) Days
                            KpiDataTableLoader.FollowUp.LoadInitConfVsCurrConfDataTable((int)TempThree.DataViews.Minus_One_Seven);
                            break;
                        case 7: // 0 days
                            KpiDataTableLoader.FollowUp.LoadInitConfVsCurrConfDataTable((int)TempThree.DataViews.Zero);
                            break;
                        case 8: // 1 - 7 Days
                            KpiDataTableLoader.FollowUp.LoadInitConfVsCurrConfDataTable((int)TempThree.DataViews.One_Seven);
                            break;
                        case 9: // 8 - 14 Days
                            KpiDataTableLoader.FollowUp.LoadInitConfVsCurrConfDataTable((int)TempThree.DataViews.Eight_Fourteen);
                            break;
                        case 10: // 15 - 21 Days
                            KpiDataTableLoader.FollowUp.LoadInitConfVsCurrConfDataTable((int)TempThree.DataViews.Fifteen_TwentyOne);
                            break;
                        case 11: // >= 22 Days
                            KpiDataTableLoader.FollowUp.LoadInitConfVsCurrConfDataTable((int)TempThree.DataViews.TwentyTwo);
                            break;
                        case 12: // Total
                            KpiDataTableLoader.FollowUp.LoadInitConfVsCurrConfDataTable((int)TempThree.DataViews.Total);
                            break;
                        case 13: // Percent Unconfirmed
                            KpiDataTableLoader.FollowUp.LoadInitConfVsCurrConfDataTable((int)TempThree.DataViews.PercentUnconf);
                            break;
                    }
                    break;
                case 5: // Final Confirmation Date vs Final Plan Date
                    switch (columnIndex)
                    {
                        case 3: // <= -22 Days
                            KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable((int)TempThree.DataViews.Minus_TwentyTwo);
                            break;
                        case 4: // -(15 - 21) Days
                            KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable((int)TempThree.DataViews.Minus_Fifteen_TwentyOne);
                            break;
                        case 5: // -(8 - 14) Days
                            KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable((int)TempThree.DataViews.Minus_Eight_Fourteen);
                            break;
                        case 6: // -(1 - 7) Days
                            KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable((int)TempThree.DataViews.Minus_One_Seven);
                            break;
                        case 7: // 0 days
                            KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable((int)TempThree.DataViews.Zero);
                            break;
                        case 8: // 1 - 7 Days
                            KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable((int)TempThree.DataViews.One_Seven);
                            break;
                        case 9: // 8 - 14 Days
                            KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable((int)TempThree.DataViews.Eight_Fourteen);
                            break;
                        case 10: // 15 - 21 Days
                            KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable((int)TempThree.DataViews.Fifteen_TwentyOne);
                            break;
                        case 11: // >= 22 Days
                            KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable((int)TempThree.DataViews.TwentyTwo);
                            break;
                        case 12: // Total
                            KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable((int)TempThree.DataViews.Total);
                            break;
                        case 13: // Percent Unconfirmed
                            KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable((int)TempThree.DataViews.PercentUnconf);
                            break;
                    }
                    break;
                case 6: // Receipt Date vs Current Plan Date
                    switch (columnIndex)
                    {
                        case 3: // <= -22 Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable((int)TempThree.DataViews.Minus_TwentyTwo);
                            break;
                        case 4: // -(15 - 21) Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable((int)TempThree.DataViews.Minus_Fifteen_TwentyOne);
                            break;
                        case 5: // -(8 - 14) Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable((int)TempThree.DataViews.Minus_Eight_Fourteen);
                            break;
                        case 6: // -(1 - 7) Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable((int)TempThree.DataViews.Minus_One_Seven);
                            break;
                        case 7: // 0 days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable((int)TempThree.DataViews.Zero);
                            break;
                        case 8: // 1 - 7 Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable((int)TempThree.DataViews.One_Seven);
                            break;
                        case 9: // 8 - 14 Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable((int)TempThree.DataViews.Eight_Fourteen);
                            break;
                        case 10: // 15 - 21 Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable((int)TempThree.DataViews.Fifteen_TwentyOne);
                            break;
                        case 11: // >= 22 Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable((int)TempThree.DataViews.TwentyTwo);
                            break;
                        case 12: // Total
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable((int)TempThree.DataViews.Total);
                            break;
                    }
                    break;
                case 7: // Receipt Date vs Original Confirmation Date
                    switch (columnIndex)
                    {
                        case 3: // <= -22 Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable((int)TempThree.DataViews.Minus_TwentyTwo);
                            break;
                        case 4: // -(15 - 21) Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable((int)TempThree.DataViews.Minus_Fifteen_TwentyOne);
                            break;
                        case 5: // -(8 - 14) Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable((int)TempThree.DataViews.Minus_Eight_Fourteen);
                            break;
                        case 6: // -(1 - 7) Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable((int)TempThree.DataViews.Minus_One_Seven);
                            break;
                        case 7: // 0 days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable((int)TempThree.DataViews.Zero);
                            break;
                        case 8: // 1 - 7 Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable((int)TempThree.DataViews.One_Seven);
                            break;
                        case 9: // 8 - 14 Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable((int)TempThree.DataViews.Eight_Fourteen);
                            break;
                        case 10: // 15 - 21 Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable((int)TempThree.DataViews.Fifteen_TwentyOne);
                            break;
                        case 11: // >= 22 Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable((int)TempThree.DataViews.TwentyTwo);
                            break;
                        case 12: // Total
                            KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable((int)TempThree.DataViews.Total);
                            break;
                        case 13: // Percent Unconfirmed
                            KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable((int)TempThree.DataViews.PercentUnconf);
                            break;
                    }
                    break;
                case 8: // Receipt Date vs Current Confirmation Date
                    switch (columnIndex)
                    {
                        case 3: // <= -22 Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable((int)TempThree.DataViews.Minus_TwentyTwo);
                            break;
                        case 4: // -(15 - 21) Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable((int)TempThree.DataViews.Minus_Fifteen_TwentyOne);
                            break;
                        case 5: // -(8 - 14) Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable((int)TempThree.DataViews.Minus_Eight_Fourteen);
                            break;
                        case 6: // -(1 - 7) Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable((int)TempThree.DataViews.Minus_One_Seven);
                            break;
                        case 7: // 0 days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable((int)TempThree.DataViews.Zero);
                            break;
                        case 8: // 1 - 7 Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable((int)TempThree.DataViews.One_Seven);
                            break;
                        case 9: // 8 - 14 Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable((int)TempThree.DataViews.Eight_Fourteen);
                            break;
                        case 10: // 15 - 21 Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable((int)TempThree.DataViews.Fifteen_TwentyOne);
                            break;
                        case 11: // >= 22 Days
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable((int)TempThree.DataViews.TwentyTwo);
                            break;
                        case 12: // Total
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable((int)TempThree.DataViews.Total);
                            break;
                        case 13: // Percent Unconfirmed
                            KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable((int)TempThree.DataViews.PercentUnconf);
                            break;
                    }
                    break;
            }
        }






        /// <summary>
        /// Loads calls the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandlePurchTwoDataTableLoading(int rowIndex, int columnIndex)
        {
            switch (rowIndex)
            {
                case 2: // PR 2nd Lvl Release Date vs PO Creation Date
                    switch (columnIndex)
                    {
                        case 3: // <= 0 Days
                            KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable((int)TempFour.DataViews.LessThanZero);
                            break;
                        case 4: // 1 - 3 Days
                            KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable((int)TempFour.DataViews.One_Three);
                            break;
                        case 5: // 4 - 7 Days
                            KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable((int)TempFour.DataViews.Four_Seven);
                            break;
                        case 6: // 8 - 14 Days
                            KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable((int)TempFour.DataViews.Eight_Fourteen);
                            break;
                        case 7: // 15 - 21 Days
                            KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable((int)TempFour.DataViews.Fifteen_TwentyOne);
                            break;
                        case 8: // 22 - 28 Days
                            KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable((int)TempFour.DataViews.TwentyTwo_TwentyEight);
                            break;
                        case 9: // 29 - 35 Days
                            KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable((int)TempFour.DataViews.TwentyNine_ThirtyFive);
                            break;
                        case 10: // 36 - 42 Days
                            KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable((int)TempFour.DataViews.ThirtySix_FourtyTwo);
                            break;
                        case 11: // 43 - 49 Days
                            KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable((int)TempFour.DataViews.FourtyThree_FourtyNine);
                            break;
                        case 12: // 50 - 56 Days
                            KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable((int)TempFour.DataViews.Fifty_FiftySix);
                            break;
                        case 13: // 57+ Days
                            KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable((int)TempFour.DataViews.GreaterThanEqualFiftySeven);
                            break;
                        case 14: // Total
                            KpiDataTableLoader.PurchTwo.LoadPr2ndLvlRelVsPOCreationDataTable((int)TempFour.DataViews.Total);
                            break;
                    }
                    break;
                case 3: // PO Creation Date vs PO Release Date
                    switch (columnIndex)
                    {
                        case 3: // <= 0 Days
                            KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable((int)TempFour.DataViews.LessThanZero);
                            break;
                        case 4: // 1 - 3 Days
                            KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable((int)TempFour.DataViews.One_Three);
                            break;
                        case 5: // 4 - 7 Days
                            KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable((int)TempFour.DataViews.Four_Seven);
                            break;
                        case 6: // 8 - 14 Days
                            KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable((int)TempFour.DataViews.Eight_Fourteen);
                            break;
                        case 7: // 15 - 21 Days
                            KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable((int)TempFour.DataViews.Fifteen_TwentyOne);
                            break;
                        case 8: // 22 - 28 Days
                            KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable((int)TempFour.DataViews.TwentyTwo_TwentyEight);
                            break;
                        case 9: // 29 - 35 Days
                            KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable((int)TempFour.DataViews.TwentyNine_ThirtyFive);
                            break;
                        case 10: // 36 - 42 Days
                            KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable((int)TempFour.DataViews.ThirtySix_FourtyTwo);
                            break;
                        case 11: // 43 - 49 Days
                            KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable((int)TempFour.DataViews.FourtyThree_FourtyNine);
                            break;
                        case 12: // 50 - 56 Days
                            KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable((int)TempFour.DataViews.Fifty_FiftySix);
                            break;
                        case 13: // 57+ Days
                            KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable((int)TempFour.DataViews.GreaterThanEqualFiftySeven);
                            break;
                        case 14: // Total
                            KpiDataTableLoader.PurchTwo.LoadPoCreationVsPoReleaseDataTable((int)TempFour.DataViews.Total);
                            break;
                    }
                    break;
                case 4: // PO Rleaese Date vs PO Confirmation Date
                    switch (columnIndex)
                    {
                        case 3: // <= 0 Days
                            KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable((int)TempFour.DataViews.LessThanZero);
                            break;
                        case 4: // 1 - 3 Days
                            KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable((int)TempFour.DataViews.One_Three);
                            break;
                        case 5: // 4 - 7 Days
                            KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable((int)TempFour.DataViews.Four_Seven);
                            break;
                        case 6: // 8 - 14 Days
                            KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable((int)TempFour.DataViews.Eight_Fourteen);
                            break;
                        case 7: // 15 - 21 Days
                            KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable((int)TempFour.DataViews.Fifteen_TwentyOne);
                            break;
                        case 8: // 22 - 28 Days
                            KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable((int)TempFour.DataViews.TwentyTwo_TwentyEight);
                            break;
                        case 9: // 29 - 35 Days
                            KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable((int)TempFour.DataViews.TwentyNine_ThirtyFive);
                            break;
                        case 10: // 36 - 42 Days
                            KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable((int)TempFour.DataViews.ThirtySix_FourtyTwo);
                            break;
                        case 11: // 43 - 49 Days
                            KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable((int)TempFour.DataViews.FourtyThree_FourtyNine);
                            break;
                        case 12: // 50 - 56 Days
                            KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable((int)TempFour.DataViews.Fifty_FiftySix);
                            break;
                        case 13: // 57+ Days
                            KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable((int)TempFour.DataViews.GreaterThanEqualFiftySeven);
                            break;
                        case 14: // Total
                            KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable((int)TempFour.DataViews.Total);
                            break;
                        case 15: // Percent Unconfirmed
                            KpiDataTableLoader.PurchTwo.LoadPoReleaseVsPoConfDataTable((int)TempFour.DataViews.PercentUnconf);
                            break;
                    }
                    break;
            }
        }






        /// <summary>
        /// Loads calls the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandlePurchSubDataTableLoading(int rowIndex, int columnIndex)
        {
            switch (rowIndex)
            {
                case 5: // PR Release Date vs PO Release Date
                    switch (columnIndex)
                    {
                        case 3: // <= 0 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.LessThanZero);
                            break;
                        case 4: // 1 - 3 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.One_Three);
                            break;
                        case 5: // 4 - 7 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.Four_Seven);
                            break;
                        case 6: // 8 - 14 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.Eight_Fourteen);
                            break;
                        case 7: // 15 - 21 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.Fifteen_TwentyOne);
                            break;
                        case 8: // 22 - 28 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.TwentyTwo_TwentyEight);
                            break;
                        case 9: // 29 - 35 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.TwentyNine_ThirtyFive);
                            break;
                        case 10: // 36 - 42 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.ThirtySix_FourtyTwo);
                            break;
                        case 11: // 43 - 49 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.FourtyThree_FourtyNine);
                            break;
                        case 12: // 50 - 56 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.Fifty_FiftySix);
                            break;
                        case 13: // 57+ Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.GreaterThanEqualFiftySeven);
                            break;
                        case 14: // Total
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.Total);
                            break;
                    }
                    break;
                case 6: // PO Creation Date vs Confirmation Entry Date
                    switch (columnIndex)
                    {
                        case 3: // <= 0 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.LessThanZero);
                            break;
                        case 4: // 1 - 3 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.One_Three);
                            break;
                        case 5: // 4 - 7 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.Four_Seven);
                            break;
                        case 6: // 8 - 14 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.Eight_Fourteen);
                            break;
                        case 7: // 15 - 21 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.Fifteen_TwentyOne);
                            break;
                        case 8: // 22 - 28 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.TwentyTwo_TwentyEight);
                            break;
                        case 9: // 29 - 35 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.TwentyNine_ThirtyFive);
                            break;
                        case 10: // 36 - 42 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.ThirtySix_FourtyTwo);
                            break;
                        case 11: // 43 - 49 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.FourtyThree_FourtyNine);
                            break;
                        case 12: // 50 - 56 Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.Fifty_FiftySix);
                            break;
                        case 13: // 57+ Days
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.GreaterThanEqualFiftySeven);
                            break;
                        case 14: // Total
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.Total);
                            break;
                        case 15: // Percent Unconfirmed
                            KpiDataTableLoader.PurchSub.LoadPrRelVsPoRelDataTable((int)TempFour.DataViews.PercentUnconf);
                            break;
                    }
                    break;
            }
        }






        /// <summary>
        /// Loads calls the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandlePurchTotalDataTableLoading(int rowIndex, int columnIndex)
        {
            switch (rowIndex)
            {
                case 7: // Pr Release Date to Confirmation Entry Date
                    switch (columnIndex)
                    {
                        case 3: // <= 0 Days
                            KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable((int)TempFour.DataViews.LessThanZero);
                            break;
                        case 4: // 1 - 3 Days
                            KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable((int)TempFour.DataViews.One_Three);
                            break;
                        case 5: // 4 - 7 Days
                            KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable((int)TempFour.DataViews.Four_Seven);
                            break;
                        case 6: // 8 - 14 Days
                            KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable((int)TempFour.DataViews.Eight_Fourteen);
                            break;
                        case 7: // 15 - 21 Days
                            KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable((int)TempFour.DataViews.Fifteen_TwentyOne);
                            break;
                        case 8: // 22 - 28 Days
                            KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable((int)TempFour.DataViews.TwentyTwo_TwentyEight);
                            break;
                        case 9: // 29 - 35 Days
                            KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable((int)TempFour.DataViews.TwentyNine_ThirtyFive);
                            break;
                        case 10: // 36 - 42 Days
                            KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable((int)TempFour.DataViews.ThirtySix_FourtyTwo);
                            break;
                        case 11: // 43 - 49 Days
                            KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable((int)TempFour.DataViews.FourtyThree_FourtyNine);
                            break;
                        case 12: // 50 - 56 Days
                            KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable((int)TempFour.DataViews.Fifty_FiftySix);
                            break;
                        case 13: // 57+ Days
                            KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable((int)TempFour.DataViews.GreaterThanEqualFiftySeven);
                            break;
                        case 14: // Total
                            KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable((int)TempFour.DataViews.Total);
                            break;
                        case 15: // Percent Unconfirmed
                            KpiDataTableLoader.PurchTotal.LoadPrReleaseConfEntryDataTable((int)TempFour.DataViews.PercentUnconf);
                            break;
                    }
                    break;
            }
        }






        /// <summary>
        /// Loads calls the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandlePurchPlanDataTableLoading(int rowIndex, int columnIndex)
        {
            switch (rowIndex)
            {
                case 8: // PO Release vs PR Delivery Date
                    switch (columnIndex)
                    {
                        case 3: // <= 0 Days
                            KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable((int)TempFour.DataViews.LessThanZero);
                            break;
                        case 4: // 1 - 3 Days
                            KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable((int)TempFour.DataViews.One_Three);
                            break;
                        case 5: // 4 - 7 Days
                            KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable((int)TempFour.DataViews.Four_Seven);
                            break;
                        case 6: // 8 - 14 Days
                            KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable((int)TempFour.DataViews.Eight_Fourteen);
                            break;
                        case 7: // 15 - 21 Days
                            KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable((int)TempFour.DataViews.Fifteen_TwentyOne);
                            break;
                        case 8: // 22 - 28 Days
                            KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable((int)TempFour.DataViews.TwentyTwo_TwentyEight);
                            break;
                        case 9: // 29 - 35 Days
                            KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable((int)TempFour.DataViews.TwentyNine_ThirtyFive);
                            break;
                        case 10: // 36 - 42 Days
                            KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable((int)TempFour.DataViews.ThirtySix_FourtyTwo);
                            break;
                        case 11: // 43 - 49 Days
                            KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable((int)TempFour.DataViews.FourtyThree_FourtyNine);
                            break;
                        case 12: // 50 - 56 Days
                            KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable((int)TempFour.DataViews.Fifty_FiftySix);
                            break;
                        case 13: // 57+ Days
                            KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable((int)TempFour.DataViews.GreaterThanEqualFiftySeven);
                            break;
                        case 14: // Total
                            KpiDataTableLoader.PurchPlan.LoadPoRelVsPrDelDateDataTable((int)TempFour.DataViews.Total);
                            break;
                    }
                    break;
                case 9: // PR 2nd Lvl Release Date to Original Planned Delivery Date
                    switch (columnIndex)
                    {
                        case 3: // <= 0 Days
                            KpiDataTableLoader.PurchPlan.LoadPr2ndLvlRelOrigPlanDateDataTable((int)TempFour.DataViews.LessThanZero);
                            break;
                        case 4: // 1 - 3 Days
                            KpiDataTableLoader.PurchPlan.LoadPr2ndLvlRelOrigPlanDateDataTable((int)TempFour.DataViews.One_Three);
                            break;
                        case 5: // 4 - 7 Days
                            KpiDataTableLoader.PurchPlan.LoadPr2ndLvlRelOrigPlanDateDataTable((int)TempFour.DataViews.Four_Seven);
                            break;
                        case 6: // 8 - 14 Days
                            KpiDataTableLoader.PurchPlan.LoadPr2ndLvlRelOrigPlanDateDataTable((int)TempFour.DataViews.Eight_Fourteen);
                            break;
                        case 7: // 15 - 21 Days
                            KpiDataTableLoader.PurchPlan.LoadPr2ndLvlRelOrigPlanDateDataTable((int)TempFour.DataViews.Fifteen_TwentyOne);
                            break;
                        case 8: // 22 - 28 Days
                            KpiDataTableLoader.PurchPlan.LoadPr2ndLvlRelOrigPlanDateDataTable((int)TempFour.DataViews.TwentyTwo_TwentyEight);
                            break;
                        case 9: // 29 - 35 Days
                            KpiDataTableLoader.PurchPlan.LoadPr2ndLvlRelOrigPlanDateDataTable((int)TempFour.DataViews.TwentyNine_ThirtyFive);
                            break;
                        case 10: // 36 - 42 Days
                            KpiDataTableLoader.PurchPlan.LoadPr2ndLvlRelOrigPlanDateDataTable((int)TempFour.DataViews.ThirtySix_FourtyTwo);
                            break;
                        case 11: // 43 - 49 Days
                            KpiDataTableLoader.PurchPlan.LoadPr2ndLvlRelOrigPlanDateDataTable((int)TempFour.DataViews.FourtyThree_FourtyNine);
                            break;
                        case 12: // 50 - 56 Days
                            KpiDataTableLoader.PurchPlan.LoadPr2ndLvlRelOrigPlanDateDataTable((int)TempFour.DataViews.Fifty_FiftySix);
                            break;
                        case 13: // 57+ Days
                            KpiDataTableLoader.PurchPlan.LoadPr2ndLvlRelOrigPlanDateDataTable((int)TempFour.DataViews.GreaterThanEqualFiftySeven);
                            break;
                        case 14: // Total
                            KpiDataTableLoader.PurchPlan.LoadPr2ndLvlRelOrigPlanDateDataTable((int)TempFour.DataViews.Total);
                            break;
                    }
                    break;
            }
        }





        /// <summary>
        /// Loads calls the data table loading funciton depending on the particular cell click under a particular KPA
        /// </summary>
        /// <param name="rowIndex">The row index of the clicked cell</param>
        /// <param name="columnIndex">The column index of the clicked cell</param>
        private void HandleOtherDataTableLoading(int rowIndex, int columnIndex)
        {
            switch (rowIndex)
            {
                case 0: // PRs Created
                    switch (columnIndex)
                    {
                        case 3: // >= 0 Weeks
                            KpiDataTableLoader.Other.LoadPrsCreated((int)TempFive.DataViews.GreaterThanZeroWeeks);
                            break;
                        case 4: // >= -1 Weeks
                            KpiDataTableLoader.Other.LoadPrsCreated((int)TempFive.DataViews.GreaterThanMinusOneWeeks);
                            break;
                        case 5: // >= -2 Weeks
                            KpiDataTableLoader.Other.LoadPrsCreated((int)TempFive.DataViews.GreaterThanMinusTwoWeeks);
                            break;
                        case 6: // >= -3 Weeks
                            KpiDataTableLoader.Other.LoadPrsCreated((int)TempFive.DataViews.GreaterThanMinusThreeWeeks);
                            break;
                        case 7: // >= -4 Weeks
                            KpiDataTableLoader.Other.LoadPrsCreated((int)TempFive.DataViews.GreaterThanMinusFourWeeks);
                            break;
                        case 8: // >= -5 Weeks
                            KpiDataTableLoader.Other.LoadPrsCreated((int)TempFive.DataViews.GreaterThanMinusFiveWeeks);
                            break;
                        case 9: // >= -6 Weeks
                            KpiDataTableLoader.Other.LoadPrsCreated((int)TempFive.DataViews.GreaterThanMinusSixWeeks);
                            break;
                        case 10: // >= -7 Weeks
                            KpiDataTableLoader.Other.LoadPrsCreated((int)TempFive.DataViews.GreaterThanMinusSevenWeeks);
                            break;
                        case 11: // >= -8 Weeks
                            KpiDataTableLoader.Other.LoadPrsCreated((int)TempFive.DataViews.GreaterThanMinusEightWeeks);
                            break;
                        case 12: // < -8 Weeks
                            KpiDataTableLoader.Other.LoadPrsCreated((int)TempFive.DataViews.LessThanEightWeeks);
                            break;
                        case 13: // Total
                            KpiDataTableLoader.Other.LoadPrsCreated((int)TempFive.DataViews.Total);
                            break;
                    }
                    break;
                case 1: // PRs Released
                    switch (columnIndex)
                    {
                        case 3: // >= 0 Weeks
                            KpiDataTableLoader.Other.LoadPrsReleased((int)TempFive.DataViews.GreaterThanZeroWeeks);
                            break;
                        case 4: // >= -1 Weeks
                            KpiDataTableLoader.Other.LoadPrsReleased((int)TempFive.DataViews.GreaterThanMinusOneWeeks);
                            break;
                        case 5: // >= -2 Weeks
                            KpiDataTableLoader.Other.LoadPrsReleased((int)TempFive.DataViews.GreaterThanMinusTwoWeeks);
                            break;
                        case 6: // >= -3 Weeks
                            KpiDataTableLoader.Other.LoadPrsReleased((int)TempFive.DataViews.GreaterThanMinusThreeWeeks);
                            break;
                        case 7: // >= -4 Weeks
                            KpiDataTableLoader.Other.LoadPrsReleased((int)TempFive.DataViews.GreaterThanMinusFourWeeks);
                            break;
                        case 8: // >= -5 Weeks
                            KpiDataTableLoader.Other.LoadPrsReleased((int)TempFive.DataViews.GreaterThanMinusFiveWeeks);
                            break;
                        case 9: // >= -6 Weeks
                            KpiDataTableLoader.Other.LoadPrsReleased((int)TempFive.DataViews.GreaterThanMinusSixWeeks);
                            break;
                        case 10: // >= -7 Weeks
                            KpiDataTableLoader.Other.LoadPrsReleased((int)TempFive.DataViews.GreaterThanMinusSevenWeeks);
                            break;
                        case 11: // >= -8 Weeks
                            KpiDataTableLoader.Other.LoadPrsReleased((int)TempFive.DataViews.GreaterThanMinusEightWeeks);
                            break;
                        case 12: // < -8 Weeks
                            KpiDataTableLoader.Other.LoadPrsReleased((int)TempFive.DataViews.LessThanEightWeeks);
                            break;
                        case 13: // Total
                            KpiDataTableLoader.Other.LoadPrsReleased((int)TempFive.DataViews.Total);
                            break;
                    }
                    break;
                case 2: // Total Spend
                    switch (columnIndex)
                    {
                        case 3: // >= 0 Weeks
                            KpiDataTableLoader.Other.LoadTotalSpend((int)TempFive.DataViews.GreaterThanZeroWeeks);
                            break;
                        case 4: // >= -1 Weeks
                            KpiDataTableLoader.Other.LoadTotalSpend((int)TempFive.DataViews.GreaterThanMinusOneWeeks);
                            break;
                        case 5: // >= -2 Weeks
                            KpiDataTableLoader.Other.LoadTotalSpend((int)TempFive.DataViews.GreaterThanMinusTwoWeeks);
                            break;
                        case 6: // >= -3 Weeks
                            KpiDataTableLoader.Other.LoadTotalSpend((int)TempFive.DataViews.GreaterThanMinusThreeWeeks);
                            break;
                        case 7: // >= -4 Weeks
                            KpiDataTableLoader.Other.LoadTotalSpend((int)TempFive.DataViews.GreaterThanMinusFourWeeks);
                            break;
                        case 8: // >= -5 Weeks
                            KpiDataTableLoader.Other.LoadTotalSpend((int)TempFive.DataViews.GreaterThanMinusFiveWeeks);
                            break;
                        case 9: // >= -6 Weeks
                            KpiDataTableLoader.Other.LoadTotalSpend((int)TempFive.DataViews.GreaterThanMinusSixWeeks);
                            break;
                        case 10: // >= -7 Weeks
                            KpiDataTableLoader.Other.LoadTotalSpend((int)TempFive.DataViews.GreaterThanMinusSevenWeeks);
                            break;
                        case 11: // >= -8 Weeks
                            KpiDataTableLoader.Other.LoadTotalSpend((int)TempFive.DataViews.GreaterThanMinusEightWeeks);
                            break;
                        case 12: // < -8 Weeks
                            KpiDataTableLoader.Other.LoadTotalSpend((int)TempFive.DataViews.LessThanEightWeeks);
                            break;
                        case 13: // Total
                            KpiDataTableLoader.Other.LoadTotalSpend((int)TempFive.DataViews.Total);
                            break;
                    }
                    break;
                case 3: // PR Value vs PO Value
                    switch (columnIndex)
                    {
                        case 3: // >= 0 Weeks
                            KpiDataTableLoader.Other.LoadPrVsPoValue((int)TempFive.DataViews.GreaterThanZeroWeeks);
                            break;
                        case 4: // >= -1 Weeks
                            KpiDataTableLoader.Other.LoadPrVsPoValue((int)TempFive.DataViews.GreaterThanMinusOneWeeks);
                            break;
                        case 5: // >= -2 Weeks
                            KpiDataTableLoader.Other.LoadPrVsPoValue((int)TempFive.DataViews.GreaterThanMinusTwoWeeks);
                            break;
                        case 6: // >= -3 Weeks
                            KpiDataTableLoader.Other.LoadPrVsPoValue((int)TempFive.DataViews.GreaterThanMinusThreeWeeks);
                            break;
                        case 7: // >= -4 Weeks
                            KpiDataTableLoader.Other.LoadPrVsPoValue((int)TempFive.DataViews.GreaterThanMinusFourWeeks);
                            break;
                        case 8: // >= -5 Weeks
                            KpiDataTableLoader.Other.LoadPrVsPoValue((int)TempFive.DataViews.GreaterThanMinusFiveWeeks);
                            break;
                        case 9: // >= -6 Weeks
                            KpiDataTableLoader.Other.LoadPrVsPoValue((int)TempFive.DataViews.GreaterThanMinusSixWeeks);
                            break;
                        case 10: // >= -7 Weeks
                            KpiDataTableLoader.Other.LoadPrVsPoValue((int)TempFive.DataViews.GreaterThanMinusSevenWeeks);
                            break;
                        case 11: // >= -8 Weeks
                            KpiDataTableLoader.Other.LoadPrVsPoValue((int)TempFive.DataViews.GreaterThanMinusEightWeeks);
                            break;
                        case 12: // < -8 Weeks
                            KpiDataTableLoader.Other.LoadPrVsPoValue((int)TempFive.DataViews.LessThanEightWeeks);
                            break;
                        case 13: // Total
                            KpiDataTableLoader.Other.LoadPrVsPoValue((int)TempFive.DataViews.Total);
                            break;
                    }
                    break;
                case 4: // Hot Job PRs 
                    switch (columnIndex)
                    {
                        case 3: // >= 0 Weeks
                            KpiDataTableLoader.Other.LoadHotJobPrs((int)TempFive.DataViews.GreaterThanZeroWeeks);
                            break;
                        case 4: // >= -1 Weeks
                            KpiDataTableLoader.Other.LoadHotJobPrs((int)TempFive.DataViews.GreaterThanMinusOneWeeks);
                            break;
                        case 5: // >= -2 Weeks
                            KpiDataTableLoader.Other.LoadHotJobPrs((int)TempFive.DataViews.GreaterThanMinusTwoWeeks);
                            break;
                        case 6: // >= -3 Weeks
                            KpiDataTableLoader.Other.LoadHotJobPrs((int)TempFive.DataViews.GreaterThanMinusThreeWeeks);
                            break;
                        case 7: // >= -4 Weeks
                            KpiDataTableLoader.Other.LoadHotJobPrs((int)TempFive.DataViews.GreaterThanMinusFourWeeks);
                            break;
                        case 8: // >= -5 Weeks
                            KpiDataTableLoader.Other.LoadHotJobPrs((int)TempFive.DataViews.GreaterThanMinusFiveWeeks);
                            break;
                        case 9: // >= -6 Weeks
                            KpiDataTableLoader.Other.LoadHotJobPrs((int)TempFive.DataViews.GreaterThanMinusSixWeeks);
                            break;
                        case 10: // >= -7 Weeks
                            KpiDataTableLoader.Other.LoadHotJobPrs((int)TempFive.DataViews.GreaterThanMinusSevenWeeks);
                            break;
                        case 11: // >= -8 Weeks
                            KpiDataTableLoader.Other.LoadHotJobPrs((int)TempFive.DataViews.GreaterThanMinusEightWeeks);
                            break;
                        case 12: // < -8 Weeks
                            KpiDataTableLoader.Other.LoadHotJobPrs((int)TempFive.DataViews.LessThanEightWeeks);
                            break;
                        case 13: // Total
                            KpiDataTableLoader.Other.LoadHotJobPrs((int)TempFive.DataViews.Total);
                            break;
                    }
                    break;
            }
        }
    }
}
