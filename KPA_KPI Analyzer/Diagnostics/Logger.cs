using System;
using System.IO;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Diagnostics
{
    public static class Logger
    {
        /// <summary>
        /// Logs the message in the logFile.
        /// </summary>
        /// <param name="logFile"></param>
        /// <param name="message"></param>
        public static void Log(AppDirectoryUtils.LogFiles logFile, string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(AppDirectoryUtils.logFiles[(int)logFile], true))
                {
                    sw.WriteLine("[" + DateTime.Now.ToString() + "] - " + message);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Logger Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
