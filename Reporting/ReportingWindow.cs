using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reporting
{
    public partial class ReportingWindow : Form
    {
        public ReportingWindow()
        {
            InitializeComponent();
        }

        private void ReportingWindow_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Add(new Widgets.KpaSelectiveReport() { Dock = DockStyle.Fill });
        }
    }
}
