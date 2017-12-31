using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationIOLibarary.ApplicationDirectories;

namespace ApplicationIOLibarary.ApplicationFiles
{
    /// <summary>
    /// integer indexers of where the resource files are located
    /// </summary>
    public enum ResourceFile
    {
        PRPO_Database,
        Settings
    }





    /// <summary>
    /// a integer indexer of where the files are located
    /// </summary>
    public enum LogFile
    {
        ExcelTransferEvents,
        ExcelTransferEventErrors,
        DbConnectionEvents,
        DbConnectionEventErrors,
        ReportEvents,
        ReportEventErrors,
        AppEvents,
    }




    /// <summary>
    /// a indexer that gives the positions within overallFiles meaning
    /// </summary>
    public enum OverallFile
    {
        US_Overall,
        MX_Overall
    }




    /// <summary>
    /// An indexer that gives the positions whithin variantFiles meaning.
    /// </summary>
    public enum VariantFile
    {
        FilterVariants
    }




    public static class FileUtils
    {
        // The file path of the database.
        public static readonly string DbPath = Path.Combine(DirectoryUtils.AppDir, resourcesFiles[(int)ResourceFile.PRPO_Database]);


        /// <summary>
        /// The file paths of where the resource files are located.
        /// </summary>
        public static string[] resourcesFiles =
        {
            @"Resources\PRPODB.accdb",
            @"Resources\Settings.json"
        };


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
            @"Resources\Logs\ApplicationEvents.txt"
        };

        

        /// <summary>
        /// The file path of where the overall data files are located.
        /// </summary>
        public static string[] overallFiles =
        {
            @"Resources\Overall\US_Overall.json",
            @"Resources\Overall\MX_Overall.json"
        };

        

        /// <summary>
        /// The file path ofwhere the filter variants data are stored.
        /// </summary>
        public static string[] variantFiles =
        {
            @"Resources\Variants\FilterVariants.json"
        };




        /// <summary>
        /// return the full file path of there the directory is located within the application strucure
        /// </summary>
        /// <param name="dir">The directory in question</param>
        /// <returns>
        /// Returns the file path of where the directory is located
        /// </returns>
        public static string GetFullPath(AppDirectory dir) => DirectoryUtils.AppDir + DirectoryUtils.directories[(int)dir];





        /// <summary>
        /// Returns whether or not the overall data file exists.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool DataFileExists(OverallFile file) => File.Exists(overallFiles[(int)file]);










        /// <summary>
        /// Create the supplied type of log file
        /// </summary>
        /// <param name="file">The log file indexer that needs to be created.</param>
        public static void CreateFile(LogFile file)
        {
            try
            {
                File.Create(Path.Combine(DirectoryUtils.AppDir, logFiles[(int)file]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Log File(s) Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }





        /// <summary>
        /// Create the supplied type of overall data storage file (JSON file)
        /// </summary>
        /// <param name="file">The overall file indexer that needs to be created.</param>
        public static void CreateFile(OverallFile file)
        {
            try
            {
                File.Create(Path.Combine(DirectoryUtils.AppDir, overallFiles[(int)file]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Overall Data Storage File Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }




        /// <summary>
        /// Create the supplied type of resource data storage file (JSON)
        /// </summary>
        /// <param name="file">The settings file indexer</param>
        public static void CreateFile(ResourceFile settingsFile)
        {
            try
            {
                File.Create(Path.Combine(DirectoryUtils.AppDir, resourcesFiles[(int)settingsFile]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings File Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }






        /// <summary>
        /// Creates the variant file.
        /// </summary>
        /// <param name="varFile"></param>
        public static void CreateFile(VariantFile file)
        {
            try
            {
                File.Create(Path.Combine(DirectoryUtils.AppDir, variantFiles[(int)file]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Variant File Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }




        /// <summary>
        /// Remove the supplied countries overall file.
        /// </summary>
        /// <param name="file"></param>
        public static void RemoveFile(OverallFile file)
        {
            if (File.Exists(overallFiles[(int)file]))
            {
                File.Delete(overallFiles[(int)file]);
            }
        }
    }
}
