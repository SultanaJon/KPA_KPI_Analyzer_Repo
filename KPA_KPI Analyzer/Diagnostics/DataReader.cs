using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Diagnostics
{
    internal static class DataReader
    {
        private static readonly JavaScriptSerializer ser = new JavaScriptSerializer();
        private static string dataJSONString = string.Empty;



        /// <summary>
        /// Load the inventory from the JSON file
        /// </summary>
        /// <exception cref="Exception">Any exception thrown will be caught</exception>
        public static void LoadOverallData(ref KPA_KPI_Overall.Overall data)
        {
            try
            {
                if(Values.Globals.FocusedCountry == Values.Globals.Countries.UnitedStates)
                {
                    dataJSONString = File.ReadAllText(AppDirectoryUtils.overallFiles[(int)AppDirectoryUtils.OverallFiles.US_Overall]);
                }
                else
                {
                    dataJSONString = File.ReadAllText(AppDirectoryUtils.overallFiles[(int)AppDirectoryUtils.OverallFiles.MX_Overall]);
                }
                data = ser.Deserialize<KPA_KPI_Overall.Overall>(dataJSONString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Overall DataReader Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }





        /// <summary>
        /// save the inventory's current state to the JSON file
        /// </summary>
        /// <exception cref="Exceptions">Any exception thrown will be caught</exception>
        public static void SaveOverallData(KPA_KPI_Overall.Overall data)
        {
            try
            {
                dataJSONString = ser.Serialize(data);
                if(Values.Globals.FocusedCountry == Values.Globals.Countries.UnitedStates)
                {
                    File.WriteAllText(AppDirectoryUtils.overallFiles[(int)AppDirectoryUtils.OverallFiles.US_Overall], dataJSONString);
                }
                else
                {
                    File.WriteAllText(AppDirectoryUtils.overallFiles[(int)AppDirectoryUtils.OverallFiles.MX_Overall], dataJSONString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Overall DataReader Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
