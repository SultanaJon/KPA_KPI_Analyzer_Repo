using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPIPurchTotalTemplate : UserControl
    {

        Overall overallData;
        DataTable prReleaseConfEntry;
        DataTable unconfirmed;




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
        public KPIPurchTotalTemplate()
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
        private string TimeBucketTen { get { return lbl_timebuckTen.Text; } set { lbl_timebuckTen.Text = value;  } }
        private string TimeBucketEleven { get { return lbl_timebuckEleven.Text; } set { lbl_timebuckEleven.Text = value; } }
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

            Title = "PR Release to Confirmation Entry";
            TimeBucketOne = overallData.kpi.purchTotal.prRelConfEntry.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpi.purchTotal.prRelConfEntry.data.One_Three.ToString();
            TimeBucketThree = overallData.kpi.purchTotal.prRelConfEntry.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpi.purchTotal.prRelConfEntry.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpi.purchTotal.prRelConfEntry.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpi.purchTotal.prRelConfEntry.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpi.purchTotal.prRelConfEntry.data.TwentyNine_ThirtyFive.ToString();
            TimeBucketEight = overallData.kpi.purchTotal.prRelConfEntry.data.ThirtySix_FourtyTwo.ToString();
            TimeBucketNine = overallData.kpi.purchTotal.prRelConfEntry.data.FourtyThree_FourtyNine.ToString();
            TimeBucketTen = overallData.kpi.purchTotal.prRelConfEntry.data.Fifty_FiftySix.ToString();
            TimeBucketEleven = overallData.kpi.purchTotal.prRelConfEntry.data.greaterThanEqualFiftySeven.ToString();


            AnalysisOne = "- Will show if PO line item has a confirmation date.";
            AnalysisTwo = "- Difference between initial confirmation date creation and PR 2nd level release.";


            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelEleven.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);
            dp.addLabely(lbl_xLabelEight.Text, TimeBucketEight);
            dp.addLabely(lbl_xLabelNine.Text, TimeBucketNine);
            dp.addLabely(lbl_xLabelTen.Text, TimeBucketTen);

            TotalOrders = String.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.Total);
            Average = String.Format("{0:n}", overallData.kpi.purchTotal.prRelConfEntry.data.Average);
            PercNoConf = String.Format("{0:n}", overallData.kpi.purchTotal.prRelConfEntry.data.PercentUnconf);
            PercNoConfTotal = String.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.PercentUnconfTotal);
            TimeBucketOne = String.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.LessThanZero);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.One_Three);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.Four_Seven);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.Eight_Fourteen);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.Fifteen_TwentyOne);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.TwentyNine_ThirtyFive);
            TimeBucketEight = String.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.ThirtySix_FourtyTwo);
            TimeBucketNine = String.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.FourtyThree_FourtyNine);
            TimeBucketTen = String.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.Fifty_FiftySix);
            TimeBucketEleven = String.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.greaterThanEqualFiftySeven);


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
                // PR Release to COnfirmation Entry
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                prReleaseConfEntry = new DataTable();
                unconfirmed = new DataTable();

                prReleaseConfEntry = Overall.prsOnPOsDt.Clone();
                unconfirmed = Overall.prsOnPOsDt.Clone();



                foreach (DataRow dr in Overall.prsOnPOsDt.Rows)
                {
                    string[] strfirstConfCreateDt = (dr["1st Conf Creation Da"].ToString()).Split('/');
                    int firstConfCreateYear = int.Parse(strfirstConfCreateDt[2]);
                    int firstConfCreateMonth = int.Parse(strfirstConfCreateDt[0]);
                    int firstConfCreateDay = int.Parse(strfirstConfCreateDt[1]);

                    if (firstConfCreateYear == 0 && firstConfCreateMonth == 0 & firstConfCreateDay == 0)
                    {
                        unconfirmed.ImportRow(dr);
                        continue;
                    }
                    else
                    {
                        firstConfCreateYear = int.Parse(strfirstConfCreateDt[2]);
                        firstConfCreateMonth = int.Parse(strfirstConfCreateDt[0].TrimStart('0'));
                        firstConfCreateDay = int.Parse(strfirstConfCreateDt[1].TrimStart('0'));
                    }

                    DateTime poLineConfCreateDate = new DateTime(firstConfCreateYear, firstConfCreateMonth, firstConfCreateDay);

                    string[] strPR2ndLvlRelDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    int secLvlRelYear = int.Parse(strPR2ndLvlRelDate[2]);
                    int secLvlRelMonth = int.Parse(strPR2ndLvlRelDate[0].TrimStart('0'));
                    int secLvlRelDay = int.Parse(strPR2ndLvlRelDate[1].TrimStart('0'));

                    DateTime pr2ndLvlRelDate = new DateTime(secLvlRelYear, secLvlRelMonth, secLvlRelDay);
                    double elapsedDays = (int)(poLineConfCreateDate - pr2ndLvlRelDate).TotalDays;

                    switch (tag)
                    {
                        case 0:
                            prReleaseConfEntry.ImportRow(dr);
                            break;
                        case 1:
                            if (elapsedDays <= 0)
                            {
                                prReleaseConfEntry.ImportRow(dr);
                            }
                            continue;
                        case 2:
                            if (elapsedDays >= 1 && elapsedDays <= 3)
                            {
                                prReleaseConfEntry.ImportRow(dr);
                            }
                            continue;
                        case 3:
                            if (elapsedDays >= 4 && elapsedDays <= 7)
                            {
                                prReleaseConfEntry.ImportRow(dr);
                            }
                            continue;
                        case 4:
                            if (elapsedDays >= 8 && elapsedDays <= 14)
                            {
                                prReleaseConfEntry.ImportRow(dr);
                            }
                            continue;
                        case 5:
                            if (elapsedDays >= 15 && elapsedDays <= 21)
                            {
                                prReleaseConfEntry.ImportRow(dr);
                            }
                            continue;
                        case 6:
                            if (elapsedDays >= 22 && elapsedDays <= 28)
                            {
                                prReleaseConfEntry.ImportRow(dr);
                            }
                            continue;
                        case 7:
                            if (elapsedDays >= 29 && elapsedDays <= 35)
                            {
                                prReleaseConfEntry.ImportRow(dr);
                            }
                            continue;
                        case 8:
                            if (elapsedDays >= 36 && elapsedDays <= 42)
                            {
                                prReleaseConfEntry.ImportRow(dr);
                            }
                            continue;
                        case 9:
                            if (elapsedDays >= 43 && elapsedDays <= 49)
                            {
                                prReleaseConfEntry.ImportRow(dr);
                            }
                            continue;
                        case 10:
                            if (elapsedDays >= 50 && elapsedDays <= 56)
                            {
                                prReleaseConfEntry.ImportRow(dr);
                            }
                            continue;
                        case 11:
                            if(elapsedDays >= 57)
                            {
                                prReleaseConfEntry.ImportRow(dr);
                            }
                            continue;
                        default:
                            continue;
                    }
                }

                if(tag != 11)
                {
                    using (DataViewer dv = new DataViewer() { Data = prReleaseConfEntry })
                    {
                        dv.LoadData();
                        dv.ShowDialog();
                    }
                }
                else
                {
                    using (DataViewer dv = new DataViewer() { Data = unconfirmed })
                    {
                        dv.LoadData();
                        dv.ShowDialog();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Purch Total Data Viewer Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
