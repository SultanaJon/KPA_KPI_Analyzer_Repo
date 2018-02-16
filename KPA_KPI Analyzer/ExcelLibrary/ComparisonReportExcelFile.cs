using KPA_KPI_Analyzer.Reporting;

namespace KPA_KPI_Analyzer.ExcelLibrary
{
    public sealed class ComparisonReportExcelFile : ExcelFile
    {
        /// <summary>
        /// The filter the user is reunning the report against
        /// </summary>
        public string Filter { get; set; }


        /// <summary>
        /// The performance the category falls under (either KPA or KPI)
        /// </summary>
        public string Performance { get; set; }


        /// <summary>
        /// The section the category falls under
        /// </summary>
        public string Section { get; set; }


        /// <summary>
        /// The category the user is running the report against
        /// </summary>
        public string Category { get; set; }


        /// <summary>
        /// The country the data is from
        /// </summary>
        public string Country { get; set; }


        /// <summary>
        /// The date the comparison report was ran (this will always be today's date)
        /// </summary>
        public string ReportGenerationDate { get; set; }



        /// <summary>
        /// The file paths to all of the templates
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
        /// The template type the category belongs to
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



        /// <summary>
        /// The cell positions of the report information
        /// </summary>
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
            RowStart =    12,
            ColumnStart = 2,
            ColumnEnd =   12
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
        /// Custom Constructor
        /// </summary>
        /// <param name="_templateStructure">The template structure being targeted (based on the category chosen for the report)</param>
        public ComparisonReportExcelFile(TemplateTypes.Template _templateStructure)
        {
            SheetName = "Sheet1";
            ChosenTemplate = _templateStructure;
        }
    }
}
