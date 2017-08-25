using System;
using System.IO;

namespace KPA_KPI_Analyzer.IOUtils
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
            if (logFile != AppDirectoryUtils.LogFiles.LoadedUSDate && logFile != AppDirectoryUtils.LogFiles.LoadedMXDate)
            {
                using (StreamWriter sw = new StreamWriter(AppDirectoryUtils.logFiles[(int)logFile], true))
                {
                    sw.WriteLine("[" + DateTime.Now.ToString() + "] - " + message);
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(AppDirectoryUtils.logFiles[(int)logFile], false))
                {
                    sw.Write(message);
                }
            }
            
        }
    }
}
