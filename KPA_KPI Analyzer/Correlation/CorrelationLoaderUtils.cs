namespace KPA_KPI_Analyzer.Correlation
{
    public static class CorrelationLoaderUtils
    {
        /// <summary>
        /// The number of columns being used in the correlation tool.
        /// </summary>
        public static int NumberOfCorrelationHeaders = CorrelationHeaders.correlationHeaders.Length;



        /// <summary>
        /// 
        /// </summary>
        public static int NumberOfCompletedCorrelationLoads { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public static int NumberOfCompletedRawDataLoads { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public static bool CorrelationLoadProcessStarted { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public static bool CorrelationRawDataLoadProcessStarted { get; set; }




        public static bool CorrelationRawDataLoaded { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public static bool CorrelationCalculated { get; set; }




        /// <summary>
        /// 
        /// </summary>
        public static bool TableLoadProcessStarted { get; set; }
        
        
        
        /// <summary>
        /// 
        /// </summary>
        public static bool TablesLoaded { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public static void Reset()
        {
            NumberOfCompletedCorrelationLoads = 0;
            NumberOfCompletedRawDataLoads = 0;
            CorrelationLoadProcessStarted = false;
            CorrelationRawDataLoadProcessStarted = false;
            CorrelationRawDataLoaded = false;
            CorrelationCalculated = false;
            TableLoadProcessStarted = false;
            TablesLoaded = false;
        }
    }
}
