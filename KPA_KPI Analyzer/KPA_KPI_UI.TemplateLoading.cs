using KPA_KPI_Analyzer.PerformanceReporting;
using KPA_KPI_Analyzer.Templates.Template_Controls.KPA_Controls;
using KPA_KPI_Analyzer.Templates.Template_Controls.KPI_Controls;
using System;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI : Form
    {
        /// <summary>
        /// When the application is processing something, the loading screen will be presented with a message of what process is happening.
        /// </summary>
        /// <param name="_message">The message to display on the loading screen of the process.</param>
        private void ActivateLoadingScreen(string _message)
        {
            // Lock the navigation functionality
            navigationSettings.Status = Navigation.Functionality.Locked;

            ms_applicaitonMenuStrip.Enabled = false;

            // Set the text of the progress bar.
            cpb_loadingScreenCircProgBar.Text = _message;


            // Make the loading screen visible
            pnl_loadingScreen.Visible = true;

            // Bring the loading panel to the front if covered.
            pnl_loadingScreen.BringToFront();
        }



        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpaPlanTemplate()
        {
            topHandleBarModel.Section = "Plan";
            KPAPlanTemplate kpaPlanTemp = new KPAPlanTemplate()
            {
                Name = "Plan",
                Dock = DockStyle.Fill,
            };

            pnl_activePage.Controls.Add(kpaPlanTemp);
            kpaPlanTemp.BringToFront();
        }
    


        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpaPurchTemplate()
        {
            topHandleBarModel.Section = "Purch";
            KPAPurchTemplate kpaPurchTemp = new KPAPurchTemplate()
            {
                Name = "Purch",
                Dock = DockStyle.Fill,

            };
            pnl_activePage.Controls.Add(kpaPurchTemp);
            kpaPurchTemp.BringToFront();
        }
    


        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpaPurchSubTemplate()
        {
            topHandleBarModel.Section = "Purch Sub";
            KPAPurchSubTemplate kpaPurchSubTemp = new KPAPurchSubTemplate()
            {
                Name = "PurchSub",
                Dock = DockStyle.Fill,
            };

            pnl_activePage.Controls.Add(kpaPurchSubTemp);
            kpaPurchSubTemp.BringToFront();
        }



        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpaPurchTotalTemplate()
        {
            topHandleBarModel.Section = "Purch Total";
            KPAPurchTotalTemplate kpaPurchTotalTemp = new KPAPurchTotalTemplate()
            {
                Name = "PurchTotal",
                Dock = DockStyle.Fill,
            };

            pnl_activePage.Controls.Add(kpaPurchTotalTemp);
            kpaPurchTotalTemp.BringToFront();
        }



        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreatekpaFollowUpTemplate()
        {
            topHandleBarModel.Section = "Follow Up";
            KPAFollowUpTemplate kpaFollowUpTemp = new KPAFollowUpTemplate()
            {
                Name = "FollowUp",
                Dock = DockStyle.Fill,
            };
            pnl_activePage.Controls.Add(kpaFollowUpTemp);
            kpaFollowUpTemp.BringToFront();
        }



        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpaHotJobsTemplate()
        {
            topHandleBarModel.Section = "Hot Jobs";
            KPAHotJobsTemplate kpaHotJobs = new KPAHotJobsTemplate()
            {
                Name = "HotJobs",
                Dock = DockStyle.Fill,
            };
            pnl_activePage.Controls.Add(kpaHotJobs);
            kpaHotJobs.BringToFront();
        }



        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpaExcessStockStockTemplate()
        {
            topHandleBarModel.Section = "Excess Stock - Stock";
            KPAExcessStockStock kpaExcessStockStock = new KPAExcessStockStock()
            {
                Name = "ExcessStockStock",
                Dock = DockStyle.Fill,
            };

            pnl_activePage.Controls.Add(kpaExcessStockStock);
            kpaExcessStockStock.BringToFront();
        }



        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpaExcessStockOpenOrdersTemplate()
        {
            topHandleBarModel.Section = "Excess Stock - Open Orders";
            KPAExcessStockOpenOrders kpaExcessStockOpenOrders = new KPAExcessStockOpenOrders()
            {
                Name = "ExcessStockOpenOrders",
                Dock = DockStyle.Fill,
            };

            pnl_activePage.Controls.Add(kpaExcessStockOpenOrders);
            kpaExcessStockOpenOrders.BringToFront();
        }



        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpaCurrPlanActualTemplate()
        {
            topHandleBarModel.Section = "Current Plan vs Actual";
            KPACurrentPlanActualTemplate kpaCurrPlanActual = new KPACurrentPlanActualTemplate()
            {
                Name = "CurrPlanActual",
                Dock = DockStyle.Fill,
            };
            pnl_activePage.Controls.Add(kpaCurrPlanActual);
            kpaCurrPlanActual.BringToFront();
        }





        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpiPlanTemplate()
        {
            topHandleBarModel.Section = "Plan";
            KPIPlanTemplate kpiPlanTemplate = new KPIPlanTemplate()
            {
                Name = "Plan",
                Dock = DockStyle.Fill
            };

            pnl_activePage.Controls.Add(kpiPlanTemplate);
            kpiPlanTemplate.BringToFront();
        }



        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpiPurchTemplate()
        {
            topHandleBarModel.Section = "Purch";
            KPIPurchTemplate kpiPurchTemplate = new KPIPurchTemplate()
            {
                Name = "Purch",
                Dock = DockStyle.Fill
            };
            pnl_activePage.Controls.Add(kpiPurchTemplate);
            kpiPurchTemplate.BringToFront();
        }



        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpiFollowUpTemplate()
        {
            topHandleBarModel.Section = "Follow Up";
            KPIFollowUpTemplate kpiFollowUpTemplate = new KPIFollowUpTemplate()
            {
                Name = "FollowUp",
                Dock = DockStyle.Fill
            };
            pnl_activePage.Controls.Add(kpiFollowUpTemplate);
            kpiFollowUpTemplate.BringToFront();
        }



        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpiPlanTwoTemplate()
        {
            topHandleBarModel.Section = "Plan II";
            KPIPlanTwoTemplate kpiPlanTwoTemplate = new KPIPlanTwoTemplate()
            {
                Name = "Plan",
                Dock = DockStyle.Fill
            };
            pnl_activePage.Controls.Add(kpiPlanTwoTemplate);
            kpiPlanTwoTemplate.BringToFront();
        }



        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpiPurchTwoTemplate()
        {
            topHandleBarModel.Section = "Purch II";
            KPIPurchTwoTemplate kpiPurchTwoTemplate = new KPIPurchTwoTemplate()
            {
                Name = "Purch",
                Dock = DockStyle.Fill
            };
            pnl_activePage.Controls.Add(kpiPurchTwoTemplate);
            kpiPurchTwoTemplate.BringToFront();
        }



        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpiPurchSubTemplate()
        {
            topHandleBarModel.Section = "Purch Sub";
            KPIPurchSubTemplate kpiPurchSubTemplate = new KPIPurchSubTemplate()
            {
                Name = "PurchSub",
                Dock = DockStyle.Fill
            };
            pnl_activePage.Controls.Add(kpiPurchSubTemplate);
            kpiPurchSubTemplate.BringToFront();
        }



        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpiPurchTotalTemplate()
        {
            topHandleBarModel.Section = "Purch Total";
            KPIPurchTotalTemplate kpiPurchTotalTemplate = new KPIPurchTotalTemplate()
            {
                Name = "PurchTotal",
                Dock = DockStyle.Fill
            };

            pnl_activePage.Controls.Add(kpiPurchTotalTemplate);
            kpiPurchTotalTemplate.BringToFront();
        }



        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpiPurchPlanTemplate()
        {
            topHandleBarModel.Section = "Purch/Plan";
            KPIPurchPlanTemplate kpiPurchPlanTemplate = new KPIPurchPlanTemplate()
            {
                Name = "PurchPlan",
                Dock = DockStyle.Fill
            };

            pnl_activePage.Controls.Add(kpiPurchPlanTemplate);
            kpiPurchPlanTemplate.BringToFront();
        }



        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpiOtherTemplate()
        {
            topHandleBarModel.Section = "Other";
            KPIOtherTemplate kpiOtherTemplate = new KPIOtherTemplate()
            {
                Name = "Other",
                Dock = DockStyle.Fill
            };
            pnl_activePage.Controls.Add(kpiOtherTemplate);
            kpiOtherTemplate.BringToFront();
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
                    case "ExcessStockStock":
                    case "ExcessStockOpenOrders":
                    case "CurrPlanActual":
                    case "PurchPlan":
                    case "Other":
                    case "Correlation":
                    case "Reports":
                        pnl_activePage.Controls.Remove(ctrl);
                        break;
                    default:
                        break;
                }
            }
        }



        /// <summary>
        /// Triggered when a controls is added to the active page panel (pnl_activePage). depending on
        /// what control was added, that templates data will be loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnl_activePage_ControlAdded(object sender, ControlEventArgs e)
        {
            if(e.Control is Correlation.CorrelationControl || e.Control is SelctiveReportingWidget)
            {
                return;
            }


            if (e.Control is UserControl)
            {
                if(navigationController.MainTag == Navigation.MainNavigationTag.KPA)
                {
                    switch(navigationController.SectionTag)
                    {
                        case Navigation.SectionNavigationTag.Plan:
                            KPAPlanTemplate kpaPlan = (KPAPlanTemplate)e.Control;
                            kpaPlan.LoadPanel();
                            activeTemplate = kpaPlan;
                            break;
                        case Navigation.SectionNavigationTag.Purch:
                            KPAPurchTemplate kpaPurch = (KPAPurchTemplate)e.Control;
                            kpaPurch.LoadPanel();
                            activeTemplate = kpaPurch;
                            break;
                        case Navigation.SectionNavigationTag.PurchSub:
                            KPAPurchSubTemplate kpaPurchSub = (KPAPurchSubTemplate)e.Control;
                            kpaPurchSub.LoadPanel();
                            activeTemplate = kpaPurchSub;
                            break;
                        case Navigation.SectionNavigationTag.PurchTotal:
                            KPAPurchTotalTemplate kpaPurchTotal = (KPAPurchTotalTemplate)e.Control;
                            kpaPurchTotal.LoadPanel();
                            activeTemplate = kpaPurchTotal;
                            break;
                        case Navigation.SectionNavigationTag.FollowUp:
                            KPAFollowUpTemplate kpaFollowUp = (KPAFollowUpTemplate)e.Control;
                            kpaFollowUp.LoadPanel();
                            activeTemplate = kpaFollowUp;
                            break;
                        case Navigation.SectionNavigationTag.HotJobs:
                            KPAHotJobsTemplate kpaHotJobs = (KPAHotJobsTemplate)e.Control;
                            kpaHotJobs.LoadPanel();
                            activeTemplate = kpaHotJobs;
                            break;
                        case Navigation.SectionNavigationTag.ExcessStockStock:
                            KPAExcessStockStock kpaExcessStockStock = (KPAExcessStockStock)e.Control;
                            kpaExcessStockStock.LoadPanel();
                            activeTemplate = kpaExcessStockStock;
                            break;
                        case Navigation.SectionNavigationTag.ExcessStockOpenOrders:
                            KPAExcessStockOpenOrders kpaExcessStockOpenOrders = (KPAExcessStockOpenOrders)e.Control;
                            kpaExcessStockOpenOrders.LoadPanel();
                            activeTemplate = kpaExcessStockOpenOrders;
                            break;
                        case Navigation.SectionNavigationTag.CurrentPlanVsActual:
                            KPACurrentPlanActualTemplate kpaCurrPlanActual = (KPACurrentPlanActualTemplate)e.Control;
                            kpaCurrPlanActual.LoadPanel();
                            activeTemplate = kpaCurrPlanActual;
                            break;
                        default:
                            break;
                    }
                }
                else // the user is interacting with the KPIs
                {
                    switch (navigationController.SectionTag)
                    {
                        case Navigation.SectionNavigationTag.Plan:
                            KPIPlanTemplate kpiPlan = (KPIPlanTemplate)e.Control;
                            kpiPlan.LoadPanel();
                            activeTemplate = kpiPlan;
                            break;
                        case Navigation.SectionNavigationTag.Purch:
                            KPIPurchTemplate kpiPurch = (KPIPurchTemplate)e.Control;
                            kpiPurch.LoadPanel();
                            activeTemplate = kpiPurch;
                            break;
                        case Navigation.SectionNavigationTag.FollowUp:
                            KPIFollowUpTemplate kpiFollowUp = (KPIFollowUpTemplate)e.Control;
                            kpiFollowUp.LoadPanel();
                            activeTemplate = kpiFollowUp;
                            break;
                        case Navigation.SectionNavigationTag.PlanII:
                            KPIPlanTwoTemplate kpiPlanTwo = (KPIPlanTwoTemplate)e.Control;
                            kpiPlanTwo.LoadPanel();
                            activeTemplate = kpiPlanTwo;
                            break;
                        case Navigation.SectionNavigationTag.PurchII:
                            KPIPurchTwoTemplate kpiPurchTwo = (KPIPurchTwoTemplate)e.Control;
                            kpiPurchTwo.LoadPanel();
                            activeTemplate = kpiPurchTwo;
                            break;
                        case Navigation.SectionNavigationTag.PurchSub:
                            KPIPurchSubTemplate kpiPurchSub = (KPIPurchSubTemplate)e.Control;
                            kpiPurchSub.LoadPanel();
                            activeTemplate = kpiPurchSub;
                            break;
                        case Navigation.SectionNavigationTag.PurchTotal:
                            KPIPurchTotalTemplate kpiPurchTotal = (KPIPurchTotalTemplate)e.Control;
                            kpiPurchTotal.LoadPanel();
                            activeTemplate = kpiPurchTotal;
                            break;
                        case Navigation.SectionNavigationTag.PurchPlan:
                            KPIPurchPlanTemplate kpiPurchPlan = (KPIPurchPlanTemplate)e.Control;
                            kpiPurchPlan.LoadPanel();
                            activeTemplate = kpiPurchPlan;
                            break;
                        case Navigation.SectionNavigationTag.Other:
                            KPIOtherTemplate kpiOther = (KPIOtherTemplate)e.Control;
                            kpiOther.LoadPanel();
                            activeTemplate = kpiOther;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

    
        /// <summary>
        /// Refreshes the active template that is within pnl_activePage. This is called when the 
        /// application is made full screen and normal size. This is for the column chart located
        /// on each template.
        /// </summary>
        public void RefreshTemplate()
        {
            if(navigationController.MainTag == Navigation.MainNavigationTag.KPA)
            {
                switch(navigationController.SectionTag)
                {
                    case Navigation.SectionNavigationTag.Plan:
                        KPAPlanTemplate kpaPlan = (KPAPlanTemplate)activeTemplate;
                        kpaPlan.RefreshTemplate();
                        break;
                    case Navigation.SectionNavigationTag.Purch:
                        KPAPurchTemplate kpaPurch = (KPAPurchTemplate)activeTemplate;
                        kpaPurch.RefreshTemplate();
                        break;
                    case Navigation.SectionNavigationTag.PurchSub:
                        KPAPurchSubTemplate kpaPurchSub = (KPAPurchSubTemplate)activeTemplate;
                        kpaPurchSub.RefreshTemplate();
                        break;
                    case Navigation.SectionNavigationTag.PurchTotal:
                        KPAPurchTotalTemplate kpaPurchTotal = (KPAPurchTotalTemplate)activeTemplate;
                        kpaPurchTotal.RefreshTemplate();
                        break;
                    case Navigation.SectionNavigationTag.FollowUp:
                        KPAFollowUpTemplate kpaFollowUp = (KPAFollowUpTemplate)activeTemplate;
                        kpaFollowUp.RefreshTemplate();
                        break;
                    case Navigation.SectionNavigationTag.HotJobs:
                        KPAHotJobsTemplate kpaHotJobs = (KPAHotJobsTemplate)activeTemplate;
                        kpaHotJobs.RefreshTemplate();
                        break;
                    case Navigation.SectionNavigationTag.ExcessStockStock:
                        KPAExcessStockStock kapExcessStockStock = (KPAExcessStockStock)activeTemplate;
                        kapExcessStockStock.RefreshTemplate();
                        break;
                    case Navigation.SectionNavigationTag.ExcessStockOpenOrders:
                        KPAExcessStockOpenOrders kpaExcessStockOpenOrders = (KPAExcessStockOpenOrders)activeTemplate;
                        kpaExcessStockOpenOrders.RefreshTemplate();
                        break;
                    case Navigation.SectionNavigationTag.CurrentPlanVsActual:
                        KPACurrentPlanActualTemplate kpaCurrPlanActual = (KPACurrentPlanActualTemplate)activeTemplate;
                        kpaCurrPlanActual.RefreshTemplate();
                        break;
                    default:
                        break;
                }
            }
            else // The has  KPI currently loaded
            {
                switch(navigationController.SectionTag)
                {
                    case Navigation.SectionNavigationTag.Plan:
                        KPIPlanTemplate kpiPlan = (KPIPlanTemplate)activeTemplate;
                        kpiPlan.RefreshTemplate();
                        break;
                    case Navigation.SectionNavigationTag.Purch:
                        KPIPurchTemplate kpiPurch = (KPIPurchTemplate)activeTemplate;
                        kpiPurch.RefreshTemplate();
                        break;
                    case Navigation.SectionNavigationTag.FollowUp:
                        KPIFollowUpTemplate kpiFollowUp = (KPIFollowUpTemplate)activeTemplate;
                        kpiFollowUp.RefreshTemplate();
                        break;
                    case Navigation.SectionNavigationTag.PlanII:
                        KPIPlanTwoTemplate kpiPlanTwo = (KPIPlanTwoTemplate)activeTemplate;
                        kpiPlanTwo.RefreshTemplate();
                        break;
                    case Navigation.SectionNavigationTag.PurchII:
                        KPIPurchTwoTemplate kpiPurchTwo = (KPIPurchTwoTemplate)activeTemplate;
                        kpiPurchTwo.RefreshTemplate();
                        break;
                    case Navigation.SectionNavigationTag.PurchSub:
                        KPIPurchSubTemplate kpiPurchSub = (KPIPurchSubTemplate)activeTemplate;
                        kpiPurchSub.RefreshTemplate();
                        break;
                    case Navigation.SectionNavigationTag.PurchTotal:
                        KPIPurchTotalTemplate kpiPurchTotal = (KPIPurchTotalTemplate)activeTemplate;
                        kpiPurchTotal.RefreshTemplate();
                        break;
                    case Navigation.SectionNavigationTag.PurchPlan:
                        KPIPurchPlanTemplate kpiPurchPlan = (KPIPurchPlanTemplate)activeTemplate;
                        kpiPurchPlan.RefreshTemplate();
                        break;
                    case Navigation.SectionNavigationTag.Other:
                        KPIOtherTemplate kpiOther = (KPIOtherTemplate)activeTemplate;
                        kpiOther.RefreshTemplate();
                        break;
                    default:
                        break;
                }
            }
        }



        /// <summary>
        /// Loads either the KPA or KPI overall data template depending on what navigation button was pressed.
        /// </summary>
        private void LoadOverallTemplate(Values.Performances.Performance page)
        {
            if (page == Values.Performances.Performance.KPA)
            {
                topHandleBarModel.Update("KPA", "ALL", "ALL");


                NewKPAOverall kpaOverall = new NewKPAOverall()
                {
                    Name = "Overall",
                    Dock = DockStyle.Fill
                };
                pnl_activePage.Controls.Add(kpaOverall);
                kpaOverall.BringToFront();
            }

            if (page == Values.Performances.Performance.KPI)
            {
                topHandleBarModel.Update("KPI", "ALL", "ALL");

                NewKPIOverall kpiOverall = new NewKPIOverall()
                {
                    Name = "Overall",
                    Dock = DockStyle.Fill
                };
                pnl_activePage.Controls.Add(kpiOverall);
                kpiOverall.BringToFront();
            }
        }


        /// <summary>
        /// Loads the correlation controls into view.
        /// </summary>
        private void CreateCorrelationWindow()
        {
            topHandleBarModel.Update("N/A", "ALL", "ALL");

            Correlation.CorrelationControl correlation = new Correlation.CorrelationControl()
            {
                Name = "Correlation",
                Dock = DockStyle.Fill
            };

            pnl_activePage.Controls.Add(correlation);
            correlation.BringToFront();
        }
    }
}