﻿using System;

namespace KPA_KPI_Analyzer.DatabaseUtils
{
    class ThreadInteruptedException : Exception
    {
        public ThreadInteruptedException() { }
        public ThreadInteruptedException(string message) : base(message) { }
    }
}
