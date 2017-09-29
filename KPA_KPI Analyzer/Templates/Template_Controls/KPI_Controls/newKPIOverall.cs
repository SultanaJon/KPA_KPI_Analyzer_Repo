using KPA_KPI_Analyzer.KPA_KPI_Overall;
using KPA_KPI_Analyzer.KPA_KPI_Overall.KPI_Sections;
using System;
using System.Drawing;
using System.Windows.Forms;

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
                string.Format("{0:n0}", data.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.greaterThanEqualFiftySeven),
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
                string.Format("{0:n0}", data.kpi.purchTwo.poCreationVsPORel.data.greaterThanEqualFiftySeven),
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
                string.Format("{0:n0}", data.kpi.purchTwo.poRelVsPOConf.data.greaterThanEqualFiftySeven),
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
                string.Format("{0:n0}", data.kpi.purchSub.prRelVsPORel.data.greaterThanEqualFiftySeven),
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
                string.Format("{0:n0}", data.kpi.purchSub.poCreateVsConfEntry.data.greaterThanEqualFiftySeven),
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
                string.Format("{0:n0}", data.kpi.purchTotal.prRelConfEntry.data.greaterThanEqualFiftySeven),
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
                string.Format("{0:n0}", data.kpi.purchPlan.poRelVsPRDelDate.data.greaterThanEqualFiftySeven),
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
                string.Format("{0:n0}", data.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.greaterThanEqualFiftySeven),
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
    }
}
