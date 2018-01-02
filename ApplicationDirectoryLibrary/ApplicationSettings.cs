using ApplicationIOLibarary.ApplicationFiles;
using ApplicationIOLibarary.Interfaces;
using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ApplicationIOLibarary
{
    public class ApplicationSettings : IStorable, ILoadable<ApplicationSettings>
    {
        public ReportSettings reportSettings;
        public CorrelationSettings correlationSettings;



        /// <summary>
        /// JavaScript serializer used to serialize and deserializer ApplicationConfig objects
        /// </summary>
        private JavaScriptSerializer ser;
        private string dataJSONString;



        /// <summary>
        /// Default Constructor
        /// </summary>
        public ApplicationSettings()
        {
            reportSettings = new ReportSettings();
            correlationSettings = new CorrelationSettings();

            ser = new JavaScriptSerializer();
            dataJSONString = string.Empty;
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
        public void Load(ref ApplicationSettings settings)
        {
            try
            {
                dataJSONString = File.ReadAllText(FileUtils.resourcesFiles[(int)ResourceFile.Settings]);
                settings = ser.Deserialize<ApplicationSettings>(dataJSONString);
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