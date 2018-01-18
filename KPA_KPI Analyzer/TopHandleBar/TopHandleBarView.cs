using System;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.TopHandleBar
{
    public partial class TopHandleBarView : UserControl, ITopHandleBarView
    {

        /// <summary>
        /// Event for when the hamburger icon is clicked.
        /// </summary>
        public event EventHandler HamburgerClick;



        /// <summary>
        /// Default constructor
        /// </summary>
        public TopHandleBarView()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Updates the labels on the view to inform the user what they are looking at.
        /// </summary>
        /// <param name="_model">The model that has been udpated</param>
        public void UpdateView(ITopHandleBarModel _model)
        {
            lbl_Country.Text = _model.CurrentCountry;
            lbl_reportGenerationDate.Text = _model.ReportGenerationDate;
            lbl_Performance.Text = _model.Performance;
            lbl_Section.Text = _model.Section;
            lbl_Category.Text = _model.Category;
        }



        /// <summary>
        /// Event that fires when the user clicks the navigation button.
        /// </summary>
        /// <param name="sender">The navigation button</param>
        /// <param name="e">the click event</param>
        private void btn_navigation_Click(object sender, EventArgs e)
        {
            // Notify the controller that the navigation button has been clicked.
            HamburgerClick(sender, e);
        }
    }
}
