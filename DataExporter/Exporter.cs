using OfficeOpenXml;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataExporter
{
    public partial class Exporter
    {

        /// <summary>
        /// The worksheet of the excel file
        /// </summary>
        private ExcelWorksheet worksheet;




        /// <summary>
        /// Indicator of whether or no the export process has been completed
        /// </summary>
        public static bool ExportProcessCompleted { get; set; }



        /// <summary>
        /// Exports the data the supplied data table to excel.
        /// </summary>
        /// <param name="dt">The table of data</param>
        /// <param name="xlFile">The excel file object</param>
        public void ExportData(DataTable dt, RawDataExcelFile xlFile)
        {
            System.IO.FileInfo xlFileInfo = new System.IO.FileInfo(xlFile.FileName);

            if (xlFileInfo.Exists)
                xlFileInfo.Delete();

            using (ExcelPackage xlPackage = new ExcelPackage(xlFileInfo))
            {
                ExcelWorksheet xlWorksheet = xlPackage.Workbook.Worksheets.Add(xlFile.SheetName);
                xlWorksheet.Cells[(int)CellStartPosition.RowStartPosition, (int)CellStartPosition.ColumnStartPosition].LoadFromDataTable(dt, xlFile.ContainsHeaders);
                xlPackage.Save();

                ExportProcessCompleted = true;
                // open the excel file just created in a new process
                OpenExcelFile(xlFile.FileName);
            }
        }






        /// <summary>
        /// Exports the overall data to the overall excel file located in resources -> reports Overall.xlsx
        /// </summary>
        public async void ExportOverall(OverallExcelFile xlFile)
        {
            FileInfo fileInfo = new FileInfo(OverallExcelFile.OverallTemplateFilePath);
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                // Change the worksheet of the overall excel file to the KPA sheet
                worksheet = package.Workbook.Worksheets.SingleOrDefault(x => x.Name == OverallExcelFile.overallSheetNames[(int)OverallSheetNames.KPAOverall]);
                worksheet.Cells[1, 1].Value = "KPA Overall Summery - " + xlFile.Country + " - " + xlFile.PrpoGenerationDate;

                // Start a new task to export the KPA overall data
                Task kpaOverallTask = new Task(ExportKpaOverallData);
                kpaOverallTask.Start();

                // Wait until the KPA overall data has been exported
                await kpaOverallTask;

                // Change the worksheet of the overall excel file to the KPI sheet
                worksheet = package.Workbook.Worksheets.SingleOrDefault(x => x.Name == OverallExcelFile.overallSheetNames[(int)OverallSheetNames.KPIOverall]);
                worksheet.Cells[1, 1].Value = "KPI Overall Summery - " + xlFile.Country + " - " + xlFile.PrpoGenerationDate;

                // Start a new task to export the KPA overall data
                Task kpiOverallTask = new Task(ExportKpiOverallData);
                kpiOverallTask.Start();

                // Wait until the KPA overall data has been exported
                await kpiOverallTask;

                // Open the updated excel file so the user can view it
                FileInfo tempOverallFileInfo = new FileInfo(OverallExcelFile.TemporaryOverallFilePath);
                package.SaveAs(tempOverallFileInfo);
                OpenExcelFile(OverallExcelFile.TemporaryOverallFilePath);
            }
        }






        /// <summary>
        /// Opens the supplied excel file in a new process for viewing
        /// </summary>
        /// <param name="xlFile">The excel file</param>
        private void OpenExcelFile(string filePath)
        {
            Process excelProcess = new Process();
            excelProcess.StartInfo = new ProcessStartInfo(filePath);
            excelProcess.Start();
        }
    }
}