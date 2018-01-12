using Reporting.KeyPerformanceIndicators;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Reporting
{
    public class KpiReport : Report
    {
        /// <summary>
        /// A private instance of a KPI Report
        /// </summary>
        private static KpiReport kpiReportInstance = new KpiReport();


        /// <summary>
        /// A public property to get the instance of the KPI Report.
        /// </summary>
        public static KpiReport KpiReportInstance { get { return kpiReportInstance; } }


        /// <summary>
        /// Indicator of whether or not the report has been setup. This will make sure the
        /// report is not ran without it being setup.
        /// </summary>
        private bool ReportSetup { get; set; }


        /// <summary>
        /// The contents of the KPI Report
        /// </summary>
        Dictionary<string, List<KeyPerformanceIndicator>> report;


        /// <summary>
        /// Default Private Constructor
        /// </summary>
        private KpiReport()
        {
            report = new Dictionary<string, List<KeyPerformanceIndicator>>();
        }



        /// <summary>
        /// Creates a new instance of a KPA Report
        /// </summary>
        public static void CreateNewInstance()
        {
            // Creates a new instance of the report
            kpiReportInstance = new KpiReport();
        }




        /// <summary>
        /// Creates the KPA Report
        /// </summary>
        /// <param name="filters"></param>
        public void SetupReport(List<string> filters)
        {
            foreach (string filter in filters)
            {
                // Add the filter to the report and add a set of actions for it.
                report.Add(filter, GetIndicators());
            }

            // Mark the report as being setup.
            ReportSetup = true;
        }





        /// <summary>
        /// Runs the report based on the filter given
        /// </summary>
        public override void RunReport()
        {
            if (ReportSetup)
            {
                if (report.Count > 0)
                {
                    foreach (string filter in report.Keys)
                    {
                        foreach (KeyPerformanceIndicator action in report[filter])
                        {
                            action.RunSelectiveReport(filter);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("The KPI Report has not been set and cannot run.", "Report Setup Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
