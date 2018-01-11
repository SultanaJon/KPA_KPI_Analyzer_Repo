using Reporting.KeyPerformanceActions;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Reporting
{
    public class KpaReport : Report
    {
        /// <summary>
        /// Private instance of a KPA Report
        /// </summary>
        private static KpaReport kpaReportInstance = new KpaReport();


        /// <summary>
        /// Property to return the instance of the KPA Report
        /// </summary>
        public static KpaReport KpaReportInstance { get { return kpaReportInstance; } }



        /// <summary>
        /// Indicator of whether or not the report has been setup. This will make sure the
        /// report is not ran without it being setup.
        /// </summary>
        private bool ReportSetup { get; set; }


        /// <summary>
        /// The contents of the KPA Report
        /// </summary>
        Dictionary<string, List<KeyPerformanceAction>> report;


        /// <summary>
        /// Default Private Constructor
        /// </summary>
        private KpaReport()
        {
            report = new Dictionary<string, List<KeyPerformanceAction>>();
        }




        /// <summary>
        /// Creates a new instance of a KPA Report
        /// </summary>
        public static void CreateNewInstance()
        {
            // Creates a new instance of the report
            kpaReportInstance = new KpaReport();
        }



        /// <summary>
        /// Creates the KPA Report
        /// </summary>
        /// <param name="filters"></param>
        public void SetupReport(List<string> filters)
        {
            foreach(string filter in filters)
            {
                report.Add(filter, Actions);
            }

            // Mark the report as being setup.
            ReportSetup = true;
        }





        /// <summary>
        /// Runs the report based on the filter given
        /// </summary>
        public override void RunReport()
        {
            if(ReportSetup)
            {
                if (report.Count > 0)
                {
                    foreach (string filter in report.Keys)
                    {
                        foreach (KeyPerformanceAction action in report[filter])
                        {
                            action.RunSelectiveReport(filter);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("The KPA Report has not been set and cannot run.", "Report Setup Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
