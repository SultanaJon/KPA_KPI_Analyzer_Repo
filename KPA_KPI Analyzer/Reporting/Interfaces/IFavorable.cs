namespace Reporting.Interfaces
{
    public interface IFavorable
    {
        /// <summary>
        /// The percent favorable for the KPA or KPI it is attached to.
        /// </summary>
        double PercentFavorable { get; set; }


        /// <summary>
        /// Calculates the percent favorable for the specific KPA or KPI it is attached to
        /// </summary>
        void CalculatePercentFavorable();
    }
}
