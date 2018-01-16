namespace Reporting.TimeSpans.Templates
{
    internal interface ITemplateThree
    {
        double Average { get; set; }
        int TotalRecords { get; set; }
        int LessThanEqualToNegTwentyTwoDays { get; set; }
        int NegTwentyOneToNegFifteenDays { get; set; }
        int NegFourteenToNegEightDays { get; set; }
        int NegSevenToNegOneDays { get; set; }
        int ZeroDays { get; set; }
        int OneToSevenDays { get; set; }
        int EightToFourteenDays { get; set; }
        int FifteenToTwentyOneDays { get; set; }
        int GreaterThanEqualToTwentyTwoDays { get; set; }


        /// <summary>
        /// Calculates the average for the specific KPA or KPI.
        /// </summary>
        /// <param name="_totalDays"></param>
        void CalculateAverage(double _totalDays);


        /// <summary>
        /// Updates the time span buckets if the elapsed days meets their conditions
        /// </summary>
        /// <param name="_elapsedDays">The number of elapsed days.</param>
        void TimeSpanDump(double _elapsedDays);
    }
}
