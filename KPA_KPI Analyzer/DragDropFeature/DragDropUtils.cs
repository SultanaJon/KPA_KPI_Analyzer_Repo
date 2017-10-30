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


        public delegate void DisplayDragDropPageHandler();
        public static event DisplayDragDropPageHandler DisplayDragDropPage;



        public delegate void ClearUsSettingsHandler();
        public static event ClearUsSettingsHandler ClearUsSettings;


        public delegate void ClearMxSettingsHandler();
        public static event ClearMxSettingsHandler ClearMxSettings;



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
        /// If a file is incorrect this function will be called and the import process will not start.
        /// </summary>
        public static void StopFileProcessing()
        {
            US_PRPO_FilePath = string.Empty;
            MX_PRPO_FilePath = string.Empty;
            ExcelInfo.USUpdated = false;
            ExcelInfo.MXUpdated = false;
        }






        /// <summary>
        /// If the files are valid so far, this function will populate the filepath variables that will be used to import into MS Access
        /// </summary>
        /// <param name="filePaths">The file paths of the PRPO files that were dropped by the user.</param>
        private static void PopulateExcelFilePaths(string[] filePaths)
        {
            bool usFileProcessed = false;
            bool mxFileProcessed = false;
           
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
                        if (MessageBox.Show("This file looks to be outdated. Would you still like to import the data?", "Outdated Time Stamp Detection", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if(!usFileProcessed)
                            {
                                usFileProcessed = true;
                                US_PRPO_FilePath = file;
                                ExcelInfo.USUpdated = true;
                            }
                            else
                            {
                                MessageBox.Show("To avoid memory consumption, please do not load more than one PRPO file from the same country.");
                                StopFileProcessing();
                                DisplayDragDropPage();
                            }
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
                        if (MessageBox.Show("This file looks to be outdated. Would you still like to import the data?", "Outdated Time Stamp Detection", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if(!mxFileProcessed)
                            {
                                mxFileProcessed = true;
                                MX_PRPO_FilePath = file;
                                ExcelInfo.MXUpdated = true;
                            }
                            else
                            {
                                MessageBox.Show("To avoid memory consumption, please do not load more than one PRPO file from the same country.");
                                StopFileProcessing();
                                DisplayDragDropPage();
                            }
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
                    // Cannot determine the SelectedCountry based on the file name.
                    MessageBox.Show("Cannot determine the country of origin based on the file(s) name.");
                }


                if(!usFileProcessed)
                {
                    Diagnostics.AppDirectoryUtils.RemoveFile(Diagnostics.AppDirectoryUtils.OverallFiles.US_Overall);
                    ClearUsSettings();
                }

                if (!mxFileProcessed)
                {
                    Diagnostics.AppDirectoryUtils.RemoveFile(Diagnostics.AppDirectoryUtils.OverallFiles.MX_Overall);
                    ClearMxSettings();
                }
            }
        }
    }
}
