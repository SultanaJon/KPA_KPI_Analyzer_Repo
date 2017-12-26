using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reporting.Selective
{
    public partial class SelectiveReportControlsWidget : UserControl
    {
        List<Bunifu.Framework.UI.BunifuCheckbox> reportingCheckBoxes = new List<Bunifu.Framework.UI.BunifuCheckbox>();
        List<GroupBox> reportingGroupBoxes = new List<GroupBox>();

        private enum ReportingType
        {
            KpaKpiReport,
            ComparisonReport
        }


        public SelectiveReportControlsWidget()
        {
            InitializeComponent();

        }



        private void SelectiveReportControlsWidget_Load(object sender, EventArgs e)
        {
            reportingCheckBoxes.Add(chkBox_KpaKpiReporting);
            reportingCheckBoxes.Add(chkBox_ComparisonReporting);
            reportingGroupBoxes.Add(groupBox_KpaKpiReporting);
            reportingGroupBoxes.Add(groupBox_ComparisonReporting);
        }








        /// <summary>
        /// Toggles the check mode between the KPA & KPI Reporting checkbox & the Comparison checkbox.
        /// </summary>
        /// <param name="sender">The checkbox</param>
        /// <param name="e">The on change event</param>
        private void chkBox_ReportingOptions_OnChange(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuCheckbox chkBox = (Bunifu.Framework.UI.BunifuCheckbox)sender;
            int tag = int.Parse(chkBox.Tag.ToString());

            switch(tag)
            {
                case (int)ReportingType.KpaKpiReport:
                    if(chkBox.Checked)
                    {
                        reportingCheckBoxes[(int)ReportingType.ComparisonReport].Checked = false;
                        reportingGroupBoxes[(int)ReportingType.ComparisonReport].Enabled = false;
                    }
                    else
                    {
                        reportingCheckBoxes[(int)ReportingType.ComparisonReport].Checked = false;
                        reportingGroupBoxes[(int)ReportingType.ComparisonReport].Enabled = false;
                    }
                    break;
                case (int)ReportingType.ComparisonReport:
                    if (chkBox.Checked)
                    {
                        reportingCheckBoxes[(int)ReportingType.KpaKpiReport].Checked = false;
                        reportingGroupBoxes[(int)ReportingType.KpaKpiReport].Enabled = false;
                    }
                    else
                    {
                        reportingCheckBoxes[(int)ReportingType.KpaKpiReport].Checked = false;
                        reportingGroupBoxes[(int)ReportingType.KpaKpiReport].Enabled = false;
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
