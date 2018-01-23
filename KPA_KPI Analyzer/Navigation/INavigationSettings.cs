namespace KPA_KPI_Analyzer.Navigation
{
    public interface INavigationSettings
    {
        /// <summary>
        /// Boolean to indicate whether or not the navigation windows is locked
        /// </summary>
        Functionality Status { get; set; }



        /// <summary>
        /// Boolean to indicate whether or not the navigation is in front of all other controls or not.
        /// </summary>
        Visibility Visible { get; set; }
    }
}
