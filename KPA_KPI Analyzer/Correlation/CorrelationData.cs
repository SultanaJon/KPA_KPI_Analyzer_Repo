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
            foreach(Values.StringUtils.CorrelationStringUtils.CorrelationMatrixIndexer index in Enum.GetValues(typeof(Values.StringUtils.CorrelationStringUtils.CorrelationMatrixIndexer)))
            {
                rawData.Add(Values.StringUtils.CorrelationStringUtils.correlationHeaders[(int)index], new List<double>());
            }

            correlationData = new Dictionary<string, List<double>>();
            foreach (Values.StringUtils.CorrelationStringUtils.CorrelationMatrixIndexer index in Enum.GetValues(typeof(Values.StringUtils.CorrelationStringUtils.CorrelationMatrixIndexer)))
            {
                correlationData.Add(Values.StringUtils.CorrelationStringUtils.correlationHeaders[(int)index], new List<double>());
            }
        }
    }
}
