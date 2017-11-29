﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.Values
{
    public static class Performances
    {
        /// <summary>
        /// The current Performance
        /// </summary>
        public enum Performance
        {
            KPA,
            KPI
        }


        /// <summary>
        /// List of the Performances the application will display.
        /// </summary>
        public static string[] performances =
        {
            "KPA",
            "KPI"
        };
    }
}
