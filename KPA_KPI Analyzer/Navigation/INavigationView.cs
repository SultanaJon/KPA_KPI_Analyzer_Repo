using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
