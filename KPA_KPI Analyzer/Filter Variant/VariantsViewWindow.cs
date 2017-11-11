using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Filter_Variant
{
    public partial class VariantsViewWindow : Form
    {
        public List<Variant> Variants { get; set; }


        /// <summary>
        /// The forms constructor.
        /// </summary>
        public VariantsViewWindow()
        {
            InitializeComponent();
        }




        private void VariantsViewWindow_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }



        /////////////////////////////////////////////////// UI DIALOGS //////////////////////////////////////////////////
        //
        //  here we can control the behavior of the form.
        // 
        //  These functions perform the following
        //  1) minimize the form into the taskbar.
        //  2) maximize the form to the size of the screen and min down to normal size.
        //  3) close the application.
        //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region UI_Dialogs

        /// <summary>
        /// This event will change the background of the button when the user hovers over it.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">The Mouse Enter Event</param>
        private void btn_Minimize_MouseEnter(object sender, EventArgs e)
        {
            pnl_Minimize.BackgroundImage = Properties.Resources.Minimize_Hover_Icon;
        }






        /// <summary>
        /// This event will change the background of the image back to the original image.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">the Mouse Leave event</param>
        private void btn_Minimize_MouseLeave(object sender, EventArgs e)
        {
            pnl_Minimize.BackgroundImage = Properties.Resources.Minimize;
        }






        /// <summary>
        /// This event will trigger when the user clicks the minimize button. The form will minimize into the taskbar.
        /// </summary>
        /// <param name="sender">The minimize button</param>
        /// <param name="e">The click event.</param>
        private void btn_Minimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;






        /// <summary>
        /// This event will change the background of the button when the user hovers over it.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">The Mouse Over event</param>
        private void btn_Close_MouseHover(object sender, EventArgs e)
        {
            pnl_Close.BackgroundImage = Properties.Resources.Close_Hover_icon;
        }






        /// <summary>
        /// This event will change the background of the button back to the original background image.
        /// </summary>
        /// <param name="sender">the close button</param>
        /// <param name="e">The MouseLeave event</param>
        private void btn_Close_MouseLeave(object sender, EventArgs e)
        {
            pnl_Close.BackgroundImage = Properties.Resources.Close;
        }






        /// <summary>
        /// This event will close the entire application (process)
        /// </summary>
        /// <param name="sender">The Close button</param>
        /// <param name="e">The click event</param>
        private void btn_Close_Click(object sender, EventArgs e) => Close();

        #endregion






        /// <summary>
        /// Add all of the user variants to the datagrid view.
        /// </summary>
        private void LoadDataGridView()
        {
            string[] row;
            if(Variants != null)
            {
                foreach(var variant in Variants)
                {
                    row = new string[] { variant.VariantName, variant.Active.ToString(), variant.VariantDescription };
                    dgv_variants.Rows.Add(row);
                }
            }
        }




        /// <summary>
        /// Loads the Variant Detail Display Window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_view_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRow = dgv_variants.SelectedRows;
            
            if(selectedRow.Count == 1)
            {
                DataGridViewRow row = selectedRow[0];
                using (Filter_Variant.VariantsDetailDisplayWindow vddw = new VariantsDetailDisplayWindow()
                {
                    VariantName = Variants[row.Index].VariantName,
                    VariantDescription = Variants[row.Index].VariantDescription,
                    DetailVariants = Variants
                })
                {
                    vddw.ShowDialog();
                }
            }   
        }








        /// <summary>
        /// Removes the selected rows from the list of variants and the datagridview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_remove_Click(object sender, EventArgs e)
        {
            // Get the selected rows
            DataGridViewSelectedRowCollection selectedRows = dgv_variants.SelectedRows;

            // Go throught each selected row and remove from the variant list and the datagridview.
            foreach(DataGridViewRow row in selectedRows)
            {
                int index = row.Index;

                // remove the variant from VariantFilters
                Variants.RemoveAt(index);

                // remove this row from the data grid view.
                dgv_variants.Rows.RemoveAt(index);
            }
        }
    }
}
