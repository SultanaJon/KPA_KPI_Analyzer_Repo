using System.Data;

namespace KPA_KPI_Analyzer.DataLoading
{
    public static class DataViewerUtils
    {
        /// <summary>
        /// The data that should be loaded into the DataViewer.
        /// </summary>
        public static DataTable Data { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public static bool DataLoadProcessStarted { get; set; }




        /// <summary>
        /// Indication of whether the data was fully loaded and can now be loaded into the DataViewer.s
        /// </summary>
        public static bool DataLoaded { get; set; }
    }
}
