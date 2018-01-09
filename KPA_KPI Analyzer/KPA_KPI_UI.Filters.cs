using DataAccessLibrary;
using Filters;
using Filters.Variants;
using Reporting;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI : Form
    {
        #region FIELD DATA

        string filters = string.Empty;
        List<Bunifu.Framework.UI.BunifuCheckbox> checkBoxes = new List<Bunifu.Framework.UI.BunifuCheckbox>();
        List<CheckedListBox> checkListBoxes = new List<CheckedListBox>();

        #endregion


        #region EVENTS

        /// <summary>
        /// Updates the contents of the of the checked list boxes on the filters page.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filter"></param>
        public void UpdateFilters(HashSet<string> data, FilterColumn filter)
        {
            HasFiltersAdded();
            UpdateFilterButtons();
            List<string> lst = new List<string>();

            switch ((int)filter)
            {
                case 1:
                    ChkdListBx_ProjectNumber.Invoke((MethodInvoker)delegate {
                        ChkdListBx_ProjectNumber.Items.Clear();
                        lst = new List<string>(data);
                        ChkdListBx_ProjectNumber.Items.AddRange(lst.ToArray());
                    });
                    break;
                case 2: // WBS Element
                    ChkdListBx_WBSElement.Invoke((MethodInvoker)delegate {
                        ChkdListBx_WBSElement.Items.Clear();
                        lst = new List<string>(data);
                        ChkdListBx_WBSElement.Items.AddRange(lst.ToArray());
                    });
                    
                    break;
                case 3: // Material
                    ChkdListBx_Material.Invoke((MethodInvoker)delegate {
                        ChkdListBx_Material.Items.Clear();
                        lst = new List<string>(data);
                        ChkdListBx_Material.Items.AddRange(lst.ToArray());
                    });
                    break;
                case 4: // Material Group
                    ChkdListBx_MaterialGroup.Invoke((MethodInvoker)delegate {
                        ChkdListBx_MaterialGroup.Items.Clear();
                        lst = new List<string>(data);
                        ChkdListBx_MaterialGroup.Items.AddRange(lst.ToArray());
                    });
                    break;
                case 5:// Vendor
                    ChkdListBx_Vendor.Invoke((MethodInvoker)delegate {
                        ChkdListBx_Vendor.Items.Clear();
                        lst = new List<string>(data);
                        ChkdListBx_Vendor.Items.AddRange(lst.ToArray());
                    });
                    break;
                case 6: // Vendor Description
                    ChkdListBx_VendorDesc.Invoke((MethodInvoker)delegate {
                        ChkdListBx_VendorDesc.Items.Clear();
                        lst = new List<string>(data);
                        ChkdListBx_VendorDesc.Items.AddRange(lst.ToArray());
                    });
                    break;
                case 7: // PR Purch Group
                    ChkdListBx_PrPurchGroup.Invoke((MethodInvoker)delegate {
                        ChkdListBx_PrPurchGroup.Items.Clear();
                        lst = new List<string>(data);
                        ChkdListBx_PrPurchGroup.Items.AddRange(lst.ToArray());
                    });
                    break;
                case 8: // PO Purch Group
                    ChkdListBx_PoPurchGroup.Invoke((MethodInvoker)delegate {
                        ChkdListBx_PoPurchGroup.Items.Clear();
                        lst = new List<string>(data);
                        ChkdListBx_PoPurchGroup.Items.AddRange(lst.ToArray());
                    });
                    break;
                case 9: // IR Supp Name
                    ChkdListBx_IRSuppName.Invoke((MethodInvoker)delegate {
                        ChkdListBx_IRSuppName.Items.Clear();
                        lst = new List<string>(data);
                        ChkdListBx_IRSuppName.Items.AddRange(lst.ToArray());
                    });
                    break;
                case 10: // Fxd Supp Name
                    ChkdListBx_FxdSuppName.Invoke((MethodInvoker)delegate {
                        ChkdListBx_FxdSuppName.Items.Clear();
                        lst = new List<string>(data);
                        ChkdListBx_FxdSuppName.Items.AddRange(lst.ToArray());
                    });
                    break;
                case 11: // Dsrd Supp Name
                    ChkdListBx_DsrdSuppName.Invoke((MethodInvoker)delegate {
                        ChkdListBx_DsrdSuppName.Items.Clear();
                        lst = new List<string>(data);
                        ChkdListBx_DsrdSuppName.Items.AddRange(lst.ToArray());
                    });
                    break;
                case 12: // Commodity Category
                    ChkdListBx_CommodityCat.Invoke((MethodInvoker)delegate {
                        ChkdListBx_CommodityCat.Items.Clear();
                        lst = new List<string>(data);
                        ChkdListBx_CommodityCat.Items.AddRange(lst.ToArray());
                    });
                    break;
                case 13: // Escaped
                    ChkdListBx_Escaped.Invoke((MethodInvoker)delegate {
                        ChkdListBx_Escaped.Items.Clear();
                        lst = new List<string>(data);
                        ChkdListBx_Escaped.Items.AddRange(lst.ToArray());
                    });
                    break;
                case 14: // PO Document Type
                    ChkdListBx_poDocumentType.Invoke((MethodInvoker)delegate {
                        ChkdListBx_poDocumentType.Items.Clear();
                        lst = new List<string>(data);
                        ChkdListBx_poDocumentType.Items.AddRange(lst.ToArray());
                    });
                    break;
                case 15: // Production Order Material
                    ChkdListBx_productionOrderMat.Invoke((MethodInvoker)delegate {
                        ChkdListBx_productionOrderMat.Items.Clear();
                        lst = new List<string>(data);
                        ChkdListBx_productionOrderMat.Items.AddRange(lst.ToArray());
                    });
                    break;
                default:
                    break;
            }
        }





        public void LoadFilters()
        {
            HashSet<string> data = new HashSet<string>();
            data = FilterManager.GetUniqueProjectNumber();
            UpdateFilters(data, FilterColumn.ProjectNUm_ProdOrdWbs);

            data = FilterManager.GetUniqueWbsElement();
            UpdateFilters(data, FilterColumn.WBS_Element);

            data = FilterManager.GetUniqueMaterial();
            UpdateFilters(data, FilterColumn.Material);

            data = FilterManager.GetUniqueMaterialGroup();
            UpdateFilters(data, FilterColumn.MaterialGroup);

            data = FilterManager.GetUniqueVendor();
            UpdateFilters(data, FilterColumn.Vendor);

            data = FilterManager.GetUniqueVendorDescription();
            UpdateFilters(data, FilterColumn.VendorDescription);

            data = FilterManager.GetUniquePrPurchaseGroup();
            UpdateFilters(data, FilterColumn.PurchGroup);

            data = FilterManager.GetUniquePoPurchaseGroup();
            UpdateFilters(data, FilterColumn.PoPurchGroup);

            data = FilterManager.GetUniqueIrSuppName();
            UpdateFilters(data, FilterColumn.IRSuppName);

            data = FilterManager.GetUniqueFxdSuppName();
            UpdateFilters(data, FilterColumn.FxdSuppName);

            data = FilterManager.GetUniqueDsrdSuppName();
            UpdateFilters(data, FilterColumn.DsrdSuppName);

            data = FilterManager.GetUniqueCommodityCategory();
            UpdateFilters(data, FilterColumn.CommCat);

            data = FilterManager.GetUniqueEscaped();
            UpdateFilters(data, FilterColumn.Escaped);

            data = FilterManager.GetUniquePoDocumentType();
            UpdateFilters(data, FilterColumn.PoDocumentType);

            data = FilterManager.GetUniqueProductionOrderMaterial();
            UpdateFilters(data, FilterColumn.ProdOrderMaterial);

            FilterUtils.FiltersLoaded = true;
        }




        /// <summary>
        /// When a check box is check this event will fire.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ckdListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox clb = (CheckedListBox)sender;
            int tag = int.Parse(clb.Tag.ToString());

            switch (tag)
            {
                case 0:
                    if (e.NewValue == CheckState.Checked)
                    {
                        FilterData.ColumnFilters.projectNumber.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        FilterData.ColumnFilters.projectNumber.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 1: // WBS Element
                    if (e.NewValue == CheckState.Checked)
                    {
                        FilterData.ColumnFilters.wbsElement.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        FilterData.ColumnFilters.wbsElement.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 2: // Material
                    if (e.NewValue == CheckState.Checked)
                    {
                        FilterData.ColumnFilters.material.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        FilterData.ColumnFilters.material.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 3: // Material Group
                    if (e.NewValue == CheckState.Checked)
                    {
                        FilterData.ColumnFilters.materialGroup.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        FilterData.ColumnFilters.materialGroup.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 4: // Vendor
                    if (e.NewValue == CheckState.Checked)
                    {
                        FilterData.ColumnFilters.vendor.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        FilterData.ColumnFilters.vendor.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 5: // Vendor Desc
                    if (e.NewValue == CheckState.Checked)
                    {
                        FilterData.ColumnFilters.vendorDesc.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        FilterData.ColumnFilters.vendorDesc.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 6: // PR Purch Group
                    if (e.NewValue == CheckState.Checked)
                    {
                        FilterData.ColumnFilters.purchGroup.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        FilterData.ColumnFilters.purchGroup.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 7: // PO Purch Group
                    if (e.NewValue == CheckState.Checked)
                    {
                        FilterData.ColumnFilters.poPurchGroup.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        FilterData.ColumnFilters.poPurchGroup.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 8: // IR Supp Name
                    if (e.NewValue == CheckState.Checked)
                    {
                        FilterData.ColumnFilters.irSuppName.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        FilterData.ColumnFilters.irSuppName.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 9: // Fxd Supp Name
                    if (e.NewValue == CheckState.Checked)
                    {
                        FilterData.ColumnFilters.fxdSuppName.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        FilterData.ColumnFilters.fxdSuppName.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 10: // Dsrd Supp Name
                    if (e.NewValue == CheckState.Checked)
                    {
                        FilterData.ColumnFilters.dsrdSuppName.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        FilterData.ColumnFilters.dsrdSuppName.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 11: // Commodity Category
                    if (e.NewValue == CheckState.Checked)
                    {
                        FilterData.ColumnFilters.commCategory.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        FilterData.ColumnFilters.commCategory.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 12: // Escaped
                    if (e.NewValue == CheckState.Checked)
                    {
                        FilterData.ColumnFilters.escaped.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        FilterData.ColumnFilters.escaped.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 13: // PO Document Type
                    if (e.NewValue == CheckState.Checked)
                    {
                        FilterData.ColumnFilters.poDocumentType.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        FilterData.ColumnFilters.poDocumentType.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 14: // PO Document Type
                    if (e.NewValue == CheckState.Checked)
                    {
                        FilterData.ColumnFilters.prodOrderMat.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        FilterData.ColumnFilters.prodOrderMat.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
            }
            HasFiltersAdded();
            UpdateFilterButtons();
        }



        /// <summary>
        /// Determines if the PR or PO date ranges are valid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dp_DateRangeChange(object sender, EventArgs e)
        {
            if (FilterData.DateFilters.FilterByPrDateRange || FilterData.DateFilters.FilterByPoDateRange || FilterData.DateFilters.FilterByFinalReceiptDate)
            {
                Bunifu.Framework.UI.BunifuDatepicker dp = (Bunifu.Framework.UI.BunifuDatepicker)sender;
                int tag = int.Parse(dp.Tag.ToString());
                CheckDateRange(tag);
            }
        }





        /// <summary>
        /// Any filters that are checked will be unchecked and the filters check lists
        /// will be set back to the normal state.
        /// </summary>
        /// <param name="sender">the clear filters button</param>
        /// <param name="e">The click event</param>
        private void btn_clearSelected_Click(object sender, EventArgs e)
        {
            filters = string.Empty;
            ClearSelected();
            UpdateFilterButtons();
        }





        /// <summary>
        /// Apply the filters and load the data again with the filters applied.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_applyFilters_Click(object sender, EventArgs e)
        {
            GetCheckedColumnFilters();

            if (FilterData.DateFilters.FilterByPrDateRange)
            {
                if (CheckDateRange(0))
                {
                    FilterData.DateFilters.FilterByPrDateRange = false;
                    return;
                }
                else
                {
                    FilterData.DateFilters.PrFromDate = dp_PRFromDate.Value;
                    FilterData.DateFilters.PrToDate = dp_PRToDate.Value;
                    FilterData.DateFilters.FilterByPrDateRange = true;
                }
            }
            else
            {
                FilterData.DateFilters.FilterByPrDateRange = false;
            }


            if (FilterData.DateFilters.FilterByPoDateRange)
            {
                if (CheckDateRange(2))
                {
                    FilterData.DateFilters.FilterByPoDateRange = false;
                    return;
                }
                else
                {
                    FilterData.DateFilters.PoFromDate = dp_POFromDate.Value;
                    FilterData.DateFilters.PoToDate = dp_POToDate.Value;
                    FilterData.DateFilters.FilterByPoDateRange = true;
                }
            }
            else
            {
                FilterData.DateFilters.FilterByPoDateRange = false;
            }



            if (FilterData.DateFilters.FilterByFinalReceiptDate)
            {
                if (CheckDateRange(4))
                {
                    FilterData.DateFilters.FilterByFinalReceiptDate = false;
                    return;
                }
                else
                {
                    FilterData.DateFilters.FinalReceiptFromDate = dp_finalReceiptFromDate.Value;
                    FilterData.DateFilters.FinalReceiptToDate = dp_finalReciptToDate.Value;
                    FilterData.DateFilters.FilterByFinalReceiptDate = true;
                }
            }
            else
            {
                FilterData.DateFilters.FilterByFinalReceiptDate = false;
            }



            BuildQueryFilters();

            CheckFilterStatus();

            DatabaseManager.Filters = filters; 

            // Toggles the variant tools within the menu strip based on certain conditions.
            CheckActiveVariants();

            // Check the filter status to update the variant tools.
            UpdateVariantTools();
            BeginDataLoadProcess();
        }





        /// <summary>
        /// Clear the filters and set everything back to default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_clearFilters_Click(object sender, EventArgs e)
        {
            filters = string.Empty;
            ClearFilters();
            UpdateFilterButtons();


            // Load the KPA Overall data from local file
            (reports[ReportingType.KpaOverall] as KpaOverallReport).Load();

            // Load the KPA Overall data from local file
            (reports[ReportingType.KpiOverall] as KpiOverallReport).Load();



            // Dactivate all of the variants.
            DeactivateVariants();

            // Update the variant tools within the menu strip.
            UpdateVariantTools();
        }






        /// <summary>
        /// When the state of a checkbox changes, this event will trigger.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_OnChange(object sender, EventArgs e)
        {
            try
            {

                Bunifu.Framework.UI.BunifuCheckbox chkBox = (Bunifu.Framework.UI.BunifuCheckbox)sender;
                int tag = int.Parse(chkBox.Tag.ToString());
                CheckFilters(tag);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter Checkbox OnChange Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        /// <summary>
        /// When a user clicks a label associated with date ranges or advanced filters, this event will trigger.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filterLabel_Click(object sender, EventArgs e)
        {
            try
            {
                Bunifu.Framework.UI.BunifuCustomLabel label = (Bunifu.Framework.UI.BunifuCustomLabel)sender;
                int tag = int.Parse(label.Tag.ToString());

                if (checkBoxes[tag].Checked)
                {
                    checkBoxes[tag].Checked = false;
                }
                else
                {
                    checkBoxes[tag].Checked = true;
                }

                CheckFilters(tag);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter Label Click Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        #region HELPER FUNCTIONS

        /// <summary>
        /// Depending on if the PR or PO date range filter is checked. The from date and to date will be compared and
        /// a message box will be prompted to the user if the selected dates are incorrect.
        /// </summary>
        /// <returns>Returns whether or not the the date range of either the PR or PO date range is value. True if the date range is not valid and false if the date range is valid.</returns>
        /// <param name="datePickerTag"></param>
        private bool CheckDateRange(int datePickerTag)
        {
            DateTime prFrom;
            DateTime prTo;
            DateTime poFrom;
            DateTime poTo;
            DateTime finalRecFrom;
            DateTime finalRecTo;

            switch (datePickerTag)
            {
                case 0: // pr from date tag number
                case 1: // pr to date tag number
                    prFrom = dp_PRFromDate.Value;
                    prTo = dp_PRToDate.Value;
                    if (prFrom > prTo)
                    {
                        btn_applyFilters.Enabled = false;
                        MessageBox.Show("The PR from date cannot greater than the PR to date!", "PR Date Range Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        btn_applyFilters.Enabled = true;
                    }
                    break;
                case 2: // po from date tag number
                case 3: // po to date tag number
                    poFrom = dp_POFromDate.Value;
                    poTo = dp_POToDate.Value;
                    if (poFrom > poTo)
                    {
                        btn_applyFilters.Enabled = false;
                        MessageBox.Show("The PO from date cannot greater than the PO to date!", "PO Date Range Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        btn_applyFilters.Enabled = true;
                    }
                    break;
                case 4: // final receipt from date tag number
                case 5: // final receipt to date tag number
                    finalRecFrom = dp_finalReceiptFromDate.Value;
                    finalRecTo = dp_finalReciptToDate.Value;
                    if (finalRecFrom > finalRecTo)
                    {
                        btn_applyFilters.Enabled = false;
                        MessageBox.Show("The final recipt from date cannot greater than the final receipt to date!", "Final Receipt Date Range Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        btn_applyFilters.Enabled = true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }




        /// <summary>
        /// Checks the date filters that are applied.
        /// </summary>
        public void UpdateDateFilterCheckedItems()
        {
            if (FilterData.DateFilters.Applied)
            {
                if (FilterData.DateFilters.FilterByPrDateRange)
                {
                    chkBox_PrDateRange.Checked = true;
                    dp_PRFromDate.Value = FilterData.DateFilters.PrFromDate;
                    dp_PRToDate.Value = FilterData.DateFilters.PrToDate;
                }

                if (FilterData.DateFilters.FilterByPoDateRange)
                {
                    chkBox_PoDateRange.Checked = true;
                    dp_POFromDate.Value = FilterData.DateFilters.PoFromDate;
                    dp_POToDate.Value = FilterData.DateFilters.PoToDate;
                }

                if (FilterData.DateFilters.FilterByFinalReceiptDate)
                {
                    chkBox_FinalReceiptDate.Checked = true;
                    dp_finalReceiptFromDate.Value = FilterData.DateFilters.FinalReceiptFromDate;
                    dp_finalReciptToDate.Value = FilterData.DateFilters.FinalReceiptToDate;
                }
            }
        }




        /// <summary>
        /// Checks the advanced filters that are applied.
        /// </summary>
        public void UpdateAdvancedFilterCheckedItems()
        {
            if (FilterData.AdvancedFilters.Applied)
            {
                if (!FilterData.AdvancedFilters.FilterByServicePrPo)
                {
                    chkBox_servicePrPo.Checked = false;
                }

                if (!FilterData.AdvancedFilters.FilterBySteelPrPo)
                {
                    chkBox_SteelPrPo.Checked = false;
                }

                if (!FilterData.AdvancedFilters.FilterByPouPrPo)
                {
                    chkBox_pouPrPo.Checked = false;
                }

                if (!FilterData.AdvancedFilters.FilterByIntercompPo)
                {
                    chkBox_IntCompPo.Checked = false;
                }

                if (!FilterData.AdvancedFilters.FilterByCodifiedMatNonSubcont)
                {
                    chkBox_codifiedMatNonSub.Checked = false;
                }

                if (!FilterData.AdvancedFilters.FilterByCodifiedMatSubcont)
                {
                    chkBox_codifiedMatSubCon.Checked = false;
                }

                if (!FilterData.AdvancedFilters.FilterByManualPr)
                {
                    chkBox_manualPr.Checked = false;
                }
            }
        }



        /// <summary>
        /// Checks the column filters that are applied.
        /// </summary>
        private void UpdateColumnFilterCheckedItems()
        {
            int index = 0;


            if (FilterData.ColumnFilters.Applied)
            {
                // Project Number
                if (FilterData.ColumnFilters.projectNumber.Count > 0)
                {
                    ChkdListBx_ProjectNumber.ItemCheck -= ckdListBox_ItemCheck;
                    foreach (string str in FilterData.ColumnFilters.projectNumber)
                    {
                        index = ChkdListBx_ProjectNumber.Items.IndexOf(str);
                        if (index >= 0)
                        {
                            if (!ChkdListBx_ProjectNumber.GetItemChecked(index))
                                ChkdListBx_ProjectNumber.SetItemChecked(index, true);
                        }
                    }
                    ChkdListBx_ProjectNumber.ItemCheck += ckdListBox_ItemCheck;
                }



                // WBS Element
                if (FilterData.ColumnFilters.wbsElement.Count > 0)
                {
                    ChkdListBx_WBSElement.ItemCheck -= ckdListBox_ItemCheck;
                    foreach (string str in FilterData.ColumnFilters.wbsElement)
                    {
                        index = ChkdListBx_WBSElement.Items.IndexOf(str);
                        if (index >= 0)
                        {
                            if (!ChkdListBx_WBSElement.GetItemChecked(index))
                                ChkdListBx_WBSElement.SetItemChecked(index, true);
                        }
                    }
                    ChkdListBx_WBSElement.ItemCheck += ckdListBox_ItemCheck;
                }


                // Material
                if (FilterData.ColumnFilters.material.Count > 0)
                {
                    ChkdListBx_Material.ItemCheck -= ckdListBox_ItemCheck;
                    foreach (string str in FilterData.ColumnFilters.material)
                    {
                        index = ChkdListBx_Material.Items.IndexOf(str);
                        if (index >= 0)
                        {
                            if (!ChkdListBx_Material.GetItemChecked(index))
                                ChkdListBx_Material.SetItemChecked(index, true);
                        }
                    }
                    ChkdListBx_Material.ItemCheck += ckdListBox_ItemCheck;
                }


                // Material Group
                if (FilterData.ColumnFilters.materialGroup.Count > 0)
                {
                    ChkdListBx_MaterialGroup.ItemCheck -= ckdListBox_ItemCheck;
                    foreach (string str in FilterData.ColumnFilters.materialGroup)
                    {
                        index = ChkdListBx_MaterialGroup.Items.IndexOf(str);
                        if (index >= 0)
                        {
                            if (!ChkdListBx_MaterialGroup.GetItemChecked(index))
                                ChkdListBx_MaterialGroup.SetItemChecked(index, true);
                        }
                    }
                    ChkdListBx_MaterialGroup.ItemCheck += ckdListBox_ItemCheck;
                }


                // Vendor
                if (FilterData.ColumnFilters.vendor.Count > 0)
                {
                    ChkdListBx_Vendor.ItemCheck -= ckdListBox_ItemCheck;
                    foreach (string str in FilterData.ColumnFilters.vendor)
                    {
                        index = ChkdListBx_Vendor.Items.IndexOf(str);
                        if (index >= 0)
                        {
                            if (!ChkdListBx_Vendor.GetItemChecked(index))
                                ChkdListBx_Vendor.SetItemChecked(index, true);
                        }
                    }
                    ChkdListBx_Vendor.ItemCheck += ckdListBox_ItemCheck;
                }


                // Vendor Description
                if (FilterData.ColumnFilters.vendorDesc.Count > 0)
                {
                    ChkdListBx_VendorDesc.ItemCheck -= ckdListBox_ItemCheck;
                    foreach (string str in FilterData.ColumnFilters.vendorDesc)
                    {
                        index = ChkdListBx_VendorDesc.Items.IndexOf(str);
                        if (index >= 0)
                        {
                            if (!ChkdListBx_VendorDesc.GetItemChecked(index))
                                ChkdListBx_VendorDesc.SetItemChecked(index, true);
                        }
                    }
                    ChkdListBx_VendorDesc.ItemCheck += ckdListBox_ItemCheck;
                }


                // PR Purch Group
                if (FilterData.ColumnFilters.purchGroup.Count > 0)
                {
                    ChkdListBx_PrPurchGroup.ItemCheck -= ckdListBox_ItemCheck;
                    foreach (string str in FilterData.ColumnFilters.purchGroup)
                    {
                        index = ChkdListBx_PrPurchGroup.Items.IndexOf(str);
                        if (index >= 0)
                        {
                            if (!ChkdListBx_PrPurchGroup.GetItemChecked(index))
                                ChkdListBx_PrPurchGroup.SetItemChecked(index, true);
                        }
                    }
                    ChkdListBx_PrPurchGroup.ItemCheck += ckdListBox_ItemCheck;
                }



                // PO Purch Group
                if (FilterData.ColumnFilters.poPurchGroup.Count > 0)
                {
                    ChkdListBx_PoPurchGroup.ItemCheck -= ckdListBox_ItemCheck;
                    foreach (string str in FilterData.ColumnFilters.poPurchGroup)
                    {
                        index = ChkdListBx_PoPurchGroup.Items.IndexOf(str);
                        if (index >= 0)
                        {
                            if (!ChkdListBx_PoPurchGroup.GetItemChecked(index))
                                ChkdListBx_PoPurchGroup.SetItemChecked(index, true);
                        }
                    }
                    ChkdListBx_PoPurchGroup.ItemCheck += ckdListBox_ItemCheck;
                }




                // IR Supp Name
                if (FilterData.ColumnFilters.irSuppName.Count > 0)
                {
                    ChkdListBx_IRSuppName.ItemCheck -= ckdListBox_ItemCheck;
                    foreach (string str in FilterData.ColumnFilters.irSuppName)
                    {
                        index = ChkdListBx_IRSuppName.Items.IndexOf(str);
                        if (index >= 0)
                        {
                            if (!ChkdListBx_IRSuppName.GetItemChecked(index))
                                ChkdListBx_IRSuppName.SetItemChecked(index, true);
                        }
                    }
                    ChkdListBx_IRSuppName.ItemCheck += ckdListBox_ItemCheck;
                }



                // Fxd Supp Name
                if (FilterData.ColumnFilters.fxdSuppName.Count > 0)
                {
                    ChkdListBx_FxdSuppName.ItemCheck -= ckdListBox_ItemCheck;
                    foreach (string str in FilterData.ColumnFilters.fxdSuppName)
                    {
                        index = ChkdListBx_FxdSuppName.Items.IndexOf(str);
                        if (index >= 0)
                        {
                            if (!ChkdListBx_FxdSuppName.GetItemChecked(index))
                                ChkdListBx_FxdSuppName.SetItemChecked(index, true);
                        }
                    }
                    ChkdListBx_FxdSuppName.ItemCheck += ckdListBox_ItemCheck;
                }


                // Dsrd Supp Name
                if (FilterData.ColumnFilters.dsrdSuppName.Count > 0)
                {
                    ChkdListBx_DsrdSuppName.ItemCheck -= ckdListBox_ItemCheck;
                    foreach (string str in FilterData.ColumnFilters.dsrdSuppName)
                    {
                        index = ChkdListBx_DsrdSuppName.Items.IndexOf(str);
                        if (index >= 0)
                        {
                            if (!ChkdListBx_DsrdSuppName.GetItemChecked(index))
                                ChkdListBx_DsrdSuppName.SetItemChecked(index, true);
                        }
                    }
                    ChkdListBx_DsrdSuppName.ItemCheck += ckdListBox_ItemCheck;
                }


                // Commodity Category
                if (FilterData.ColumnFilters.commCategory.Count > 0)
                {
                    ChkdListBx_CommodityCat.ItemCheck -= ckdListBox_ItemCheck;
                    foreach (string str in FilterData.ColumnFilters.commCategory)
                    {
                        index = ChkdListBx_CommodityCat.Items.IndexOf(str);
                        if (index >= 0)
                        {
                            if (!ChkdListBx_CommodityCat.GetItemChecked(index))
                                ChkdListBx_CommodityCat.SetItemChecked(index, true);
                        }
                    }
                    ChkdListBx_CommodityCat.ItemCheck += ckdListBox_ItemCheck;
                }


                // Escaped
                if (FilterData.ColumnFilters.escaped.Count > 0)
                {
                    ChkdListBx_Escaped.ItemCheck -= ckdListBox_ItemCheck;
                    foreach (string str in FilterData.ColumnFilters.escaped)
                    {
                        index = ChkdListBx_Escaped.Items.IndexOf(str);
                        if (index >= 0)
                        {
                            if (!ChkdListBx_Escaped.GetItemChecked(index))
                                ChkdListBx_Escaped.SetItemChecked(index, true);
                        }
                    }
                    ChkdListBx_Escaped.ItemCheck += ckdListBox_ItemCheck;
                }


                // PO Document Type
                if (FilterData.ColumnFilters.poDocumentType.Count > 0)
                {
                    ChkdListBx_poDocumentType.ItemCheck -= ckdListBox_ItemCheck;
                    foreach (string str in FilterData.ColumnFilters.poDocumentType)
                    {
                        index = ChkdListBx_poDocumentType.Items.IndexOf(str);
                        if (index >= 0)
                        {
                            if (!ChkdListBx_poDocumentType.GetItemChecked(index))
                                ChkdListBx_poDocumentType.SetItemChecked(index, true);
                        }
                    }
                    ChkdListBx_poDocumentType.ItemCheck += ckdListBox_ItemCheck;
                }


                // Production Order Material
                if (FilterData.ColumnFilters.prodOrderMat.Count > 0)
                {
                    ChkdListBx_productionOrderMat.ItemCheck -= ckdListBox_ItemCheck;
                    foreach (string str in FilterData.ColumnFilters.prodOrderMat)
                    {
                        index = ChkdListBx_productionOrderMat.Items.IndexOf(str);
                        if (index >= 0)
                        {
                            if (!ChkdListBx_productionOrderMat.GetItemChecked(index))
                                ChkdListBx_productionOrderMat.SetItemChecked(index, true);
                        }
                    }
                    ChkdListBx_productionOrderMat.ItemCheck += ckdListBox_ItemCheck;
                }
            }
        }




        /// <summary>
        /// Builds the query that consists of the filters that will load the data.
        /// </summary>
        private void BuildQueryFilters()
        {
            filters = string.Empty;


            // Project Number
            if (FilterData.ColumnFilters.projectNumber.Count > 0)
            {
                for (int i = 0; i < FilterData.ColumnFilters.projectNumber.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (FilterData.ColumnFilters.projectNumber[i] == "[Blanks]")
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.ProjectNum_WBS_Element] + "] IS NULL OR " + DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.ProjectNUm_ProdOrdWbs] + "] IS NULL";
                    else
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.ProjectNum_WBS_Element] + "] LIKE " + "'%" + FilterData.ColumnFilters.projectNumber[i] + "%' OR " + DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.ProjectNUm_ProdOrdWbs] + "] LIKE " + "'%" + FilterData.ColumnFilters.projectNumber[i] + "%'";

                    if (i != (FilterData.ColumnFilters.projectNumber.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }




            // WBS Element
            if (FilterData.ColumnFilters.wbsElement.Count > 0)
            {
                for (int i = 0; i < FilterData.ColumnFilters.wbsElement.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (FilterData.ColumnFilters.wbsElement[i] == "[Blanks]")
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.WBS_Element] + "] IS NULL";
                    else
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.WBS_Element] + "] = " + "'" + FilterData.ColumnFilters.wbsElement[i] + "'";


                    if (i != (FilterData.ColumnFilters.wbsElement.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }


            // Material
            if (FilterData.ColumnFilters.material.Count > 0)
            {
                for (int i = 0; i < FilterData.ColumnFilters.material.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (FilterData.ColumnFilters.material[i] == "[Blanks]")
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.Material] + "] IS NULL";
                    else
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.Material] + "] = " + "'" + FilterData.ColumnFilters.material[i] + "'";

                    if (i != (FilterData.ColumnFilters.material.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            
            // Material Group
            if(FilterData.ColumnFilters.materialGroup.Count > 0)
            {
                for (int i = 0; i < FilterData.ColumnFilters.materialGroup.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (FilterData.ColumnFilters.materialGroup[i] == "[Blanks]")
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.MaterialGroup] + "] IS NULL";
                    else
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.MaterialGroup] + "] = " + "'" + FilterData.ColumnFilters.materialGroup[i] + "'";

                    if (i != (FilterData.ColumnFilters.materialGroup.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            
            // Vendor
            if(FilterData.ColumnFilters.vendor.Count > 0)
            {
                for (int i = 0; i < FilterData.ColumnFilters.vendor.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (FilterData.ColumnFilters.vendor[i] == "[Blanks]")
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.Vendor] + "] IS NULL";
                    else
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.Vendor] + "] = " + FilterData.ColumnFilters.vendor[i];

                    if (i != (FilterData.ColumnFilters.vendor.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            
            // Vendor Description
            if(FilterData.ColumnFilters.vendorDesc.Count > 0)
            {
                for (int i = 0; i < FilterData.ColumnFilters.vendorDesc.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (FilterData.ColumnFilters.vendorDesc[i] == "[Blanks]")
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.VendorDescription] + "] IS NULL";
                    else
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.VendorDescription] + "] = " + "'" + FilterData.ColumnFilters.vendorDesc[i] + "'";

                    if (i != (FilterData.ColumnFilters.vendorDesc.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            

            // Purchase Group
            if(FilterData.ColumnFilters.purchGroup.Count > 0)
            {
                for (int i = 0; i < FilterData.ColumnFilters.purchGroup.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (FilterData.ColumnFilters.purchGroup[i] == "[Blanks]")
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.PurchGroup] + "] IS NULL";
                    else
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.PurchGroup] + "] = " + "'" + FilterData.ColumnFilters.purchGroup[i] + "'";

                    if (i != (FilterData.ColumnFilters.purchGroup.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }



            // PO Purchase Group
            if (FilterData.ColumnFilters.poPurchGroup.Count > 0)
            {
                for (int i = 0; i < FilterData.ColumnFilters.poPurchGroup.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (FilterData.ColumnFilters.poPurchGroup[i] == "[Blanks]")
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.PoPurchGroup] + "] IS NULL";
                    else
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.PoPurchGroup] + "] = " + "'" + FilterData.ColumnFilters.poPurchGroup[i] + "'";

                    if (i != (FilterData.ColumnFilters.poPurchGroup.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }


            // IR Supp Name
            if (FilterData.ColumnFilters.irSuppName.Count > 0)
            {
                for (int i = 0; i < FilterData.ColumnFilters.irSuppName.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (FilterData.ColumnFilters.irSuppName[i] == "[Blanks]")
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.IRSuppName] + "] IS NULL";
                    else
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.IRSuppName] + "] = " + "'" + FilterData.ColumnFilters.irSuppName[i] + "'";

                    if (i != (FilterData.ColumnFilters.irSuppName.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            

            // Fxd Supp Name
            if(FilterData.ColumnFilters.fxdSuppName.Count > 0)
            {
                for (int i = 0; i < FilterData.ColumnFilters.fxdSuppName.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (FilterData.ColumnFilters.fxdSuppName[i] == "[Blanks]")
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.FxdSuppName] + "] IS NULL";
                    else
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.FxdSuppName] + "] = " + "'" + FilterData.ColumnFilters.fxdSuppName[i] + "'";

                    if (i != (FilterData.ColumnFilters.fxdSuppName.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            

            // Dsrd Supp Name
            if(FilterData.ColumnFilters.dsrdSuppName.Count > 0)
            {
                for (int i = 0; i < FilterData.ColumnFilters.dsrdSuppName.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (FilterData.ColumnFilters.dsrdSuppName[i] == "[Blanks]")
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.DsrdSuppName] + "] IS NULL";
                    else
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.DsrdSuppName] + "] = " + "'" + FilterData.ColumnFilters.dsrdSuppName[i] + "'";

                    if (i != (FilterData.ColumnFilters.dsrdSuppName.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            

            // Comm Category
            if(FilterData.ColumnFilters.commCategory.Count > 0)
            {
                for (int i = 0; i < FilterData.ColumnFilters.commCategory.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (FilterData.ColumnFilters.commCategory[i] == "[Blanks]")
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.CommCat] + "] IS NULL";
                    else
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.CommCat] + "] = " + "'" + FilterData.ColumnFilters.commCategory[i] + "'";


                    if (i != (FilterData.ColumnFilters.commCategory.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }

            // Escaped
            if (FilterData.ColumnFilters.escaped.Count > 0)
            {
                for (int i = 0; i < FilterData.ColumnFilters.escaped.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (FilterData.ColumnFilters.escaped[i] == "[Blanks]")
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.Escaped] + "] IS NULL";
                    else
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.Escaped] + "] = " + "'" + FilterData.ColumnFilters.escaped[i] + "'";


                    if (i != (FilterData.ColumnFilters.escaped.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }


            // PO Document Type
            if (FilterData.ColumnFilters.poDocumentType.Count > 0)
            {
                for (int i = 0; i < FilterData.ColumnFilters.poDocumentType.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (FilterData.ColumnFilters.poDocumentType[i] == "[Blanks]")
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.PoDocumentType] + "] IS NULL";
                    else
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.PoDocumentType] + "] = " + "'" + FilterData.ColumnFilters.poDocumentType[i] + "'";


                    if (i != (FilterData.ColumnFilters.poDocumentType.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }

            // PO Document Type
            if (FilterData.ColumnFilters.prodOrderMat.Count > 0)
            {
                for (int i = 0; i < FilterData.ColumnFilters.prodOrderMat.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (FilterData.ColumnFilters.prodOrderMat[i] == "[Blanks]")
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.ProdOrderMaterial] + "] IS NULL";
                    else
                        filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.ProdOrderMaterial] + "] = " + "'" + FilterData.ColumnFilters.prodOrderMat[i] + "'";


                    if (i != (FilterData.ColumnFilters.prodOrderMat.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
        }




        /// <summary>
        /// Clears the selected filters
        /// </summary>
        private void ClearSelected()
        { 
            // reset the added filters.
            ResetAdded();

            // Uncheck the date filters
            chkBox_PrDateRange.Checked = false;
            chkBox_PoDateRange.Checked = false;
            chkBox_FinalReceiptDate.Checked = false;


            // Uncheck the checklist boxes.
            foreach (var chklistBox in checkListBoxes)
            {
                foreach (int index in chklistBox.CheckedIndices)
                {
                    chklistBox.SetItemCheckState(index, CheckState.Unchecked);
                }
            }


            // Reset the advance filters back to their default state.
            foreach (Bunifu.Framework.UI.BunifuCheckbox chkBox in checkBoxes)
            {
                if (int.Parse(chkBox.Tag.ToString()) <= 2)
                    continue;
                else
                    chkBox.Checked = true;
            }
        }





        /// <summary>
        /// Add the check Indices of all the filter check list boxes and add them to the saved fitlers.
        /// </summary>
        private void GetCheckedColumnFilters()
        {
            // Clear the selected fitlers and get the updated checked filters
            FilterData.ColumnFilters.Reset();

            // Project Number
            foreach (int i in ChkdListBx_ProjectNumber.CheckedIndices)
            {
                FilterData.ColumnFilters.projectNumber.Add(ChkdListBx_ProjectNumber.Items[i].ToString());
            }

            // WBS Element
            foreach (int i in ChkdListBx_WBSElement.CheckedIndices)
            {
                FilterData.ColumnFilters.wbsElement.Add(ChkdListBx_WBSElement.Items[i].ToString());
            }

            // Material
            foreach (int i in ChkdListBx_Material.CheckedIndices)
            {
                FilterData.ColumnFilters.material.Add(ChkdListBx_Material.Items[i].ToString());
            }

            // Material Group
            foreach (int i in ChkdListBx_MaterialGroup.CheckedIndices)
            {
                FilterData.ColumnFilters.materialGroup.Add(ChkdListBx_MaterialGroup.Items[i].ToString());
            }

            // Vendor
            foreach (int i in ChkdListBx_Vendor.CheckedIndices)
            {
                FilterData.ColumnFilters.vendor.Add(ChkdListBx_Vendor.Items[i].ToString());
            }

            // Vendor Desc
            foreach (int i in ChkdListBx_VendorDesc.CheckedIndices)
            {
                FilterData.ColumnFilters.vendorDesc.Add(ChkdListBx_VendorDesc.Items[i].ToString());
            }

            // PR Purchase Group
            foreach (int i in ChkdListBx_PrPurchGroup.CheckedIndices)
            {
                FilterData.ColumnFilters.purchGroup.Add(ChkdListBx_PrPurchGroup.Items[i].ToString());
            }

            // PO Purchase Group
            foreach (int i in ChkdListBx_PoPurchGroup.CheckedIndices)
            {
                FilterData.ColumnFilters.poPurchGroup.Add(ChkdListBx_PoPurchGroup.Items[i].ToString());
            }

            // IR Supp Name:
            foreach (int i in ChkdListBx_IRSuppName.CheckedIndices)
            {
                FilterData.ColumnFilters.irSuppName.Add(ChkdListBx_IRSuppName.Items[i].ToString());
            }

            // Fxd Supp Name
            foreach (int i in ChkdListBx_FxdSuppName.CheckedIndices)
            {
                FilterData.ColumnFilters.fxdSuppName.Add(ChkdListBx_FxdSuppName.Items[i].ToString());
            }

            // Dsrd Supp Name
            foreach (int i in ChkdListBx_DsrdSuppName.CheckedIndices)
            {
                FilterData.ColumnFilters.dsrdSuppName.Add(ChkdListBx_DsrdSuppName.Items[i].ToString());
            }

            // Commodity Cat
            foreach (int i in ChkdListBx_CommodityCat.CheckedIndices)
            {
                FilterData.ColumnFilters.commCategory.Add(ChkdListBx_CommodityCat.Items[i].ToString());
            }

            // Escaped
            foreach (int i in ChkdListBx_Escaped.CheckedIndices)
            {
                FilterData.ColumnFilters.escaped.Add(ChkdListBx_Escaped.Items[i].ToString());
            }

            // PO Document Type
            foreach (int i in ChkdListBx_poDocumentType.CheckedIndices)
            {
                FilterData.ColumnFilters.poDocumentType.Add(ChkdListBx_poDocumentType.Items[i].ToString());
            }

            // Production Order Material
            foreach (int i in ChkdListBx_productionOrderMat.CheckedIndices)
            {
                FilterData.ColumnFilters.prodOrderMat.Add(ChkdListBx_productionOrderMat.Items[i].ToString());
            }
        }





        /// <summary>
        /// Checks the status of the filters and applies them if they are added.
        /// </summary>
        public void CheckFilterStatus()
        {
            HasFiltersAdded();
            if (FilterData.ColumnFilters.Added)
            {
                DatabaseManager.SecondaryFilters = filters;
                filters = " AND " + filters;
                DatabaseManager.Filters = filters;
                FilterData.ColumnFilters.Applied = true;
            }
            else
            {
                filters = string.Empty;
                DatabaseManager.Filters = filters;
                DatabaseManager.SecondaryFilters = filters;
                FilterData.ColumnFilters.Applied = false;
            }


            if (FilterData.DateFilters.Added)
            {
                FilterData.DateFilters.Applied = true;
            }
            else
            {
                FilterData.DateFilters.Applied = false;
            }


            if (FilterData.AdvancedFilters.AdvanceFiltersChanged())
            {
                FilterData.AdvancedFilters.Applied = true;
            }
            else
            {
                FilterData.AdvancedFilters.Applied = false;
            }
        }





        /// <summary>
        /// Checks if there are any variants save and if the user has any variants applied against the data.
        /// </summary>
        private void CheckActiveVariants()
        {

            // If there are any variants allow the user to view them.
            if (variantSettings.Variants.Count > 0)
                viewVariantsToolStripMenuItem.Enabled = true;
            else
                viewVariantsToolStripMenuItem.Enabled = false;



            // Loop throught each saved variant and see if they are active. We do not want the user
            // to have the option to add a variant that is currently active against the data.
            foreach (Variant setting in variantSettings.Variants)
            {
                if (setting.Active)
                {
                    addVariantToolStripMenuItem.Enabled = true;
                    break;
                }
                else
                    addVariantToolStripMenuItem.Enabled = false;
            }
        }






        /// <summary>
        /// Clears the filter settings and clears the fitlers applied on the data.
        /// </summary>
        private void ClearFilters()
        {
            // Reset column, advance, and date filters
            ResetAdded();
            ResetApplied();
            FilterData.ResetFilters();

            // Clear selected filters.
            ClearSelected();
        }





        /// <summary>
        /// Resets applied data settings
        /// </summary>
        private void ResetApplied()
        {
            FilterData.ColumnFilters.Applied = false;
            FilterData.AdvancedFilters.Applied = false;
            FilterData.DateFilters.Applied = false;

            FilterData.DateFilters.FilterByPrDateRange = false;
            FilterData.DateFilters.FilterByPoDateRange = false;
            FilterData.DateFilters.FilterByFinalReceiptDate = false;
        }





        /// <summary>
        /// Resets the Added data settings
        /// </summary>
        private void ResetAdded()
        {
            FilterData.ColumnFilters.Added = false;
            FilterData.AdvancedFilters.Added = false;
            FilterData.DateFilters.Added = false;
        }





        /// <summary>
        /// If the user has applied filters against the data, this function will assign FiltersAdded to true.
        /// </summary>
        public void HasFiltersAdded()
        {
            FilterData.ColumnFilters.Added = false;
            FilterData.AdvancedFilters.Added = false;
            FilterData.DateFilters.Added = false;

            // Check if the user enable the option to filter by PR or PO date range.
            if (FilterData.DateFilters.FilterByPrDateRange || FilterData.DateFilters.FilterByPoDateRange || FilterData.DateFilters.FilterByFinalReceiptDate)
                FilterData.DateFilters.Added = true;
             else
                FilterData.DateFilters.Added = false;

            // Check if the user has changed the advanced filters
            FilterData.AdvancedFilters.Added = FilterData.AdvancedFilters.AdvanceFiltersChanged();

            // Check if the user selected any filters from the following check list boxes.
            if (FilterData.ColumnFilters.projectNumber.Count > 0
                || FilterData.ColumnFilters.wbsElement.Count > 0
                || FilterData.ColumnFilters.material.Count > 0
                || FilterData.ColumnFilters.material.Count > 0
                || FilterData.ColumnFilters.materialGroup.Count > 0
                || FilterData.ColumnFilters.vendor.Count > 0
                || FilterData.ColumnFilters.vendorDesc.Count > 0
                || FilterData.ColumnFilters.purchGroup.Count > 0
                || FilterData.ColumnFilters.poPurchGroup.Count > 0
                || FilterData.ColumnFilters.irSuppName.Count > 0
                || FilterData.ColumnFilters.fxdSuppName.Count > 0
                || FilterData.ColumnFilters.dsrdSuppName.Count > 0
                || FilterData.ColumnFilters.commCategory.Count > 0
                || FilterData.ColumnFilters.escaped.Count > 0
                || FilterData.ColumnFilters.poDocumentType.Count > 0
                || FilterData.ColumnFilters.prodOrderMat.Count > 0)
            {
                FilterData.ColumnFilters.Added = true;
            }
        }




        /// <summary>
        /// Enables the apply filters button.
        /// </summary>
        private void EnableApplyFiltersButton()
        {
            btn_applyFilters.Enabled = true;
            btn_applyFilters.BackColor = System.Drawing.Color.MediumSeaGreen;
            btn_applyFilters.ForeColor = System.Drawing.SystemColors.ButtonFace;
        }





        /// <summary>
        /// Enables the clear selected filter button.
        /// </summary>
        private void EnableClearSelectedButton()
        {
            btn_clearSelected.Enabled = true;
            btn_clearSelected.BackColor = System.Drawing.Color.DarkSlateGray;
            btn_clearSelected.ForeColor = System.Drawing.SystemColors.ButtonFace;
        }
        



        /// <summary>
        /// Enables the clear filters button.
        /// </summary>
        private void EnableClearFiltersButton()
        {
            btn_clearFilters.Enabled = true;
            btn_clearFilters.BackColor = System.Drawing.Color.IndianRed;
            btn_clearFilters.ForeColor = System.Drawing.SystemColors.ButtonFace;
        }




        /// <summary>
        /// Disables the instance button passed in as a parameter.
        /// </summary>
        private void DisableButton(Button btn)
        {
            btn.Enabled = false;
            btn.BackColor = System.Drawing.Color.LightGray;
            btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
        }





        /// <summary>
        /// Determines if the apply, clear, and clear selected buttons should be enabled or disabled.
        /// </summary>
        private void UpdateFilterButtons()
        {
            HasFiltersAdded();
            if (FilterData.ColumnFilters.Added || FilterData.DateFilters.Added || FilterData.AdvancedFilters.Added)
            {
                EnableApplyFiltersButton();
                EnableClearSelectedButton();
            }
            else
            {
                DisableButton(btn_applyFilters);
                DisableButton(btn_clearSelected);
            }


            if (FilterData.ColumnFilters.Applied || FilterData.DateFilters.Applied || FilterData.AdvancedFilters.Applied)
            {
                EnableClearFiltersButton();
            }
            else
            {
                DisableButton(btn_clearFilters);
            }
        }






        /// <summary>
        /// Checks if the user has selected to filter by date ranges or advanced filters.
        /// </summary>
        public void CheckFilters(int tag)
        {
            switch(tag)
            {
                case 0:
                    // Check if the user has chosen the option to filter by PR Date.
                    if (chkBox_PrDateRange.Checked)
                    {
                        FilterData.DateFilters.FilterByPrDateRange = true;
                        CheckDateRange(0);
                    }
                    else
                    {
                        FilterData.DateFilters.FilterByPrDateRange = false;
                    }
                    break;
                case 1:
                    // Check if the user has chosen the option to filter by PO Date.
                    if (chkBox_PoDateRange.Checked)
                    {
                        FilterData.DateFilters.FilterByPoDateRange = true;
                        CheckDateRange(2);
                    }
                    else
                    {
                        FilterData.DateFilters.FilterByPoDateRange = false;
                    }
                    break;
                case 2:
                    // Check if the user has chosen the option to filter by final receipt date.
                    if (chkBox_FinalReceiptDate.Checked)
                    {
                        FilterData.DateFilters.FilterByFinalReceiptDate = true;
                        CheckDateRange(2);
                    }
                    else
                    {
                        FilterData.DateFilters.FilterByFinalReceiptDate = false;
                    }
                    break;
                case 3:
                    // Check if the user has chosent the option to filter service PR/POs
                    if (chkBox_servicePrPo.Checked)
                    {
                        FilterData.AdvancedFilters.FilterByServicePrPo = true;
                    }
                    else
                    {
                        FilterData.AdvancedFilters.FilterByServicePrPo = false;
                    }
                    break;
                case 4:
                    // Check if the user has chosent the option to filter steel PR/POs
                    if (chkBox_SteelPrPo.Checked)
                    {
                        FilterData.AdvancedFilters.FilterBySteelPrPo = true;
                    }
                    else
                    {
                        FilterData.AdvancedFilters.FilterBySteelPrPo = false;
                    }
                    break;
                case 5:
                    // Check if the user has chosent the option to filter POU PR/POs
                    if (chkBox_pouPrPo.Checked)
                    {
                        FilterData.AdvancedFilters.FilterByPouPrPo = true;
                    }
                    else
                    {
                        FilterData.AdvancedFilters.FilterByPouPrPo = false;
                    }
                    break;
                case 6:
                    // Check if the user has chosent the option to filter Intercompany POs
                    if (chkBox_IntCompPo.Checked)
                    {
                        FilterData.AdvancedFilters.FilterByIntercompPo = true;
                    }
                    else
                    {
                        FilterData.AdvancedFilters.FilterByIntercompPo = false;
                    }
                    break;
                case 7:
                    // Check if the user has chosent the option to filter Codified Material (non- subcontract)
                    if (chkBox_codifiedMatNonSub.Checked)
                    {
                        FilterData.AdvancedFilters.FilterByCodifiedMatNonSubcont = true;
                    }
                    else
                    {
                        FilterData.AdvancedFilters.FilterByCodifiedMatNonSubcont = false;
                    }
                    break;
                case 8:
                    // Check if the user has chosent the option to filter Codified Material (Subcontact)
                    if (chkBox_codifiedMatSubCon.Checked)
                    {
                        FilterData.AdvancedFilters.FilterByCodifiedMatSubcont = true;
                    }
                    else
                    {
                        FilterData.AdvancedFilters.FilterByCodifiedMatSubcont = false;
                    }
                    break;
                default:
                    // Check if the user has chosent the option to filter Manual PRs
                    if (chkBox_manualPr.Checked)
                    {
                        FilterData.AdvancedFilters.FilterByManualPr = true;
                    }
                    else
                    {
                        FilterData.AdvancedFilters.FilterByManualPr = false;
                    }
                    break;
            }

            UpdateFilterButtons();
        }





        /// <summary>
        /// Gather all the check list boxes on the form so they can later be looped through.
        /// </summary>
        public void GetCheckListBoxes()
        {
            checkListBoxes.Add(ChkdListBx_ProjectNumber);
            checkListBoxes.Add(ChkdListBx_WBSElement);
            checkListBoxes.Add(ChkdListBx_Material);
            checkListBoxes.Add(ChkdListBx_MaterialGroup);
            checkListBoxes.Add(ChkdListBx_Vendor);
            checkListBoxes.Add(ChkdListBx_VendorDesc);
            checkListBoxes.Add(ChkdListBx_PrPurchGroup);
            checkListBoxes.Add(ChkdListBx_PoPurchGroup);
            checkListBoxes.Add(ChkdListBx_IRSuppName);
            checkListBoxes.Add(ChkdListBx_FxdSuppName);
            checkListBoxes.Add(ChkdListBx_DsrdSuppName);
            checkListBoxes.Add(ChkdListBx_CommodityCat);
            checkListBoxes.Add(ChkdListBx_Escaped);
            checkListBoxes.Add(ChkdListBx_poDocumentType);
            checkListBoxes.Add(ChkdListBx_productionOrderMat);
        }



        /// <summary>
        /// Load all the date ranges and advanced filter check boxes into a list of checkboxes.
        /// </summary>
        public void GetCheckBoxControls()
        {
            checkBoxes.Add(chkBox_PrDateRange);
            checkBoxes.Add(chkBox_PoDateRange);
            checkBoxes.Add(chkBox_FinalReceiptDate);
            checkBoxes.Add(chkBox_servicePrPo);
            checkBoxes.Add(chkBox_SteelPrPo);
            checkBoxes.Add(chkBox_pouPrPo);
            checkBoxes.Add(chkBox_IntCompPo);
            checkBoxes.Add(chkBox_codifiedMatNonSub);
            checkBoxes.Add(chkBox_codifiedMatSubCon);
            checkBoxes.Add(chkBox_manualPr);
        }

        #endregion
    }
}
