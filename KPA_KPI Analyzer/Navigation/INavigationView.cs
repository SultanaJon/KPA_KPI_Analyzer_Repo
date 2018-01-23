using System;

namespace KPA_KPI_Analyzer.Navigation
{
    public interface INavigationView
    {
        /// <summary>
        /// Event for when the main navigaiton is being clicked.
        /// </summary>
        event EventHandler<NavigationArgs> NavigationClick;
    }
}
