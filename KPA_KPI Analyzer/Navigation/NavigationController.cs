using System;

namespace KPA_KPI_Analyzer.Navigation
{
    public class NavigationController : INavigationController
    {
        /// <summary>
        /// The view of the navigation window
        /// </summary>
        private INavigationView view;





        /// <summary>
        /// Get teh current active main tag in the navigation
        /// </summary>
        public MainNavigationTag MainTag { get { return (view as NavigationView).NavigationArguments.MainTag; } }





        /// <summary>
        /// Get the current active section tag
        /// </summary>
        public SectionNavigationTag SectionTag { get { return (view as NavigationView).NavigationArguments.SectionTag; } }




        /// <summary>
        /// Default Constructor
        /// </summary>
        public NavigationController(INavigationView _view, EventHandler<NavigationArgs> _handle, NavigationSettings _settings)
        {
            // Get control of the navigation view supplied
            view = _view;

            // allow the navigation view to view the navigation setting
            (view as NavigationView).AttachSettings(_settings);

            // Attach the method handle from the main form to the views event listenr
            view.NavigationClick += _handle;
        }
    }
}
