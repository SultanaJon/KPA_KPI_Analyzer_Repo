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
            if (activeSectionBtn != btn)
                btn.ForeColor = System.Drawing.Color.LightSalmon;
        }







        /// <summary>
        /// Change the forecolor back to normal after the user performed a hover leave.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainNavSection_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (activeSectionBtn != btn)
                btn.ForeColor = System.Drawing.Color.White;
        }







        /// <summary>
        /// This event will trigger when the user clicks on any sections contained within either
        /// KPA or KPI. The only section buttons that will load pages are the Overall sections
        /// of both KPA and KPI.
        /// </summary>
        /// <param name="sender">The section button</param>
        /// <param name="e">The click event</param>
        private void sectionBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            activateSectionBtn(btn);

            int actSecTag = int.Parse(btn.Tag.ToString());
            int mainActTag = int.Parse(mainNavActiveBtn.Tag.ToString());


            if (actSecTag >= 0 && actSecTag <= 14)
                lbl_Performance.Text = "KPA";
            else
                lbl_Performance.Text = "KPI";

            switch (actSecTag)
            {
                case 0: // KPA --> Overall
                    lbl_Section.Text = "All";
                    lbl_Category.Text = "All";
                    LoadOverallTemplate();
                    break;
                case 1: // KPA --> Plan
                    lbl_Section.Text = "Plan";
                    KPAPlanTemplate kpaPlanTemp = new KPAPlanTemplate() { Name = "Plan" };
                    KPAPlanTemplate.ChangeCategory += UpdateCategoryStatus;
                    kpaPlanTemp.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpaPlanTemp);
                    kpaPlanTemp.BringToFront();
                    break;
                case 2: // KPA --> Purch
                    lbl_Section.Text = "Purch";
                    RemoveActivePanelControls();
                    KPAPurchTemplate kpaPurchTemp = new KPAPurchTemplate() { Name = "Purch" };
                    KPAPurchTemplate.ChangeCategory += UpdateCategoryStatus;
                    kpaPurchTemp.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpaPurchTemp);
                    kpaPurchTemp.BringToFront();
                    break;
                case 3: // KPA --> Purch Sub
                    lbl_Section.Text = "Purch Sub";
                    RemoveActivePanelControls();
                    KPAPurchSubTemplate kpaPurchSubTemp = new KPAPurchSubTemplate() { Name = "PurchSub" };
                    KPAPurchSubTemplate.ChangeCategory += UpdateCategoryStatus;
                    kpaPurchSubTemp.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpaPurchSubTemp);
                    kpaPurchSubTemp.BringToFront();
                    break;
                case 4: // KPA --> Purch Total
                    lbl_Section.Text = "Purch Total";
                    RemoveActivePanelControls();
                    KPAPurchTotalTemplate kpaPurchTotalTemp = new KPAPurchTotalTemplate() { Name = "PurchTotal" };
                    KPAPurchTotalTemplate.ChangeCategory += UpdateCategoryStatus;
                    kpaPurchTotalTemp.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpaPurchTotalTemp);
                    kpaPurchTotalTemp.BringToFront();
                    break;
                case 5: // KPA --> Purch/Plan Total
                    lbl_Section.Text = "N/A";
                    lbl_Category.Text = "N/A";
                    lbl_Section.Text = "Purch/Plan Total";
                    LoadDataComingSoonTemplate();
                    break;
                case 6: // KPA --> Follow Up
                    lbl_Section.Text = "Follow Up";
                    RemoveActivePanelControls();
                    KPAFollowUpTemplate kpaFollowUpTemp = new KPAFollowUpTemplate() { Name = "FollowUp" };
                    KPAFollowUpTemplate.ChangeCategory += UpdateCategoryStatus;
                    kpaFollowUpTemp.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpaFollowUpTemp);
                    kpaFollowUpTemp.BringToFront();
                    break;
                case 7: // KPA --> Cancellations
                    lbl_Section.Text = "N/A";
                    lbl_Category.Text = "N/A";
                    LoadDataComingSoonTemplate();
                    break;
                case 8: // KPA --> NCRs
                    lbl_Section.Text = "N/A";
                    lbl_Category.Text = "N/A";
                    LoadDataComingSoonTemplate();
                    break;
                case 9: // KPA --> Hot Jobs
                    lbl_Section.Text = "Hot Jobs";
                    RemoveActivePanelControls();
                    KPAHotJobsTemplate kpaHotJobs = new KPAHotJobsTemplate() { Name = "HotJobs" };
                    KPAHotJobsTemplate.ChangeCategory += UpdateCategoryStatus;
                    kpaHotJobs.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpaHotJobs);
                    kpaHotJobs.BringToFront();
                    break;
                case 10: // KPA --> Excess Stock - Stock
                    lbl_Section.Text = "N/A";
                    lbl_Category.Text = "N/A";
                    LoadDataComingSoonTemplate();
                    break;
                case 11: // KPA --> Excess Stock - Open Orders
                    lbl_Section.Text = "N/A";
                    lbl_Category.Text = "N/A";
                    LoadDataComingSoonTemplate();
                    break;
                case 12: // KPA --> Current Plan vs Actual
                    lbl_Section.Text = "Current Plan vs Actual";
                    RemoveActivePanelControls();
                    KPACurrentPlanActualTemplate kpaCurrPlanActual = new KPACurrentPlanActualTemplate() { Name = "CurrPlanActual" };
                    KPACurrentPlanActualTemplate.ChangeCategory += UpdateCategoryStatus;
                    kpaCurrPlanActual.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpaCurrPlanActual);
                    kpaCurrPlanActual.BringToFront();
                    break;
                case 13: // KPA --> MTC
                    lbl_Section.Text = "N/A";
                    lbl_Category.Text = "N/A";
                    LoadDataComingSoonTemplate();
                    break;
                case 14: // KPI --> Overall
                    lbl_Section.Text = "All";
                    lbl_Category.Text = "All";
                    LoadOverallTemplate();
                    break;
                case 15: // KPI --> Plan
                    lbl_Section.Text = "Plan";
                    RemoveActivePanelControls();
                    KPIPlanTemplate kpiPlanTemplate = new KPIPlanTemplate() { Name = "Plan" };
                    KPIPlanTemplate.ChangeCategory += UpdateCategoryStatus;
                    kpiPlanTemplate.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpiPlanTemplate);
                    kpiPlanTemplate.BringToFront();
                    break;
                case 16: // KPI --> Purch
                    lbl_Section.Text = "Purch";
                    RemoveActivePanelControls();
                    KPIPurchTemplate kpiPurchTemplate = new KPIPurchTemplate() { Name = "Purch" };
                    KPIPurchTemplate.ChangeCategory += UpdateCategoryStatus;
                    kpiPurchTemplate.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpiPurchTemplate);
                    kpiPurchTemplate.BringToFront();
                    break;
                case 17: // KPI --> Follow Up
                    lbl_Section.Text = "Follow Up";
                    RemoveActivePanelControls();
                    KPIFollowUpTemplate kpiFollowUpTemplate = new KPIFollowUpTemplate() { Name = "FollowUp" };
                    KPIFollowUpTemplate.ChangeCategory += UpdateCategoryStatus;
                    kpiFollowUpTemplate.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpiFollowUpTemplate);
                    kpiFollowUpTemplate.BringToFront();
                    break;
                case 18: // KPI --> Plan
                    lbl_Section.Text = "N/A";
                    lbl_Category.Text = "N/A";
                    LoadDataComingSoonTemplate();
                    break;
                case 19: // KPI --> Purch
                    lbl_Section.Text = "Purch";
                    RemoveActivePanelControls();
                    KPIPurchTwoTemplate kpiPurchTwoTemplate = new KPIPurchTwoTemplate() { Name = "Purch" };
                    KPIPurchTwoTemplate.ChangeCategory += UpdateCategoryStatus;
                    kpiPurchTwoTemplate.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpiPurchTwoTemplate);
                    kpiPurchTwoTemplate.BringToFront();
                    break;
                case 20: // KPI --> Purch Sub
                    lbl_Section.Text = "Purch Sub";
                    RemoveActivePanelControls();
                    KPIPurchSubTemplate kpiPurchSubTemplate = new KPIPurchSubTemplate() { Name = "PurchSub" };
                    KPIPurchSubTemplate.ChangeCategory += UpdateCategoryStatus;
                    kpiPurchSubTemplate.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpiPurchSubTemplate);
                    kpiPurchSubTemplate.BringToFront();
                    break;
                case 21: // KPI --> Purch Total
                    lbl_Section.Text = "Purch Total";
                    RemoveActivePanelControls();
                    KPIPurchTotalTemplate kpiPurchTotalTemplate = new KPIPurchTotalTemplate() { Name = "PurchTotal" };
                    KPIPurchTotalTemplate.ChangeCategory += UpdateCategoryStatus;
                    kpiPurchTotalTemplate.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpiPurchTotalTemplate);
                    kpiPurchTotalTemplate.BringToFront();
                    break;
                case 22: // KPI --> Purch/Plan
                    lbl_Section.Text = "Purch/Plan";
                    RemoveActivePanelControls();
                    KPIPurchPlanTemplate kpiPurchPlanTemplate = new KPIPurchPlanTemplate() { Name = "PurchPlan" };
                    KPIPurchPlanTemplate.ChangeCategory += UpdateCategoryStatus;
                    kpiPurchPlanTemplate.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpiPurchPlanTemplate);
                    kpiPurchPlanTemplate.BringToFront();
                    break;
                case 23: // KPI --> Purch/Plan Total
                    lbl_Section.Text = "N/A";
                    lbl_Category.Text = "N/A";
                    LoadDataComingSoonTemplate();
                    break;
                case 24: // KPI --> Other
                    lbl_Section.Text = "Other";
                    RemoveActivePanelControls();
                    KPIOtherTemplate kpiOtherTemplate = new KPIOtherTemplate() { Name = "Other" };
                    KPIOtherTemplate.ChangeCategory += UpdateCategoryStatus;
                    kpiOtherTemplate.Dock = DockStyle.Fill;
                    pnl_activePage.Controls.Add(kpiOtherTemplate);
                    kpiOtherTemplate.BringToFront();
                    break;
                default:
                    break;
            }
        }







        /// <summary>
        /// This function will activate the new section active button and set back the current active button to defaul.
        /// </summary>
        /// <param name="btn">The button that will be the new active button</param>
        private void activateSectionBtn(Button btn)
        {
            int tag = int.Parse(btn.Tag.ToString());
            setCurrentActiveSectionBtnToDefault();
            btn.ForeColor = System.Drawing.Color.Coral;
            activeSectionBtn = btn;
        }







        /// <summary>
        /// This function will set the current active section button back to its default state.
        /// </summary>
        private void setCurrentActiveSectionBtnToDefault()
        {
            activeSectionBtn.ForeColor = System.Drawing.Color.White;
        }







        /// <summary>
        /// This function will load the default page of either the KPA or KPI section. This will only activate if the user was on a
        /// different page (either dashboard, Charts or Filters)
        /// </summary>
        /// <param name="tag">The tag of either the KPA or KPI button</param>
        private void loadDefaultSectionState(int tag)
        {
            setCurrentActiveSectionBtnToDefault();
            if (tag == 1) // Load the default KPA Overall section state
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




        /// <summary>
        /// This function will remove any templates that are within the active page. To make the application
        /// faster we do not want the active page panel to be populated with many templates. The active page
        /// should only consist of the dashboard, one active template, the loading screen, the dashboard dragdrop
        /// when needed, and the filters page.
        /// </summary>
        private void RemoveActivePanelControls()
        {
            foreach (Control ctrl in pnl_activePage.Controls)
            {
                switch (ctrl.Name)
                {
                    case "Overall":
                    case "DataComingSoon":
                    case "Plan":
                    case "Purch":
                    case "PurchSub":
                    case "PurchTotal":
                    case "FollowUp":
                    case "HotJobs":
                    case "CurrPlanActual":
                    case "PurchPlan":
                    case "Other":
                        pnl_activePage.Controls.Remove(ctrl);
                        break;
                    default:
                        break;
                }
            }
        }



        /// <summary>
        /// This function is used as a callback function for when the template controls are loaded and cateogries within 
        /// the templates are clicked, the label showing the current category is updated.
        /// </summary>
        /// <param name="currentCategory"></param>
        private void UpdateCategoryStatus(string currentCategory)
        {
            lbl_Category.Text = currentCategory;
        }
    }
}
