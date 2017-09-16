using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using KPA_KPI_Analyzer.FilterFeeature;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPI_Controls
{
    public partial class KPIPurchTemplate : UserControl
    {
        Overall overallData;
        DataTable initConfVsPrPlanDateDt;
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
            CurrCategory = "Initial Confirmation vs PR Planned Date";
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

            Title = "Initial Confirmation vs PR Planned Date";
            ChangeCategory(Title);
            CurrCategory = Title;

            TimeBucketOne = overallData.kpi.purch.initConfVsPRPlanDate.data.Minus_TwentyTwo.ToString();
            TimeBucketTwo = overallData.kpi.purch.initConfVsPRPlanDate.data.Minus_Fifteen_TwentyOne.ToString();
            TimeBucketThree = overallData.kpi.purch.initConfVsPRPlanDate.data.Minus_Eight_Fourteen.ToString();
            TimeBucketFour = overallData.kpi.purch.initConfVsPRPlanDate.data.Minus_One_Seven.ToString();
            TimeBucketFive = overallData.kpi.purch.initConfVsPRPlanDate.data.Zero.ToString();
            TimeBucketSix = overallData.kpi.purch.initConfVsPRPlanDate.data.One_Seven.ToString();
            TimeBucketSeven = overallData.kpi.purch.initConfVsPRPlanDate.data.Eight_Fourteen.ToString();
            TimeBucketEight = overallData.kpi.purch.initConfVsPRPlanDate.data.Fifteen_TwentyOne.ToString();
            TimeBucketNine = overallData.kpi.purch.initConfVsPRPlanDate.data.TwentyTwo.ToString();

            AnalysisOne = "- Will show if PO line item has been confirmed.";
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
        public void ViewData_Click(object sender, EventArgs e)
        {
            try
            {
                Bunifu.Framework.UI.BunifuFlatButton btn = (Bunifu.Framework.UI.BunifuFlatButton)sender;
                int tag = int.Parse(btn.Tag.ToString());


                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Initial Confirmation vs PR Planned Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                initConfVsPrPlanDateDt = new DataTable();
                unconfirmed = new DataTable();
                DataTable posConf = new DataTable();

                initConfVsPrPlanDateDt = Overall.prsOnPOsDt.Clone();
                unconfirmed = Overall.prsOnPOsDt.Clone();


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



                    string[] strFirstConfDate = (dr["1st Conf Date"].ToString()).Split('/');
                    int firstConfYear = int.Parse(strFirstConfDate[2]);
                    int firstConfMonth = int.Parse(strFirstConfDate[0]);
                    int firstConfDay = int.Parse(strFirstConfDate[1]);

                    if (firstConfYear == 0 && firstConfMonth == 0 && firstConfDay == 0)
                    {
                        unconfirmed.ImportRow(dr);
                        continue;
                    }
                    else
                    {
                        posConf.ImportRow(dr);
                        firstConfYear = int.Parse(strFirstConfDate[2]);
                        firstConfMonth = int.Parse(strFirstConfDate[0].TrimStart('0'));
                        firstConfDay = int.Parse(strFirstConfDate[1].TrimStart('0'));
                    }

                    DateTime firstConfDate = new DateTime(firstConfYear, firstConfMonth, firstConfDay);

                    string[] strPRPlanDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int prDelYear = int.Parse(strPRPlanDate[2]);
                    int prDelMonth = int.Parse(strPRPlanDate[0].TrimStart('0'));
                    int prDelDay = int.Parse(strPRPlanDate[1].TrimStart('0'));

                    DateTime prPlanDate = new DateTime(prDelYear, prDelMonth, prDelDay);
                    double elapsedDays = (int)(firstConfDate - prPlanDate).TotalDays;

                    switch (tag)
                    {
                        case 0:
                            initConfVsPrPlanDateDt.ImportRow(dr);
                            break;
                        case 1:
                            if (elapsedDays <= (-22))
                            {
                                initConfVsPrPlanDateDt.ImportRow(dr);
                            }
                            continue;
                        case 2:
                            if (elapsedDays > (-22) && elapsedDays <= (-15))
                            {
                                initConfVsPrPlanDateDt.ImportRow(dr);
                            }
                            continue;
                        case 3:
                            if (elapsedDays > (-15) && elapsedDays <= (-8))
                            {
                                initConfVsPrPlanDateDt.ImportRow(dr);
                            }
                            continue;
                        case 4:
                            if (elapsedDays > (-8) && elapsedDays <= (-1))
                            {
                                initConfVsPrPlanDateDt.ImportRow(dr);
                            }
                            continue;
                        case 5:
                            if (elapsedDays == 0)
                            {
                                initConfVsPrPlanDateDt.ImportRow(dr);
                            }
                            continue;
                        case 6:
                            if (elapsedDays >= 1 && elapsedDays <= 7)
                            {
                                initConfVsPrPlanDateDt.ImportRow(dr);
                            }
                            continue;
                        case 7:
                            if (elapsedDays >= 8 && elapsedDays <= 14)
                            {
                                initConfVsPrPlanDateDt.ImportRow(dr);
                            }
                            continue;
                        case 8:
                            if (elapsedDays >= 15 && elapsedDays <= 21)
                            {
                                initConfVsPrPlanDateDt.ImportRow(dr);
                            }
                            continue;
                        case 9:
                            if (elapsedDays >= 22)
                            {
                                initConfVsPrPlanDateDt.ImportRow(dr);
                            }
                            continue;
                        default:
                            continue;
                    }
                }

                if (tag != 10)
                {
                    using (DataViewer dv = new DataViewer() { Data = initConfVsPrPlanDateDt, Country = CurrCountry, Performance = CurrPerformance, Section = CurrSection, Category = CurrCategory })
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Purch Data Viewer Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
