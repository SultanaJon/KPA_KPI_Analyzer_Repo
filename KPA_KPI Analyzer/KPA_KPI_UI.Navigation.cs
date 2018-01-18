using System;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI
    {
        #region FIELD DATA

        /// <summary>
        /// The active main navigation buttons
        /// </summary>
        Bunifu.Framework.UI.BunifuFlatButton mainNavActiveBtn = new Bunifu.Framework.UI.BunifuFlatButton();


        /// <summary>
        /// The active panel if if KPA or KPI main navigation buttons are active.
        /// </summary>
        Panel mainNavActivePanel = new Panel() { Visible = false };


        /// <summary>
        /// Boolean value indicating whether or not the navigation is locked from the user.
        /// </summary>
        bool NavigationLocked = false;


        /// <summary>
        /// Boolean value indicating whether or no the main navigation is in front.
        /// </summary>
        bool MenuInFront = false;

        #endregion


        #region EVENTS

        /// <summary>
        /// Triggered when the user clicks the navigation expander button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_NavExpander_Click(object sender, EventArgs e)
        {
            if (MenuInFront)
            {
                MenuInFront = false;
                pnl_NavigationPanelMax.SendToBack();
            }
            else
            {
                MenuInFront = true;
                pnl_NavigationPanelMax.BringToFront();
            }
        }


        /// <summary>
        /// This event will trigger when the user clicks on any of the main navigation buttons.S
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainNavButton_Click(object sender, EventArgs e)
        {
            int tag = 0;
            if (NavigationLocked)
                return;

            mainNavActiveBtn = (Bunifu.Framework.UI.BunifuFlatButton)sender;
            tag = int.Parse(mainNavActiveBtn.Tag.ToString());



            RemoveActivePanelControls();


            // Load the pages that correspond to the clicked button
            switch (tag)
            {
                case 0: // Dashboard btn clicked
                    // update the top handle bar model
                    topHandleBarModel.Update("N/A", "N/A", "N/A"); toggleMainNavSection(tag);
                    ShowPage(Pages.Dashboard);
                    break;
                case 1: // KPA btn clicked
                    toggleMainNavSection(tag);
                    SetActiveSectionBtnToDefault();
                    LoadOverallTemplate(Values.Performances.Performance.KPA);
                    break;
                case 2: // KPI btn clicked
                    toggleMainNavSection(tag);
                    SetActiveSectionBtnToDefault();
                    LoadOverallTemplate(Values.Performances.Performance.KPI);
                    break;
                case 3: // Charts btn clicked
                    toggleMainNavSection(tag);
                    break;
                case 4: // Filters btn clicked
                    // Set the model indicating that there is currently no KPA or KPI being viewed.
                    topHandleBarModel.Update("N/A", "N/A", "N/A"); toggleMainNavSection(tag);
                    toggleMainNavSection(tag);
                    ShowPage(Pages.Filters);
                    break;
                case 5:
                    CreateCorrelationWindow();
                    break;
                case 6:
                    CreateReportPage();
                    break;
                default:
                    break;
            }
        }

        #endregion


        #region HELPER FUNCTIONS

        /// <summary>
        /// This function will toggle the main navigation sections when either KPA or KPI buttons are clicked.
        /// </summary>
        /// <param name="tag">The tag of the main navigation button that was clicked.</param>
        private void toggleMainNavSection(int tag)
        {
            switch (tag)
            {
                case 1:
                    if (pnl_KPISectionsPanel.Visible)
                    {
                        pnl_KPISectionsPanel.Visible = false;
                    }

                    if (!pnl_KPASectionsPanel.Visible)
                    {
                        pnl_KPASectionsPanel.Visible = true;
                        mainNavActivePanel = pnl_KPASectionsPanel;
                    }
                    else
                    {
                        pnl_KPASectionsPanel.Visible = false;
                    }
                    break;
                case 2:
                    if (pnl_KPASectionsPanel.Visible)
                    {
                        pnl_KPASectionsPanel.Visible = false;
                    }

                    if (!pnl_KPISectionsPanel.Visible)
                    {
                        pnl_KPISectionsPanel.Visible = true;
                        mainNavActivePanel = pnl_KPISectionsPanel;
                    }
                    else
                    {
                        pnl_KPISectionsPanel.Visible = false;
                    }
                    mainNavActivePanel = pnl_KPISectionsPanel;
                    break;
                default:
                    pnl_KPASectionsPanel.Visible = false;
                    pnl_KPISectionsPanel.Visible = false;
                    break;
            }
        }

        #endregion
    }
}