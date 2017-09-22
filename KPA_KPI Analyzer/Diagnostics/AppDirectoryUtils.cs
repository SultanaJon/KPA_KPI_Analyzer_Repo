using System;
using System.IO;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Diagnostics
{
    public static class AppDirectoryUtils
    {
        /// <summary>
        /// Returns the application directory.
        /// </summary>
        public static string AppDirectory
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }






        /// <summary>
        /// A integer indexer of there the directories are located within the folder structure.
        /// </summary>
        public enum Directories
        {
            ResourceFolder,
            ReportsFolder,
            LogFolder,
            Overall
        }






        /// <summary>
        /// The paths of where these directories are lcoated
        /// </summary>
        public static string[] DirectoryStructures =
        {
            "Resources",
            @"Resources\Reports",
            @"Resources\Logs",
            @"Resources\Overall"
        };






        /// <summary>
        /// integer indexers of where the resource files are located
        /// </summary>
        public enum ResourceFiles
        {
            PRPO_Database
        }






        /// <summary>
        /// The file paths of where the resource files are located.
        /// </summary>
        public static string[] resourceFiles =
        {
            @"Resources\PRPODB.accdb",
        };






        /// <summary>
        /// a integer indexer of where the files are located
        /// </summary>
        public enum LogFiles
        {
            ExcelTransferEvents,
            ExcelTransferEventErrors,
            DbConnectionEvents,
            DbConnectionEventErrors,
            ReportEvents,
            ReportEventErrors,
            AppEvents,
            LoadedUSDate,
            LoadedMXDate
        }






        /// <summary>
        /// The file paths of where the log files are located.
        /// </summary>
        public static string[] logFiles =
        {
            @"Resources\Logs\ExcelTransferEvents.txt",
            @"Resources\Logs\ExcelTransferEventErrors.txt",
            @"Resources\Logs\dbConnectionEvents.txt",
            @"Resources\Logs\dbConnectionEventErrors.txt",
            @"Resources\Logs\ReportEvents.txt",
            @"Resources\Logs\ReportEventErrors.txt",
            @"Resources\Logs\ApplicationEvents.txt",
            @"Resources\Logs\LoadedUSDate.txt",
            @"Resources\Logs\LoadedMXDate.txt"
        };




        /// <summary>
        /// a indexer that gives the positions within overallFiles meaning
        /// </summary>
        public enum OverallFiles
        {
            US_Overall,
            MX_Overall
        }






        /// <summary>
        /// The file path of where the overall data files are located.
        /// </summary>
        public static string[] overallFiles =
        {
            @"Resources\Overall\US_Overall.json",
            @"Resources\Overall\MX_Overall.json"
        };





        /// <summary>
        /// return the full file path of there the directory is located within the application strucure
        /// </summary>
        /// <param name="dir">The directory in question</param>
        /// <returns>
        /// Returns the file path of where the directory is located
        /// </returns>
        public static string GetFullPath(Directories dir) => AppDirectory + DirectoryStructures[(int)dir];





        /// <summary>
        /// Returns whether or not the overall data file exists.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool DataFileExists(OverallFiles file) => File.Exists(overallFiles[(int)file]);





        /// <summary>
        /// Check if the directory exists
        /// </summary>
        /// <param name="dir">The directory in question</param>
        /// <returns>
        /// A boolean value indicating whether or not the directory exists
        /// </returns>
        public static bool CheckDirectories(Directories dir)
        {
           return Directory.Exists(DirectoryStructures[(int)dir]) ? true : false;
        }






        /// <summary>
        /// This function will build the Directory structure based on the directory that was supplied
        /// </summary>
        /// <param name="dir">The directory that needs to be built</param>
        public static void BuildDirectoryStructure(Directories dir)
        {
            try
            {
                if (dir == Directories.ReportsFolder)
                {
                    foreach (Directories directory in Enum.GetValues(typeof(Directories)))
                        Directory.CreateDirectory(DirectoryStructures[(int)directory]);
                }
                else if (dir == Directories.Overall)
                    Directory.CreateDirectory(DirectoryStructures[(int)dir]);
                else if (dir == Directories.ResourceFolder)
                    Directory.CreateDirectory(DirectoryStructures[(int)dir]);
                else if (dir == Directories.LogFolder)
                    Directory.CreateDirectory(DirectoryStructures[(int)dir]);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        /// <summary>
        /// Create the supplied type of log file
        /// </summary>
        /// <param name="file">The log file indexer that needs to be created.</param>
        internal static void CreateFile(LogFiles file)
        {
            File.Create(Path.Combine(Configuration.AppDir, logFiles[(int)file]));
        }





        /// <summary>
        /// Create the supplied type of overall data storage file (JSON file)
        /// </summary>
        /// <param name="file">The overall file indexer that needs to be created.</param>
        internal static void CreateFile(OverallFiles file)
        {
            File.Create(Path.Combine(Configuration.AppDir, overallFiles[(int)file]));
        }
    }
}
