using System;

namespace KPA_KPI_Analyzer.Correlation
{
    public static class CorrelationSettings
    {
        /// <summary>
        /// Indicator of whether the user wants to filter by PR creation date.
        /// </summary>
        public static bool FilterByPrDate { get; set; }

        /// <summary>
        /// Indicator of whether the user wants to filter by PO Line Creation Date.
        /// </summary>
        public static bool FilterbyPoDate { get; set; }

        /// <summary>
        /// The from date within the PR Creation Date range.
        /// </summary>
        public static DateTime PrFromDate { get; set; }

        /// <summary>
        /// The to date within the PR Creation Date range.
        /// </summary>
        public static DateTime PrToDate { get; set; }

        /// <summary>
        /// The from date within the PO Line Creation Date range.
        /// </summary>
        public static DateTime PoFromDate { get; set; }

        /// <summary>
        /// The to date within the PO Line Creation Date Range
        /// </summary>
        public static DateTime PoToDate { get; set; }
    }
}
