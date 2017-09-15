using DataImporter.Access;
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
    public partial class KPAPurchTotalTemplate : UserControl
    {
        Overall overallData = new Overall();
        DataTable dt;
        DataTable prRelConfEntry;
        OleDbDataAdapter da;
        OleDbCommand cmd;



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
        public KPAPurchTotalTemplate()
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
        private string TimeBucketTwo { get { return lbl_timebuckTwo.Text; } set { lbl_timebuckTwo.Text = value; } }
        private string TimeBucketThree { get { return lbl_timebuckThree.Text; } set { lbl_timebuckThree.Text = value; } }
        private string TimeBucketFour { get { return lbl_timebuckFour.Text; } set { lbl_timebuckFour.Text = value; } }
        private string TimeBucketFive { get { return lbl_timebuckFive.Text; } set { lbl_timebuckFive.Text = value;  } }
        private string TimeBucketSix { get { return lbl_timebuckSix.Text; } set { lbl_timebuckSix.Text = value;  } }
        private string TimeBucketSeven { get { return lbl_timebuckSeven.Text; } set { lbl_timebuckSeven.Text = value;  } }
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
            RenderPRRelToConfEntry();
            ActiveCategory = 0;
            datavizLoadTimer.Start();
            CurrCategory = "PR Release to Confirmation Entry";
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
                    RenderPRRelToConfEntry();
                    break;
                default:
                    break;
            }
        }





        /// <summary>
        /// Renders the specific KPA category into the loaded template
        /// </summary>
        public void RenderPRRelToConfEntry()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);

            Title = "PR Release to Confirmation Entry";
            ChangeCategory(Title);
            CurrCategory = Title;

            TimeBucketOne = overallData.kpa.purchTotal.prRelConfEntry.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpa.purchTotal.prRelConfEntry.data.One_Three.ToString();
            TimeBucketThree = overallData.kpa.purchTotal.prRelConfEntry.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpa.purchTotal.prRelConfEntry.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpa.purchTotal.prRelConfEntry.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpa.purchTotal.prRelConfEntry.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpa.purchTotal.prRelConfEntry.data.TwentyNinePlus.ToString();

            TotalOrders = string.Format("{0:n0}", overallData.kpa.purchTotal.prRelConfEntry.data.Total);
            Average = string.Format("{0:n}", overallData.kpa.purchTotal.prRelConfEntry.data.Average);

            AnalysisOne = "- PRs fully released which are either not on a PO or on a PO (but have not been confirmed and are not delivered).";
            AnalysisTwo = "- Difference between todays date and the date the PR was released to the 2nd level.";

            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);

            TimeBucketOne = string.Format("{0:n0}", overallData.kpa.purchTotal.prRelConfEntry.data.LessThanZero);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpa.purchTotal.prRelConfEntry.data.One_Three);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpa.purchTotal.prRelConfEntry.data.Four_Seven);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpa.purchTotal.prRelConfEntry.data.Eight_Fourteen);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpa.purchTotal.prRelConfEntry.data.Fifteen_TwentyOne);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpa.purchTotal.prRelConfEntry.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpa.purchTotal.prRelConfEntry.data.TwentyNinePlus);


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
                // PR Release to Confirmation Entry
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = new DataTable();
                prRelConfEntry = new DataTable();

                if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_PurchTotal_PRRelConfEntry] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                else
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_PurchTotal_PRRelConfEntry] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);

                da = new OleDbDataAdapter(cmd);
                da.Fill(dt);

                prRelConfEntry = dt.Clone();


                foreach (DataRow dr in dt.Rows)
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




                    string[] strDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime date = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (int)(today - date).TotalDays;

                    switch (tag)
                    {
                        case 0:
                            prRelConfEntry.ImportRow(dr);
                            break;
                        case 1:
                            if (elapsedDays <= 0)
                            {
                                prRelConfEntry.ImportRow(dr);
                            }
                            continue;
                        case 2:
                            if (elapsedDays >= 1 && elapsedDays <= 3)
                            {
                                prRelConfEntry.ImportRow(dr);
                            }
                            continue;
                        case 3:
                            if (elapsedDays >= 4 && elapsedDays <= 7)
                            {
                                prRelConfEntry.ImportRow(dr);
                            }
                            continue;
                        case 4:
                            if (elapsedDays >= 8 && elapsedDays <= 14)
                            {
                                prRelConfEntry.ImportRow(dr);
                            }
                            continue;
                        case 5:
                            if (elapsedDays >= 15 && elapsedDays <= 21)
                            {
                                prRelConfEntry.ImportRow(dr);
                            }
                            continue;
                        case 6:
                            if (elapsedDays >= 22 && elapsedDays <= 28)
                            {
                                prRelConfEntry.ImportRow(dr);
                            }
                            continue;
                        case 7:
                            if (elapsedDays >= 29)
                            {
                                prRelConfEntry.ImportRow(dr);
                            }
                            continue;
                        default:
                            continue;
                    }
                }

                using (DataViewer dv = new DataViewer() { Data = prRelConfEntry, Country = CurrCountry, Performance = CurrPerformance, Section = CurrSection, Category = CurrCategory })
                {
                    dv.LoadData();
                    dv.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Purch Total Data Viewer Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
