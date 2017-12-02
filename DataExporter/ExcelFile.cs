namespace DataExporter
{
    public class ExcelFile
    {
        #region MEMBERS

        private static string overallTemplateFilePath = @"Resources\Reports\OverallTemplate.xlsx";
        private static string tempOverallFilePath = @"Resources\Reports\Overall.xlsx";
        #endregion



        #region PROPERTIES

        /// <summary>
        /// The name of the excel file
        /// </summary>
        public string FileName { get; set; }


        /// <summary>
        /// The name of the sheet within the excel file
        /// </summary>
        public string SheetName { get; set; }




        /// <summary>
        /// An indicator of whether or not the excel file should include headers
        /// </summary>
        public bool HasHeaders { get; set; }



        /// <summary>
        /// Information regarding the excel file to export
        /// </summary>
        public System.IO.FileInfo FileInfo { get; set; }



        /// <summary>
        /// The path of the overall.xlsx file
        /// </summary>
        public static string OverallTemplateFilePath { get { return overallTemplateFilePath; } }



        /// <summary>
        /// The path of the viewable overall file.
        /// </summary>
        public static string TempOverallFilePath { get { return tempOverallFilePath; } }




        /// <summary>
        /// The country that belongs with the data.
        /// </summary>
        public string Country { get; set; }


        /// <summary>
        /// The date the PRPO report loaded into the applicaiton was generated.
        /// </summary>
        public string PrpoGenerationDate { get; set; }

        #endregion



        #region ENUMERATION
        
        /// <summary>
        /// Indexers for the start position within the overall.xlsx file.
        /// </summary>
        public enum ValuesColumnPosition : byte
        {
            RowStartPosition = 1,
            ColumnStartPosition = 1
        }



        /// <summary>
        /// Indexers for cell positions within the KPA and KPI Overall summery sheets.
        /// </summary>
        public enum OverallCellPositions : byte
        {
            KpaOverallTempOneRowStartPosition = 2,
            KpaOverallTempOneColStartPosition = 4,
            KpaOverallTempOneMaxRow= 22,
            KpaOverallTempOneMaxCol = 13,

            KpaOverallTempTwoRowStartPosition = 25,
            KpaOverallTempTwoColStartPosition = 4,
            KpaOverallTempTwoMaxRow = 26,
            KpaOverallTempTwoMaxCol = 15,

            KpiOverallTempThreeRowStartPosition = 2,
            KpiOverallTempThreeColStartPosition = 4,
            KpiOverallTempThreeMaxRow = 10,
            KpiOverallTempThreeMaxCol = 16,

            KpiOverallTempFourRowStartPosition = 13,
            KpiOverallTempFourColStartPosition = 4,
            KpiOverallTempFourMaxRow = 21,
            KpiOverallTempFourMaxCol = 17,

            KpiOverallTempFiveRowStartPosition = 24,
            KpiOverallTempFiveColStartPosition = 4,
            KpiOverallTempFiveMaxRow = 28,
            KpiOverallTempFiveMaxCol = 15
        }




        /// <summary>
        /// An indexer for the sheets names within overall.xlsx.
        /// </summary>
        public enum OverallSheetNames
        {
            KPAOverall,
            KPIOverall
        }

        public static string[] overallSheetNames =
        {
            "KPA Overall",
            "KPI Overall"
        };


        public enum OverallDefaultSheetName
        {
            Default
        }


        public static string[] overallDefaultSheetNames =
        {
            "sheet1"
        };

        #endregion




        #region CONSTRUCTORS
        public ExcelFile(string fileName,  bool containsHeaders)
        {
            FileName = fileName;
            //SheetName = sheetName;
            SheetName = overallDefaultSheetNames[(int)OverallDefaultSheetName.Default];
            HasHeaders = containsHeaders;
            FileInfo = new System.IO.FileInfo(FileName);
        }

        #endregion
    }
}
