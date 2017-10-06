using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.ApplicatonConfiguration
{
    /// <summary>
    /// This interface allows objects to save ther instance to a JSON file for storage.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IStorable<T>
    {
        bool Save(T obj);
        bool Load(T obj);
    }


    public class ApplicationConfig : IStorable<ApplicationConfig>
    {
        /// <summary>
        /// Returns whether or no the US PRPO report has been loaded.
        /// </summary>
        public bool PrpoUsReportLoaded { get; set; }
        

        /// <summary>
        /// Returns whether or not the MX PRPO report has been loaded.
        /// </summary>
        public bool PrpoMxReportLoaded { get; set; }


        /// <summary>
        /// The date of the current loaded US PRPO report
        /// </summary>
        public DateTime PrpoUsDate { get; set; }


        /// <summary>
        /// The date of the current MX PRPO report loaded.
        /// </summary>
        public DateTime PrpoMxDate { get; set; }


        /// <summary>
        /// The last date the US PRPO report was loaded
        /// </summary>
        public DateTime PrpoUsLastLoadedDate { get; set; }



        /// <summary>
        /// The last date the MX PRPO report was loaded.
        /// </summary>
        public DateTime PrpoMxLastLoadedDate { get; set; }



        /// <summary>
        /// The name of the US PRPO report loaded into the application.
        /// </summary>
        public string PrpoUsReportFileName { get; set; }



        /// <summary>
        /// The name of the MX PRPO report loaded into the application.
        /// </summary>
        public string PrpoMxReportFileName { get; set; }



        /// <summary>
        /// Saves the settings to a tempory storage location in JSON format for later loading.
        /// </summary>
        /// <param name="settings">the application settings to be saved.</param>
        /// <returns></returns>
        public bool Save(ApplicationConfig settings)
        {
            return true;
        }



        /// <summary>
        /// Loads the setting from a tempory storage location in JSON format.
        /// </summary>
        /// <param name="settings">the application settings used to stored the settigns loaded.</param>
        /// <returns></returns>
        public bool Load(ApplicationConfig settings)
        {
            return false;
        }
    }
}
