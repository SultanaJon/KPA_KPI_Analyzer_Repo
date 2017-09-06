using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

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
        private string Title { get { return lbl_title.Text; } set { lbl_title.Text = value; } }
        private string AnalysisOne { get { return lbl_analysisOne.Text; } set { lbl_analysisOne.Text = value;  } }
        private string AnalysisTwo { get { return lbl_analysisTwo.Text; } set { lbl_analysisTwo.Text = value;  } }
        private string TotalValue { get { return lbl_totalValue.Text; } set { lbl_totalValue.Text = "$" + value; } }
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

            TimeBucketOne = overallData.kpi.other.prsCreated.data.Zero.ToString();
            TimeBucketTwo = overallData.kpi.other.prsCreated.data.LessOneWeek.ToString();
            TimeBucketThree = overallData.kpi.other.prsCreated.data.LessTwoWeeks.ToString();
            TimeBucketFour = overallData.kpi.other.prsCreated.data.LessThreeWeeks.ToString();
            TimeBucketFive = overallData.kpi.other.prsCreated.data.LessFourWeeks.ToString();
            TimeBucketSix = overallData.kpi.other.prsCreated.data.LessFiveWeeks.ToString();
            TimeBucketSeven = overallData.kpi.other.prsCreated.data.LessSixWeeks.ToString();
            TimeBucketEight = overallData.kpi.other.prsCreated.data.LessSevenWeeks.ToString();
            TimeBucketNine = overallData.kpi.other.prsCreated.data.LessEightWeeks.ToString();
            TimeBucketTen = overallData.kpi.other.prsCreated.data.LessNinePlusWeeks.ToString();


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

            TotalOrders = String.Format("{0:n0}", overallData.kpi.other.prsCreated.data.Total);
            TotalValue = String.Format("{0:n}", overallData.kpi.other.prsCreated.data.TotalValue);
            TimeBucketOne = String.Format("{0:n0}", overallData.kpi.other.prsCreated.data.Zero);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpi.other.prsCreated.data.LessOneWeek);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpi.other.prsCreated.data.LessTwoWeeks);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpi.other.prsCreated.data.LessThreeWeeks);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpi.other.prsCreated.data.LessFourWeeks);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpi.other.prsCreated.data.LessFiveWeeks);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpi.other.prsCreated.data.LessSixWeeks);
            TimeBucketEight = String.Format("{0:n0}", overallData.kpi.other.prsCreated.data.LessSevenWeeks);
            TimeBucketNine = String.Format("{0:n0}", overallData.kpi.other.prsCreated.data.LessEightWeeks);
            TimeBucketTen = String.Format("{0:n0}", overallData.kpi.other.prsCreated.data.LessNinePlusWeeks);



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

            TimeBucketOne = overallData.kpi.other.prsReleased.data.Zero.ToString();
            TimeBucketTwo = overallData.kpi.other.prsReleased.data.LessOneWeek.ToString();
            TimeBucketThree = overallData.kpi.other.prsReleased.data.LessTwoWeeks.ToString();
            TimeBucketFour = overallData.kpi.other.prsReleased.data.LessThreeWeeks.ToString();
            TimeBucketFive = overallData.kpi.other.prsReleased.data.LessFourWeeks.ToString();
            TimeBucketSix = overallData.kpi.other.prsReleased.data.LessFiveWeeks.ToString();
            TimeBucketSeven = overallData.kpi.other.prsReleased.data.LessSixWeeks.ToString();
            TimeBucketEight = overallData.kpi.other.prsReleased.data.LessSevenWeeks.ToString();
            TimeBucketNine = overallData.kpi.other.prsReleased.data.LessEightWeeks.ToString();
            TimeBucketTen = overallData.kpi.other.prsReleased.data.LessNinePlusWeeks.ToString();



            AnalysisOne = "- Count of PRs by 2nd level release date.";
            AnalysisTwo = "- Difference between the date the PR was released to the 2nd level and todays date.";


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


            TotalOrders = String.Format("{0:n0}", overallData.kpi.other.prsReleased.data.Total);
            TotalValue = String.Format("{0:n}", overallData.kpi.other.prsReleased.data.TotalValue);
            TimeBucketOne = String.Format("{0:n0}", overallData.kpi.other.prsReleased.data.Zero);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpi.other.prsReleased.data.LessOneWeek);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpi.other.prsReleased.data.LessTwoWeeks);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpi.other.prsReleased.data.LessThreeWeeks);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpi.other.prsReleased.data.LessFourWeeks);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpi.other.prsReleased.data.LessFiveWeeks);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpi.other.prsReleased.data.LessSixWeeks);
            TimeBucketEight = String.Format("{0:n0}", overallData.kpi.other.prsReleased.data.LessSevenWeeks);
            TimeBucketNine = String.Format("{0:n0}", overallData.kpi.other.prsReleased.data.LessEightWeeks);
            TimeBucketTen = String.Format("{0:n0}", overallData.kpi.other.prsReleased.data.LessNinePlusWeeks);

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

            TimeBucketOne = overallData.kpi.other.totalSpend.data.Zero.ToString();
            TimeBucketTwo = overallData.kpi.other.totalSpend.data.LessOneWeek.ToString();
            TimeBucketThree = overallData.kpi.other.totalSpend.data.LessTwoWeeks.ToString();
            TimeBucketFour = overallData.kpi.other.totalSpend.data.LessThreeWeeks.ToString();
            TimeBucketFive = overallData.kpi.other.totalSpend.data.LessFourWeeks.ToString();
            TimeBucketSix = overallData.kpi.other.totalSpend.data.LessFiveWeeks.ToString();
            TimeBucketSeven = overallData.kpi.other.totalSpend.data.LessSixWeeks.ToString();
            TimeBucketEight = overallData.kpi.other.totalSpend.data.LessSevenWeeks.ToString();
            TimeBucketNine = overallData.kpi.other.totalSpend.data.LessEightWeeks.ToString();
            TimeBucketTen = overallData.kpi.other.totalSpend.data.LessNinePlusWeeks.ToString();


            AnalysisOne = "- Total PO Value over time.";
            AnalysisTwo = "- Difference between the PO line creation date and todays date.";


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

            TotalOrders = String.Format("{0:n0}", overallData.kpi.other.totalSpend.data.Total);
            TotalValue = String.Format("{0:n}", overallData.kpi.other.totalSpend.data.TotalValue);
            TimeBucketOne = String.Format("{0:n0}", overallData.kpi.other.totalSpend.data.Zero);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpi.other.totalSpend.data.LessOneWeek);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpi.other.totalSpend.data.LessTwoWeeks);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpi.other.totalSpend.data.LessThreeWeeks);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpi.other.totalSpend.data.LessFourWeeks);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpi.other.totalSpend.data.LessFiveWeeks);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpi.other.totalSpend.data.LessSixWeeks);
            TimeBucketEight = String.Format("{0:n0}", overallData.kpi.other.totalSpend.data.LessSevenWeeks);
            TimeBucketNine = String.Format("{0:n0}", overallData.kpi.other.totalSpend.data.LessEightWeeks);
            TimeBucketTen = String.Format("{0:n0}", overallData.kpi.other.totalSpend.data.LessNinePlusWeeks);


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

            TimeBucketOne = overallData.kpi.other.prVsPOValue.data.Zero.ToString();
            TimeBucketTwo = overallData.kpi.other.prVsPOValue.data.LessOneWeek.ToString();
            TimeBucketThree = overallData.kpi.other.prVsPOValue.data.LessTwoWeeks.ToString();
            TimeBucketFour = overallData.kpi.other.prVsPOValue.data.LessThreeWeeks.ToString();
            TimeBucketFive = overallData.kpi.other.prVsPOValue.data.LessFourWeeks.ToString();
            TimeBucketSix = overallData.kpi.other.prVsPOValue.data.LessFiveWeeks.ToString();
            TimeBucketSeven = overallData.kpi.other.prVsPOValue.data.LessSixWeeks.ToString();
            TimeBucketEight = overallData.kpi.other.prVsPOValue.data.LessSevenWeeks.ToString();
            TimeBucketNine = overallData.kpi.other.prVsPOValue.data.LessEightWeeks.ToString();
            TimeBucketTen = overallData.kpi.other.prVsPOValue.data.LessNinePlusWeeks.ToString();


            AnalysisOne = "- PR vs PO Variance.";
            AnalysisTwo = "- Difference between the PO line creation date and todays date.";


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

            TotalOrders = String.Format("{0:n0}", overallData.kpi.other.prVsPOValue.data.Total);
            TotalValue = String.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.TotalValue);
            TimeBucketOne = String.Format("{0:n0}", overallData.kpi.other.prVsPOValue.data.Zero);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpi.other.prVsPOValue.data.LessOneWeek);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpi.other.prVsPOValue.data.LessTwoWeeks);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpi.other.prVsPOValue.data.LessThreeWeeks);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpi.other.prVsPOValue.data.LessFourWeeks);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpi.other.prVsPOValue.data.LessFiveWeeks);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpi.other.prVsPOValue.data.LessSixWeeks);
            TimeBucketEight = String.Format("{0:n0}", overallData.kpi.other.prVsPOValue.data.LessSevenWeeks);
            TimeBucketNine = String.Format("{0:n0}", overallData.kpi.other.prVsPOValue.data.LessEightWeeks);
            TimeBucketTen = String.Format("{0:n0}", overallData.kpi.other.prVsPOValue.data.LessNinePlusWeeks);


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

            TimeBucketOne = overallData.kpi.other.hotJobPrs.data.Zero.ToString();
            TimeBucketTwo = overallData.kpi.other.hotJobPrs.data.LessOneWeek.ToString();
            TimeBucketThree = overallData.kpi.other.hotJobPrs.data.LessTwoWeeks.ToString();
            TimeBucketFour = overallData.kpi.other.hotJobPrs.data.LessThreeWeeks.ToString();
            TimeBucketFive = overallData.kpi.other.hotJobPrs.data.LessFourWeeks.ToString();
            TimeBucketSix = overallData.kpi.other.hotJobPrs.data.LessFiveWeeks.ToString();
            TimeBucketSeven = overallData.kpi.other.hotJobPrs.data.LessSixWeeks.ToString();
            TimeBucketEight = overallData.kpi.other.hotJobPrs.data.LessSevenWeeks.ToString();
            TimeBucketNine = overallData.kpi.other.hotJobPrs.data.LessEightWeeks.ToString();
            TimeBucketTen = overallData.kpi.other.hotJobPrs.data.LessNinePlusWeeks.ToString();


            AnalysisOne = "- Will show all PRs over time.";
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

            TotalOrders = String.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.Total);
            TotalValue = String.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.TotalValue);
            TimeBucketOne = String.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.Zero);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.LessOneWeek);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.LessTwoWeeks);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.LessThreeWeeks);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.LessFourWeeks);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.LessFiveWeeks);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.LessSixWeeks);
            TimeBucketEight = String.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.LessSevenWeeks);
            TimeBucketNine = String.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.LessEightWeeks);
            TimeBucketTen = String.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.LessNinePlusWeeks);


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
                                    if (weeks < 0 && weeks >= (-1))
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (weeks < (-1) && weeks >= (-2))
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (weeks < (-2) && weeks >= (-3))
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (weeks < (-3) && weeks >= (-4))
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (weeks < (-4) && weeks >= (-5))
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (weeks < (-5) && weeks >= (-6))
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (weeks < (-6) && weeks >= (-7))
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (weeks < (-7) && weeks >= (-8))
                                    {
                                        prsCreated.ImportRow(dr);
                                    }
                                    continue;
                                case 10:
                                    if (weeks <= (-9))
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
                                    if (weeks < 0 && weeks >= (-1))
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (weeks < (-1) && weeks >= (-2))
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (weeks < (-2) && weeks >= (-3))
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (weeks < (-3) && weeks >= (-4))
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (weeks < (-4) && weeks >= (-5))
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (weeks < (-5) && weeks >= (-6))
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (weeks < (-6) && weeks >= (-7))
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (weeks < (-7) && weeks >= (-8))
                                    {
                                        prReleased.ImportRow(dr);
                                    }
                                    continue;
                                case 10:
                                    if (weeks <= (-9))
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
                                    if (weeks < 0 && weeks >= (-1))
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (weeks < (-1) && weeks >= (-2))
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (weeks < (-2) && weeks >= (-3))
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (weeks < (-3) && weeks >= (-4))
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (weeks < (-4) && weeks >= (-5))
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (weeks < (-5) && weeks >= (-6))
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (weeks < (-6) && weeks >= (-7))
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (weeks < (-7) && weeks >= (-8))
                                    {
                                        totalSpend.ImportRow(dr);
                                    }
                                    continue;
                                case 10:
                                    if (weeks <= (-9))
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
                                    prVsPOValue.ImportRow(dr);
                                    break;
                                case 1:
                                    if (weeks == 0)
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (weeks < 0 && weeks >= (-1))
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (weeks < (-1) && weeks >= (-2))
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (weeks < (-2) && weeks >= (-3))
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (weeks < (-3) && weeks >= (-4))
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (weeks < (-4) && weeks >= (-5))
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (weeks < (-5) && weeks >= (-6))
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (weeks < (-6) && weeks >= (-7))
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (weeks < (-7) && weeks >= (-8))
                                    {
                                        prVsPOValue.ImportRow(dr);
                                    }
                                    continue;
                                case 10:
                                    if (weeks <= (-9))
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
                                    if (weeks < 0 && weeks >= (-1))
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (weeks < (-1) && weeks >= (-2))
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (weeks < (-2) && weeks >= (-3))
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (weeks < (-3) && weeks >= (-4))
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (weeks < (-4) && weeks >= (-5))
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (weeks < (-5) && weeks >= (-6))
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (weeks < (-6) && weeks >= (-7))
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (weeks < (-7) && weeks >= (-8))
                                    {
                                        hotJobPRs.ImportRow(dr);
                                    }
                                    continue;
                                case 10:
                                    if (weeks <= (-9))
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
