﻿using KPA_KPI_Analyzer.KPA_KPI_Overall;
using KPA_KPI_Analyzer.Values;
using System;
using System.Drawing;
using System.Windows.Forms;
using KPA_KPI_Analyzer.DataLoading.KPA_Data.DataTableLoader;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPA_Controls
{
    public partial class KPAFollowUpTemplate : UserControl
    {
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
            Globals.CurrCategory = "Confirmed vs Plan Date";
            ChangeCategory();
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
            Globals.CurrCategory = Title;
            ChangeCategory();
            TimeBucketOne = overallData.kpa.followUp.confDateVsPlanDate.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpa.followUp.confDateVsPlanDate.data.One_Three.ToString();
            TimeBucketThree = overallData.kpa.followUp.confDateVsPlanDate.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpa.followUp.confDateVsPlanDate.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpa.followUp.confDateVsPlanDate.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpa.followUp.confDateVsPlanDate.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpa.followUp.confDateVsPlanDate.data.TwentyNinePlus.ToString();



            TotalOrders = string.Format("{0:n0}", overallData.kpa.followUp.confDateVsPlanDate.data.Total);
            Average = string.Format("{0:n}", overallData.kpa.followUp.confDateVsPlanDate.data.Average);


            AnalysisOne = "- Will only show for PO line items with confimration date and have not been received complete.";
            AnalysisTwo = "- Difference between current confirmed date and current plan date.";


            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);


            TimeBucketOne = string.Format("{0:n0}", overallData.kpa.followUp.confDateVsPlanDate.data.LessThanZero);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpa.followUp.confDateVsPlanDate.data.One_Three);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpa.followUp.confDateVsPlanDate.data.Four_Seven);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpa.followUp.confDateVsPlanDate.data.Eight_Fourteen);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpa.followUp.confDateVsPlanDate.data.Fifteen_TwentyOne);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpa.followUp.confDateVsPlanDate.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpa.followUp.confDateVsPlanDate.data.TwentyNinePlus);


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
            Globals.CurrCategory = Title;
            ChangeCategory();

            TimeBucketOne = overallData.kpa.followUp.ConfDateForUpcomingDel.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpa.followUp.ConfDateForUpcomingDel.data.One_Three.ToString();
            TimeBucketThree = overallData.kpa.followUp.ConfDateForUpcomingDel.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpa.followUp.ConfDateForUpcomingDel.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpa.followUp.ConfDateForUpcomingDel.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpa.followUp.ConfDateForUpcomingDel.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpa.followUp.ConfDateForUpcomingDel.data.TwentyNinePlus.ToString();

            TotalOrders = string.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.Total);
            Average = string.Format("{0:n}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.Average);


            AnalysisOne = "- Will only show for PO line items with a confirmation date and have not been received complete.";
            AnalysisTwo = "- Difference between the confirmation date and todays date.";

            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);


            TimeBucketOne = string.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.LessThanZero);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.One_Three);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.Four_Seven);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.Eight_Fourteen);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.Fifteen_TwentyOne);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpa.followUp.ConfDateForUpcomingDel.data.TwentyNinePlus);


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
            Title = "Due Today or Late to Confirmed Date";
            Globals.CurrCategory = Title;
            ChangeCategory();

            TimeBucketOne = overallData.kpa.followUp.LateToConfDate.data.LessThanZero.ToString();
            TimeBucketTwo = overallData.kpa.followUp.LateToConfDate.data.One_Three.ToString();
            TimeBucketThree = overallData.kpa.followUp.LateToConfDate.data.Four_Seven.ToString();
            TimeBucketFour = overallData.kpa.followUp.LateToConfDate.data.Eight_Fourteen.ToString();
            TimeBucketFive = overallData.kpa.followUp.LateToConfDate.data.Fifteen_TwentyOne.ToString();
            TimeBucketSix = overallData.kpa.followUp.LateToConfDate.data.TwentyTwo_TwentyEight.ToString();
            TimeBucketSeven = overallData.kpa.followUp.LateToConfDate.data.TwentyNinePlus.ToString();


            TotalOrders = string.Format("{0:n0}", overallData.kpa.followUp.LateToConfDate.data.Total);
            Average = string.Format("{0:n}", overallData.kpa.followUp.LateToConfDate.data.Average);


            AnalysisOne = "- Open PO line which is confirmed for today or in the past.";
            AnalysisTwo = "- Difference between todays date and the current confirmation date.";

            dp.addLabely(lbl_xLabelOne.Text, TimeBucketOne);
            dp.addLabely(lbl_xLabelTwo.Text, TimeBucketTwo);
            dp.addLabely(lbl_xLabelThree.Text, TimeBucketThree);
            dp.addLabely(lbl_xLabelFour.Text, TimeBucketFour);
            dp.addLabely(lbl_xLabelFive.Text, TimeBucketFive);
            dp.addLabely(lbl_xLabelSix.Text, TimeBucketSix);
            dp.addLabely(lbl_xLabelSeven.Text, TimeBucketSeven);

            TimeBucketOne = string.Format("{0:n0}", overallData.kpa.followUp.LateToConfDate.data.LessThanZero);
            TimeBucketTwo = string.Format("{0:n0}", overallData.kpa.followUp.LateToConfDate.data.One_Three);
            TimeBucketThree = string.Format("{0:n0}", overallData.kpa.followUp.LateToConfDate.data.Four_Seven);
            TimeBucketFour = string.Format("{0:n0}", overallData.kpa.followUp.LateToConfDate.data.Eight_Fourteen);
            TimeBucketFive = string.Format("{0:n0}", overallData.kpa.followUp.LateToConfDate.data.Fifteen_TwentyOne);
            TimeBucketSix = string.Format("{0:n0}", overallData.kpa.followUp.LateToConfDate.data.TwentyTwo_TwentyEight);
            TimeBucketSeven = string.Format("{0:n0}", overallData.kpa.followUp.LateToConfDate.data.TwentyNinePlus);

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
                    case 0: // Confirmed Vs Plan Date
                        KpaDataTableLoader.FollowUp.LoadConfirmedVsPlanDateDataTable(tag);
                        break;
                    case 1: // Confirmed Date for Upcoming Deliveries
                        KpaDataTableLoader.FollowUp.LoadConfirmedDateForUpcomingDeliveriesDataTable(tag);
                        break;
                    case 2: // PO Creation to Confirmation Entry
                        KpaDataTableLoader.FollowUp.LoadPOCreationToConfirmationEntryDataTable(tag);
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
