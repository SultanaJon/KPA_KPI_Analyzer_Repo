﻿using System;

namespace KPA_KPI_Analyzer.Navigation
{
    public class NavigationArgs : EventArgs
    {
        /// <summary>
        /// Indicator of what main button in the navigation is currently active
        /// </summary>
        public MainNavigationTag MainTag { get; internal set; }



        /// <summary>
        /// Indicator of what section button in the navigation is currently active
        /// </summary>
        public SectionNavigationTag SectionTag { get; internal set; }
    }
}
