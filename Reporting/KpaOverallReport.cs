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

namespace Reporting
{
    public class KpaOverallReport : Report, IStorable, ILoadable
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
        /// The contents of the KPA Report
        /// </summary>
        List<KeyPerformanceAction> kpaOverallReport;




        /// <summary>
        /// Default Private Constructor
        /// </summary>
        private KpaOverallReport()
        {
            kpaOverallReport = new List<KeyPerformanceAction>();

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
        /// Creates the overall report
        /// </summary>
        public void CreateReport()
        {
            // Clear the report and add the actions to it
            kpaOverallReport.Clear();
            kpaOverallReport.AddRange(Actions);
        }




        /// <summary>
        /// Runs the overall report for all the Key Performance Actions (KPA)
        /// </summary>
        public override void RunReport()
        {
            foreach (KeyPerformanceAction action in kpaOverallReport)
            {
                // This KPA needs information from another KPA.
                if (action is ConfirmedDateForUpcomingDeliveries)
                    continue;

                // Run the KPAs Overall Report
                action.RunOverallReport();
            }

            // Get the lessThanZero data from Due Today or Late to confirmed
            int lessThanEqualToZero = (kpaOverallReport[(int)KpaOption.FollowUp_DueTodayOrLateToConfirmed] as DueTodayOrLateToConfirmed).LessThanEqualToZeroDays;

            // supply Confirmed date for upcoming deliveries the above data
            (kpaOverallReport[(int)KpaOption.FollowUp_ConfirmedDateForUpcomingDeliveries] as ConfirmedDateForUpcomingDeliveries).DueTodayLateToConfirmedLessThanZeroDueToday = lessThanEqualToZero;

            // Run the overall report for Follow up -> Confirmed Date for upcoming deliveries
            kpaOverallReport[(int)KpaOption.FollowUp_ConfirmedDateForUpcomingDeliveries].RunOverallReport();
        }




        /// <summary>
        /// Loads the KPA Overall Report for either the United States or Mexico from external file to application
        /// </summary>
        /// <param name="_report">The report that needs to be loaded</param>
        public void Load()
        {
            dataJSONString = string.Empty;
            ser = new System.Web.Script.Serialization.JavaScriptSerializer();

            try
            {
                if (ReportingCountry.TargetCountry == Country.UnitedStates)
                    dataJSONString = File.ReadAllText(ApplicationIOLibarary.ApplicationFiles.FileUtils.overallFiles[(int)ApplicationIOLibarary.ApplicationFiles.OverallFile.US_KPA_Overall]);
                else
                    dataJSONString = File.ReadAllText(ApplicationIOLibarary.ApplicationFiles.FileUtils.overallFiles[(int)ApplicationIOLibarary.ApplicationFiles.OverallFile.MX_KPA_Overall]);

                kpaOverallReport = ser.Deserialize<List<KeyPerformanceAction>>(dataJSONString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Overall Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Saves the report to a local directory
        /// </summary>
        public void Save()
        {
            dataJSONString = string.Empty;
            ser = new System.Web.Script.Serialization.JavaScriptSerializer();

            try
            {
                // Store the contents of the KPA Overall Report Instance
                dataJSONString = ser.Serialize(kpaOverallReport);
                if (ReportingCountry.TargetCountry == Country.UnitedStates)
                {
                    File.WriteAllText(ApplicationIOLibarary.ApplicationFiles.FileUtils.overallFiles[(int)ApplicationIOLibarary.ApplicationFiles.OverallFile.US_KPA_Overall], dataJSONString);
                }
                else
                {
                    File.WriteAllText(ApplicationIOLibarary.ApplicationFiles.FileUtils.overallFiles[(int)ApplicationIOLibarary.ApplicationFiles.OverallFile.MX_KPA_Overall], dataJSONString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Overall Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}