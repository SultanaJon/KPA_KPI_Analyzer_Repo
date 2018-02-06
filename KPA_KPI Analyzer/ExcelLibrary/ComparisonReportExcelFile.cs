namespace KPA_KPI_Analyzer.ExcelLibrary
{
    public enum Template
    {
        TemplateOne,
        TemplateTwo,
        TemplateThree,
        TemplateFour,
        TemplateFive
    }


    public sealed class ComparisonReportExcelFile : ExcelFile
    {

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
        public static Template ChosenTemplate { get; set; }




        /// <summary>
        /// The file path based on the chosen template
        /// </summary>
        public static string TemplateFilePath
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
        /// Customer Constructor
        /// </summary>
        /// <param name="template">The template the user is using</param>
        public ComparisonReportExcelFile(Template template)
        {
            switch (ChosenTemplate)
            {
                case Template.TemplateOne:
                    ChosenTemplate = Template.TemplateOne;
                    break;
                case Template.TemplateTwo:
                    ChosenTemplate = Template.TemplateTwo;
                    break;
                case Template.TemplateThree:
                    ChosenTemplate = Template.TemplateThree;
                    break;
                case Template.TemplateFour:
                    ChosenTemplate = Template.TemplateFour;
                    break;
                default: // Template five
                    ChosenTemplate = Template.TemplateFive;
                    break;
            }
        }




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
