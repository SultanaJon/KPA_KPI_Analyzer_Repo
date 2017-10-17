using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.Data;
using System.Diagnostics;

namespace DataExporter
{
    public class Exporter
    {
        #region PROPERTIES

        /// <summary>
        /// Indicator of whether or no the export process has been completed
        /// </summary>
        public static bool ExportProcessCompleted { get; set; }

        #endregion


        #region STATIC HELPER FUNCTIONS

        /// <summary>
        /// Exports the data the supplied data table to excel.
        /// </summary>
        /// <param name="dt">The table of data</param>
        /// <param name="xlFile">The excel file object</param>
        public static void Export(DataTable dt, ExcelFile xlFile)
        {
            System.IO.FileInfo xlFileInfo = new System.IO.FileInfo(xlFile.FileName);

            if (xlFileInfo.Exists)
                xlFileInfo.Delete();

            using (ExcelPackage xlPackage = new ExcelPackage(xlFileInfo))
            {
                ExcelWorksheet xlWorksheet = xlPackage.Workbook.Worksheets.Add(xlFile.SheetName);
                xlWorksheet.Cells[(int)ExcelFile.ColumnPosition.RowStartPosition, (int)ExcelFile.ColumnPosition.ColumnStartPosition].LoadFromDataTable(dt, xlFile.HasHeaders);
                xlPackage.Save();

                ExportProcessCompleted = true;
                // open the excel file just created in a new process
                OpenExcelFile(xlFile);
            }
        }


        /// <summary>
        /// Opens the supplied excel file in a new process for viewing
        /// </summary>
        /// <param name="xlFile">The excel file</param>
        private static void OpenExcelFile(ExcelFile xlFile)
        {
            Process excelProcess = new Process();
            excelProcess.StartInfo = new ProcessStartInfo(xlFile.FileName);
            excelProcess.Start();
        }

        #endregion
    }
}
