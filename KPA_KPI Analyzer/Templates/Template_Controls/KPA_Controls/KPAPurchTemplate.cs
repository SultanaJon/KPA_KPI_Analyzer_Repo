using KPA_KPI_Analyzer.DataLoading.KPA_Data.DataTableLoader;
using KPA_KPI_Analyzer.KPA_KPI_Overall;
using KPA_KPI_Analyzer.Values;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPA_Controls
{
    public partial class KPAPurchTemplate : UserControl
    {
        private Overall overallData = new Overall();



        public delegate void UpdateCategoryHandler();
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
        public KPAPurchTemplate()
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
        private string TimeBucketTwo { get { return lbl_timebuckTwo.Text; } set { lbl_timebuckTwo.Text = value; } }
        private string TimeBucketThree { get { return lbl_timebuckThree.Text; } set { lbl_timebuckThree.Text = value;  } }
        private string TimeBucketFour { get { return lbl_timebuckFour.Text; } set { lbl_timebuckFour.Text = value;  } }
        private string TimeBucketFive { get { return lbl_timebuckFive.Text; } set { lbl_timebuckFive.Text = value; }  }
        private string TimeBucketSix { get { return lbl_timebuckSix.Text; } set { lbl_timebuckSix.Text = value;  } }
        private string TimeBucketSeven { get { return lbl_timebuckSeven.Text; } set { lbl_timebuckSeven.Text = value;  } }
        private System.Drawing.Color DefaultButtonTextColor
        {
            set
            {
                btn_One.Textcolor = value;
                btn_Two.Textcolor = value;
                btn_Three.Textcolor = value;
                btn_Four.Textcolor = value;
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
            RenderPRAgingRel();
            btn_One.selected = true;
            btn_One.Textcolor = System.Drawing.Color.Coral;
            ActiveCategory = 0;
            datavizLoadTimer.Start();
            Globals.CurrCategory = Globals.kpaCategories[(int)Globals.KPA_Sections.Purch][(int)Globals.KPA_Categories.Purch.PRsAgingRel];
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
            btn_Four.selected = false;
            btn.selected = true;
            DefaultButtonTextColor = System.Drawing.Color.DarkGray;
            btn.Textcolor = System.Drawing.Color.Coral;


            int tag = int.Parse(btn.Tag.ToString());
            ActiveCategory = tag;



            switch (tag)
            {
                case 0:
                    RenderPRAgingRel();
                    break;
                case 1:
                    RenderPOFirstRel();
                    break;
                case 2:
                    RenderPOPrevRel();
                    break;
                case 3:
                    NoConfirmation();
                    break;
                default:
                    break;
            }
        }






        /// <summary>
        /// Renders the specific KPA category into the loaded template
        /// </summary>
        private void RenderPRAgingRel()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);

            Title = Globals.kpaCategories[(int)Globals.KPA_Sections.Purch][(int)Globals.KPA_Categories.Purch.PRsAgingRel];
            Globals.CurrCategory = Title;
            Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.Purch];
            ChangeCategory();
            
            TimeBucketOne = overallData.kpa.purch.prsAgingRel.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpa.purch.prsAgingRel.data.One_Three.ToString();
            TimeBucketThree = overallData.kpa.purch.prsAgingRel.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpa.purch.prsAgingRel.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpa.purch.prsAgingRel.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpa.purch.prsAgingRel.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpa.purch.prsAgingRel.data.TwentyNinePlus.ToString();


            TotalOrders = string.Format("{0:n0}", overallData.kpa.purch.prsAgingRel.data.Total);
            Average = string.Format("{0:n}", overallData.kpa.purch.prsAgingRel.data.Average);

            AnalysisOne = "- Will only show in this field if the PR is fully released and the PR open Qty > 0.";
            AnalysisTwo = "- Difference between todays date and the date the PR was fully released.";


            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);

            TimeBucketOne = string.Format("{0:n0}", overallData.kpa.purch.prsAgingRel.data.LessThanZero);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpa.purch.prsAgingRel.data.One_Three);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpa.purch.prsAgingRel.data.Four_Seven);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpa.purch.prsAgingRel.data.Eight_Fourteen);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpa.purch.prsAgingRel.data.Fifteen_TwentyOne);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpa.purch.prsAgingRel.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpa.purch.prsAgingRel.data.TwentyNinePlus);

            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);

            canvas.addData(dp);
            dataviz.Render(canvas);
        }






        /// <summary>
        /// Renders the specific KPA category into the loaded template
        /// </summary>
        private void RenderPOFirstRel()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);
            Title = Globals.kpaCategories[(int)Globals.KPA_Sections.Purch][(int)Globals.KPA_Categories.Purch.POFirstRelease];
            Globals.CurrCategory = Title;
            Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.Purch];
            ChangeCategory();

            TimeBucketOne = overallData.kpa.purch.poFirstRel.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpa.purch.poFirstRel.data.One_Three.ToString();
            TimeBucketThree = overallData.kpa.purch.poFirstRel.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpa.purch.poFirstRel.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpa.purch.poFirstRel.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpa.purch.poFirstRel.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpa.purch.poFirstRel.data.TwentyNinePlus.ToString();


            TotalOrders = string.Format("{0:n0}", overallData.kpa.purch.poFirstRel.data.Total);
            Average = string.Format("{0:n}", overallData.kpa.purch.poFirstRel.data.Average);


            AnalysisOne = "- Will only show in this field if PR is on the PO and the PO line item has never been released (approved).";
            AnalysisTwo = "- Difference between todays date and the date the PR was added to the PO.";

            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);

            TimeBucketOne = string.Format("{0:n0}", overallData.kpa.purch.poFirstRel.data.LessThanZero);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpa.purch.poFirstRel.data.One_Three);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpa.purch.poFirstRel.data.Four_Seven);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpa.purch.poFirstRel.data.Eight_Fourteen);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpa.purch.poFirstRel.data.Fifteen_TwentyOne);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpa.purch.poFirstRel.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpa.purch.poFirstRel.data.TwentyNinePlus);


            canvas.addData(dp);
            dataviz.Render(canvas);
        }





        /// <summary>
        /// Renders the specific KPA category into the loaded template
        /// </summary>
        private void RenderPOPrevRel()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);
            Title = Globals.kpaCategories[(int)Globals.KPA_Sections.Purch][(int)Globals.KPA_Categories.Purch.POPrevRelease];
            Globals.CurrCategory = Title;
            Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.PurchTotal];
            ChangeCategory();

            TimeBucketOne = overallData.kpa.purch.poPrevRel.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpa.purch.poPrevRel.data.One_Three.ToString();
            TimeBucketThree = overallData.kpa.purch.poPrevRel.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpa.purch.poPrevRel.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpa.purch.poPrevRel.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpa.purch.poPrevRel.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpa.purch.poPrevRel.data.TwentyNinePlus.ToString();


            TotalOrders = string.Format("{0:n0}", overallData.kpa.purch.poPrevRel.data.Total);
            Average = string.Format("{0:n}", overallData.kpa.purch.poPrevRel.data.Average);

            AnalysisOne = "- PR is on the PO, PO line items was previously released, PO currently not released (approved), and line item is not received.";
            AnalysisTwo = "- Difference between todays date and the date the PR was added to the PO.";

            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);


            TimeBucketOne = string.Format("{0:n0}", overallData.kpa.purch.poPrevRel.data.LessThanZero);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpa.purch.poPrevRel.data.One_Three);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpa.purch.poPrevRel.data.Four_Seven);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpa.purch.poPrevRel.data.Eight_Fourteen);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpa.purch.poPrevRel.data.Fifteen_TwentyOne);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpa.purch.poPrevRel.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpa.purch.poPrevRel.data.TwentyNinePlus);



            canvas.addData(dp);
            dataviz.Render(canvas);
        }





        /// <summary>
        /// Renders the specific KPA category into the loaded template
        /// </summary>
        private void NoConfirmation()
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);
            Title = Globals.kpaCategories[(int)Globals.KPA_Sections.Purch][(int)Globals.KPA_Categories.Purch.NoConfirmation];
            Globals.CurrCategory = Title;
            Globals.CurrSection = Globals.kpaSections[(int)Globals.KPA_Sections.PurchTotal];
            ChangeCategory();

            TimeBucketOne = overallData.kpa.purch.noConfirmation.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpa.purch.noConfirmation.data.One_Three.ToString();
            TimeBucketThree = overallData.kpa.purch.noConfirmation.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpa.purch.noConfirmation.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpa.purch.noConfirmation.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpa.purch.noConfirmation.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpa.purch.noConfirmation.data.TwentyNinePlus.ToString();


            TotalOrders = string.Format("{0:n0}", overallData.kpa.purch.noConfirmation.data.Total);
            Average = string.Format("{0:n}", overallData.kpa.purch.noConfirmation.data.Average);


            AnalysisOne = "- PR is on PO, PO previously released, no confirmation, and line not received complete.";
            AnalysisTwo = "- Difference between todays date and the date that PO line item first approved.";

            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);


            TimeBucketOne = string.Format("{0:n0}", overallData.kpa.purch.noConfirmation.data.LessThanZero);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpa.purch.noConfirmation.data.One_Three);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpa.purch.noConfirmation.data.Four_Seven);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpa.purch.noConfirmation.data.Eight_Fourteen);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpa.purch.noConfirmation.data.Fifteen_TwentyOne);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpa.purch.noConfirmation.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpa.purch.noConfirmation.data.TwentyNinePlus);



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
                using (DataViewer dv = new DataViewer())
                {
                    Bunifu.Framework.UI.BunifuFlatButton btn = (Bunifu.Framework.UI.BunifuFlatButton)sender;
                    int tag = int.Parse(btn.Tag.ToString());

                    switch (ActiveCategory)
                    {
                        case 0: // PRs Aging Released
                            dv.DataLoader += KpaDataTableLoader.Purch.LoadPrsAgingReleasedDataTable;
                            dv.ColumnTag = tag;
                            break;
                        case 1: // PO First Release
                            dv.DataLoader += KpaDataTableLoader.Purch.LoadPoFirstReleaseDataTable;
                            dv.ColumnTag = tag;
                            break;
                        case 2: // PO Prev Release
                            dv.DataLoader += KpaDataTableLoader.Purch.LoadPoPrevReleaseDataTable;
                            dv.ColumnTag = tag;
                            break;
                        case 3: // No Confirmations
                            dv.DataLoader += KpaDataTableLoader.Purch.LoadNoConfirmationsDataTable;
                            dv.ColumnTag = tag;
                            break;
                    }
                    dv.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Purch Data Viewer Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
