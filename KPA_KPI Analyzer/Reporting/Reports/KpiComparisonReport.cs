using KPA_KPI_Analyzer.Reporting;
using Reporting.KeyPerformanceIndicators;
using Reporting.TimeSpans.Templates;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Reporting.Reports
{
    public class KpiComparisonReport : Report
    {
        /// <summary>
        /// Private instance of a KPI Report
        /// </summary>
        private static KpiComparisonReport kpiComparisonReportInstance;



        /// <summary>
        /// Property to return the instance of the KPI Report
        /// </summary>
        public static KpiComparisonReport KpiComparisonReportInstance
        {
            get
            {
                // Create a new instance if one does not exist
                if (kpiComparisonReportInstance == null)
                {
                    kpiComparisonReportInstance = new KpiComparisonReport();
                }

                // Return the instance of the object
                return kpiComparisonReportInstance;
            }
        }




        /// <summary>
        /// The property to hold the structure of the report
        /// </summary>
        public TemplateTypes.Template TemplateStructure { get; private set; }



        /// <summary>
        /// A list of Key Performance Indicators (KPIs) used by reports
        /// </summary>
        public static Dictionary<string, KeyPerformanceIndicator> Content { get; private set; }



        /// <summary>
        /// Default Constructor
        /// </summary>
        public KpiComparisonReport()
        {

        }




        /// <summary>
        /// Creates a new instance of a KPI Report
        /// </summary>
        public static void CreateNewInstance()
        {
            // Creates a new instance of the report
            kpiComparisonReportInstance = new KpiComparisonReport();
        }





        /// <summary>
        /// Runs each KPI comparison calculation in a seperate thread.
        /// </summary>
        public void RunReport(Filters.FilterOptions.Options _option)
        {
            foreach (string key in Content.Keys)
            {
                Content[key].RunComparison(key, _option);
            }
        }



        /// <summary>
        /// Generates the report by applying the KPI to each filter
        /// </summary>
        /// <param name="filters">The list of filters the user wants to use in the report</param>
        /// <param name="_option">The KPI option to use in the report</param>
        public bool GenerateReport(List<string> filters, KpiOption _option)
        {
            bool result = true;
            Content = new Dictionary<string, KeyPerformanceIndicator>();

            try
            {
                foreach (string filter in filters)
                {
                    // Get the KPA the user would like to use
                    KeyPerformanceIndicator indicator = GetIndicator(_option);

                    // Get the structure type of the template being used.
                    TemplateStructure = GetTemplateStructure(indicator);

                    if (indicator != null)
                    {
                        // add the filter and the action to the dictionary
                        Content.Add(filter, indicator);
                    }
                    else
                    {
                        MessageBox.Show("An error occured while trying to get the KPA", "Comparison Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        result = false;
                    }
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Argument null exception was thrown", "Comparison Report Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Argument exception was thrown", "Comparison Report Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }

            // Return the result of the creation
            return result;
        }





        /// <summary>
        /// Get the type of structure based on the selected KPA
        /// </summary>
        /// <param name="_action">The selected KPA</param>
        /// <returns>The type of template structure</returns>
        private TemplateTypes.Template GetTemplateStructure(KeyPerformanceIndicator _indicator)
        {
            if (_indicator.TemplateBlock is ITemplateThree)
            {
                return TemplateTypes.Template.TemplateThree;
            }
            else if (_indicator.TemplateBlock is ITemplateFour)
            {
                return TemplateTypes.Template.TemplateFour;
            }
            else // ITemplateFive
            {
                return TemplateTypes.Template.TemplateFive;
            }
        }





        /// <summary>
        /// Get the KPI that the user would like to use as the base of the report
        /// </summary>
        /// <param name="_option">The KPI Option used to get the KPI</param>
        /// <returns>The KPI the user wants as the base of the report</returns>
        private KeyPerformanceIndicator GetIndicator(KpiOption _option)
        {
            KeyPerformanceIndicator indicator = null;
            switch (_option)
            {
                case KpiOption.Plan_CurrentPlanDateVsPrPlanDate:
                    indicator = new KeyPerformanceIndicators.Plan.CurrentPlanDateVsPRPlanDate();
                    break;
                case KpiOption.Plan_OrigPlanDateMinusPrFullReleaseDateVsCodedLead:
                    indicator = new KeyPerformanceIndicators.Plan.OriginalPlanDateTo2ndLvlReleaseDateVsCodedLead();
                    break;
                case KpiOption.Plan_CurrentPlanDateMinusPrFullReleaseDateVsCodedLead:
                    indicator = new KeyPerformanceIndicators.Plan.CurrentPlanDateTo2ndLvlReleaseDateVsCodedLead();
                    break;
                case KpiOption.Purch_InitialConfirmationDateVsPrPlanDate:
                    indicator = new KeyPerformanceIndicators.Purch.InitialConfirmationDateVsPRPlanDate();
                    break;
                case KpiOption.FollowUp_CurrentConfirmationDateVsInitialConfirmationDate:
                    indicator = new KeyPerformanceIndicators.FollowUp.CurrentConfirmationDateVsInitialConfirmationDate();
                    break;
                case KpiOption.FollowUp_FinalConfirmationDateVsInitialConfirmationDate:
                    indicator = new KeyPerformanceIndicators.FollowUp.FinalConfirmationDateVsFinalPlanDate();
                    break;
                case KpiOption.FollowUp_ReceiptDateVsCurrentPlanDate:
                    indicator = new KeyPerformanceIndicators.FollowUp.ReceiptDateVsCurrentPlanDate();
                    break;
                case KpiOption.FollowUp_ReceiptDateVsOriginalConfirmationDate:
                    indicator = new KeyPerformanceIndicators.FollowUp.ReceiptDateVsOriginalConfirmationDate();
                    break;
                case KpiOption.FollowUp_ReceiptDateVsCurrentConfirmationDate:
                    indicator = new KeyPerformanceIndicators.FollowUp.ReceiptDateVsCurrentConfirmationDate();
                    break;
                case KpiOption.PlanTwo_MaterialDueOriginalPlannedDate:
                    indicator = new KeyPerformanceIndicators.PlanTwo.MaterialDueOriginalPlannedDate();
                    break;
                case KpiOption.PlanTwo_MaterialDueFinalPlannedDate:
                    indicator = new KeyPerformanceIndicators.PlanTwo.MaterialDueFinalPlannedDate();
                    break;
                case KpiOption.PlanTwo_PrReleaseDateVsPrCreationDate:
                    indicator = new KeyPerformanceIndicators.PlanTwo.PrReleaseVsPrCreation();
                    break;
                case KpiOption.PurchTwo_PrFullyReleaseDateVsPoCreationDate:
                    indicator = new KeyPerformanceIndicators.PurchTwo.PR2ndLvlReleaseDateVsPOCreationDate();
                    break;
                case KpiOption.PurchTwo_PoCreationDateVsPoReleaseDate:
                    indicator = new KeyPerformanceIndicators.PurchTwo.POCreationDateVsPOReleaseDate();
                    break;
                case KpiOption.PurchTwo_PoReleaseDateVsPoConfirmationDate:
                    indicator = new KeyPerformanceIndicators.PurchTwo.POReleaseDateVsPOConfirmationDate();
                    break;
                case KpiOption.PurchSub_PrReleaseVsPoReleaseDate:
                    indicator = new KeyPerformanceIndicators.PurchSub.PRReleaseDateVsPOReleaseDate();
                    break;
                case KpiOption.PurchSub_PoCreationDateVsConfirmationEntryDate:
                    indicator = new KeyPerformanceIndicators.PurchSub.POCreationDateVsConfirmationEntry();
                    break;
                case KpiOption.PurchTotal_PrReleaseDateToConfirmationEntryDate:
                    indicator = new KeyPerformanceIndicators.PurchTotal.PRReleaseDateToConfirmationEntry();
                    break;
                case KpiOption.PurchPlan_PoReleaseVsPrDeliveryDate:
                    indicator = new KeyPerformanceIndicators.PurchPlan.POReleaseVsPRDeliveryDate();
                    break;
                case KpiOption.Other_PrsCreated:
                    indicator = new KeyPerformanceIndicators.Other.PRsCreated();
                    break;
                case KpiOption.Other_PrsReleased:
                    indicator = new KeyPerformanceIndicators.Other.PRsReleased();
                    break;
                case KpiOption.Other_TotalSpend:
                    indicator = new KeyPerformanceIndicators.Other.TotalSpend();
                    break;
                case KpiOption.Other_PrValueVsPoValue:
                    indicator = new KeyPerformanceIndicators.Other.PRValueVsPOValue();
                    break;
                case KpiOption.Other_HotJobPRs:
                    indicator = new KeyPerformanceIndicators.Other.HotJobPRs();
                    break;
                default:
                    break;
            }

            // Return the requested indicator
            return indicator;
        }
    }
}