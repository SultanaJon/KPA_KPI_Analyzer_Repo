using System;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI
    {
        Button mainNavActiveBtn = new Button();
        Panel mainNavActivePanel = new Panel() { Visible = false };
        bool NavigationLocked = false;


        /// <summary>
        /// This event will trigger when the user hovers over one of the main navigation buttons
        /// </summary>
        /// <param name="sender">The button being hovered over</param>
        /// <param name="e">The hovered event</param>
        private void MainNavBtn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button; // Get the object being hovered over.
            int tag = int.Parse(btn.Tag as string);

            if (mainNavActiveBtn != btn) // if the hovered button is the active button we do not want to bother changing the background image
            {
                switch(tag)
                {
                    case 0:
                        btn.BackgroundImage = Properties.Resources.DashboardBG_HoverActive;
                        break;
                    case 1:
                        btn.BackgroundImage = Properties.Resources.KPABG_Hover;
                        break;
                    case 2:
                        btn.BackgroundImage = Properties.Resources.KPIBG_Hover;
                        break;
                    case 3:
                        btn.BackgroundImage = Properties.Resources.ChartsBG_HoverActive;
                        break;
                    case 4:
                        btn.BackgroundImage = Properties.Resources.FilterBG_HoverActive;
                        break;
                }
            }
        }







        /// <summary>
        /// This event will trigger when the user hovers off the face of the button
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">The mouse leave event</param>
        private void MainNavBtn_MouseLeave(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            int tag = int.Parse((string)btn.Tag);

            if (mainNavActiveBtn != btn)
            {
                switch (tag)
                {
                    case 0:
                        btn.BackgroundImage = Properties.Resources.DashboardBG_Normal;
                        break;
                    case 1:
                        btn.BackgroundImage = Properties.Resources.KPABG_Normal;
                        break;
                    case 2:
                        btn.BackgroundImage = Properties.Resources.KPIBG_Normal;
                        break;
                    case 3:
                        btn.BackgroundImage = Properties.Resources.ChartsBG_Normal;
                        break;
                    case 4:
                        btn.BackgroundImage = Properties.Resources.FilterBG_Normal;
                        break;
                }
            }
        }







        /// <summary>
        /// Triggered when the user clicks the navigation expander button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_NavExpander_Click(object sender, EventArgs e)
        {
            if (pnl_NavigationPanelMax.Width == Constants.maxNavWidth)
            {
                pnl_NavigationPanelMax.Width = Constants.minNavWidth;
                if(mainNavActivePanel.Visible)
                {
                    mainNavActivePanel.Visible = false;
                    if (int.Parse(mainNavActiveBtn.Tag.ToString()) == 1)
                        mainNavActiveBtn.BackgroundImage = Properties.Resources.KPABG_Hover;
                    else
                        mainNavActiveBtn.BackgroundImage = Properties.Resources.KPIBG_Hover;
                }
            }
            else
            {
                pnl_NavigationPanelMax.Width = Constants.maxNavWidth;
            }
        }







        /// <summary>
        /// This event will trigger when the user clicks on any of the main navigation buttons.S
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void mainNavButton_Click(object sender, EventArgs e)
        {
            bool toggleDefaultSection = true;

            if (NavigationLocked)
                return;

            Button btn = sender as Button;
            int tag = int.Parse(btn.Tag.ToString());

            if (tag == 4)
                btn_NavExpander.Enabled = false;
            else
                btn_NavExpander.Enabled = true;

            if (mainNavActiveBtn != btn) // activate the button unless already activated
                activateButton(sender);
            else
                toggleDefaultSection = false;


            // Load the pages that correspond to the clicked button
            switch (int.Parse(btn.Tag.ToString()))
            {
                case 0: // Dashboard btn clicked
                    toggleMainNavSection();
                    tblpnl_DashbaordPage.BringToFront();
                    break;
                case 1: // KPA btn clicked
                    if (pnl_NavigationPanelMax.Width == Constants.minNavWidth)
                        pnl_NavigationPanelMax.Width = Constants.maxNavWidth;

                    toggleMainNavSection();

                    if(toggleDefaultSection)
                    {
                        LoadOverallTemplate();
                    }
                    break;
                case 2: // KPI btn clicked
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
                    toggleMainNavSection();
                    if (pnl_NavigationPanelMax.Width == Constants.maxNavWidth)
                        pnl_NavigationPanelMax.Width = Constants.minNavWidth;

                    tblpnl_Filters.BringToFront();
                    break;
                default:
                    break;
            }
        }







        /// <summary>
        /// This function will toggle the main navigation sections when either KPA or KPI buttons are clicked.
        /// </summary>
        public void toggleMainNavSection()
        {
            switch (int.Parse(mainNavActiveBtn.Tag as string))
            {
                case 1:
                    if (pnl_KPISectionsPanel.Visible)
                    {
                        pnl_KPISectionsPanel.Visible = false;
                        btn_KPI.BackgroundImage = Properties.Resources.KPIBG_Normal;
                    }

                    if (!pnl_KPASectionsPanel.Visible)
                    {
                        pnl_KPASectionsPanel.Visible = true;
                        btn_KPA.BackgroundImage = Properties.Resources.KPABG_Active;
                        mainNavActivePanel = pnl_KPASectionsPanel;
                    }
                    else
                    {
                        pnl_KPASectionsPanel.Visible = false;
                        btn_KPA.BackgroundImage = Properties.Resources.KPABG_Hover;
                    }
                    break;
                case 2:
                    if (pnl_KPASectionsPanel.Visible)
                    {
                        pnl_KPASectionsPanel.Visible = false;
                        btn_KPA.BackgroundImage = Properties.Resources.KPABG_Normal;
                    }

                    if (!pnl_KPISectionsPanel.Visible)
                    {
                        pnl_KPISectionsPanel.Visible = true;
                        btn_KPI.BackgroundImage = Properties.Resources.KPIBG_Active;
                        mainNavActivePanel = pnl_KPISectionsPanel;
                    }
                    else
                    {
                        pnl_KPISectionsPanel.Visible = false;
                        btn_KPI.BackgroundImage = Properties.Resources.KPIBG_Hover;
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
        public void activateButton(object sender)
        {
            int mainActTag = int.Parse(mainNavActiveBtn.Tag.ToString());

            // set the active button back to default state.
            setCurrActiveButtonToDefault();

            // get the object being acted upon.
            Button btn = sender as Button;
            int tag = int.Parse(btn.Tag.ToString());

            switch (tag)
            {
                case 0:
                    btn.BackgroundImage = Properties.Resources.DashboardBG_HoverActive;

                    // Only load the default state if the main nav active button is not KPA or KPI
                    if (mainActTag != 1 || mainActTag != 2)
                        loadDefaultSectionState(tag);
                    break;
                case 1: // 1 & 2 are navigation buttons with sub menu
                    btn.BackgroundImage = Properties.Resources.KPABG_Active;

                    // Only load the default state if the main nav active button is not KPA or KPI
                    if (mainActTag != 1 || mainActTag != 2)
                        loadDefaultSectionState(tag);
                    break;
                case 2:
                    btn.BackgroundImage = Properties.Resources.KPIBG_Active;

                    // Only load the default state if the main nav active button is not KPA or KPI
                    if(mainActTag != 1 || mainActTag != 2)
                        loadDefaultSectionState(tag);
                    break;
                case 3:
                    btn.BackgroundImage = Properties.Resources.ChartsBG_HoverActive;

                    // Only load the default state if the main nav active button is not KPA or KPI
                    if (mainActTag != 1 || mainActTag != 2)
                        loadDefaultSectionState(tag);
                    break;
                case 4:
                    btn.BackgroundImage = Properties.Resources.FilterBG_HoverActive;

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
        public void setCurrActiveButtonToDefault()
        {
            switch (int.Parse(mainNavActiveBtn.Tag as string))
            {
                case 0:
                    // update the icon image of the current active button
                    mainNavActiveBtn.BackgroundImage = Properties.Resources.DashboardBG_Normal;
                    break;
                case 1:
                    mainNavActiveBtn.BackgroundImage = Properties.Resources.KPABG_Normal;

                    if (pnl_KPASectionsPanel.Height != Constants.zeroHeight)
                        pnl_KPASectionsPanel.Height = Constants.zeroHeight;

                    if (pnl_KPISectionsPanel.Height != Constants.zeroHeight)
                        pnl_KPISectionsPanel.Height = Constants.zeroHeight;
                    break;
                case 2:
                    mainNavActiveBtn.BackgroundImage = Properties.Resources.KPIBG_Normal;

                    if (pnl_KPASectionsPanel.Height != Constants.zeroHeight)
                        pnl_KPASectionsPanel.Height = Constants.zeroHeight;

                    if (pnl_KPISectionsPanel.Height != Constants.zeroHeight)
                        pnl_KPISectionsPanel.Height = Constants.zeroHeight;
                    break;
                case 3:
                    // update the icon image of the current active button
                    mainNavActiveBtn.BackgroundImage = Properties.Resources.ChartsBG_Normal;
                    break;
                case 4:
                    // update the icon image of the current active button
                    mainNavActiveBtn.BackgroundImage = Properties.Resources.FilterBG_Normal;
                    break;
                default:
                    break;
            }
        }
    }
}
