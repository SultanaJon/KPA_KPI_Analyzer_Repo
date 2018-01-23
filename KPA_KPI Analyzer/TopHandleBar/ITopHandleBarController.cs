using System;

namespace KPA_KPI_Analyzer.TopHandleBar
{
    public interface ITopHandleBarController
    {
        /// <summary>
        /// Triggers an event to toggle the main navigation window
        /// </summary>
        event EventHandler ToggleNavigation;
    }
}
