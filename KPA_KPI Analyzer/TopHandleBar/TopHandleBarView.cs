using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// An enumeration parallel to the defaultLabelValues array
        /// </summary>
        private enum DefaultLabelValue
        {
            Country,
            GenerationDate,
            Perforamnce,
            Section,
            Category
        }


        public static string[] defaultLabelValues =
        {
            "Checking...",
            "Checking...",
            "N/A",
            "N/A",
            "N/A"
        };


        /// <summary>
        /// Default constructor
        /// </summary>
        public TopHandleBarView()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Event method that is fired when the TopHandleBarView has finished painting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopHandleBarView_Load(object sender, EventArgs e)
        {
            // Update the view with default values.
            UpdateDefaultView();
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
        /// Updates the view with default values
        /// </summary>
        public void UpdateDefaultView()
        {
            lbl_Country.Text = defaultLabelValues[(int)DefaultLabelValue.Country];
            lbl_reportGenerationDate.Text = defaultLabelValues[(int)DefaultLabelValue.GenerationDate];
            lbl_Performance.Text = defaultLabelValues[(int)DefaultLabelValue.Perforamnce];
            lbl_Section.Text = defaultLabelValues[(int)DefaultLabelValue.Section];
            lbl_Category.Text = defaultLabelValues[(int)DefaultLabelValue.Category];
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
