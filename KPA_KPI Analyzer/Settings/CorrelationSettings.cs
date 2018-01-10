using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationIOLibarary.Interfaces;
using System.IO;
using ApplicationIOLibarary.ApplicationFiles;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Settings
{
    public class CorrelationSettings : IStorable<CorrelationSettings>, ILoadable<CorrelationSettings>
    {
        /// <summary>
        /// The instance of the Correlation Settings
        /// </summary>
        private static CorrelationSettings correlationSettingsInstance;




        /// <summary>
        /// Property to get the instance of the Correlation Settings
        /// </summary>
        public static CorrelationSettings Instance
        {
            get
            {
                // if the instance has not been instantiated, create one
                if(correlationSettingsInstance == null)
                {
                    correlationSettingsInstance = new CorrelationSettings();
                }

                // return the instance of the correlation settings
                return correlationSettingsInstance;
            }
        }



        /// <summary>
        /// Determines whether the correlation feature is turned on.
        /// </summary>
        public bool CorrelationOn { get; set; }




        /// <summary>
        /// Private Constructor
        /// </summary>
        private CorrelationSettings()
        {
            CorrelationOn = false;
        }




        /// <summary>
        /// Creates a new instance of the report settings
        /// </summary>
        public static void Clear()
        {
            correlationSettingsInstance = new CorrelationSettings();
        }



        /// <summary>
        /// Loads the setting from a tempory storage location in JSON format.
        /// </summary>
        /// <returns>Boolean value indicating whether or not the Load operation was successful.</returns>
        public void Load()
        {
            try
            {
                var jsonString = File.ReadAllText(FileUtils.resourcesFiles[(int)ResourceFile.CorrelationSettings]);
                correlationSettingsInstance = JsonConvert.DeserializeObject<CorrelationSettings>(jsonString);
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
