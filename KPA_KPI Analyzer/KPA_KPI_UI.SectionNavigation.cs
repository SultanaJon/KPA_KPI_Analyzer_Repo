﻿using System;
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
            RemoveActivePanelControls();

            int actSecTag = int.Parse(btn.Tag.ToString());

            if (actSecTag >= 0 && actSecTag <= 14)
                lbl_Performance.Text = "KPA";
            else
                lbl_Performance.Text = "KPI";


            switch (actSecTag)
            {
                case 0: // KPA --> Overall
                    LoadOverallTemplate();
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
                case 5: // KPA --> Purch/Plan Total
                    LoadDataComingSoonTemplate();
                    break;
                case 6: // KPA --> Follow Up
                    CreatekpaFollowUpTemplate();
                    break;
                case 7: // KPA --> Cancellations
                    LoadDataComingSoonTemplate();
                    break;
                case 8: // KPA --> NCRs
                    LoadDataComingSoonTemplate();
                    break;
                case 9: // KPA --> Hot Jobs
                    CreateKpaHotJobsTemplate();
                    break;
                case 10: // KPA --> Excess Stock - Stock
                    LoadDataComingSoonTemplate();
                    break;
                case 11: // KPA --> Excess Stock - Open Orders
                    LoadDataComingSoonTemplate();
                    break;
                case 12: // KPA --> Current Plan vs Actual
                    CreateKpaCurrPlanActualTemplate();
                    break;
                case 13: // KPA --> MTC
                    LoadDataComingSoonTemplate();
                    break;
                case 14: // KPI --> Overall
                    LoadOverallTemplate();
                    break;
                case 15: // KPI --> Plan
                    CreateKpiPlanTemplate();
                    break;
                case 16: // KPI --> Purch
                    CreateKpiPurchTemplate();
                    break;
                case 17: // KPI --> Follow Up
                    CreateKpiFollowUpTemplate();
                    break;
                case 18: // KPI --> Plan
                    LoadDataComingSoonTemplate();
                    break;
                case 19: // KPI --> Purch
                    CreateKpiPurchTwoTemplate();
                    break;
                case 20: // KPI --> Purch Sub
                    CreateKpiPurchSubTemplate();
                    break;
                case 21: // KPI --> Purch Total
                    CreateKpiPurchTotalTemplate();
                    break;
                case 22: // KPI --> Purch/Plan
                    CreateKpiPurchPlanTemplate();
                    break;
                case 23: // KPI --> Purch/Plan Total
                    LoadDataComingSoonTemplate();
                    break;
                case 24: // KPI --> Other
                    CreateKpiOtherTemplate();
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
