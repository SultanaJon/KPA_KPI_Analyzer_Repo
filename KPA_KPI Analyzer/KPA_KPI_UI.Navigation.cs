using KPA_KPI_Analyzer.Navigation;
using KPA_KPI_Analyzer.Values;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI
    {
        /// <summary>
        /// The controller of the navigation window
        /// </summary>
        public NavigationController navigationController;



        /// <summary>
        /// The settings of the navigation window
        /// </summary>
        public NavigationSettings navigationSettings;



        /// <summary>
        /// Creates the navigation controller.
        /// </summary>
        public void CreateNavigationController()
        {
            // Ceate a new navigation settings object
            navigationSettings = new NavigationSettings();

            // Create an instance of the controller
            navigationController = new NavigationController(navigationWindow, MainNavigation_Click, navigationSettings);
        }




        /// <summary>
        /// This event will trigger when the user clicks on any of the main navigation buttons.S
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainNavigation_Click(object sender, NavigationArgs e)
        {
            // Removes any templates that might be in the active panel.
            RemoveActivePanelControls();

            // Load the pages that correspond to the clicked button
            switch (e.MainTag)
            {
                case MainNavigationTag.Dashboard:
                    topHandleBarModel.Update("N/A", "N/A", "N/A");
                    ShowPage(Pages.Dashboard);
                    break;
                case MainNavigationTag.KPA:
                    if (e.SectionTag == SectionNavigationTag.Overall)
                    {
                        // Load the KPA overall template
                        LoadOverallTemplate(Performances.Performance.KPA);
                    }
                    else
                    {
                        // Load the section template the user would like to view
                        LoadKpaSectionPage(e);
                    }
                    break;
                case MainNavigationTag.KPI:
                    if (e.SectionTag == SectionNavigationTag.Overall)
                    {
                        // Load teh KPI overall template
                        LoadOverallTemplate(Performances.Performance.KPI);
                    }
                    else
                    {
                        // Load the section template the user would like to view
                        LoadKpiSectionPage(e);
                    }
                    break;
                case MainNavigationTag.Correlation:
                    CreateCorrelationWindow();
                    break;
                case MainNavigationTag.Filters:
                    // Set the model indicating that there is currently no KPA or KPI being viewed.
                    topHandleBarModel.Update("N/A", "N/A", "N/A");
                    ShowPage(Pages.Filters);
                    break;
                case MainNavigationTag.Reports:
                    CreateReportPage();
                    break;
                default:
                    break;
            }
        }




        /// <summary>
        /// Loads the KPA section pages requested by the user
        /// </summary>
        /// <param name="e">The navigation args aquired by the navigation view</param>
        private void LoadKpaSectionPage(NavigationArgs e)
        {
            // Remove and Performance panel from the active panel view
            RemoveActivePanelControls();

            // Update the top handle bar to notify the user they are viewing KPA information
            topHandleBarModel.Performance = "KPA";

            switch(e.SectionTag)
            {
                case SectionNavigationTag.Plan:
                    CreateKpaPlanTemplate();
                    break;
                case SectionNavigationTag.Purch:
                    CreateKpaPurchTemplate();
                    break;
                case SectionNavigationTag.PurchSub:
                    CreateKpaPurchSubTemplate();
                    break;
                case SectionNavigationTag.PurchTotal:
                    CreateKpaPurchTotalTemplate();
                    break;
                case SectionNavigationTag.FollowUp:
                    CreatekpaFollowUpTemplate();
                    break;
                case SectionNavigationTag.HotJobs:
                    CreateKpaHotJobsTemplate();
                    break;
                case SectionNavigationTag.ExcessStockStock:
                    CreateKpaExcessStockStockTemplate();
                    break;
                case SectionNavigationTag.ExcessStockOpenOrders:
                    CreateKpaExcessStockOpenOrdersTemplate();
                    break;
                case SectionNavigationTag.CurrentPlanVsActual:
                    CreateKpaCurrPlanActualTemplate();
                    break;
                default:
                    break;
            }
        }





        /// <summary>
        /// Loads the KPI section pages request by the user
        /// </summary>
        /// <param name="e">The navigation args aquired from the navigation view</param>
        private void LoadKpiSectionPage(NavigationArgs e)
        {
            // Remove and Performance panel from the active panel view
            RemoveActivePanelControls();

            // Update the top handle bar to notify the user they are viewing KPI information
            topHandleBarModel.Performance = "KPI";


            switch(e.SectionTag)
            {
                case SectionNavigationTag.Plan:
                    CreateKpiPlanTemplate();
                    break;
                case SectionNavigationTag.Purch:
                    CreateKpiPurchTemplate();
                    break;
                case SectionNavigationTag.FollowUp:
                    CreateKpiFollowUpTemplate();
                    break;
                case SectionNavigationTag.PlanII:
                    CreateKpiPlanTwoTemplate();
                    break;
                case SectionNavigationTag.PurchII:
                    CreateKpiPurchTwoTemplate();
                    break;
                case SectionNavigationTag.FollowUpTwo:
                    CreateKpiFollowUpTwoTemplate();
                    break;
                case SectionNavigationTag.PurchSub:
                    CreateKpiPurchSubTemplate();
                    break;
                case SectionNavigationTag.PurchTotal:
                    CreateKpiPurchTotalTemplate();
                    break;
                case SectionNavigationTag.PurchPlan:
                    CreateKpiPurchPlanTemplate();
                    break;
                case SectionNavigationTag.Other:
                    CreateKpiOtherTemplate();
                    break;
                default:
                    break;
            }
        }
    }
}