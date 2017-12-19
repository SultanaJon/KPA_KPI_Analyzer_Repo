using System;

namespace KPA_KPI_Analyzer.ApplicationConfiguration
{
    public static class PRPOSettings
    {
        /// <summary>
        /// Based on changes within SAP, any PRPO report created before 12/8/2017 will not be accepted because the application
        /// uses fields that have been added tha
        /// </summary>
        public static DateTime ValidPrpoDate = new DateTime(2017, 12, 8);
    }
}
