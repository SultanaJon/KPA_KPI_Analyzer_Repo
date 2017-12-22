using KPA_KPI_Analyzer.DataLoading;
using KPA_KPI_Analyzer.DataLoading.KPI_Data.DataTableLoader;
using KPA_KPI_Analyzer.Overall_Data;
using KPA_KPI_Analyzer.Values;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPI_Controls
{
    public partial class KPIPurchTemplate : UserControl
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
        /// 
        /// </summary>
        public KPIPurchTemplate()
        {
            InitializeComponent();
        }





        /// <summary>
        /// Properties for the various labels on the control
        /// </summary>
        #region Template Properties
        public string TotalOrders { get { return lbl_totalOrders.Text; } set { lbl_totalOrders.Text = value; } }
        private string Title { get { return lbl_title.Text; } set { lbl_title.Text = value;  } }
        private string AnalysisOne { get { return lbl_analysisOne.Text; } set { lbl_analysisOne.Text = value;  } }
        private string AnalysisTwo { get { return lbl_analysisTwo.Text; } set { lbl_analysisTwo.Text = value;  } }
        private string Average { get { return lbl_average.Text; } set { lbl_average.Text = value + " Day(s)"; } }
        private string TimeBucketOne { get { return lbl_timebuckOne.Text; } set { lbl_timebuckOne.Text = value;  } }
        private string TimeBucketTwo { get { return lbl_timebuckTwo.Text; } set { lbl_timebuckTwo.Text = value;  } }
        private string TimeBucketThree { get { return lbl_timebuckThree.Text; } set { lbl_timebuckThree.Text = value;  } }
        private string TimeBucketFour { get { return lbl_timebuckFour.Text; } set { lbl_timebuckFour.Text = value;  } }
        private string TimeBucketFive { get { return lbl_timebuckFive.Text; } set { lbl_timebuckFive.Text = value;  } }
        private string TimeBucketSix { get { return lbl_timebuckSix.Text; } set { lbl_timebuckSix.Text = value;  } }
        private string TimeBucketSeven { get { return lbl_timebuckSeven.Text; } set { lbl_timebuckSeven.Text = value;  } }
        private string TimeBucketEight { get { return lbl_timebuckEight.Text; } set { lbl_timebuckEight.Text = value;  } }
        private string TimeBucketNine { get { return lbl_timebuckNine.Text; } set { lbl_timebuckNine.Text = value;  } }
        private string PercNoConf { get { return lbl_Percent.Text; } set { lbl_Percent.Text = value + "%"; } }
        private string PercNoConfTotal { get { return lbl_percUnconfTotal.Text; } set { lbl_percUnconfTotal.Text = value; } }
        private System.Drawing.Color DefaultButtonTextColor
        {
            set
            {
                btn_One.Textcolor = value;
                
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
            Globals.CurrCategory = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.Purch][(int)Values.Categories.KpiCategory.Purch.InitialConfirmationDatevsPRPlanDate];
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

            Title = Values.Categories.kpiCategories[(int)Values.Sections.KpiSection.Purch][(int)Values.Categories.KpiCategory.Purch.InitialConfirmationDatevsPRPlanDate];
            Globals.CurrCategory = Title;
            Globals.CurrSection = Values.Sections.kpiections[(int)Values.Sections.KpiSection.Purch];
            ChangeCategory();

            TimeBucketOne = overallData.kpi.purch.initConfVsPRPlanDate.data.Minus_TwentyTwo.ToString();
            TimeBucketTwo = overallData.kpi.purch.initConfVsPRPlanDate.data.Minus_Fifteen_TwentyOne.ToString();
            TimeBucketThree = overallData.kpi.purch.initConfVsPRPlanDate.data.Minus_Eight_Fourteen.ToString();
            TimeBucketFour = overallData.kpi.purch.initConfVsPRPlanDate.data.Minus_One_Seven.ToString();
            TimeBucketFive = overallData.kpi.purch.initConfVsPRPlanDate.data.Zero.ToString();
            TimeBucketSix = overallData.kpi.purch.initConfVsPRPlanDate.data.One_Seven.ToString();
            TimeBucketSeven = overallData.kpi.purch.initConfVsPRPlanDate.data.Eight_Fourteen.ToString();
            TimeBucketEight = overallData.kpi.purch.initConfVsPRPlanDate.data.Fifteen_TwentyOne.ToString();
            TimeBucketNine = overallData.kpi.purch.initConfVsPRPlanDate.data.TwentyTwo.ToString();

            AnalysisOne = "- Will show if the PR is on a PO.";
            AnalysisTwo = "- Difference between first confirmed date and PR planned date.";


            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);

            TotalOrders = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.Total);
            Average = string.Format("{0:n}", overallData.kpi.purch.initConfVsPRPlanDate.data.Average);
            PercNoConf = string.Format("{0:n}", overallData.kpi.purch.initConfVsPRPlanDate.data.PercentUnconf);
            PercNoConfTotal = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.PercentUnconfTotal);
            TimeBucketOne = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.Minus_TwentyTwo);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.Minus_Fifteen_TwentyOne);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.Minus_Eight_Fourteen);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.Minus_One_Seven);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.Zero);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.One_Seven);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.Eight_Fourteen);
            TimeBucketEight = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.Fifteen_TwentyOne);
            TimeBucketNine = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.TwentyTwo);


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

                    // Initial Confirmation vs PR Planned Date
                    dv.DataLoader += KpiDataTableLoader.Purch.LoadInitialConfVsPrPlanDateDataTable;
                    dv.ColumnTag = tag;
                    dv.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Purch Values Viewer Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
