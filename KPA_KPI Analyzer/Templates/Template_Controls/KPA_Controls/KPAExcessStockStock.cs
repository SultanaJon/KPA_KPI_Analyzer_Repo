using KPA_KPI_Analyzer.DataLoading;
using KPA_KPI_Analyzer.DataLoading.KPA_Data.DataTableLoader;
using KPA_KPI_Analyzer.Overall_Data;
using KPA_KPI_Analyzer.Values;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPA_Controls
{
    public partial class KPAExcessStockStock : UserControl
    {
        Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
        Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);

        Overall overallData = new Overall();



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
        public KPAExcessStockStock()
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
            btn_One.selected = true;
            btn_One.Textcolor = System.Drawing.Color.Coral;
            RenderPRsAgingNotRel();
            DatavizLoaded = false;
            ActiveCategory = 0;
            datavizLoadTimer.Start();
            Globals.CurrCategory = Values.Categories.kpaCategories[(int)Values.Sections.KpaSection.ExcessStock_Stock][(int)Values.Categories.KpaCategory.ExcessStockStock.PrsAgingNotRel];
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
            btn.selected = true;
            DefaultButtonTextColor = System.Drawing.Color.DarkGray;
            btn.Textcolor = System.Drawing.Color.Coral;

            int tag = int.Parse(btn.Tag.ToString());

            ActiveCategory = tag;


            switch (tag)
            {
                case 0:
                    RenderPRsAgingNotRel();
                    break;
                case 1:
                    RenderPrsAgingReleased();
                    break;
                case 2:
                    RenderPoConfThruDeliv();
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

            Title = Values.Categories.kpaCategories[(int)Values.Sections.KpaSection.ExcessStock_Stock][(int)Values.Categories.KpaCategory.ExcessStockStock.PrsAgingNotRel];
            Globals.CurrCategory = Title;
            Globals.CurrSection = Values.Sections.kpaSections[(int)Values.Sections.KpaSection.ExcessStock_Stock];
            ChangeCategory();

            TimeBucketOne = overallData.kpa.excessStockStock.prsAgingNotRel.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpa.excessStockStock.prsAgingNotRel.data.One_Three.ToString();
            TimeBucketThree = overallData.kpa.excessStockStock.prsAgingNotRel.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpa.excessStockStock.prsAgingNotRel.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpa.excessStockStock.prsAgingNotRel.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpa.excessStockStock.prsAgingNotRel.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpa.excessStockStock.prsAgingNotRel.data.TwentyNinePlus.ToString();

            Average = string.Format("{0:n}", overallData.kpa.excessStockStock.prsAgingNotRel.data.Average);
            TotalOrders = string.Format("{0:n0}", overallData.kpa.excessStockStock.prsAgingNotRel.data.Total);

            AnalysisOne = "- Will only show in this field if the PR is not fully released, the PR Open Qty > 0, General Stock On Hand > 0 and Project Stock On Hand > 0.";
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

            TimeBucketOne = string.Format("{0:n0}", overallData.kpa.excessStockStock.prsAgingNotRel.data.LessThanZero);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpa.excessStockStock.prsAgingNotRel.data.One_Three);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpa.excessStockStock.prsAgingNotRel.data.Four_Seven);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpa.excessStockStock.prsAgingNotRel.data.Eight_Fourteen);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpa.excessStockStock.prsAgingNotRel.data.Fifteen_TwentyOne);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpa.excessStockStock.prsAgingNotRel.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpa.excessStockStock.prsAgingNotRel.data.TwentyNinePlus);

        }







        /// <summary>
        /// Renders the specific KPA category into the loaded template
        /// </summary>
        private void RenderPrsAgingReleased()
        {
            canvas = new Bunifu.DataViz.Canvas();
            dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);
            Title = Values.Categories.kpaCategories[(int)Values.Sections.KpaSection.ExcessStock_Stock][(int)Values.Categories.KpaCategory.ExcessStockStock.PRsAgingRel];
            Globals.CurrCategory = Title;
            Globals.CurrSection = Values.Sections.kpaSections[(int)Values.Sections.KpaSection.ExcessStock_Stock];
            ChangeCategory();

            TimeBucketOne = overallData.kpa.excessStockStock.prsAgingRel.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpa.excessStockStock.prsAgingRel.data.One_Three.ToString();
            TimeBucketThree = overallData.kpa.excessStockStock.prsAgingRel.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpa.excessStockStock.prsAgingRel.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpa.excessStockStock.prsAgingRel.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpa.excessStockStock.prsAgingRel.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpa.excessStockStock.prsAgingRel.data.TwentyNinePlus.ToString();

            Average = string.Format("{0:n}", overallData.kpa.excessStockStock.prsAgingRel.data.Average);
            TotalOrders = string.Format("{0:n0}", overallData.kpa.excessStockStock.prsAgingRel.data.Total);

            AnalysisOne = "- Will only show in this field if the PR is fully released, the PR open Qty > 0, General Stock On Hand > 0 and Project Stock On Hand > 0.";
            AnalysisTwo = "- Difference between todays date and the date the PR was fully released.";

            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);

            canvas.addData(dp);
            dataviz.Render(canvas);

            TimeBucketOne = string.Format("{0:n0}", overallData.kpa.excessStockStock.prsAgingRel.data.LessThanZero);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpa.excessStockStock.prsAgingRel.data.One_Three);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpa.excessStockStock.prsAgingRel.data.Four_Seven);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpa.excessStockStock.prsAgingRel.data.Eight_Fourteen);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpa.excessStockStock.prsAgingRel.data.Fifteen_TwentyOne);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpa.excessStockStock.prsAgingRel.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpa.excessStockStock.prsAgingRel.data.TwentyNinePlus);

        }




        /// <summary>
        /// Renders the specific KPA category into the loaded template
        /// </summary>
        private void RenderPoConfThruDeliv()
        {
            canvas = new Bunifu.DataViz.Canvas();
            dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_column);
            Title = Values.Categories.kpaCategories[(int)Values.Sections.KpaSection.ExcessStock_Stock][(int)Values.Categories.KpaCategory.ExcessStockStock.POCreationThruDelivery];
            Globals.CurrCategory = Title;
            Globals.CurrSection = Values.Sections.kpaSections[(int)Values.Sections.KpaSection.ExcessStock_Stock];
            ChangeCategory();

            TimeBucketOne = overallData.kpa.excessStockStock.PoCreationThruDeliv.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpa.excessStockStock.PoCreationThruDeliv.data.One_Three.ToString();
            TimeBucketThree = overallData.kpa.excessStockStock.PoCreationThruDeliv.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpa.excessStockStock.PoCreationThruDeliv.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpa.excessStockStock.PoCreationThruDeliv.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpa.excessStockStock.PoCreationThruDeliv.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpa.excessStockStock.PoCreationThruDeliv.data.TwentyNinePlus.ToString();

            Average = string.Format("{0:n}", overallData.kpa.excessStockStock.PoCreationThruDeliv.data.Average);
            TotalOrders = string.Format("{0:n0}", overallData.kpa.excessStockStock.PoCreationThruDeliv.data.Total);

            AnalysisOne = "- Will only show in this field if PR is on PO, PO line item does not have a confirmation date, PO line is not received complete, General Stock On Hand > 0 and Project Stock On Hand > 0.";
            AnalysisTwo = "- Difference between todays date and the date the PR was added to the PO.";

            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);

            canvas.addData(dp);
            dataviz.Render(canvas);

            TimeBucketOne = string.Format("{0:n0}", overallData.kpa.excessStockStock.PoCreationThruDeliv.data.LessThanZero);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpa.excessStockStock.PoCreationThruDeliv.data.One_Three);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpa.excessStockStock.PoCreationThruDeliv.data.Four_Seven);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpa.excessStockStock.PoCreationThruDeliv.data.Eight_Fourteen);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpa.excessStockStock.PoCreationThruDeliv.data.Fifteen_TwentyOne);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpa.excessStockStock.PoCreationThruDeliv.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpa.excessStockStock.PoCreationThruDeliv.data.TwentyNinePlus);
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
        private void btn_viewData_Click(object sender, EventArgs e)
        {
            try
            {
                using (DataViewer dv = new DataViewer())
                {
                    Bunifu.Framework.UI.BunifuFlatButton btn = (Bunifu.Framework.UI.BunifuFlatButton)sender;
                    int tag = int.Parse(btn.Tag.ToString());

                    switch (ActiveCategory)
                    {
                        case 0: // PRs Aging (Not Released)
                            dv.DataLoader += KpaDataTableLoader.ExcessStock_Stock.LoadPrsAgingNotReleased;
                            break;
                        case 1: // PRs Aging (Released)
                            dv.DataLoader += KpaDataTableLoader.ExcessStock_Stock.LoadPrsAgingReleased;
                            break;
                        case 2: // Po Creation Date to Confirmation Entry
                            dv.DataLoader += KpaDataTableLoader.ExcessStock_Stock.LoadPoConfThruDeliv;
                            break;
                        default:
                            break;
                    }
                    dv.ColumnTag = tag;
                    dv.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Excess Stock - Stock Data Viewer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
