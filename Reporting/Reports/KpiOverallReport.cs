using ApplicationIOLibarary.Interfaces;
using Newtonsoft.Json;
using Reporting.KeyPerformanceIndicators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Reporting.Reports
{
    public class KpiOverallReport : Report, IStorable<KpiOverallReport>, ILoadable<KpiOverallReport>
    {
        /// <summary>
        /// Private instance of a KPA Report
        /// </summary>
        private static KpiOverallReport kpiOverallReportInstance;





        /// <summary>
        /// Property to return the instance of the KPA Report
        /// </summary>
        public static KpiOverallReport KpiOverallReportInstance
        {
            get
            {
                if(kpiOverallReportInstance == null)
                {
                    kpiOverallReportInstance = new KpiOverallReport();
                }
                return kpiOverallReportInstance;
            }
        }






        /// <summary>
        /// A list of Key Performance Indicators (KPIs) used by report
        /// </summary>
        public static List<KeyPerformanceIndicator> Indicators { get; private set; }



        /// <summary>
        /// Default Private Constructor
        /// </summary>
        private KpiOverallReport()
        {
            // Get the actions for the report
            Indicators = GetIndicators();
        }




        /// <summary>
        /// Creates a new instance of a KPA Report
        /// </summary>
        public static void CreateNewInstance()
        {
            // Creates a new instance of the report
            kpiOverallReportInstance = new KpiOverallReport();
        }





        /// <summary>
        /// Runs the overall report for all the Key Performance Actions (KPA)
        /// </summary>
        public void RunReport()
        {
            try
            {
                foreach (KeyPerformanceIndicator indicator in Indicators)
                {
                    indicator.Run();
                }
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
        private void DeserializeIndicators(string[] results)
        {
            foreach (KpiOption option in Enum.GetValues(typeof(KpiOption)))
            {
                // Run again the specific KPI option
                switch (option)
                {
                    case KpiOption.Plan_CurrentPlanDateVsPrPlanDate:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.Plan.CurrentPlanDateVsPRPlanDate>(results[(int)option]);
                        break;
                    case KpiOption.Plan_OrigPlanDateMinusPrFullReleaseDateVsCodedLead:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.Plan.OriginalPlanDateTo2ndLvlReleaseDateVsCodedLead>(results[(int)option]);
                        break;
                    case KpiOption.Plan_CurrentPlanDateMinusPrFullReleaseDateVsCodedLead:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.Plan.CurrentPlanDateTo2ndLvlReleaseDateVsCodedLead>(results[(int)option]);
                        break;
                    case KpiOption.Purch_InitialConfirmationDateVsPrPlanDate:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.Purch.InitialConfirmationDateVsPRPlanDate>(results[(int)option]);
                        break;
                    case KpiOption.FollowUp_CurrentConfirmationDateVsInitialConfirmationDate:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.FollowUp.CurrentConfirmationDateVsInitialConfirmationDate>(results[(int)option]);
                        break;
                    case KpiOption.FollowUp_FinalConfirmationDateVsInitialConfirmationDate:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.FollowUp.FinalConfirmationDateVsFinalPlanDate>(results[(int)option]);
                        break;
                    case KpiOption.FollowUp_ReceiptDateVsCurrentPlanDate:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.FollowUp.ReceiptDateVsCurrentPlanDate>(results[(int)option]);
                        break;
                    case KpiOption.FollowUp_ReceiptDateVsOriginalConfirmationDate:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.FollowUp.ReceiptDateVsOriginalConfirmationDate>(results[(int)option]);
                        break;
                    case KpiOption.FollowUp_ReceiptDateVsCurrentConfirmationDate:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.FollowUp.ReceiptDateVsCurrentConfirmationDate>(results[(int)option]);
                        break;
                    case KpiOption.PlanTwo_MaterialDueOriginalPlannedDate:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.PlanTwo.MaterialDueOriginalPlannedDate>(results[(int)option]);
                        break;
                    case KpiOption.PlanTwo_MaterialDueFinalPlannedDate:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.PlanTwo.MaterialDueFinalPlannedDate>(results[(int)option]);
                        break;
                    case KpiOption.PurchTwo_PrFullyReleaseDateVsPoCreationDate:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.PurchTwo.PR2ndLvlReleaseDateVsPOCreationDate>(results[(int)option]);
                        break;
                    case KpiOption.PurchTwo_PoCreationDateVsPoReleaseDate:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.PurchTwo.POCreationDateVsPOReleaseDate>(results[(int)option]);
                        break;
                    case KpiOption.PurchTwo_PoReleaseDateVsPoConfirmationDate:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.PurchTwo.POReleaseDateVsPOConfirmationDate>(results[(int)option]);
                        break;
                    case KpiOption.PurchSub_PrReleaseVsPoReleaseDate:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.PurchSub.PRReleaseDateVsPOReleaseDate>(results[(int)option]);
                        break;
                    case KpiOption.PurchSub_PoCreationDateVsConfirmationEntryDate:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.PurchSub.POCreationDateVsConfirmationEntry>(results[(int)option]);
                        break;
                    case KpiOption.PurchTotal_PrReleaseDateToConfirmationEntryDate:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.PurchTotal.PRReleaseDateToConfirmationEntry>(results[(int)option]);
                        break;
                    case KpiOption.PurchPlan_PoReleaseVsPrDeliveryDate:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.PurchPlan.POReleaseVsPRDeliveryDate>(results[(int)option]);
                        break;
                    case KpiOption.Other_PrsCreated:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.Other.PRsCreated>(results[(int)option]);
                        break;
                    case KpiOption.Other_PrsReleased:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.Other.PRsReleased>(results[(int)option]);
                        break;
                    case KpiOption.Other_TotalSpend:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.Other.TotalSpend>(results[(int)option]);
                        break;
                    case KpiOption.Other_PrValueVsPoValue:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.Other.PRValueVsPOValue>(results[(int)option]);
                        break;
                    case KpiOption.Other_HotJobPRs:
                        Indicators[(int)option] = JsonConvert.DeserializeObject<KeyPerformanceIndicators.Other.HotJobPRs>(results[(int)option]);
                        break;
                    default:
                        throw new Exception();
                }
            }
        }




        /// <summary>
        /// Loads the KPI Overall Report for either the United States or Mexico from external file to application
        /// </summary>
        /// <param name="_report">The report that needs to be loaded</param>
        public void Load()
        {
            string jsonString = string.Empty;

            try
            {
                if (ReportingCountry.TargetCountry == Country.UnitedStates)
                    jsonString = File.ReadAllText(ApplicationIOLibarary.ApplicationFiles.FileUtils.overallFiles[(int)ApplicationIOLibarary.ApplicationFiles.OverallFile.US_KPI_Overall]);
                else
                    jsonString = File.ReadAllText(ApplicationIOLibarary.ApplicationFiles.FileUtils.overallFiles[(int)ApplicationIOLibarary.ApplicationFiles.OverallFile.MX_KPI_Overall]);

                // Because the Indicators are a list of Key Performance Indicators, we cannot deserialize into
                // the list because KeyPerformanceIndicator is an abstract class and cannot be instantiated. We must 
                // get a list of objects and individually create the derived Key Performance Indicators.
                var objects = JsonConvert.DeserializeObject<List<object>>(jsonString);
                var results = objects.Select(obj => JsonConvert.SerializeObject(obj)).ToArray();

                // Send the list of strings (action) to get deserialized back into the list of actions
                DeserializeIndicators(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Overall KPI Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        /// <summary>
        /// Saves the report to a local directory
        /// </summary>
        public void Save()
        {
            try
            {
                // store the contents of the KPI Overall Report into a JSON string
                var jsonString = JsonConvert.SerializeObject(Indicators);

                if (ReportingCountry.TargetCountry == Country.UnitedStates)
                {
                    File.WriteAllText(ApplicationIOLibarary.ApplicationFiles.FileUtils.overallFiles[(int)ApplicationIOLibarary.ApplicationFiles.OverallFile.US_KPI_Overall], jsonString);
                }
                else
                {
                    File.WriteAllText(ApplicationIOLibarary.ApplicationFiles.FileUtils.overallFiles[(int)ApplicationIOLibarary.ApplicationFiles.OverallFile.MX_KPI_Overall], jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Overall DataReader Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
