using Reporting.Interfaces;
using Reporting.KeyPerformanceActions;
using Reporting.KeyPerformanceIndicators;
using Reporting.Reports;
using Reporting.TimeSpans.Templates;
using System.Collections.Generic;
using static KPA_KPI_Analyzer.ExcelLibrary.ComparisonReportExcelFile;

namespace KPA_KPI_Analyzer.ExcelLibrary
{
    public partial class Exporter
    {
        private bool reportInfoPrinted = false;
        private Dictionary<string, KeyPerformanceAction> kpaContent = new Dictionary<string, KeyPerformanceAction>();
        private Dictionary<string, KeyPerformanceIndicator> kpiContent = new Dictionary<string, KeyPerformanceIndicator>();




        /// <summary>
        /// prints the comparison report information
        /// </summary>
        /// <param name="_perf">The performance being targeted</param>
        /// <param name="_sec">The section the KPA or KPI belongs under.</param>
        /// <param name="_cat">The category the KPA or KPI belong under.</param>
        private void PrintReportInformation(string _perf, string _sec, string _cat)
        {
            worksheet.Cells[(int)ReportInformationCellPosition.PerformanceRow, (int)ReportInformationCellPosition.ValueColumnPosition].Value = _perf;
            worksheet.Cells[(int)ReportInformationCellPosition.SectionRow, (int)ReportInformationCellPosition.ValueColumnPosition].Value = _sec;
            worksheet.Cells[(int)ReportInformationCellPosition.CateogoryRow, (int)ReportInformationCellPosition.ValueColumnPosition].Value = _cat;
        }





        /// <summary>
        /// Get the template data from the one of the KPAs
        /// </summary>
        /// <param name="_fitler">the filter to access the KPA in the reports contents</param>
        /// <returns>Returns a list of formated strings containing the template data</returns>
        private List<string> GatherKpaTemplateData(string _filter)
        {
            // Get the template data from the KPA
            Template tempOneData = kpaContent[_filter].TemplateBlock;

            // Get the template data from the action
            List<string> tempData = new List<string>();
            tempData.Add(_filter);
            tempData.AddRange(tempOneData.GetTemplateData());

            // Return the list of data
            return tempData;
        }





        /// <summary>
        /// Get the template data from the one of the KPIs
        /// </summary>
        /// <param name="_fitler">the filter to access the KPI in the reports contents</param>
        /// <returns>Returns a list of formated strings containing the template data</returns>
        private List<string> GatherKpiTemplateData(string _filter)
        {
            // Get the template data from the KPA
            Template tempOneData = kpiContent[_filter].TemplateBlock;

            // Get the template data from the action
            List<string> tempData = new List<string>();
            tempData.Add(_filter);
            tempData.AddRange(tempOneData.GetTemplateData());

            // Return the list of data
            return tempData;
        }




        /// <summary>
        /// Prints the template data after cleaning to excel
        /// </summary>
        /// <param name="_templateData">The template containing the data form the KPA or KPI</param>
        private void PrintData(List<string> _templateData)
        {
            if (_templateData != null)
            {
                // We are starting at position 2 in the array because the first two value are the section and cateogory
                // The template already contains this data
                foreach (string data in _templateData)
                {
                    // if the value in the array is blank, move to the next index in the array
                    if (data == "")
                    {
                        // Increment the column and continue
                        ++col;
                        continue;
                    }

                    // Add the value to the cell
                    double n;
                    if (double.TryParse(data, out n))
                    {
                        worksheet.Cells[row, col].Value = n;
                    }
                    else
                    {
                        worksheet.Cells[row, col].Value = data;
                    }

                    // Increment the column position within the excel file
                    ++col;
                }
            }
        }



        /// <summary>
        /// Exports the template one data to excel
        /// </summary>
        private void ExportComparisonTemplateOne()
        {
            row = (int)TemplateOneCellPosition.RowStart;
            colStart = (int)TemplateOneCellPosition.ColumnStart;
            col = colStart;

            kpaContent = KpaComparisonReport.Content;

            foreach (string filter in kpaContent.Keys)
            {
                // If the report information has not been printed, print it.
                if (!reportInfoPrinted)
                {
                    PrintReportInformation(kpaContent[filter].Performance, kpaContent[filter].Section, kpaContent[filter].Name);
                    reportInfoPrinted = true;
                }


                // Insert a row into the data table
                worksheet.InsertRow(row, 1);

                // Make sure the action is from template one.
                if (kpaContent[filter].TemplateBlock is TemplateOne)
                {
                    // Get the template data from the KPA
                    List<string> templateData = GatherKpaTemplateData(filter);

                    if (kpiContent[filter] is IFavorable)
                        templateData.Add(string.Format("{0:n0}", (kpiContent[filter] as IFavorable).PercentFavorable + "%"));

                    // Remove any unwanted characters
                    CleanData(ref templateData);

                    // Print the data to excel
                    PrintData(templateData);
                }

                col = colStart;
                ++row;
            }
        }







        /// <summary>
        /// Exports the template two data to excel
        /// </summary>
        private void ExportComparisonTemplateTwo()
        {
            row = (int)TemplateTwoCellPosition.RowStart;
            colStart = (int)TemplateTwoCellPosition.ColumnStart;
            col = colStart;

            kpaContent = KpaComparisonReport.Content;

            foreach (string filter in kpaContent.Keys)
            {
                // If the report information has not been printed, print it.
                if (!reportInfoPrinted)
                {
                    PrintReportInformation(kpaContent[filter].Performance, kpaContent[filter].Section, kpaContent[filter].Name);
                    reportInfoPrinted = true;
                }

                // Insert a row into the data table
                worksheet.InsertRow(row, 1);

                // Make sure the action is from template one.
                if (kpaContent[filter].TemplateBlock is TemplateTwo)
                {
                    // Get the template data from the KPA
                    List<string> templateData = GatherKpaTemplateData(filter);

                    // Every KPA in this template has a favorable percentage.
                    templateData.Add(string.Format("{0:n0}", (kpaContent[filter] as IFavorable).PercentFavorable + "%"));

                    // Remove any unwanted characters
                    CleanData(ref templateData);

                    // Print the data to excel
                    PrintData(templateData);
                }

                col = colStart;
                ++row;
            }
        }






        /// <summary>
        /// Exports the template three data to excel
        /// </summary>
        private void ExportComparisonTemplateThree()
        {
            row = (int)TemplateThreeCellPosition.RowStart;
            colStart = (int)TemplateThreeCellPosition.ColumnStart;
            col = colStart;

            kpiContent = KpiComparisonReport.Content;

            foreach (string filter in kpiContent.Keys)
            {
                // If the report information has not been printed, print it.
                if (!reportInfoPrinted)
                {
                    PrintReportInformation(kpiContent[filter].Performance, kpiContent[filter].Section, kpiContent[filter].Name);
                    reportInfoPrinted = true;
                }


                // Insert a row into the data table
                worksheet.InsertRow(row, 1);

                // Make sure the action is from template one.
                if (kpiContent[filter].TemplateBlock is TemplateThree)
                {
                    // Get the template data from the KPA
                    List<string> templateData = GatherKpiTemplateData(filter);

                    if (kpiContent[filter] is IUnconfirmed)
                        templateData.Add((kpiContent[filter] as IUnconfirmed).PercentUnconfirmed.ToString());
                    else
                        templateData.Add("");


                    if (kpiContent[filter] is IFavorable)
                    {
                        templateData.Add((kpiContent[filter] as IFavorable).PercentFavorable.ToString());
                    }

                    // Remove any unwanted characters
                    CleanData(ref templateData);

                    // Print the data to excel
                    PrintData(templateData);
                }

                col = colStart;
                ++row;
            }
        }





        /// <summary>
        /// Exports the template four data to excel
        /// </summary>
        private void ExportComparisonTemplateFour()
        { 
            row = (int)TemplateFourCellPosition.RowStart;
            colStart = (int)TemplateFourCellPosition.ColumnStart;
            col = colStart;

            kpiContent = KpiComparisonReport.Content;

            foreach (string filter in kpiContent.Keys)
            {
                // If the report information has not been printed, print it.
                if (!reportInfoPrinted)
                {
                    PrintReportInformation(kpiContent[filter].Performance, kpiContent[filter].Section, kpiContent[filter].Name);
                    reportInfoPrinted = true;
                }

                // Insert a row into the data table
                worksheet.InsertRow(row, 1);

                // Make sure the action is from template one.
                if (kpiContent[filter].TemplateBlock is TemplateFour)
                {
                    // Get the template data from the KPA
                    List<string> templateData = GatherKpiTemplateData(filter);

                    if (kpiContent[filter] is IUnconfirmed)
                    {
                        templateData.Add(string.Format("{0:n0}", (kpiContent[filter] as IUnconfirmed).PercentUnconfirmed + "%"));
                    }

                    // Remove any unwanted characters
                    CleanData(ref templateData);

                    // Print the data to excel
                    PrintData(templateData);
                }

                col = colStart;
                ++row;
            }
        }





        /// <summary>
        /// Exports the template five data to excel
        /// </summary>
        private void ExportComparisonTemplateFive()
        {
            row = (int)TemplateFiveCellPosition.RowStart;
            colStart = (int)TemplateFiveCellPosition.ColumnStart;
            col = colStart;

            kpiContent = KpiComparisonReport.Content;

            foreach (string filter in kpiContent.Keys)
            {
                // If the report information has not been printed, print it.
                if (!reportInfoPrinted)
                {
                    PrintReportInformation(kpiContent[filter].Performance, kpiContent[filter].Section, kpiContent[filter].Name);
                    reportInfoPrinted = true;
                }

                // Insert a row into the data table
                worksheet.InsertRow(row, 1);

                // Make sure the action is from template one.
                if (kpiContent[filter].TemplateBlock is TemplateFive)
                {
                    // Get the template data from the KPA
                    List<string> templateData = GatherKpiTemplateData(filter);

                    // Remove any unwanted characters
                    CleanData(ref templateData);

                    // Print the data to excel
                    PrintData(templateData);
                }

                col = colStart;
                ++row;
            }
        }
    }
}
