using Filters;
using Reporting;
using Reporting.KeyPerformanceActions;
using Reporting.KeyPerformanceIndicators;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.PerformanceReporting
{
    public partial class ComparisonReportingWidget : UserControl, IComparisonReportingWidgetView
    {
        #region IComparisonReportingWidgetView Events

        /// <summary>
        /// An event for when the user clicks generate reports
        /// </summary>
        public event EventHandler GenerateReport;

        #endregion

        #region IComparisonReportingWidgetView Properties

        /// <summary>
        /// The performance the comparison report will track
        /// </summary>
        public ReportingType PerformanceReportType { get; set; }


        /// <summary>
        /// The filter option the comparison report will use.
        /// </summary>

        public FilterOptions.Options FilteringOption { get; set; }


        /// <summary>
        /// The KPA that the user will base the report off of.
        /// </summary>
        public KpaOption KPAOption { get; set; }


        /// <summary>
        /// The KPI that the user will base the report off of.
        /// </summary>
        public KpiOption KPIOption { get; set; }

        #endregion



        /// <summary>
        /// Default Constructor
        /// </summary>
        public ComparisonReportingWidget()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Event that fires when the SelectiveReportingWidget Loads.
        /// </summary>
        /// <param name="sender">The Selective Reporting Widget</param>
        /// <param name="e">The Load Event</param>
        private void ComparisonReportingWidget_Load(object sender, EventArgs e)
        {
            // Load the filter options into the filter option combobox.
            LoadFilterOptions();

            // Load the KPA options into the KPA option combobox.
            LoadKpaOptions();
            KPAOption = default(KpaOption);
        }



        /// <summary>
        /// Event that fires when the check state of a radio button changes
        /// </summary>
        /// <param name="sender">The radio button</param>
        /// <param name="e">The CheckedChanged event</param>
        private void radioBtn_Reporting_CheckedChanged(object sender, EventArgs e)
        {
            // Clear the items in the category combobox so a new list can be added.
            comboBox_CategoryOption.Items.Clear();

            if(radioBtn_KpaReporting.Checked)
            {
                label_CategoryOption.Text = "KPA Option:";
                PerformanceReportType = ReportingType.KpaComparisonReport;
                KPAOption = default(KpaOption);
                LoadKpaOptions();
            }
            else
            {
                label_CategoryOption.Text = "KPI Option:";
                PerformanceReportType = ReportingType.KpiComparisonReport;
                KPIOption = default(KpiOption);
                LoadKpiOptions();
            }
        }




        /// <summary>
        /// Loads the filter options into the filter options combobox
        /// </summary>
        private void LoadFilterOptions()
        {
            // Clear the contents of the combobox
            comboBox_FitlerOption.Items.Clear();

            // Get a new data source
            List<string> filterOptions = new List<string>(Filters.FilterOptions.options);
            
            // Populate the combobox
            comboBox_FitlerOption.DataSource = filterOptions;
        }





        /// <summary>
        /// Loads the KPA options into the Category options combobox.
        /// </summary>

        private void LoadKpaOptions()
        {
            // Get the list of actions
            List<string> actions = new List<string>(KeyPerformanceAction.options);

            // Clear the content of the combobox
            comboBox_CategoryOption.Items.Clear();

            // Add each action to the combobox
            foreach(string action in actions)
            {
                comboBox_CategoryOption.Items.Add(action);
            }

            comboBox_CategoryOption.SelectedIndex = 0;

            // Configure the width of the combobox.
            ConfigureCategoryComboBoxWidth();
        }




        /// <summary>
        /// Loads the KPI option into the category options combobox.
        /// </summary>
        private void LoadKpiOptions()
        {
            // Get the list of indicators
            List<string> indicators = new List<string>(KeyPerformanceIndicator.options);

            // Clear the content of the combobox
            comboBox_CategoryOption.Items.Clear();

            // Add each indicator to the combobox
            foreach (string indicator in indicators)
            {
                comboBox_CategoryOption.Items.Add(indicator);
            }

            comboBox_CategoryOption.SelectedIndex = 0;

            // Configure the width of the combobox.
            ConfigureCategoryComboBoxWidth();
        }




        /// <summary>
        /// Sets the comboboxe's contents display width based on the values it holds.
        /// </summary>
        private void ConfigureCategoryComboBoxWidth()
        {
            int maxWidth = 0, temp = 0;
            foreach(var obj in comboBox_CategoryOption.Items)
            {
                temp = TextRenderer.MeasureText(obj.ToString(), comboBox_CategoryOption.Font).Width;
                if (temp > maxWidth)
                    maxWidth = temp;
            }

            try
            {
                comboBox_CategoryOption.DropDownWidth = maxWidth;
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Comparison Widget Exception");
            }
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
        /// Fires when the user clicks generate report
        /// </summary>
        /// <param name="sender">The generate report button</param>
        /// <param name="e">the click event</param>
        private void GenerateComparisonReport_Click(object sender, EventArgs e)
        {
            // Ivokes the callback method if it is not null
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
            if (radioBtn_KpaReporting.Checked)
            {
                PerformanceReportType = ReportingType.KpaComparisonReport;
            }
            else
            {
                PerformanceReportType = ReportingType.KpaComparisonReport;
            }
        }




        /// <summary>
        /// When the user chooses a different Filter option this event will fire.
        /// </summary>
        /// <param name="sender">The filter option combobox</param>
        /// <param name="e">The selected index changed event</param>
        private void comboBox_FitlerOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox_FitlerOption.SelectedIndex;
            foreach (FilterOptions.Options option in Enum.GetValues(typeof(FilterOptions.Options)))
            {
                if (index == (int)option)
                {
                    FilteringOption = option;
                }
            }
        }





        /// <summary>
        /// When the user chooses a different category option this event will fire
        /// </summary>
        /// <param name="sender">The category option combobox</param>
        /// <param name="e">The selected index changed event</param>
        private void comboBox_CategoryOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = default(int);
            if(PerformanceReportType == ReportingType.KpaComparisonReport)
            {
                index = comboBox_CategoryOption.SelectedIndex;
                foreach (KpaOption option in Enum.GetValues(typeof(KpaOption)))
                {
                    if (index == (int)option)
                    {
                        KPAOption = option;
                    }
                }
            }
            else // The Performance Report Type is KPI Comparison Report
            {
                index = comboBox_CategoryOption.SelectedIndex;
                foreach(KpiOption option in Enum.GetValues(typeof(KpiOption)))
                {
                    if(index == (int)option)
                    {
                        KPIOption = option;
                    }
                }
            }
        }
    }
}
