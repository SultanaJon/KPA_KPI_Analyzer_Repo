using Excel_Access_Tools.Access;
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
    public partial class KPAPlanTemplate : UserControl
    {
        Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
        Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);
        Overall overallData = new Overall();
        DataTable dt;
        DataTable prsAgingNotRelDt;
        DataTable MaterialDueDt;
        OleDbDataAdapter da;
        OleDbCommand cmd;


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
        public KPAPlanTemplate()
        {
            InitializeComponent();
        }






        /// <summary>
        /// Properties for the various labels on the control
        /// </summary>
        #region Template Properties
        public string TotalOrders { get { return lbl_totalOrders.Text; } set { lbl_totalOrders.Text = value; } }

        private string Title { get { return lbl_title.Text; } set { lbl_title.Text = value; } }
        private string AnalysisOne { get { return lbl_analysisOne.Text; } set { lbl_analysisOne.Text = value; } }
        private string AnalysisTwo { get { return lbl_analysisTwo.Text; } set { lbl_analysisTwo.Text = value; } }
        private string Average { get { return lbl_average.Text; } set { lbl_average.Text = value + " Day(s)"; } }
        private string TimeBucketOne { get { return lbl_timebuckOne.Text; } set { lbl_timebuckOne.Text = value; } }
        private string TimeBucketTwo { get { return lbl_timebuckTwo.Text; } set { lbl_timebuckTwo.Text = value; } }
        private string TimeBucketThree { get { return lbl_timebuckThree.Text; } set { lbl_timebuckThree.Text = value; } }
        private string TimeBucketFour { get { return lbl_timebuckFour.Text; } set { lbl_timebuckFour.Text = value; } }
        private string TimeBucketFive { get { return lbl_timebuckFive.Text; } set { lbl_timebuckFive.Text = value; } }
        private string TimeBucketSix { get { return lbl_timebuckSix.Text; } set { lbl_timebuckSix.Text = value; } }
        private string TimeBucketSeven { get { return lbl_timebuckSeven.Text; } set { lbl_timebuckSeven.Text = value; } }
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
        public void LoadPanel(Overall overall)
        {
            overallData = overall;
            SetGraphColor();
            DefaultButtonTextColor = System.Drawing.Color.DarkGray;
            btn_Two.selected = true;
            btn_Two.Textcolor = System.Drawing.Color.Coral;
            RenderPRsAgingNotRel();
            DatavizLoaded = false;
            ActiveCategory = 1;
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
                    // There will need to be a data coming soon panel presented
                    break;
                case 1:
                    RenderPRsAgingNotRel();
                    break;
                case 2:
                    RenderMaterialDue();
                    break;
                default:
                    break;
            }
        }




        /// <summary>
        /// Renders the specific KPA category into the loaded template
        /// </summary>
        private void RenderPRsAgingNotRel()
        {
            canvas = new Bunifu.DataViz.Canvas();
            dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);

            Title = "PRs Aging (Not Released)";
            ChangeCategory(Title);
            TimeBucketOne = overallData.kpa.plan.prsAgingNotRel.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpa.plan.prsAgingNotRel.data.One_Three.ToString();
            TimeBucketThree = overallData.kpa.plan.prsAgingNotRel.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpa.plan.prsAgingNotRel.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpa.plan.prsAgingNotRel.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpa.plan.prsAgingNotRel.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpa.plan.prsAgingNotRel.data.TwentyNinePlus.ToString();

            Average = String.Format("{0:n}", overallData.kpa.plan.prsAgingNotRel.data.Average);
            TotalOrders = String.Format("{0:n0}", overallData.kpa.plan.prsAgingNotRel.data.Total);

            AnalysisOne = "- Will only show in this field if the PR is not fully released and the PR Open Qty > 0.";
            AnalysisTwo = "- Difference between todays date and the date the PR was created.";

            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);

            canvas.addData(dp);
            dataviz.Render(canvas);

            TimeBucketOne = String.Format("{0:n0}", overallData.kpa.plan.prsAgingNotRel.data.LessThanZero);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpa.plan.prsAgingNotRel.data.One_Three);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpa.plan.prsAgingNotRel.data.Four_Seven);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpa.plan.prsAgingNotRel.data.Eight_Fourteen);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpa.plan.prsAgingNotRel.data.Fifteen_TwentyOne);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpa.plan.prsAgingNotRel.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpa.plan.prsAgingNotRel.data.TwentyNinePlus);

        }







        /// <summary>
        /// Renders the specific KPA category into the loaded template
        /// </summary>
        private void RenderMaterialDue()
        {
            canvas = new Bunifu.DataViz.Canvas();
            dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);
            Title = "Material Due";
            ChangeCategory(Title);

            TimeBucketOne = overallData.kpa.plan.matDueDate.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpa.plan.matDueDate.data.One_Three.ToString();
            TimeBucketThree = overallData.kpa.plan.matDueDate.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpa.plan.matDueDate.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpa.plan.matDueDate.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpa.plan.matDueDate.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpa.plan.matDueDate.data.TwentyNinePlus.ToString();

            Average = String.Format("{0:n}", overallData.kpa.plan.matDueDate.data.Average);
            TotalOrders = String.Format("{0:n0}", overallData.kpa.plan.matDueDate.data.Total);

            AnalysisOne = "- Will only show in this field if PR is fully released and the PR Open Qty > 0.";
            AnalysisTwo = "- Difference between the current requirement date and todays date.";

            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);

            canvas.addData(dp);
            dataviz.Render(canvas);

            TimeBucketOne = String.Format("{0:n0}", overallData.kpa.plan.matDueDate.data.LessThanZero);
            TimeBucketTwo = String.Format("{0:n0}", overallData.kpa.plan.matDueDate.data.One_Three);
            TimeBucketThree = String.Format("{0:n0}", overallData.kpa.plan.matDueDate.data.Four_Seven);
            TimeBucketFour = String.Format("{0:n0}", overallData.kpa.plan.matDueDate.data.Eight_Fourteen);
            TimeBucketFive = String.Format("{0:n0}", overallData.kpa.plan.matDueDate.data.Fifteen_TwentyOne);
            TimeBucketSix = String.Format("{0:n0}", overallData.kpa.plan.matDueDate.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = String.Format("{0:n0}", overallData.kpa.plan.matDueDate.data.TwentyNinePlus);

        }






        /// <summary>
        /// Triggered when the template is loaded. This will load the data in the template
        /// into the dataviz object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datavizLoadTimer_Tick(object sender, EventArgs e)
        {
            if(!DatavizLoaded)
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
        private void btn_viewData_Click(object sender, EventArgs e)
        {
            try
            {
                Bunifu.Framework.UI.BunifuFlatButton btn = (Bunifu.Framework.UI.BunifuFlatButton)sender;
                int tag = int.Parse(btn.Tag.ToString());

                switch (ActiveCategory)
                {
                    case 0:
                        break;
                    case 1:

                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //
                        // PRs Aging (Not Released)
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        dt = new DataTable();
                        prsAgingNotRelDt = new DataTable();

                        if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                            cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_Plan_PRsAgingNotRel] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                        else
                            cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_Plan_PRsAgingNotRel] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);

                        da = new OleDbDataAdapter(cmd);
                        da.Fill(dt);

                        prsAgingNotRelDt = dt.Clone();



                        foreach (DataRow dr in dt.Rows)
                        {
                            string[] reqCreationDate = (dr["Requisn Date"].ToString()).Split('/');
                            int year = int.Parse(reqCreationDate[2]);
                            int month = int.Parse(reqCreationDate[0].TrimStart('0'));
                            int day = int.Parse(reqCreationDate[1].TrimStart('0'));

                            DateTime reqDate = new DateTime(year, month, day);
                            double elapsedDays = (int)(DateTime.Now - reqDate).TotalDays;

                            switch (tag)
                            {
                                case 0:
                                    prsAgingNotRelDt.ImportRow(dr);
                                    break;
                                case 1:
                                    if (elapsedDays <= 0)
                                    {
                                        prsAgingNotRelDt.ImportRow(dr);
                                    }
                                    continue;
                                case 2:
                                    if (elapsedDays >= 1 && elapsedDays <= 3)
                                    {
                                        prsAgingNotRelDt.ImportRow(dr);
                                    }
                                    continue;
                                case 3:
                                    if (elapsedDays >= 4 && elapsedDays <= 7)
                                    {
                                        prsAgingNotRelDt.ImportRow(dr);
                                    }
                                    continue;
                                case 4:
                                    if (elapsedDays >= 8 && elapsedDays <= 14)
                                    {
                                        prsAgingNotRelDt.ImportRow(dr);
                                    }
                                    continue;
                                case 5:
                                    if (elapsedDays >= 15 && elapsedDays <= 21)
                                    {
                                        prsAgingNotRelDt.ImportRow(dr);
                                    }
                                    continue;
                                case 6:
                                    if (elapsedDays >= 22 && elapsedDays <= 28)
                                    {
                                        prsAgingNotRelDt.ImportRow(dr);
                                    }
                                    continue;
                                case 7:
                                    if (elapsedDays >= 29)
                                    {
                                        prsAgingNotRelDt.ImportRow(dr);
                                    }
                                    continue;
                                default:
                                    continue;
                            }
                        }

                        using (DataViewer dv = new DataViewer() { Data = prsAgingNotRelDt })
                        {
                            dv.LoadData();
                            dv.ShowDialog();
                        }

                        break;
                    case 2:
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //
                        // Material Due
                        //
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        dt = new DataTable();
                        MaterialDueDt = new DataTable();

                        if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                            cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_Plan_MaterialDue] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                        else
                            cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_Plan_MaterialDue] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);

                        da = new OleDbDataAdapter(cmd);
                        da.Fill(dt);

                        MaterialDueDt = dt.Clone();

                        foreach (DataRow dr in dt.Rows)
                        {
                            string[] strCurrReqDate = (dr["PR Delivery Date"].ToString()).Split('/');
                            int year = int.Parse(strCurrReqDate[2]);
                            int month = int.Parse(strCurrReqDate[0].TrimStart('0'));
                            int day = int.Parse(strCurrReqDate[1].TrimStart('0'));

                            DateTime currReqDate = new DateTime(year, month, day);
                            DateTime today = DateTime.Now.Date;
                            double elapsedDays = (int)(currReqDate - today).TotalDays;


                            switch (int.Parse(btn.Tag.ToString()))
                            {
                                case 0:
                                    MaterialDueDt.ImportRow(dr);
                                    break;
                                case 1:
                                    if (elapsedDays <= 0)
                                    {
                                        MaterialDueDt.ImportRow(dr);
                                    }
                                    break;
                                case 2:
                                    if (elapsedDays >= 1 && elapsedDays <= 3)
                                    {
                                        MaterialDueDt.ImportRow(dr);
                                    }
                                    break;
                                case 3:
                                    if (elapsedDays >= 4 && elapsedDays <= 7)
                                    {
                                        MaterialDueDt.ImportRow(dr);
                                    }
                                    break;
                                case 4:
                                    if (elapsedDays >= 8 && elapsedDays <= 14)
                                    {
                                        MaterialDueDt.ImportRow(dr);
                                    }
                                    break;
                                case 5:
                                    if (elapsedDays >= 15 && elapsedDays <= 21)
                                    {
                                        MaterialDueDt.ImportRow(dr);
                                    }
                                    break;
                                case 6:
                                    if (elapsedDays >= 22 && elapsedDays <= 28)
                                    {
                                        MaterialDueDt.ImportRow(dr);
                                    }
                                    break;
                                case 7:
                                    if (elapsedDays >= 29)
                                    {
                                        MaterialDueDt.ImportRow(dr);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }

                        using (DataViewer dv = new DataViewer() { Data = MaterialDueDt })
                        {
                            dv.LoadData();
                            dv.ShowDialog();
                        }
                        break;
                    default:
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Plan Data Viewer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
