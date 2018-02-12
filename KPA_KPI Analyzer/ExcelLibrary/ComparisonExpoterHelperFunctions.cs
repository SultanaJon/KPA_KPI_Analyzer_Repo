using Reporting.Interfaces;
using Reporting.KeyPerformanceActions;
using Reporting.Reports;
using Reporting.TimeSpans.Templates;
using System.Collections.Generic;
using static KPA_KPI_Analyzer.ExcelLibrary.ComparisonReportExcelFile;

namespace KPA_KPI_Analyzer.ExcelLibrary
{
    public partial class Exporter
    {
        private void ExportComparisonTemplateOne()
        {
            row = (int)TemplateOneCellPosition.RowStart;
            colStart = (int)TemplateOneCellPosition.ColumnStart;
            col = colStart;

            Dictionary<string, KeyPerformanceAction> content = KpaComparisonReport.Content;

            foreach (string filter in content.Keys)
            {
                // Insert a row into the data table
                worksheet.InsertRow(row, 1);

                // Make sure the action is from template one.
                if (content[filter].TemplateBlock is TemplateOne)
                {
                    // Convert the action to a ITemplate interface
                    TemplateOne tempOneData = content[filter].TemplateBlock as TemplateOne;

                    // Get the template data from the action
                    List<string> tempData = new List<string>();
                    tempData.Add(filter);
                    tempData.AddRange(tempOneData.GetTemplateData());

                    if (content[filter] is IFavorable)
                        tempData.Add(string.Format("{0:n0}", (content[filter] as IFavorable).PercentFavorable + "%"));

                    // Remove any unwanted characters
                    CleanData(ref tempData);

                    if (tempData != null)
                    {
                        // We are starting at position 2 in the array because the first two value are the section and cateogory
                        // The template already contains this data
                        foreach (string data in tempData)
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

                col = colStart;
                ++row;
            }
        }


        private void ExportComparisonTemplateTwo()
        {
            row = (int)TemplateTwoCellPosition.RowStart;
            colStart = (int)TemplateTwoCellPosition.ColumnStart;
            col = colStart;

            Dictionary<string, KeyPerformanceAction> content = KpaComparisonReport.Content;

            foreach (string filter in content.Keys)
            {
                // Insert a row into the data table
                worksheet.InsertRow(row, 1);

                // Make sure the action is from template one.
                if (content[filter].TemplateBlock is TemplateTwo)
                {
                    // Convert the action to a ITemplate interface
                    TemplateTwo tempTwoData = content[filter].TemplateBlock as TemplateTwo;

                    // Get the template data from the action
                    List<string> tempData = new List<string>();
                    tempData.Add(filter);
                    tempData.AddRange(tempTwoData.GetTemplateData());
                    tempData.Add(string.Format("{0:n0}", (content[filter] as IFavorable).PercentFavorable + "%"));

                    // Remove any unwanted characters
                    CleanData(ref tempData);

                    if (tempData != null)
                    {
                        // We are starting at position 2 in the array because the first two value are the section and cateogory
                        // The template already contains this data
                        foreach (string data in tempData)
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

                col = colStart;
                ++row;
            }
        }


        private void ExportComparisonTemplateThree()
        {
            row = (int)TemplateThreeCellPosition.RowStart;
            colStart = (int)TemplateThreeCellPosition.ColumnStart;
            col = colStart;

            Dictionary<string, KeyPerformanceAction> content = KpaComparisonReport.Content;

            foreach (string filter in content.Keys)
            {
                // Insert a row into the data table
                worksheet.InsertRow(row, 1);

                // Make sure the action is from template one.
                if (content[filter].TemplateBlock is TemplateThree)
                {
                    // Convert the action to a ITemplate interface
                    TemplateThree tempThreeData = content[filter].TemplateBlock as TemplateThree;

                    // Get the template data from the action
                    List<string> tempData = new List<string>();
                    tempData.Add(filter);
                    tempData.AddRange(tempThreeData.GetTemplateData());

                    if (content[filter] is IUnconfirmed)
                        tempData.Add((content[filter] as IUnconfirmed).PercentUnconfirmed.ToString());
                    else
                        tempData.Add("");


                    if (content[filter] is IFavorable)
                    {
                        tempData.Add((content[filter] as IFavorable).PercentFavorable.ToString());
                    }


                    // Remove any unwanted characters
                    CleanData(ref tempData);

                    if (tempData != null)
                    {
                        // We are starting at position 2 in the array because the first two value are the section and cateogory
                        // The template already contains this data
                        foreach (string data in tempData)
                        {
                            // if the value in the array is blank, move to the next index in the array
                            if (data == "")
                            {
                                // Increment the column and continue
                                ++col;
                                continue;
                            }

                            // Add the value to the cel;
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

                col = colStart;
                ++row;
            }
        }


        private void ExportComparisonTemplateFour()
        { 
            row = (int)TemplateFourCellPosition.RowStart;
            colStart = (int)TemplateFourCellPosition.ColumnStart;
            col = colStart;

            Dictionary<string, KeyPerformanceAction> content = KpaComparisonReport.Content;

            foreach (string filter in content.Keys)
            {
                // Insert a row into the data table
                worksheet.InsertRow(row, 1);

                // Make sure the action is from template one.
                if (content[filter].TemplateBlock is TemplateFour)
                {
                    // Convert the action to a ITemplate interface
                    TemplateFour tempFourData = content[filter].TemplateBlock as TemplateFour;

                    // Get the template data from the action
                    List<string> tempData = new List<string>();
                    tempData.Add(filter);
                    tempData.AddRange(tempFourData.GetTemplateData());

                    if (content[filter] is IUnconfirmed)
                    {
                        tempData.Add(string.Format("{0:n0}", (content[filter] as IUnconfirmed).PercentUnconfirmed + "%"));
                    }

                    // Remove any unwanted characters
                    CleanData(ref tempData);

                    if (tempData != null)
                    {
                        // We are starting at position 2 in the array because the first two value are the section and cateogory
                        // The template already contains this data
                        foreach (string data in tempData)
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

                col = colStart;
                ++row;
            }
        }


        private void ExportComparisonTemplateFive()
        {
            row = (int)TemplateFiveCellPosition.RowStart;
            colStart = (int)TemplateFiveCellPosition.ColumnStart;
            col = colStart;

            Dictionary<string, KeyPerformanceAction> content = KpaComparisonReport.Content;

            foreach (string filter in content.Keys)
            {
                // Insert a row into the data table
                worksheet.InsertRow(row, 1);

                // Make sure the action is from template one.
                if (content[filter].TemplateBlock is TemplateFive)
                {
                    // Convert the action to a ITemplate interface
                    TemplateFive tempFiveData = content[filter].TemplateBlock as TemplateFive;

                    // Get the template data from the action
                    List<string> tempData = new List<string>();
                    tempData.Add(filter);
                    tempData.AddRange(tempFiveData.GetTemplateData());

                    // Remove any unwanted characters
                    CleanData(ref tempData);

                    if (tempData != null)
                    {
                        // We are starting at position 2 in the array because the first two value are the section and cateogory
                        // The template already contains this data
                        foreach (string data in tempData)
                        {
                            // if the value in the array is blank, move to the next index in the array
                            if (data == "")
                            {
                                // Increment the column and continue
                                ++col;
                                continue;
                            }

                            // Add the value to the cel;
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

                col = colStart;
                ++row;
            }
        }
    }
}
