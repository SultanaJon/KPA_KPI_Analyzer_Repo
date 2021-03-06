﻿using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPIFollowUpTemplate : UserControl
    {
        Overall overallData;
        DataTable initConfVsCurrConf;
        DataTable finalConfDateVsFinalPlanDateDt;
        DataTable recDateVsCurrPlanDateDt;
        DataTable recDateVsOrigConfDateDt;
        DataTable recDateVsCurrConfDateDt;
        DataTable unconfirmed;




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
                    RenderOne();
                    break;
                case 1:
                    pnl_PercentagePanel.Visible = true;
                    RenderTwo();
                    break;
                case 2:
                    pnl_PercentagePanel.Visible = false;
                    RenderThree();
                    break;
                case 3:
                    pnl_PercentagePanel.Visible = true;
                    RenderFour();
                    break;
                case 4:
                    pnl_PercentagePanel.Visible = true;
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


            TotalOrders = String.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Total);
            Average = String.Format("{0:n}", overallData.kpi.followUp.initConfVsCurrConf.data.Average);
            PercNoConf = String.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.PercentUnconf);
            TimeBucketOne = String.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Minus_TwentyTwo);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Minus_Fifteen_TwentyOne);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Minus_Eight_Fourteen);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Minus_One_Seven);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Zero);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.One_Seven);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Eight_Fourteen);
            TimeBucketEight = String.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Fifteen_TwentyOne);
            TimeBucketNine = String.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.TwentyTwo);



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
            AnalysisTwo = "- Difference between the confirmation date and PR planned date.";



            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);




            TotalOrders = String.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Total);
            Average = String.Format("{0:n}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Average);
            PercNoConf = String.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.PercentUnconf);
            TimeBucketOne = String.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_TwentyTwo);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_Fifteen_TwentyOne);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_Eight_Fourteen);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_One_Seven);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Zero);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.One_Seven);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Eight_Fourteen);
            TimeBucketEight = String.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Fifteen_TwentyOne);
            TimeBucketNine = String.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.TwentyTwo);


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



            TotalOrders = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Total);
            Average = String.Format("{0:n}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Average);
            TimeBucketOne = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_TwentyTwo);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_Fifteen_TwentyOne);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_Eight_Fourteen);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_One_Seven);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Zero);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.One_Seven);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Eight_Fourteen);
            TimeBucketEight = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Fifteen_TwentyOne);
            TimeBucketNine = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.TwentyTwo);



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

            TotalOrders = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Total);
            Average = String.Format("{0:n}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Average);
            PercNoConf = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.PercentUnconf);
            TimeBucketOne = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_TwentyTwo);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_Fifteen_TwentyOne);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_Eight_Fourteen);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_One_Seven);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Zero);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.One_Seven);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Eight_Fourteen);
            TimeBucketEight = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Fifteen_TwentyOne);
            TimeBucketNine = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.TwentyTwo);


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

            TotalOrders = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Total);
            Average = String.Format("{0:n}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Average);
            PercNoConf = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.PercentUnconf);
            TimeBucketOne = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_TwentyTwo);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_Fifteen_TwentyOne);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_Eight_Fourteen);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_One_Seven);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Zero);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.One_Seven);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Eight_Fourteen);
            TimeBucketEight = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Fifteen_TwentyOne);
            TimeBucketNine = String.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.TwentyTwo);

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
                    case 0:
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //
                        // Initial Confirmation vs Current Confirmation
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        initConfVsCurrConf = new DataTable();
                        unconfirmed = new DataTable();


                        initConfVsCurrConf = Overall.posRecCompDt.Clone();
                        unconfirmed = Overall.posRecCompDt.Clone();



                        foreach (DataRow dr in Overall.posRecCompDt.Rows)
                        {
                            string[] strFirstConfDate = (dr["1st Conf Date"].ToString()).Split('/');
                            int firstConfYear = int.Parse(strFirstConfDate[2]);
                            int firstConfMonth = int.Parse(strFirstConfDate[0]);
                            int firstConfDay = int.Parse(strFirstConfDate[1]);


                            if (firstConfYear == 0 && firstConfMonth == 0 && firstConfDay == 0)
                            {
                                unconfirmed.ImportRow(dr);
                                continue;
                            }
                            else
                            {
                                firstConfYear = int.Parse(strFirstConfDate[2]);
                                firstConfMonth = int.Parse(strFirstConfDate[0].TrimStart('0'));
                                firstConfDay = int.Parse(strFirstConfDate[1].TrimStart('0'));
                            }

                            DateTime firstConfDate = new DateTime(firstConfYear, firstConfMonth, firstConfDay);

                            string[] delConfDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                            int delConfYear = int.Parse(delConfDate[2]);
                            int delConfMonth = int.Parse(delConfDate[0].TrimStart('0'));
                            int delConfDay = int.Parse(delConfDate[1].TrimStart('0'));

                            DateTime prPlanDate = new DateTime(delConfYear, delConfMonth, delConfDay);
                            double elapsedDays = (firstConfDate - prPlanDate).TotalDays;

                            switch (tag)
                            {
                                case 0:
                                    initConfVsCurrConf.ImportRow(dr);
                                    break;
                                case 1:
                                    if (elapsedDays <= (-22))
                                    {
                                        initConfVsCurrConf.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (elapsedDays > (-22) && elapsedDays <= (-15))
                                    {
                                        initConfVsCurrConf.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (elapsedDays > (-14) && elapsedDays <= (-8))
                                    {
                                        initConfVsCurrConf.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (elapsedDays > (-7) && elapsedDays <= (-1))
                                    {
                                        initConfVsCurrConf.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (elapsedDays == 0)
                                    {
                                        initConfVsCurrConf.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (elapsedDays >= 1 && elapsedDays <= 7)
                                    {
                                        initConfVsCurrConf.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (elapsedDays >= 8 && elapsedDays <= 14)
                                    {
                                        initConfVsCurrConf.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (elapsedDays >= 15 && elapsedDays <= 21)
                                    {
                                        initConfVsCurrConf.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (elapsedDays >= 22)
                                    {
                                        initConfVsCurrConf.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }


                        if(tag != 10)
                        {
                            using (DataViewer dv = new DataViewer() { Data = initConfVsCurrConf })
                            {
                                dv.LoadData();
                                dv.ShowDialog();
                            }
                        }
                        else
                        {
                            using (DataViewer dv = new DataViewer() { Data = unconfirmed })
                            {
                                dv.LoadData();
                                dv.ShowDialog();
                            }
                        }
                        
                        break;
                    case 1:
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //
                        // Final Confirmation Date Vs Final Planned Date
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        finalConfDateVsFinalPlanDateDt = new DataTable();
                        unconfirmed = new DataTable();


                        finalConfDateVsFinalPlanDateDt = Overall.posRecCompDt.Clone();
                        unconfirmed = Overall.posRecCompDt.Clone();



                        foreach (DataRow dr in Overall.posRecCompDt.Rows)
                        {
                            string[] strDelConfDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                            int finalConfYear = int.Parse(strDelConfDate[2]);
                            int finalConfMonth = int.Parse(strDelConfDate[0]);
                            int finalConfDay = int.Parse(strDelConfDate[1]);

                            if (finalConfYear == 0 && finalConfMonth == 0 && finalConfDay == 0)
                            {
                                unconfirmed.ImportRow(dr);
                                continue;
                            }
                            else
                            {
                                finalConfYear = int.Parse(strDelConfDate[2]);
                                finalConfMonth = int.Parse(strDelConfDate[0].TrimStart('0'));
                                finalConfDay = int.Parse(strDelConfDate[1].TrimStart('0'));
                            }

                            DateTime finalConfDate = new DateTime(finalConfYear, finalConfMonth, finalConfDay);


                            string[] strPrDelDate = (dr["PR Delivery Date"].ToString()).Split('/');
                            int delConfYear = int.Parse(strPrDelDate[2]);
                            int delConfMonth = int.Parse(strPrDelDate[0].TrimStart('0'));
                            int delConfDay = int.Parse(strPrDelDate[1].TrimStart('0'));

                            DateTime prPlanDate = new DateTime(delConfYear, delConfMonth, delConfDay);
                            double elapsedDays = (finalConfDate - prPlanDate).TotalDays;

                            switch (tag)
                            {
                                case 0:
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                    break;
                                case 1:
                                    if (elapsedDays <= (-22))
                                    {
                                        finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (elapsedDays > (-22) && elapsedDays <= (-15))
                                    {
                                        finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (elapsedDays > (-14) && elapsedDays <= (-8))
                                    {
                                        finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (elapsedDays > (-7) && elapsedDays <= (-1))
                                    {
                                        finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (elapsedDays == 0)
                                    {
                                        finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (elapsedDays >= 1 && elapsedDays <= 7)
                                    {
                                        finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (elapsedDays >= 8 && elapsedDays <= 14)
                                    {
                                        finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (elapsedDays >= 15 && elapsedDays <= 21)
                                    {
                                        finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (elapsedDays >= 22)
                                    {
                                        finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        if (tag != 10)
                        {
                            using (DataViewer dv = new DataViewer() { Data = finalConfDateVsFinalPlanDateDt })
                            {
                                dv.LoadData();
                                dv.ShowDialog();
                            }
                        }
                        else
                        {
                            using (DataViewer dv = new DataViewer() { Data = unconfirmed })
                            {
                                dv.LoadData();
                                dv.ShowDialog();
                            }
                        }
                        break;
                    case 2:
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //
                        // Receipt Date vs Current Planned Date
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        recDateVsCurrPlanDateDt = new DataTable();
                        recDateVsCurrPlanDateDt = Overall.posRecCompDt.Clone();

                        foreach (DataRow dr in Overall.posRecCompDt.Rows)
                        {
                            string[] strLastPORecDate = (dr["Last PO Rec#Date"].ToString()).Split('/');
                            int lastPORecDtYear = int.Parse(strLastPORecDate[2]);
                            int lastPORecDtMonth = int.Parse(strLastPORecDate[0]);
                            int lastPORecDtDay = int.Parse(strLastPORecDate[1]);

                            DateTime lastPORecDate = new DateTime(lastPORecDtYear, lastPORecDtMonth, lastPORecDtDay);

                            string[] strCurrPlanDate = (dr["Rescheduling date"].ToString()).Split('/');
                            int currConfYear = int.Parse(strCurrPlanDate[2]);
                            int currConfMonth = int.Parse(strCurrPlanDate[0]);
                            int currConfDay = int.Parse(strCurrPlanDate[1]);

                            if (currConfYear == 0 && currConfMonth == 0 && currConfDay == 0)
                            {
                                string[] strNewCurrConfDate = (dr["Delivery Date"].ToString()).Split('/');
                                currConfYear = int.Parse(strNewCurrConfDate[2]);
                                currConfMonth = int.Parse(strNewCurrConfDate[0].TrimStart('0'));
                                currConfDay = int.Parse(strNewCurrConfDate[1].TrimStart('0'));
                            }
                            else
                            {
                                currConfYear = int.Parse(strCurrPlanDate[2]);
                                currConfMonth = int.Parse(strCurrPlanDate[0].TrimStart('0'));
                                currConfDay = int.Parse(strCurrPlanDate[1].TrimStart('0'));
                            }

                            DateTime currPlanDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                            double elapsedDays = (lastPORecDate - currPlanDate).TotalDays;

                            switch (tag)
                            {
                                case 0:
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                    break;
                                case 1:
                                    if (elapsedDays <= (-22))
                                    {
                                        recDateVsCurrPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (elapsedDays > (-22) && elapsedDays <= (-15))
                                    {
                                        recDateVsCurrPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (elapsedDays > (-14) && elapsedDays <= (-8))
                                    {
                                        recDateVsCurrPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (elapsedDays > (-7) && elapsedDays <= (-1))
                                    {
                                        recDateVsCurrPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (elapsedDays == 0)
                                    {
                                        recDateVsCurrPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (elapsedDays >= 1 && elapsedDays <= 7)
                                    {
                                        recDateVsCurrPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (elapsedDays >= 8 && elapsedDays <= 14)
                                    {
                                        recDateVsCurrPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (elapsedDays >= 15 && elapsedDays <= 21)
                                    {
                                        recDateVsCurrPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (elapsedDays >= 22)
                                    {
                                        recDateVsCurrPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        using (DataViewer dv = new DataViewer() { Data = recDateVsCurrPlanDateDt })
                        {
                            dv.LoadData();
                            dv.ShowDialog();
                        }

                        break;
                    case 3:
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //
                        // Receipt Date vs Orig Conf Date
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        recDateVsOrigConfDateDt = new DataTable();
                        unconfirmed = new DataTable();


                        recDateVsOrigConfDateDt = Overall.posRecCompDt.Clone();
                        unconfirmed = Overall.posRecCompDt.Clone();



                        foreach (DataRow dr in Overall.posRecCompDt.Rows)
                        {
                            string[] strLastPORecDate = (dr["Last PO Rec#Date"].ToString()).Split('/');
                            int lastPORecDtYear = int.Parse(strLastPORecDate[2]);
                            int lastPORecDtMonth = int.Parse(strLastPORecDate[0]);
                            int lastPORecDtDay = int.Parse(strLastPORecDate[1]);

                            DateTime lastPORecDate = new DateTime(lastPORecDtYear, lastPORecDtMonth, lastPORecDtDay);

                            string[] strFirstConfDate = (dr["1st Conf Date"].ToString()).Split('/');
                            int firstConfYear = int.Parse(strFirstConfDate[2]);
                            int firstConfMonth = int.Parse(strFirstConfDate[0]);
                            int firstConfDay = int.Parse(strFirstConfDate[1]);

                            if (firstConfYear == 0 && firstConfMonth == 0 && firstConfDay == 0)
                            {
                                unconfirmed.ImportRow(dr);
                                continue;
                            }
                            else
                            {
                                firstConfYear = int.Parse(strFirstConfDate[2]);
                                firstConfMonth = int.Parse(strFirstConfDate[0].TrimStart('0'));
                                firstConfDay = int.Parse(strFirstConfDate[1].TrimStart('0'));
                            }

                            DateTime firstConfDate = new DateTime(firstConfYear, firstConfMonth, firstConfDay);
                            double elapsedDays = (lastPORecDate - firstConfDate).TotalDays;

                            switch (tag)
                            {
                                case 0:
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                    break;
                                case 1:
                                    if (elapsedDays <= (-22))
                                    {
                                        recDateVsOrigConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (elapsedDays > (-22) && elapsedDays <= (-15))
                                    {
                                        recDateVsOrigConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (elapsedDays > (-14) && elapsedDays <= (-8))
                                    {
                                        recDateVsOrigConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (elapsedDays > (-7) && elapsedDays <= (-1))
                                    {
                                        recDateVsOrigConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (elapsedDays == 0)
                                    {
                                        recDateVsOrigConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (elapsedDays >= 1 && elapsedDays <= 7)
                                    {
                                        recDateVsOrigConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (elapsedDays >= 8 && elapsedDays <= 14)
                                    {
                                        recDateVsOrigConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (elapsedDays >= 15 && elapsedDays <= 21)
                                    {
                                        recDateVsOrigConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (elapsedDays >= 22)
                                    {
                                        recDateVsOrigConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        if(tag != 10)
                        {
                            using (DataViewer dv = new DataViewer() { Data = recDateVsOrigConfDateDt })
                            {
                                dv.LoadData();
                                dv.ShowDialog();
                            }
                        }
                        else
                        {
                            using (DataViewer dv = new DataViewer() { Data = unconfirmed })
                            {
                                dv.LoadData();
                                dv.ShowDialog();
                            }
                        }
                        break;
                    case 4:
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //
                        // Receipt Date vs Current Conf Date
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        recDateVsCurrConfDateDt = new DataTable();
                        unconfirmed = new DataTable();


                        recDateVsCurrConfDateDt = Overall.posRecCompDt.Clone();
                        unconfirmed = Overall.posRecCompDt.Clone();



                        foreach (DataRow dr in Overall.posRecCompDt.Rows)
                        {
                            string[] strLastPORecDate = (dr["Last PO Rec#Date"].ToString()).Split('/');
                            int lastPORecDtYear = int.Parse(strLastPORecDate[2]);
                            int lastPORecDtMonth = int.Parse(strLastPORecDate[0]);
                            int lastPORecDtDay = int.Parse(strLastPORecDate[1]);

                            DateTime lastPORecDate = new DateTime(lastPORecDtYear, lastPORecDtMonth, lastPORecDtDay);

                            string[] strCurrConfDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                            int currConfYear = int.Parse(strCurrConfDate[2]);
                            int currConfMonth = int.Parse(strCurrConfDate[0]);
                            int currConfDay = int.Parse(strCurrConfDate[1]);

                            if (currConfYear == 0 && currConfMonth == 0 && currConfDay == 0)
                            {
                                unconfirmed.ImportRow(dr);
                                continue;
                            }
                            else
                            {
                                currConfYear = int.Parse(strCurrConfDate[2]);
                                currConfMonth = int.Parse(strCurrConfDate[0].TrimStart('0'));
                                currConfDay = int.Parse(strCurrConfDate[1].TrimStart('0'));
                            }
                            DateTime currConfDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                            double elapsedDays = (lastPORecDate - currConfDate).TotalDays;

                            switch (tag)
                            {
                                case 0:
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                    break;
                                case 1:
                                    if (elapsedDays <= (-22))
                                    {
                                        recDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (elapsedDays > (-22) && elapsedDays <= (-15))
                                    {
                                        recDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (elapsedDays > (-14) && elapsedDays <= (-8))
                                    {
                                        recDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (elapsedDays > (-7) && elapsedDays <= (-1))
                                    {
                                        recDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (elapsedDays == 0)
                                    {
                                        recDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (elapsedDays >= 1 && elapsedDays <= 7)
                                    {
                                        recDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (elapsedDays >= 8 && elapsedDays <= 14)
                                    {
                                        recDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (elapsedDays >= 15 && elapsedDays <= 21)
                                    {
                                        recDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (elapsedDays >= 22)
                                    {
                                        recDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        if (tag != 10)
                        {
                            using (DataViewer dv = new DataViewer() { Data = recDateVsCurrConfDateDt })
                            {
                                dv.LoadData();
                                dv.ShowDialog();
                            }
                        }
                        else
                        {
                            using (DataViewer dv = new DataViewer() { Data = unconfirmed })
                            {
                                dv.LoadData();
                                dv.ShowDialog();
                            }
                        }
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
