using Reporting;
using System;

namespace KPA_KPI_Analyzer.ExcelFiles
{
    public class PrpoExcelFile
    {
        /// <summary>
        /// The path of the excel file
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The date of the excel file was generated
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The country that this excel file is associated with.
        /// </summary>
        public Country AssociatedCountry { get; set; }
    }
}
