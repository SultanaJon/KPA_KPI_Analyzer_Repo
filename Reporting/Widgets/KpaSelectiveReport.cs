using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reporting.Widgets
{
    public partial class KpaSelectiveReport : UserControl
    {
        /// <summary>
        /// Headers for the report. The key is the kpa section and th value is a list of kpas.
        /// </summary>
        Dictionary<string, List<string>> headers = new Dictionary<string, List<string>>();



        /// <summary>
        /// The default constructor
        /// </summary>
        public KpaSelectiveReport()
        {
            InitializeComponent();
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;
                return handleParam;
            }
        }



        /// <summary>
        /// Event that is fired when the form is finished loading.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KpaSelectiveReport_Load(object sender, EventArgs e)
        {
            foreach(ReportingSections.KpaReportingSection section in Enum.GetValues(typeof(ReportingSections.KpaReportingSection)))
            {
                List<string> temp = new List<string>();
                temp.AddRange(ReportingCategories.kpaReportingCategories[(int)section]);
                headers.Add(ReportingSections.kpaReportingSections[(int)section], temp);
            }


            // Add the columns to the datagridview.
            AddColumns();

            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.ColumnHeadersHeight = dataGridView1.ColumnHeadersHeight * 3;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
        }



        private void AddColumns()
        {
            dataGridView1.Columns.Add("Column0", "");

            const string columnName = "Column";
            int colNum = 1;

            foreach (string section in headers.Keys)
            {
                foreach (string category in headers[section])
                {
                    if (section == ReportingSections.kpaReportingSections[(int)ReportingSections.KpaReportingSection.CurrentPlanVsActual])
                    {
                        dataGridView1.Columns.Add(columnName + colNum++, "Average");
                        dataGridView1.Columns.Add(columnName + colNum++, "Total");
                        dataGridView1.Columns.Add(columnName + colNum++, "% Favorable");
                    }
                    else
                    {
                        dataGridView1.Columns.Add(columnName + colNum++, "Average");
                        dataGridView1.Columns.Add(columnName + colNum++, "Total");
                    }
                }
            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            int columnPos = 1;

            foreach (string section in headers.Keys)
            {
                Rectangle r1;

                // Need to check for this section because it has more column than the other.
                if (section == ReportingSections.kpaReportingSections[(int)ReportingSections.KpaReportingSection.CurrentPlanVsActual])
                {
                    r1 = dataGridView1.GetCellDisplayRectangle(columnPos, -1, true);
                    r1.Width = r1.Width * (headers[section].Count * 3) - 2;
                    r1.Height = r1.Height / 3;
                    columnPos += (headers[section].Count * 3);
                }
                else
                {
                    r1 = dataGridView1.GetCellDisplayRectangle(columnPos, -1, true);
                    r1.Width = r1.Width * (headers[section].Count * 2) - 2;
                    r1.Height = r1.Height / 3;
                    columnPos += (headers[section].Count * 2);
                }

                r1.X += 1;
                e.Graphics.FillRectangle(new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1);

                StringFormat format = new StringFormat();

                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(section, dataGridView1.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
            }


            columnPos = 1;

            foreach (string section in headers.Keys)
            {
                foreach (string category in headers[section])
                {
                    Rectangle r1;

                    // need to check for this section because it has more column than the other.
                    if (section == ReportingSections.kpaReportingSections[(int)ReportingSections.KpaReportingSection.CurrentPlanVsActual])
                    {
                        r1 = dataGridView1.GetCellDisplayRectangle(columnPos, -1, true);
                        r1.Width = r1.Width * 3 - 2;
                        r1.Height = r1.Height / 3;
                        columnPos += 3;
                    }
                    else
                    {
                        r1 = dataGridView1.GetCellDisplayRectangle(columnPos, -1, true);
                        r1.Width = r1.Width * 2 - 2;
                        r1.Height = r1.Height / 3;
                        columnPos += 2;
                    }

                    r1.X += 1;
                    r1.Y += r1.Height;

                    e.Graphics.FillRectangle(new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1);

                    StringFormat format = new StringFormat();

                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    e.Graphics.DrawString(category, dataGridView1.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
                }
            }
        }



        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            //InvalidateHeader();
        }


        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            //InvalidateHeader();
        }


        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //InvalidateHeader();
        }





        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex == -1 && e.ColumnIndex > 0)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 3;
                r2.Height = e.CellBounds.Height / 3;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
        }



        private void InvalidateHeader()
        {
            Rectangle recHeader = dataGridView1.DisplayRectangle;
            recHeader.Height = dataGridView1.ColumnHeadersHeight / 3;
            dataGridView1.Invalidate(recHeader);
        }
    }
}
