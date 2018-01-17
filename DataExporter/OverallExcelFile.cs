namespace DataExporter
{

    /// <summary>
    /// An indexer for the sheets names within overall.xlsx.
    /// </summary>
    public enum OverallSheetNames
    {
        KPAOverall,
        KPIOverall
    }



    public sealed class OverallExcelFile : ExcelFile
    {
        /// <summary>
        /// The path to the overall template excel file. This file is only used as a template
        /// </summary>
        private static string overallTemplateFilePath = @"Resources\Reports\OverallTemplate.xlsx";



        /// <summary>
        /// The path of the overall excel file where the overall data will be outputed and the file that will be presented
        /// </summary>
        private static string temporaryOverallFilePath = @"Resources\Reports\Overall.xlsx";



        /// <summary>
        /// The path of the overall.xlsx file
        /// </summary>
        public static string OverallTemplateFilePath { get { return overallTemplateFilePath; } }



        /// <summary>
        /// The path of the viewable overall file.
        /// </summary>
        public static string TemporaryOverallFilePath { get { return temporaryOverallFilePath; } }



        /// <summary>
        /// The country that belongs with the data.
        /// </summary>
        public string Country { get; set; }



        /// <summary>
        /// The date the PRPO report loaded into the applicaiton was generated.
        /// </summary>
        public string PrpoGenerationDate { get; set; }



        /// <summary>
        /// The names of the sheets within the overall excel file
        /// </summary>
        public static string[] overallSheetNames =
        {
            "KPA Overall",
            "KPI Overall"
        };



        /// <summary>
        /// Indexers for cell positions within the KPA and KPI Overall summery sheets.
        /// </summary>
        public enum OverallCellPositions : byte
        {
            KpaOverallTempOneRowStartPosition = 2,
            KpaOverallTempOneColStartPosition = 4,
            KpaOverallTempOneMaxRow = 22,
            KpaOverallTempOneMaxCol = 13,

            KpaOverallTempTwoRowStartPosition = 25,
            KpaOverallTempTwoColStartPosition = 4,
            KpaOverallTempTwoMaxRow = 26,
            KpaOverallTempTwoMaxCol = 15,

            KpiOverallTempThreeRowStartPosition = 2,
            KpiOverallTempThreeColStartPosition = 4,
            KpiOverallTempThreeMaxRow = 11,
            KpiOverallTempThreeMaxCol = 16,

            KpiOverallTempFourRowStartPosition = 14,
            KpiOverallTempFourColStartPosition = 4,
            KpiOverallTempFourMaxRow = 22,
            KpiOverallTempFourMaxCol = 17,

            KpiOverallTempFiveRowStartPosition = 25,
            KpiOverallTempFiveColStartPosition = 4,
            KpiOverallTempFiveMaxRow = 29,
            KpiOverallTempFiveMaxCol = 15
        }
    }
}
