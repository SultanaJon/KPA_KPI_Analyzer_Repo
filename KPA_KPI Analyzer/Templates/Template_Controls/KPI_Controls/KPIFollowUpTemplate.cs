using KPA_KPI_Analyzer.DataLoading.KPI_Data.DataTableLoader;
using KPA_KPI_Analyzer.KPA_KPI_Overall;
using KPA_KPI_Analyzer.Values;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPI_Controls
{
    public partial class KPIFollowUpTemplate : UserControl
    {
        Overall overallData;


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
        public KPIFollowUpTemplate()
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
        private string AnalysisTwo { get { return lbl_analysisTwo.Text; } set { lbl_analysisTwo.Text = value;  } }
        private string Average { get { return lbl_average.Text; } set { lbl_average.Text = value + " Day(s)"; } }
        private string TimeBucketOne { get { return lbl_timebuckOne.Text; } set { lbl_timebuckOne.Text = value; } }
        private string TimeBucketTwo { get { return lbl_timebuckTwo.Text; } set { lbl_timebuckTwo.Text = value; } }
        private string TimeBucketThree { get { return lbl_timebuckThree.Text; } set { lbl_timebuckThree.Text = value; } }
        private string TimeBucketFour { get { return lbl_timebuckFour.Text; } set { lbl_timebuckFour.Text = value;  } }
        private string TimeBucketFive { get { return lbl_timebuckFive.Text; } set { lbl_timebuckFive.Text = value;  } }
        private string TimeBucketSix { get { return lbl_timebuckSix.Text; } set { lbl_timebuckSix.Text = value;  } }
        private string TimeBucketSeven { get { return lbl_timebuckSeven.Text; } set { lbl_timebuckSeven.Text = value; } }
        private string TimeBucketEight { get { return lbl_timebuckEight.Text; } set { lbl_timebuckEight.Text = value; } }
        private string TimeBucketNine { get { return lbl_timebuckNine.Text; } set { lbl_timebuckNine.Text = value; } }
        private string PercNoConf { get { return lbl_Percent.Text; } set { lbl_Percent.Text = value + "%"; } }
        private string PercNoConfTotal { get { return lbl_percUnconfTotal.Text; } set { lbl_percUnconfTotal.Text = value; } }
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
        public void LoadPanel(Overall data)
        {
            overallData = data;
            SetGraphColor();
            pnl_PercentagePanel.Visible = true;
            DefaultButtonTextColor = System.Drawing.Color.DarkGray;
            RenderOne();
            btn_One.selected = true;
            btn_One.Textcolor = System.Drawing.Color.Coral;
            DatavizLoaded = false;
            ActiveCategory = 0;
            datavizLoadTimer.Start();
            Globals.CurrCategory = "Initial Confirmation vs Current Confirmation";
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
                    pnl_PercentagePanel.Visible = true;
                    btn_unconfIncludedStatusButton.Visible = true;
                    btn_unconfIncludedStatusButton.Text = "Not Including Unconfirmed!";
                    RenderOne();
                    break;
                case 1:
                    pnl_PercentagePanel.Visible = true;
                    btn_unconfIncludedStatusButton.Visible = true;
                    btn_unconfIncludedStatusButton.Text = "Including Unconfirmed!";
                    RenderTwo();
                    break;
                case 2:
                    pnl_PercentagePanel.Visible = false;
                    btn_unconfIncludedStatusButton.Visible = false;
                    RenderThree();
                    break;
                case 3:
                    pnl_PercentagePanel.Visible = true;
                    btn_unconfIncludedStatusButton.Visible = true;
                    btn_unconfIncludedStatusButton.Text = "Not Including Unconfirmed!";
                    RenderFour();
                    break;
                case 4:
                    pnl_PercentagePanel.Visible = true;
                    btn_unconfIncludedStatusButton.Visible = true;
                    btn_unconfIncludedStatusButton.Text = "Not Including Unconfirmed!";
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

            Title = "Initial Confirmation vs Current Confirmation";
            Globals.CurrCategory = Title;
            ChangeCategory();

            TotalOrders = overallData.kpi.followUp.initConfVsCurrConf.data.Total.ToString();
            Average = overallData.kpi.followUp.initConfVsCurrConf.data.Average.ToString();
            PercNoConf = overallData.kpi.followUp.initConfVsCurrConf.data.PercentUnconf.ToString();
            TimeBucketOne = overallData.kpi.followUp.initConfVsCurrConf.data.Minus_TwentyTwo.ToString();
            TimeBucketTwo = overallData.kpi.followUp.initConfVsCurrConf.data.Minus_Fifteen_TwentyOne.ToString();
            TimeBucketThree = overallData.kpi.followUp.initConfVsCurrConf.data.Minus_Eight_Fourteen.ToString();
            TimeBucketFour = overallData.kpi.followUp.initConfVsCurrConf.data.Minus_One_Seven.ToString();
            TimeBucketFive = overallData.kpi.followUp.initConfVsCurrConf.data.Zero.ToString();
            TimeBucketSix = overallData.kpi.followUp.initConfVsCurrConf.data.One_Seven.ToString();
            TimeBucketSeven = overallData.kpi.followUp.initConfVsCurrConf.data.Eight_Fourteen.ToString();
            TimeBucketEight = overallData.kpi.followUp.initConfVsCurrConf.data.Fifteen_TwentyOne.ToString();
            TimeBucketNine = overallData.kpi.followUp.initConfVsCurrConf.data.TwentyTwo.ToString();

            AnalysisOne = "- Will show if PO line item is received complete and the line has a confirmation date.";
            AnalysisTwo = "- Difference between first confirmed date and final confirmation date.";


            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);

            TotalOrders = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Total);
            Average = string.Format("{0:n}", overallData.kpi.followUp.initConfVsCurrConf.data.Average);
            PercNoConf = string.Format("{0:n}", overallData.kpi.followUp.initConfVsCurrConf.data.PercentUnconf);
            PercNoConfTotal = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.PercentUnconfTotal);
            TimeBucketOne = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Minus_TwentyTwo);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Minus_Fifteen_TwentyOne);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Minus_Eight_Fourteen);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Minus_One_Seven);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Zero);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.One_Seven);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Eight_Fourteen);
            TimeBucketEight = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Fifteen_TwentyOne);
            TimeBucketNine = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.TwentyTwo);

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

            Title = "Final Confirmation Date vs Final Planned Date";
            Globals.CurrCategory = Title;
            ChangeCategory();

            TotalOrders = overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Total.ToString();
            Average = overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Average.ToString();
            PercNoConf = overallData.kpi.followUp.finalConfDateVsFinalPlan.data.PercentUnconf.ToString();
            TimeBucketOne = overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_TwentyTwo.ToString();
            TimeBucketTwo = overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_Fifteen_TwentyOne.ToString();
            TimeBucketThree = overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_Eight_Fourteen.ToString();
            TimeBucketFour = overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_One_Seven.ToString();
            TimeBucketFive = overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Zero.ToString();
            TimeBucketSix = overallData.kpi.followUp.finalConfDateVsFinalPlan.data.One_Seven.ToString();
            TimeBucketSeven = overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Eight_Fourteen.ToString();
            TimeBucketEight = overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Fifteen_TwentyOne.ToString();
            TimeBucketNine = overallData.kpi.followUp.finalConfDateVsFinalPlan.data.TwentyTwo.ToString();

            AnalysisOne = "- Will show if PO line item has been received complete.";
            AnalysisTwo = "- Difference between current confirmation date and current planned date.";

            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);

            TotalOrders = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Total);
            Average = string.Format("{0:n}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Average);
            PercNoConf = string.Format("{0:n}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.PercentUnconf);
            PercNoConfTotal = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.PercentUnconfTotal);
            TimeBucketOne = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_TwentyTwo);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_Fifteen_TwentyOne);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_Eight_Fourteen);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_One_Seven);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Zero);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.One_Seven);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Eight_Fourteen);
            TimeBucketEight = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Fifteen_TwentyOne);
            TimeBucketNine = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.TwentyTwo);

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

            Title = "Receipt Date vs Current Planed Date";
            Globals.CurrCategory = Title;
            ChangeCategory();

            TotalOrders = overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Total.ToString();
            Average = overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Average.ToString();
            TimeBucketOne = overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_TwentyTwo.ToString();
            TimeBucketTwo = overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_Fifteen_TwentyOne.ToString();
            TimeBucketThree = overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_Eight_Fourteen.ToString();
            TimeBucketFour = overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_One_Seven.ToString();
            TimeBucketFive = overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Zero.ToString();
            TimeBucketSix = overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.One_Seven.ToString();
            TimeBucketSeven = overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Eight_Fourteen.ToString();
            TimeBucketEight = overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Fifteen_TwentyOne.ToString();
            TimeBucketNine = overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.TwentyTwo.ToString();

            AnalysisOne = "- Will show if PO line has been received complete.";
            AnalysisTwo = "- Difference between final receipt date and current planned date.";

            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);

            TotalOrders = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Total);
            Average = string.Format("{0:n}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Average);
            TimeBucketOne = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_TwentyTwo);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_Fifteen_TwentyOne);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_Eight_Fourteen);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_One_Seven);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Zero);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.One_Seven);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Eight_Fourteen);
            TimeBucketEight = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Fifteen_TwentyOne);
            TimeBucketNine = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.TwentyTwo);

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

            Title = "Receipt Date vs Original Confirmed Date";
            Globals.CurrCategory = Title;
            ChangeCategory();

            TotalOrders = overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Total.ToString();
            Average = overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Average.ToString();
            PercNoConf = overallData.kpi.followUp.receiptDateVsOrigConfDate.data.PercentUnconf.ToString();
            TimeBucketOne = overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_TwentyTwo.ToString();
            TimeBucketTwo = overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_Fifteen_TwentyOne.ToString();
            TimeBucketThree = overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_Eight_Fourteen.ToString();
            TimeBucketFour = overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_One_Seven.ToString();
            TimeBucketFive = overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Zero.ToString();
            TimeBucketSix = overallData.kpi.followUp.receiptDateVsOrigConfDate.data.One_Seven.ToString();
            TimeBucketSeven = overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Eight_Fourteen.ToString();
            TimeBucketEight = overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Fifteen_TwentyOne.ToString();
            TimeBucketNine = overallData.kpi.followUp.receiptDateVsOrigConfDate.data.TwentyTwo.ToString();

            AnalysisOne = "- Will show if PO line has been received complete.";
            AnalysisTwo = "- Difference between final receipt date and the original confirmation date.";

            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);

            TotalOrders = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Total);
            Average = string.Format("{0:n}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Average);
            PercNoConf = string.Format("{0:n}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.PercentUnconf);
            PercNoConfTotal = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.PercentUnconfTotal);
            TimeBucketOne = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_TwentyTwo);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_Fifteen_TwentyOne);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_Eight_Fourteen);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_One_Seven);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Zero);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.One_Seven);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Eight_Fourteen);
            TimeBucketEight = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Fifteen_TwentyOne);
            TimeBucketNine = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.TwentyTwo);

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

            Title = "Receipt Date vs Current Confirmed Date";
            Globals.CurrCategory = Title;
            ChangeCategory();

            TotalOrders = overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Total.ToString();
            Average = overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Average.ToString();
            PercNoConf = overallData.kpi.followUp.receiptDateVsCurrConfDate.data.PercentUnconf.ToString();
            TimeBucketOne = overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_TwentyTwo.ToString();
            TimeBucketTwo = overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_Fifteen_TwentyOne.ToString();
            TimeBucketThree = overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_Eight_Fourteen.ToString();
            TimeBucketFour = overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_One_Seven.ToString();
            TimeBucketFive = overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Zero.ToString();
            TimeBucketSix = overallData.kpi.followUp.receiptDateVsCurrConfDate.data.One_Seven.ToString();
            TimeBucketSeven = overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Eight_Fourteen.ToString();
            TimeBucketEight = overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Fifteen_TwentyOne.ToString();
            TimeBucketNine = overallData.kpi.followUp.receiptDateVsCurrConfDate.data.TwentyTwo.ToString();

            AnalysisOne = "- Will show if PO line has been received complete.";
            AnalysisTwo = "- Difference between final receipt date and the current confirmation date.";

            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);

            TotalOrders = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Total);
            Average = string.Format("{0:n}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Average);
            PercNoConf = string.Format("{0:n}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.PercentUnconf);
            PercNoConfTotal = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.PercentUnconfTotal);
            TimeBucketOne = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_TwentyTwo);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_Fifteen_TwentyOne);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_Eight_Fourteen);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_One_Seven);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Zero);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.One_Seven);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Eight_Fourteen);
            TimeBucketEight = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Fifteen_TwentyOne);
            TimeBucketNine = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.TwentyTwo);

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
        public void ViewData_Click(object sender, EventArgs e)
        {
            try
            {
                Bunifu.Framework.UI.BunifuFlatButton btn = (Bunifu.Framework.UI.BunifuFlatButton)sender;
                int tag = int.Parse(btn.Tag.ToString());

                switch (ActiveCategory)
                {
                    case 0: // Initial Confirmation vs Current Confirmation
                        KpiDataTableLoader.FollowUp.LoadInitConfVsCurrConfDataTable(tag);
                        break;
                    case 1: // Final Confirmation Date vs Final Planned Date
                        KpiDataTableLoader.FollowUp.LoadFinalConfDateVsFinalPlanDateDataTable(tag);
                        break;
                    case 2: // Receipt Date vs Current Planned Date
                        KpiDataTableLoader.FollowUp.LoadRecDateVsCurrPlanDateDataTable(tag);
                        break;
                    case 3: // Receipt Date vs Orig Conf Date
                        KpiDataTableLoader.FollowUp.LoadRecDateVsOrigConfDateDataTable(tag);
                        break;
                    case 4: // Receipt Date vs Current Conf Date
                        KpiDataTableLoader.FollowUp.LoadRecDateVsCurrConfDateDataTable(tag);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Follow Up Viewer Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
