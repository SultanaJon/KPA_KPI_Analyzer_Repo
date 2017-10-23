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
            foreach(Values.Globals.CorrelationMatrixIndexer index in Enum.GetValues(typeof(Values.Globals.CorrelationMatrixIndexer)))
            {
                rawData.Add(Values.Globals.correlationHeaders[(int)index], new List<double>());
            }

            correlationData = new Dictionary<string, List<double>>();
            foreach (Values.Globals.CorrelationMatrixIndexer index in Enum.GetValues(typeof(Values.Globals.CorrelationMatrixIndexer)))
            {
                correlationData.Add(Values.Globals.correlationHeaders[(int)index], new List<double>());
            }
        }
    }
}
