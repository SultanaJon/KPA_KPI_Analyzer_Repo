namespace Reporting.TimeSpans.Templates
{
    public interface ITemplateOne
    {
        double Average { get; set; }
        int TotalRecords { get; set; }
        int LessThanEqualToZeroDays { get; set; }
        int OneToThreeDays { get; set; }
        int FourToSevenDays { get; set; }
        int EightToFourteenDays { get; set; }
        int FifteenToTwentyOneDays { get; set; }
        int TwentyTwoToTwentyEightDays { get; set; }
        int TwentyNinePlusDays { get; set; }


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
