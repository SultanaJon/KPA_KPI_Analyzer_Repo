using KPA_KPI_Analyzer.Values;
using System;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI
    {
        #region FIELD DATA

        /// <summary>
        /// The section button that is currently active.
        /// </summary>
        Button activeSectionBtn = new Button();

        #endregion


        #region EVENTS

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

            RemoveActivePanelControls();
            SetActiveSectionBtnToDefault();
            SetActiveSectionBtn(btn);

            int actSecTag = int.Parse(btn.Tag.ToString());

            if (actSecTag >= 0 && actSecTag <= 9)
                lbl_Performance.Text = "KPA";
            else
                lbl_Performance.Text = "KPI";


            switch (actSecTag)
            {
                case 0: // KPA --> Overall
                    LoadOverallTemplate(Values.Performances.Performance.KPA);
                    break;
                case 1: // KPA --> Plan
                    CreateKpaPlanTemplate();
                    break;
                case 2: // KPA --> Purch
                    CreateKpaPurchTemplate();
                    break;
                case 3: // KPA --> Purch Sub
                    CreateKpaPurchSubTemplate();
                    break;
                case 4: // KPA --> Purch Total
                    CreateKpaPurchTotalTemplate();
                    break;
                case 5: // KPA --> Follow Up
                    CreatekpaFollowUpTemplate();
                    break;
                case 6: // KPA --> Hot Jobs
                    CreateKpaHotJobsTemplate();
                    break;
                case 7: // KPA --> Excess Stock - Stock
                    CreateKpaExcessStockStockTemplate();
                    break;
                case 8: // KPA --> Excess Stock - Open Orders
                    CreateKpaExcessStockOpenOrdersTemplate();
                    break;
                case 9: // KPA --> Current Plan vs Actual
                    CreateKpaCurrPlanActualTemplate();
                    break;
                case 10: // KPI --> Overall
                    LoadOverallTemplate(Values.Performances.Performance.KPI);
                    break;
                case 11: // KPI --> Plan
                    CreateKpiPlanTemplate();
                    break;
                case 12: // KPI --> Purch
                    CreateKpiPurchTemplate();
                    break;
                case 13: // KPI --> Follow Up
                    CreateKpiFollowUpTemplate();
                    break;
                case 14: // KPI --> Plan
                    CreateKpiPlanTwoTemplate();
                    break;
                case 15: // KPI --> Purch
                    CreateKpiPurchTwoTemplate();
                    break;
                case 16: // KPI --> Purch Sub
                    CreateKpiPurchSubTemplate();
                    break;
                case 17: // KPI --> Purch Total
                    CreateKpiPurchTotalTemplate();
                    break;
                case 18: // KPI --> Purch/Plan
                    CreateKpiPurchPlanTemplate();
                    break;
                case 19: // KPI --> Other
                    CreateKpiOtherTemplate();
                    break;
                default:
                    break;
            }
        }

        #endregion


        #region HELPER FUNCTIONS

        /// <summary>
        /// Set the current active section button back to its default state.
        /// </summary>
        private void SetActiveSectionBtnToDefault()
        {
            activeSectionBtn.BackColor = System.Drawing.Color.FromArgb(36, 41, 46);
            activeSectionBtn.ForeColor = System.Drawing.Color.FromArgb(103, 110, 117);
        }



        /// <summary>
        /// Set the supplied button argument as the active section button
        /// </summary>
        /// <param name="btn">The button to make active</param>
        private void SetActiveSectionBtn(Button btn)
        {
            activeSectionBtn = btn;
            activeSectionBtn.BackColor = System.Drawing.Color.FromArgb(101, 198, 187);
            activeSectionBtn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
        }



        /// <summary>
        /// This function will load the default page of either the KPA or KPI section. This will only activate if the user was on a
        /// different page (either dashboard, Charts or Filters)
        /// </summary>
        /// <param name="tag">The tag of either the KPA or KPI button</param>
        private void loadDefaultSectionState(int tag)
        {
            if (tag == 1) // Load the default KPA Overall section state
            {
                activeSectionBtn = btn_kpaOverall;
            }
            else // load the default KPI section state
            {
                activeSectionBtn = btn_kpiOverall;
            }
        }



        /// <summary>
        /// This function is used as a callback function for when the template controls are loaded and cateogries within 
        /// the templates are clicked, the label showing the current category is updated.
        /// </summary>
        private void UpdateCategoryStatus()
        {
            lbl_Category.Text = Globals.CurrCategory;
        }

        #endregion
    }
}
