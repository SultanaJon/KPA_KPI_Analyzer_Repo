using KPA_KPI_Analyzer.DataLoading;
using KPA_KPI_Analyzer.DataLoading.KPI_Data.DataTableLoader;
using KPA_KPI_Analyzer.Overall_Data;
using KPA_KPI_Analyzer.Values;
using Reporting;
using Reporting.KeyPerformanceIndicators;
using Reporting.Overall;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPI_Controls
{
    public partial class KPIOtherTemplate : UserControl
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
        public KPIOtherTemplate()
        {
            InitializeComponent();
        }





        /// <summary>
        /// Properties for the various labels on the control
        /// </summary>
        #region Template Properties
        public string TotalOrders { get { return lbl_totalOrders.Text; } set { lbl_totalOrders.Text = value; } }
        private string TotalValue { get { return lbl_totalValue.Text; } set { lbl_totalValue.Text = "$" + value; } }
        private string Title { get { return lbl_title.Text; } set { lbl_title.Text = value; } }
        private string AnalysisOne { get { return lbl_analysisOne.Text; } set { lbl_analysisOne.Text = value;  } }
        private string AnalysisTwo { get { return lbl_analysisTwo.Text; } set { lbl_analysisTwo.Text = value;  } }
        private string TimeBucketOne { get { return lbl_timebuckOne.Text; } set { lbl_timebuckOne.Text = value;  } }
        private string TimeBucketTwo { get { return lbl_timebuckTwo.Text; } set { lbl_timebuckTwo.Text = value;  } }
        private string TimeBucketThree { get { return lbl_timebuckThree.Text; } set { lbl_timebuckThree.Text = value; } }
        private string TimeBucketFour { get { return lbl_timebuckFour.Text; } set { lbl_timebuckFour.Text = value;  } }
        private string TimeBucketFive { get { return lbl_timebuckFive.Text; } set { lbl_timebuckFive.Text = value;  } }
        private string TimeBucketSix { get { return lbl_timebuckSix.Text; } set { lbl_timebuckSix.Text = value; } }
        private string TimeBucketSeven { get { return lbl_timebuckSeven.Text; } set { lbl_timebuckSeven.Text = value; } }
        private string TimeBucketEight { get { return lbl_timebuckEight.Text; } set { lbl_timebuckEight.Text = value; } }
        private string TimeBucketNine { get { return lbl_timebuckNine.Text; } set { lbl_timebuckNine.Text = value; } }
        private string TimeBucketTen { get { return lbl_timebuckTen.Text; } set { lbl_timebuckTen.Text = value;  } }

        private System.Drawing.Color DefaultButtonTextColor
        {
            set
            {
                btn_One.Textcolor = value;
                btn_Two.Textcolor = value;
                btn_Three.Textcolor = value;
                btn_Four.Textcolor = value;
                btn_Five.Textcolor = value;
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
            RenderOne();
            btn_One.selected = true;
            btn_One.Textcolor = System.Drawing.Color.Coral;
            DatavizLoaded = false;
            ActiveCategory = 0;
            datavizLoadTimer.Start();
            Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.Other][(int)Values.Categories.KpiCategory.Other.PRsCreated];
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
            dataviz.colorSet.Add(Color.FromArgb(21, 86, 84));
            dataviz.colorSet.Add(Color.FromArgb(12, 58, 56));
            dataviz.colorSet.Add(Color.FromArgb(7, 38, 36));
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
            btn_Four.selected = false;
            btn_Five.selected = false;

            btn.selected = true;
            DefaultButtonTextColor = System.Drawing.Color.DarkGray;
            btn.Textcolor = System.Drawing.Color.Coral;


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
                case 2:
                    RenderThree();
                    break;
                case 3:
                    RenderFour();
                    break;
                case 4:
                    RenderFive();
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

            Title = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.Other][(int)Values.Categories.KpiCategory.Other.PRsCreated];
            Globals.CurrCategory = Title;
            Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.Other];
            ChangeCategory();


            AnalysisOne = "- Count of PRs by creation date.";
            AnalysisTwo = "- Difference between the date the PR was created and the todays date.";


            ITemplateFive tempFive = (Report.Indicators[(int)KpiOption.Other_PrsCreated]
                as Reporting.KeyPerformanceIndicators.Other.PRsCreated).Template;

            // Add the data to the column chart
            dp.addLabely(lbl_xLabelOne.Text, tempFive.GreaterThanEqualToZeroWeeks.ToString());
            dp.addLabely(lbl_xLabelTwo.Text, tempFive.GreaterThanEqualToNegOneWeek.ToString());
            dp.addLabely(lbl_xLabelThree.Text, tempFive.GreaterThanEqualToNegTwoWeeks.ToString());
            dp.addLabely(lbl_xLabelFour.Text, tempFive.GreaterThanEqualToNegThreeWeeks.ToString());
            dp.addLabely(lbl_xLabelFive.Text, tempFive.GreaterThanEqualToNegFourWeeks.ToString());
            dp.addLabely(lbl_xLabelSix.Text, tempFive.GreaterThanEqualToNegFiveWeeks.ToString());
            dp.addLabely(lbl_xLabelSeven.Text, tempFive.GreaterThanEqualToNegSixWeeks.ToString());
            dp.addLabely(lbl_xLabelEight.Text, tempFive.GreaterThanEqualToNegSevenWeeks.ToString());
            dp.addLabely(lbl_xLabelNine.Text, tempFive.GreaterThanEqualToNegEightWeeks.ToString());
            dp.addLabely(lbl_xLabelTen.Text, tempFive.LessThanNegEightWeeks.ToString());

            // Add the data to the time spans
            TotalValue = string.Format("{0:n}", tempFive.TotalValue);
            TimeBucketOne = string.Format("{0:n0}", tempFive.GreaterThanEqualToZeroWeeks);
            TimeBucketTwo = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegOneWeek);
            TimeBucketThree = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegTwoWeeks);
            TimeBucketFour = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegThreeWeeks);
            TimeBucketFive = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegFourWeeks);
            TimeBucketSix = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegFiveWeeks);
            TimeBucketSeven = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegSixWeeks);
            TimeBucketEight = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegSevenWeeks);
            TimeBucketNine = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegEightWeeks);
            TimeBucketTen = string.Format("{0:n0}", tempFive.LessThanNegEightWeeks);
            TotalOrders = string.Format("{0:n0}", tempFive.TotalRecords);

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

            Title = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.Other][(int)Values.Categories.KpiCategory.Other.PRsReleased];
            Globals.CurrCategory = Title;
            Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.Other];
            ChangeCategory();
            
            AnalysisOne = "- Count of PRs by release date.";
            AnalysisTwo = "- Difference between PR fully released date and todays date.";

            ITemplateFive tempFive = (Report.Indicators[(int)KpiOption.Other_PrsReleased]
                as Reporting.KeyPerformanceIndicators.Other.PRsReleased).Template;

            // Add the data to the column chart
            dp.addLabely(lbl_xLabelOne.Text, tempFive.GreaterThanEqualToZeroWeeks.ToString());
            dp.addLabely(lbl_xLabelTwo.Text, tempFive.GreaterThanEqualToNegOneWeek.ToString());
            dp.addLabely(lbl_xLabelThree.Text, tempFive.GreaterThanEqualToNegTwoWeeks.ToString());
            dp.addLabely(lbl_xLabelFour.Text, tempFive.GreaterThanEqualToNegThreeWeeks.ToString());
            dp.addLabely(lbl_xLabelFive.Text, tempFive.GreaterThanEqualToNegFourWeeks.ToString());
            dp.addLabely(lbl_xLabelSix.Text, tempFive.GreaterThanEqualToNegFiveWeeks.ToString());
            dp.addLabely(lbl_xLabelSeven.Text, tempFive.GreaterThanEqualToNegSixWeeks.ToString());
            dp.addLabely(lbl_xLabelEight.Text, tempFive.GreaterThanEqualToNegSevenWeeks.ToString());
            dp.addLabely(lbl_xLabelNine.Text, tempFive.GreaterThanEqualToNegEightWeeks.ToString());
            dp.addLabely(lbl_xLabelTen.Text, tempFive.LessThanNegEightWeeks.ToString());

            // Add the data to the time spans
            TotalValue = string.Format("{0:n}", tempFive.TotalValue);
            TimeBucketOne = string.Format("{0:n0}", tempFive.GreaterThanEqualToZeroWeeks);
            TimeBucketTwo = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegOneWeek);
            TimeBucketThree = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegTwoWeeks);
            TimeBucketFour = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegThreeWeeks);
            TimeBucketFive = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegFourWeeks);
            TimeBucketSix = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegFiveWeeks);
            TimeBucketSeven = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegSixWeeks);
            TimeBucketEight = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegSevenWeeks);
            TimeBucketNine = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegEightWeeks);
            TimeBucketTen = string.Format("{0:n0}", tempFive.LessThanNegEightWeeks);
            TotalOrders = string.Format("{0:n0}", tempFive.TotalRecords);

            canvas.addData(dp);
            dataviz.Render(canvas);
        }






        /// <summary>
        /// Renders the specific KPI category into the loaded template
        /// </summary>
        private void RenderThree()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);

            Title = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.Other][(int)Values.Categories.KpiCategory.Other.TotalSpend];
            Globals.CurrCategory = Title;
            Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.Other];
            ChangeCategory();


            AnalysisOne = "- Value of PO Lines based on PO line Creation Date.";
            AnalysisTwo = "";

            ITemplateFive tempFive = (Report.Indicators[(int)KpiOption.Other_PrsCreated]
                as Reporting.KeyPerformanceIndicators.Other.PRsCreated).Template;

            // Add the data to the column chart
            dp.addLabely(lbl_xLabelOne.Text, tempFive.GreaterThanEqualToZeroWeeks.ToString());
            dp.addLabely(lbl_xLabelTwo.Text, tempFive.GreaterThanEqualToNegOneWeek.ToString());
            dp.addLabely(lbl_xLabelThree.Text, tempFive.GreaterThanEqualToNegTwoWeeks.ToString());
            dp.addLabely(lbl_xLabelFour.Text, tempFive.GreaterThanEqualToNegThreeWeeks.ToString());
            dp.addLabely(lbl_xLabelFive.Text, tempFive.GreaterThanEqualToNegFourWeeks.ToString());
            dp.addLabely(lbl_xLabelSix.Text, tempFive.GreaterThanEqualToNegFiveWeeks.ToString());
            dp.addLabely(lbl_xLabelSeven.Text, tempFive.GreaterThanEqualToNegSixWeeks.ToString());
            dp.addLabely(lbl_xLabelEight.Text, tempFive.GreaterThanEqualToNegSevenWeeks.ToString());
            dp.addLabely(lbl_xLabelNine.Text, tempFive.GreaterThanEqualToNegEightWeeks.ToString());
            dp.addLabely(lbl_xLabelTen.Text, tempFive.LessThanNegEightWeeks.ToString());


            // Add the data to the time spans

            TotalOrders = string.Format("{0:n0}", tempFive.TotalValue);
            TotalValue = string.Format("{0:n}", tempFive.GreaterThanEqualToZeroWeeks);
            TimeBucketOne = "$" + string.Format("{0:n}", tempFive.GreaterThanEqualToNegOneWeek);
            TimeBucketTwo = "$" + string.Format("{0:n}", tempFive.GreaterThanEqualToNegTwoWeeks);
            TimeBucketThree = "$" + string.Format("{0:n}", tempFive.GreaterThanEqualToNegThreeWeeks);
            TimeBucketFour = "$" + string.Format("{0:n}", tempFive.GreaterThanEqualToNegFourWeeks);
            TimeBucketFive = "$" + string.Format("{0:n}", tempFive.GreaterThanEqualToNegFiveWeeks);
            TimeBucketSix = "$" + string.Format("{0:n}", tempFive.GreaterThanEqualToNegSixWeeks);
            TimeBucketSeven = "$" + string.Format("{0:n}", tempFive.GreaterThanEqualToNegSevenWeeks);
            TimeBucketEight = "$" + string.Format("{0:n}", tempFive.GreaterThanEqualToNegEightWeeks);
            TimeBucketNine = "$" + string.Format("{0:n}", tempFive.LessThanNegEightWeeks);
            TimeBucketTen = "$" + string.Format("{0:n}", tempFive.TotalRecords);


            canvas.addData(dp);
            dataviz.Render(canvas);
        }






        /// <summary>
        /// Renders the specific KPI category into the loaded template
        /// </summary>
        private void RenderFour()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);

            Title = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.Other][(int)Values.Categories.KpiCategory.Other.PRValuevsPOValue];
            Globals.CurrCategory = Title;
            Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.Other];
            ChangeCategory();

            AnalysisOne = "- Based on PO line Creation Date.";
            AnalysisTwo = "- Variance of PO line value vs PR line value over time.";


            ITemplateFive tempFive = (Report.Indicators[(int)KpiOption.Other_PrsCreated]
                as Reporting.KeyPerformanceIndicators.Other.PRsCreated).Template;

            // Add the data to the column chart
            dp.addLabely(lbl_xLabelOne.Text, tempFive.GreaterThanEqualToZeroWeeks.ToString());
            dp.addLabely(lbl_xLabelTwo.Text, tempFive.GreaterThanEqualToNegOneWeek.ToString());
            dp.addLabely(lbl_xLabelThree.Text, tempFive.GreaterThanEqualToNegTwoWeeks.ToString());
            dp.addLabely(lbl_xLabelFour.Text, tempFive.GreaterThanEqualToNegThreeWeeks.ToString());
            dp.addLabely(lbl_xLabelFive.Text, tempFive.GreaterThanEqualToNegFourWeeks.ToString());
            dp.addLabely(lbl_xLabelSix.Text, tempFive.GreaterThanEqualToNegFiveWeeks.ToString());
            dp.addLabely(lbl_xLabelSeven.Text, tempFive.GreaterThanEqualToNegSixWeeks.ToString());
            dp.addLabely(lbl_xLabelEight.Text, tempFive.GreaterThanEqualToNegSevenWeeks.ToString());
            dp.addLabely(lbl_xLabelNine.Text, tempFive.GreaterThanEqualToNegEightWeeks.ToString());
            dp.addLabely(lbl_xLabelTen.Text, tempFive.LessThanNegEightWeeks.ToString());


            // Add the data to the time spans

            TotalOrders = string.Format("{0:n0}", tempFive.TotalValue);
            TotalValue = string.Format("{0:n}", tempFive.GreaterThanEqualToZeroWeeks);
            TimeBucketOne = "$" + string.Format("{0:n}", tempFive.GreaterThanEqualToNegOneWeek);
            TimeBucketTwo = "$" + string.Format("{0:n}", tempFive.GreaterThanEqualToNegTwoWeeks);
            TimeBucketThree = "$" + string.Format("{0:n}", tempFive.GreaterThanEqualToNegThreeWeeks);
            TimeBucketFour = "$" + string.Format("{0:n}", tempFive.GreaterThanEqualToNegFourWeeks);
            TimeBucketFive = "$" + string.Format("{0:n}", tempFive.GreaterThanEqualToNegFiveWeeks);
            TimeBucketSix = "$" + string.Format("{0:n}", tempFive.GreaterThanEqualToNegSixWeeks);
            TimeBucketSeven = "$" + string.Format("{0:n}", tempFive.GreaterThanEqualToNegSevenWeeks);
            TimeBucketEight = "$" + string.Format("{0:n}", tempFive.GreaterThanEqualToNegEightWeeks);
            TimeBucketNine = "$" + string.Format("{0:n}", tempFive.LessThanNegEightWeeks);
            TimeBucketTen = "$" + string.Format("{0:n}", tempFive.TotalRecords);


            canvas.addData(dp);
            dataviz.Render(canvas);
        }






        /// <summary>
        /// Renders the specific KPI category into the loaded template
        /// </summary>
        private void RenderFive()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);

            Title = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.Other][(int)Values.Categories.KpiCategory.Other.HotJobPRs];
            Globals.CurrCategory = Title;
            Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.Other];
            ChangeCategory();

            AnalysisOne = "- Will show for PRs which have Purchase Group of 'UHJ'.";
            AnalysisTwo = "- Difference between the date the PR was created and todays date.";

            ITemplateFive tempFive = (Report.Indicators[(int)KpiOption.Other_HotJobPRs]
                as Reporting.KeyPerformanceIndicators.Other.HotJobPRs).Template;

            // Add the data to the column chart
            dp.addLabely(lbl_xLabelOne.Text, tempFive.GreaterThanEqualToZeroWeeks.ToString());
            dp.addLabely(lbl_xLabelTwo.Text, tempFive.GreaterThanEqualToNegOneWeek.ToString());
            dp.addLabely(lbl_xLabelThree.Text, tempFive.GreaterThanEqualToNegTwoWeeks.ToString());
            dp.addLabely(lbl_xLabelFour.Text, tempFive.GreaterThanEqualToNegThreeWeeks.ToString());
            dp.addLabely(lbl_xLabelFive.Text, tempFive.GreaterThanEqualToNegFourWeeks.ToString());
            dp.addLabely(lbl_xLabelSix.Text, tempFive.GreaterThanEqualToNegFiveWeeks.ToString());
            dp.addLabely(lbl_xLabelSeven.Text, tempFive.GreaterThanEqualToNegSixWeeks.ToString());
            dp.addLabely(lbl_xLabelEight.Text, tempFive.GreaterThanEqualToNegSevenWeeks.ToString());
            dp.addLabely(lbl_xLabelNine.Text, tempFive.GreaterThanEqualToNegEightWeeks.ToString());
            dp.addLabely(lbl_xLabelTen.Text, tempFive.LessThanNegEightWeeks.ToString());

            // Add the data to the time spans
            TotalValue = string.Format("{0:n}", tempFive.TotalValue);
            TimeBucketOne = string.Format("{0:n0}", tempFive.GreaterThanEqualToZeroWeeks);
            TimeBucketTwo = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegOneWeek);
            TimeBucketThree = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegTwoWeeks);
            TimeBucketFour = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegThreeWeeks);
            TimeBucketFive = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegFourWeeks);
            TimeBucketSix = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegFiveWeeks);
            TimeBucketSeven = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegSixWeeks);
            TimeBucketEight = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegSevenWeeks);
            TimeBucketNine = string.Format("{0:n0}", tempFive.GreaterThanEqualToNegEightWeeks);
            TimeBucketTen = string.Format("{0:n0}", tempFive.LessThanNegEightWeeks);
            TotalOrders = string.Format("{0:n0}", tempFive.TotalRecords);

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
                        case 0: // PRs Created
                            dv.DataLoader += KpiDataTableLoader.Other.LoadPrsCreated;
                            dv.ColumnTag = tag;
                            break;
                        case 1: // PRs Released
                            dv.DataLoader += KpiDataTableLoader.Other.LoadPrsReleased;
                            dv.ColumnTag = tag;
                            break;
                        case 2: // Total Spend
                            dv.DataLoader += KpiDataTableLoader.Other.LoadTotalSpend;
                            dv.ColumnTag = tag;
                            break;
                        case 3: // PR vs PO Value
                            dv.DataLoader += KpiDataTableLoader.Other.LoadPrVsPoValue;
                            dv.ColumnTag = tag;
                            break;
                        case 4: // Hot Job PRs
                            dv.DataLoader += KpiDataTableLoader.Other.LoadHotJobPrs;
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
                MessageBox.Show(ex.Message, "KPI -> Other Values Viewer Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
