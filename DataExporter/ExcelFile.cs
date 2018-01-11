using System.IO;

namespace DataExporter
{
    /// <summary>
    /// Indexers for the Excel file cell start positions
    /// </summary>
    public enum CellStartPosition : byte
    {
        RowStartPosition = 1,
        ColumnStartPosition = 1
    }

    public abstract class ExcelFile
    {
        /// <summary>
        /// The name of the excel file
        /// </summary>
        public string FileName { get; set; }



        /// <summary>
        /// The name of the sheet within the excel file
        /// </summary>
        public string[] SheetNames { get; set; }



        /// <summary>
        /// An indicator of whether or not the excel file should include headers
        /// </summary>
        public bool[] ContainsHeaders { get; set; }



        /// <summary>
        /// Information regarding the excel file to export
        /// </summary>
        public FileInfo FileInfo { get; set; }


 
        /// <summary>
        /// Interanl Default Constructor
        /// </summary>
        internal ExcelFile()
        {

        }
    }
}
