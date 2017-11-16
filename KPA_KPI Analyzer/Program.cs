using System;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Bunifu.Framework.LICENSE.License.Authenticate("jonsultana@outlook.com", "f4e019896b4e55f7ad4c72006ed65de8");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new SplashScreen());
        }
    }
}
