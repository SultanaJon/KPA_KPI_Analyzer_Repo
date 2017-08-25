using System;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI
    {
        Button activeSectionBtn = new Button();
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();


        /// <summary>
        /// When the user hovers over a button, change the forecolor to coral.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainNavSection_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(activeSectionBtn != btn)
                btn.ForeColor = System.Drawing.Color.LightSalmon;
        }







        /// <summary>
        /// Change the forecolor back to normal after the user performed a hover leave.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MainNavSection_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(activeSectionBtn != btn)
                btn.ForeColor = System.Drawing.Color.White;
        }







        /// <summary>
        /// This event will trigger when the user clicks on any sections contained within either
        /// KPA or KPI. The only section buttons that will load pages are the Overall sections
        /// of both KPA and KPI.
        /// </summary>
        /// <param name="sender">The section button</param>
        /// <param name="e">The click event</param>
        public void sectionBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            activateSectionBtn(btn);

            int actSecTag = int.Parse(btn.Tag.ToString());
            int mainActTag = int.Parse(mainNavActiveBtn.Tag.ToString());

            switch (actSecTag)
            {
                case 0: // KPA --> Overall
                    LoadOverallTemplate();
                    break;
                case 1: // KPA --> Plan
                    pnl_activePage.Controls.Clear();
                    pnl_activePage.BringToFront();
                    KPAPlanTemplate kpaPlanTemp = new KPAPlanTemplate();
                    kpaPlanTemp.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpaPlanTemp);
                    break;
                case 2: // KPA --> Purch
                    pnl_activePage.Controls.Clear();
                    pnl_activePage.BringToFront();
                    KPAPurchTemplate kpaPurchTemp = new KPAPurchTemplate();
                    kpaPurchTemp.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpaPurchTemp);
                    break;
                case 3: // KPA --> Purch Sub
                    pnl_activePage.Controls.Clear();
                    pnl_activePage.BringToFront();
                    KPAPurchSubTemplate kpaPurchSubTemp = new KPAPurchSubTemplate();
                    kpaPurchSubTemp.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpaPurchSubTemp);
                    break;
                case 4: // KPA --> Purch Total
                    pnl_activePage.Controls.Clear();
                    pnl_activePage.BringToFront();
                    KPAPurchTotalTemplate kpaPurchTotalTemp = new KPAPurchTotalTemplate();
                    kpaPurchTotalTemp.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpaPurchTotalTemp);
                    break;
                case 5: // KPA --> Purch/Plan Total
                    LoadDataComingSoonTemplate();
                    break;
                case 6: // KPA --> Follow Up
                    pnl_activePage.Controls.Clear();
                    pnl_activePage.BringToFront();
                    KPAFollowUpTemplate kpaFollowUpTemp = new KPAFollowUpTemplate();
                    kpaFollowUpTemp.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpaFollowUpTemp);
                    break;
                case 7: // KPA --> Cancellations
                    LoadDataComingSoonTemplate();
                    break;
                case 8: // KPA --> NCRs
                    LoadDataComingSoonTemplate();
                    break;
                case 9: // KPA --> Hot Jobs
                    pnl_activePage.Controls.Clear();
                    pnl_activePage.BringToFront();
                    KPAHotJobsTemplate kpaHotJobs = new KPAHotJobsTemplate();
                    kpaHotJobs.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpaHotJobs);
                    break;
                case 10: // KPA --> Excess Stock - Stock
                    LoadDataComingSoonTemplate();
                    break;
                case 11: // KPA --> Excess Stock - Open Orders
                    LoadDataComingSoonTemplate();
                    break;
                case 12: // KPA --> Current Plan vs Actual
                    pnl_activePage.Controls.Clear();
                    pnl_activePage.BringToFront();
                    KPACurrentPlanActualTemplate kpaCurrPlanActual = new KPACurrentPlanActualTemplate();
                    kpaCurrPlanActual.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpaCurrPlanActual);
                    break;
                case 13: // KPA --> MTC
                    LoadDataComingSoonTemplate();
                    break;
                case 14: // KPI --> Overall
                    LoadOverallTemplate();
                    break;
                case 15: // KPI --> Plan
                    pnl_activePage.Controls.Clear();
                    pnl_activePage.BringToFront();
                    KPIPlanTemplate kpiPlanTemplate = new KPIPlanTemplate();
                    kpiPlanTemplate.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpiPlanTemplate);
                    break;
                case 16: // KPI --> Purch
                    pnl_activePage.Controls.Clear();
                    pnl_activePage.BringToFront();
                    KPIPurchTemplate kpiPurchTemplate = new KPIPurchTemplate();
                    kpiPurchTemplate.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpiPurchTemplate);
                    break;
                case 17: // KPI --> Follow Up
                    pnl_activePage.Controls.Clear();
                    pnl_activePage.BringToFront();
                    KPIFollowUpTemplate kpiFollowUpTemplate = new KPIFollowUpTemplate();
                    kpiFollowUpTemplate.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpiFollowUpTemplate);
                    break;
                case 18: // KPI --> Plan
                    LoadDataComingSoonTemplate();
                    break;
                case 19: // KPI --> Purch
                    pnl_activePage.Controls.Clear();
                    pnl_activePage.BringToFront();
                    KPIPurchTwoTemplate kpiPurchTwoTemplate = new KPIPurchTwoTemplate();
                    kpiPurchTwoTemplate.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpiPurchTwoTemplate);
                    break;
                case 20: // KPI --> Purch Sub
                    pnl_activePage.Controls.Clear();
                    pnl_activePage.BringToFront();
                    KPIPurchSubTemplate kpiPurchSubTemplate = new KPIPurchSubTemplate();
                    kpiPurchSubTemplate.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpiPurchSubTemplate);
                    break;
                case 21: // KPI --> Purch Total
                    pnl_activePage.Controls.Clear();
                    pnl_activePage.BringToFront();
                    KPIPurchTotalTemplate kpiPurchTotalTemplate = new KPIPurchTotalTemplate();
                    kpiPurchTotalTemplate.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpiPurchTotalTemplate);
                    break;
                case 22: // KPI --> Purch/Plan
                    pnl_activePage.Controls.Clear();
                    pnl_activePage.BringToFront();
                    KPIPurchPlanTemplate kpiPurchPlanTemplate = new KPIPurchPlanTemplate();
                    kpiPurchPlanTemplate.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpiPurchPlanTemplate);
                    break;
                case 23: // KPI --> Purch/Plan Total
                    LoadDataComingSoonTemplate();
                    break;
                case 24: // KPI --> Other
                    pnl_activePage.Controls.Clear();
                    pnl_activePage.BringToFront();
                    KPIOtherTemplate kpiOtherTemplate = new KPIOtherTemplate();
                    kpiOtherTemplate.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpiOtherTemplate);
                    break;
                default:
                    break;
            }
        }







        /// <summary>
        /// This function will activate the new section active button and set back the current active button to defaul.
        /// </summary>
        /// <param name="btn">The button that will be the new active button</param>
        public void activateSectionBtn(Button btn)
        {
            int tag = int.Parse(btn.Tag.ToString());
            setCurrentActiveSectionBtnToDefault();
            btn.ForeColor = System.Drawing.Color.Coral;
            activeSectionBtn = btn;
        }







        /// <summary>
        /// This function will set the current active section button back to its default state.
        /// </summary>
        public void setCurrentActiveSectionBtnToDefault()
        {
            activeSectionBtn.ForeColor = System.Drawing.Color.White;
        }







        /// <summary>
        /// This function will load the default page of either the KPA or KPI section. This will only activate if the user was on a
        /// different page (either dashboard, Charts or Filters)
        /// </summary>
        /// <param name="tag">The tag of either the KPA or KPI button</param>
        public void loadDefaultSectionState(int tag)
        {
            setCurrentActiveSectionBtnToDefault();
            if(tag == 1) // Load the default KPA Overall section state
            {
                activeSectionBtn = btn_kpaOverall;
                activeSectionBtn.ForeColor = System.Drawing.Color.Coral;
            }
            else // load the default KPI section state
            {
                activeSectionBtn = btn_kpiOverall;
                activeSectionBtn.ForeColor = System.Drawing.Color.Coral;
            }
        }
    }
}
