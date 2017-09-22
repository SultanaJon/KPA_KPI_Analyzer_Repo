using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.DatabaseUtils;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPI_Controls
{
    public partial class KPIPurchSubTemplate : UserControl
    {
        Overall overallData;
        DataTable prRelVsPORel;
        DataTable poCreateVsConfEntry;
        DataTable unconfirmed;


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
        public KPIPurchSubTemplate()
        {
            InitializeComponent();
        }





        /// <summary>
        /// Properties for the various labels on the control
        /// </summary
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
        private string TimeBucketTen { get { return lbl_timebuckTen.Text; } set { lbl_timebuckTen.Text = value;  } }
        private string TimeBucketEleven { get { return lbl_timebuckEleven.Text; } set { lbl_timebuckEleven.Text = value; } }
        private string PercNoConf { get { return lbl_Percent.Text; } set { lbl_Percent.Text = value + "%"; } }
        private string PercNoConfTotal { get { return lbl_percUnconfTotal.Text; } set { lbl_percUnconfTotal.Text = value;} }
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
            CurrCategory = "PR Release vs PO Release";
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
                    pnl_PercentagePanel.Visible = false;
                    btn_unconfIncludedStatusButton.Visible = false;
                    RenderOne();
                    break;
                case 1:
                    pnl_PercentagePanel.Visible = true;
                    btn_unconfIncludedStatusButton.Visible = true;
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

            Title = "PR Release vs PO Release";
            ChangeCategory(Title);
            CurrCategory = Title;

            TimeBucketOne = overallData.kpi.purchSub.prRelVsPORel.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpi.purchSub.prRelVsPORel.data.One_Three.ToString();
            TimeBucketThree = overallData.kpi.purchSub.prRelVsPORel.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpi.purchSub.prRelVsPORel.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpi.purchSub.prRelVsPORel.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpi.purchSub.prRelVsPORel.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpi.purchSub.prRelVsPORel.data.TwentyNine_ThirtyFive.ToString();
            TimeBucketEight = overallData.kpi.purchSub.prRelVsPORel.data.ThirtySix_FourtyTwo.ToString();
            TimeBucketNine = overallData.kpi.purchSub.prRelVsPORel.data.FourtyThree_FourtyNine.ToString();
            TimeBucketTen = overallData.kpi.purchSub.prRelVsPORel.data.Fifty_FiftySix.ToString();
            TimeBucketEleven = overallData.kpi.purchSub.prRelVsPORel.data.greaterThanEqualFiftySeven.ToString();

            AnalysisOne = "- Will show if PR is on a PO that has previously been released.";
            AnalysisTwo = "- Difference between PO line initial release date and PR second level release.";


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


            TotalOrders = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.Total);
            Average = string.Format("{0:n}", overallData.kpi.purchSub.prRelVsPORel.data.Average);
            TimeBucketOne = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.LessThanZero);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.One_Three);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.Four_Seven);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.Eight_Fourteen);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.Fifteen_TwentyOne);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.TwentyNine_ThirtyFive);
            TimeBucketEight = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.ThirtySix_FourtyTwo);
            TimeBucketNine = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.FourtyThree_FourtyNine);
            TimeBucketTen = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.Fifty_FiftySix);
            TimeBucketEleven = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.greaterThanEqualFiftySeven);


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

            Title = "PO Creation vs Confirmation Entry";
            ChangeCategory(Title);
            CurrCategory = Title;

            TimeBucketOne = overallData.kpi.purchSub.poCreateVsConfEntry.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpi.purchSub.poCreateVsConfEntry.data.One_Three.ToString();
            TimeBucketThree = overallData.kpi.purchSub.poCreateVsConfEntry.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpi.purchSub.poCreateVsConfEntry.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpi.purchSub.poCreateVsConfEntry.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpi.purchSub.poCreateVsConfEntry.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpi.purchSub.poCreateVsConfEntry.data.TwentyNine_ThirtyFive.ToString();
            TimeBucketEight = overallData.kpi.purchSub.poCreateVsConfEntry.data.ThirtySix_FourtyTwo.ToString();
            TimeBucketNine = overallData.kpi.purchSub.poCreateVsConfEntry.data.FourtyThree_FourtyNine.ToString();
            TimeBucketTen = overallData.kpi.purchSub.poCreateVsConfEntry.data.Fifty_FiftySix.ToString();
            TimeBucketEleven = overallData.kpi.purchSub.poCreateVsConfEntry.data.greaterThanEqualFiftySeven.ToString();


            AnalysisOne = "- Will show if PO line has a confirmation date.";
            AnalysisTwo = "- Difference between initial confirmation date creation and PO line item creation.";


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

            TotalOrders = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.Total);
            Average = string.Format("{0:n}", overallData.kpi.purchSub.poCreateVsConfEntry.data.Average);
            PercNoConf = string.Format("{0:n}", overallData.kpi.purchSub.poCreateVsConfEntry.data.PercentUnconf);
            PercNoConfTotal = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.PercentUnconfTotal);
            TimeBucketOne = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.LessThanZero);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.One_Three);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.Four_Seven);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.Eight_Fourteen);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.Fifteen_TwentyOne);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.TwentyNine_ThirtyFive);
            TimeBucketEight = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.ThirtySix_FourtyTwo);
            TimeBucketNine = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.FourtyThree_FourtyNine);
            TimeBucketTen = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.Fifty_FiftySix);
            TimeBucketEleven = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.greaterThanEqualFiftySeven);


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
                        // PR Release vs PO Release
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        prRelVsPORel = new DataTable();
                        prRelVsPORel = PRPO_DB_Utils.prsOnPOsDt.Clone();



                        foreach (DataRow dr in PRPO_DB_Utils.prsOnPOsDt.Rows)
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



                            string[] strPOLineFirstRelDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                            int poLineFirstRelYear = int.Parse(strPOLineFirstRelDate[2]);
                            int poLineFirstRelMonth = int.Parse(strPOLineFirstRelDate[0]);
                            int poLineFirstRelDay = int.Parse(strPOLineFirstRelDate[1]);

                            if (poLineFirstRelYear == 0 && poLineFirstRelMonth == 0 && poLineFirstRelDay == 0)
                            {
                                continue;
                            }
                            else
                            {
                                poLineFirstRelYear = int.Parse(strPOLineFirstRelDate[2]);
                                poLineFirstRelMonth = int.Parse(strPOLineFirstRelDate[0].TrimStart('0'));
                                poLineFirstRelDay = int.Parse(strPOLineFirstRelDate[1].TrimStart('0'));
                            }

                            DateTime poLineFirstRelDate = new DateTime(poLineFirstRelYear, poLineFirstRelMonth, poLineFirstRelDay);

                            string[] strPR2ndLvlRelDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                            int secLvlRelYear = int.Parse(strPR2ndLvlRelDate[2]);
                            int secLvlRelMonth = int.Parse(strPR2ndLvlRelDate[0].TrimStart('0'));
                            int secLvlRelDay = int.Parse(strPR2ndLvlRelDate[1].TrimStart('0'));

                            DateTime pr2ndLvlRelDate = new DateTime(secLvlRelYear, secLvlRelMonth, secLvlRelDay);
                            double elapsedDays = (int)(poLineFirstRelDate - pr2ndLvlRelDate).TotalDays;

                            switch (tag)
                            {
                                case 0:
                                    prRelVsPORel.ImportRow(dr);
                                    break;
                                case 1:
                                    if (elapsedDays <= 0)
                                    {
                                        prRelVsPORel.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (elapsedDays >= 1 && elapsedDays <= 3)
                                    {
                                        prRelVsPORel.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (elapsedDays >= 4 && elapsedDays <= 7)
                                    {
                                        prRelVsPORel.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (elapsedDays >= 8 && elapsedDays <= 14)
                                    {
                                        prRelVsPORel.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (elapsedDays >= 15 && elapsedDays <= 21)
                                    {
                                        prRelVsPORel.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (elapsedDays >= 22 && elapsedDays <= 28)
                                    {
                                        prRelVsPORel.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (elapsedDays >= 29 && elapsedDays <= 35)
                                    {
                                        prRelVsPORel.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (elapsedDays >= 36 && elapsedDays <= 42)
                                    {
                                        prRelVsPORel.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (elapsedDays >= 43 && elapsedDays <= 49)
                                    {
                                        prRelVsPORel.ImportRow(dr);
                                    }
                                    continue;
                                case 10:
                                    if (elapsedDays >= 50 && elapsedDays <= 56)
                                    {
                                        prRelVsPORel.ImportRow(dr);
                                    }
                                    continue;
                                case 11:
                                    if(elapsedDays >= 57)
                                    {
                                        prRelVsPORel.ImportRow(dr);
                                    }
                                    continue;   
                                default:
                                    continue;
                            }
                        }

                        using (DataViewer dv = new DataViewer() { Data = prRelVsPORel, Country = CurrCountry, Performance = CurrPerformance, Section = CurrSection, Category = CurrCategory })
                        {
                            dv.LoadData();
                            dv.ShowDialog();
                        }
                        break;
                    case 1:
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //
                        // PO Creation vs Confirmation Entry
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        poCreateVsConfEntry = new DataTable();
                        unconfirmed = new DataTable();


                        poCreateVsConfEntry = PRPO_DB_Utils.prsOnPOsDt.Clone();
                        unconfirmed = PRPO_DB_Utils.prsOnPOsDt.Clone();



                        foreach (DataRow dr in PRPO_DB_Utils.prsOnPOsDt.Rows)
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



                            string[] strFirstConCreatefDate = (dr["1st Conf Creation Da"].ToString()).Split('/');
                            int poLineFirstConCreatefYear = int.Parse(strFirstConCreatefDate[2]);
                            int poLineFirstConfCreateMonth = int.Parse(strFirstConCreatefDate[0]);
                            int poLineFirstConfCreateDay = int.Parse(strFirstConCreatefDate[1]);

                            if (poLineFirstConCreatefYear == 0 && poLineFirstConfCreateMonth == 0 && poLineFirstConfCreateDay == 0)
                            {
                                unconfirmed.ImportRow(dr);
                                continue;
                            }
                            else
                            {
                                poLineFirstConCreatefYear = int.Parse(strFirstConCreatefDate[2]);
                                poLineFirstConfCreateMonth = int.Parse(strFirstConCreatefDate[0]);
                                poLineFirstConfCreateDay = int.Parse(strFirstConCreatefDate[1]);
                            }


                            DateTime initialConfCreateDate = new DateTime(poLineFirstConCreatefYear, poLineFirstConfCreateMonth, poLineFirstConfCreateDay);

                            string[] strPOLineCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                            int poLineCreateYear = int.Parse(strPOLineCreateDt[2]);
                            int poLineCreateMonth = int.Parse(strPOLineCreateDt[0].TrimStart('0'));
                            int poLineCreateDay = int.Parse(strPOLineCreateDt[1].TrimStart('0'));

                            DateTime poLineItemCreateDate = new DateTime(poLineCreateYear, poLineCreateMonth, poLineCreateDay);

                            double elapsedDays = (int)(initialConfCreateDate - poLineItemCreateDate).TotalDays;

                            switch (tag)
                            {
                                case 0:
                                    poCreateVsConfEntry.ImportRow(dr);
                                    break;
                                case 1:
                                    if (elapsedDays <= 0)
                                    {
                                        poCreateVsConfEntry.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (elapsedDays >= 1 && elapsedDays <= 3)
                                    {
                                        poCreateVsConfEntry.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (elapsedDays >= 4 && elapsedDays <= 7)
                                    {
                                        poCreateVsConfEntry.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (elapsedDays >= 8 && elapsedDays <= 14)
                                    {
                                        poCreateVsConfEntry.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (elapsedDays >= 15 && elapsedDays <= 21)
                                    {
                                        poCreateVsConfEntry.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (elapsedDays >= 22 && elapsedDays <= 28)
                                    {
                                        poCreateVsConfEntry.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (elapsedDays >= 29 && elapsedDays <= 35)
                                    {
                                        poCreateVsConfEntry.ImportRow(dr);
                                    }
                                    continue;
                                case 8:
                                    if (elapsedDays >= 36 && elapsedDays <= 42)
                                    {
                                        poCreateVsConfEntry.ImportRow(dr);
                                    }
                                    continue;
                                case 9:
                                    if (elapsedDays >= 43 && elapsedDays <= 49)
                                    {
                                        poCreateVsConfEntry.ImportRow(dr);
                                    }
                                    continue;
                                case 10:
                                    if (elapsedDays >= 50 && elapsedDays <= 56)
                                    {
                                        poCreateVsConfEntry.ImportRow(dr);
                                    }
                                    continue;
                                case 11:
                                    if (elapsedDays >= 57)
                                    {
                                        poCreateVsConfEntry.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        if (tag != 12)
                        {
                            using (DataViewer dv = new DataViewer() { Data = poCreateVsConfEntry, Country = CurrCountry, Performance = CurrPerformance, Section = CurrSection, Category = CurrCategory })
                            {
                                dv.LoadData();
                                dv.ShowDialog();
                            }
                        }
                        else
                        {
                            using (DataViewer dv = new DataViewer() { Data = unconfirmed, Country = CurrCountry, Performance = CurrPerformance, Section = CurrSection, Category = CurrCategory })
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
                MessageBox.Show(ex.Message, "KPI -> Purch Sub Data Viewer Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
