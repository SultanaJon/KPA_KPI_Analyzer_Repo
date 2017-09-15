using DataImporter.Excel;
using KPA_KPI_Analyzer.DragDropFeatures.Exceptions;
using System;
using System.IO;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.DragDropFeatures
{
    public static class DragDropUtils
    {
        // The file path of where the excel files are located.
        public static string US_PRPO_FilePath = string.Empty;
        public static string MX_PRPO_FilePath = string.Empty;






        /// <summary>
        /// This file will begin to process the files that were dropped into the form.
        /// </summary>
        /// <param name="filePaths">The file paths of the files that are to be imported to excel</param>
        public static void ProcessFiles(string[] filePaths)
        {
            // Check for too many dropped files
            if (filePaths.Length > 2)
                throw new DragDropExceptions.DragDropFileOverloadException("Attempted to drop more than two files. Please drop only two or less excel files.");

            // Check for invalid file types
            foreach (var file in filePaths)
            {
                if (Path.GetExtension(file).ToUpper() != ".XLSX" && Path.GetExtension(file).ToUpper() != ".XLS")
                    throw new DragDropExceptions.DragDropInvalidExtensionException(Path.GetFileName(file) + " has a incompatable file type. Please only supply excel files.");

                if (!file.Contains("PRPO")) // the file is not a PRPO file
                    throw new DragDropExceptions.DragDropInvalidExcelFileException("You must supply a either US & MX PRPO file.Do not drop PO_PROG or PURDASH!");
            }

            PopulateExcelFilePaths(filePaths);
        }






        /// <summary>
        /// If the files are valid so far, this function will populate the filepath variables that will be used to import into MS Access
        /// </summary>
        /// <param name="filePaths">The file paths of the PRPO files that were dropped by the user.</param>
        private static void PopulateExcelFilePaths(string[] filePaths)
        {
            //if (!AccessUtils.US_PRPO_TableExists && !AccessUtils.MX_PRPO_TableExists)
            //{
            //    ExcelInfo.USUpdated = false;
            //    ExcelInfo.MXUpdated = false;
            //}

            ExcelInfo.USUpdated = false;
            ExcelInfo.MXUpdated = false;
            US_PRPO_FilePath = string.Empty;
            MX_PRPO_FilePath = string.Empty;

            int count = filePaths.Length; // get the number of files that were dropped.

            foreach (var file in filePaths)
            {
                if (file.Contains("US")) // This file contains United States Data
                {
                    // if the file has already been updated do nothing and continue.
                    //if (US_PRPO_FilePath == file) continue;

                    if (!file.Contains(DateTime.Now.ToString("MMddyyyy")))
                    {
                        if (MessageBox.Show("This file does not have a time stamp of " + DateTime.Now.ToString("MMMM dd, yyyy") + ". Do you still want to import this data?", "Time Stamp Detection", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            US_PRPO_FilePath = file;
                            ExcelInfo.USUpdated = true;
                        }
                    }
                    else
                    {
                        US_PRPO_FilePath = file;
                        ExcelInfo.USUpdated = true;
                    }
                }
                else if (file.Contains("MX")) // This file contains Mexico Data
                {
                    //if (MX_PRPO_FilePath == file) continue;

                    if (!file.Contains(DateTime.Now.ToString("MMddyyyy")))
                    {
                        if (MessageBox.Show("This file does not have a time stamp of " + DateTime.Now.ToString("MMMM dd, yyyy") + ". Do you still want to import this data?", "Time Stamp Detection", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            MX_PRPO_FilePath = file;
                            ExcelInfo.MXUpdated = true;
                        }
                    }
                    else
                    {
                        MX_PRPO_FilePath = file;
                        ExcelInfo.MXUpdated = true;
                    }
                }
                else
                {
                    // Cannot determine the Overall.SelectedCountry based on the file name.
                    // errorList.Add(DateTime.Now.ToString() + " - The file you have dropped may be the PRPO file but make sure it has the following nameing convention : \'PRPO_US{DATE HERE}\' or \'PRPO_MX{DATE HERE}' & the following Extenstion types: \'.xlsx\' or \'.xls\'");
                }
            }
        }
    }
}
