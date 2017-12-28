using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Reporting
{
    public partial class SelctiveReportingWidget : UserControl
    {
        public SelctiveReportingWidget()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Event that fires when the SelectiveReportingWidget Loads.
        /// </summary>
        /// <param name="sender">The Selective Reporting Widget</param>
        /// <param name="e">The Load Event</param>
        private void SelctiveReportingWidget_Load(object sender, EventArgs e)
        {
            LoadFilterOptions();
        }




        /// <summary>
        /// Loads the filter options into the filter options combobox
        /// </summary>
        private void LoadFilterOptions()
        {
            Filters.FilterOptions filterOptions = new Filters.FilterOptions();
            comboBox_FitlerOption.DataSource = filterOptions.GetFilterOptions();
            comboBox_FitlerOption.DisplayMember = "Name";
            comboBox_FitlerOption.ValueMember = "Value";
        }
    }
}
