using System;
using System.Collections.Generic;

namespace KPA_KPI_Analyzer.Correlation
{
    public class CorrelationData
    {
        public Dictionary<string, List<double>> rawData;
        public Dictionary<string, List<double>> correlationData;

        public CorrelationData()
        {
            rawData = new Dictionary<string, List<double>>();
            foreach(CorrelationHeaders.CorrelationMatrixIndexer index in Enum.GetValues(typeof(CorrelationHeaders.CorrelationMatrixIndexer)))
            {
                rawData.Add(CorrelationHeaders.correlationHeaders[(int)index], new List<double>());
            }

            correlationData = new Dictionary<string, List<double>>();
            foreach (CorrelationHeaders.CorrelationMatrixIndexer index in Enum.GetValues(typeof(CorrelationHeaders.CorrelationMatrixIndexer)))
            {
                correlationData.Add(CorrelationHeaders.correlationHeaders[(int)index], new List<double>());
            }
        }
    }
}
