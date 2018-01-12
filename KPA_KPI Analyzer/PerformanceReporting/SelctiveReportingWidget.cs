using Filters;
using Reporting;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.PerformanceReporting
{
    public partial class SelctiveReportingWidget : UserControl, ISelectiveReportingWidgetView
    {
        #region ISelectiveReportingWidgetView Events

        public event EventHandler GenerateReport;

        #endregion

        #region ISelectiveReportingWidgetView Properties

        /// <summary>
        /// The Performance the comparison report will track
        /// </summary>
        public ReportingType PerformanceReportType { get; set; }




        /// <summary>
        /// The filter option nthe comparison report will use.
        /// </summary>
        public FilterOptions.Options FilteringOption { get; set; }

        #endregion



        /// <summary>
        /// Default Constructor
        /// </summary>
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
            // Clear the contents of the combobox
            comboBox_FitlerOption.Items.Clear();

            // Get a new data source
            List<string> filterOptions = new List<string>(FilterOptions.options);

            // Populate the combobox
            comboBox_FitlerOption.DataSource = filterOptions;
        }






        /// <summary>
        /// Assigns the EventHandler passed in to the GenerateReport event
        /// </summary>
        /// <param name="_handler"></param>
        public void RegisterReportGenerationHandler(EventHandler _handler)
        {
            // Assign the method to the event handler
            GenerateReport += _handler;
        }





        /// <summary>
        /// Invokes the Generate reports method
        /// </summary>
        /// <param name="sender">The generate report button</param>
        /// <param name="e">The click event</param>
        public void OnGenerateReport(object sender, EventArgs e)
        {
            // Ivokes the callback if it is not null
            GenerateReport?.Invoke(sender, e);
        }





        /// <summary>
        /// When the checked state changes on the performance radio buttons, The Reporting
        /// information will be updated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PerformanceRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if(radioBtn_KpaReporting.Checked)
            {
                PerformanceReportType = ReportingType.KpaReport;
            }
            else
            {
                PerformanceReportType = ReportingType.KpiReport;
            }
        }





        /// <summary>
        /// When the selected index of the combobox changes, get the newly selected filter option.
        /// </summary>
        /// <param name="sender">The filter option combobox</param>
        /// <param name="e">The selected index changed event</param>
        private void comboBox_FitlerOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox_FitlerOption.SelectedIndex;
            foreach(FilterOptions.Options option in Enum.GetValues(typeof(FilterOptions.Options)))
            {
                if(index == (int)option)
                {
                    FilteringOption = option;
                }
            }
        }
    }
}
