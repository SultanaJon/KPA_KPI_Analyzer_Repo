//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//          Project: KPA-KPI Analysis Application
//          Company: Comau North America
//
//          Developer: Jonathan Michael Sultana
//          Date: 06/09/2017
//          
//          "Once you stop learning you start dying" - Albert Einstein
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using ApplicationIOLibarary;
using ApplicationIOLibarary.ApplicationFiles;
using DataAccessLibrary;
using ExcelLibrary;
using Filters;
using Filters.Variants;
using KPA_KPI_Analyzer.Overall_Data;
using KPA_KPI_Analyzer.Values;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI : Form
    {
        #region FIELD DATA

        // Data regarding the form.
        private FormData frmData = new FormData();

        // The overall data calculated.
        private Overall overallData = new Overall();

        // The current active user controls visible.
        private UserControl activeTemplate = new UserControl();
        
        // The application settings.
        private ApplicationSettings settings = new ApplicationSettings();

        // The settings used for filter variants.
        private FilterVariants variantSettings = new FilterVariants();

        #endregion


        #region CONSTRUCTORS

        /// <summary>
        /// The initital constructor of the main ui
        /// </summary>
        public KPA_KPI_UI()
        {
            InitializeComponent();
            NavigationLocked = true;
        }



        /// <summary>
        /// The custom constructor of the main user interface. This constructor takes a database conenection that will be used
        /// to connect to and read data from.
        /// </summary>
        /// <param name="conn">The database connection that was established in the splash screen.</param>
        public KPA_KPI_UI(ApplicationSettings settingsData)
        {
            InitializeComponent();
          
            // Set the settings file for the application.
            settings = settingsData;
        }

        #endregion


        #region EVENTS

        /// <summary>
        /// This functijon will be called when the form loads.
        /// </summary>
        /// <param name="sender">The form</param>
        /// <param name="e">The load event</param>
        private void KPA_KPI_UI_Load(object sender, EventArgs e)
        {
            mainNavActiveBtn = btn_Dashboard; // set the active button as the first button (Dashboard)
            InitializeProgramEvents();
            GetCheckBoxControls();
            GetCheckListBoxes();
            InitializeProgram();

        }



        /////////////////////////////////////////////////// UI DIALOGS //////////////////////////////////////////////////
        //
        //  here we can control the behavior of the form.
        // 
        //  These functions perform the following
        //  1) minimize the form into the taskbar.
        //  2) maximize the form to the size of the screen and min down to normal size.
        //  3) close the application.
        //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region UI CONTROL EVENTS
        /// <summary>
        /// This event will change the button background image while the user has their cursor over it.
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">The Mouse Hover Event</param>
        private void btn_Expand_MouseHover(object sender, EventArgs e)
        {
            pnl_Maximize.BackgroundImage = Properties.Resources.Maximize_Hover_icon;
        }






        /// <summary>
        /// This event will change the background of the image back to the original image.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">the Mouse Leave Event</param>
        private void btn_Expand_MouseLeave(object sender, EventArgs e)
        {
            pnl_Maximize.BackgroundImage = Properties.Resources.Maximize;
        }






        /// <summary>
        /// This event will trigger when the user clicks the expand button and the form will expand.
        /// </summary>
        /// <param name="sender">The expand button</param>
        /// <param name="e">The click event.</param>
        private void btn_Expand_Click(object sender, EventArgs e)
        {
            FormSizer();
        }






        /// <summary>
        /// This event will change the background of the button when the user hovers over it.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">The Mouse Enter Event</param>
        private void btn_Minimize_MouseEnter(object sender, EventArgs e)
        {
            pnl_Minimize.BackgroundImage = Properties.Resources.Minimize_Hover_Icon;
        }






        /// <summary>
        /// This event will change the background of the image back to the original image.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">the Mouse Leave event</param>
        private void btn_Minimize_MouseLeave(object sender, EventArgs e)
        {
            pnl_Minimize.BackgroundImage = Properties.Resources.Minimize;
        }






        /// <summary>
        /// This event will trigger when the user clicks the minimize button. The form will minimize into the taskbar.
        /// </summary>
        /// <param name="sender">The minimize button</param>
        /// <param name="e">The click event.</param>
        private void btn_Minimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;






        /// <summary>
        /// This event will change the background of the button when the user hovers over it.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">The Mouse Over event</param>
        private void btn_Close_MouseHover(object sender, EventArgs e)
        {
            pnl_Close.BackgroundImage = Properties.Resources.Close_Hover_icon;
        }






        /// <summary>
        /// This event will change the background of the button back to the original background image.
        /// </summary>
        /// <param name="sender">the close button</param>
        /// <param name="e">The MouseLeave event</param>
        private void btn_Close_MouseLeave(object sender, EventArgs e)
        {
            pnl_Close.BackgroundImage = Properties.Resources.Close;
        }






        /// <summary>
        /// This event will close the entire application (process)
        /// </summary>
        /// <param name="sender">The Close button</param>
        /// <param name="e">The click event</param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            // Deactivate and save the variants.
            variantSettings.DeactivateVariants();

            // Close the application.
            Application.Exit();
        }
        #endregion





        /////////////////////////////////////////////////// TOP PANEL //////////////////////////////////////////////////
        //
        //  Here we can control the behavior of the top drag panel
        // 
        //  These functions perform the following.
        //  1) size the form to the size of the screen when double clicked.
        //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region TOP DRAG PANEL EVENTS
        /// <summary>
        /// This event will trigger when the user double clicks the top panel of the the UI. This will max out the size of 
        /// the screen based on the size of the working area of the computer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnl_TopPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSizer();
        }


        /// <summary>
        /// This function will expand or minimize to original window size.
        /// </summary>
        private void FormSizer()
        {
            Screen screen = Screen.FromControl(this);

            if (Width == screen.WorkingArea.Width && Height == screen.WorkingArea.Height) // the form is maxed
            {
                Width = Values.Constants.minFormWidth;
                Height = Values.Constants.minFormHeight;
                Left = frmData.FrmX;
                Top = frmData.FrmY;
            }
            else // the form is its default size
            {
                frmData.FrmX = Left;
                frmData.FrmY = Top;
                Left = screen.WorkingArea.Left;
                Top = screen.WorkingArea.Top;
                Height = screen.WorkingArea.Height;
                Width = screen.WorkingArea.Width;

            }
            RefreshTemplate();
        }


        #endregion





        #region MENU ITEM EVENTS

        /// <summary>
        /// Closes the running process.
        /// </summary>
        /// <param name="sender">The menu strip File->Exit menu item</param>
        /// <param name="e">The click event</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Deactivate and save the variants.
            variantSettings.DeactivateVariants();

            // Close the application
            Application.Exit();
        }






        /// <summary>
        /// Shows the drag drop screen.
        /// </summary>
        /// <param name="sender">The View->Analysis menu item</param>
        /// <param name="e">The click event</param>
        private void analysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPage(Pages.DragDropDash);
        }






        /// <summary>
        /// Shows the drag drop screen.
        /// </summary>
        /// <param name="sender">The Tools->Import menu item</param>
        /// <param name="e">The click event</param>
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPage(Pages.DragDropDash);
        }




        /// <summary>
        /// Begins the export overall data operation.
        /// </summary>
        /// <param name="sender">The Tools->Export->Overall Data menu item</param>
        /// <param name="e">The click event</param>
        private void overallDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<List<string>> tempKpaOneData;
            List<List<string>> tempKpaTwoData;
            List<List<string>> tempKpiThreeData;
            List<List<string>> tempKpiFourData;
            List<List<string>> tempKpiFiveData;

            try
            {
                tempKpaOneData = overallData.GetKpaTempOneData();
                tempKpaTwoData = overallData.GetKpaTempTwoData();
                tempKpiThreeData = overallData.GetKpiTempThreeData();
                tempKpiFourData = overallData.GetKpiTempFourData();
                tempKpiFiveData = overallData.GetKpiTempFiveData();

                if (tempKpaOneData == null || tempKpaTwoData == null || tempKpiThreeData == null || tempKpiFourData == null || tempKpiFiveData == null)
                    throw new NullReferenceException();
                else
                {
                    Globals.CurrCountry = lbl_Country.Text;
                    // export the templates to overall.xlsx located in resources -> reports
                    Exporter.ExportOverall(
                        tempKpaOneData,
                        tempKpaTwoData,
                        tempKpiThreeData,
                        tempKpiFourData,
                        tempKpiFiveData,
                        Globals.CurrCountry,
                        Globals.PrpoGenerationDate
                    );

                    tempKpaOneData.Clear();
                    tempKpaTwoData.Clear();
                    tempKpiThreeData.Clear();
                    tempKpiFourData.Clear();
                    tempKpiFiveData.Clear();

                    tempKpaOneData = null;
                    tempKpaTwoData = null;
                    tempKpiThreeData = null;
                    tempKpiFourData = null;
                    tempKpiFiveData = null;
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }






        /// <summary>
        /// When the user clicks the add variant button on the menu strip, if there are filters applied, this function
        /// will show the add variant window which will add the filters to a variant and add it to the list of saved
        /// variants so the user can quickly load them and apply them to the data.
        /// </summary>
        /// <param name="sender">The Tools->Filters->Add Varaints menu item</param>
        /// <param name="e">The click event</param>
        private void addVariantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // When the user clicks this menu strip button, the add variant window will open.
            using (VariantsCreationWindow vcw = new VariantsCreationWindow())
            {
                if (vcw.ShowDialog() == DialogResult.OK)
                {
                    // Get the name and the description the user just entered and pass it to the constructor
                    // of the new variant.p
                    Variant variant = new Variant(vcw.VariantName, vcw.VariantDescription, FilterData.GetSelectedFilters());

                    // Deactivate all of the variants.
                    DeactivateVariants();

                    // add the variant to the list of variants and save them.
                    variantSettings.AddVariant(variant);
                    variantSettings.Save();

                    // The user must apply the filters in order to add them.
                    addVariantToolStripMenuItem.Enabled = false;
                }
            }
        }





        /// <summary>
        /// When the user clicks the view variants button on the menu strip. If any, the variants the user has added 
        /// will be displayed in this window.
        /// </summary>
        /// <param name="sender">The Tools->Filters->View Variants menu item</param>
        /// <param name="e">The click event</param>
        private void viewVariantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // When the user clicks this menu strip button, the variants view window will open.
            using (VariantsViewWindow vvw = new VariantsViewWindow() { Variants = variantSettings.Variants })
            {
                vvw.ShowDialog();
                // Get the list of variants in case the user updated them and save.  
                variantSettings.Variants = vvw.Variants;
                variantSettings.Save();
            }
        }

        #endregion

        #endregion


        #region HELPER FUNCTIONS

        /// <summary>
        /// Configure the application to the United States
        /// </summary>
        public void ConfigureToUnitedStates()
        {
            lbl_Country.Text = Values.Countries.countries[(int)Values.Countries.Country.UnitedStates];
            Globals.TargetCountry = Values.Countries.Country.UnitedStates;
            DatabaseManager.TargetTable = DatabaseTables.databaseTables[(int)DatabaseTables.DatabaseTable.UnitedStates];
        }



        /// <summary>
        /// Configure the application to Mexico
        /// </summary>
        public void ConfigureToMexico()
        {
            lbl_Country.Text = Values.Countries.countries[(int)Values.Countries.Country.Mexico];
            Globals.TargetCountry = Values.Countries.Country.Mexico;
            DatabaseManager.TargetTable = DatabaseTables.databaseTables[(int)DatabaseTables.DatabaseTable.Mexico];
        }



        /// <summary>
        /// Initializes callback functions used while in seperate threads of execution.
        /// </summary>
        private void InitializeProgramEvents()
        {
            // Setup callback functions for Dataloading.
            DatabaseManager.RenewDataLoadTimer += RenewDataLoadTimer;
            DatabaseManager.DisplayDragDropPage += ShowDragDropPage;

            // Setup callback functions for Drag & Drop screen
            FileProcessing.ExcelFileProcessor.DisplayDragDropPage += ShowDragDropPage;
            FileProcessing.ExcelFileProcessor.ClearMxSettings += ResetMxSettings;
            FileProcessing.ExcelFileProcessor.ClearUsSettings += ResetUsSettings;

            // Setup callback functions that update the Variants tool on the menu strip toolbar.
            VariantsViewWindow.UpdateVariantTools += UpdateVariantTools;
            FilterVariants.UpdateVariantTools += UpdateVariantTools;
            VariantsViewWindow.BeginVariantLoadProcess += BeginVariantLoadProcess;
        }



        /// <summary>
        /// Start the loading of the filters.
        /// </summary>
        public void InitializeFilterLoadProcess()
        {
            DateTime today = DateTime.Now.Date;
            dp_PRFromDate.Value = today;
            dp_PRToDate.Value = today;
            dp_POFromDate.Value = today;
            dp_POToDate.Value = today;
            dp_finalReceiptFromDate.Value = today;
            dp_finalReciptToDate.Value = today;

            ShowPage(Pages.LoadingScreen);
            ms_applicaitonMenuStrip.Enabled = false;
            cpb_loadingScreenCircProgBar.Text = "Loading Filters...";
            Filters.FilterUtils.FiltersLoaded = false;
            Filters.FilterUtils.FilterLoadProcessStarted = false;
            FiltersTimer.Start();
        }



        /// <summary>
        /// Returns the last time (in a DateTime format) of when the data was reloaded for the US PRPO report
        /// </summary>
        /// <returns></returns>
        public DateTime GetLastLoadedUsPrpoReportDate()
        {
            string[] date = settings.reportSettings.PrpoUsLastLoadedDate.Split(' ');
            int month = int.Parse(date[0].ToString());
            int day = int.Parse(date[1].ToString());
            int year = int.Parse(date[2].ToString());

            DateTime dt = new DateTime(year, month, day);
            return dt;
        }



        /// <summary>
        /// Returns the last time (in a DateTime format) of when the data was reloaded for the MX PRPO report
        /// </summary>
        /// <returns></returns>
        public DateTime GetLastLoadedMxPrpoReportDate()
        {

            string[] date = settings.reportSettings.PrpoMxLastLoadedDate.Split(' ');
            int month = int.Parse(date[0].ToString());
            int day = int.Parse(date[1].ToString());
            int year = int.Parse(date[2].ToString());

            DateTime dt = new DateTime(year, month, day);
            return dt;
        }



        /// <summary>
        /// Returns the date (in a DateTime format) of the loaded US PRPO report.
        /// </summary>
        /// <returns></returns>
        public DateTime GetLoadedUsPrpoReportDate()
        {
            string[] date = settings.reportSettings.PrpoUsDate.Split(' ');
            int month = int.Parse(date[0].ToString());
            int day = int.Parse(date[1].ToString());
            int year = int.Parse(date[2].ToString());

            DateTime dt = new DateTime(year, month, day);
            return dt;
        }


        /// <summary>
        /// Returns the date (in a DateTime format) of the loaded US PRPO report.
        /// </summary>
        /// <returns></returns>
        public DateTime GetLoadedMxPrpoReportDate()
        {
            string[] date = settings.reportSettings.PrpoMxDate.Split(' ');
            int month = int.Parse(date[0].ToString());
            int day = int.Parse(date[1].ToString());
            int year = int.Parse(date[2].ToString());

            DateTime dt = new DateTime(year, month, day);
            return dt;
        }



        /// <summary>
        /// Reset the settings that deal with United States.
        /// </summary>
        public void ResetUsSettings()
        {
            settings.reportSettings.PrpoUsReportLoaded = false;
            settings.reportSettings.PrpoUsReportFileName = string.Empty;
            settings.reportSettings.PrpoUsLastLoadedDate = string.Empty;
            settings.reportSettings.PrpoUsDate = string.Empty;
        }



        /// <summary>
        /// Resets the settings that deal with Mexico
        /// </summary>
        public void ResetMxSettings()
        {
            settings.reportSettings.PrpoMxReportLoaded = false;
            settings.reportSettings.PrpoMxReportFileName = string.Empty;
            settings.reportSettings.PrpoMxLastLoadedDate = string.Empty;
            settings.reportSettings.PrpoMxDate = string.Empty;
        }



        /// <summary>
        /// Configure the application based on the resources available to it.
        /// </summary>
        private void InitializeProgram()
        {
            CheckVariantSettings();

            if (DatabaseManager.GetDatabaseConnection() != null && new FileInfo(FileUtils.resourcesFiles[(int)ResourceFile.Settings]).Length != 0)
            {
                try
                {
                    if (settings.reportSettings.PrpoUsReportLoaded && settings.reportSettings.PrpoMxReportLoaded)
                    {
                        NavigationLocked = true;
                        ShowPage(Pages.CountrySelector);
                    }
                    else if (settings.reportSettings.PrpoUsReportLoaded)
                    {
                        ConfigureToUnitedStates();

                        if (FileUtils.DataFileExists(OverallFile.US_Overall))
                        {
                            // the file exists
                            if (new FileInfo(FileUtils.overallFiles[(int)OverallFile.US_Overall]).Length > 0)
                            {
                                DateTime dt = GetLastLoadedUsPrpoReportDate();
                                if (dt == DateTime.Today.Date)
                                {
                                    // Load the overall data
                                    overallData.Load(ref overallData);

                                    dt = GetLoadedUsPrpoReportDate();
                                    lbl_topPanelNavPrpoDate.Text = dt.ToString("MMMM dd, yyyy");
                                    Globals.PrpoGenerationDate = lbl_topPanelNavPrpoDate.Text;
                                    InitializeFilterLoadProcess();
                                }
                                else
                                {
                                    BeginDataLoadProcess();
                                }
                            }
                            else
                            {
                                BeginDataLoadProcess();
                            }
                        }
                        else // the file does not exist
                        {
                            FileUtils.CreateFile(OverallFile.US_Overall);
                            BeginDataLoadProcess();
                        }
                    }
                    else if(settings.reportSettings.PrpoMxReportLoaded)
                    {
                        ConfigureToMexico();

                        if (FileUtils.DataFileExists(OverallFile.MX_Overall))
                        {
                            // the file exists
                            if (new FileInfo(FileUtils.overallFiles[(int)OverallFile.MX_Overall]).Length > 0)
                            {
                                DateTime dt = GetLastLoadedMxPrpoReportDate();
                                if (dt == DateTime.Today.Date)
                                {
                                    // Load the overall data
                                    overallData.Load(ref overallData);

                                    dt = GetLoadedMxPrpoReportDate();
                                    lbl_topPanelNavPrpoDate.Text = dt.ToString("MMMM dd, yyyy");
                                    Values.Globals.PrpoGenerationDate = lbl_topPanelNavPrpoDate.Text;
                                    InitializeFilterLoadProcess();
                                }
                                else
                                {
                                    BeginDataLoadProcess();
                                }
                            }
                            else
                            {
                                BeginDataLoadProcess();
                            }
                        }
                        else // the file does not exist
                        {
                            FileUtils.CreateFile(OverallFile.MX_Overall);
                            BeginDataLoadProcess();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Application load error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else
            {
                settings = new ApplicationSettings();
                lbl_Country.Text = "Waiting...";
                lbl_topPanelNavPrpoDate.Text = "Waiting...";
                ShowPage(Pages.DragDropDash);
            }
        }






        /// <summary>
        /// The pages that can be displayed in the active page panel.
        /// </summary>
        public enum Pages
        {
            Dashboard,
            DragDropDash,
            Filters,
            LoadingScreen,
            CountrySelector
        }






        /// <summary>
        /// This event will display the request page in the active page panel.
        /// </summary>
        /// <param name="page">The page to be displayed</param>
        private void ShowPage(Pages page)
        {
            HidePages();
            switch((int)page)
            {
                case 0:
                    tblpnl_DashbaordPage.Visible = true;
                    tblpnl_DashbaordPage.BringToFront();
                    break;
                case 1:
                    NavigationLocked = true;
                    ms_applicaitonMenuStrip.Enabled = false;
                    tblpnl_DragDrop.Visible = true;
                    tblpnl_DragDrop.BringToFront();
                    break;
                case 2:
                    tblpnl_Filters.Visible = true;
                    tblpnl_Filters.BringToFront();
                    break;
                case 3:
                    NavigationLocked = true;
                    ms_applicaitonMenuStrip.Enabled = false;
                    pnl_loadingScreen.Visible = true;
                    pnl_loadingScreen.BringToFront();
                    break;
                case 4:
                    NavigationLocked = true;
                    ms_applicaitonMenuStrip.Enabled = false;
                    pnl_CountrySelector.Visible = true;
                    pnl_CountrySelector.BringToFront();
                    break;
                default:
                    break;  
            }
        }


        /// <summary>
        /// Used when data is being improted. This callback function will be used to display the drag drop page when an error occurs while improting or loading.
        /// </summary>
        private void ShowDragDropPage()
        {
            ShowPage(Pages.DragDropDash);
        }



        /// <summary>
        /// Hides all of the pages incase they are visible.
        /// </summary>
        private void HidePages()
        {
            tblpnl_DashbaordPage.Visible = false;
            tblpnl_DragDrop.Visible = false;
            tblpnl_Filters.Visible = false;
            pnl_CountrySelector.Visible = false;
            pnl_loadingScreen.Visible = false;
        }






        /// <summary>
        /// This event will resubscribe the DataLoaderTimer.Tick event.
        /// </summary>
        /// <remarks>
        /// This had to be done because after the DataLoaderTimer would run a couple of times its event would no longer fire as if it was unsubscribed somehow.
        /// </remarks>
        public void RenewDataLoadTimer()
        {
            DataLoaderTimer.Tick -= DataLoaderTimer_Tick;
            DataLoaderTimer.Tick += DataLoaderTimer_Tick;
        }



        /// <summary>
        /// Checks if there is a variant settigs file available to load. if not the variant settings file will
        /// be initialized.
        /// </summary>
        private void CheckVariantSettings()
        {
            // Load the variant settings
            if (new FileInfo(FileUtils.variantFiles[(int)VariantFile.FilterVariants]).Length != 0)
            {
                variantSettings.Load(ref variantSettings);

                if (variantSettings.Variants.Count > 0)
                    viewVariantsToolStripMenuItem.Enabled = true;
            }
        }



        /// <summary>
        /// Deactivate all of the variants.
        /// </summary>
        private void DeactivateVariants()
        {
            // Deactivate all of the variants
            foreach (var savedVariant in variantSettings.Variants)
                savedVariant.Active = false;
        }


        /// <summary>
        /// Check the status of the filter and update the variant filter tools.
        /// </summary>
        public void UpdateVariantTools()
        {
            // If the user has any filters applied, allow them to add variants, otherwise block this ability.
            if (FilterData.ColumnFilters.Applied || FilterData.AdvancedFilters.Applied || FilterData.DateFilters.Applied)
                addVariantToolStripMenuItem.Enabled = true;
            else
                addVariantToolStripMenuItem.Enabled = false;



            // If the user has any fitlers still applied, still provide the ability to view them.
            if (variantSettings.Variants.Count > 0)
                viewVariantsToolStripMenuItem.Enabled = true;
            else
                viewVariantsToolStripMenuItem.Enabled = false;
        }


        /// <summary>
        /// Used as a call-back function for when the user chooses to apply a saved variant against the data.
        /// </summary>
        /// <param name="_variantDetails">A Dictionary object that stores the filters saved in the chosen variant.</param>
        public void BeginVariantLoadProcess(Dictionary<string, List<string>> _variantDetails)
        {
            addVariantToolStripMenuItem.Enabled = false;

            // Make sure there is no filters selected already.
            ClearSelected();

            // Pass Variant details to filters for calibration
            FilterData.CalibrateFilters(_variantDetails);
            BuildQueryFilters();
            Filters.FilterUtils.FiltersLoaded = false;

            CheckFilterStatus();

            // Update the checked items that are applied.
            UpdateColumnFilterCheckedItems();
            UpdateDateFilterCheckedItems();
            UpdateAdvancedFilterCheckedItems();

            // Start the data load process.
            BeginDataLoadProcess();

            // Update the buttons.
            UpdateFilterButtons();
        }


        #endregion

        private void reportingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}