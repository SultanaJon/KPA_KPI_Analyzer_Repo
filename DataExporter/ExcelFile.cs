namespace DataExporter
{
    public class ExcelFile
    {
        #region MEMBERS

        public static string[] defaultSheetName =
        {
            "Sheet1"
        };

        public static string[] defaultFileNames =
        {
            "DefaultFileName"
        };

        public static string[] overallSheetNames =
        {
            "KPA Overall",
            "KPI Overall"
        };


        private static string overallFilePath = @"Resources\Reports\Overall.xlsx";

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


        public static string OverallFilePath { get { return overallFilePath; } }

        #endregion



        #region ENUMERATION
        
        /// <summary>
        /// 
        /// </summary>
        public enum DataColumnPosition : byte
        {
            RowStartPosition = 1,
            ColumnStartPosition = 1
        }



        /// <summary>
        /// 
        /// </summary>
        public enum OverallCellPositions : byte
        {
            KpaOverallTempOneRowStartPosition = 2,
            KpaOverallTempOneColStartPosition = 4,
            KpaOverallTempOneMaxRow= 28,
            KpaOverallTempOneMaxCol = 12,

            KpaOverallTempTwoRowStartPosition = 30,
            KpaOverallTempTwoColStartPosition = 4,
            KpaOverallTempTwoMaxRow = 31,
            KpaOverallTempTwoMaxCol = 14,

            KpiOverallTempThreeRowStartPosition = 2,
            KpiOverallTempThreeColStartPosition = 4,
            KpiOverallTempThreeMaxRow = 11,
            KpiOverallTempThreeMaxCol = 15,

            KpiOverallTempFourRowStartPosition = 13,
            KpiOverallTempFourColStartPosition = 4,
            KpiOverallTempFourMaxRow = 24,
            KpiOverallTempFourMaxCol = 17,

            KpiOverallTempFiveRowStartPosition = 26,
            KpiOverallTempFiveColStartPosition = 4,
            KpiOverallTempFiveMaxRow = 30,
            KpiOverallTempFiveMaxCol = 16
        }





        /// <summary>
        /// An indexer for default names of the excel file
        /// </summary>
        private enum DefaultDataSheetName
        {
            Sheet1
        }


        /// <summary>
        /// 
        /// </summary>
        private enum DefaultDataFileName
        {
            Default
        }

        /// <summary>
        /// 
        /// </summary>
        public enum OverallSheetNames
        {
            KPAOverall,
            KPIOverall
        }



        #endregion




        #region CONSTRUCTORS
        public ExcelFile(string fileName, string sheetName, bool containsHeaders)
        {
            FileName = fileName;
            SheetName = sheetName;
            HasHeaders = containsHeaders;
            FileInfo = new System.IO.FileInfo(FileName);
        }

        public ExcelFile(string fileName, string sheetName) : this(fileName, sheetName, false) { }
        public ExcelFile(string fileName, bool headers) : this(fileName, defaultSheetName[(int)DefaultDataSheetName.Sheet1], headers) { }
        public ExcelFile(string fileName) : this(fileName, defaultSheetName[(int)DefaultDataSheetName.Sheet1], false) { }

        #endregion
    }
}
