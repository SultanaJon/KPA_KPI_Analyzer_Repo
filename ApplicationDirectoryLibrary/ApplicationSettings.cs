using ApplicationIOLibarary.ApplicationFiles;
using ApplicationIOLibarary.Interfaces;
using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ApplicationIOLibarary
{
    public class ApplicationSettings : IStorable, ILoadable
    {
        /// <summary>
        /// The instance of the application settings
        /// </summary>
        private static ApplicationSettings appSettingsInstance;

        /// <summary>
        /// The settings for the report
        /// </summary>
        public ReportSettings reportSettings;



        /// <summary>
        /// The settings for the correlation feature
        /// </summary>
        public CorrelationSettings correlationSettings;



        /// <summary>
        /// Property to return the instance of the application settings
        /// </summary>
        public static ApplicationSettings AppSettingsInstance
        {
            get
            {
                if(appSettingsInstance == null)
                {
                    appSettingsInstance = new ApplicationSettings();
                }

                // return the instance of the application settings
                return appSettingsInstance;
            }
        }




        /// <summary>
        /// JavaScriptSerializer to serialize and deserialize the application settings
        /// </summary>
        private JavaScriptSerializer ser;


        /// <summary>
        /// string to hold the contents of the object after serialization
        /// </summary>
        private string dataJSONString;



        /// <summary>
        /// Default Constructor
        /// </summary>
        private ApplicationSettings()
        {
            reportSettings = new ReportSettings();
            correlationSettings = new CorrelationSettings();

            ser = new JavaScriptSerializer();
            dataJSONString = string.Empty;
        }




        /// <summary>
        /// Allows the user to create a new instance of the settings file
        /// </summary>
        public static ApplicationSettings CreateNewSettingsInstance()
        {
            // Create a new settings instance
            appSettingsInstance = new ApplicationSettings();

            // Return the newly created instance
            return appSettingsInstance;
        }



        /// <summary>
        /// public class - The setting for the report settings.
        /// </summary>
        public class ReportSettings
        {
            /// <summary>
            /// Default Constructor
            /// </summary>
            public ReportSettings()
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
        }




        /// <summary>
        /// public calss - The settings for the correlation feature.
        /// </summary>
        public class CorrelationSettings
        {
            public CorrelationSettings()
            {
                CorrelationOn = false;
            }


            /// <summary>
            /// Determines whether the correlation feature is turned on.
            /// </summary>
            public bool CorrelationOn { get; set; }
        }




        /// <summary>
        /// Loads the setting from a tempory storage location in JSON format.
        /// </summary>
        /// <returns>Boolean value indicating whether or not the Load operation was successful.</returns>
        public void Load()
        {
            try
            {
                dataJSONString = File.ReadAllText(FileUtils.resourcesFiles[(int)ResourceFile.Settings]);
                appSettingsInstance = ser.Deserialize<ApplicationSettings>(dataJSONString);
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
                dataJSONString = ser.Serialize(this);
                File.WriteAllText(FileUtils.resourcesFiles[(int)ResourceFile.Settings], dataJSONString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings File Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}