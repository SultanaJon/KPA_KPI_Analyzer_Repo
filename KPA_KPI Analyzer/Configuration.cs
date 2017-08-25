using System;
using System.IO;

namespace KPA_KPI_Analyzer
{
    public static class Configuration
    {
        public static readonly string AppDir = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string DbPath = Path.Combine(AppDir, IOUtils.AppDirectoryUtils.resourceFiles[(int)IOUtils.AppDirectoryUtils.ResourceFiles.PRPO_Database]);
    }
}
