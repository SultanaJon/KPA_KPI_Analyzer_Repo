using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ApplicationIOLibarary.ApplicationDirectories
{
    /// <summary>
    /// A integer indexer of there the directories are located within the folder structure.
    /// </summary>
    public enum AppDirectory
    {
        ResourceFolder,
        ReportsFolder,
        LogFolder,
        Overall,
        Variants
    }



    public static class DirectoryUtils
    {
        // The directory of the application
        public static readonly string AppDir = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// The paths of where these directories are lcoated
        /// </summary>
        public static string[] directories =
        {
            "Resources",
            @"Resources\Reports",
            @"Resources\Logs",
            @"Resources\Overall",
            @"Resources\Variants"
        };






        /// <summary>
        /// Check if the directory exists
        /// </summary>
        /// <param name="dir">The directory in question</param>
        /// <returns>
        /// A boolean value indicating whether or not the directory exists
        /// </returns>
        public static bool CheckDirectories(AppDirectory dir)
        {
            return Directory.Exists(directories[(int)dir]) ? true : false;
        }
    }
}
