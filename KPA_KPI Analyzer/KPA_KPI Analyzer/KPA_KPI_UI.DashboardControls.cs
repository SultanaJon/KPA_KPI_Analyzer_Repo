﻿using DataImporter.Classes;
using Excel_Access_Tools.Access;
using Excel_Access_Tools.Excel;
using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.DragDropFeatures;
using KPA_KPI_Analyzer.DragDropFeatures.Exceptions;
using System;
using System.Threading;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI
    {
        Thread usThread;
        Thread mxThread;




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
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = ((string[])e.Data.GetData(DataFormats.FileDrop));

                try
                {
                    DragDropUtils.ProcessFiles(filePaths);
                }
                catch (DragDropExceptions.DragDropFileOverloadException ex)
                {
                    // An attempt of more than two files were dropped on the form.
                    errorList.Clear();
                    errorList.Add(ex.Message);
                    using (IOUtils.ErrorMessageBox errmsgbox = new IOUtils.ErrorMessageBox())
                    {
                        if (errmsgbox.ShowDialog() == DialogResult.OK)
                        {
                            errmsgbox.Close();
                        }
                    }
                }
                catch (DragDropExceptions.DragDropInvalidExtensionException ex)
                {
                    // Files were dropped that had an invalid file extention
                    errorList.Clear();
                    errorList.Add(ex.Message);
                    using (IOUtils.ErrorMessageBox errmsgbox = new IOUtils.ErrorMessageBox())
                    {
                        if (errmsgbox.ShowDialog() == DialogResult.OK)
                        {
                            errmsgbox.Close();
                        }
                    }
                }
                catch (DragDropExceptions.DragDropInvalidExcelFileException ex)
                {
                    // Files were dropped that were not PRPO files
                    errorList.Clear();
                    errorList.Add(ex.Message);
                    using (IOUtils.ErrorMessageBox errmsgbox = new IOUtils.ErrorMessageBox())
                    {
                        if (errmsgbox.ShowDialog() == DialogResult.OK)
                        {
                            errmsgbox.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    errorList.Clear();
                    errorList.Add(ex.Message);
                    using (IOUtils.ErrorMessageBox errmsgbox = new IOUtils.ErrorMessageBox())
                    {
                        if (errmsgbox.ShowDialog() == DialogResult.OK)
                        {
                            errmsgbox.Close();
                            Application.Exit();
                        }
                    }
                }




                Importer.NumberOfImports = filePaths.Length;
                Importer.ImportComplete = false;
                Importer.CompletedImports = 0;
                Importer.ImportProgress += ImportProgress;
                Importer.importStarted = false;

                if (ExcelInfo.USUpdated || ExcelInfo.MXUpdated)
                {
                    overallData = new KPA_KPI_Overall.Overall();
                    if(AccessUtils.US_PRPO_TableExists || AccessUtils.MX_PRPO_TableExists)
                        PRPO_DB_Utils.DropCreateDb();
                    else
                        AccessUtils.CreateAccessDB();


                    btn_DatabaseConnectionStatus.Invoke((MethodInvoker)delegate { btn_DatabaseConnectionStatus.Image = Properties.Resources.databaseConn_Disconnected_Icon; });

                    pnl_activePage.Controls.Clear();
                    pnl_loadingScreen.Visible = true;
                    pnl_loadingScreen.BringToFront();
                    lbl_loadingStatus.Text = "Importing Data...";


                    ImportTimer.Start();
                }
            }
        }
    }
}
