using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reporting;
using Reporting.KeyPerformanceActions;
using Reporting.KeyPerformanceIndicators;

namespace KPA_KPI_Analyzer.Reporting
{
    public partial class ComparisonReportingWidget : UserControl
    {
        List<MaterialSkin.Controls.MaterialRadioButton> radioBtns = new List<MaterialSkin.Controls.MaterialRadioButton>();

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
            // holding the radio buttons in a list.
            radioBtns.Add(radioBtn_KpaReporting);
            radioBtns.Add(radioBtn_KpiReporting);

            // Load the filter options into the filter option combobox.
            LoadFilterOptions();

            // Load the KPA options into the KPA option combobox.
            LoadKpaOptions();
        }



        /// <summary>
        /// Event that fires when the check state of a radio button changes
        /// </summary>
        /// <param name="sender">The radio button</param>
        /// <param name="e">The CheckedChanged event</param>
        private void radioBtn_Reporting_CheckedChanged(object sender, EventArgs e)
        {
            MaterialSkin.Controls.MaterialRadioButton radioBtn = (MaterialSkin.Controls.MaterialRadioButton)sender;
            int tag = int.Parse(radioBtn.Tag.ToString());

            // Clear the items in the category combobox so a new list can be added.
            comboBox_CategoryOption.Items.Clear();

            switch(radioBtn.Text)
            {
                case "KPA Report":
                    if(radioBtns[tag].Checked)
                    {
                        label_CategoryOption.Text = "KPA Option:";
                        LoadKpaOptions();
                    }
                    else
                    {
                        label_CategoryOption.Text = "KPI Option:";
                        LoadKpiOptions();
                    }
                    break;
                case "KPI Report":
                    if (radioBtns[tag].Checked)
                    {
                        label_CategoryOption.Text = "KPI Option:";
                        LoadKpiOptions();
                    }
                    else
                    {
                        label_CategoryOption.Text = "KPA Option:";
                        LoadKpaOptions();
                    }
                    break;
            }
        }



        /// <summary>
        /// Event that fires when the user clicks the Generate Report button.
        /// </summary>
        /// <param name="sender">The Generate Report Button</param>
        /// <param name="e">The Click event</param>
        private void btn_GenerateReport_Click(object sender, EventArgs e)
        {
            if(radioBtn_KpaReporting.Checked)
            {

            }
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

        /// <summary>
        /// Loads the KPA options into the Category options combobox.
        /// </summary>

        private void LoadKpaOptions()
        {
            //SelectiveReport kpaReport = new SelectiveReport();
            //List<KeyPerformanceAction> actions = kpaReport.Actions;

            //foreach(KeyPerformanceAction action in actions)
            //{
            //    comboBox_CategoryOption.Items.Add(action.Section + " - " + action.Name);
            //}

            //comboBox_CategoryOption.SelectedIndex = 0;

            //// Configure the width of the combobox.
            //ConfigureCategoryComboBoxWidth();
        }




        /// <summary>
        /// Loads the KPI option into the category options combobox.
        /// </summary>
        private void LoadKpiOptions()
        {
            //SelectiveReport kpiReport = new SelectiveReport();
            //List<KeyPerformanceIndicator> indicators = kpiReport.Indicators;

            //foreach (KeyPerformanceIndicator indicator in indicators)
            //{
            //    comboBox_CategoryOption.Items.Add(indicator.Section + " - " + indicator.Name);
            //}

            //comboBox_CategoryOption.SelectedIndex = 0;

            //// Configure the width of the combobox.
            //ConfigureCategoryComboBoxWidth();
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
    }
}
