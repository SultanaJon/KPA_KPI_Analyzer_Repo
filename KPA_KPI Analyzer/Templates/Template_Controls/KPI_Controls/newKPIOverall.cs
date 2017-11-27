using KPA_KPI_Analyzer.DataLoading.KPI_Data.DataTableLoader;
using KPA_KPI_Analyzer.KPA_KPI_Overall;
using KPA_KPI_Analyzer.KPA_KPI_Overall.KPI_Sections;
using KPA_KPI_Analyzer.Values;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPI_Controls
{
    public partial class NewKPIOverall : UserControl
    {
        private Overall data;


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
            PercentUnconf
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
        public NewKPIOverall(Overall _data)
        {
            InitializeComponent();
            ApplyDataGridStyles();
            data = _data;


            Globals.CurrPerformance = "KPI";

            if (Globals.FocusedCountry == StringUtils.Country.UnitedStates)
                Globals.CurrCountry = StringUtils.countries[(int)StringUtils.Country.UnitedStates];
            else
                Globals.CurrCountry = StringUtils.countries[(int)StringUtils.Country.Mexico];
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
            string[] row = new string[]{
                data.kpi.plan.Name,
                data.kpi.plan.categoryNames[(int)Plan.CategorNames.currPlanVsPrPlanDate],
                string.Format("{0:n}", data.kpi.plan.currPlanDateVsPrPlanDate.data.Average),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateVsPrPlanDate.data.Minus_TwentyTwo),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateVsPrPlanDate.data.Minus_Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateVsPrPlanDate.data.Minus_Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateVsPrPlanDate.data.Minus_One_Seven),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateVsPrPlanDate.data.Zero),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateVsPrPlanDate.data.One_Seven),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateVsPrPlanDate.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateVsPrPlanDate.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateVsPrPlanDate.data.TwentyTwo),
                string.Format("{0:n0}", data.kpi.plan.currPlanDateVsPrPlanDate.data.Total)
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
                data.kpi.followUp.categoryNames[(int)FollowUp.CategorNames.CurrConfVsInitConf],
                string.Format("{0:n}", data.kpi.followUp.currConfVsInitConf.data.Average),
                string.Format("{0:n0}", data.kpi.followUp.currConfVsInitConf.data.Minus_TwentyTwo),
                string.Format("{0:n0}", data.kpi.followUp.currConfVsInitConf.data.Minus_Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.followUp.currConfVsInitConf.data.Minus_Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.followUp.currConfVsInitConf.data.Minus_One_Seven),
                string.Format("{0:n0}", data.kpi.followUp.currConfVsInitConf.data.Zero),
                string.Format("{0:n0}", data.kpi.followUp.currConfVsInitConf.data.One_Seven),
                string.Format("{0:n0}", data.kpi.followUp.currConfVsInitConf.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.followUp.currConfVsInitConf.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.followUp.currConfVsInitConf.data.TwentyTwo),
                string.Format("{0:n0}", data.kpi.followUp.currConfVsInitConf.data.Total),
                string.Format("{0:n}", data.kpi.followUp.currConfVsInitConf.data.PercentUnconf + "%")

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

            string[] row = new string[]{
                data.kpi.planTwo.Name,
                data.kpi.planTwo.categoryNames[(int)PlanTwo.CategoryNames.materialDueOrigPlanDate],
                string.Format("{0:n}", data.kpi.planTwo.materialDueOrigPlanDate.data.Average),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueOrigPlanDate.data.LessThanZero),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueOrigPlanDate.data.One_Three),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueOrigPlanDate.data.Four_Seven),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueOrigPlanDate.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueOrigPlanDate.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueOrigPlanDate.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueOrigPlanDate.data.TwentyNine_ThirtyFive),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueOrigPlanDate.data.ThirtySix_FourtyTwo),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueOrigPlanDate.data.FourtyThree_FourtyNine),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueOrigPlanDate.data.Fifty_FiftySix),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueOrigPlanDate.data.GreaterThanEqualFiftySeven),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueOrigPlanDate.data.Total)
            };
            TemplateFourDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpi.planTwo.Name,
                data.kpi.planTwo.categoryNames[(int)PlanTwo.CategoryNames.materialDueFinalPlanDate],
                string.Format("{0:n}", data.kpi.planTwo.materialDueFinalPlanDate.data.Average),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueFinalPlanDate.data.LessThanZero),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueFinalPlanDate.data.One_Three),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueFinalPlanDate.data.Four_Seven),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueFinalPlanDate.data.Eight_Fourteen),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueFinalPlanDate.data.Fifteen_TwentyOne),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueFinalPlanDate.data.TwentyTwo_TwentyEight),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueFinalPlanDate.data.TwentyNine_ThirtyFive),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueFinalPlanDate.data.ThirtySix_FourtyTwo),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueFinalPlanDate.data.FourtyThree_FourtyNine),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueFinalPlanDate.data.Fifty_FiftySix),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueFinalPlanDate.data.GreaterThanEqualFiftySeven),
                string.Format("{0:n0}", data.kpi.planTwo.materialDueFinalPlanDate.data.Total)
            };
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
                string.Format("{0:n0}", data.kpi.other.prsCreated.data.GreaterThanZeroWeeks),
                string.Format("{0:n0}", data.kpi.other.prsCreated.data.GreaterThanMinusOneWeeks),
                string.Format("{0:n0}", data.kpi.other.prsCreated.data.GreaterThanMinusTwoWeeks),
                string.Format("{0:n0}", data.kpi.other.prsCreated.data.GreaterThanMinusThreeWeeks),
                string.Format("{0:n0}", data.kpi.other.prsCreated.data.GreaterThanMinusFourWeeks),
                string.Format("{0:n0}", data.kpi.other.prsCreated.data.GreaterThanMinusFiveWeeks),
                string.Format("{0:n0}", data.kpi.other.prsCreated.data.GreaterThanMinusSixWeeks),
                string.Format("{0:n0}", data.kpi.other.prsCreated.data.GreaterThanMinusSevenWeeks),
                string.Format("{0:n0}", data.kpi.other.prsCreated.data.GreaterThanMinusEightWeeks),
                string.Format("{0:n0}", data.kpi.other.prsCreated.data.LessThanEightWeeks),
                string.Format("{0:n0}", data.kpi.other.prsCreated.data.Total)
            };
            TemplateFiveDataGrid.Rows.Add(row);

            row = new string[]{
                data.kpi.other.Name,
                data.kpi.other.categoryNames[(int)Other.CategorNames.prsReleased],
                "$" + string.Format("{0:n}", data.kpi.other.prsReleased.data.TotalValue),
                string.Format("{0:n0}", data.kpi.other.prsReleased.data.GreaterThanZeroWeeks),
                string.Format("{0:n0}", data.kpi.other.prsReleased.data.GreaterThanMinusOneWeeks),
                string.Format("{0:n0}", data.kpi.other.prsReleased.data.GreaterThanMinusTwoWeeks),
                string.Format("{0:n0}", data.kpi.other.prsReleased.data.GreaterThanMinusThreeWeeks),
                string.Format("{0:n0}", data.kpi.other.prsReleased.data.GreaterThanMinusFourWeeks),
                string.Format("{0:n0}", data.kpi.other.prsReleased.data.GreaterThanMinusFiveWeeks),
                string.Format("{0:n0}", data.kpi.other.prsReleased.data.GreaterThanMinusSixWeeks),
                string.Format("{0:n0}", data.kpi.other.prsReleased.data.GreaterThanMinusSevenWeeks),
                string.Format("{0:n0}", data.kpi.other.prsReleased.data.GreaterThanMinusEightWeeks),
                string.Format("{0:n0}", data.kpi.other.prsReleased.data.LessThanEightWeeks),
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
                string.Format("{0:n0}", data.kpi.other.hotJobPrs.data.GreaterThanZeroWeeks),
                string.Format("{0:n0}", data.kpi.other.hotJobPrs.data.GreaterThanMinusOneWeeks),
                string.Format("{0:n0}", data.kpi.other.hotJobPrs.data.GreaterThanMinusTwoWeeks),
                string.Format("{0:n0}", data.kpi.other.hotJobPrs.data.GreaterThanMinusThreeWeeks),
                string.Format("{0:n0}", data.kpi.other.hotJobPrs.data.GreaterThanMinusFourWeeks),
                string.Format("{0:n0}", data.kpi.other.hotJobPrs.data.GreaterThanMinusFiveWeeks),
                string.Format("{0:n0}", data.kpi.other.hotJobPrs.data.GreaterThanMinusSixWeeks),
                string.Format("{0:n0}", data.kpi.other.hotJobPrs.data.GreaterThanMinusSevenWeeks),
                string.Format("{0:n0}", data.kpi.other.hotJobPrs.data.GreaterThanMinusEightWeeks),
                string.Format("{0:n0}", data.kpi.other.hotJobPrs.data.LessThanEightWeeks),
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
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.Plan];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.Plan][(int)StringUtils.KpiStringUtils.Category.Plan.CurrentPlanDateVsPrPlanDate];
                        HandlePlanDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 1:
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.Plan];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.Plan][(int)StringUtils.KpiStringUtils.Category.Plan.OriginalPlanDate2ndLvlReleaseDatevsCodedLeadTime];
                        HandlePlanDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 2:
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.Plan];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.Plan][(int)StringUtils.KpiStringUtils.Category.Plan.CurrentPlanDate2ndLvlReleaseDatevsCodedLeadTime];
                        HandlePlanDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 3: // Purch
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.Purch];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.Purch][(int)StringUtils.KpiStringUtils.Category.Purch.InitialConfirmationDatevsPRPlanDate];
                        HandlePurchDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 4: // Follow Up
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.FollowUp];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.FollowUp][(int)StringUtils.KpiStringUtils.Category.FollowUp.CurrentConfDateVsInitialConfDate];
                        HandleFollowUpDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 5:
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.FollowUp];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.FollowUp][(int)StringUtils.KpiStringUtils.Category.FollowUp.FinalConfirmationDatevsFinalPlanDate];
                        HandleFollowUpDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 6:
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.FollowUp];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.FollowUp][(int)StringUtils.KpiStringUtils.Category.FollowUp.ReceiptDatevsCurrentPlanDate];
                        HandleFollowUpDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 7:
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.FollowUp];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.FollowUp][(int)StringUtils.KpiStringUtils.Category.FollowUp.ReceiptDatevsOriginalConfirmationDate];
                        HandleFollowUpDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 8:
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.FollowUp];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.FollowUp][(int)StringUtils.KpiStringUtils.Category.FollowUp.ReceiptDatevsCurrentConfirmationDate];
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
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.PlanTwo];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.PlanTwo][(int)StringUtils.KpiStringUtils.Category.PlanTwo.MaterialDueOriginalPlanDate];
                        HandlePlanTwoDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 1:
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.PlanTwo];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.PlanTwo][(int)StringUtils.KpiStringUtils.Category.PlanTwo.MaterialDueFinalPlannedDate];
                        HandlePlanTwoDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 2: // 4 - 5 = Purch Two
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.PurchTwo];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.PurchTwo][(int)StringUtils.KpiStringUtils.Category.PurchTwo.PR2ndLvlReleaseDatevsPOCreationDate];
                        HandlePurchTwoDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 3:
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.PurchTwo];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.PurchTwo][(int)StringUtils.KpiStringUtils.Category.PurchTwo.POCreationDatevsPOReleaseDate];
                        HandlePurchTwoDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 4:
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.PurchTwo];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.PurchTwo][(int)StringUtils.KpiStringUtils.Category.PurchTwo.POReleaseDatevsPOConfirmationDate];
                        HandlePurchTwoDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 5: // 7 - 8 Purch Sub
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.PurchSub];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.PurchSub][(int)StringUtils.KpiStringUtils.Category.PurchSub.PRReleaseDatevsPOReleaseDate];
                        HandlePurchSubDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 6:
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.PurchSub];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.PurchSub][(int)StringUtils.KpiStringUtils.Category.PurchSub.POCreationDatevsConfirmationEntryDate];
                        HandlePurchSubDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 7: // Purch Total
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.PurchTotal];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.PurchTotal][(int)StringUtils.KpiStringUtils.Category.PurchTotal.PRReleaseDatetoConfirmationEntryDate];
                        HandlePurchTotalDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 8: // 10 - 11 = Purch Plan
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.PurchPlan];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.PurchPlan][(int)StringUtils.KpiStringUtils.Category.PurchPlan.POReleasevsPRDeliveryDate];
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
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.Other];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.Other][(int)StringUtils.KpiStringUtils.Category.Other.PRsCreated];
                        HandleOtherDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 1:
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.Other];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.Other][(int)StringUtils.KpiStringUtils.Category.Other.PRsReleased];
                        HandleOtherDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 2:
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.Other];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.Other][(int)StringUtils.KpiStringUtils.Category.Other.TotalSpend];
                        HandleOtherDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 3:
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.Other];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.Other][(int)StringUtils.KpiStringUtils.Category.Other.PRValuevsPOValue];
                        HandleOtherDataTableLoading(e.RowIndex, e.ColumnIndex);
                        break;
                    case 4:
                        Globals.CurrSection = StringUtils.KpiStringUtils.sections[(int)StringUtils.KpiStringUtils.Section.Other];
                        Globals.CurrCategory = StringUtils.KpiStringUtils.categories[(int)StringUtils.KpiStringUtils.Section.Other][(int)StringUtils.KpiStringUtils.Category.Other.HotJobPRs];
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
                                return;
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
                        }
                        break;
                    case 1: // (Original Plan Date - 2nd Lvl Rel Date) vs Coded Lead-time
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
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
                        }
                        break;
                    case 2: // (Current Plan Date - 2nd Lvl Rel Date) vs Coded Lead-time
                        switch (columnIndex)
                        {
                            case 0: // section
                            case 1: // category
                                return;
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
                                return;
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
                                return;
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
