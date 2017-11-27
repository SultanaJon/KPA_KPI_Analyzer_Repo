using KPA_KPI_Analyzer.Diagnostics;
using KPA_KPI_Analyzer.FilterFeeature;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI : Form
    {
        #region MEMBERS

        string filters = string.Empty;
        List<Bunifu.Framework.UI.BunifuCheckbox> checkBoxes = new List<Bunifu.Framework.UI.BunifuCheckbox>();
        List<CheckedListBox> checkListBoxes = new List<CheckedListBox>();

        #endregion

        #region PROPERTIES

        /// <summary>
        /// boolean value stating whether or not the user has checked filters to apply
        /// </summary>
        public static bool ColumnFiltersAdded { get; set; }




        /// <summary>
        /// boolean value stating whether or not the user has added a date range filters to either the pr or po creation date.
        /// </summary>
        public static bool DateFiltersAdded { get; set; }





        public static bool AdvancedFiltersAdded { get; set; }





        /// <summary>
        /// boolean value indicating whether or not the user has applied the filters to the data.
        /// </summary>
        public static bool ColumnFiltersApplied { get; set; }





        /// <summary>
        /// boolean value indicating whether or not the user has applied date filters to the data
        /// </summary>
        public static bool DateFiltersApplied { get; set; }




        /// <summary>
        /// 
        /// </summary>
        public static bool AdvancedFiltersApplied { get; set; }



        /// <summary>
        /// boolean value indicating whether the program should filter by the pr date range.
        /// </summary>
        public static bool FilterByPrDate { get; set; }





        /// <summary>
        /// boolean vaule indicating whether the program should filter by the po date range.
        /// </summary>
        public static bool FilterByPoDate { get; set; }




        /// <summary>
        /// boolean value indicating whether the program should filter by the po date range.
        /// </summary>
        public static bool FilterByFinalRecDate { get; set; }
        #endregion




        /// <summary>
        /// Updates the contents of the of the checked list boxes on the filters page.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filter"></param>
        public void UpdateFilters(HashSet<string> data, FilterUtils.Filters filter)
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
                        Filters.ColumnFilters.projectNumber.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        Filters.ColumnFilters.projectNumber.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 1: // WBS Element
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.ColumnFilters.wbsElement.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        Filters.ColumnFilters.wbsElement.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 2: // Material
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.ColumnFilters.material.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        Filters.ColumnFilters.material.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 3: // Material Group
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.ColumnFilters.materialGroup.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        Filters.ColumnFilters.materialGroup.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 4: // Vendor
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.ColumnFilters.vendor.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        Filters.ColumnFilters.vendor.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 5: // Vendor Desc
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.ColumnFilters.vendorDesc.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        Filters.ColumnFilters.vendorDesc.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 6: // PR Purch Group
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.ColumnFilters.purchGroup.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        Filters.ColumnFilters.purchGroup.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 7: // PO Purch Group
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.ColumnFilters.poPurchGroup.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        Filters.ColumnFilters.poPurchGroup.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 8: // IR Supp Name
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.ColumnFilters.irSuppName.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        Filters.ColumnFilters.irSuppName.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 9: // Fxd Supp Name
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.ColumnFilters.fxdSuppName.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        Filters.ColumnFilters.fxdSuppName.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 10: // Dsrd Supp Name
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.ColumnFilters.dsrdSuppName.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        Filters.ColumnFilters.dsrdSuppName.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 11: // Commodity Category
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.ColumnFilters.commCategory.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        Filters.ColumnFilters.commCategory.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 12: // Escaped
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.ColumnFilters.escaped.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        Filters.ColumnFilters.escaped.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 13: // PO Document Type
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.ColumnFilters.poDocumentType.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        Filters.ColumnFilters.poDocumentType.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
                case 14: // PO Document Type
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.ColumnFilters.prodOrderMat.Add(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    else
                    {
                        Filters.ColumnFilters.prodOrderMat.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                    }
                    break;
            }
            HasFiltersAdded();
            UpdateFilterButtons();
        }





        /// <summary>
        /// This function will ensure that values that are checked stay checked
        /// after the check boxes are updated and populated with new values.
        /// </summary>
        private void UpdateCheckedItems()
        {
            int index = 0;

            // Project Number
            if (Filters.ColumnFilters.projectNumber.Count > 0)
            {
                ChkdListBx_ProjectNumber.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.ColumnFilters.projectNumber)
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
            if (Filters.ColumnFilters.wbsElement.Count > 0)
            {
                ChkdListBx_WBSElement.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.ColumnFilters.wbsElement)
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
            if (Filters.ColumnFilters.material.Count > 0)
            {
                ChkdListBx_Material.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.ColumnFilters.material)
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
            if (Filters.ColumnFilters.materialGroup.Count > 0)
            {
                ChkdListBx_MaterialGroup.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.ColumnFilters.materialGroup)
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
            if (Filters.ColumnFilters.vendor.Count > 0)
            {
                ChkdListBx_Vendor.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.ColumnFilters.vendor)
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
            if (Filters.ColumnFilters.vendorDesc.Count > 0)
            {
                ChkdListBx_VendorDesc.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.ColumnFilters.vendorDesc)
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
            if (Filters.ColumnFilters.purchGroup.Count > 0)
            {
                ChkdListBx_PrPurchGroup.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.ColumnFilters.purchGroup)
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
            if (Filters.ColumnFilters.poPurchGroup.Count > 0)
            {
                ChkdListBx_PoPurchGroup.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.ColumnFilters.poPurchGroup)
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
            if (Filters.ColumnFilters.irSuppName.Count > 0)
            {
                ChkdListBx_IRSuppName.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.ColumnFilters.irSuppName)
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
            if (Filters.ColumnFilters.fxdSuppName.Count > 0)
            {
                ChkdListBx_FxdSuppName.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.ColumnFilters.fxdSuppName)
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
            if (Filters.ColumnFilters.dsrdSuppName.Count > 0)
            {
                ChkdListBx_DsrdSuppName.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.ColumnFilters.dsrdSuppName)
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
            if (Filters.ColumnFilters.commCategory.Count > 0)
            {
                ChkdListBx_CommodityCat.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.ColumnFilters.commCategory)
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
            if (Filters.ColumnFilters.escaped.Count > 0)
            {
                ChkdListBx_Escaped.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.ColumnFilters.escaped)
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
            if (Filters.ColumnFilters.poDocumentType.Count > 0)
            {
                ChkdListBx_poDocumentType.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.ColumnFilters.poDocumentType)
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
            if (Filters.ColumnFilters.prodOrderMat.Count > 0)
            {
                ChkdListBx_productionOrderMat.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.ColumnFilters.prodOrderMat)
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




        /// <summary>
        /// Builds the query that consists of the filters that will load the data.
        /// </summary>
        private void BuildQueryFilters()
        {
            filters = string.Empty;


            // Project Number
            if (Filters.ColumnFilters.projectNumber.Count > 0)
            {
                for (int i = 0; i < Filters.ColumnFilters.projectNumber.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (Filters.ColumnFilters.projectNumber[i] == "[Blanks]")
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.ProjectNum_WBS_Element] + "] IS NULL OR " + Values.Globals.CountryTableName + ".[" + FilterFeeature.FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.ProjectNUm_ProdOrdWbs] + "] IS NULL";
                    else
                        filters += Values.Globals.CountryTableName + ".[" + FilterFeeature.FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.ProjectNum_WBS_Element] + "] LIKE " + "'%" + Filters.ColumnFilters.projectNumber[i] + "%' OR " + Values.Globals.CountryTableName + ".[" + FilterFeeature.FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.ProjectNUm_ProdOrdWbs] + "] LIKE " + "'%" + Filters.ColumnFilters.projectNumber[i] + "%'";

                    if (i != (Filters.ColumnFilters.projectNumber.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }




            // WBS Element
            if (Filters.ColumnFilters.wbsElement.Count > 0)
            {
                for (int i = 0; i < Filters.ColumnFilters.wbsElement.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (Filters.ColumnFilters.wbsElement[i] == "[Blanks]")
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.WBS_Element] + "] IS NULL";
                    else
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.WBS_Element] + "] = " + "'" + Filters.ColumnFilters.wbsElement[i] + "'";


                    if (i != (Filters.ColumnFilters.wbsElement.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }


            // Material
            if (Filters.ColumnFilters.material.Count > 0)
            {
                for (int i = 0; i < Filters.ColumnFilters.material.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (Filters.ColumnFilters.material[i] == "[Blanks]")
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.Material] + "] IS NULL";
                    else
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.Material] + "] = " + "'" + Filters.ColumnFilters.material[i] + "'";

                    if (i != (Filters.ColumnFilters.material.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            
            // Material Group
            if(Filters.ColumnFilters.materialGroup.Count > 0)
            {
                for (int i = 0; i < Filters.ColumnFilters.materialGroup.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (Filters.ColumnFilters.materialGroup[i] == "[Blanks]")
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.MaterialGroup] + "] IS NULL";
                    else
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.MaterialGroup] + "] = " + "'" + Filters.ColumnFilters.materialGroup[i] + "'";

                    if (i != (Filters.ColumnFilters.materialGroup.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            
            // Vendor
            if(Filters.ColumnFilters.vendor.Count > 0)
            {
                for (int i = 0; i < Filters.ColumnFilters.vendor.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (Filters.ColumnFilters.vendor[i] == "[Blanks]")
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.Vendor] + "] IS NULL";
                    else
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.Vendor] + "] = " + Filters.ColumnFilters.vendor[i];

                    if (i != (Filters.ColumnFilters.vendor.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            
            // Vendor Description
            if(Filters.ColumnFilters.vendorDesc.Count > 0)
            {
                for (int i = 0; i < Filters.ColumnFilters.vendorDesc.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (Filters.ColumnFilters.vendorDesc[i] == "[Blanks]")
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.VendorDescription] + "] IS NULL";
                    else
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.VendorDescription] + "] = " + "'" + Filters.ColumnFilters.vendorDesc[i] + "'";

                    if (i != (Filters.ColumnFilters.vendorDesc.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            

            // Purchase Group
            if(Filters.ColumnFilters.purchGroup.Count > 0)
            {
                for (int i = 0; i < Filters.ColumnFilters.purchGroup.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (Filters.ColumnFilters.purchGroup[i] == "[Blanks]")
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.PurchGroup] + "] IS NULL";
                    else
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.PurchGroup] + "] = " + "'" + Filters.ColumnFilters.purchGroup[i] + "'";

                    if (i != (Filters.ColumnFilters.purchGroup.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }



            // PO Purchase Group
            if (Filters.ColumnFilters.poPurchGroup.Count > 0)
            {
                for (int i = 0; i < Filters.ColumnFilters.poPurchGroup.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (Filters.ColumnFilters.poPurchGroup[i] == "[Blanks]")
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.PoPurchGroup] + "] IS NULL";
                    else
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.PoPurchGroup] + "] = " + "'" + Filters.ColumnFilters.poPurchGroup[i] + "'";

                    if (i != (Filters.ColumnFilters.poPurchGroup.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }


            // IR Supp Name
            if (Filters.ColumnFilters.irSuppName.Count > 0)
            {
                for (int i = 0; i < Filters.ColumnFilters.irSuppName.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (Filters.ColumnFilters.irSuppName[i] == "[Blanks]")
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.IRSuppName] + "] IS NULL";
                    else
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.IRSuppName] + "] = " + "'" + Filters.ColumnFilters.irSuppName[i] + "'";

                    if (i != (Filters.ColumnFilters.irSuppName.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            

            // Fxd Supp Name
            if(Filters.ColumnFilters.fxdSuppName.Count > 0)
            {
                for (int i = 0; i < Filters.ColumnFilters.fxdSuppName.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (Filters.ColumnFilters.fxdSuppName[i] == "[Blanks]")
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.FxdSuppName] + "] IS NULL";
                    else
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.FxdSuppName] + "] = " + "'" + Filters.ColumnFilters.fxdSuppName[i] + "'";

                    if (i != (Filters.ColumnFilters.fxdSuppName.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            

            // Dsrd Supp Name
            if(Filters.ColumnFilters.dsrdSuppName.Count > 0)
            {
                for (int i = 0; i < Filters.ColumnFilters.dsrdSuppName.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (Filters.ColumnFilters.dsrdSuppName[i] == "[Blanks]")
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.DsrdSuppName] + "] IS NULL";
                    else
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.DsrdSuppName] + "] = " + "'" + Filters.ColumnFilters.dsrdSuppName[i] + "'";

                    if (i != (Filters.ColumnFilters.dsrdSuppName.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            

            // Comm Category
            if(Filters.ColumnFilters.commCategory.Count > 0)
            {
                for (int i = 0; i < Filters.ColumnFilters.commCategory.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (Filters.ColumnFilters.commCategory[i] == "[Blanks]")
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.CommCat] + "] IS NULL";
                    else
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.CommCat] + "] = " + "'" + Filters.ColumnFilters.commCategory[i] + "'";


                    if (i != (Filters.ColumnFilters.commCategory.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }

            // Escaped
            if (Filters.ColumnFilters.escaped.Count > 0)
            {
                for (int i = 0; i < Filters.ColumnFilters.escaped.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (Filters.ColumnFilters.escaped[i] == "[Blanks]")
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.Escaped] + "] IS NULL";
                    else
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.Escaped] + "] = " + "'" + Filters.ColumnFilters.escaped[i] + "'";


                    if (i != (Filters.ColumnFilters.escaped.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }


            // PO Document Type
            if (Filters.ColumnFilters.poDocumentType.Count > 0)
            {
                for (int i = 0; i < Filters.ColumnFilters.poDocumentType.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (Filters.ColumnFilters.poDocumentType[i] == "[Blanks]")
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.PoDocumentType] + "] IS NULL";
                    else
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.PoDocumentType] + "] = " + "'" + Filters.ColumnFilters.poDocumentType[i] + "'";


                    if (i != (Filters.ColumnFilters.poDocumentType.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }

            // PO Document Type
            if (Filters.ColumnFilters.prodOrderMat.Count > 0)
            {
                for (int i = 0; i < Filters.ColumnFilters.prodOrderMat.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (Filters.ColumnFilters.prodOrderMat[i] == "[Blanks]")
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.ProdOrderMaterial] + "] IS NULL";
                    else
                        filters += Values.Globals.CountryTableName + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.ProdOrderMaterial] + "] = " + "'" + Filters.ColumnFilters.prodOrderMat[i] + "'";


                    if (i != (Filters.ColumnFilters.prodOrderMat.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
        }





        /// <summary>
        /// Any filters that are checked will be unchecked and the filters check lists
        /// will be set back to the normal state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_clearSelected_Click(object sender, EventArgs e)
        {
            filters = string.Empty;
            ClearSelected();
            UpdateFilterButtons();
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
            Filters.ColumnFilters.Reset();

            // Project Number
            foreach (int i in ChkdListBx_ProjectNumber.CheckedIndices)
            {
                Filters.ColumnFilters.projectNumber.Add(ChkdListBx_ProjectNumber.Items[i].ToString());
            }

            // WBS Element
            foreach (int i in ChkdListBx_WBSElement.CheckedIndices)
            {
                Filters.ColumnFilters.wbsElement.Add(ChkdListBx_WBSElement.Items[i].ToString());
            }

            // Material
            foreach (int i in ChkdListBx_Material.CheckedIndices)
            {
                Filters.ColumnFilters.material.Add(ChkdListBx_Material.Items[i].ToString());
            }

            // Material Group
            foreach (int i in ChkdListBx_MaterialGroup.CheckedIndices)
            {
                Filters.ColumnFilters.materialGroup.Add(ChkdListBx_MaterialGroup.Items[i].ToString());
            }

            // Vendor
            foreach (int i in ChkdListBx_Vendor.CheckedIndices)
            {
                Filters.ColumnFilters.vendor.Add(ChkdListBx_Vendor.Items[i].ToString());
            }

            // Vendor Desc
            foreach (int i in ChkdListBx_VendorDesc.CheckedIndices)
            {
                Filters.ColumnFilters.vendorDesc.Add(ChkdListBx_VendorDesc.Items[i].ToString());
            }

            // PR Purchase Group
            foreach (int i in ChkdListBx_PrPurchGroup.CheckedIndices)
            {
                Filters.ColumnFilters.purchGroup.Add(ChkdListBx_PrPurchGroup.Items[i].ToString());
            }

            // PO Purchase Group
            foreach (int i in ChkdListBx_PoPurchGroup.CheckedIndices)
            {
                Filters.ColumnFilters.poPurchGroup.Add(ChkdListBx_PoPurchGroup.Items[i].ToString());
            }

            // IR Supp Name:
            foreach (int i in ChkdListBx_IRSuppName.CheckedIndices)
            {
                Filters.ColumnFilters.irSuppName.Add(ChkdListBx_IRSuppName.Items[i].ToString());
            }

            // Fxd Supp Name
            foreach (int i in ChkdListBx_FxdSuppName.CheckedIndices)
            {
                Filters.ColumnFilters.fxdSuppName.Add(ChkdListBx_FxdSuppName.Items[i].ToString());
            }

            // Dsrd Supp Name
            foreach (int i in ChkdListBx_DsrdSuppName.CheckedIndices)
            {
                Filters.ColumnFilters.dsrdSuppName.Add(ChkdListBx_DsrdSuppName.Items[i].ToString());
            }

            // Commodity Cat
            foreach (int i in ChkdListBx_CommodityCat.CheckedIndices)
            {
                Filters.ColumnFilters.commCategory.Add(ChkdListBx_CommodityCat.Items[i].ToString());
            }

            // Escaped
            foreach (int i in ChkdListBx_Escaped.CheckedIndices)
            {
                Filters.ColumnFilters.escaped.Add(ChkdListBx_Escaped.Items[i].ToString());
            }

            // PO Document Type
            foreach (int i in ChkdListBx_poDocumentType.CheckedIndices)
            {
                Filters.ColumnFilters.poDocumentType.Add(ChkdListBx_poDocumentType.Items[i].ToString());
            }

            // Production Order Material
            foreach (int i in ChkdListBx_productionOrderMat.CheckedIndices)
            {
                Filters.ColumnFilters.prodOrderMat.Add(ChkdListBx_productionOrderMat.Items[i].ToString());
            }
        }








        /// <summary>
        /// Apply the filters and load the data again with the filters applied.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_applyFilters_Click(object sender, EventArgs e)
        {
            GetCheckedColumnFilters();

            if (FilterByPrDate)
            {
                if (CheckDateRange(0))
                {
                    Filters.DateFilters.FilterByPrDateRange = false;
                    return;
                }
                else
                {
                    Filters.DateFilters.PrFromDate = dp_PRFromDate.Value;
                    Filters.DateFilters.PrToDate = dp_PRToDate.Value;
                    Filters.DateFilters.FilterByPrDateRange = true;
                }
            }
            else
            {
                Filters.DateFilters.FilterByPrDateRange = false;
            }


            if(FilterByPoDate)
            {
                if (CheckDateRange(2))
                {
                    Filters.DateFilters.FilterByPoDateRange = false;
                    return;
                }
                else
                {
                    Filters.DateFilters.PoFromDate = dp_POFromDate.Value;
                    Filters.DateFilters.PoToDate = dp_POToDate.Value;
                    Filters.DateFilters.FilterByPoDateRange = true;
                }
            }
            else
            {
                Filters.DateFilters.FilterByPoDateRange = false;
            }



            if (FilterByFinalRecDate)
            {
                if (CheckDateRange(4))
                {
                    Filters.DateFilters.FilterByFinalReceiptDate = false;
                    return;
                }
                else
                {
                    Filters.DateFilters.FinalReceiptFromDate = dp_finalReceiptFromDate.Value;
                    Filters.DateFilters.FinalReceiptToDate = dp_finalReciptToDate.Value;
                    Filters.DateFilters.FilterByFinalReceiptDate = true;
                }
            }
            else
            {
                Filters.DateFilters.FilterByFinalReceiptDate = false;
            }



            BuildQueryFilters();
            HasFiltersAdded();
            if(ColumnFiltersAdded)
            {
                Filters.SecondaryFilterQuery = filters;
                filters = " AND " + filters;
                Filters.FilterQuery = filters;
                ColumnFiltersApplied = true;
            }
            else
            {
                filters = string.Empty;
                Filters.FilterQuery = filters;
                Filters.SecondaryFilterQuery = filters;
                ColumnFiltersApplied = false;
            }


            if(DateFiltersAdded)
            {
                DateFiltersApplied = true;
            }
            else
            {
                DateFiltersApplied = false;
            }


            if(Filters.AdvancedFilters.AdvanceFiltersChanged())
            {
                AdvancedFiltersApplied = true;
            }
            else
            {
                AdvancedFiltersApplied = false;
            }


            // Toggles the variant tools within the menu strip based on certain conditions.
            CheckActiveVariants();


            // Check the filter status to update the variant tools.
            UpdateVariantTools();
            InitializeDataLoadProcess();
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
            foreach (Filter_Variant.Variant setting in variantSettings.Variants)
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
        /// Clear the filters and set everything back to default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_clearFilters_Click(object sender, EventArgs e)
        {
            filters = string.Empty;
            ClearFilters();
            UpdateFilterButtons();


            // Load the overall data
            overallData.Load(ref overallData);

            // Dactivate all of the variants.
            DeactivateVariants();

            // Update the variant tools within the menu strip.
            UpdateVariantTools();
        }






        /// <summary>
        /// Clears the filter settings and clears the fitlers applied on the data.
        /// </summary>
        private void ClearFilters()
        {
            // Reset column, advance, and date filters
            ResetAdded();
            ResetApplied();
            Filters.ResetFilters();

            // Clear selected filters.
            ClearSelected();
        }





        /// <summary>
        /// Resets applied data settings
        /// </summary>
        private void ResetApplied()
        {
            ColumnFiltersApplied = false;
            AdvancedFiltersApplied = false;
            DateFiltersApplied = false;
            FilterByPrDate = false;
            FilterByPoDate = false;
            FilterByFinalRecDate = false;
        }





        /// <summary>
        /// Resets the Added data settings
        /// </summary>
        private void ResetAdded()
        {
            ColumnFiltersAdded = false;
            AdvancedFiltersAdded = false;
            DateFiltersAdded = false;
        }





        /// <summary>
        /// If the user has applied filters against the data, this function will assign FiltersAdded to true.
        /// </summary>
        public void HasFiltersAdded()
        {
            ColumnFiltersAdded = false;

            // Check if the user enable the option to filter by PR or PO date range.
            if (FilterByPrDate || FilterByPoDate || FilterByFinalRecDate)
                DateFiltersAdded = true;
             else
                DateFiltersAdded = false;

            // Check if the user has changed the advanced filters
            AdvancedFiltersAdded = Filters.AdvancedFilters.AdvanceFiltersChanged();

            // Check if the user selected any filters from the following check list boxes.
            if (Filters.ColumnFilters.projectNumber.Count > 0) ColumnFiltersAdded = true;
            if (Filters.ColumnFilters.wbsElement.Count > 0) ColumnFiltersAdded = true;
            if (Filters.ColumnFilters.material.Count > 0) ColumnFiltersAdded = true;
            if (Filters.ColumnFilters.material.Count > 0) ColumnFiltersAdded = true;
            if (Filters.ColumnFilters.materialGroup.Count > 0) ColumnFiltersAdded = true;
            if (Filters.ColumnFilters.vendor.Count > 0) ColumnFiltersAdded = true;
            if (Filters.ColumnFilters.vendorDesc.Count > 0) ColumnFiltersAdded = true;
            if (Filters.ColumnFilters.purchGroup.Count > 0) ColumnFiltersAdded = true;
            if (Filters.ColumnFilters.poPurchGroup.Count > 0) ColumnFiltersAdded = true;
            if (Filters.ColumnFilters.irSuppName.Count > 0) ColumnFiltersAdded = true;
            if (Filters.ColumnFilters.fxdSuppName.Count > 0) ColumnFiltersAdded = true;
            if (Filters.ColumnFilters.dsrdSuppName.Count > 0) ColumnFiltersAdded = true;
            if (Filters.ColumnFilters.commCategory.Count > 0) ColumnFiltersAdded = true;
            if (Filters.ColumnFilters.escaped.Count > 0) ColumnFiltersAdded = true;
            if (Filters.ColumnFilters.poDocumentType.Count > 0) ColumnFiltersAdded = true;
            if (Filters.ColumnFilters.prodOrderMat.Count > 0) ColumnFiltersAdded = true;
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
        /// Determines if the PR or PO date ranges are valid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dp_DateRangeChange(object sender, EventArgs e)
        {
            if(FilterByPrDate || FilterByPoDate || FilterByFinalRecDate)
            {
                Bunifu.Framework.UI.BunifuDatepicker dp = (Bunifu.Framework.UI.BunifuDatepicker)sender;
                int tag = int.Parse(dp.Tag.ToString());
                CheckDateRange(tag);
            }
        }





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
        /// Determines if the apply, clear, and clear selected buttons should be enabled or disabled.
        /// </summary>
        private void UpdateFilterButtons()
        {
            HasFiltersAdded();
            if (ColumnFiltersAdded || DateFiltersAdded || AdvancedFiltersAdded)
            {
                EnableApplyFiltersButton();
                EnableClearSelectedButton();
            }
            else
            {
                DisableButton(btn_applyFilters);
                DisableButton(btn_clearSelected);
            }


            if (ColumnFiltersApplied || DateFiltersApplied || AdvancedFiltersApplied)
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
                        FilterByPrDate = true;
                        CheckDateRange(0);
                    }
                    else
                    {
                        FilterByPrDate = false;
                    }
                    break;
                case 1:
                    // Check if the user has chosen the option to filter by PO Date.
                    if (chkBox_PoDateRange.Checked)
                    {
                        FilterByPoDate = true;
                        CheckDateRange(2);
                    }
                    else
                    {
                        FilterByPoDate = false;
                    }
                    break;
                case 2:
                    // Check if the user has chosen the option to filter by final receipt date.
                    if (chkBox_FinalReceiptDate.Checked)
                    {
                        FilterByFinalRecDate = true;
                        CheckDateRange(2);
                    }
                    else
                    {
                        FilterByFinalRecDate = false;
                    }
                    break;
                case 3:
                    // Check if the user has chosent the option to filter service PR/POs
                    if (chkBox_servicePrPo.Checked)
                    {
                        Filters.AdvancedFilters.FilterByServicePrPo = true;
                    }
                    else
                    {
                        Filters.AdvancedFilters.FilterByServicePrPo = false;
                    }
                    break;
                case 4:
                    // Check if the user has chosent the option to filter steel PR/POs
                    if (chkBox_SteelPrPo.Checked)
                    {
                        Filters.AdvancedFilters.FilterBySteelPrPo = true;
                    }
                    else
                    {
                        Filters.AdvancedFilters.FilterBySteelPrPo = false;
                    }
                    break;
                case 5:
                    // Check if the user has chosent the option to filter POU PR/POs
                    if (chkBox_pouPrPo.Checked)
                    {
                        Filters.AdvancedFilters.FilterByPouPrPo = true;
                    }
                    else
                    {
                        Filters.AdvancedFilters.FilterByPouPrPo = false;
                    }
                    break;
                case 6:
                    // Check if the user has chosent the option to filter Intercompany POs
                    if (chkBox_IntCompPo.Checked)
                    {
                        Filters.AdvancedFilters.FilterByIntercompPo = true;
                    }
                    else
                    {
                        Filters.AdvancedFilters.FilterByIntercompPo = false;
                    }
                    break;
                case 7:
                    // Check if the user has chosent the option to filter Codified Material (non- subcontract)
                    if (chkBox_codifiedMatNonSub.Checked)
                    {
                        Filters.AdvancedFilters.FilterByCodifiedMatNonSubcont = true;
                    }
                    else
                    {
                        Filters.AdvancedFilters.FilterByCodifiedMatNonSubcont = false;
                    }
                    break;
                case 8:
                    // Check if the user has chosent the option to filter Codified Material (Subcontact)
                    if (chkBox_codifiedMatSubCon.Checked)
                    {
                        Filters.AdvancedFilters.FilterByCodifiedMatSubcont = true;
                    }
                    else
                    {
                        Filters.AdvancedFilters.FilterByCodifiedMatSubcont = false;
                    }
                    break;
                default:
                    // Check if the user has chosent the option to filter Manual PRs
                    if (chkBox_manualPr.Checked)
                    {
                        Filters.AdvancedFilters.FilterByManualPr = true;
                    }
                    else
                    {
                        Filters.AdvancedFilters.FilterByManualPr = false;
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
            catch(Exception ex)
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter Label Click Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
