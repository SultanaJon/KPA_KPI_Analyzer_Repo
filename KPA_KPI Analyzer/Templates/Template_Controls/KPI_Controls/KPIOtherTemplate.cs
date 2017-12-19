using KPA_KPI_Analyzer.DataLoading;
using KPA_KPI_Analyzer.DataLoading.KPI_Data.DataTableLoader;
using KPA_KPI_Analyzer.Overall_Data;
using KPA_KPI_Analyzer.Values;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPI_Controls
{
    public partial class KPIOtherTemplate : UserControl
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
        public void LoadPanel(Overall data)
        {
            overallData = data;
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

            TimeBucketOne = ((int)overallData.kpi.other.prsCreated.data.GreaterThanZeroWeeks).ToString();
            TimeBucketTwo = ((int)overallData.kpi.other.prsCreated.data.GreaterThanMinusOneWeeks).ToString();
            TimeBucketThree = ((int)overallData.kpi.other.prsCreated.data.GreaterThanMinusTwoWeeks).ToString();
            TimeBucketFour = ((int)overallData.kpi.other.prsCreated.data.GreaterThanMinusThreeWeeks).ToString();
            TimeBucketFive = ((int)overallData.kpi.other.prsCreated.data.GreaterThanMinusFourWeeks).ToString();
            TimeBucketSix = ((int)overallData.kpi.other.prsCreated.data.GreaterThanMinusFiveWeeks).ToString();
            TimeBucketSeven = ((int)overallData.kpi.other.prsCreated.data.GreaterThanMinusSixWeeks).ToString();
            TimeBucketEight = ((int)overallData.kpi.other.prsCreated.data.GreaterThanMinusSevenWeeks).ToString();
            TimeBucketNine = ((int)overallData.kpi.other.prsCreated.data.GreaterThanMinusEightWeeks).ToString();
            TimeBucketTen = ((int)overallData.kpi.other.prsCreated.data.LessThanEightWeeks).ToString();


            AnalysisOne = "- Count of PRs by creation date.";
            AnalysisTwo = "- Difference between the date the PR was created and the todays date.";


            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);
            dp.addLabely(lbl_xLabelTen.Text, TimeBucketTen);
            
            TotalOrders = string.Format("{0:n0}", overallData.kpi.other.prsCreated.data.Total);
            TotalValue = string.Format("{0:n}", overallData.kpi.other.prsCreated.data.TotalValue);
            TimeBucketOne = string.Format("{0:n0}", overallData.kpi.other.prsCreated.data.GreaterThanZeroWeeks);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpi.other.prsCreated.data.GreaterThanMinusOneWeeks);
            TimeBucketThree =  string.Format("{0:n0}", overallData.kpi.other.prsCreated.data.GreaterThanMinusTwoWeeks);
            TimeBucketFour =  string.Format("{0:n0}", overallData.kpi.other.prsCreated.data.GreaterThanMinusThreeWeeks);
            TimeBucketFive =  string.Format("{0:n0}", overallData.kpi.other.prsCreated.data.GreaterThanMinusFourWeeks);
            TimeBucketSix =  string.Format("{0:n0}", overallData.kpi.other.prsCreated.data.GreaterThanMinusFiveWeeks);
            TimeBucketSeven =  string.Format("{0:n0}", overallData.kpi.other.prsCreated.data.GreaterThanMinusSixWeeks);
            TimeBucketEight =  string.Format("{0:n0}", overallData.kpi.other.prsCreated.data.GreaterThanMinusSevenWeeks);
            TimeBucketNine =  string.Format("{0:n0}", overallData.kpi.other.prsCreated.data.GreaterThanMinusEightWeeks);
            TimeBucketTen =  string.Format("{0:n0}", overallData.kpi.other.prsCreated.data.LessThanEightWeeks);



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

            TimeBucketOne = ((int)overallData.kpi.other.prsReleased.data.GreaterThanZeroWeeks).ToString();
            TimeBucketTwo = ((int)overallData.kpi.other.prsReleased.data.GreaterThanMinusOneWeeks).ToString();
            TimeBucketThree = ((int)overallData.kpi.other.prsReleased.data.GreaterThanMinusTwoWeeks).ToString();
            TimeBucketFour = ((int)overallData.kpi.other.prsReleased.data.GreaterThanMinusThreeWeeks).ToString();
            TimeBucketFive = ((int)overallData.kpi.other.prsReleased.data.GreaterThanMinusFourWeeks).ToString();
            TimeBucketSix = ((int)overallData.kpi.other.prsReleased.data.GreaterThanMinusFiveWeeks).ToString();
            TimeBucketSeven = ((int)overallData.kpi.other.prsReleased.data.GreaterThanMinusSixWeeks).ToString();
            TimeBucketEight = ((int)overallData.kpi.other.prsReleased.data.GreaterThanMinusSevenWeeks).ToString();
            TimeBucketNine = ((int)overallData.kpi.other.prsReleased.data.GreaterThanMinusEightWeeks).ToString();
            TimeBucketTen = ((int)overallData.kpi.other.prsReleased.data.LessThanEightWeeks).ToString();



            AnalysisOne = "- Count of PRs by release date.";
            AnalysisTwo = "- Difference between PR fully released date and todays date.";


            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);
            dp.addLabely(lbl_xLabelTen.Text, TimeBucketTen);


            TotalOrders = string.Format("{0:n0}", overallData.kpi.other.prsReleased.data.Total);
            TotalValue = string.Format("{0:n}", overallData.kpi.other.prsReleased.data.TotalValue);
            TimeBucketOne = string.Format("{0:n0}", overallData.kpi.other.prsReleased.data.GreaterThanZeroWeeks);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpi.other.prsReleased.data.GreaterThanMinusOneWeeks);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpi.other.prsReleased.data.GreaterThanMinusTwoWeeks);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpi.other.prsReleased.data.GreaterThanMinusThreeWeeks);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpi.other.prsReleased.data.GreaterThanMinusFourWeeks);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpi.other.prsReleased.data.GreaterThanMinusFiveWeeks);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpi.other.prsReleased.data.GreaterThanMinusSixWeeks);
            TimeBucketEight = string.Format("{0:n0}", overallData.kpi.other.prsReleased.data.GreaterThanMinusSevenWeeks);
            TimeBucketNine = string.Format("{0:n0}", overallData.kpi.other.prsReleased.data.GreaterThanMinusEightWeeks);
            TimeBucketTen = string.Format("{0:n0}", overallData.kpi.other.prsReleased.data.LessThanEightWeeks);

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

            TimeBucketOne = ((int)overallData.kpi.other.totalSpend.data.GreaterThanZeroWeeks).ToString();
            TimeBucketTwo = ((int)overallData.kpi.other.totalSpend.data.GreaterThanMinusOneWeeks).ToString();
            TimeBucketThree = ((int)overallData.kpi.other.totalSpend.data.GreaterThanMinusTwoWeeks).ToString();
            TimeBucketFour = ((int)overallData.kpi.other.totalSpend.data.GreaterThanMinusThreeWeeks).ToString();
            TimeBucketFive = ((int)overallData.kpi.other.totalSpend.data.GreaterThanMinusFourWeeks).ToString();
            TimeBucketSix = ((int)overallData.kpi.other.totalSpend.data.GreaterThanMinusFiveWeeks).ToString();
            TimeBucketSeven = ((int)overallData.kpi.other.totalSpend.data.GreaterThanMinusSixWeeks).ToString();
            TimeBucketEight = ((int)overallData.kpi.other.totalSpend.data.GreaterThanMinusSevenWeeks).ToString();
            TimeBucketNine = ((int)overallData.kpi.other.totalSpend.data.GreaterThanMinusEightWeeks).ToString();
            TimeBucketTen = ((int)overallData.kpi.other.totalSpend.data.LessThanEightWeeks).ToString();


            AnalysisOne = "- Value of PO Lines based on PO line Creation Date.";
            AnalysisTwo = "";


            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);
            dp.addLabely(lbl_xLabelTen.Text, TimeBucketTen);

            TotalOrders = string.Format("{0:n0}", overallData.kpi.other.totalSpend.data.Total);
            TotalValue = string.Format("{0:n}", overallData.kpi.other.totalSpend.data.TotalValue);
            TimeBucketOne = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanZeroWeeks);
            TimeBucketTwo = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanMinusOneWeeks);
            TimeBucketThree = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanMinusTwoWeeks);
            TimeBucketFour = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanMinusThreeWeeks);
            TimeBucketFive = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanMinusFourWeeks);
            TimeBucketSix = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanMinusFiveWeeks);
            TimeBucketSeven = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanMinusSixWeeks);
            TimeBucketEight = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanMinusSevenWeeks);
            TimeBucketNine = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanMinusEightWeeks);
            TimeBucketTen = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.LessThanEightWeeks);


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

            TimeBucketOne = ((int)overallData.kpi.other.prVsPOValue.data.GreaterThanZeroWeeks).ToString();
            TimeBucketTwo = ((int)overallData.kpi.other.prVsPOValue.data.GreaterThanMinusOneWeeks).ToString();
            TimeBucketThree = ((int)overallData.kpi.other.prVsPOValue.data.GreaterThanMinusTwoWeeks).ToString();
            TimeBucketFour = ((int)overallData.kpi.other.prVsPOValue.data.GreaterThanMinusThreeWeeks).ToString();
            TimeBucketFive = ((int)overallData.kpi.other.prVsPOValue.data.GreaterThanMinusFourWeeks).ToString();
            TimeBucketSix = ((int)overallData.kpi.other.prVsPOValue.data.GreaterThanMinusFiveWeeks).ToString();
            TimeBucketSeven = ((int)overallData.kpi.other.prVsPOValue.data.GreaterThanMinusSixWeeks).ToString();
            TimeBucketEight = ((int)overallData.kpi.other.prVsPOValue.data.GreaterThanMinusSevenWeeks).ToString();
            TimeBucketNine = ((int)overallData.kpi.other.prVsPOValue.data.GreaterThanMinusSevenWeeks).ToString();
            TimeBucketTen = ((int)overallData.kpi.other.prVsPOValue.data.LessThanEightWeeks).ToString();


            AnalysisOne = "- Based on PO line Creation Date.";
            AnalysisTwo = "- Variance of PO line value vs PR line value over time.";


            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);
            dp.addLabely(lbl_xLabelTen.Text, TimeBucketTen);


            TotalOrders = string.Format("{0:n0}", overallData.kpi.other.prVsPOValue.data.Total);
            TotalValue = string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.TotalValue);
            TimeBucketOne = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanZeroWeeks);
            TimeBucketTwo = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanMinusOneWeeks);
            TimeBucketThree = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanMinusTwoWeeks);
            TimeBucketFour = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanMinusThreeWeeks);
            TimeBucketFive = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanMinusFourWeeks);
            TimeBucketSix = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanMinusFiveWeeks);
            TimeBucketSeven = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanMinusSixWeeks);
            TimeBucketEight = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanMinusSevenWeeks);
            TimeBucketNine = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanMinusEightWeeks);
            TimeBucketTen = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.LessThanEightWeeks);


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

            TimeBucketOne = ((int)overallData.kpi.other.hotJobPrs.data.GreaterThanZeroWeeks).ToString();
            TimeBucketTwo = ((int)overallData.kpi.other.hotJobPrs.data.GreaterThanMinusOneWeeks).ToString();
            TimeBucketThree = ((int)overallData.kpi.other.hotJobPrs.data.GreaterThanMinusTwoWeeks).ToString();
            TimeBucketFour = ((int)overallData.kpi.other.hotJobPrs.data.GreaterThanMinusThreeWeeks).ToString();
            TimeBucketFive = ((int)overallData.kpi.other.hotJobPrs.data.GreaterThanMinusFourWeeks).ToString();
            TimeBucketSix = ((int)overallData.kpi.other.hotJobPrs.data.GreaterThanMinusFiveWeeks).ToString();
            TimeBucketSeven = ((int)overallData.kpi.other.hotJobPrs.data.GreaterThanMinusSixWeeks).ToString();
            TimeBucketEight = ((int)overallData.kpi.other.hotJobPrs.data.GreaterThanMinusSevenWeeks).ToString();
            TimeBucketNine = ((int)overallData.kpi.other.hotJobPrs.data.GreaterThanMinusEightWeeks).ToString();
            TimeBucketTen = ((int)overallData.kpi.other.hotJobPrs.data.LessThanEightWeeks).ToString();


            AnalysisOne = "- Will show for PRs which have Purchase Group of 'UHJ'.";
            AnalysisTwo = "- Difference between the date the PR was created and todays date.";


            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);
            dp.addLabely(lbl_xLabelTen.Text, TimeBucketTen);


            TotalOrders = string.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.Total);
            TotalValue = string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.TotalValue);
            TimeBucketOne =string.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.GreaterThanZeroWeeks);
            TimeBucketTwo =string.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusOneWeeks);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusTwoWeeks);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusThreeWeeks);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusFourWeeks);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusFiveWeeks);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusSixWeeks);
            TimeBucketEight = string.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusSevenWeeks);
            TimeBucketNine = string.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusEightWeeks);
            TimeBucketTen = string.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.LessThanEightWeeks);


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
