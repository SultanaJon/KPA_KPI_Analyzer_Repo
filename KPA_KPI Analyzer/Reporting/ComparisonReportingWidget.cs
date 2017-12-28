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

            // Configure the width of the combobox.
            ConfigureCategoryComboBoxWidth();
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

            switch(radioBtn.Text)
            {
                case "KPA Report":
                    if(radioBtns[tag].Checked)
                    {
                        label_CategoryOption.Text = "KPA Option";
                    }
                    else
                    {
                        label_CategoryOption.Text = "KPI Option";
                    }
                    break;
                case "KPI Report":
                    if (radioBtns[tag].Checked)
                    {
                        label_CategoryOption.Text = "KPI Option";
                    }
                    else
                    {
                        label_CategoryOption.Text = "KPA Option";
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
            PerformanceTrack performanceTrack = new SelectiveReport();
            List<KeyPerformanceAction> actions = performanceTrack.Actions;

            comboBox_CategoryOption.DataSource = actions;
            comboBox_CategoryOption.DisplayMember = "Name";
            comboBox_CategoryOption.ValueMember = "Section";
        }




        /// <summary>
        /// Loads the KPI option into the category options combobox.
        /// </summary>
        private void LoadKpiOptions()
        {

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
