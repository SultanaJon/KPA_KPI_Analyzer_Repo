using ApplicationIOLibarary.Interfaces;
using Newtonsoft.Json;
using Reporting.KeyPerformanceActions;
using Reporting.TimeSpans.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reporting.Reports
{
    public class KpaComparisonReport : Report
    {
        /// <summary>
        /// Private instance of a KPA Report
        /// </summary>
        private static KpaComparisonReport kpaComparisonReportInstance;



        /// <summary>
        /// Property to return the instance of the KPA Report
        /// </summary>
        public static KpaComparisonReport KpaComparisonReportInstance
        {
            get
            {
                // Create a new instance if one does not exist
                if (kpaComparisonReportInstance == null)
                {
                    kpaComparisonReportInstance = new KpaComparisonReport();
                }

                // Return the instance of the object
                return kpaComparisonReportInstance;
            }
        }



        /// <summary>
        /// A list of Key Performance Actions (KPAs) used by reports
        /// </summary>
        public static Dictionary<string, KeyPerformanceAction> Contents { get; private set; }





        /// <summary>
        /// Default Private Constructor
        /// </summary>
        private KpaComparisonReport()
        {
            
        }




        /// <summary>
        /// Creates a new instance of a KPA Report
        /// </summary>
        public static void CreateNewInstance()
        {
            // Creates a new instance of the report
            kpaComparisonReportInstance = new KpaComparisonReport();
        }





        /// <summary>
        /// Starts calculating the KPA
        /// </summary>
        public void RunReport(Filters.FilterOptions.Options _option)
        {
            foreach(string filter in Contents.Keys)
            {
                Contents[filter].RunComparison(filter, _option);
            }
        }




        /// <summary>
        /// Generates the report by applying the KPA to each filter
        /// </summary>
        /// <param name="filters">The list of filters the user wants to use in the report</param>
        /// <param name="_option">The KPA option to use in the report</param>
        public bool GenerateReport(List<string> filters, KpaOption _option)
        {
            bool result = true;
            Contents = new Dictionary<string, KeyPerformanceAction>();

            try
            {
                foreach (string filter in filters)
                {
                    // Get the KPA the user would like to use
                    KeyPerformanceAction action = GetAction(_option);

                    if (action != null)
                    {
                        // add the filter and the action to the dictionary
                        Contents.Add(filter, action);
                    }
                    else
                    {
                        MessageBox.Show("An error occured while trying to get the KPA", "Comparison Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        result = false;
                    }
                }
            }
            catch(ArgumentNullException)
            {
                MessageBox.Show("Argument null exception was thrown", "Comparison Report Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Argument exception was thrown", "Comparison Report Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }

            // Return the result of the creation
            return result;
        }





        /// <summary>
        /// Get the KPA that the user would like to use as the base of the report
        /// </summary>
        /// <param name="_option">The KPA Option used to get the KPA</param>
        /// <returns>The KPA the user wants as the base of the report</returns>
        private KeyPerformanceAction GetAction(KpaOption _option)
        {
            KeyPerformanceAction action = null;
            switch (_option)
            {
                case KpaOption.Plan_PrsAgingNotReleased:
                    action = new KeyPerformanceActions.Plan.PRsAgingNotReleased();
                    break;
                case KpaOption.Plan_MaterialDue:
                    action = new KeyPerformanceActions.Plan.MaterialDue();
                    break;
                case KpaOption.Purch_PRsAgingReleased:
                    action = new KeyPerformanceActions.Purch.PRsAgingReleased();
                    break;
                case KpaOption.Purch_PoFirstRelease:
                    action = new KeyPerformanceActions.Purch.POFirstRelease();
                    break;
                case KpaOption.Purch_PoPrevRelease:
                    action = new KeyPerformanceActions.Purch.POPrevRelease();
                    break;
                case KpaOption.Purch_NoConfirmation:
                    action = new KeyPerformanceActions.Purch.NoConfirmations();
                    break;
                case KpaOption.PurchSub_PrReleaseToPoRelease:
                    action = new KeyPerformanceActions.PurchSub.PRReleaseToPORelease();
                    break;
                case KpaOption.PurchSub_PoCreationToConfirmationEntry:
                    action = new KeyPerformanceActions.PurchSub.POCreationToConfirmationEntry();
                    break;
                case KpaOption.PurchTotal_PrReleaseToConfirmationEntry:
                    action = new KeyPerformanceActions.PurchTotal.PRReleaseToConfirmationEntry();
                    break;
                case KpaOption.FollowUp_ConfirmedDateVsPlanDate:
                    action = new KeyPerformanceActions.FollowUp.ConfirmedDateVsPlanDate();
                    break;
                case KpaOption.FollowUp_ConfirmedDateForUpcomingDeliveries:
                    action = new KeyPerformanceActions.FollowUp.ConfirmedDateForUpcomingDeliveries();
                    break;
                case KpaOption.FollowUp_DueTodayOrLateToConfirmed:
                    action = new KeyPerformanceActions.FollowUp.DueTodayOrLateToConfirmed();
                    break;
                case KpaOption.HotJobs_PrsNotOnPo:
                    action = new KeyPerformanceActions.HotJobs.PRsNotOnPO();
                    break;
                case KpaOption.HotJobs_NoConfirmations:
                    action = new KeyPerformanceActions.HotJobs.NoConfirmations();
                    break;
                case KpaOption.HotJobs_LateToConfirmed:
                    action = new KeyPerformanceActions.HotJobs.LateToConfirmed();
                    break;
                case KpaOption.ExcessStockStock_PrsAgingNotReleased:
                    action = new KeyPerformanceActions.ExcessStockStock.PRsAgingNotReleased();
                    break;
                case KpaOption.ExcessStockStock_PrsAgingReleased:
                    action = new KeyPerformanceActions.ExcessStockStock.PRsAgingReleased();
                    break;
                case KpaOption.ExcessStockStock_PoCreationTruDelivery:
                    action = new KeyPerformanceActions.ExcessStockStock.POCreationThruDelivery();
                    break;
                case KpaOption.ExcessStockOpenOrders_PrsAgingNotReleased:
                    action = new KeyPerformanceActions.ExcessStockOpenOrders.PRsAgingNotReleased();
                    break;
                case KpaOption.ExcessStockOpenOrders_PrsAgingReleased:
                    action = new KeyPerformanceActions.ExcessStockOpenOrders.PRsAgingReleased();
                    break;
                case KpaOption.ExcessStockOpenOrders_PoCreationTruDelivery:
                    action = new KeyPerformanceActions.ExcessStockOpenOrders.POCreationThruDelivery();
                    break;
                case KpaOption.CurrentPlanVsActual_CurrentPlanDateVsCurrentConfirmationDate:
                    action = new KeyPerformanceActions.CurrentPlanVsActual.CurrentPlanDateVsCurrentConfirmationDate();
                    break;
                case KpaOption.CurrentPlanVsActual_CurrentPlanDateVsCurrentConfirmationDateForHotJobs:
                    action = new KeyPerformanceActions.CurrentPlanVsActual.CurrentPlanDateVsCurrentConfirmationDateForHotJobs();
                    break;
                default:
                    break;
            }

            // Return the requested action
            return action;
        }
    }
}
