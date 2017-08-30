using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPIPlanTemplate : UserControl
    {
        Overall overallData;
        DataTable prPlanDateVsCurrPlanDt;


        public delegate void UpdateCategoryHandler(string categoryName);
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
        public KPIPlanTemplate()
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
        private string Average { get { return lbl_average.Text; } set { lbl_average.Text = value; } }
        private string TimeBucketOne { get { return lbl_timebuckOne.Text; } set { lbl_timebuckOne.Text = value;  } }
        private string TimeBucketTwo { get { return lbl_timebuckTwo.Text; } set { lbl_timebuckTwo.Text = value;  } }
        private string TimeBucketThree { get { return lbl_timebuckThree.Text; } set { lbl_timebuckThree.Text = value;  } }
        private string TimeBucketFour { get { return lbl_timebuckFour.Text; } set { lbl_timebuckFour.Text = value;  } }
        private string TimeBucketFive { get { return lbl_timebuckFive.Text; } set { lbl_timebuckFive.Text = value;  } }
        private string TimeBucketSix { get { return lbl_timebuckSix.Text; } set { lbl_timebuckSix.Text = value;  } }
        private string TimeBucketSeven { get { return lbl_timebuckSeven.Text; } set { lbl_timebuckSeven.Text = value;  } }
        private string TimeBucketEight { get { return lbl_timebuckEight.Text; } set { lbl_timebuckEight.Text = value;  } }
        private string TimeBucketNine { get { return lbl_timebuckNine.Text; } set { lbl_timebuckNine.Text = value;  } }
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

            Title = "PR Planned Date vs Current Planned";
            ChangeCategory(Title);
            Average = overallData.kpi.plan.prPlanDateVsCurrPlan.data.Average.ToString();
            TotalOrders = overallData.kpi.plan.prPlanDateVsCurrPlan.data.Total.ToString();
            TimeBucketOne = overallData.kpi.plan.prPlanDateVsCurrPlan.data.Minus_TwentyTwo.ToString();
            TimeBucketTwo = overallData.kpi.plan.prPlanDateVsCurrPlan.data.Minus_Fifteen_TwentyOne.ToString();
            TimeBucketThree = overallData.kpi.plan.prPlanDateVsCurrPlan.data.Minus_Eight_Fourteen.ToString();
            TimeBucketFour = overallData.kpi.plan.prPlanDateVsCurrPlan.data.Minus_One_Seven.ToString();
            TimeBucketFive = overallData.kpi.plan.prPlanDateVsCurrPlan.data.Zero.ToString();
            TimeBucketSix = overallData.kpi.plan.prPlanDateVsCurrPlan.data.One_Seven.ToString();
            TimeBucketSeven = overallData.kpi.plan.prPlanDateVsCurrPlan.data.Eight_Fourteen.ToString();
            TimeBucketEight = overallData.kpi.plan.prPlanDateVsCurrPlan.data.Fifteen_TwentyOne.ToString();
            TimeBucketNine = overallData.kpi.plan.prPlanDateVsCurrPlan.data.TwentyTwo.ToString();



            AnalysisOne = "- Will show for PRs that are on a PO.";
            AnalysisTwo = "- Difference between current planned date and PR planned date.";


            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);

            Average = String.Format("{0:n}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Average);
            TotalOrders = String.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Total);
            TimeBucketOne = String.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Minus_TwentyTwo);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Minus_Fifteen_TwentyOne);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Minus_Eight_Fourteen);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Minus_One_Seven);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Zero);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.One_Seven);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Eight_Fourteen);
            TimeBucketEight = String.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Fifteen_TwentyOne);
            TimeBucketNine = String.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.TwentyTwo);


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

            Title = "(Orig Plan Date - 2nd Lvl Rel Date vs Coded Lead-time";
            ChangeCategory(Title);
            Average = overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Average.ToString();
            TotalOrders = overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Total.ToString();
            TimeBucketOne = overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_TwentyTwo.ToString();
            TimeBucketTwo = overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Fifteen_TwentyOne.ToString();
            TimeBucketThree = overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Eight_Fourteen.ToString();
            TimeBucketFour = overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_One_Seven.ToString();
            TimeBucketFive = overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Zero.ToString();
            TimeBucketSix = overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.One_Seven.ToString();
            TimeBucketSeven = overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Eight_Fourteen.ToString();
            TimeBucketEight = overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Fifteen_TwentyOne.ToString();
            TimeBucketNine = overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.TwentyTwo.ToString();


            AnalysisOne = "- Will show if PR has 2nd level release.";
            AnalysisTwo = "- (PR planned date - 2nd level release date) - commodity coded leadtime.";


            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);

            Average = String.Format("{0:n}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Average);
            TotalOrders = String.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Total);
            TimeBucketOne = String.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_TwentyTwo);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Fifteen_TwentyOne);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Eight_Fourteen);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_One_Seven);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Zero);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.One_Seven);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Eight_Fourteen);
            TimeBucketEight = String.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Fifteen_TwentyOne);
            TimeBucketNine = String.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.TwentyTwo);


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

            Title = "(Curr Plan Date - 2nd Lvl Rel Date) vs Coded Lead-time";
            ChangeCategory(Title);
            Average = overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Average.ToString();
            TotalOrders = overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Total.ToString();
            TimeBucketOne = overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_TwentyTwo.ToString();
            TimeBucketTwo = overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Fifteen_TwentyOne.ToString();
            TimeBucketThree = overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Eight_Fourteen.ToString();
            TimeBucketFour = overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_One_Seven.ToString();
            TimeBucketFive = overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Zero.ToString();
            TimeBucketSix = overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.One_Seven.ToString();
            TimeBucketSeven = overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Eight_Fourteen.ToString();
            TimeBucketEight = overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Fifteen_TwentyOne.ToString();
            TimeBucketNine = overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.TwentyTwo.ToString();



            AnalysisOne = "- Will show if PR has 2nd level release.";
            AnalysisTwo = "- (current planned date - 2nd level release date) - commodity coded leadtime.";


            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);

            Average = String.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Average);
            TotalOrders = String.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Total);
            TimeBucketOne = String.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_TwentyTwo);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Fifteen_TwentyOne);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Eight_Fourteen);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_One_Seven);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Zero);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.One_Seven);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Eight_Fourteen);
            TimeBucketEight = String.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Fifteen_TwentyOne);
            TimeBucketNine = String.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.TwentyTwo);


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
                        // PR Planned Date vs Current Planned
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        prPlanDateVsCurrPlanDt = new DataTable();
                        prPlanDateVsCurrPlanDt = Overall.prsOnPOsDt.Clone();



                        foreach (DataRow dr in Overall.prsOnPOsDt.Rows)
                        {
                            string[] strPrPlanDate = (dr["PR Delivery Date"].ToString()).Split('/');
                            int delConfYear = int.Parse(strPrPlanDate[2]);
                            int delConfMonth = int.Parse(strPrPlanDate[0].TrimStart('0'));
                            int delConfDay = int.Parse(strPrPlanDate[1].TrimStart('0'));

                            DateTime prPlanDate = new DateTime(delConfYear, delConfMonth, delConfDay);

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

                            DateTime reqDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                            double elapsedDays = (reqDate - prPlanDate).TotalDays;

                            if (elapsedDays < 0)
                                elapsedDays = Math.Floor(elapsedDays);
                            else if (elapsedDays == 0)
                                ;
                            else // elapsed days > 0
                                elapsedDays = Math.Ceiling(elapsedDays);

                            elapsedDays = (int)elapsedDays;

                            switch (tag)
                            {
                                case 0:
                                    prPlanDateVsCurrPlanDt.ImportRow(dr);
                                    break;
                                case 1:
                                    if (elapsedDays <= (-22))
                                    {
                                        prPlanDateVsCurrPlanDt.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (elapsedDays > (-22) && elapsedDays <= (-15))
                                    {
                                        prPlanDateVsCurrPlanDt.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (elapsedDays > (-15) && elapsedDays <= (-8))
                                    {
                                        prPlanDateVsCurrPlanDt.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (elapsedDays > (-8) && elapsedDays <= (-1))
                                    {
                                        prPlanDateVsCurrPlanDt.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (elapsedDays == 0)
                                    {
                                        prPlanDateVsCurrPlanDt.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (elapsedDays >= 1 && elapsedDays <= 7)
                                    {
                                        prPlanDateVsCurrPlanDt.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (elapsedDays >= 8 && elapsedDays <= 14)
                                    {
                                        prPlanDateVsCurrPlanDt.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (elapsedDays >= 15 && elapsedDays <= 21)
                                    {
                                        prPlanDateVsCurrPlanDt.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (elapsedDays >= 22)
                                    {
                                        prPlanDateVsCurrPlanDt.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        using (DataViewer dv = new DataViewer() { Data = prPlanDateVsCurrPlanDt })
                        {
                            dv.LoadData();
                            dv.ShowDialog();
                        }
                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Plan Data Viewer Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}