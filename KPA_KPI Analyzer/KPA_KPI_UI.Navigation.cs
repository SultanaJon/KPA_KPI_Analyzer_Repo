using System;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI
    {
        Bunifu.Framework.UI.BunifuImageButton mainNavActiveBtn = new Bunifu.Framework.UI.BunifuImageButton();
        Panel mainNavActivePanel = new Panel() { Visible = false };
        bool NavigationLocked = false;
        bool MenuInFront = false;


        /// <summary>
        /// This event will trigger when the user hovers over one of the main navigation buttons
        /// </summary>
        /// <param name="sender">The button being hovered over</param>
        /// <param name="e">The hovered event</param>
        private void MainNavBtn_MouseEnter(object sender, EventArgs e)
        {

        }







        /// <summary>
        /// This event will trigger when the user hovers off the face of the button
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">The mouse leave event</param>
        private void MainNavBtn_MouseLeave(object sender, EventArgs e)
        {

        }







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
                if(mainNavActivePanel.Visible)
                {
                    mainNavActivePanel.Visible = false;
                    if (int.Parse(mainNavActiveBtn.Tag.ToString()) == 1) ;
                    else ;
                }
            }
            else
            {
                MenuInFront = true;
                pnl_NavigationPanelMax.BringToFront();
                pnl_NavigationPanelMax.Width = Constants.maxNavWidth;
            }
        }







        /// <summary>
        /// This event will trigger when the user clicks on any of the main navigation buttons.S
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainNavButton_Click(object sender, EventArgs e)
        {
            bool toggleDefaultSection = true;

            if (NavigationLocked)
                return;

            Bunifu.Framework.UI.BunifuImageButton btn = sender as Bunifu.Framework.UI.BunifuImageButton;
            int tag = int.Parse(btn.Tag.ToString());


            if (mainNavActiveBtn != btn) // activate the button unless already activated
                activateButton(sender);
            else
                toggleDefaultSection = false;


            // Load the pages that correspond to the clicked button
            switch (int.Parse(btn.Tag.ToString()))
            {
                case 0: // Dashboard btn clicked
                    RemoveActivePanelControls();
                    lbl_Performance.Text = "Not Selected";
                    lbl_Section.Text = "Not Selected";
                    lbl_Category.Text = "Not Selected";
                    toggleMainNavSection();
                    tblpnl_DashbaordPage.BringToFront();
                    break;
                case 1: // KPA btn clicked
                    RemoveActivePanelControls();

                    if (pnl_NavigationPanelMax.Width == Constants.minNavWidth)
                        pnl_NavigationPanelMax.Width = Constants.maxNavWidth;

                    toggleMainNavSection();

                    if(toggleDefaultSection)
                    {
                        LoadOverallTemplate();
                    }
                    break;
                case 2: // KPI btn clicked
                    RemoveActivePanelControls();

                    if (pnl_NavigationPanelMax.Width == Constants.minNavWidth)
                        pnl_NavigationPanelMax.Width = Constants.maxNavWidth;

                    toggleMainNavSection();

                    if (toggleDefaultSection)
                    {
                        LoadOverallTemplate();
                    }
                    break;
                case 3: // Charts btn clicked
                    toggleMainNavSection();
                    break;
                case 4: // Filters btn clicked
                    RemoveActivePanelControls();
                    lbl_Performance.Text = "Not Selected";
                    lbl_Section.Text = "Not Selected";
                    lbl_Category.Text = "Not Selected";
                    toggleMainNavSection();
                    tblpnl_Filters.BringToFront();
                    break;
                default:
                    break;
            }
        }







        /// <summary>
        /// This function will toggle the main navigation sections when either KPA or KPI buttons are clicked.
        /// </summary>
        private void toggleMainNavSection()
        {
            switch (int.Parse(mainNavActiveBtn.Tag as string))
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







        /// <summary>
        /// This function will activeate the new active button and deactivate the current active button
        /// </summary>
        /// <param name="sender"></param>
        private void activateButton(object sender)
        {
            int mainActTag = int.Parse(mainNavActiveBtn.Tag.ToString());

            // set the active button back to default state.
            setCurrActiveButtonToDefault();

            // get the object being acted upon.
            Bunifu.Framework.UI.BunifuImageButton btn = sender as Bunifu.Framework.UI.BunifuImageButton;
            int tag = int.Parse(btn.Tag.ToString());

            switch (tag)
            {
                case 0:
                    // Only load the default state if the main nav active button is not KPA or KPI
                    if (mainActTag != 1 || mainActTag != 2)
                        loadDefaultSectionState(tag);
                    break;
                case 1: // 1 & 2 are navigation buttons with sub menu
                    // Only load the default state if the main nav active button is not KPA or KPI
                    if (mainActTag != 1 || mainActTag != 2)
                        loadDefaultSectionState(tag);
                    break;
                case 2:
                    // Only load the default state if the main nav active button is not KPA or KPI
                    if(mainActTag != 1 || mainActTag != 2)
                        loadDefaultSectionState(tag);
                    break;
                case 3:
                    // Only load the default state if the main nav active button is not KPA or KPI
                    if (mainActTag != 1 || mainActTag != 2)
                        loadDefaultSectionState(tag);
                    break;
                case 4:
                    // Only load the default state if the main nav active button is not KPA or KPI
                    if (mainActTag != 1 || mainActTag != 2)
                        loadDefaultSectionState(tag);
                    break;
                default: break;
            }


            // Make the active button as clicked button
            mainNavActiveBtn = btn;
        }







        /// <summary>
        /// This function will set the current active button back to its default state.
        /// </summary>
        private void setCurrActiveButtonToDefault()
        {
            switch (int.Parse(mainNavActiveBtn.Tag as string))
            {
                case 0:
                    // update the icon image of the current active button
                    break;
                case 1:

                    if (pnl_KPASectionsPanel.Height != Constants.zeroHeight)
                        pnl_KPASectionsPanel.Height = Constants.zeroHeight;

                    if (pnl_KPISectionsPanel.Height != Constants.zeroHeight)
                        pnl_KPISectionsPanel.Height = Constants.zeroHeight;
                    break;
                case 2:

                    if (pnl_KPASectionsPanel.Height != Constants.zeroHeight)
                        pnl_KPASectionsPanel.Height = Constants.zeroHeight;

                    if (pnl_KPISectionsPanel.Height != Constants.zeroHeight)
                        pnl_KPISectionsPanel.Height = Constants.zeroHeight;
                    break;
                case 3:
                    // update the icon image of the current active button
                    break;
                case 4:
                    // update the icon image of the current active button
                    break;
                default:
                    break;
            }
        }
    }
}
