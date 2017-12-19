using DataImporter.Importing;
using KPA_KPI_Analyzer.ExcelFiles;
using KPA_KPI_Analyzer.FileProcessing;
using KPA_KPI_Analyzer.FileProcessing.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI
    {
        #region FIELD DATA

        /// <summary>
        /// Thread to Load the United States data.
        /// </summary>
        Thread usThread;

        /// <summary>
        /// Thread to load the Mexico data.
        /// </summary>
        Thread mxThread;

        /// <summary>
        /// The files that the user supplied and have been processed.
        /// </summary>
        List<PrpoExcelFile> processedFiles;

        #endregion


        #region EVENTS

        /// <summary>
        /// Triggered when PRPO reports enter the area of a drag & drop region.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnl_DragDropArea_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }



        /// <summary>
        /// Triggered when the user drops any file into the region that allows a drop.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnl_DragDropArea_DragDrop(object sender, DragEventArgs e)
        {
            processedFiles = new List<PrpoExcelFile>();

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = ((string[])e.Data.GetData(DataFormats.FileDrop));

                try
                {
                    // Get the processed files.
                    processedFiles = ExcelFileProcessor.ProcessFiles(filePaths);

                    Importer.SetupImportSettings(filePaths.Length);
                    Importer.ImportProgress += ImportProgress;

                    // Begin the process of importing the files supplied
                    BeginImportProcess();
                }
                catch (FileProcessingExceptions.PrpoFileOverloadException ex)
                {
                    // An attempt of more than two files were dropped on the form.
                    MessageBox.Show(ex.Message);
                    ShowPage(Pages.DragDropDash);
                }
                catch (FileProcessingExceptions.FileProcessingInvalidExtensionException ex)
                {
                    // Files were dropped that had an invalid file extention
                    MessageBox.Show(ex.Message);
                    ShowPage(Pages.DragDropDash);
                }
                catch (FileProcessingExceptions.FileProcessingInvalidExcelFileException ex)
                {
                    // Files were dropped that were not PRPO files
                    MessageBox.Show(ex.Message);
                    ShowPage(Pages.DragDropDash);
                }
                catch(FileProcessingExceptions.PrpoDateProcessingErrorException ex)
                {
                    MessageBox.Show(ex.Message);
                    ShowPage(Pages.DragDropDash);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    ShowPage(Pages.DragDropDash);
                }
            }
        }

        #endregion


        #region HELPER FUNCTIONS

        /// <summary>
        /// When the threads seperate threads 'usThread' & 'mxThread' are performing the imports, We want to know when they have finished so we
        /// can fully open the application to the user for viewing.
        /// </summary>
        /// <param name="numImports">A integer value indicating the number of imports being performed</param>
        /// <param name="compImports">A integer value indicating the number of imports completed.</param>
        public void ImportProgress(int numImports, int compImports)
        {
            if ((numImports == compImports) && numImports != 0)
            {
                Importer.ImportComplete = true;
            }
        }

        #endregion
    }
}