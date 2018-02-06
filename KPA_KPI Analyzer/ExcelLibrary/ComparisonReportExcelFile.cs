namespace KPA_KPI_Analyzer.ExcelLibrary
{
    public sealed class ComparisonReportExcelFile : ExcelFile
    {
        private static string comparisonTemplateOneFilePath = @"Resources\Reports\ComparisonReportOneTemplate.xlsx";
        private static string comparisonTemplateTwoFilePath = @"Resources\Reports\ComparisonReportTwoTemplate.xlsx";
        private static string comparisonTemplateThreeFilePath = @"Resources\Reports\ComparisonReportThreeTemplate.xlsx";
        private static string comparisonTemplateFourFilePath = @"Resources\Reports\ComparisonReportFourTemplate.xlsx";
        private static string comparisonTemplateFiveFilePath = @"Resources\Reports\ComparisonReportFiveTemplate.xlsx";


        public static string ComparisonTemplateOneFilePath { get { return comparisonTemplateOneFilePath; } }
        public static string ComparisonTemplateTwoFilePath { get { return comparisonTemplateTwoFilePath; } }
        public static string ComparisonTemplateThreeFilePath { get { return comparisonTemplateThreeFilePath; } }
        public static string ComparisonTemplateFourFilePath { get { return comparisonTemplateFourFilePath; } }
        public static string ComparisonTemplateFiveFilePath { get { return comparisonTemplateFiveFilePath; } }


        private static string comparisonReportFilePath = @"Resources\Reports\ComparisonReport.xlsx";



        /// <summary>
        /// Indexers for cell positions within the KPA and KPI Overall summery sheets.
        /// </summary>
        public enum TemplateOneCellPosition : byte
        {
            RowStart = 3,
            ColumnStart = 2,
            ColumnEnd = 11
        }

        /// <summary>
        /// Indexers for cell positions within the KPA and KPI Overall summery sheets.
        /// </summary>
        public enum TemplateTwoCellPosition : byte
        {
            RowStart = 3,
            ColumnStart = 2,
            ColumnEnd = 13
        }

        /// <summary>
        /// Indexers for cell positions within the KPA and KPI Overall summery sheets.
        /// </summary>
        public enum TemplateThreeCellPosition : byte
        {
            RowStart = 3,
            ColumnStart = 2,
            ColumnEnd = 14
        }

        /// <summary>
        /// Indexers for cell positions within the KPA and KPI Overall summery sheets.
        /// </summary>
        public enum TemplateFourCellPosition : byte
        {
            RowStart = 3,
            ColumnStart = 2,
            ColumnEnd = 15
        }

        /// <summary>
        /// Indexers for cell positions within the KPA and KPI Overall summery sheets.
        /// </summary>
        public enum TemplateFiveCellPosition : byte
        {
            RowStart = 3,
            ColumnStart = 2,
            ColumnEnd = 13
        }
    }
}
