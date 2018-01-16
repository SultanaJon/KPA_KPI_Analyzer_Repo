namespace Reporting.TimeSpans.Templates
{
    internal interface ITemplateTwo
    {
        double Average { get; set; }
        int TotalRecords { get; set; }
        int LessthanNegThreeWeeks { get; set; }
        int GreaterThanEqualToNegThreeWeeks { get; set; }
        int GreaterThanEqualToNegTwoWeeks { get; set; }
        int GreaterThanEqualNegOneWeek { get; set; }
        int ZeroWeeks { get; set; }
        int LessThanEqualToOneWeek { get; set; }
        int LessThanEqualToTwoWeeks { get; set; }
        int LessThanEqualToThreeWeeks { get; set; }
        int GreaterThanThreeWeeks { get; set; }


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
