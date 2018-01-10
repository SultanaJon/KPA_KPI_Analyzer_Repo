using Reporting.KeyPerformanceActions;
using Reporting.KeyPerformanceActions.FollowUp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationIOLibarary.Interfaces;
using Newtonsoft.Json;

namespace Reporting
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
        /// Default Private Constructor
        /// </summary>
        private KpaOverallReport()
        {
            // Check if any other report have already created the actions
            if (!ActionsSet)
            {
                // Add the Key Performance Actions to the report
                AddActions();
                ActionsSet = true;
            }
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
        /// Builds the KPA report so it can be created (calculated)
        /// </summary>
        private void AddActions()
        {
            KeyPerformanceAction action = new KeyPerformanceActions.Plan.PRsAgingNotReleased();
            Actions.Add(action);
            Actions.Add(new KeyPerformanceActions.Plan.MaterialDue());
            Actions.Add(new KeyPerformanceActions.Purch.PRsAgingReleased());
            Actions.Add(new KeyPerformanceActions.Purch.POFirstRelease());
            Actions.Add(new KeyPerformanceActions.Purch.POPrevRelease());
            Actions.Add(new KeyPerformanceActions.Purch.NoConfirmations());
            Actions.Add(new KeyPerformanceActions.PurchSub.PRReleaseToPORelease());
            Actions.Add(new KeyPerformanceActions.PurchSub.POCreationToConfirmationEntry());
            Actions.Add(new KeyPerformanceActions.PurchTotal.PRReleaseToConfirmationEntry());
            Actions.Add(new KeyPerformanceActions.FollowUp.ConfirmedDateVsPlanDate());
            Actions.Add(new KeyPerformanceActions.FollowUp.ConfirmedDateForUpcomingDeliveries());
            Actions.Add(new KeyPerformanceActions.FollowUp.DueTodayOrLateToConfirmed());
            Actions.Add(new KeyPerformanceActions.HotJobs.PRsNotOnPO());
            Actions.Add(new KeyPerformanceActions.HotJobs.NoConfirmations());
            Actions.Add(new KeyPerformanceActions.HotJobs.LateToConfirmed());
            Actions.Add(new KeyPerformanceActions.ExcessStockStock.PRsAgingNotReleased());
            Actions.Add(new KeyPerformanceActions.ExcessStockStock.PRsAgingReleased());
            Actions.Add(new KeyPerformanceActions.ExcessStockStock.POCreationThruDelivery());
            Actions.Add(new KeyPerformanceActions.ExcessStockOpenOrders.PRsAgingNotReleased());
            Actions.Add(new KeyPerformanceActions.ExcessStockOpenOrders.PRsAgingReleased());
            Actions.Add(new KeyPerformanceActions.ExcessStockOpenOrders.POCreationThruDelivery());
            Actions.Add(new KeyPerformanceActions.CurrentPlanVsActual.CurrentPlanDateVsCurrentConfirmationDate());
            Actions.Add(new KeyPerformanceActions.CurrentPlanVsActual.CurrentPlanDateVsCurrentConfirmationDateForHotJobs());
        }





        /// <summary>
        /// Runs the overall report for all the Key Performance Actions (KPA)
        /// </summary>
        public override void RunReport()
        {
            foreach (KeyPerformanceAction action in Actions)
            {
                // This KPA needs information from another KPA.
                if (action is ConfirmedDateForUpcomingDeliveries)
                    continue;

                // Run the KPAs Overall Report
                action.RunOverallReport();
            }

            // Get the lessThanZero data from Due Today or Late to confirmed
            int lessThanEqualToZero = (Actions[(int)KpaOption.FollowUp_DueTodayOrLateToConfirmed] as DueTodayOrLateToConfirmed).LessThanEqualToZeroDays;

            // supply Confirmed date for upcoming deliveries the above data
            (Actions[(int)KpaOption.FollowUp_ConfirmedDateForUpcomingDeliveries] as ConfirmedDateForUpcomingDeliveries).DueTodayLateToConfirmedLessThanZeroDueToday = lessThanEqualToZero;

            // Run the overall report for Follow up -> Confirmed Date for upcoming deliveries
            Actions[(int)KpaOption.FollowUp_ConfirmedDateForUpcomingDeliveries].RunOverallReport();
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

                // Load the JSON data into the reporting Actions
                kpaOverallReportInstance = JsonConvert.DeserializeObject<KpaOverallReport>(jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Overall Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var jsonString = JsonConvert.SerializeObject(this);

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