using System;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI
    {
        Bunifu.Framework.UI.BunifuImageButton mainNavActiveBtn = new Bunifu.Framework.UI.BunifuImageButton();
        Bunifu.Framework.UI.BunifuImageButton imgBtn = new Bunifu.Framework.UI.BunifuImageButton();
        Bunifu.Framework.UI.BunifuFlatButton flatBtn = new Bunifu.Framework.UI.BunifuFlatButton();

        Panel mainNavActivePanel = new Panel() { Visible = false };
        bool NavigationLocked = false;
        bool MenuInFront = false;









        /// <summary>
        /// Initiates when the user unfocuses from the navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnl_NavigationPanelMax_Leave(object sender, EventArgs e)
        {
            pnl_NavigationPanelMax.SendToBack();
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

            if (sender is Bunifu.Framework.UI.BunifuFlatButton)
            {
                flatBtn = (Bunifu.Framework.UI.BunifuFlatButton)sender;
                tag = int.Parse(flatBtn.Tag.ToString());
            }
            else
            {
                imgBtn = (Bunifu.Framework.UI.BunifuImageButton)sender;
                tag = int.Parse(imgBtn.Tag.ToString());
            }



            RemoveActivePanelControls();


            // Load the pages that correspond to the clicked button
            switch (tag)
            {
                case 0: // Dashboard btn clicked
                    lbl_Performance.Text = "Not Selected";
                    lbl_Section.Text = "Not Selected";
                    lbl_Category.Text = "Not Selected";
                    toggleMainNavSection(tag);
                    ShowPage(Pages.Dashboard);
                    break;
                case 1: // KPA btn clicked
                    toggleMainNavSection(tag);
                    SetActiveSectionBtnToDefault();
                    LoadOverallTemplate(Performance.KPA);
                    break;
                case 2: // KPI btn clicked
                    toggleMainNavSection(tag);
                    SetActiveSectionBtnToDefault();
                    LoadOverallTemplate(Performance.KPI);
                    break;
                case 3: // Charts btn clicked
                    toggleMainNavSection(tag);
                    break;
                case 4: // Filters btn clicked
                    lbl_Performance.Text = "Not Selected";
                    lbl_Section.Text = "Not Selected";
                    lbl_Category.Text = "Not Selected";
                    toggleMainNavSection(tag);
                    ShowPage(Pages.Filters);
                    break;
                default:
                    break;
            }
        }







        







        /// <summary>
        /// This function will toggle the main navigation sections when either KPA or KPI buttons are clicked.
        /// </summary>
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
    }
}
