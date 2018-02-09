using KPA_KPI_Analyzer.Reporting;

namespace KPA_KPI_Analyzer.ExcelLibrary
{
    public sealed class ComparisonReportExcelFile : ExcelFile
    {
        public string Filter { get; set; }
        public string Performance { get; set; }
        public string Section { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }
        public string ReportGenerationDate { get; set; }




        /// <summary>
        /// 
        /// </summary>
        private static string[] templateFilePaths =
        {
            @"Resources\Reports\ComparisonReportOneTemplate.xlsx",
            @"Resources\Reports\ComparisonReportTwoTemplate.xlsx",
            @"Resources\Reports\ComparisonReportThreeTemplate.xlsx",
            @"Resources\Reports\ComparisonReportFourTemplate.xlsx",
            @"Resources\Reports\ComparisonReportFiveTemplate.xlsx",
        };
        



        /// <summary>
        /// 
        /// </summary>
        public TemplateTypes.Template ChosenTemplate { get; private set; }




        /// <summary>
        /// The file path based on the chosen template
        /// </summary>
        public string TemplateFilePath
        {
            get
            {
                return templateFilePaths[(int)ChosenTemplate];
            }
        }



        /// <summary>
        /// The file path of the comparison report
        /// </summary>
        public static string ComparisonReportFilePath { get { return @"Resources\Reports\ComparisonReport.xlsx"; } }




        public enum ReportInformationCellPosition
        {
            FilterRow = 4,
            PerformanceRow = 5,
            SectionRow = 6,
            CateogoryRow = 7,
            CountryRow = 8,
            ReportGenerationRow = 9,
            ValueColumnPosition = 4
        }




        /// <summary>
        /// Indexers for cell positions within the KPA and KPI Overall summery sheets.
        /// </summary>
        public enum TemplateOneCellPosition : byte
        {
            RowStart = 12,
            ColumnStart = 2,
            ColumnEnd = 12
        }

        /// <summary>
        /// Indexers for cell positions within the KPA and KPI Overall summery sheets.
        /// </summary>
        public enum TemplateTwoCellPosition : byte
        {
            RowStart = 12,
            ColumnStart = 2,
            ColumnEnd = 14
        }

        /// <summary>
        /// Indexers for cell positions within the KPA and KPI Overall summery sheets.
        /// </summary>
        public enum TemplateThreeCellPosition : byte
        {
            RowStart = 12,
            ColumnStart = 2,
            ColumnEnd = 15
        }

        /// <summary>
        /// Indexers for cell positions within the KPA and KPI Overall summery sheets.
        /// </summary>
        public enum TemplateFourCellPosition : byte
        {
            RowStart = 12,
            ColumnStart = 2,
            ColumnEnd = 16
        }

        /// <summary>
        /// Indexers for cell positions within the KPA and KPI Overall summery sheets.
        /// </summary>
        public enum TemplateFiveCellPosition : byte
        {
            RowStart = 12,
            ColumnStart = 2,
            ColumnEnd = 14
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="_templateStructure"></param>
        public ComparisonReportExcelFile(TemplateTypes.Template _templateStructure)
        {
            SheetName = "Sheet1";
            ChosenTemplate = _templateStructure;
        }
    }
}
