using ApplicationIOLibarary.ApplicationFiles;
using ApplicationIOLibarary.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Settings
{
    public class ReportSettings : IStorable<ReportSettings>, ILoadable<ReportSettings>
    {
        /// <summary>
        /// The instance of the report settings
        /// </summary>
        private static ReportSettings reportSettingsInstance;




        /// <summary>
        /// Property to return the instance of the report settings
        /// </summary>
        public static ReportSettings Instance
        {
            get
            {
                // If the report settings has not been instanciated, create one
                if(reportSettingsInstance == null)
                {
                    reportSettingsInstance = new ReportSettings();
                }

                // Return the instance of the report settings
                return reportSettingsInstance;
            }
        }




        #region Settings Properties

        /// <summary>
        /// Returns whether or no the US PRPO report has been loaded.
        /// </summary>s
        public bool PrpoUsReportLoaded { get; set; }


        /// <summary>
        /// Returns whether or not the MX PRPO report has been loaded.
        /// </summary>
        public bool PrpoMxReportLoaded { get; set; }


        /// <summary>
        /// The date of the current loaded US PRPO report
        /// </summary>
        public string PrpoUsDate { get; set; }


        /// <summary>
        /// The date of the current MX PRPO report loaded.
        /// </summary>
        public string PrpoMxDate { get; set; }


        /// <summary>
        /// The last date the US PRPO report was loaded
        /// </summary>
        public string PrpoUsLastLoadedDate { get; set; }



        /// <summary>
        /// The last date the MX PRPO report was loaded.
        /// </summary>
        public string PrpoMxLastLoadedDate { get; set; }



        /// <summary>
        /// The name of the US PRPO report loaded into the application.
        /// </summary>
        public string PrpoUsReportFileName { get; set; }



        /// <summary>
        /// The name of the MX PRPO report loaded into the application.
        /// </summary>
        public string PrpoMxReportFileName { get; set; }

        #endregion


        /// <summary>
        /// Default Constructor
        /// </summary>
        private ReportSettings()
        {
            PrpoUsReportLoaded = false;
            PrpoMxReportLoaded = false;
            PrpoUsDate = "00/00/0000";
            PrpoMxDate = "00/00/0000";
            PrpoUsLastLoadedDate = "00/00/0000";
            PrpoMxLastLoadedDate = "00/00/0000";
            PrpoUsReportFileName = "N/A";
            PrpoMxReportFileName = "N/A";
        }




        /// <summary>
        /// Creates a new instance of the report settings
        /// </summary>
        public static void Clear()
        {
            reportSettingsInstance = new ReportSettings();
        }



        /// <summary>
        /// Loads the setting from a tempory storage location in JSON format.
        /// </summary>
        /// <returns>Boolean value indicating whether or not the Load operation was successful.</returns>
        public void Load()
        {

            try
            {
                var jsonString = File.ReadAllText(FileUtils.resourcesFiles[(int)ResourceFile.ReportingSettings]);
                reportSettingsInstance = JsonConvert.DeserializeObject<ReportSettings>(jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings File Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        /// <summary>
        /// Saves the settings to a tempory storage location in JSON format for later loading.
        /// </summary>
        /// <returns>Boolean value indicating whether or not the save operation as successful.</returns>
        public void Save()
        {
            try
            {
                var jsonString = JsonConvert.SerializeObject(this);
                File.WriteAllText(FileUtils.resourcesFiles[(int)ResourceFile.ReportingSettings], jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings File Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
