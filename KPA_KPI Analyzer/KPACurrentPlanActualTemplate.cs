using Excel_Access_Tools.Access;
using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPACurrentPlanActualTemplate : UserControl
    {
        Overall overallData = new Overall();
        DataTable dt;
        DataTable currPlanDateVsCurrConfDateDt;
        DataTable currPlanDateVsCurrConfDateDtHotJobs;
        OleDbDataAdapter da;
        OleDbCommand cmd;






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
        private string Average { get { return lbl_average.Text; } set { lbl_average.Text = value; } }
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

            Title = "Current planned date vs current confirmation date (Open POs)";
            TimeBucketOne = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanMinusThree.ToString();
            TimeBucketTwo = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusThree.ToString();
            TimeBucketThree = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusTwo.ToString();
            TimeBucketFour = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusOne.ToString();
            TimeBucketFive = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.ZeroWeeks.ToString();
            TimeBucketSix = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualOneWeek.ToString();
            TimeBucketSeven = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualTwoWeeks.ToString();
            TimeBucketEight = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualThreeWeeks.ToString();
            TimeBucketNine = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanThreeWeeks.ToString();

            TotalOrders = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.Total);
            Average = String.Format("{0:n}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.Average) + " Day(s)";

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


            TimeBucketOne = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanMinusThree);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusThree);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusTwo);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusOne);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.ZeroWeeks);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualOneWeek);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualTwoWeeks);
            TimeBucketEight = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualThreeWeeks);
            TimeBucketNine = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanThreeWeeks);


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
            Title = "Current planned date vs current confirmation date (Open POs) - Hot Job Only";

            TimeBucketOne = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanMinusThree.ToString();
            TimeBucketTwo = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusThree.ToString();
            TimeBucketThree = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusTwo.ToString();
            TimeBucketFour = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusOne.ToString();
            TimeBucketFive = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.ZeroWeeks.ToString();
            TimeBucketSix = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualOneWeek.ToString();
            TimeBucketSeven = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualTwoWeeks.ToString();
            TimeBucketEight = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualThreeWeeks.ToString();
            TimeBucketNine = overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanThreeWeeks.ToString();


            TotalOrders = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.Total);
            Average = String.Format("{0:n}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.Average) + " Week(s)";

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



            TimeBucketOne = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanMinusThree);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusThree);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusTwo);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusOne);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.ZeroWeeks);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualOneWeek);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualTwoWeeks);
            TimeBucketEight = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualThreeWeeks);
            TimeBucketNine = String.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanThreeWeeks);

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
                    case 0:

                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //
                        // Current Planned Date vs Current Confirmation Date (Open Pos)
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        dt = new DataTable();
                        currPlanDateVsCurrConfDateDt = new DataTable();

                        if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                            cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_CurrPlanActual_CurrPlanDateCurrConfDateOpenPO] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                        else
                            cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_CurrPlanActual_CurrPlanDateCurrConfDateOpenPO] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);

                        da = new OleDbDataAdapter(cmd);
                        da.Fill(dt);

                        currPlanDateVsCurrConfDateDt = dt.Clone();



                        foreach (DataRow dr in dt.Rows)
                        {
                            string[] strDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                            int year = int.Parse(strDate[2]);
                            int month = int.Parse(strDate[0].TrimStart('0'));
                            int day = int.Parse(strDate[1].TrimStart('0'));

                            DateTime confDate = new DateTime(year, month, day);


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
                            double elapsedDays = (int)(confDate - currPlanDate).TotalDays;

                            int weeks = 0;
                            if (elapsedDays < 0)
                                weeks = (int)Math.Floor(elapsedDays / 7);
                            else if (elapsedDays == 0)
                                weeks = 0;
                            else
                                weeks = (int)Math.Ceiling(elapsedDays / 7);

                            switch (tag)
                            {
                                case 0:
                                    currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                    break;
                                case 1:
                                    if (weeks < (-3))
                                    {
                                        currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (weeks >= (-3) && weeks < (-2))
                                    {
                                        currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (weeks >= (-2) && weeks < (-1))
                                    {
                                        currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (weeks >= (-1) && weeks < 0)
                                    {
                                        currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (weeks == 0)
                                    {
                                        currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (weeks > 0 && weeks <= 1)
                                    {
                                        currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (weeks > 1 && weeks <= 2)
                                    {
                                        currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (weeks > 2 && weeks <= 3)
                                    {
                                        currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (weeks > 3)
                                    {
                                        currPlanDateVsCurrConfDateDt.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        using (DataViewer dv = new DataViewer() { Data = currPlanDateVsCurrConfDateDt })
                        {
                            dv.LoadData();
                            dv.ShowDialog();
                        }
                        break;
                    case 1:

                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //
                        // Current Planned Date vs Current Confirmation Date (Open POs) - Hot Jobs Only
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        dt = new DataTable();
                        currPlanDateVsCurrConfDateDtHotJobs = new DataTable();

                        if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                            cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_CurrPlanActual_CurrPlanDateCurrConfDateOpenPOHotJobs] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                        else
                            cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_CurrPlanActual_CurrPlanDateCurrConfDateOpenPOHotJobs] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);

                        da = new OleDbDataAdapter(cmd);
                        da.Fill(dt);

                        currPlanDateVsCurrConfDateDtHotJobs = dt.Clone();



                        foreach (DataRow dr in dt.Rows)
                        {
                            string[] strDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                            int year = int.Parse(strDate[2]);
                            int month = int.Parse(strDate[0].TrimStart('0'));
                            int day = int.Parse(strDate[1].TrimStart('0'));

                            DateTime confDate = new DateTime(year, month, day);


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
                            double elapsedDays = (int)(confDate - currPlanDate).TotalDays;


                            int weeks = 0;
                            if (elapsedDays < 0)
                                weeks = (int)Math.Floor(elapsedDays / 7);
                            else if (elapsedDays == 0)
                                weeks = 0;
                            else
                                weeks = (int)Math.Ceiling(elapsedDays / 7);

                            switch (tag)
                            {
                                case 0:
                                    currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                    break;
                                case 1:
                                    if (weeks < (-3))
                                    {
                                        currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (weeks >= (-3) && weeks < (-2))
                                    {
                                        currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (weeks >= (-2) && weeks < (-1))
                                    {
                                        currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (weeks >= (-1) && weeks < 0)
                                    {
                                        currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (weeks == 0)
                                    {
                                        currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (weeks > 0 && weeks <= 1)
                                    {
                                        currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (weeks > 1 && weeks <= 2)
                                    {
                                        currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (weeks > 2 && weeks <= 3)
                                    {
                                        currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (weeks > 3)
                                    {
                                        currPlanDateVsCurrConfDateDtHotJobs.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        using (DataViewer dv = new DataViewer() { Data = currPlanDateVsCurrConfDateDtHotJobs })
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
                MessageBox.Show(ex.Message, "KPA -> Current Plan vs Actual Data Viewer Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
