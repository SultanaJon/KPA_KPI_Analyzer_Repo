using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPA_KPI_Analyzer.Interfaces;
using KPA_KPI_Analyzer.Data.Kpa;
using KPA_KPI_Analyzer.Data.Kpi;


namespace KPA_KPI_Analyzer.Data
{
    public class OverallData : IJSONStoreable, IJSONLoadable<OverallData>
    {
        /// <summary>
        ///  Kpas holds the data for all KPAs
        /// </summary>
        public Kpas kpas = new Kpas();


        /// <summary>
        /// Kpis holds the data for all KPIs
        /// </summary>
        public Kpis kpis = new Kpis(); 



        /// <summary>
        /// Default Constructor
        /// </summary>
        public OverallData() { }



        /// <summary>
        /// Saves the overall data to external JSON file.
        /// </summary>
        public void Save()
        {

        }


        /// <summary>
        /// Loads the overall data from external JSON file into overall data object
        /// </summary>
        /// <param name="_overallData"></param>
        public void Load(ref OverallData _overallData)
        {

        }
    }
}
