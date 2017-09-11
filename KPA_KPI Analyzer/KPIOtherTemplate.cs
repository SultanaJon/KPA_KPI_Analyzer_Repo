using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using KPA_KPI_Analyzer.FilterFeeature;

namespace KPA_KPI_Analyzer
{
    public partial class KPIOtherTemplate : UserControl
    {
        Overall overallData;
        DataTable prsCreated;
        DataTable prReleased;
        DataTable totalSpend;
        DataTable prVsPOValue;
        DataTable hotJobPRs;



        public delegate void UpdateCategoryHandler(string categoryName);
        public static event UpdateCategoryHandler ChangeCategory;


        /// <summary>
        /// Boolean value indicating whether the data was loaded into the dataviz control
        /// </summary>
        bool DatavizLoaded { get; set; }




        /// <summary>
        /// Current selected country to display in the data viewer
        /// </summary>
        public string CurrCountry { get; set; }


        /// <summary>
        /// Current selected performance to display in the data viewer
        /// </summary>
        public string CurrPerformance { get; set; }


        /// <summary>
        /// Current selected section to display in the data viewer
        /// </summary>
        public string CurrSection { get; set; }



        /// <summary>
        /// Current selected category to display in the data viewer
        /// </summary>
        public string CurrCategory { get; set; }



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
            CurrCategory = "PRs Created";
            ChangeCategory(CurrCategory);
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

            Title = "PRs Created";
            ChangeCategory(Title);
            CurrCategory = Title;

            TimeBucketOne = ((int)overallData.kpi.other.prsCreated.data.ZeroWeeks).ToString();
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
            TimeBucketOne = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.ZeroWeeks);
            TimeBucketTwo = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.GreaterThanMinusOneWeeks);
            TimeBucketThree = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.GreaterThanMinusTwoWeeks);
            TimeBucketFour = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.GreaterThanMinusThreeWeeks);
            TimeBucketFive = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.GreaterThanMinusFourWeeks);
            TimeBucketSix = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.GreaterThanMinusFiveWeeks);
            TimeBucketSeven = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.GreaterThanMinusSixWeeks);
            TimeBucketEight = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.GreaterThanMinusSevenWeeks);
            TimeBucketNine = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.GreaterThanMinusEightWeeks);
            TimeBucketTen = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.LessThanEightWeeks);



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

            Title = "PRs Released";
            ChangeCategory(Title);
            CurrCategory = Title;

            TimeBucketOne = ((int)overallData.kpi.other.prsReleased.data.ZeroWeeks).ToString();
            TimeBucketTwo = ((int)overallData.kpi.other.prsReleased.data.GreaterThanMinusOneWeeks).ToString();
            TimeBucketThree = ((int)overallData.kpi.other.prsReleased.data.GreaterThanMinusTwoWeeks).ToString();
            TimeBucketFour = ((int)overallData.kpi.other.prsReleased.data.GreaterThanMinusThreeWeeks).ToString();
            TimeBucketFive = ((int)overallData.kpi.other.prsReleased.data.GreaterThanMinusFourWeeks).ToString();
            TimeBucketSix = ((int)overallData.kpi.other.prsReleased.data.GreaterThanMinusFiveWeeks).ToString();
            TimeBucketSeven = ((int)overallData.kpi.other.prsReleased.data.GreaterThanMinusSixWeeks).ToString();
            TimeBucketEight = ((int)overallData.kpi.other.prsReleased.data.GreaterThanMinusSevenWeeks).ToString();
            TimeBucketNine = ((int)overallData.kpi.other.prsReleased.data.GreaterThanMinusEightWeeks).ToString();
            TimeBucketTen = ((int)overallData.kpi.other.prsReleased.data.LessThanEightWeeks).ToString();



            AnalysisOne = "- Count of PRs by 2nd level release date.";
            AnalysisTwo = "- Count of PRs by final release date.";


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
            TimeBucketOne = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.ZeroWeeks);
            TimeBucketTwo = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.GreaterThanMinusOneWeeks);
            TimeBucketThree = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.GreaterThanMinusTwoWeeks);
            TimeBucketFour = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.GreaterThanMinusThreeWeeks);
            TimeBucketFive = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.GreaterThanMinusFourWeeks);
            TimeBucketSix = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.GreaterThanMinusFiveWeeks);
            TimeBucketSeven = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.GreaterThanMinusSixWeeks);
            TimeBucketEight = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.GreaterThanMinusSevenWeeks);
            TimeBucketNine = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.GreaterThanMinusEightWeeks);
            TimeBucketTen = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.LessThanEightWeeks);

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

            Title = "Total Spend";
            ChangeCategory(Title);
            CurrCategory = Title;

            TimeBucketOne = ((int)overallData.kpi.other.totalSpend.data.ZeroWeeks).ToString();
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
            TimeBucketOne = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.ZeroWeeks);
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

            Title = "PR vs PO Value";
            ChangeCategory(Title);
            CurrCategory = Title;

            TimeBucketOne = ((int)overallData.kpi.other.prVsPOValue.data.ZeroWeeks).ToString();
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
            TimeBucketOne = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.ZeroWeeks);
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

            Title = "Hot Job PRs";
            ChangeCategory(Title);
            CurrCategory = Title;

            TimeBucketOne = ((int)overallData.kpi.other.hotJobPrs.data.ZeroWeeks).ToString();
            TimeBucketTwo = ((int)overallData.kpi.other.hotJobPrs.data.GreaterThanMinusOneWeeks).ToString();
            TimeBucketThree = ((int)overallData.kpi.other.hotJobPrs.data.GreaterThanMinusTwoWeeks).ToString();
            TimeBucketFour = ((int)overallData.kpi.other.hotJobPrs.data.GreaterThanMinusThreeWeeks).ToString();
            TimeBucketFive = ((int)overallData.kpi.other.hotJobPrs.data.GreaterThanMinusFourWeeks).ToString();
            TimeBucketSix = ((int)overallData.kpi.other.hotJobPrs.data.GreaterThanMinusFiveWeeks).ToString();
            TimeBucketSeven = ((int)overallData.kpi.other.hotJobPrs.data.GreaterThanMinusSixWeeks).ToString();
            TimeBucketEight = ((int)overallData.kpi.other.hotJobPrs.data.GreaterThanMinusSevenWeeks).ToString();
            TimeBucketNine = ((int)overallData.kpi.other.hotJobPrs.data.GreaterThanMinusEightWeeks).ToString();
            TimeBucketTen = ((int)overallData.kpi.other.hotJobPrs.data.LessThanEightWeeks).ToString();


            AnalysisOne = "- Will show fo rPRs which have Purchase Group of 'UHJ'.";
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


            TotalOrders = "$" + string.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.Total);
            TotalValue = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.TotalValue);
            TimeBucketOne = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.ZeroWeeks);
            TimeBucketTwo = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusOneWeeks);
            TimeBucketThree = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusTwoWeeks);
            TimeBucketFour = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusThreeWeeks);
            TimeBucketFive = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusFourWeeks);
            TimeBucketSix = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusFiveWeeks);
            TimeBucketSeven = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusSixWeeks);
            TimeBucketEight = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusSevenWeeks);
            TimeBucketNine = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusEightWeeks);
            TimeBucketTen = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.LessThanEightWeeks);


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
                        // PRs Created
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        prsCreated = new DataTable();
                        prsCreated = Overall.AllDt.Clone();



                        foreach (DataRow dr in Overall.AllDt.Rows)
                        {
                            if (Filters.FilterByPrDateRange)
                            {
                                // The user wants to filter by PR date range
                                string[] requisnDate = (dr["Requisn Date"].ToString()).Split('/');
                                int reqYear = int.Parse(requisnDate[2]);
                                int reqMonth = int.Parse(requisnDate[0].TrimStart('0'));
                                int reqDay = int.Parse(requisnDate[1].TrimStart('0'));
                                DateTime reqTestDate = new DateTime(reqYear, reqMonth, reqDay);

                                if (reqTestDate < Filters.PrFromDate || reqTestDate > Filters.PrToDate)
                                {
                                    // The PR date is not within the PR date range.
                                    continue;
                                }
                            }

                            if (Filters.FilterByPoDateRange)
                            {
                                // The user wnats to filter by PO date range
                                string[] strPODate = (dr["PO Date"].ToString()).Split('/');
                                int poYear = int.Parse(strPODate[2]);
                                int poMonth = int.Parse(strPODate[0]);
                                int poDay = int.Parse(strPODate[1]);

                                if (poYear == 0 && poMonth == 0 && poDay == 0)
                                {
                                    // This record is not a PO so we dont care about it
                                    continue;
                                }
                                else
                                {
                                    poYear = int.Parse(strPODate[2]);
                                    poMonth = int.Parse(strPODate[0].TrimStart('0'));
                                    poDay = int.Parse(strPODate[1].TrimStart('0'));
                                }

                                DateTime poTestDate = new DateTime(poYear, poMonth, poDay);

                                if (poTestDate < Filters.PoFromDate || poTestDate > Filters.PoToDate)
                                {
                                    // The PO date is not within the PO date range.
                                    continue;
                                }
                            }



                            string[] strReqDate = (dr["Requisn Date"].ToString()).Split('/');
                            int reqDateYear = int.Parse(strReqDate[2]);
                            int reqDateMonth = int.Parse(strReqDate[0].TrimStart('0'));
                            int reqDateDay = int.Parse(strReqDate[1].TrimStart('0'));

                            DateTime prReqDate = new DateTime(reqDateYear, reqDateMonth, reqDateDay);

                            DateTime today = DateTime.Now.Date;
                            double elapsedDays = (prReqDate - today).TotalDays;
                            double weeks = Math.Floor(elapsedDays / 7);

                            switch (tag)
                            {
                                case 0:
                                    prsCreated.ImportRow(dr);
                                    break;
                                case 1:
                                    if (weeks == 0)
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (weeks >= (-1) && weeks < 0)
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (weeks >= (-2) && weeks < (-1))
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (weeks >= (-3) && weeks < (-2))
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (weeks >= (-4) && weeks < (-3))
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (weeks >= (-5) && weeks < (-4))
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (weeks >= (-6) && weeks < (-5))
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (weeks >= (-7) && weeks < (-6))
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (weeks >= (-8) && weeks < (-7))
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                case 10:
                                    if (weeks < (-8))
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        using (DataViewer dv = new DataViewer() { Data = prsCreated, Country = CurrCountry, Performance = CurrPerformance, Section = CurrSection, Category = CurrCategory })
                        {
                            dv.LoadData();
                            dv.ShowDialog();
                        }
                        break;
                    case 1:
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //
                        // PRs Released
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        prReleased = new DataTable();
                        prReleased = Overall.pr2ndLvlRelDateDt.Clone();



                        foreach (DataRow dr in Overall.pr2ndLvlRelDateDt.Rows)
                        {
                            if (Filters.FilterByPrDateRange)
                            {
                                // The user wants to filter by PR date range
                                string[] requisnDate = (dr["Requisn Date"].ToString()).Split('/');
                                int reqYear = int.Parse(requisnDate[2]);
                                int reqMonth = int.Parse(requisnDate[0].TrimStart('0'));
                                int reqDay = int.Parse(requisnDate[1].TrimStart('0'));
                                DateTime reqTestDate = new DateTime(reqYear, reqMonth, reqDay);

                                if (reqTestDate < Filters.PrFromDate || reqTestDate > Filters.PrToDate)
                                {
                                    // The PR date is not within the PR date range.
                                    continue;
                                }
                            }

                            if (Filters.FilterByPoDateRange)
                            {
                                // The user wnats to filter by PO date range
                                string[] strPODate = (dr["PO Date"].ToString()).Split('/');
                                int poYear = int.Parse(strPODate[2]);
                                int poMonth = int.Parse(strPODate[0]);
                                int poDay = int.Parse(strPODate[1]);

                                if (poYear == 0 && poMonth == 0 && poDay == 0)
                                {
                                    // This record is not a PO so we dont care about it
                                    continue;
                                }
                                else
                                {
                                    poYear = int.Parse(strPODate[2]);
                                    poMonth = int.Parse(strPODate[0].TrimStart('0'));
                                    poDay = int.Parse(strPODate[1].TrimStart('0'));
                                }

                                DateTime poTestDate = new DateTime(poYear, poMonth, poDay);

                                if (poTestDate < Filters.PoFromDate || poTestDate > Filters.PoToDate)
                                {
                                    // The PO date is not within the PO date range.
                                    continue;
                                }
                            }



                            string[] strPr2ndLvlRelDt = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                            int pr2ndLvlRelDtYear = int.Parse(strPr2ndLvlRelDt[2]);
                            int pr2ndLvlRelDtMonth = int.Parse(strPr2ndLvlRelDt[0].TrimStart('0'));
                            int pr2ndLvlRelDtDay = int.Parse(strPr2ndLvlRelDt[1].TrimStart('0'));

                            DateTime pr2ndLvlRelDt = new DateTime(pr2ndLvlRelDtYear, pr2ndLvlRelDtMonth, pr2ndLvlRelDtDay);
                            DateTime today = DateTime.Now.Date;
                            double elapsedDays = (pr2ndLvlRelDt - today).TotalDays;
                            double weeks = Math.Floor(elapsedDays / 7);

                            switch (tag)
                            {
                                case 0:
                                    prReleased.ImportRow(dr);
                                    break;
                                case 1:
                                    if (weeks == 0)
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (weeks >= (-1) && weeks < 0)
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (weeks >= (-2) && weeks < (-1))
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (weeks >= (-3) && weeks < (-2))
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (weeks >= (-4) && weeks < (-3))
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (weeks >= (-5) && weeks < (-4))
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (weeks >= (-6) && weeks < (-5))
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (weeks >= (-7) && weeks < (-6))
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (weeks >= (-8) && weeks < (-7))
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                case 10:
                                    if (weeks < (-8))
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        using (DataViewer dv = new DataViewer() { Data = prReleased, Country = CurrCountry, Performance = CurrPerformance, Section = CurrSection, Category = CurrCategory })
                        {
                            dv.LoadData();
                            dv.ShowDialog();
                        }
                        break;
                    case 2:
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //
                        // Total Spend
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        totalSpend = new DataTable();
                        totalSpend = Overall.prsOnPOsDt.Clone();



                        foreach (DataRow dr in Overall.prsOnPOsDt.Rows)
                        {
                            if (Filters.FilterByPrDateRange)
                            {
                                // The user wants to filter by PR date range
                                string[] requisnDate = (dr["Requisn Date"].ToString()).Split('/');
                                int reqYear = int.Parse(requisnDate[2]);
                                int reqMonth = int.Parse(requisnDate[0].TrimStart('0'));
                                int reqDay = int.Parse(requisnDate[1].TrimStart('0'));
                                DateTime reqTestDate = new DateTime(reqYear, reqMonth, reqDay);

                                if (reqTestDate < Filters.PrFromDate || reqTestDate > Filters.PrToDate)
                                {
                                    // The PR date is not within the PR date range.
                                    continue;
                                }
                            }

                            if (Filters.FilterByPoDateRange)
                            {
                                // The user wnats to filter by PO date range
                                string[] strPODate = (dr["PO Date"].ToString()).Split('/');
                                int poYear = int.Parse(strPODate[2]);
                                int poMonth = int.Parse(strPODate[0]);
                                int poDay = int.Parse(strPODate[1]);

                                if (poYear == 0 && poMonth == 0 && poDay == 0)
                                {
                                    // This record is not a PO so we dont care about it
                                    continue;
                                }
                                else
                                {
                                    poYear = int.Parse(strPODate[2]);
                                    poMonth = int.Parse(strPODate[0].TrimStart('0'));
                                    poDay = int.Parse(strPODate[1].TrimStart('0'));
                                }

                                DateTime poTestDate = new DateTime(poYear, poMonth, poDay);

                                if (poTestDate < Filters.PoFromDate || poTestDate > Filters.PoToDate)
                                {
                                    // The PO date is not within the PO date range.
                                    continue;
                                }
                            }



                            string[] strPoCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                            int poCreateDtYear = int.Parse(strPoCreateDt[2]);
                            int poCreateDtMonth = int.Parse(strPoCreateDt[0].TrimStart('0'));
                            int poCreateDtDay = int.Parse(strPoCreateDt[1].TrimStart('0'));

                            DateTime poCreateDate = new DateTime(poCreateDtYear, poCreateDtMonth, poCreateDtDay);
                            DateTime today = DateTime.Now.Date;
                            double elapsedDays = (poCreateDate - today).TotalDays;
                            double weeks = Math.Floor(elapsedDays / 7);

                            switch (tag)
                            {
                                case 0:
                                    totalSpend.ImportRow(dr);
                                    break;
                                case 1:
                                    if (weeks == 0)
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (weeks >= (-1) && weeks < 0)
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (weeks >= (-2) && weeks < (-1))
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (weeks >= (-3) && weeks < (-2))
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (weeks >= (-4) && weeks < (-3))
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (weeks >= (-5) && weeks < (-4))
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (weeks >= (-6) && weeks < (-5))
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (weeks >= (-7) && weeks < (-6))
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (weeks >= (-8) && weeks < (-7))
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                case 10:
                                    if (weeks < (-8))
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        using (DataViewer dv = new DataViewer() { Data = totalSpend, Country = CurrCountry, Performance = CurrPerformance, Section = CurrSection, Category = CurrCategory })
                        {
                            dv.LoadData();
                            dv.ShowDialog();
                        }
                        break;
                    case 3:
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //
                        // PR vs PO Value
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        prVsPOValue = new DataTable();
                        prVsPOValue = Overall.prsOnPOsDt.Clone();



                        foreach (DataRow dr in Overall.prsOnPOsDt.Rows)
                        {
                            if (Filters.FilterByPrDateRange)
                            {
                                // The user wants to filter by PR date range
                                string[] requisnDate = (dr["Requisn Date"].ToString()).Split('/');
                                int reqYear = int.Parse(requisnDate[2]);
                                int reqMonth = int.Parse(requisnDate[0].TrimStart('0'));
                                int reqDay = int.Parse(requisnDate[1].TrimStart('0'));
                                DateTime reqTestDate = new DateTime(reqYear, reqMonth, reqDay);

                                if (reqTestDate < Filters.PrFromDate || reqTestDate > Filters.PrToDate)
                                {
                                    // The PR date is not within the PR date range.
                                    continue;
                                }
                            }

                            if (Filters.FilterByPoDateRange)
                            {
                                // The user wnats to filter by PO date range
                                string[] strPODate = (dr["PO Date"].ToString()).Split('/');
                                int poYear = int.Parse(strPODate[2]);
                                int poMonth = int.Parse(strPODate[0]);
                                int poDay = int.Parse(strPODate[1]);

                                if (poYear == 0 && poMonth == 0 && poDay == 0)
                                {
                                    // This record is not a PO so we dont care about it
                                    continue;
                                }
                                else
                                {
                                    poYear = int.Parse(strPODate[2]);
                                    poMonth = int.Parse(strPODate[0].TrimStart('0'));
                                    poDay = int.Parse(strPODate[1].TrimStart('0'));
                                }

                                DateTime poTestDate = new DateTime(poYear, poMonth, poDay);

                                if (poTestDate < Filters.PoFromDate || poTestDate > Filters.PoToDate)
                                {
                                    // The PO date is not within the PO date range.
                                    continue;
                                }
                            }



                            string[] strPoCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                            int poCreateDtYear = int.Parse(strPoCreateDt[2]);
                            int poCreateDtMonth = int.Parse(strPoCreateDt[0].TrimStart('0'));
                            int poCreateDtDay = int.Parse(strPoCreateDt[1].TrimStart('0'));

                            DateTime poCreateDate = new DateTime(poCreateDtYear, poCreateDtMonth, poCreateDtDay);

                            DateTime today = DateTime.Now.Date;
                            double elapsedDays = (today - poCreateDate).TotalDays;
                            double weeks = Math.Floor(elapsedDays / 7);

                            switch (tag)
                            {
                                case 0:
                                    prVsPOValue.ImportRow(dr);
                                    break;
                                case 1:
                                    if (weeks == 0)
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (weeks >= (-1) && weeks < 0)
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (weeks >= (-2) && weeks < (-1))
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (weeks >= (-3) && weeks < (-2))
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (weeks >= (-4) && weeks < (-3))
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (weeks >= (-5) && weeks < (-4))
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (weeks >= (-6) && weeks < (-5))
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (weeks >= (-7) && weeks < (-6))
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (weeks >= (-8) && weeks < (-7))
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 10:
                                    if (weeks < (-8))
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        using (DataViewer dv = new DataViewer() { Data = prVsPOValue, Country = CurrCountry, Performance = CurrPerformance, Section = CurrSection, Category = CurrCategory })
                        {
                            dv.LoadData();
                            dv.ShowDialog();
                        }
                        break;
                    case 4:
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //
                        // Hot Job PRs
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        hotJobPRs = new DataTable();
                        hotJobPRs = Overall.AllDt.Clone();



                        foreach (DataRow dr in Overall.AllDt.Rows)
                        {
                            if (Filters.FilterByPrDateRange)
                            {
                                // The user wants to filter by PR date range
                                string[] requisnDate = (dr["Requisn Date"].ToString()).Split('/');
                                int reqYear = int.Parse(requisnDate[2]);
                                int reqMonth = int.Parse(requisnDate[0].TrimStart('0'));
                                int reqDay = int.Parse(requisnDate[1].TrimStart('0'));
                                DateTime reqTestDate = new DateTime(reqYear, reqMonth, reqDay);

                                if (reqTestDate < Filters.PrFromDate || reqTestDate > Filters.PrToDate)
                                {
                                    // The PR date is not within the PR date range.
                                    continue;
                                }
                            }

                            if (Filters.FilterByPoDateRange)
                            {
                                // The user wnats to filter by PO date range
                                string[] strPODate = (dr["PO Date"].ToString()).Split('/');
                                int poYear = int.Parse(strPODate[2]);
                                int poMonth = int.Parse(strPODate[0]);
                                int poDay = int.Parse(strPODate[1]);

                                if (poYear == 0 && poMonth == 0 && poDay == 0)
                                {
                                    // This record is not a PO so we dont care about it
                                    continue;
                                }
                                else
                                {
                                    poYear = int.Parse(strPODate[2]);
                                    poMonth = int.Parse(strPODate[0].TrimStart('0'));
                                    poDay = int.Parse(strPODate[1].TrimStart('0'));
                                }

                                DateTime poTestDate = new DateTime(poYear, poMonth, poDay);

                                if (poTestDate < Filters.PoFromDate || poTestDate > Filters.PoToDate)
                                {
                                    // The PO date is not within the PO date range.
                                    continue;
                                }
                            }



                            if (dr["Purch# Group"].ToString() != "UHJ")
                                continue;

                            string[] strPrReqDt = (dr["Requisn Date"].ToString()).Split('/');
                            int reqDateYear = int.Parse(strPrReqDt[2]);
                            int reqDateMonth = int.Parse(strPrReqDt[0].TrimStart('0'));
                            int reqDateDay = int.Parse(strPrReqDt[1].TrimStart('0'));

                            DateTime reqDate = new DateTime(reqDateYear, reqDateMonth, reqDateDay);
                            DateTime today = DateTime.Now.Date;
                            double elapsedDays = (reqDate - today).TotalDays;
                            double weeks = Math.Floor(elapsedDays / 7);

                            switch (tag)
                            {
                                case 0:
                                    hotJobPRs.ImportRow(dr);
                                    break;
                                case 1:
                                    if (weeks == 0)
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (weeks >= (-1) && weeks < 0)
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (weeks >= (-2) && weeks < (-1))
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (weeks >= (-3) && weeks < (-2))
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (weeks >= (-4) && weeks < (-3))
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (weeks >= (-5) && weeks < (-4))
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (weeks >= (-6) && weeks < (-5))
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (weeks >= (-7) && weeks < (-6))
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (weeks >= (-8) && weeks < (-7))
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                case 10:
                                    if (weeks < (-8))
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        using (DataViewer dv = new DataViewer() { Data = hotJobPRs, Country = CurrCountry, Performance = CurrPerformance, Section = CurrSection, Category = CurrCategory })
                        {
                            dv.LoadData();
                            dv.ShowDialog();
                        }
                        break;
                    default:
                        
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Other Data Viewer Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
