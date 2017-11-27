using KPA_KPI_Analyzer.Templates.Template_Controls.KPA_Controls;
using KPA_KPI_Analyzer.Templates.Template_Controls.KPI_Controls;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI : Form
    {

        /// <summary>
        /// The current Performance
        /// </summary>
        public enum Performance
        {
            KPA,
            KPI
        }

        /// <summary>
        /// Instantiates a template object and adds the control to the active page panel for loading/viewing
        /// </summary>
        private void CreateKpaOverallTemplate()
        {
            activeSectionBtn = btn_kpaOverall;
            lbl_Performance.Text = "KPA";
            lbl_Section.Text = "All";
            lbl_Category.Text = "All";
            MenuInFront = true;
            NewKPAOverall kpaOverall = new NewKPAOverall(overallData)
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
            lbl_Section.Text = "Plan";
            KPAPlanTemplate kpaPlanTemp = new KPAPlanTemplate()
            {
                Name = "Plan",
                Dock = DockStyle.Fill,
            };

            KPAPlanTemplate.ChangeCategory += UpdateCategoryStatus;
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
            lbl_Section.Text = "Purch";
            KPAPurchTemplate kpaPurchTemp = new KPAPurchTemplate()
            {
                Name = "Purch",
                Dock = DockStyle.Fill,

            };
            KPAPurchTemplate.ChangeCategory += UpdateCategoryStatus;
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
            lbl_Section.Text = "Purch Sub";
            KPAPurchSubTemplate kpaPurchSubTemp = new KPAPurchSubTemplate()
            {
                Name = "PurchSub",
                Dock = DockStyle.Fill,
            };

            KPAPurchSubTemplate.ChangeCategory += UpdateCategoryStatus;
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
            lbl_Section.Text = "Purch Total";
            KPAPurchTotalTemplate kpaPurchTotalTemp = new KPAPurchTotalTemplate()
            {
                Name = "PurchTotal",
                Dock = DockStyle.Fill,
            };

            KPAPurchTotalTemplate.ChangeCategory += UpdateCategoryStatus;
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
            lbl_Section.Text = "Follow Up";
            KPAFollowUpTemplate kpaFollowUpTemp = new KPAFollowUpTemplate()
            {
                Name = "FollowUp",
                Dock = DockStyle.Fill,
            };
            KPAFollowUpTemplate.ChangeCategory += UpdateCategoryStatus;
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
            lbl_Section.Text = "Hot Jobs";
            KPAHotJobsTemplate kpaHotJobs = new KPAHotJobsTemplate()
            {
                Name = "HotJobs",
                Dock = DockStyle.Fill,
            };

            KPAHotJobsTemplate.ChangeCategory += UpdateCategoryStatus;
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
            lbl_Section.Text = "Excess Stock - Stock";
            KPAExcessStockStock kpaExcessStockStock = new KPAExcessStockStock()
            {
                Name = "ExcessStockStock",
                Dock = DockStyle.Fill,
            };

            KPAExcessStockStock.ChangeCategory += UpdateCategoryStatus;
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
            lbl_Section.Text = "Excess Stock - Open Orders";
            KPAExcessStockOpenOrders kpaExcessStockOpenOrders = new KPAExcessStockOpenOrders()
            {
                Name = "ExcessStockOpenOrders",
                Dock = DockStyle.Fill,
            };

            KPAExcessStockOpenOrders.ChangeCategory += UpdateCategoryStatus;
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
            lbl_Section.Text = "Current Plan vs Actual";
            KPACurrentPlanActualTemplate kpaCurrPlanActual = new KPACurrentPlanActualTemplate()
            {
                Name = "CurrPlanActual",
                Dock = DockStyle.Fill,
            };
            KPACurrentPlanActualTemplate.ChangeCategory += UpdateCategoryStatus;
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
            lbl_Performance.Text = "KPI";
            lbl_Section.Text = "All";
            lbl_Category.Text = "All";
            NewKPIOverall kpiOverall = new NewKPIOverall(overallData)
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
            lbl_Section.Text = "Plan";
            KPIPlanTemplate kpiPlanTemplate = new KPIPlanTemplate()
            {
                Name = "Plan",
                Dock = DockStyle.Fill
            };

            KPIPlanTemplate.ChangeCategory += UpdateCategoryStatus;
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
            lbl_Section.Text = "Purch";
            KPIPurchTemplate kpiPurchTemplate = new KPIPurchTemplate()
            {
                Name = "Purch",
                Dock = DockStyle.Fill
            };
            KPIPurchTemplate.ChangeCategory += UpdateCategoryStatus;
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
            lbl_Section.Text = "Follow Up";
            KPIFollowUpTemplate kpiFollowUpTemplate = new KPIFollowUpTemplate()
            {
                Name = "FollowUp",
                Dock = DockStyle.Fill
            };
            KPIFollowUpTemplate.ChangeCategory += UpdateCategoryStatus;
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
            lbl_Section.Text = "Plan";
            KPIPlanTwoTemplate kpiPlanTwoTemplate = new KPIPlanTwoTemplate()
            {
                Name = "Plan",
                Dock = DockStyle.Fill
            };
            KPIPlanTwoTemplate.ChangeCategory += UpdateCategoryStatus;
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
            lbl_Section.Text = "Purch";
            KPIPurchTwoTemplate kpiPurchTwoTemplate = new KPIPurchTwoTemplate()
            {
                Name = "Purch",
                Dock = DockStyle.Fill
            };
            KPIPurchTwoTemplate.ChangeCategory += UpdateCategoryStatus;
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
            lbl_Section.Text = "Purch Sub";
            KPIPurchSubTemplate kpiPurchSubTemplate = new KPIPurchSubTemplate()
            {
                Name = "PurchSub",
                Dock = DockStyle.Fill
            };
            KPIPurchSubTemplate.ChangeCategory += UpdateCategoryStatus;
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
            lbl_Section.Text = "Purch Total";
            KPIPurchTotalTemplate kpiPurchTotalTemplate = new KPIPurchTotalTemplate()
            {
                Name = "PurchTotal",
                Dock = DockStyle.Fill
            };

            KPIPurchTotalTemplate.ChangeCategory += UpdateCategoryStatus;
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
            lbl_Section.Text = "Purch/Plan";
            KPIPurchPlanTemplate kpiPurchPlanTemplate = new KPIPurchPlanTemplate()
            {
                Name = "PurchPlan",
                Dock = DockStyle.Fill
            };

            KPIPurchPlanTemplate.ChangeCategory += UpdateCategoryStatus;
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
            lbl_Section.Text = "Other";
            KPIOtherTemplate kpiOtherTemplate = new KPIOtherTemplate()
            {
                Name = "Other",
                Dock = DockStyle.Fill
            };
            KPIOtherTemplate.ChangeCategory += UpdateCategoryStatus;
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
            if (e.Control is UserControl)
            {
                int tag = int.Parse(activeSectionBtn.Tag.ToString());

                switch (tag)
                {
                    case 1:
                        KPAPlanTemplate kpaPlan = (KPAPlanTemplate)e.Control;
                        kpaPlan.LoadPanel(overallData);
                        activeTemplate = kpaPlan;
                        break;
                    case 2:
                        KPAPurchTemplate kpaPurch = (KPAPurchTemplate)e.Control;
                        kpaPurch.LoadPanel(overallData);
                        activeTemplate = kpaPurch;
                        break;
                    case 3:
                        KPAPurchSubTemplate kpaPurchSub = (KPAPurchSubTemplate)e.Control;
                        kpaPurchSub.LoadPanel(overallData);
                        activeTemplate = kpaPurchSub;
                        break;
                    case 4:
                        KPAPurchTotalTemplate kpaPurchTotal = (KPAPurchTotalTemplate)e.Control;
                        kpaPurchTotal.LoadPanel(overallData);
                        activeTemplate = kpaPurchTotal;
                        break;
                    case 5:
                        KPAFollowUpTemplate kpaFollowUp = (KPAFollowUpTemplate)e.Control;
                        kpaFollowUp.LoadPanel(overallData);
                        activeTemplate = kpaFollowUp;
                        break;
                    case 6:
                        KPAHotJobsTemplate kpaHotJobs = (KPAHotJobsTemplate)e.Control;
                        kpaHotJobs.LoadPanel(overallData);
                        activeTemplate = kpaHotJobs;
                        break;
                    case 7:
                        KPAExcessStockStock kpaExcessStockStock = (KPAExcessStockStock)e.Control;
                        kpaExcessStockStock.LoadPanel(overallData);
                        activeTemplate = kpaExcessStockStock;
                        break;
                    case 8:
                        KPAExcessStockOpenOrders kpaExcessStockOpenOrders = (KPAExcessStockOpenOrders)e.Control;
                        kpaExcessStockOpenOrders.LoadPanel(overallData);
                        activeTemplate = kpaExcessStockOpenOrders;
                        break;
                    case 9:
                        KPACurrentPlanActualTemplate kpaCurrPlanActual = (KPACurrentPlanActualTemplate)e.Control;
                        kpaCurrPlanActual.LoadPanel(overallData);
                        activeTemplate = kpaCurrPlanActual;
                        break;
                    case 11:
                        KPIPlanTemplate kpiPlan = (KPIPlanTemplate)e.Control;
                        kpiPlan.LoadPanel(overallData);
                        activeTemplate = kpiPlan;
                        break;
                    case 12:
                        KPIPurchTemplate kpiPurch = (KPIPurchTemplate)e.Control;
                        kpiPurch.LoadPanel(overallData);
                        activeTemplate = kpiPurch;
                        break;
                    case 13:
                        KPIFollowUpTemplate kpiFollowUp = (KPIFollowUpTemplate)e.Control;
                        kpiFollowUp.LoadPanel(overallData);
                        activeTemplate = kpiFollowUp;
                        break;
                    case 14:
                        KPIPlanTwoTemplate kpiPlanTwo  = (KPIPlanTwoTemplate)e.Control;
                        kpiPlanTwo.LoadPanel(overallData);
                        activeTemplate = kpiPlanTwo;
                        break;
                    case 15:
                        KPIPurchTwoTemplate kpiPurchTwo = (KPIPurchTwoTemplate)e.Control;
                        kpiPurchTwo.LoadPanel(overallData);
                        activeTemplate = kpiPurchTwo;
                        break;
                    case 16:
                        KPIPurchSubTemplate kpiPurchSub = (KPIPurchSubTemplate)e.Control;
                        kpiPurchSub.LoadPanel(overallData);
                        activeTemplate = kpiPurchSub;
                        break;
                    case 17:
                        KPIPurchTotalTemplate kpiPurchTotal = (KPIPurchTotalTemplate)e.Control;
                        kpiPurchTotal.LoadPanel(overallData);
                        activeTemplate = kpiPurchTotal;
                        break;
                    case 18:
                        KPIPurchPlanTemplate kpiPurchPlan = (KPIPurchPlanTemplate)e.Control;
                        kpiPurchPlan.LoadPanel(overallData);
                        activeTemplate = kpiPurchPlan;
                        break;
                    case 19:
                        KPIOtherTemplate kpiOther = (KPIOtherTemplate)e.Control;
                        kpiOther.LoadPanel(overallData);
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
        private void LoadOverallTemplate(Performance page)
        {
            if (page == Performance.KPA)
            {
                activeSectionBtn = btn_kpaOverall;
                SetActiveSectionBtn(activeSectionBtn);
                lbl_Performance.Text = "KPA";
                lbl_Section.Text = "All";
                lbl_Category.Text = "All";
                MenuInFront = true;
                NewKPAOverall kpaOverall = new NewKPAOverall(overallData)
                {
                    Name = "Overall",
                    Dock = DockStyle.Fill
                };
                pnl_activePage.Controls.Add(kpaOverall);
                kpaOverall.BringToFront();
                pnl_NavigationPanelMax.BringToFront();
            }

            if (page == Performance.KPI)
            {
                activeSectionBtn = btn_kpiOverall;
                SetActiveSectionBtn(activeSectionBtn);
                lbl_Performance.Text = "KPI";
                lbl_Section.Text = "All";
                lbl_Category.Text = "All";
                MenuInFront = true;
                NewKPIOverall kpiOverall = new NewKPIOverall(overallData)
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
        /// Loads the data coming soon template.
        /// </summary>
        private void LoadDataComingSoonTemplate()
        {
            lbl_Section.Text = "N/A";
            lbl_Category.Text = "N/A";
            MenuInFront = true;
            DataComingSoon comingSoon = new DataComingSoon()
            {
                Name = "DataComingSoon",
                Dock = DockStyle.Fill
            };

            pnl_activePage.Controls.Add(comingSoon);
            comingSoon.BringToFront();
            pnl_NavigationPanelMax.BringToFront();
        }
    }
}