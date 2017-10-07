using KPA_KPI_Analyzer.DataLoading.KPA_Data.DataTableLoader;
using KPA_KPI_Analyzer.KPA_KPI_Overall;
using KPA_KPI_Analyzer.Values;
using System;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPA_Controls
{
    public partial class KPACurrentPlanActualTemplate : UserControl
    {
        Overall overallData = new Overall();

        public delegate void UpdateCategoryHandler();
        public static event UpdateCategoryHandler ChangeCategory;

        /// <summary>
        /// Boolean determining whether or not the dataviz graph was loaded.
        /// </summary>
        bool DatavizLoaded { get; set; }



        /// <summary>
        ///  The tag (assigned through the properties of the control) number of the active category.
        /// </summary>
        int ActiveCategory { get; set; }




        /// <summary>
        /// Default Constructor
        /// </summary>
        public KPACurrentPlanActualTemplate()
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
        private string TimeBucketNine{ get { return lbl_timebuckNine.Text; } set { lbl_timebuckNine.Text = value;  } }
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
        public void LoadPanel(Overall data)
        {
            overallData = data;
            SetGraphColor();
            DefaultButtonTextColor = System.Drawing.Color.DarkGray;
            RenderCurrPlanCurrConfDateOpenPO();
            btn_One.selected = true;
            btn_One.Textcolor = System.Drawing.Color.Coral;
            DatavizLoaded = false;
            datavizLoadTimer.Start();
            ActiveCategory = 0;
            Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.CurrPlanActual][(int)Globals.KPA_Categories.CurrPlanVsActual.CurrPlanDateCurrConfDateOpenPO];
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
        /// Set the color of the graph that will be displayed on the template.
        /// </summary>
        private void SetGraphColor()
        {
            dataviz.colorSet.Add(System.Drawing.Color.FromArgb(123, 204, 243));
            dataviz.colorSet.Add(System.Drawing.Color.FromArgb(96, 189, 227));
            dataviz.colorSet.Add(System.Drawing.Color.FromArgb(79, 179, 208));
            dataviz.colorSet.Add(System.Drawing.Color.FromArgb(62, 168, 186));
            dataviz.colorSet.Add(System.Drawing.Color.FromArgb(50, 150, 160));
            dataviz.colorSet.Add(System.Drawing.Color.FromArgb(41, 132, 137));
            dataviz.colorSet.Add(System.Drawing.Color.FromArgb(31, 109, 109));
            dataviz.colorSet.Add(System.Drawing.Color.FromArgb(21, 86, 84));
            dataviz.colorSet.Add(System.Drawing.Color.FromArgb(12, 58, 56));
        }






        /// <summary>
        /// Triggered when the category buttons of the template are clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategoryButton_Click(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuFlatButton btn = (Bunifu.Framework.UI.BunifuFlatButton)sender;


            btn_One.selected = false;
            btn_Two.selected = false;
            btn.selected = true;
            DefaultButtonTextColor = System.Drawing.Color.DarkGray;
            btn.Textcolor = System.Drawing.Color.Coral;


            int tag = int.Parse(btn.Tag.ToString());
            ActiveCategory = tag;


            switch (tag)
            {
                case 0:
                    RenderCurrPlanCurrConfDateOpenPO();
                    break;
                case 1:
                    RenderCurrPlanCurrConfDateHotJobs();
                    break;
                default:
                    break;
            }
        }






        /// <summary>
        /// Renders the specific KPA data on the template
        /// </summary>
        private void RenderCurrPlanCurrConfDateOpenPO()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);

            Title = Globals.kpaCategories[(int)Globals.KPA_Sections.CurrPlanActual][(int)Globals.KPA_Categories.CurrPlanVsActual.CurrPlanDateCurrConfDateOpenPO];
            Globals.CurrCategory = Title;
            ChangeCategory();

            TimeBucketOne = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanMinusThree.ToString();
            TimeBucketTwo = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusThree.ToString();
            TimeBucketThree = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusTwo.ToString();
            TimeBucketFour = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusOne.ToString();
            TimeBucketFive = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.ZeroWeeks.ToString();
            TimeBucketSix = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualOneWeek.ToString();
            TimeBucketSeven = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualTwoWeeks.ToString();
            TimeBucketEight = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualThreeWeeks.ToString();
            TimeBucketNine = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanThreeWeeks.ToString();

            TotalOrders = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.Total);
            Average = string.Format("{0:n}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.Average);

            AnalysisOne = "- Will only show if the PO line has a confirmed date AND is not received complete.";
            AnalysisTwo = "- Difference between the confirmation date and the current planned date.";


            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);


            TimeBucketOne = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanMinusThree);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusThree);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusTwo);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusOne);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.ZeroWeeks);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualOneWeek);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualTwoWeeks);
            TimeBucketEight = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualThreeWeeks);
            TimeBucketNine = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanThreeWeeks);


            canvas.addData(dp);
            dataviz.Render(canvas);
        }






        /// <summary>
        /// Renders the specific KPA data on the template
        /// </summary>
        private void RenderCurrPlanCurrConfDateHotJobs()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);
            Title = Globals.kpaCategories[(int)Globals.KPA_Sections.CurrPlanActual][(int)Globals.KPA_Categories.CurrPlanVsActual.CurrPlanDateCurrConfDateOpenPOHotJobs];
            Globals.CurrCategory = Title;
            ChangeCategory();

            TimeBucketOne = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanMinusThree.ToString();
            TimeBucketTwo = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusThree.ToString();
            TimeBucketThree = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusTwo.ToString();
            TimeBucketFour = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusOne.ToString();
            TimeBucketFive = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.ZeroWeeks.ToString();
            TimeBucketSix = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualOneWeek.ToString();
            TimeBucketSeven = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualTwoWeeks.ToString();
            TimeBucketEight = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualThreeWeeks.ToString();
            TimeBucketNine = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanThreeWeeks.ToString();


            TotalOrders = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.Total);
            Average = string.Format("{0:n}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.Average);

            AnalysisOne = "- Will only show if the PO line has a confirmed date, the PO line is not received complete and the purchase group is UHJ.";
            AnalysisTwo = "- Difference between confirmation date and the current planned date.";


            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);



            TimeBucketOne = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanMinusThree);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusThree);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusTwo);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusOne);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.ZeroWeeks);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualOneWeek);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualTwoWeeks);
            TimeBucketEight = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualThreeWeeks);
            TimeBucketNine = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanThreeWeeks);

            canvas.addData(dp);
            dataviz.Render(canvas);
        }






        /// <summary>
        /// Triggered after the template is loaded into view. Once the timer ticks once the timer will
        /// end and the graph will be populated.
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
                    case 0: // Current Plan Date vs Current Confirmation Date (Open POs)
                        KpaDataTableLoader.CurrentPlanVsActual.LoadCurrentPlanVsCurrentConfDateDataTable(tag);
                        break;
                    case 1: // Current Planned Date vs Current Confirmation Date (Open POs) - Hot Jobs Only
                        KpaDataTableLoader.CurrentPlanVsActual.LoadCurrPlandDateVsCurrConfDateOpenPOs_HotJobsDataTable(tag);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Current Plan vs Actual Data Viewer Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
