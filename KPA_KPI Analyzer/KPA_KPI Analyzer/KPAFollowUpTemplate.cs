﻿using Excel_Access_Tools.Access;
using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPAFollowUpTemplate : UserControl
    {
        Overall overallData = new Overall();
        DataTable confVsPlanDateDt;
        DataTable poFirsconfDateUpDelDt;
        //DataTable LateConfDateDt;
        DataTable dt;
        OleDbCommand cmd;
        OleDbDataAdapter da;





        /// <summary>
        /// Boolean value indicating whether the data was loaded into the dataviz control
        /// </summary>
        bool DatavizLoaded { get; set; }





        /// <summary>
        /// The tag (property for the control) indicating what category is loaded
        /// </summary>
        int ActiveCategory { get; set; }




        /// <summary>
        /// Default constructor
        /// </summary>
        public KPAFollowUpTemplate()
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
        private string Average { get { return lbl_average.Text; } set { lbl_average.Text = value + " Day(s)"; } }
        private string TimeBucketOne { get { return lbl_timebuckOne.Text; } set { lbl_timebuckOne.Text = value;  } }
        private string TimeBucketTwo { get { return lbl_timebuckTwo.Text; } set { lbl_timebuckTwo.Text = value;  } }
        private string TimeBucketThree { get { return lbl_timebuckThree.Text; } set { lbl_timebuckThree.Text = value;  } }
        private string TimeBucketFour { get { return lbl_timebuckFour.Text; } set { lbl_timebuckFour.Text = value;  } }
        private string TimeBucketFive { get { return lbl_timebuckFive.Text; } set { lbl_timebuckFive.Text = value;  } }
        private string TimeBucketSix { get { return lbl_timebuckSix.Text; } set { lbl_timebuckSix.Text = value;  } }
        private string TimeBucketSeven { get { return lbl_timebuckSeven.Text; } set { lbl_timebuckSeven.Text = value;  } }
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
            RenderConfirmedVsPlanDate();
            btn_One.selected = true;
            btn_One.Textcolor = System.Drawing.Color.Coral;
            ActiveCategory = 0;
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
                    RenderConfirmedVsPlanDate();
                    break;
                case 1:
                    RenderConfUpcomingDel();
                    break;
                case 2:
                    RenderLateToConfDate();
                    break;
                default:
                    break;
            }
        }






        /// <summary>
        /// Renders the specific KPA category into the loaded template
        /// </summary>
        private void RenderConfirmedVsPlanDate()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);

            Title = "Confirmed vs Plan Date";
            TimeBucketOne = overallData.kpa.followUp.confDateVsPlanDate.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpa.followUp.confDateVsPlanDate.data.One_Three.ToString();
            TimeBucketThree = overallData.kpa.followUp.confDateVsPlanDate.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpa.followUp.confDateVsPlanDate.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpa.followUp.confDateVsPlanDate.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpa.followUp.confDateVsPlanDate.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpa.followUp.confDateVsPlanDate.data.TwentyNinePlus.ToString();



            TotalOrders = String.Format("{0:n0}", overallData.kpa.followUp.confDateVsPlanDate.data.Total);
            Average = String.Format("{0:n}", overallData.kpa.followUp.confDateVsPlanDate.data.Average);


            AnalysisOne = "- Will only show in this field if PR is on a PO, the line item does have a confirmation date and the line is not received complete.";
            AnalysisTwo = "- Difference between current confirmed date and current plan date.";


            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);


            TimeBucketOne = String.Format("{0:n0}", overallData.kpa.followUp.confDateVsPlanDate.data.LessThanZero);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpa.followUp.confDateVsPlanDate.data.One_Three);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpa.followUp.confDateVsPlanDate.data.Four_Seven);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpa.followUp.confDateVsPlanDate.data.Eight_Fourteen);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpa.followUp.confDateVsPlanDate.data.Fifteen_TwentyOne);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpa.followUp.confDateVsPlanDate.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpa.followUp.confDateVsPlanDate.data.TwentyNinePlus);


            canvas.addData(dp);
            dataviz.Render(canvas);
        }






        /// <summary>
        /// Renders the specific KPA category into the loaded template
        /// </summary>
        private void RenderConfUpcomingDel()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);
            Title = "Confirmed Date for Upcoming Deliveres";

            TimeBucketOne = overallData.kpa.followUp.ConfDateForUpcomingDel.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpa.followUp.ConfDateForUpcomingDel.data.One_Three.ToString();
            TimeBucketThree = overallData.kpa.followUp.ConfDateForUpcomingDel.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpa.followUp.ConfDateForUpcomingDel.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpa.followUp.ConfDateForUpcomingDel.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpa.followUp.ConfDateForUpcomingDel.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpa.followUp.ConfDateForUpcomingDel.data.TwentyNinePlus.ToString();

            TotalOrders = String.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.Total);
            Average = String.Format("{0:n}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.Average);


            AnalysisOne = "- Will only show for PO line items with a confirmation date and have been received complete.";
            AnalysisTwo = "- Difference between the confirmation date and todays date.";

            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);


            TimeBucketOne = String.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.LessThanZero);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.One_Three);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.Four_Seven);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.Eight_Fourteen);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.Fifteen_TwentyOne);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.TwentyNinePlus);


            canvas.addData(dp);
            dataviz.Render(canvas);
        }





        /// <summary>
        /// Renders the specific KPA category into the loaded template
        /// </summary>
        private void RenderLateToConfDate()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);
            Title = "Late to Confirmed Date";

            TimeBucketOne = overallData.kpa.followUp.ConfDateForUpcomingDel.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpa.followUp.ConfDateForUpcomingDel.data.One_Three.ToString();
            TimeBucketThree = overallData.kpa.followUp.ConfDateForUpcomingDel.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpa.followUp.ConfDateForUpcomingDel.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpa.followUp.ConfDateForUpcomingDel.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpa.followUp.ConfDateForUpcomingDel.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpa.followUp.ConfDateForUpcomingDel.data.TwentyNinePlus.ToString();


            TotalOrders = String.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.Total);
            Average = String.Format("{0:n}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.Average);


            AnalysisOne = "- Number of lines that need to be cancelled.";
            AnalysisTwo = "- Difference of today’s date and cancellation first time on report.";

            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);

            TimeBucketOne = String.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.LessThanZero);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.One_Three);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.Four_Seven);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.Eight_Fourteen);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.Fifteen_TwentyOne);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.TwentyNinePlus);

            canvas.addData(dp);
            dataviz.Render(canvas);
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
                        // Confirmed Vs Plan Date
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        dt = new DataTable();
                        confVsPlanDateDt = new DataTable();

                        if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                            cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_FollowUp_ConfPlanDate] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                        else
                            cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_FollowUp_ConfPlanDate] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);

                        da = new OleDbDataAdapter(cmd);
                        da.Fill(dt);

                        confVsPlanDateDt = dt.Clone();



                        foreach (DataRow dr in dt.Rows)
                        {
                            string[] strCurrConfDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                            int delConfYear = int.Parse(strCurrConfDate[2]);
                            int delConfMonth = int.Parse(strCurrConfDate[0].TrimStart('0'));
                            int delConfDay = int.Parse(strCurrConfDate[1].TrimStart('0'));

                            DateTime delConfDate = new DateTime(delConfYear, delConfMonth, delConfDay);

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
                            double elapsedDays = (int)(delConfDate - currPlanDate).TotalDays;

                            switch (tag)
                            {
                                case 0:
                                    confVsPlanDateDt.ImportRow(dr);
                                    break;
                                case 1:
                                    if (elapsedDays <= 0)
                                    {
                                        confVsPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (elapsedDays >= 1 && elapsedDays <= 3)
                                    {
                                        confVsPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (elapsedDays >= 4 && elapsedDays <= 7)
                                    {
                                        confVsPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (elapsedDays >= 8 && elapsedDays <= 14)
                                    {
                                        confVsPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (elapsedDays >= 15 && elapsedDays <= 21)
                                    {
                                        confVsPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (elapsedDays >= 22 && elapsedDays <= 28)
                                    {
                                        confVsPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (elapsedDays >= 29)
                                    {
                                        confVsPlanDateDt.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        using (DataViewer dv = new DataViewer() { Data = confVsPlanDateDt })
                        {
                            dv.LoadData();
                            dv.ShowDialog();
                        }
                        break;
                    case 1:
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //
                        // Confirmed Date for Upcoming Deliveries
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        dt = new DataTable();
                        poFirsconfDateUpDelDt = new DataTable();
                        if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                            cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_FollowUp_ConfDateUpcomingDel] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                        else
                            cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_FollowUp_ConfDateUpcomingDel] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);

                        da = new OleDbDataAdapter(cmd);
                        da.Fill(dt);


                        poFirsconfDateUpDelDt = dt.Clone();

                        foreach (DataRow dr in dt.Rows)
                        {
                            string[] strDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                            int year = int.Parse(strDate[2]);
                            int month = int.Parse(strDate[0].TrimStart('0'));
                            int day = int.Parse(strDate[1].TrimStart('0'));

                            DateTime date = new DateTime(year, month, day);
                            double elapsedDays = (int)(date - DateTime.Now).TotalDays;

                            switch (tag)
                            {
                                case 0:
                                    poFirsconfDateUpDelDt.ImportRow(dr);
                                    break;
                                case 1:
                                    if (elapsedDays <= 0)
                                    {
                                        poFirsconfDateUpDelDt.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (elapsedDays >= 1 && elapsedDays <= 3)
                                    {
                                        poFirsconfDateUpDelDt.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (elapsedDays >= 4 && elapsedDays <= 7)
                                    {
                                        poFirsconfDateUpDelDt.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (elapsedDays >= 8 && elapsedDays <= 14)
                                    {
                                        poFirsconfDateUpDelDt.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (elapsedDays >= 15 && elapsedDays <= 21)
                                    {
                                        poFirsconfDateUpDelDt.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (elapsedDays >= 22 && elapsedDays <= 28)
                                    {
                                        poFirsconfDateUpDelDt.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (elapsedDays >= 29)
                                    {
                                        poFirsconfDateUpDelDt.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        using (DataViewer dv = new DataViewer() { Data = poFirsconfDateUpDelDt })
                        {
                            dv.LoadData();
                            dv.ShowDialog();
                        }
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Follow Up Data Viewer Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
