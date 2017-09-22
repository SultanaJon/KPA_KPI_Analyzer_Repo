﻿using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using KPA_KPI_Analyzer.FilterFeeature;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPI_Controls
{
    public partial class KPIPurchPlanTemplate : UserControl
    {
        Overall overallData;
        DataTable poRelVsPRDelDateDt;
        DataTable pr2ndLvlRelOrigPlanDelDateDt;
        string[] strPoLineFirstRelDate;

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
        public KPIPurchPlanTemplate()
        {
            InitializeComponent();
        }





        /// <summary>
        /// Properties for the various labels on the control
        /// </summary>
        #region Template Properties
        public string TotalOrders { get { return lbl_totalOrders.Text; } set { lbl_totalOrders.Text = value; } }
        private string Title { get { return lbl_title.Text; } set { lbl_title.Text = value;  } }
        private string AnalysisOne { get { return lbl_analysisOne.Text; } set { lbl_analysisOne.Text = value; } }
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
        private string TimeBucketNine { get { return lbl_timebuckNine.Text; } set { lbl_timebuckNine.Text = value; } }
        private string TimeBucketTen { get { return lbl_timebuckTen.Text; } set { lbl_timebuckTen.Text = value; } }
        private string TimeBucketEleven { get { return lbl_timebuckEleven.Text; } set { lbl_timebuckEleven.Text = value; } }

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
            RenderOne();
            btn_One.selected = true;
            btn_One.Textcolor = System.Drawing.Color.Coral;
            DatavizLoaded = false;
            ActiveCategory = 0;
            datavizLoadTimer.Start();
            CurrCategory = "PO Release vs PR Delivery Date";
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
            dataviz.colorSet.Add(Color.FromArgb(4, 13, 18));
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

            Title = "PO Release vs PR Delivery Date";
            ChangeCategory(Title);
            CurrCategory = Title;
            
            TimeBucketOne = overallData.kpi.purchPlan.poRelVsPRDelDate.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpi.purchPlan.poRelVsPRDelDate.data.One_Three.ToString();
            TimeBucketThree = overallData.kpi.purchPlan.poRelVsPRDelDate.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpi.purchPlan.poRelVsPRDelDate.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpi.purchPlan.poRelVsPRDelDate.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpi.purchPlan.poRelVsPRDelDate.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpi.purchPlan.poRelVsPRDelDate.data.TwentyNine_ThirtyFive.ToString();
            TimeBucketEight = overallData.kpi.purchPlan.poRelVsPRDelDate.data.ThirtySix_FourtyTwo.ToString();
            TimeBucketNine = overallData.kpi.purchPlan.poRelVsPRDelDate.data.FourtyThree_FourtyNine.ToString();
            TimeBucketTen = overallData.kpi.purchPlan.poRelVsPRDelDate.data.Fifty_FiftySix.ToString();
            TimeBucketEleven = overallData.kpi.purchPlan.poRelVsPRDelDate.data.greaterThanEqualFiftySeven.ToString();


            AnalysisOne = "- Will show if PO line item has an initial release.";
            AnalysisTwo = "- Difference between the PR delivery date and PO line initial release.";


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
            dp.addLabely(lbl_xLabelEleven.Text, TimeBucketEleven);

            TotalOrders = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.Total);
            Average = string.Format("{0:n}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.Average);
            TimeBucketOne = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.LessThanZero);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.One_Three);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.Four_Seven);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.Eight_Fourteen);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.Fifteen_TwentyOne);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.TwentyNine_ThirtyFive);
            TimeBucketEight = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.ThirtySix_FourtyTwo);
            TimeBucketNine = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.FourtyThree_FourtyNine);
            TimeBucketTen = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.Fifty_FiftySix);
            TimeBucketEleven = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.greaterThanEqualFiftySeven);


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

            Title = "PR 2nd Level Release to Original Planned Delivery Date";
            ChangeCategory(Title);
            CurrCategory = Title;

            TimeBucketOne = overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.One_Three.ToString();
            TimeBucketThree = overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.TwentyNine_ThirtyFive.ToString();
            TimeBucketEight = overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.ThirtySix_FourtyTwo.ToString();
            TimeBucketNine = overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.FourtyThree_FourtyNine.ToString();
            TimeBucketTen = overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.Fifty_FiftySix.ToString();
            TimeBucketEleven = overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.greaterThanEqualFiftySeven.ToString();


            AnalysisOne = "- Will show if PR is fully released.";
            AnalysisTwo = "- Difference between PR delivery date and PR 2nd level release Date.";


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
            dp.addLabely(lbl_xLabelEleven.Text, TimeBucketEleven);

            TotalOrders = string.Format("{0:n0}", overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.Total);
            Average = string.Format("{0:n}", overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.Average);
            TimeBucketOne = string.Format("{0:n0}", overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.LessThanZero);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.One_Three);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.Four_Seven);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.Eight_Fourteen);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.Fifteen_TwentyOne);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.TwentyNine_ThirtyFive);
            TimeBucketEight = string.Format("{0:n0}", overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.ThirtySix_FourtyTwo);
            TimeBucketNine = string.Format("{0:n0}", overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.FourtyThree_FourtyNine);
            TimeBucketTen = string.Format("{0:n0}", overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.Fifty_FiftySix);
            TimeBucketEleven = string.Format("{0:n0}", overallData.kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.greaterThanEqualFiftySeven);


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
                        // PO Release vs PR Deliver Date
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        poRelVsPRDelDateDt = new DataTable();
                        poRelVsPRDelDateDt = DatabaseUtils.PRPO_DB_Utils.prsOnPOsDt.Clone();



                        foreach (DataRow dr in DatabaseUtils.PRPO_DB_Utils.prsOnPOsDt.Rows)
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



                            strPoLineFirstRelDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                            int poLineFirstRelYear = int.Parse(strPoLineFirstRelDate[2]);
                            int poLineFirstRelMonth = int.Parse(strPoLineFirstRelDate[0]);
                            int poLineFirstRelDay = int.Parse(strPoLineFirstRelDate[1]);

                            if (poLineFirstRelYear == 0 && poLineFirstRelMonth == 0 && poLineFirstRelDay == 0)
                            {
                                continue;
                            }
                            else
                            {
                                poLineFirstRelYear = int.Parse(strPoLineFirstRelDate[2]);
                                poLineFirstRelMonth = int.Parse(strPoLineFirstRelDate[0].TrimStart('0'));
                                poLineFirstRelDay = int.Parse(strPoLineFirstRelDate[1].TrimStart('0'));
                            }

                            DateTime poLineFirstRelDate = new DateTime(poLineFirstRelYear, poLineFirstRelMonth, poLineFirstRelDay);

                            string[] strPRDelDate = (dr["PR Delivery Date"].ToString()).Split('/');
                            int prDelYear = int.Parse(strPRDelDate[2]);
                            int prDelMonth = int.Parse(strPRDelDate[0].TrimStart('0'));
                            int prDelDay = int.Parse(strPRDelDate[1].TrimStart('0'));

                            DateTime prDelDate = new DateTime(prDelYear, prDelMonth, prDelDay);
                            double elapsedDays = (int)(prDelDate - poLineFirstRelDate).TotalDays;

                            switch (tag)
                            {
                                case 0:
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                    break;
                                case 1:
                                    if (elapsedDays <= 0)
                                    {
                                        poRelVsPRDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (elapsedDays >= 1 && elapsedDays <= 3)
                                    {
                                        poRelVsPRDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (elapsedDays >= 4 && elapsedDays <= 7)
                                    {
                                        poRelVsPRDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (elapsedDays >= 8 && elapsedDays <= 14)
                                    {
                                        poRelVsPRDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (elapsedDays >= 15 && elapsedDays <= 21)
                                    {
                                        poRelVsPRDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (elapsedDays >= 22 && elapsedDays <= 28)
                                    {
                                        poRelVsPRDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (elapsedDays >= 29 && elapsedDays <= 35)
                                    {
                                        poRelVsPRDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (elapsedDays >= 36 && elapsedDays <= 42)
                                    {
                                        poRelVsPRDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (elapsedDays >= 43 && elapsedDays <= 49)
                                    {
                                        poRelVsPRDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 10:
                                    if (elapsedDays >= 50 && elapsedDays <= 56)
                                    {
                                        poRelVsPRDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 11:
                                    if (elapsedDays >= 57)
                                    {
                                        poRelVsPRDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        using (DataViewer dv = new DataViewer() { Data = poRelVsPRDelDateDt, Country = CurrCountry, Performance = CurrPerformance, Section = CurrSection, Category = CurrCategory })
                        {
                            dv.LoadData();
                            dv.ShowDialog();
                        }
                        break;
                    case 1:
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //
                        // PR 2nd Level Release to Original Planned Delivery Date
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        pr2ndLvlRelOrigPlanDelDateDt = new DataTable();
                        pr2ndLvlRelOrigPlanDelDateDt = DatabaseUtils.PRPO_DB_Utils.pr2ndLvlRelDateDt.Clone();



                        foreach (DataRow dr in DatabaseUtils.PRPO_DB_Utils.pr2ndLvlRelDateDt.Rows)
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



                            string[] strPR2ndLvlRelDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                            int pr2ndLvlRelYear = int.Parse(strPR2ndLvlRelDate[2]);
                            int pr2ndLvlRelMonth = int.Parse(strPR2ndLvlRelDate[0]);
                            int pr2ndLvlRelDay = int.Parse(strPR2ndLvlRelDate[1]);

                            if (pr2ndLvlRelYear == 0 && pr2ndLvlRelMonth == 0 && pr2ndLvlRelDay == 0)
                            {
                                continue;
                            }
                            else
                            {
                                pr2ndLvlRelYear = int.Parse(strPR2ndLvlRelDate[2]);
                                pr2ndLvlRelMonth = int.Parse(strPR2ndLvlRelDate[0].TrimStart('0'));
                                pr2ndLvlRelDay = int.Parse(strPR2ndLvlRelDate[1].TrimStart('0'));
                            }
                            DateTime pr2ndLvlRelDate = new DateTime(pr2ndLvlRelYear, pr2ndLvlRelMonth, pr2ndLvlRelDay);

                            string[] strPRDelDate = (dr["PR Delivery Date"].ToString()).Split('/');
                            int prDelYear = int.Parse(strPRDelDate[2]);
                            int prDelMonth = int.Parse(strPRDelDate[0].TrimStart('0'));
                            int prDelDay = int.Parse(strPRDelDate[1].TrimStart('0'));

                            DateTime prDelDate = new DateTime(prDelYear, prDelMonth, prDelDay);
                            double elapsedDays = (int)(prDelDate - pr2ndLvlRelDate).TotalDays;

                            switch (tag)
                            {
                                case 0:
                                    pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                    break;
                                case 1:
                                    if (elapsedDays <= 0)
                                    {
                                        pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (elapsedDays >= 1 && elapsedDays <= 3)
                                    {
                                        pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (elapsedDays >= 4 && elapsedDays <= 7)
                                    {
                                        pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (elapsedDays >= 8 && elapsedDays <= 14)
                                    {
                                        pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (elapsedDays >= 15 && elapsedDays <= 21)
                                    {
                                        pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (elapsedDays >= 22 && elapsedDays <= 28)
                                    {
                                        pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (elapsedDays >= 29 && elapsedDays <= 35)
                                    {
                                        pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (elapsedDays >= 36 && elapsedDays <= 42)
                                    {
                                        pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (elapsedDays >= 43 && elapsedDays <= 49)
                                    {
                                        pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 10:
                                    if (elapsedDays >= 50 && elapsedDays <= 56)
                                    {
                                        pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                case 11:
                                    if (elapsedDays >= 57)
                                    {
                                        pr2ndLvlRelOrigPlanDelDateDt.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        using (DataViewer dv = new DataViewer() { Data = pr2ndLvlRelOrigPlanDelDateDt, Country = CurrCountry, Performance = CurrPerformance, Section = CurrSection, Category = CurrCategory })
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
                MessageBox.Show(ex.Message, "KPI -> Purch/Plan Data Viewer Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
