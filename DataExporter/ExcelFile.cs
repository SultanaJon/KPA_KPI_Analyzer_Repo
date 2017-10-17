using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

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


        #endregion



        #region ENUMERATION
        
        public enum ColumnPosition : byte
        {
            RowStartPosition = 1,
            ColumnStartPosition = 1
        }


        /// <summary>
        /// An indexer for default names of the excel file
        /// </summary>
        private enum DefaultSheetName
        {
            Sheet1
        }



        private enum DefaultFileName
        {
            Default
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
        public ExcelFile(string fileName, bool headers) : this(fileName, defaultSheetName[(int)DefaultSheetName.Sheet1], headers) { }
        public ExcelFile(string fileName) : this(fileName, defaultSheetName[(int)DefaultSheetName.Sheet1], false) { }

        #endregion
    }
}
