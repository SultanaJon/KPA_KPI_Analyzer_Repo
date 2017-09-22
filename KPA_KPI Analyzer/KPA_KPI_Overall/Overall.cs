using DataImporter.Access;
using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.FilterFeeature;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace KPA_KPI_Analyzer.KPA_KPI_Overall
{
    public class Overall
    {
        public KPA kpa;
        public KPI kpi;



        /// <summary>
        /// Default Overall Constructor
        /// </summary>
        public Overall()
        {
            kpa = new KPA();
            kpi = new KPI();
        }
    }
}
