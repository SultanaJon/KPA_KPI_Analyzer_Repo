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
        private static string comparisonTemplateOneFilePath = @"Resources\Reports\ComparisonReportOneTemplate.xlsx";
        private static string comparisonTemplateTwoFilePath = @"Resources\Reports\ComparisonReportTwoTemplate.xlsx";
        private static string comparisonTemplateThreeFilePath = @"Resources\Reports\ComparisonReportThreeTemplate.xlsx";
        private static string comparisonTemplateFourFilePath = @"Resources\Reports\ComparisonReportFourTemplate.xlsx";
        private static string comparisonTemplateFiveFilePath = @"Resources\Reports\ComparisonReportFiveTemplate.xlsx";
        private static string comparisonReportFilePath = @"Resources\Reports\ComparisonReport.xlsx";


        public static Template ChosenTemplate { get; set; }

        public static string TemplateFilePath
        {
            get
            {
                switch(ChosenTemplate)
                {
                    case Template.TemplateOne:
                        return comparisonTemplateOneFilePath;
                    case Template.TemplateTwo:
                        return comparisonTemplateOneFilePath;
                    case Template.TemplateThree:
                        return comparisonTemplateOneFilePath;
                    case Template.TemplateFour:
                        return comparisonTemplateOneFilePath;
                    default: // Template five
                        return comparisonTemplateOneFilePath;
                }
            }
        }




        public static string ComparisonReportFilePath { get { return comparisonReportFilePath; } }




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
