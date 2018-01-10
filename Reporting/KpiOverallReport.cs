using Reporting.KeyPerformanceIndicators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationIOLibarary.Interfaces;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Reporting
{
    public class KpiOverallReport : Report, IStorable, ILoadable
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
        /// The contents of the KPA Report
        /// </summary>
        List<KeyPerformanceIndicator> kpiOverallReport;


        /// <summary>
        /// Default Private Constructor
        /// </summary>
        private KpiOverallReport()
        {
            kpiOverallReport = new List<KeyPerformanceIndicator>();

            // Check if any other report have already created the actions
            if (!IndicatorsSet)
            {
                // Add the Key Performance Actions to the report
                AddIndicators();
                IndicatorsSet = true;
            }
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
        /// Builds the KPA report so it can be created (calculated)
        /// </summary>
        private void AddIndicators()
        {
            Indicators.Add(new KeyPerformanceIndicators.Plan.CurrentPlanDateVsPRPlanDate());
            Indicators.Add(new KeyPerformanceIndicators.Plan.OriginalPlanDateTo2ndLvlReleaseDateVsCodedLead());
            Indicators.Add(new KeyPerformanceIndicators.Plan.CurrentPlanDateTo2ndLvlReleaseDateVsCodedLead());
            Indicators.Add(new KeyPerformanceIndicators.FollowUp.CurrentConfirmationDateVsInitialConfirmationDate());
            Indicators.Add(new KeyPerformanceIndicators.FollowUp.FinalConfirmationDateVsFinalPlanDate());
            Indicators.Add(new KeyPerformanceIndicators.FollowUp.ReceiptDateVsCurrentPlanDate());
            Indicators.Add(new KeyPerformanceIndicators.FollowUp.ReceiptDateVsOriginalConfirmationDate());
            Indicators.Add(new KeyPerformanceIndicators.Purch.InitialConfirmationDateVsPRPlanDate());
            Indicators.Add(new KeyPerformanceIndicators.FollowUp.ReceiptDateVsCurrentConfirmationDate());
            Indicators.Add(new KeyPerformanceIndicators.PlanTwo.MaterialDueOriginalPlannedDate());
            Indicators.Add(new KeyPerformanceIndicators.PlanTwo.MaterialDueFinalPlannedDate());
            Indicators.Add(new KeyPerformanceIndicators.PurchTwo.PR2ndLvlReleaseDateVsPOCreationDate());
            Indicators.Add(new KeyPerformanceIndicators.PurchTwo.POCreationDateVsPOReleaseDate());
            Indicators.Add(new KeyPerformanceIndicators.PurchTwo.POReleaseDateVsPOConfirmationDate());
            Indicators.Add(new KeyPerformanceIndicators.PurchSub.PRReleaseDateVsPOReleaseDate());
            Indicators.Add(new KeyPerformanceIndicators.PurchSub.POCreationDateVsConfirmationEntry());
            Indicators.Add(new KeyPerformanceIndicators.PurchTotal.PRReleaseDateToConfirmationEntry());
            Indicators.Add(new KeyPerformanceIndicators.PurchPlan.POReleaseVsPRDeliveryDate());
            Indicators.Add(new KeyPerformanceIndicators.Other.PRsCreated());
            Indicators.Add(new KeyPerformanceIndicators.Other.PRsReleased());
            Indicators.Add(new KeyPerformanceIndicators.Other.TotalSpend());
            Indicators.Add(new KeyPerformanceIndicators.Other.PRValueVsPOValue());
            Indicators.Add(new KeyPerformanceIndicators.Other.HotJobPRs());
        }




        /// <summary>
        /// Creates the overall report
        /// </summary>
        public void CreateReport()
        {
            // Clear the report and add the actions to it
            kpiOverallReport.Clear();
            kpiOverallReport.AddRange(Indicators);
        }




        /// <summary>
        /// Runs the overall report for all the Key Performance Actions (KPA)
        /// </summary>
        public override void RunReport()
        {
            foreach (KeyPerformanceIndicator indicator in kpiOverallReport)
            {
                // The the KPIs Overall Report
                indicator.RunOverallReport();
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

                kpiOverallReport = JsonConvert.DeserializeObject<List<KeyPerformanceIndicator>>(jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Overall DataReader Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var jsonString = JsonConvert.SerializeObject(kpiOverallReport);

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
