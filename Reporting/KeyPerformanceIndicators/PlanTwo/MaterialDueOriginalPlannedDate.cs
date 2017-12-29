using Reporting.Interfaces;

namespace Reporting.KeyPerformanceIndicators.PlanTwo
{
    public sealed class MaterialDueOriginalPlannedDate : KeyPerformanceIndicator, ISelectiveVOne
    {
        #region ISelectiveVOne Properties

        /// <summary>
        /// The Average Days for the Selective Calculation
        /// </summary>
        public double SelectiveAverage { get; set; }


        /// <summary>
        /// The total amount of records for the Selective Calculation
        /// </summary>
        public int SelectiveTotalRecords { get; set; }

        #endregion



        /// <summary>
        /// Default Constructor
        /// </summary>
        public MaterialDueOriginalPlannedDate()
        {
            Section = "Plan II";
            Name = "Material Due (Original Planned Date)";
        }



        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
