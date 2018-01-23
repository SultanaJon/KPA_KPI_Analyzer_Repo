using Reporting.Interfaces;
using Reporting.KeyPerformanceActions;
using Reporting.KeyPerformanceIndicators;
using Reporting.Reports;
using Reporting.TimeSpans.Templates;
using System.Collections.Generic;

namespace DataExporter
{
    public partial class Exporter
    {
        /// <summary>
        /// Export the KPA overall data to excel
        /// </summary>
        private void ExportKpaOverallData()
        {
            // Export the overall template one data
            ExportTemplateOneData();

            // Export the overall template two data
            ExportTemplateTwoData();
        }




        /// <summary>
        /// Export the KPI overall data to excel
        /// </summary>
        private void ExportKpiOverallData()
        {
            // Export the overall template one data
            ExportTemplateThreeData();

            // Export the overall template two data
            ExportTemplateFourData();

            // Export the overall template two data
            ExportTemplateFiveData();
        }




        /// <summary>
        /// Cleans the data of any values that might cause an exception to be thrown
        /// when adding the data to excel as doubles.
        /// </summary>
        private void CleanData(ref List<string> _data)
        {
            int index = 0;

            for(int j = 0; j < _data.Count; ++j)
            {
                if(_data[j].Contains("%"))
                {
                    index = _data[j].IndexOf("%");
                    _data[j] = _data[j].Remove(index, 1);
                }

                if (_data[j].Contains("$"))
                {
                    index = _data[j].IndexOf("$");
                    _data[j] = _data[j].Remove(index, 1);
                }
            }
        }





        /// <summary>
        /// Export the data from KPAs template one to excel
        /// </summary>
        private void ExportTemplateOneData()
        {
            int row = (int)OverallExcelFile.OverallCellPositions.KpaOverallTempOneRowStartPosition;
            int colStart = (int)OverallExcelFile.OverallCellPositions.KpaOverallTempOneColStartPosition;
            int col = colStart;

            foreach (KeyPerformanceAction action in KpaOverallReport.Actions)
            {
                // Make sure the action is from template one.
                if(action.TemplateBlock is TemplateOne)
                {
                    // Convert the action to a ITemplate interface
                    TemplateOne tempOneData = action.TemplateBlock as TemplateOne;

                    // Get the template data from the action
                    List<string> tempData = tempOneData.GetTemplateData();

                    if(action is IFavorable) 
                        tempData.Add(string.Format("{0:n0}", (action as IFavorable).PercentFavorable + "%"));

                    // Remove any unwanted characters
                    CleanData(ref tempData);

                    if (tempData != null)
                    {
                        // We are starting at position 2 in the array because the first two value are the section and cateogory
                        // The template already contains this data
                        foreach(string data in tempData)
                        {
                            // if the value in the array is blank, move to the next index in the array
                            if (data == "")
                            {
                                // Increment the column and continue
                                ++col;
                                continue;
                            }

                            // Add the value to the cel
                            worksheet.Cells[row, col].Value = double.Parse(data);

                            // Increment the column position within the excel file
                            ++col;
                        }
                    }
                }

                col = colStart;
                ++row;
            }
        }





        /// <summary>
        /// Export the data from KPAs template two to excel
        /// </summary>
        private void ExportTemplateTwoData()
        {
            int row = (int)OverallExcelFile.OverallCellPositions.KpaOverallTempTwoRowStartPosition;
            int colStart = (int)OverallExcelFile.OverallCellPositions.KpaOverallTempTwoColStartPosition;
            int col = colStart;


            foreach (KeyPerformanceAction action in KpaOverallReport.Actions)
            {
                // Make sure the action is from template one.
                if (action.TemplateBlock is TemplateTwo)
                {
                    // Convert the action to a ITemplate interface
                    TemplateTwo tempTwoData = action.TemplateBlock as TemplateTwo;

                    // Get the template data from the action
                    List<string> tempData = tempTwoData.GetTemplateData();
                    tempData.Add(string.Format("{0:n0}", (action as IFavorable).PercentFavorable + "%"));

                    // Remove any unwanted characters
                    CleanData(ref tempData);

                    if (tempData != null)
                    {
                        // We are starting at position 2 in the array because the first two value are the section and cateogory
                        // The template already contains this data
                        foreach(string data in tempData)
                        {
                            // if the value in the array is blank, move to the next index in the array
                            if (data == "")
                            {
                                // Increment the column and continue
                                ++col;
                                continue;
                            }

                            // Add the value to the cel
                            worksheet.Cells[row, col].Value = double.Parse(data);

                            // Increment the column position
                            ++col;
                        }
                    }

                    // Increament the row pos
                    ++row;
                }
                
                // Reset the column position back to default
                col = colStart;
            }
        }




        /// <summary>
        /// Export the data from KPIs template three to excel
        /// </summary>
        private void ExportTemplateThreeData()
        {
            int row = (int)OverallExcelFile.OverallCellPositions.KpiOverallTempThreeRowStartPosition;
            int colStart = (int)OverallExcelFile.OverallCellPositions.KpiOverallTempThreeColStartPosition;
            int col = colStart;


            foreach(KeyPerformanceIndicator indicator in KpiOverallReport.Indicators)
            {
                // Make sure the indicator is from template one.
                if (indicator.TemplateBlock is TemplateThree)
                {
                    // Convert the indicator to a ITemplate interface
                    TemplateThree tempThreeData = indicator.TemplateBlock as TemplateThree;

                    // Get the template data from the indicator
                    List<string> tempData = tempThreeData.GetTemplateData();

                    if (indicator is IUnconfirmed)
                        tempData.Add((indicator as IUnconfirmed).PercentUnconfirmed.ToString());
                    else
                        tempData.Add("");


                    if(indicator is IFavorable)
                    {
                        tempData.Add((indicator as IFavorable).PercentFavorable.ToString());
                    }

                    // Remove any unwanted characters
                    CleanData(ref tempData);

                    if (tempData != null)
                    {
                        // We are starting at position 2 in the array because the first two value are the section and cateogory
                        // The template already contains this data
                        foreach(string data in tempData)
                        {
                            // if the value in the array is blank, move to the next index in the array
                            if (data == "")
                            {
                                // Increment the column and continue
                                ++col;
                                continue;
                            }

                            // Add the value to the cel
                            worksheet.Cells[row, col].Value = double.Parse(data);

                            // Increment the column position
                            ++col;
                        }
                    }
                    // Increament the row pos
                    ++row;
                }

                // Reset the column position back to default
                col = colStart;
            }
        }




        /// <summary>
        /// Export the data from KPIs template four to excel
        /// </summary>
        private void ExportTemplateFourData()
        {
            int row = (int)OverallExcelFile.OverallCellPositions.KpiOverallTempFourRowStartPosition;
            int colStart = (int)OverallExcelFile.OverallCellPositions.KpiOverallTempFourColStartPosition;
            int col = colStart;

            foreach (KeyPerformanceIndicator indicator in KpiOverallReport.Indicators)
            {
                // Make sure the indicator is from template one.
                if (indicator.TemplateBlock is TemplateFour)
                {
                    // Convert the indicator to a ITemplate interface
                    TemplateFour tempFourData = indicator.TemplateBlock as TemplateFour;

                    // Get the template data from the indicator
                    List<string> tempData = tempFourData.GetTemplateData();

                    if (indicator is IUnconfirmed)
                    {
                        tempData.Add(string.Format("{0:n0}", (indicator as IUnconfirmed).PercentUnconfirmed + "%"));
                    }

                    // Remove any unwanted characters
                    CleanData(ref tempData);

                    if (tempData != null)
                    {
                        // We are starting at position 2 in the array because the first two value are the section and cateogory
                        // The template already contains this data
                        foreach(string data in tempData)
                        {
                            // if the value in the array is blank, move to the next index in the array
                            if (data == "")
                            {
                                // Increment the column and continue
                                ++col;
                                continue;
                            }

                            // Add the value to the cel
                            worksheet.Cells[row, col].Value = double.Parse(data);
                            
                            // Increment the column position
                            ++col;
                        }
                    }
                    // Increament the row pos
                    ++row;
                }

                // Reset the column position back to default
                col = colStart;
            }
        }



        /// <summary>
        /// Export the data from KPIs template five to excel
        /// </summary>
        private void ExportTemplateFiveData()
        {
            int row = (int)OverallExcelFile.OverallCellPositions.KpiOverallTempFiveRowStartPosition;
            int colStart = (int)OverallExcelFile.OverallCellPositions.KpiOverallTempFiveColStartPosition;
            int col = colStart;


            foreach (KeyPerformanceIndicator indicator in KpiOverallReport.Indicators)
            {
                // Make sure the indicator is from template one.
                if (indicator.TemplateBlock is TemplateFive)
                {
                    // Convert the indicator to a ITemplate interface
                    TemplateFive tempFiveData = indicator.TemplateBlock as TemplateFive;

                    // Get the template data from the indicator
                    List<string> tempData = tempFiveData.GetTemplateData();

                    // Remove any unwanted characters
                    CleanData(ref tempData);

                    if (tempData != null)
                    {
                        // We are starting at position 2 in the array because the first two value are the section and cateogory
                        // The template already contains this data
                        foreach(string data in tempData)
                        {
                            // if the value in the array is blank, move to the next index in the array
                            if (data == "")
                            {
                                // Increment the column and continue
                                ++col;
                                continue;
                            }

                            // Add the string to the cell
                            worksheet.Cells[row, col].Value = double.Parse(data);

                            // Move to the next column position
                            ++col;
                        }
                    }
                    // Increment the row pos
                    ++row;
                }

                // Reset the column position back to default
                col = colStart;
            }
        }
    }
}
