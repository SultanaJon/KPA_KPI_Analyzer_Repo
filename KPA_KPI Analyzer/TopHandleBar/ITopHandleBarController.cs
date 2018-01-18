using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
