using OfficeOpenXml;
using System.Data;
using System.IO;
using System.Linq;

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
        public static void ExportData(DataTable dt, ExcelFile xlFile)
        {
            System.IO.FileInfo xlFileInfo = new System.IO.FileInfo(xlFile.FileName);

            if (xlFileInfo.Exists)
                xlFileInfo.Delete();

            using (ExcelPackage xlPackage = new ExcelPackage(xlFileInfo))
            {
                ExcelWorksheet xlWorksheet = xlPackage.Workbook.Worksheets.Add(xlFile.SheetName);
                xlWorksheet.Cells[(int)CellStartPosition.RowStartPosition, (int)CellStartPosition.ColumnStartPosition].LoadFromDataTable(dt, xlFile.HasHeaders);
                xlPackage.Save();

                ExportProcessCompleted = true;
                // open the excel file just created in a new process
                OpenExcelFile(xlFile.FileName);
            }
        }






        /// <summary>
        /// Exports the overall data to the overall excel file located in resources -> reports Overall.xlsx
        /// </summary>
        public static void ExportOverall()
        {
            FileInfo fileInfo = new FileInfo(ExcelFile.OverallTemplateFilePath);
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets.SingleOrDefault(x => x.Name == ExcelFile.overallSheetNames[(int)ExcelFile.OverallSheetNames.KPAOverall]);
                workSheet.Cells[1, 1].Value = "KPA Overall Summery - " + country + " - " + date;

                // OUTPUT TO KPA SHEET \\
                // Handle tempOne data
                int row = (int)ExcelFile.OverallCellPositions.KpaOverallTempOneRowStartPosition;
                int colStart = (int)ExcelFile.OverallCellPositions.KpaOverallTempOneColStartPosition;
                int col = colStart;

                foreach (List<string> listRow in tempOne)
                {
                    if (listRow != null)
                    {
                        foreach (string str in listRow)
                        {
                            workSheet.Cells[row, col].Value = double.Parse(str);
                            ++col;
                        }
                    }

                    col = colStart;
                    ++row;
                }


                // Handle tempTwo data
                row = (int)ExcelFile.OverallCellPositions.KpaOverallTempTwoRowStartPosition;
                colStart = (int)ExcelFile.OverallCellPositions.KpaOverallTempTwoColStartPosition;
                col = colStart;
                foreach (List<string> listRow in tempTwo)
                {
                    if (listRow != null)
                    {
                        foreach (string str in listRow)
                        {
                            workSheet.Cells[row, col].Value = double.Parse(str);
                            ++col;
                        }
                    }

                    col = colStart;
                    ++row;
                }



                // OUTPUT TO KPI SHEET \\
                workSheet = package.Workbook.Worksheets.SingleOrDefault(x => x.Name == ExcelFile.overallSheetNames[(int)ExcelFile.OverallSheetNames.KPIOverall]);
                workSheet.Cells[1, 1].Value = "KPI Overall Summery - " + country + " - " + date;

                // Handle tempThree data
                row = (int)ExcelFile.OverallCellPositions.KpiOverallTempThreeRowStartPosition;
                colStart = (int)ExcelFile.OverallCellPositions.KpiOverallTempThreeColStartPosition;
                col = colStart;
                foreach (List<string> listRow in tempThree)
                {
                    if (listRow != null)
                    {
                        foreach (string str in listRow)
                        {
                            workSheet.Cells[row, col].Value = double.Parse(str);
                            ++col;
                        }
                    }

                    col = colStart;
                    ++row;
                }


                // Handle tempFour data
                row = (int)ExcelFile.OverallCellPositions.KpiOverallTempFourRowStartPosition;
                colStart = (int)ExcelFile.OverallCellPositions.KpiOverallTempFourColStartPosition;
                col = colStart;
                foreach (List<string> listRow in tempFour)
                {
                    if (listRow != null)
                    {
                        foreach (string str in listRow)
                        {
                            workSheet.Cells[row, col].Value = double.Parse(str);
                            ++col;
                        }
                    }

                    col = colStart;
                    ++row;
                }


                // Handle tempFive data
                row = (int)ExcelFile.OverallCellPositions.KpiOverallTempFiveRowStartPosition;
                colStart = (int)ExcelFile.OverallCellPositions.KpiOverallTempFiveColStartPosition;
                col = colStart;
                foreach (List<string> listRow in tempFive)
                {
                    if (listRow != null)
                    {
                        foreach (string str in listRow)
                        {
                            workSheet.Cells[row, col].Value = double.Parse(str);
                            ++col;
                        }
                    }

                    col = colStart;
                    ++row;
                }

                FileInfo tempOverallFileInfo = new FileInfo(ExcelFile.TempOverallFilePath);
                package.SaveAs(tempOverallFileInfo);
                OpenExcelFile(ExcelFile.TempOverallFilePath);
            }
        }






        /// <summary>
        /// Opens the supplied excel file in a new process for viewing
        /// </summary>
        /// <param name="xlFile">The excel file</param>
        private static void OpenExcelFile(string filePath)
        {
            Process excelProcess = new Process();
            excelProcess.StartInfo = new ProcessStartInfo(filePath);
            excelProcess.Start();
        }

        #endregion
    }
}