using System;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.IO;
using KPA_KPI_Analyzer.Diagnostics;

namespace KPA_KPI_Analyzer.ApplicatonConfiguration
{
    /// <summary>
    /// This interface allows objects to save ther instance to a JSON file for storage.
    /// </summary>
    internal interface IStorable
    {
        bool Save();
        bool Load();
    }


    public class ApplicationConfig : IStorable
    {
        private static readonly JavaScriptSerializer ser = new JavaScriptSerializer();
        private static string dataJSONString = string.Empty;


        public class ReportSettings
        {
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


        public class CorrelationSettings
        {
            /// <summary>
            /// Determines whether the correlation feature is turned on.
            /// </summary>
            public bool CorrelationOn { get; set; }
        }



        /// <summary>
        /// Saves the settings to a tempory storage location in JSON format for later loading.
        /// </summary>
        /// <param name="settings">the application settings to be saved.</param>
        /// <returns></returns>
        public bool Save()
        {
            try
            {
                dataJSONString = ser.Serialize(Values.Globals.settings);
                File.WriteAllText(AppDirectoryUtils.resourceFiles[(int)AppDirectoryUtils.ResourceFiles.Settings], dataJSONString);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings File Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        /// <summary>
        /// Loads the setting from a tempory storage location in JSON format.
        /// </summary>
        /// <param name="settings">the application settings used to stored the settigns loaded.</param>
        /// <returns></returns>
        public bool Load()
        {
            try
            {
                dataJSONString = File.ReadAllText(AppDirectoryUtils.resourceFiles[(int)AppDirectoryUtils.ResourceFiles.Settings]);
                Values.Globals.settings = ser.Deserialize<ApplicationConfig>(dataJSONString);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings File Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
