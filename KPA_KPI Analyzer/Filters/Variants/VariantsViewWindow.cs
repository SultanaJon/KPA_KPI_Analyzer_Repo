﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Filters.Variants
{
    public partial class VariantsViewWindow : Form
    {
        #region DELEGATES & EVENTS
        // Call-back functions to update variants tools.
        public delegate void UpdateVariantToolsHandler();
        public static event UpdateVariantToolsHandler UpdateVariantTools;


        // Call-back function to begin data loading of the users variant.
        public delegate void BeginVariantLoadHandler(Dictionary<string, List<string>> _filters);
        public static event BeginVariantLoadHandler BeginVariantLoadProcess;
        #endregion


        public List<Variant> Variants { get; set; }




        /// <summary>
        /// The forms constructor.
        /// </summary>
        public VariantsViewWindow()
        {
            InitializeComponent();
        }






        /// <summary>
        /// After the application loads, this event will trigger.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VariantsViewWindow_Load(object sender, EventArgs e)
        {
            LoadDataGridView();

            if (Variants.Count > 0)
                ToggleButtons(true);
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
            pnl_Minimize.BackgroundImage = KPA_KPI_Analyzer.Properties.Resources.Minimize_Hover_Icon;
        }






        /// <summary>
        /// This event will change the background of the image back to the original image.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">the Mouse Leave event</param>
        private void btn_Minimize_MouseLeave(object sender, EventArgs e)
        {
            pnl_Minimize.BackgroundImage = KPA_KPI_Analyzer.Properties.Resources.Minimize;
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
            pnl_Close.BackgroundImage = KPA_KPI_Analyzer.Properties.Resources.Close_Hover_icon;
        }






        /// <summary>
        /// This event will change the background of the button back to the original background image.
        /// </summary>
        /// <param name="sender">the close button</param>
        /// <param name="e">The MouseLeave event</param>
        private void btn_Close_MouseLeave(object sender, EventArgs e)
        {
            pnl_Close.BackgroundImage = KPA_KPI_Analyzer.Properties.Resources.Close;
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
            dgv_variants.Rows.Clear();
            dgv_variants.Refresh();
            string[] row;
            if(Variants != null)
            {
                foreach(var variant in Variants)
                {
                    row = new string[] { variant.VariantName, variant.Active.ToString(), variant.VariantDescription };
                    dgv_variants.Rows.Add(row);
                }
            }
            dgv_variants.Refresh();
        }






        /// <summary>
        /// Toggle whether or not the buttons are enabled.
        /// </summary>
        /// <param name="_on">Boolean value indicating to turn on or off the buttons.</param>
        private void ToggleButtons(bool _on)
        {
            if(_on)
            {
                // Enable the buttons
                btn_apply.Enabled = true;
                btn_remove.Enabled = true;
                btn_edit.Enabled = true;
                btn_view.Enabled = true;
            }
            else
            {
                // Disable the buttons
                btn_apply.Enabled = false;
                btn_remove.Enabled = false;
                btn_edit.Enabled = false;
                btn_view.Enabled = false;
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
                using (VariantsDetailDisplayWindow vddw = new VariantsDetailDisplayWindow()
                {
                    VariantName = Variants[row.Index].VariantName,
                    VariantDescription = Variants[row.Index].VariantDescription,
                    VariantDetails = Variants[row.Index].details.ToDictionary(x => x.Key, x => x.Value.ToList())
                })
                {
                    vddw.ShowDialog();
                }
            }   
        }






        /// <summary>
        /// Removes the selected rows from the list of variants and the datagridview.
        /// </summary>
        /// <param name="sender">The remove button</param>
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

            if(Variants.Count == 0)
            {
                ToggleButtons(false);
            }

            UpdateVariantTools();
        }






        /// <summary>
        /// Applies the users saved variant against the data.
        /// </summary>
        /// <param name="sender">The apply button</param>
        /// <param name="e">the click event</param>
        private void btn_apply_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRow = dgv_variants.SelectedRows;
            if (selectedRow.Count == 1)
            {
                // There is only one row so grab the first one.
                DataGridViewRow row = selectedRow[0];
                DeactivateVariants();

                // The user want to load this variant so set it to active.
                Variants[row.Index].Active = true;
                BeginVariantLoadProcess(Variants[row.Index].details);
            }
            else
                return;
        }






        /// <summary>
        /// Deavtivate the variants.
        /// </summary>
        public void DeactivateVariants()
        {
            foreach (Variant variant in Variants)
                variant.Active = false;
        }







        /// <summary>
        /// Allows the user to edit the name and the description of the variant.
        /// </summary>
        /// <param name="sender">The edit button</param>
        /// <param name="e">The click event</param>
        private void btn_edit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRow = dgv_variants.SelectedRows;

            if(selectedRow.Count == 1)
            {
                DataGridViewRow row = selectedRow[0];
                using (VariantsEditWindow editWind = new VariantsEditWindow() {
                    VariantName = Variants[row.Index].VariantName,
                    VariantDescription = Variants[row.Index].VariantDescription
                })
                {
                    if(editWind.ShowDialog() == DialogResult.OK)
                    {
                        Variants[row.Index].VariantName = editWind.VariantName;
                        Variants[row.Index].VariantDescription = editWind.VariantDescription;
                        LoadDataGridView();
                    }
                }
            }
        }
    }
}