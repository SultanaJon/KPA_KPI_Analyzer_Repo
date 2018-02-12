using OfficeOpenXml;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KPA_KPI_Analyzer.ExcelLibrary.ComparisonReportExcelFile;

namespace KPA_KPI_Analyzer.ExcelLibrary
{
    public partial class Exporter
    {
        private int row, col, colStart;

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
            FileInfo xlFileInfo = new FileInfo(xlFile.FileName);

            if (xlFileInfo.Exists)
                xlFileInfo.Delete();

            using (ExcelPackage xlPackage = new ExcelPackage(xlFileInfo))
            {
                ExcelWorksheet xlWorksheet = xlPackage.Workbook.Worksheets.Add("Sheet1");
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
        public async Task ExportOverall(OverallExcelFile xlFile)
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
        /// 
        /// </summary>
        /// <param name="xlFile"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void ExportComparisonReport(ComparisonReportExcelFile xlFile)
        {
            FileInfo fileInfo = new FileInfo(xlFile.TemplateFilePath);

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                // Get the worksheet based on the excel file sheet name
                worksheet = package.Workbook.Worksheets.SingleOrDefault(x => x.Name == xlFile.SheetName);

                // Populate the report information
                worksheet.Cells[(int)ReportInformationCellPosition.FilterRow, (int)ReportInformationCellPosition.ValueColumnPosition].Value = xlFile.Filter;
                worksheet.Cells[(int)ReportInformationCellPosition.CountryRow, (int)ReportInformationCellPosition.ValueColumnPosition].Value = xlFile.Country;
                worksheet.Cells[(int)ReportInformationCellPosition.ReportGenerationRow, (int)ReportInformationCellPosition.ValueColumnPosition].Value = xlFile.ReportGenerationDate;


                // Populate the correct comparison report template.
                switch (xlFile.ChosenTemplate)
                {
                    case Reporting.TemplateTypes.Template.TemplateOne:
                        ExportComparisonTemplateOne();
                        break;
                    case Reporting.TemplateTypes.Template.TemplateTwo:
                        ExportComparisonTemplateTwo();
                        break;
                    case Reporting.TemplateTypes.Template.TemplateThree:
                        ExportComparisonTemplateThree();
                        break;
                    case Reporting.TemplateTypes.Template.TemplateFour:
                        ExportComparisonTemplateFour();
                        break;
                    case Reporting.TemplateTypes.Template.TemplateFive:
                        ExportComparisonTemplateFive();
                        break;
                    default:
                        break;
                }


                try
                {
                    // Open the updated excel file so the user can view it
                    FileInfo tempOverallFileInfo = new FileInfo(ComparisonReportFilePath);
                    package.SaveAs(tempOverallFileInfo);
                    OpenExcelFile(ComparisonReportFilePath);
                }
                catch(ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message, "Comparison Report Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (System.Security.SecurityException ex)
                {
                    MessageBox.Show(ex.Message, "Comparison Report Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Comparison Report Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message, "Comparison Report Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (PathTooLongException ex)
                {
                    MessageBox.Show(ex.Message, "Comparison Report Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (NotSupportedException ex)
                {
                    MessageBox.Show(ex.Message, "Comparison Report Export Error",    MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Please make sure the comparison report excel file is closed before running the report.", "Comparison Report Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }






        /// <summary>
        /// Opens the supplied excel file in a new process for viewing
        /// </summary>
        /// <param name="xlFile">The excel file</param>
        private void OpenExcelFile(string filePath)
        {
            try
            {
                Process excelProcess = new Process();
                excelProcess.StartInfo = new ProcessStartInfo(filePath);
                excelProcess.Start();
            }
            catch(ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Excel Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ObjectDisposedException ex)
            {
                MessageBox.Show(ex.Message, "Excel Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Excel Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message, "Excel Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}