using KPA_KPI_Analyzer.DataLoading;
using KPA_KPI_Analyzer.DataLoading.KPI_Data.DataTableLoader;
using KPA_KPI_Analyzer.Values;
using Reporting;
using Reporting.KeyPerformanceIndicators;
using Reporting.Overall;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPI_Controls
{
    public partial class KPIPlanTwoTemplate : UserControl
    {
        


        public delegate void UpdateCategoryHandler();
        public static event UpdateCategoryHandler ChangeCategory;


        /// <summary>
        /// Boolean value indicating whether the data was loaded into the dataviz control
        /// </summary>
        bool DatavizLoaded { get; set; }




        /// <summary>
        /// The tag (property for the control) indicating what category is loaded
        /// </summary>
        int ActiveCategory { get; set; }





        /// <summary>
        /// Default Constructor
        /// </summary>
        public KPIPlanTwoTemplate()
        {
            InitializeComponent();
        }





        /// <summary>
        /// Properties for the various labels on the control
        /// </summary>
        #region Template Properties
        public string TotalOrders { get { return lbl_totalOrders.Text; } set { lbl_totalOrders.Text = value; } }
        private string Title { get { return lbl_title.Text; } set { lbl_title.Text = value; } }
        private string AnalysisOne { get { return lbl_analysisOne.Text; } set { lbl_analysisOne.Text = value; } }
        private string AnalysisTwo { get { return lbl_analysisTwo.Text; } set { lbl_analysisTwo.Text = value; } }
        private string Average { get { return lbl_average.Text; } set { lbl_average.Text = value + " Day(s)"; } }
        private string TimeBucketOne { get { return lbl_timebuckOne.Text; } set { lbl_timebuckOne.Text = value; } }
        private string TimeBucketTwo { get { return lbl_timebuckTwo.Text; } set { lbl_timebuckTwo.Text = value; } }
        private string TimeBucketThree { get { return lbl_timebuckThree.Text; } set { lbl_timebuckThree.Text = value; } }
        private string TimeBucketFour { get { return lbl_timebuckFour.Text; } set { lbl_timebuckFour.Text = value; } }
        private string TimeBucketFive { get { return lbl_timebuckFive.Text; } set { lbl_timebuckFive.Text = value; } }
        private string TimeBucketSix { get { return lbl_timebuckSix.Text; } set { lbl_timebuckSix.Text = value; } }
        private string TimeBucketSeven { get { return lbl_timebuckSeven.Text; } set { lbl_timebuckSeven.Text = value; } }
        private string TimeBucketEight { get { return lbl_timebuckEight.Text; } set { lbl_timebuckEight.Text = value; } }
        private string TimeBucketNine { get { return lbl_timebuckNine.Text; } set { lbl_timebuckNine.Text = value; } }
        private string TimeBucketTen { get { return lbl_timebuckTen.Text; } set { lbl_timebuckTen.Text = value; } }
        private string TimeBucketEleven { get { return lbl_timebuckEleven.Text; } set { lbl_timebuckEleven.Text = value; } }
        private System.Drawing.Color DefaultButtonTextColor
        {
            set
            {
                btn_One.Textcolor = value;
                btn_Two.Textcolor = value;
            }
        }
        #endregion






        /// <summary>
        /// This function will always load the default state of the control and set the color of the graph.
        /// </summary>
        public void LoadPanel()
        {
            
            SetGraphColor();
            DefaultButtonTextColor = Color.DarkGray;
            RenderTwo();
            btn_One.selected = true;
            btn_One.Textcolor = Color.Coral;
            DatavizLoaded = false;
            ActiveCategory = 0;
            Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.PlanTwo][(int)Values.Categories.KpiCategory.PlanTwo.MaterialDueOriginalPlanDate];
            ChangeCategory();
            datavizLoadTimer.Start();
        }






        /// <summary>
        /// When the template is active, this function will start the datvizLoadTimer
        /// to refresh it when the applications size changees.
        /// </summary>
        public void RefreshTemplate()
        {
            DatavizLoaded = false;
            datavizLoadTimer.Start();
        }





        /// <summary>
        /// Sets the colors of the columns within the column chart on the template
        /// </summary>
        private void SetGraphColor()
        {
            dataviz.colorSet.Add(Color.FromArgb(123, 204, 243));
            dataviz.colorSet.Add(Color.FromArgb(96, 189, 227));
            dataviz.colorSet.Add(Color.FromArgb(79, 179, 208));
            dataviz.colorSet.Add(Color.FromArgb(62, 168, 186));
            dataviz.colorSet.Add(Color.FromArgb(50, 150, 160));
            dataviz.colorSet.Add(Color.FromArgb(41, 132, 137));
            dataviz.colorSet.Add(Color.FromArgb(31, 109, 109));
            dataviz.colorSet.Add(Color.FromArgb(21, 86, 84));
            dataviz.colorSet.Add(Color.FromArgb(12, 58, 56));
            dataviz.colorSet.Add(Color.FromArgb(7, 38, 36));
            dataviz.colorSet.Add(Color.FromArgb(4, 13, 18));
        }







        /// <summary>
        /// Triggered when the category buttons are clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategoryButton_Click(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuFlatButton btn = (Bunifu.Framework.UI.BunifuFlatButton)sender;


            btn_One.selected = false;
            btn_One.selected = false;
            btn_One.selected = false;

            btn.selected = true;
            DefaultButtonTextColor = Color.DarkGray;
            btn.Textcolor = Color.Coral;


            int tag = int.Parse(btn.Tag.ToString());

            ActiveCategory = tag;

            switch (tag)
            {
                case 0:
                    RenderOne();
                    break;
                case 1:
                    RenderTwo();
                    break;
                default:
                    break;
            }
        }




        /// <summary>
        /// Renders the specific KPI category into the loaded template
        /// </summary>
        private void RenderOne()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);

            Title = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.PlanTwo][(int)Values.Categories.KpiCategory.PlanTwo.MaterialDueOriginalPlanDate];
            Globals.CurrCategory = Title;
            Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.PlanTwo];
            ChangeCategory();



            AnalysisOne = "- Will show if the PR has been fully released.";
            AnalysisTwo = "- Difference between PR delivery date and the date the PR was fully released.";



            ITemplateFour tempFour = (Report.Indicators[(int)KpiOption.PlanTwo_MaterialDueOriginalPlannedDate]
                    as Reporting.KeyPerformanceIndicators.PlanTwo.MaterialDueOriginalPlannedDate);


            // Add the data to the column chart
            dp.addLabely(lbl_xLabelOne.Text, tempFour.LessThanEqualToZeroDays.ToString());
            dp.addLabely(lbl_xLabelTwo.Text, tempFour.OneToThreeDays.ToString());
            dp.addLabely(lbl_xLabelThree.Text, tempFour.FourToSevenDays.ToString());
            dp.addLabely(lbl_xLabelFour.Text, tempFour.EightToFourteenDays.ToString());
            dp.addLabely(lbl_xLabelFive.Text, tempFour.FifteenToTwentyOneDays.ToString());
            dp.addLabely(lbl_xLabelSix.Text, tempFour.TwentyTwoToTwentyEightDays.ToString());
            dp.addLabely(lbl_xLabelSeven.Text, tempFour.TwentyNineToThirtyFiveDays.ToString());
            dp.addLabely(lbl_xLabelEight.Text, tempFour.ThirtySixtoFourtyTwoDays.ToString());
            dp.addLabely(lbl_xLabelNine.Text, tempFour.FourtyThreeToFourtyNineDays.ToString());
            dp.addLabely(lbl_xLabelTen.Text, tempFour.FiftyToFiftySixDays.ToString());
            dp.addLabely(lbl_xLabelEleven.Text, tempFour.FiftySevenPlusDays.ToString());

            // Add the data to the time spans
            Average = string.Format("{0:n}", tempFour.Average);
            TimeBucketOne = string.Format("{0:n0}", tempFour.LessThanEqualToZeroDays);
            TimeBucketTwo = string.Format("{0:n0}", tempFour.OneToThreeDays);
            TimeBucketThree = string.Format("{0:n0}", tempFour.FourToSevenDays);
            TimeBucketFour = string.Format("{0:n0}", tempFour.EightToFourteenDays);
            TimeBucketFive = string.Format("{0:n0}", tempFour.FifteenToTwentyOneDays);
            TimeBucketSix = string.Format("{0:n0}", tempFour.TwentyTwoToTwentyEightDays);
            TimeBucketSeven = string.Format("{0:n0}", tempFour.TwentyNineToThirtyFiveDays);
            TimeBucketEight = string.Format("{0:n0}", tempFour.ThirtySixtoFourtyTwoDays);
            TimeBucketNine = string.Format("{0:n0}", tempFour.FourtyThreeToFourtyNineDays);
            TimeBucketTen = string.Format("{0:n0}", tempFour.FiftyToFiftySixDays);
            TimeBucketEleven = string.Format("{0:n0}", tempFour.FiftySevenPlusDays);
            TotalOrders = string.Format("{0:n0}", tempFour.TotalRecords);

            canvas.addData(dp);
            dataviz.Render(canvas);
        }




        /// <summary>
        /// Renders the specific KPI category into the loaded template
        /// </summary>
        private void RenderTwo()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);

            Title = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.PlanTwo][(int)Values.Categories.KpiCategory.PlanTwo.MaterialDueFinalPlannedDate];
            Globals.CurrCategory = Title;
            Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.PlanTwo];
            ChangeCategory();

            AnalysisOne = "- Will show if the PR line item is on a PO.";
            AnalysisTwo = "- Difference between the current planned date and the date the PR was fully released.";


            ITemplateFour tempFour = (Report.Indicators[(int)KpiOption.PlanTwo_MaterialDueFinalPlannedDate]
                    as Reporting.KeyPerformanceIndicators.PlanTwo.MaterialDueFinalPlannedDate);

            // Add the data to the column chart
            dp.addLabely(lbl_xLabelOne.Text, tempFour.LessThanEqualToZeroDays.ToString());
            dp.addLabely(lbl_xLabelTwo.Text, tempFour.OneToThreeDays.ToString());
            dp.addLabely(lbl_xLabelThree.Text, tempFour.FourToSevenDays.ToString());
            dp.addLabely(lbl_xLabelFour.Text, tempFour.EightToFourteenDays.ToString());
            dp.addLabely(lbl_xLabelFive.Text, tempFour.FifteenToTwentyOneDays.ToString());
            dp.addLabely(lbl_xLabelSix.Text, tempFour.TwentyTwoToTwentyEightDays.ToString());
            dp.addLabely(lbl_xLabelSeven.Text, tempFour.TwentyNineToThirtyFiveDays.ToString());
            dp.addLabely(lbl_xLabelEight.Text, tempFour.ThirtySixtoFourtyTwoDays.ToString());
            dp.addLabely(lbl_xLabelNine.Text, tempFour.FourtyThreeToFourtyNineDays.ToString());
            dp.addLabely(lbl_xLabelTen.Text, tempFour.FiftyToFiftySixDays.ToString());
            dp.addLabely(lbl_xLabelEleven.Text, tempFour.FiftySevenPlusDays.ToString());

            // Add the data to the time spans
            Average = string.Format("{0:n}", tempFour.Average);
            TimeBucketOne = string.Format("{0:n0}", tempFour.LessThanEqualToZeroDays);
            TimeBucketTwo = string.Format("{0:n0}", tempFour.OneToThreeDays);
            TimeBucketThree = string.Format("{0:n0}", tempFour.FourToSevenDays);
            TimeBucketFour = string.Format("{0:n0}", tempFour.EightToFourteenDays);
            TimeBucketFive = string.Format("{0:n0}", tempFour.FifteenToTwentyOneDays);
            TimeBucketSix = string.Format("{0:n0}", tempFour.TwentyTwoToTwentyEightDays);
            TimeBucketSeven = string.Format("{0:n0}", tempFour.TwentyNineToThirtyFiveDays);
            TimeBucketEight = string.Format("{0:n0}", tempFour.ThirtySixtoFourtyTwoDays);
            TimeBucketNine = string.Format("{0:n0}", tempFour.FourtyThreeToFourtyNineDays);
            TimeBucketTen = string.Format("{0:n0}", tempFour.FiftyToFiftySixDays);
            TimeBucketEleven = string.Format("{0:n0}", tempFour.FiftySevenPlusDays);
            TotalOrders = string.Format("{0:n0}", tempFour.TotalRecords);

            canvas.addData(dp);
            dataviz.Render(canvas);
        }







        /// <summary>
        /// Triggered when the template is loaded. This will load the data in the template
        /// into the dataviz object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datavizLoadTimer_Tick(object sender, EventArgs e)
        {
            if (!DatavizLoaded)
            {
                DatavizLoaded = true;
                dataviz.Refresh();
                datavizLoadTimer.Stop();
            }
        }







        /// <summary>
        /// Triggered when the user clicks a 'view' button which then in return will present 
        /// a new window with a datagrid view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btn_viewData_Click(object sender, EventArgs e)
        {
            try
            {
                using (DataViewer dv = new DataViewer())
                {
                    Bunifu.Framework.UI.BunifuFlatButton btn = (Bunifu.Framework.UI.BunifuFlatButton)sender;
                    int tag = int.Parse(btn.Tag.ToString());

                    switch (ActiveCategory)
                    {
                        case 0: // PO Release vs PO Confirmation
                            dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueOrigPlanDate;
                            dv.ColumnTag = tag;
                            break;
                        case 1: // PO Release vs PO Confirmation
                            dv.DataLoader += KpiDataTableLoader.PlanTwo.LoadMaterialDueFinalPlanDate;
                            dv.ColumnTag = tag;
                            break;
                        default:
                            break;
                    }
                    dv.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Plan Two Values Viewer Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
