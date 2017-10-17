using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;

namespace KPA_KPI_Analyzer.Export
{
    public class CreateExcelFile
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="excelFileName"></param>
        /// <returns></returns>
        public static void ExportToExcel(DataTable dt, string fileName)
        {
            System.IO.FileInfo exlFileInfo = new System.IO.FileInfo(fileName);

            if (exlFileInfo.Exists)
                exlFileInfo.Delete();

            using (ExcelPackage objExcelPackage = new ExcelPackage(exlFileInfo))
            {
                ExcelWorksheet exlWorksheet = objExcelPackage.Workbook.Worksheets.Add("Sheet1");
                exlWorksheet.Cells[1, 1].LoadFromDataTable(dt, true);
                objExcelPackage.Save();
            }
        }
    }
}
