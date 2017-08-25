using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class LoadingScreen : UserControl
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public LoadingScreen()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Sets the labels Text property to the value given
        /// </summary>
        public string LoadingStatus { set { lbl_loadingStatus.Text = value; } }
    }
}
