using System.Data;

namespace Reporting.TimeSpans.Templates
{
    internal interface ITemplateFive
    {
        decimal TotalValue { get; set; }
        int TotalRecords { get; set; }
        decimal GreaterThanEqualToZeroWeeks { get; set; }
        decimal GreaterThanEqualToNegOneWeek { get; set; }
        decimal GreaterThanEqualToNegTwoWeeks { get; set; }
        decimal GreaterThanEqualToNegThreeWeeks { get; set; }
        decimal GreaterThanEqualToNegFourWeeks { get; set; }
        decimal GreaterThanEqualToNegFiveWeeks { get; set; }
        decimal GreaterThanEqualToNegSixWeeks { get; set; }
        decimal GreaterThanEqualToNegSevenWeeks { get; set; }
        decimal GreaterThanEqualToNegEightWeeks { get; set; }
        decimal LessThanNegEightWeeks { get; set; }


        /// <summary>
        /// Time spand to apply the elapsed days against the template data.
        /// </summary>
        /// <param name="_elapsedWeeks">number of elapsed days</param>
        void TimeSpanDump(double _elapsedWeeks);


        /// <summary>
        /// Time spans to apply the elapsed days against the template data using elapsed weeks instead of elapsed days
        /// </summary>
        /// <param name="_weeks">The total number of elapsed weeks</param>
        /// <param name="dr">The data row being used to update the time span buckets</param>
        void TimeSpanDump(double _weeks, DataRow dr);


        /// <summary>
        /// Another time span function to apply the elapsed weeks against the time span buckets
        /// </summary>
        /// <param name="_weeks">The total number of elapsed weeks</param>
        /// <param name="dr">The data row being used to update the time span buckets.</param>
        void TimeSpanDumpV2(double _weeks, DataRow dr);
    }
}
