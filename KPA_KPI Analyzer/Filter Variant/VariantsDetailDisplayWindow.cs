using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Accord.Controls;

namespace KPA_KPI_Analyzer.Filter_Variant
{
    public partial class VariantsDetailDisplayWindow : Form
    {
        public Dictionary<string, List<string>> VariantDetails { get; set; }






        /// <summary>
        /// The name of the variant being viewed.
        /// </summary>
        public string VariantName { get; set; }






        /// <summary>
        /// The description of the variant being viewed.
        /// </summary>
        public string VariantDescription { get; set; }






        /// <summary>
        /// Default constructor
        /// </summary>
        public VariantsDetailDisplayWindow()
        {
            InitializeComponent();
        }





        /// <summary>
        /// This event will trigger once the form has finished loading.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VariantsDetailDisplayWindow_Load(object sender, EventArgs e)
        {
            lbl_VariantName.Text = VariantName;
            lbl_VariantDescription.Text = VariantDescription;

            // Need to load the details into the datagridview.
            LoadDataGridView();
        }


        

        /// <summary>
        /// Gets the highest number of element contained within the details of the filters.
        /// </summary>
        /// <returns></returns>
        private int GetMaxLength()
        {
            int maxLength = -99999;
            foreach(var list in VariantDetails.Values)
                if (list.Count > maxLength)
                    maxLength = list.Count;

            return maxLength;
        }




        
        /// <summary>
        /// Populate the empty cells of the variant details.
        /// </summary>
        private void CleanVariantDetails(int highestNumElement)
        {
            foreach(var list in VariantDetails.Values)
            {
                if(list.Count < highestNumElement)
                {
                    for(int i = list.Count; i < highestNumElement; ++i)
                        list.Add(string.Empty);
                }
            }
        }




        /// <summary>
        /// 
        /// </summary>
        private void LoadDataGridView()
        {
            int maxLength = GetMaxLength();
            CleanVariantDetails(maxLength);


            for (int i = 0; i < maxLength; ++i)
            {
                string[] row =
                {
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PrDateRange]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PoLineCreateDateRange]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.FinalRecDateRange]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.AdvancedFilters]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.ProjectNumber]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.WbsElement]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.Material]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.MaterialGroup]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.Vendor]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.VendorDesciption]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PrPurchGroup]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PoPurchGroup]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.IrSuppName]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.FxdSuppName]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.DsrdSuppName]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.CommCategory]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.Escaped]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PoDocType]][i],
                    VariantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.ProdOrdMaterial]][i]
                };
                dgv_details.Rows.Add(row);
            }
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
    }
}
