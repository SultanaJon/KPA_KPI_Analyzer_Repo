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
            // Lock the navigation and the menu strip navigation
            NavigationLocked = true;
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
        private void CreateKpaOverallTemplate()
        {
            activeSectionBtn = btn_kpaOverall;
            topHandleBarModel.Update("KPA", "ALL", "ALL");
            MenuInFront = true;
            NewKPAOverall kpaOverall = new NewKPAOverall()
            {
                Name = "Overall",
                Dock = DockStyle.Fill
            };
            pnl_activePage.Controls.Add(kpaOverall);
            kpaOverall.BringToFront();
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
        }



        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpiOverallTemplate()
        {
            activeSectionBtn = btn_kpiOverall;
            topHandleBarModel.Update("KPI", "ALL", "ALL");

            NewKPIOverall kpiOverall = new NewKPIOverall()
            {
                Name = "Overall",
                Dock = DockStyle.Fill
            };
            pnl_activePage.Controls.Add(kpiOverall);
            kpiOverall.BringToFront();
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();
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
                int tag = int.Parse(activeSectionBtn.Tag.ToString());

                switch (tag)
                {
                    case 1:
                        KPAPlanTemplate kpaPlan = (KPAPlanTemplate)e.Control;
                        kpaPlan.LoadPanel();
                        activeTemplate = kpaPlan;
                        break;
                    case 2:
                        KPAPurchTemplate kpaPurch = (KPAPurchTemplate)e.Control;
                        kpaPurch.LoadPanel();
                        activeTemplate = kpaPurch;
                        break;
                    case 3:
                        KPAPurchSubTemplate kpaPurchSub = (KPAPurchSubTemplate)e.Control;
                        kpaPurchSub.LoadPanel();
                        activeTemplate = kpaPurchSub;
                        break;
                    case 4:
                        KPAPurchTotalTemplate kpaPurchTotal = (KPAPurchTotalTemplate)e.Control;
                        kpaPurchTotal.LoadPanel();
                        activeTemplate = kpaPurchTotal;
                        break;
                    case 5:
                        KPAFollowUpTemplate kpaFollowUp = (KPAFollowUpTemplate)e.Control;
                        kpaFollowUp.LoadPanel();
                        activeTemplate = kpaFollowUp;
                        break;
                    case 6:
                        KPAHotJobsTemplate kpaHotJobs = (KPAHotJobsTemplate)e.Control;
                        kpaHotJobs.LoadPanel();
                        activeTemplate = kpaHotJobs;
                        break;
                    case 7:
                        KPAExcessStockStock kpaExcessStockStock = (KPAExcessStockStock)e.Control;
                        kpaExcessStockStock.LoadPanel();
                        activeTemplate = kpaExcessStockStock;
                        break;
                    case 8:
                        KPAExcessStockOpenOrders kpaExcessStockOpenOrders = (KPAExcessStockOpenOrders)e.Control;
                        kpaExcessStockOpenOrders.LoadPanel();
                        activeTemplate = kpaExcessStockOpenOrders;
                        break;
                    case 9:
                        KPACurrentPlanActualTemplate kpaCurrPlanActual = (KPACurrentPlanActualTemplate)e.Control;
                        kpaCurrPlanActual.LoadPanel();
                        activeTemplate = kpaCurrPlanActual;
                        break;
                    case 11:
                        KPIPlanTemplate kpiPlan = (KPIPlanTemplate)e.Control;
                        kpiPlan.LoadPanel();
                        activeTemplate = kpiPlan;
                        break;
                    case 12:
                        KPIPurchTemplate kpiPurch = (KPIPurchTemplate)e.Control;
                        kpiPurch.LoadPanel();
                        activeTemplate = kpiPurch;
                        break;
                    case 13:
                        KPIFollowUpTemplate kpiFollowUp = (KPIFollowUpTemplate)e.Control;
                        kpiFollowUp.LoadPanel();
                        activeTemplate = kpiFollowUp;
                        break;
                    case 14:
                        KPIPlanTwoTemplate kpiPlanTwo  = (KPIPlanTwoTemplate)e.Control;
                        kpiPlanTwo.LoadPanel();
                        activeTemplate = kpiPlanTwo;
                        break;
                    case 15:
                        KPIPurchTwoTemplate kpiPurchTwo = (KPIPurchTwoTemplate)e.Control;
                        kpiPurchTwo.LoadPanel();
                        activeTemplate = kpiPurchTwo;
                        break;
                    case 16:
                        KPIPurchSubTemplate kpiPurchSub = (KPIPurchSubTemplate)e.Control;
                        kpiPurchSub.LoadPanel();
                        activeTemplate = kpiPurchSub;
                        break;
                    case 17:
                        KPIPurchTotalTemplate kpiPurchTotal = (KPIPurchTotalTemplate)e.Control;
                        kpiPurchTotal.LoadPanel();
                        activeTemplate = kpiPurchTotal;
                        break;
                    case 18:
                        KPIPurchPlanTemplate kpiPurchPlan = (KPIPurchPlanTemplate)e.Control;
                        kpiPurchPlan.LoadPanel();
                        activeTemplate = kpiPurchPlan;
                        break;
                    case 19:
                        KPIOtherTemplate kpiOther = (KPIOtherTemplate)e.Control;
                        kpiOther.LoadPanel();
                        activeTemplate = kpiOther;
                        break;
                    default:
                        break;
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
            if (activeSectionBtn.Tag != null)
            {
                int tag = int.Parse(activeSectionBtn.Tag.ToString());


                switch (tag)
                {
                    case 1:
                        KPAPlanTemplate kpaPlan = (KPAPlanTemplate)activeTemplate;
                        kpaPlan.RefreshTemplate();
                        break;
                    case 2:
                        KPAPurchTemplate kpaPurch = (KPAPurchTemplate)activeTemplate;
                        kpaPurch.RefreshTemplate();
                        break;
                    case 3:
                        KPAPurchSubTemplate kpaPurchSub = (KPAPurchSubTemplate)activeTemplate;
                        kpaPurchSub.RefreshTemplate();
                        break;
                    case 4:
                        KPAPurchTotalTemplate kpaPurchTotal = (KPAPurchTotalTemplate)activeTemplate;
                        kpaPurchTotal.RefreshTemplate();
                        break;
                    case 5:
                        KPAFollowUpTemplate kpaFollowUp = (KPAFollowUpTemplate)activeTemplate;
                        kpaFollowUp.RefreshTemplate();
                        break;
                    case 6:
                        KPAHotJobsTemplate kpaHotJobs = (KPAHotJobsTemplate)activeTemplate;
                        kpaHotJobs.RefreshTemplate();
                        break;
                    case 7:
                        KPAExcessStockStock kapExcessStockStock = (KPAExcessStockStock)activeTemplate;
                        kapExcessStockStock.RefreshTemplate();
                        break;
                    case 8:
                        KPAExcessStockOpenOrders kpaExcessStockOpenOrders = (KPAExcessStockOpenOrders)activeTemplate;
                        kpaExcessStockOpenOrders.RefreshTemplate();
                        break;
                    case 9:
                        KPACurrentPlanActualTemplate kpaCurrPlanActual = (KPACurrentPlanActualTemplate)activeTemplate;
                        kpaCurrPlanActual.RefreshTemplate();
                        break;
                    case 11:
                        KPIPlanTemplate kpiPlan = (KPIPlanTemplate)activeTemplate;
                        kpiPlan.RefreshTemplate();
                        break;
                    case 12:
                        KPIPurchTemplate kpiPurch = (KPIPurchTemplate)activeTemplate;
                        kpiPurch.RefreshTemplate();
                        break;
                    case 13:
                        KPIFollowUpTemplate kpiFollowUp = (KPIFollowUpTemplate)activeTemplate;
                        kpiFollowUp.RefreshTemplate();
                        break;
                    case 14:
                        KPIPlanTwoTemplate kpiPlanTwo = (KPIPlanTwoTemplate)activeTemplate;
                        kpiPlanTwo.RefreshTemplate();
                        break;
                    case 15:
                        KPIPurchTwoTemplate kpiPurchTwo = (KPIPurchTwoTemplate)activeTemplate;
                        kpiPurchTwo.RefreshTemplate();
                        break;
                    case 16:
                        KPIPurchSubTemplate kpiPurchSub = (KPIPurchSubTemplate)activeTemplate;
                        kpiPurchSub.RefreshTemplate();
                        break;
                    case 17:
                        KPIPurchTotalTemplate kpiPurchTotal = (KPIPurchTotalTemplate)activeTemplate;
                        kpiPurchTotal.RefreshTemplate();
                        break;
                    case 18:
                        KPIPurchPlanTemplate kpiPurchPlan = (KPIPurchPlanTemplate)activeTemplate;
                        kpiPurchPlan.RefreshTemplate();
                        break;
                    case 19:
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
                activeSectionBtn = btn_kpaOverall;
                SetActiveSectionBtn(activeSectionBtn);
                topHandleBarModel.Update("KPA", "ALL", "ALL");
                MenuInFront = true;
                NewKPAOverall kpaOverall = new NewKPAOverall()
                {
                    Name = "Overall",
                    Dock = DockStyle.Fill
                };
                pnl_activePage.Controls.Add(kpaOverall);
                kpaOverall.BringToFront();
                pnl_NavigationPanelMax.BringToFront();
            }

            if (page == Values.Performances.Performance.KPI)
            {
                activeSectionBtn = btn_kpiOverall;
                SetActiveSectionBtn(activeSectionBtn);
                topHandleBarModel.Update("KPI", "ALL", "ALL");

                MenuInFront = true;
                NewKPIOverall kpiOverall = new NewKPIOverall()
                {
                    Name = "Overall",
                    Dock = DockStyle.Fill
                };
                pnl_activePage.Controls.Add(kpiOverall);
                kpiOverall.BringToFront();
                pnl_NavigationPanelMax.BringToFront();
            }
        }


        /// <summary>
        /// Loads the correlation controls into view.
        /// </summary>
        private void CreateCorrelationWindow()
        {
            topHandleBarModel.Update("N/A", "ALL", "ALL");

            MenuInFront = true;
            Correlation.CorrelationControl correlation = new Correlation.CorrelationControl()
            {
                Name = "Correlation",
                Dock = DockStyle.Fill
            };

            pnl_activePage.Controls.Add(correlation);
            correlation.BringToFront();
            pnl_NavigationPanelMax.BringToFront();
        }
    }
}