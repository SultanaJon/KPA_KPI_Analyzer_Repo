using ApplicationIOLibarary.Interfaces;
using Newtonsoft.Json;
using Reporting.KeyPerformanceActions;
using Reporting.KeyPerformanceActions.FollowUp;
using Reporting.TimeSpans.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Reporting.Reports
{
    public class KpaOverallReport : Report, IStorable<KpaOverallReport>, ILoadable<KpaOverallReport>
    {
        /// <summary>
        /// Private instance of a KPA Report
        /// </summary>
        private static KpaOverallReport kpaOverallReportInstance;



        /// <summary>
        /// Property to return the instance of the KPA Report
        /// </summary>
        public static KpaOverallReport KpaOverallReportInstance
        {
            get
            {
                // Create a new instance if one does not exist
                if(kpaOverallReportInstance == null)
                {
                    kpaOverallReportInstance = new KpaOverallReport();
                }

                // Return the instance of the object
                return kpaOverallReportInstance;
            }
        }



        /// <summary>
        /// A list of Key Performance Actions (KPAs) used by reports
        /// </summary>
        public static List<KeyPerformanceAction> Actions { get; private set; }



        /// <summary>
        /// Default Private Constructor
        /// </summary>
        private KpaOverallReport()
        {
            // Get the actions for the report
            Actions = GetActions();
        }




        /// <summary>
        /// Creates a new instance of a KPA Report
        /// </summary>
        public static void CreateNewInstance()
        {
            // Creates a new instance of the report
            kpaOverallReportInstance = new KpaOverallReport();
        }





        /// <summary>
        /// Runs the overall report for all the Key Performance Actions (KPA)
        /// </summary>
        public void RunReport()
        {
            try
            {
                foreach(KeyPerformanceAction action in Actions)
                {
                    if (action is ConfirmedDateForUpcomingDeliveries)
                    {
                        continue;
                    }
                    else
                    {
                        action.Run();
                    }
                }

                // Get the lessThanZero data from Due Today or Late to confirmed
                int lessThanEqualToZero = ((Actions[(int)KpaOption.FollowUp_DueTodayOrLateToConfirmed] as DueTodayOrLateToConfirmed).TemplateBlock as TemplateOne).LessThanEqualToZeroDays;

                // supply Confirmed date for upcoming deliveries the above data
                (Actions[(int)KpaOption.FollowUp_ConfirmedDateForUpcomingDeliveries] as ConfirmedDateForUpcomingDeliveries).DueTodayLateToConfirmedLessThanZeroDueToday = lessThanEqualToZero;

                // Run the overall report for Follow up -> Confirmed Date for upcoming deliveries
                Actions[(int)KpaOption.FollowUp_ConfirmedDateForUpcomingDeliveries].Run();
            }
            catch(ObjectDisposedException)
            {
                MessageBox.Show("Object Disposed Exception Thrown", "KPI Overall Run Report Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception Thrown", "KPI Overall Run Report Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Argument Null Exception Thrown", "KPI Overall Run Report Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (AggregateException)
            {
                MessageBox.Show("Aggregate Exception Thrown", "KPI Overall Run Report Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        /// <summary>
        /// Deserializes the list of actions(strings) back into the list of actions for the report
        /// </summary>
        /// <param name="results">the list of action parsed from the json  file</param>
        private void DeserializeActions(string[] results)
        {
            foreach(KpaOption option in Enum.GetValues(typeof(KpaOption)))
            {
                switch (option)
                {
                    case KpaOption.Plan_PrsAgingNotReleased:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.Plan.PRsAgingNotReleased>(results[(int)option]);
                        break;
                    case KpaOption.Plan_MaterialDue:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.Plan.MaterialDue>(results[(int)option]);
                        break;
                    case KpaOption.Purch_PRsAgingReleased:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.Purch.PRsAgingReleased>(results[(int)option]);
                        break;
                    case KpaOption.Purch_PoFirstRelease:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.Purch.POFirstRelease>(results[(int)option]);
                        break;
                    case KpaOption.Purch_PoPrevRelease:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.Purch.POPrevRelease>(results[(int)option]);
                        break;
                    case KpaOption.Purch_NoConfirmation:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.Purch.NoConfirmations>(results[(int)option]);
                        break;
                    case KpaOption.PurchSub_PrReleaseToPoRelease:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.PurchSub.PRReleaseToPORelease>(results[(int)option]);
                        break;
                    case KpaOption.PurchSub_PoCreationToConfirmationEntry:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.PurchSub.POCreationToConfirmationEntry>(results[(int)option]);
                        break;
                    case KpaOption.PurchTotal_PrReleaseToConfirmationEntry:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.PurchTotal.PRReleaseToConfirmationEntry>(results[(int)option]);
                        break;
                    case KpaOption.FollowUp_ConfirmedDateVsPlanDate:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.FollowUp.ConfirmedDateVsPlanDate>(results[(int)option]);
                        break;
                    case KpaOption.FollowUp_ConfirmedDateForUpcomingDeliveries:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.FollowUp.ConfirmedDateForUpcomingDeliveries>(results[(int)option]);
                        break;
                    case KpaOption.FollowUp_DueTodayOrLateToConfirmed:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.FollowUp.DueTodayOrLateToConfirmed>(results[(int)option]);
                        break;
                    case KpaOption.HotJobs_PrsNotOnPo:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.HotJobs.PRsNotOnPO>(results[(int)option]);
                        break;
                    case KpaOption.HotJobs_NoConfirmations:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.HotJobs.NoConfirmations>(results[(int)option]);
                        break;
                    case KpaOption.HotJobs_LateToConfirmed:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.HotJobs.LateToConfirmed>(results[(int)option]);
                        break;
                    case KpaOption.ExcessStockStock_PrsAgingNotReleased:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.ExcessStockStock.PRsAgingNotReleased>(results[(int)option]);
                        break;
                    case KpaOption.ExcessStockStock_PrsAgingReleased:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.ExcessStockStock.PRsAgingReleased>(results[(int)option]);
                        break;
                    case KpaOption.ExcessStockStock_PoCreationTruDelivery:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.ExcessStockStock.POCreationThruDelivery>(results[(int)option]);
                        break;
                    case KpaOption.ExcessStockOpenOrders_PrsAgingNotReleased:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.ExcessStockOpenOrders.PRsAgingNotReleased>(results[(int)option]);
                        break;
                    case KpaOption.ExcessStockOpenOrders_PrsAgingReleased:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.ExcessStockOpenOrders.PRsAgingReleased>(results[(int)option]);
                        break;
                    case KpaOption.ExcessStockOpenOrders_PoCreationTruDelivery:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.ExcessStockOpenOrders.POCreationThruDelivery>(results[(int)option]);
                        break;
                    case KpaOption.CurrentPlanVsActual_CurrentPlanDateVsCurrentConfirmationDate:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.CurrentPlanVsActual.CurrentPlanDateVsCurrentConfirmationDate>(results[(int)option]);
                        break;
                    case KpaOption.CurrentPlanVsActual_CurrentPlanDateVsCurrentConfirmationDateForHotJobs:
                        Actions[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceActions.CurrentPlanVsActual.CurrentPlanDateVsCurrentConfirmationDateForHotJobs>(results[(int)option]);
                        break;
                }
            }
        }




        /// <summary>
        /// Loads the KPA Overall Report for either the United States or Mexico from external file to application
        /// </summary>
        /// <param name="_report">The report that needs to be loaded</param>
        public void Load()
        {
            string jsonString = string.Empty;

            try
            {
                if (ReportingCountry.TargetCountry == Country.UnitedStates)
                    jsonString = File.ReadAllText(ApplicationIOLibarary.ApplicationFiles.FileUtils.overallFiles[(int)ApplicationIOLibarary.ApplicationFiles.OverallFile.US_KPA_Overall]);
                else
                    jsonString = File.ReadAllText(ApplicationIOLibarary.ApplicationFiles.FileUtils.overallFiles[(int)ApplicationIOLibarary.ApplicationFiles.OverallFile.MX_KPA_Overall]);

                // Because the Actions are a list of Key Performance Actions, we cannot deserialize into
                // the list because KeyPerformanceAction is an abstract class and cannot be instantiated. 
                // We must get a list of objects and individually create the derived Key Performance Actions.
                var objects = JsonConvert.DeserializeObject<List<object>>(jsonString);
                var results = objects.Select(obj => JsonConvert.SerializeObject(obj)).ToArray();

                // Send the list of strings (action) to get deserialized back into the list of actions
                DeserializeActions(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Overall KPA Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        /// <summary>
        /// Saves the report to a local directory
        /// </summary>
        public void Save()
        {
            try
            {
                // Store the contents of the KPA Overall Report into a JSON string
                var jsonString = JsonConvert.SerializeObject(Actions);

                if (ReportingCountry.TargetCountry == Country.UnitedStates)
                {
                    File.WriteAllText(ApplicationIOLibarary.ApplicationFiles.FileUtils.overallFiles[(int)ApplicationIOLibarary.ApplicationFiles.OverallFile.US_KPA_Overall], jsonString);
                }
                else
                {
                    File.WriteAllText(ApplicationIOLibarary.ApplicationFiles.FileUtils.overallFiles[(int)ApplicationIOLibarary.ApplicationFiles.OverallFile.MX_KPA_Overall], jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Overall Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}