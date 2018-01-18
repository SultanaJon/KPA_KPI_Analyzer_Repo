using KPA_KPI_Analyzer.DataLoading;
using KPA_KPI_Analyzer.DataLoading.KPA_Data.DataTableLoader;
using KPA_KPI_Analyzer.Values;
using Reporting;
using Reporting.KeyPerformanceActions;
using Reporting.TimeSpans.Templates;
using Reporting.Reports;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPA_Controls
{
    public partial class KPAHotJobsTemplate : UserControl
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
        public KPAHotJobsTemplate()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Properties for the various labels on the control
        /// </summary>
        #region Template Properties
        private string Title { get { return lbl_title.Text; } set { lbl_title.Text = value; } }
        public string TotalOrders { get { return lbl_totalOrders.Text; } set { lbl_totalOrders.Text = value; } }
        private string AnalysisOne { get { return lbl_analysisOne.Text; } set { lbl_analysisOne.Text = value; } }
        private string AnalysisTwo { get { return lbl_analysisTwo.Text; } set { lbl_analysisTwo.Text = value; } }
        private string Average { get { return lbl_average.Text; } set { lbl_average.Text = value + " Day(s)"; } }
        private string TimeBucketOne { get { return lbl_timebuckOne.Text; } set { lbl_timebuckOne.Text = value;  } }
        private string TimeBucketTwo { get { return lbl_timebuckTwo.Text; } set { lbl_timebuckTwo.Text = value;  } }
        private string TimeBucketThree { get { return lbl_timebuckThree.Text; } set { lbl_timebuckThree.Text = value;  } }
        private string TimeBucketFour { get { return lbl_timebuckFour.Text; } set { lbl_timebuckFour.Text = value; } }
        private string TimeBucketFive { get { return lbl_timebuckFive.Text; } set { lbl_timebuckFive.Text = value; } }
        private string TimeBucketSix { get { return lbl_timebuckSix.Text; } set { lbl_timebuckSix.Text = value; } }
        private string TimeBucketSeven { get { return lbl_timebuckSeven.Text; } set { lbl_timebuckSeven.Text = value; } }
        private System.Drawing.Color DefaultButtonTextColor
        {
            set
            {
                btn_One.Textcolor = value;
                btn_Two.Textcolor = value;
                btn_Three.Textcolor = value;
            }
        }
        #endregion




        /// <summary>
        /// This function will always load the default state of the control and set the color of the graph.
        /// </summary>
        public void LoadPanel()
        {
            
            SetGraphColor();
            DefaultButtonTextColor = System.Drawing.Color.DarkGray;
            RenderPRsNotOnPO();
            btn_One.selected = true;
            btn_One.Textcolor = System.Drawing.Color.Coral;
            DatavizLoaded = false;
            ActiveCategory = 0;
            datavizLoadTimer.Start();
            KPA_KPI_UI.topHandleBarModel.Category = Values.Categories.kpaCategories[(int)Values.Sections.KpaSection.HotJobs][(int)Values.Categories.KpaCategory.HotJobs.PrsNotonPO];
            ChangeCategory();
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
            btn_Two.selected = false;
            btn_Three.selected = false;
            btn.selected = true;
            DefaultButtonTextColor = Color.DarkGray;
            btn.Textcolor = Color.Coral;


            int tag = int.Parse(btn.Tag.ToString());

            ActiveCategory = tag;

            switch (tag)
            {
                case 0:
                    RenderPRsNotOnPO();
                    break;
                case 1:
                    RenderNoConfirmations();
                    break;
                case 2:
                    RenderLateToConfirmed();
                    break;
                default:
                    break;
            }
        }






        /// <summary>
        /// Renders the specific KPA category into the loaded template
        /// </summary>
        private void RenderPRsNotOnPO()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);

            Title = Values.Categories.kpaCategories[(int)Values.Sections.KpaSection.HotJobs][(int)Values.Categories.KpaCategory.HotJobs.PrsNotonPO];
            KPA_KPI_UI.topHandleBarModel.Category = Title;
            KPA_KPI_UI.topHandleBarModel.Section = Values.Sections.kpaSections[(int)Values.Sections.KpaSection.HotJobs];
            ChangeCategory();

            AnalysisOne = "- Will only show if PR is assigned to purchase group UHJ, is fully released and the PR has not been placed on a PO.";
            AnalysisTwo = "- Difference between todays date and the date the PR was fully released.";

            TemplateOne tempOne = KpaOverallReport.Actions[(int)KpaOption.HotJobs_PrsNotOnPo].TemplateBlock as TemplateOne;


            // Add the data to the column chart
            dp.addLabely(lbl_xLabelOne.Text, tempOne.LessThanEqualToZeroDays.ToString());
            dp.addLabely(lbl_xLabelTwo.Text, tempOne.OneToThreeDays.ToString());
            dp.addLabely(lbl_xLabelThree.Text, tempOne.FourToSevenDays.ToString());
            dp.addLabely(lbl_xLabelFour.Text, tempOne.EightToFourteenDays.ToString());
            dp.addLabely(lbl_xLabelFive.Text, tempOne.FifteenToTwentyOneDays.ToString());
            dp.addLabely(lbl_xLabelSix.Text, tempOne.TwentyTwoToTwentyEightDays.ToString());
            dp.addLabely(lbl_xLabelSeven.Text, tempOne.TwentyNinePlusDays.ToString());

            // Add the values to the time spans
            Average = string.Format("{0:n}", tempOne.Average);
            TimeBucketOne = string.Format("{0:n0}", tempOne.LessThanEqualToZeroDays);
            TimeBucketTwo = string.Format("{0:n0}", tempOne.OneToThreeDays);
            TimeBucketThree = string.Format("{0:n0}", tempOne.FourToSevenDays);
            TimeBucketFour = string.Format("{0:n0}", tempOne.EightToFourteenDays);
            TimeBucketFive = string.Format("{0:n0}", tempOne.FifteenToTwentyOneDays);
            TimeBucketSix = string.Format("{0:n0}", tempOne.TwentyTwoToTwentyEightDays);
            TimeBucketSeven = string.Format("{0:n0}", tempOne.TwentyNinePlusDays);
            TotalOrders = string.Format("{0:n0}", tempOne.TotalRecords);

            // Render the column chart
            canvas.addData(dp);
            dataviz.Render(canvas);
        }






        /// <summary>
        /// Renders the specific KPA category into the loaded template
        /// </summary>
        private void RenderNoConfirmations()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);
            Title = Values.Categories.kpaCategories[(int)Values.Sections.KpaSection.HotJobs][(int)Values.Categories.KpaCategory.HotJobs.NoConfirmations];
            KPA_KPI_UI.topHandleBarModel.Category = Title;
            KPA_KPI_UI.topHandleBarModel.Section = Values.Sections.kpaSections[(int)Values.Sections.KpaSection.HotJobs];
            ChangeCategory();


            AnalysisOne = "- Will only show for PO line items with purchase group UHJ that do not have a confirmation date and are not received complete.";
            AnalysisTwo = "- Difference between todays date and the date the PO line was created.";

            TemplateOne tempOne = KpaOverallReport.Actions[(int)KpaOption.HotJobs_NoConfirmations].TemplateBlock as TemplateOne;


            // Add the data to the column chart
            dp.addLabely(lbl_xLabelOne.Text, tempOne.LessThanEqualToZeroDays.ToString());
            dp.addLabely(lbl_xLabelTwo.Text, tempOne.OneToThreeDays.ToString());
            dp.addLabely(lbl_xLabelThree.Text, tempOne.FourToSevenDays.ToString());
            dp.addLabely(lbl_xLabelFour.Text, tempOne.EightToFourteenDays.ToString());
            dp.addLabely(lbl_xLabelFive.Text, tempOne.FifteenToTwentyOneDays.ToString());
            dp.addLabely(lbl_xLabelSix.Text, tempOne.TwentyTwoToTwentyEightDays.ToString());
            dp.addLabely(lbl_xLabelSeven.Text, tempOne.TwentyNinePlusDays.ToString());

            // Add the values to the time spans
            Average = string.Format("{0:n}", tempOne.Average);
            TimeBucketOne = string.Format("{0:n0}", tempOne.LessThanEqualToZeroDays);
            TimeBucketTwo = string.Format("{0:n0}", tempOne.OneToThreeDays);
            TimeBucketThree = string.Format("{0:n0}", tempOne.FourToSevenDays);
            TimeBucketFour = string.Format("{0:n0}", tempOne.EightToFourteenDays);
            TimeBucketFive = string.Format("{0:n0}", tempOne.FifteenToTwentyOneDays);
            TimeBucketSix = string.Format("{0:n0}", tempOne.TwentyTwoToTwentyEightDays);
            TimeBucketSeven = string.Format("{0:n0}", tempOne.TwentyNinePlusDays);
            TotalOrders = string.Format("{0:n0}", tempOne.TotalRecords);

            // Render the column chart
            canvas.addData(dp);
            dataviz.Render(canvas);
        }






        /// <summary>
        /// Renders the specific KPA category into the loaded template
        /// </summary>
        private void RenderLateToConfirmed()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);
            Title = Values.Categories.kpaCategories[(int)Values.Sections.KpaSection.HotJobs][(int)Values.Categories.KpaCategory.HotJobs.LateToConfirmed];
            KPA_KPI_UI.topHandleBarModel.Category = Title;
            KPA_KPI_UI.topHandleBarModel.Section = Values.Sections.kpaSections[(int)Values.Sections.KpaSection.HotJobs];
            ChangeCategory();


            AnalysisOne = "- Will only show for PO line items with purchase group UHJ that have confirmation dates less than today and have not been received complete.";
            AnalysisTwo = "- Difference between todays date and the first confirmation date.";

            TemplateOne tempOne = KpaOverallReport.Actions[(int)KpaOption.HotJobs_LateToConfirmed].TemplateBlock as TemplateOne;


            // Add the data to the column chart
            dp.addLabely(lbl_xLabelOne.Text, tempOne.LessThanEqualToZeroDays.ToString());
            dp.addLabely(lbl_xLabelTwo.Text, tempOne.OneToThreeDays.ToString());
            dp.addLabely(lbl_xLabelThree.Text, tempOne.FourToSevenDays.ToString());
            dp.addLabely(lbl_xLabelFour.Text, tempOne.EightToFourteenDays.ToString());
            dp.addLabely(lbl_xLabelFive.Text, tempOne.FifteenToTwentyOneDays.ToString());
            dp.addLabely(lbl_xLabelSix.Text, tempOne.TwentyTwoToTwentyEightDays.ToString());
            dp.addLabely(lbl_xLabelSeven.Text, tempOne.TwentyNinePlusDays.ToString());

            // Add the values to the time spans
            Average = string.Format("{0:n}", tempOne.Average);
            TimeBucketOne = string.Format("{0:n0}", tempOne.LessThanEqualToZeroDays);
            TimeBucketTwo = string.Format("{0:n0}", tempOne.OneToThreeDays);
            TimeBucketThree = string.Format("{0:n0}", tempOne.FourToSevenDays);
            TimeBucketFour = string.Format("{0:n0}", tempOne.EightToFourteenDays);
            TimeBucketFive = string.Format("{0:n0}", tempOne.FifteenToTwentyOneDays);
            TimeBucketSix = string.Format("{0:n0}", tempOne.TwentyTwoToTwentyEightDays);
            TimeBucketSeven = string.Format("{0:n0}", tempOne.TwentyNinePlusDays);
            TotalOrders = string.Format("{0:n0}", tempOne.TotalRecords);

            // Render the column chart
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
                        case 0: // PRs (Not on PO) - Hot Jobs Only
                            dv.DataLoader += KpaDataTableLoader.HotJobs.LoadPRsNotOnPODataTable;
                            dv.ColumnTag = tag;
                            break;
                        case 1: // No Confirmations - Hot Jobs Only
                            dv.DataLoader += KpaDataTableLoader.HotJobs.LoadNoConfirmationDataTable;
                            dv.ColumnTag = tag;
                            break;
                        case 2: // Late to Confirmed - Hot Jobs Only
                            dv.DataLoader += KpaDataTableLoader.HotJobs.LoadLateToConfirmedDataTable;
                            dv.ColumnTag = tag;
                            break;
                    }
                    dv.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Hot Jobs Data Viewer Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
