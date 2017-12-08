using DataImporter.Excel;
using KPA_KPI_Analyzer.ExcelFiles;
using KPA_KPI_Analyzer.FileProcessing.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.FileProcessing
{
    public static class ExcelFileProcessor
    {
        public delegate void DisplayDragDropPageHandler();
        public static event DisplayDragDropPageHandler DisplayDragDropPage;

        
        public delegate void ClearUsSettingsHandler();
        public static event ClearUsSettingsHandler ClearUsSettings;


        public delegate void ClearMxSettingsHandler();
        public static event ClearMxSettingsHandler ClearMxSettings;


        private static List<PrpoExcelFile> files;
        public static PrpoExcelFile usPrpoFile = null;
        public static PrpoExcelFile mxPrpoFile = null;



        /// <summary>
        /// This file will begin to process the files that were dropped into the form.
        /// </summary>
        /// <param name="filePaths">The file paths of the files that are to be imported to excel</param>
        public static List<PrpoExcelFile> ProcessFiles(string[] filePaths)
        {
            // Create a new list of excel files to return
            files = new List<PrpoExcelFile>();

            // Check for too many dropped files
            if (filePaths.Length > 2)
                throw new FileProcessingExceptions.PrpoFileOverloadException("Attempted to drop more than two files. Please drop only two or less excel files.");

            // Check for invalid file types
            foreach (var file in filePaths)
            {
                if (Path.GetExtension(file).ToUpper() != ".XLSX" && Path.GetExtension(file).ToUpper() != ".XLS")
                    throw new FileProcessingExceptions.FileProcessingInvalidExtensionException(Path.GetFileName(file) + " has a incompatable file type. Please only supply excel files.");

                if (!file.Contains("PRPO")) // the file is not a PRPO file
                    throw new FileProcessingExceptions.FileProcessingInvalidExcelFileException("You must supply a either US & MX PRPO file.Do not drop PO_PROG or PURDASH!");
                else
                    ProcessPrpoReport(file);
            }

            

            if (usPrpoFile == null)
            {
                Diagnostics.AppDirectoryUtils.RemoveFile(Diagnostics.AppDirectoryUtils.OverallFile.US_Overall);
                ClearUsSettings();
            }

            if (mxPrpoFile == null)
            {
                Diagnostics.AppDirectoryUtils.RemoveFile(Diagnostics.AppDirectoryUtils.OverallFile.MX_Overall);
                ClearMxSettings();
            }

            // Get any excel files created
            GatherFiles();

            // Return the files.
            return files;
        }





        /// <summary>
        /// If there were any Excel files created, add them to the list of files to return.
        /// </summary>
        private static void GatherFiles()
        {
            if(usPrpoFile != null)
            {
                files.Add(usPrpoFile);
            }

            if(mxPrpoFile != null)
            {
                files.Add(mxPrpoFile);
            }
        }




        /// <summary>
        /// Because of constant changes to the PRPO we need to check the date of the file because older version of the PRPO report
        /// are no longer accepted due to query changes because of column changes.
        /// </summary>
        /// <returns></returns>
        private static bool GetPrpoDate(PrpoExcelFile _file)
        {
            try
            {
                string path = Path.GetFileNameWithoutExtension(_file.Path);
                string strFileName = Path.GetFileNameWithoutExtension(path);
                string strMonth = strFileName[7].ToString() + strFileName[8].ToString();
                string strDay = strFileName[9].ToString() + strFileName[10].ToString();
                string strYear = strFileName[11].ToString() + strFileName[12].ToString() + strFileName[13].ToString() + strFileName[14].ToString();

                int month = int.Parse(strMonth.TrimStart('0'));
                int day = int.Parse(strDay.TrimStart('0'));
                int year = int.Parse(strYear);

                DateTime dt = new DateTime(year, month, day);

                // Store the date of the file within the excel file object
                _file.Date = dt;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Drag & drop report date processing error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }





        /// <summary>
        /// Stop the fiel processing and load the drag drop screen.
        /// </summary>
        public static void ResetFileProcessing()
        {
            usPrpoFile = null;
            mxPrpoFile = null;
            DisplayDragDropPage();
        }





        /// <summary>
        /// If the files are valid so far, this function will populate the filepath variables that will be used to import into MS Access
        /// </summary>
        /// <param name="filePaths">The file paths of the PRPO files that were dropped by the user.</param>
        private static void ProcessPrpoReport(string _file)
        {
            if (_file.Contains("US"))
            {
                if (usPrpoFile == null)
                {
                    usPrpoFile = new UsPrpoExcelFile();
                    usPrpoFile.Path = _file;
                    usPrpoFile.AssociatedCountry = Values.Countries.Country.UnitedStates;

                    // Get and store the file
                    GetPrpoDate(usPrpoFile);
                }
                else
                {
                    MessageBox.Show("To avoid memory consumption, please do not load more than one PRPO file from the same country.");
                    ResetFileProcessing();
                    DisplayDragDropPage();
                }
            }
            else if (_file.Contains("MX")) // This file contains Mexico Data
            {

                if (mxPrpoFile == null)
                {
                    mxPrpoFile = new MxPrpoExcelFile();
                    mxPrpoFile.Path = _file;
                    mxPrpoFile.AssociatedCountry = Values.Countries.Country.Mexico;

                    // Get and store the file
                    GetPrpoDate(mxPrpoFile);
                }
                else
                {
                    MessageBox.Show("To avoid memory consumption, please do not load more than one PRPO file from the same country.");
                    ResetFileProcessing();
                    DisplayDragDropPage();
                }
            }
            else
            {
                // Cannot determine the SelectedCountry based on the file name.
                MessageBox.Show("Cannot determine the country of origin based on the file(s) name.");
            }
        }
    }
}
