using System;
using System.IO;

namespace KPA_KPI_Analyzer
{
    public static class Configuration
    {
        public static readonly string AppDir = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string DbPath = Path.Combine(AppDir, Diagnostics.AppDirectoryUtils.resourceFiles[(int)Diagnostics.AppDirectoryUtils.ResourceFiles.PRPO_Database]);
    }
}
