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

        private static string filters = string.Empty;
        private List<int> activeCLBs = new List<int>();

        #endregion

        #region PROPERTIES

        /// <summary>
        /// boolean value stating whether or not the user has checked filters TO apply
        /// </summary>
        public static bool ColumnFiltersAdded { get; set; }




        /// <summary>
        /// Boolean value stating whether or not the user has added a date range filters to either the PR or PO Creation date.
        /// </summary>
        public static bool DateFiltersAdded { get; set; }





        /// <summary>
        /// boolean value indicating whether or not the user has applied the filters to the data.
        /// </summary>
        public static bool ColumnFiltersApplied { get; set; }





        /// <summary>
        /// boolean value indicating whether or not the user has applied date filters to the data
        /// </summary>
        public static bool DateFiltersApplied { get; set; }



        /// <summary>
        /// Boolean value indicating whether the program should filter by the PR date range.
        /// </summary>
        public static bool FilterByPrDate { get; set; }





        /// <summary>
        /// Boolean vaule indicating whether the program should filter by the PO date range.
        /// </summary>
        public static bool FilterByPoDate { get; set; }

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
                case 13: // Final Receipt Date
                    ChkdListBx_FinalReceiptDate.Invoke((MethodInvoker)delegate {
                        ChkdListBx_FinalReceiptDate.Items.Clear();
                        lst = new List<string>(data);
                        ChkdListBx_FinalReceiptDate.Items.AddRange(lst.ToArray());
                    });
                    break;
                default:
                    break;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        internal FilterUtils.Filters GetActiveCLBFitler(int tag)
        {
            switch (tag)
            {
                case 0: // Project number
                    return FilterUtils.Filters.ProjectNum_WBS_Element;
                case 1: // WBS Element
                    return FilterUtils.Filters.WBS_Element;
                case 2: // Material
                    return FilterUtils.Filters.Material;
                case 3: // Material Group
                    return FilterUtils.Filters.MaterialGroup;
                case 4: // Vendor
                    return FilterUtils.Filters.Vendor;
                case 5: // Vendor Desc
                    return FilterUtils.Filters.VendorDescription;
                case 6: // Purch Group
                    return FilterUtils.Filters.PurchGroup;
                case 7: // PO Purch Group
                    return FilterUtils.Filters.PoPurchGroup;
                case 8: // IR Supp Name
                    return FilterUtils.Filters.IRSuppName;
                case 9: // Fxd Supp Name
                    return FilterUtils.Filters.FxdSuppName;
                case 10: // Dsrd Supp Name
                    return FilterUtils.Filters.DsrdSuppName;
                case 11: // Commodity Cat
                    return FilterUtils.Filters.CommCat;
                default:
                    return FilterUtils.Filters.FinalReceiptDate;
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
                        Filters.FilterValues.projectNumber.Add(clb.Items[e.Index].ToString());
                        activeCLBs.Add(int.Parse(ChkdListBx_ProjectNumber.Tag.ToString()));
                        BuildQueryFilters();
                        FilterUtils.LoadFiltersExcluded(filters, FilterUtils.Filters.ProjectNum_WBS_Element);
                    }
                    else
                    {
                        Filters.FilterValues.projectNumber.Remove(clb.Items[e.Index].ToString());
                        int position = activeCLBs.LastIndexOf(int.Parse(ChkdListBx_ProjectNumber.Tag.ToString()));
                        activeCLBs.RemoveAt(position);
                        BuildQueryFilters();
                        if (activeCLBs.Count == 0)
                            FilterUtils.LoadFilters(filters);
                        else
                        {
                            FilterUtils.LoadFiltersExcluded(filters, GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                            FilterUtils.LoadFilter(GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                        }
                    }
                    break;
                case 1: // WBS Element
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FilterValues.wbsElement.Add(clb.Items[e.Index].ToString());
                        activeCLBs.Add(int.Parse(ChkdListBx_WBSElement.Tag.ToString()));
                        BuildQueryFilters();
                        FilterUtils.LoadFiltersExcluded(filters, FilterUtils.Filters.WBS_Element);
                    }
                    else
                    {
                        Filters.FilterValues.wbsElement.Remove(clb.Items[e.Index].ToString());
                        int position = activeCLBs.LastIndexOf(int.Parse(ChkdListBx_WBSElement.Tag.ToString()));
                        activeCLBs.RemoveAt(position);
                        BuildQueryFilters();
                        if (activeCLBs.Count == 0)
                            FilterUtils.LoadFilters(filters);
                        else
                        {
                            FilterUtils.LoadFiltersExcluded(filters, GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                            FilterUtils.LoadFilter(GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                        }
                    }
                    break;
                case 2: // Material
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FilterValues.material.Add(clb.Items[e.Index].ToString());
                        activeCLBs.Add(int.Parse(ChkdListBx_Material.Tag.ToString()));
                        BuildQueryFilters();
                        FilterUtils.LoadFiltersExcluded(filters, FilterUtils.Filters.Material);
                    }
                    else
                    {
                        Filters.FilterValues.material.Remove(clb.Items[e.Index].ToString());
                        int position = activeCLBs.LastIndexOf(int.Parse(ChkdListBx_Material.Tag.ToString()));
                        activeCLBs.RemoveAt(position);
                        BuildQueryFilters();
                        if (activeCLBs.Count == 0)
                            FilterUtils.LoadFilters(filters);
                        else
                        {
                            FilterUtils.LoadFiltersExcluded(filters, GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                            FilterUtils.LoadFilter(GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                        }
                    }
                    break;
                case 3: // Material Group
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FilterValues.materialGroup.Add(clb.Items[e.Index].ToString());
                        activeCLBs.Add(int.Parse(ChkdListBx_MaterialGroup.Tag.ToString()));
                        BuildQueryFilters();
                        FilterUtils.LoadFiltersExcluded(filters, FilterUtils.Filters.MaterialGroup);
                    }
                    else
                    {
                        Filters.FilterValues.materialGroup.Remove(clb.Items[e.Index].ToString());
                        int position = activeCLBs.LastIndexOf(int.Parse(ChkdListBx_MaterialGroup.Tag.ToString()));
                        activeCLBs.RemoveAt(position);
                        BuildQueryFilters();
                        if (activeCLBs.Count == 0)
                            FilterUtils.LoadFilters(filters);
                        else
                        {
                            FilterUtils.LoadFiltersExcluded(filters, GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                            FilterUtils.LoadFilter(GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                        }
                    }
                    break;
                case 4: // Vendor
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FilterValues.vendor.Add(clb.Items[e.Index].ToString());
                        activeCLBs.Add(int.Parse(ChkdListBx_Vendor.Tag.ToString()));
                        BuildQueryFilters();
                        FilterUtils.LoadFiltersExcluded(filters, FilterUtils.Filters.Vendor);
                    }
                    else
                    {
                        Filters.FilterValues.vendor.Remove(clb.Items[e.Index].ToString());
                        int position = activeCLBs.LastIndexOf(int.Parse(ChkdListBx_Vendor.Tag.ToString()));
                        activeCLBs.RemoveAt(position);
                        BuildQueryFilters();
                        if (activeCLBs.Count == 0)
                            FilterUtils.LoadFilters(filters);
                        else
                        {
                            FilterUtils.LoadFiltersExcluded(filters, GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                            FilterUtils.LoadFilter(GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                        }
                    }
                    break;
                case 5: // Vendor Desc
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FilterValues.vendorDesc.Add(clb.Items[e.Index].ToString());
                        activeCLBs.Add(int.Parse(ChkdListBx_VendorDesc.Tag.ToString()));
                        BuildQueryFilters();
                        FilterUtils.LoadFiltersExcluded(filters, FilterUtils.Filters.VendorDescription);
                    }
                    else
                    {
                        Filters.FilterValues.vendorDesc.Remove(clb.Items[e.Index].ToString());
                        int position = activeCLBs.LastIndexOf(int.Parse(ChkdListBx_VendorDesc.Tag.ToString()));
                        activeCLBs.RemoveAt(position);
                        BuildQueryFilters();
                        if (activeCLBs.Count == 0)
                            FilterUtils.LoadFilters(filters);
                        else
                        {
                            FilterUtils.LoadFiltersExcluded(filters, GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                            FilterUtils.LoadFilter(GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                        }
                    }
                    break;
                case 6: // PR Purch Group
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FilterValues.purchGroup.Add(clb.Items[e.Index].ToString());
                        activeCLBs.Add(int.Parse(ChkdListBx_PrPurchGroup.Tag.ToString()));
                        BuildQueryFilters();
                        FilterUtils.LoadFiltersExcluded(filters, FilterUtils.Filters.PurchGroup);
                    }
                    else
                    {
                        Filters.FilterValues.purchGroup.Remove(clb.Items[e.Index].ToString());
                        int position = activeCLBs.LastIndexOf(int.Parse(ChkdListBx_PrPurchGroup.Tag.ToString()));
                        activeCLBs.RemoveAt(position);
                        BuildQueryFilters();
                        if (activeCLBs.Count == 0)
                            FilterUtils.LoadFilters(filters);
                        else
                        {
                            FilterUtils.LoadFiltersExcluded(filters, GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                            FilterUtils.LoadFilter(GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                        }
                    }
                    break;
                case 7: // PO Purch Group
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FilterValues.poPurchGroup.Add(clb.Items[e.Index].ToString());
                        activeCLBs.Add(int.Parse(ChkdListBx_PoPurchGroup.Tag.ToString()));
                        BuildQueryFilters();
                        FilterUtils.LoadFiltersExcluded(filters, FilterUtils.Filters.PoPurchGroup);
                    }
                    else
                    {
                        Filters.FilterValues.poPurchGroup.Remove(clb.Items[e.Index].ToString());
                        int position = activeCLBs.LastIndexOf(int.Parse(ChkdListBx_PoPurchGroup.Tag.ToString()));
                        activeCLBs.RemoveAt(position);
                        BuildQueryFilters();
                        if (activeCLBs.Count == 0)
                            FilterUtils.LoadFilters(filters);
                        else
                        {
                            FilterUtils.LoadFiltersExcluded(filters, GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                            FilterUtils.LoadFilter(GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                        }
                    }
                    break;
                case 8: // IR Supp Name
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FilterValues.irSuppName.Add(clb.Items[e.Index].ToString());
                        activeCLBs.Add(int.Parse(ChkdListBx_IRSuppName.Tag.ToString()));
                        BuildQueryFilters();
                        FilterUtils.LoadFiltersExcluded(filters, FilterUtils.Filters.IRSuppName);
                    }
                    else
                    {
                        Filters.FilterValues.irSuppName.Remove(clb.Items[e.Index].ToString());
                        int position = activeCLBs.LastIndexOf(int.Parse(ChkdListBx_IRSuppName.Tag.ToString()));
                        activeCLBs.RemoveAt(position);
                        BuildQueryFilters();
                        if (activeCLBs.Count == 0)
                            FilterUtils.LoadFilters(filters);
                        else
                        {
                            FilterUtils.LoadFiltersExcluded(filters, GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                            FilterUtils.LoadFilter(GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                        }
                    }
                    break;
                case 9: // Fxd Supp Name
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FilterValues.fxdSuppName.Add(clb.Items[e.Index].ToString());
                        activeCLBs.Add(int.Parse(ChkdListBx_FxdSuppName.Tag.ToString()));
                        BuildQueryFilters();
                        FilterUtils.LoadFiltersExcluded(filters, FilterUtils.Filters.FxdSuppName);
                    }
                    else
                    {
                        Filters.FilterValues.fxdSuppName.Remove(clb.Items[e.Index].ToString());
                        int position = activeCLBs.LastIndexOf(int.Parse(ChkdListBx_FxdSuppName.Tag.ToString()));
                        activeCLBs.RemoveAt(position);
                        BuildQueryFilters();
                        if (activeCLBs.Count == 0)
                            FilterUtils.LoadFilters(filters);
                        else
                        {
                            FilterUtils.LoadFiltersExcluded(filters, GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                            FilterUtils.LoadFilter(GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                        }
                    }
                    break;
                case 10: // Dsrd Supp Name
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FilterValues.dsrdSuppName.Add(clb.Items[e.Index].ToString());
                        activeCLBs.Add(int.Parse(ChkdListBx_DsrdSuppName.Tag.ToString()));
                        BuildQueryFilters();
                        FilterUtils.LoadFiltersExcluded(filters, FilterUtils.Filters.DsrdSuppName);
                    }
                    else
                    {
                        Filters.FilterValues.dsrdSuppName.Remove(clb.Items[e.Index].ToString());
                        int position = activeCLBs.LastIndexOf(int.Parse(ChkdListBx_DsrdSuppName.Tag.ToString()));
                        activeCLBs.RemoveAt(position);
                        BuildQueryFilters();
                        if (activeCLBs.Count == 0)
                            FilterUtils.LoadFilters(filters);
                        else
                        {
                            FilterUtils.LoadFiltersExcluded(filters, GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                            FilterUtils.LoadFilter(GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                        }
                    }
                    break;
                case 11: // Commodity Category
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FilterValues.commCategory.Add(clb.Items[e.Index].ToString());
                        activeCLBs.Add(int.Parse(ChkdListBx_CommodityCat.Tag.ToString()));
                        BuildQueryFilters();
                        FilterUtils.LoadFiltersExcluded(filters, FilterUtils.Filters.CommCat);
                    }
                    else
                    {
                        Filters.FilterValues.commCategory.Remove(clb.Items[e.Index].ToString());
                        int position = activeCLBs.LastIndexOf(int.Parse(ChkdListBx_CommodityCat.Tag.ToString()));
                        activeCLBs.RemoveAt(position);
                        BuildQueryFilters();
                        if (activeCLBs.Count == 0)
                            FilterUtils.LoadFilters(filters);
                        else
                        {
                            FilterUtils.LoadFiltersExcluded(filters, GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                            FilterUtils.LoadFilter(GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                        }
                    }
                    break;
                case 12: // Final Receipt Date
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FilterValues.finalRecDate.Add(clb.Items[e.Index].ToString());
                        activeCLBs.Add(int.Parse(ChkdListBx_FinalReceiptDate.Tag.ToString()));
                        BuildQueryFilters();
                        FilterUtils.LoadFiltersExcluded(filters, FilterUtils.Filters.FinalReceiptDate);
                    }
                    else
                    {
                        Filters.FilterValues.finalRecDate.Remove(clb.Items[e.Index].ToString());
                        int position = activeCLBs.LastIndexOf(int.Parse(ChkdListBx_FinalReceiptDate.Tag.ToString()));
                        activeCLBs.RemoveAt(position);
                        BuildQueryFilters();
                        if (activeCLBs.Count == 0)
                            FilterUtils.LoadFilters(filters);
                        else
                        {
                            FilterUtils.LoadFiltersExcluded(filters, GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                            FilterUtils.LoadFilter(GetActiveCLBFitler(activeCLBs[activeCLBs.Count - 1]));
                        }
                    }
                    break;
            }
            UpdateCheckedItems();
        }






        /// <summary>
        /// Builds the query that consists of the filters that will load the data.
        /// </summary>
        private void BuildQueryFilters()
        {
            filters = string.Empty;


            // Project Number
            if (Filters.FilterValues.projectNumber.Count > 0)
            {
                for (int i = 0; i < Filters.FilterValues.projectNumber.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (Filters.FilterValues.projectNumber[i] == "[Blanks]")
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.ProjectNum_WBS_Element] + "] IS NULL OR " + Values.Globals.SelectedCountry + ".[" + FilterFeeature.FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.ProjectNUm_ProdOrdWbs] + "] IS NULL";
                    else
                        filters += Values.Globals.SelectedCountry + ".[" + FilterFeeature.FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.ProjectNum_WBS_Element] + "] LIKE " + "'%" + Filters.FilterValues.projectNumber[i] + "%' OR " + Values.Globals.SelectedCountry + ".[" + FilterFeeature.FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.ProjectNUm_ProdOrdWbs] + "] LIKE " + "'%" + Filters.FilterValues.projectNumber[i] + "%'";

                    if (i != (Filters.FilterValues.projectNumber.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }




            // WBS Element
            if (Filters.FilterValues.wbsElement.Count > 0)
            {
                for (int i = 0; i < Filters.FilterValues.wbsElement.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (Filters.FilterValues.wbsElement[i] == "[Blanks]")
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.WBS_Element] + "] IS NULL";
                    else
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.WBS_Element] + "] = " + "'" + Filters.FilterValues.wbsElement[i] + "'";


                    if (i != (Filters.FilterValues.wbsElement.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }


            // Material
            if (Filters.FilterValues.material.Count > 0)
            {
                for (int i = 0; i < Filters.FilterValues.material.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (Filters.FilterValues.material[i] == "[Blanks]")
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.Material] + "] IS NULL";
                    else
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.Material] + "] = " + "'" + Filters.FilterValues.material[i] + "'";

                    if (i != (Filters.FilterValues.material.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            
            // Material Group
            if(Filters.FilterValues.materialGroup.Count > 0)
            {
                for (int i = 0; i < Filters.FilterValues.materialGroup.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (Filters.FilterValues.materialGroup[i] == "[Blanks]")
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.MaterialGroup] + "] IS NULL";
                    else
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.MaterialGroup] + "] = " + "'" + Filters.FilterValues.materialGroup[i] + "'";

                    if (i != (Filters.FilterValues.materialGroup.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            
            // Vendor
            if(Filters.FilterValues.vendor.Count > 0)
            {
                for (int i = 0; i < Filters.FilterValues.vendor.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (Filters.FilterValues.vendor[i] == "[Blanks]")
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.Vendor] + "] IS NULL";
                    else
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.Vendor] + "] = " + Filters.FilterValues.vendor[i];

                    if (i != (Filters.FilterValues.vendor.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            
            // Vendor Description
            if(Filters.FilterValues.vendorDesc.Count > 0)
            {
                for (int i = 0; i < Filters.FilterValues.vendorDesc.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    if (Filters.FilterValues.vendorDesc[i] == "[Blanks]")
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.VendorDescription] + "] IS NULL";
                    else
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.VendorDescription] + "] = " + "'" + Filters.FilterValues.vendorDesc[i] + "'";

                    if (i != (Filters.FilterValues.vendorDesc.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            

            // Purchase Group
            if(Filters.FilterValues.purchGroup.Count > 0)
            {
                for (int i = 0; i < Filters.FilterValues.purchGroup.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (Filters.FilterValues.purchGroup[i] == "[Blanks]")
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.PurchGroup] + "] IS NULL";
                    else
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.PurchGroup] + "] = " + "'" + Filters.FilterValues.purchGroup[i] + "'";

                    if (i != (Filters.FilterValues.purchGroup.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }



            // PO Purchase Group
            if (Filters.FilterValues.poPurchGroup.Count > 0)
            {
                for (int i = 0; i < Filters.FilterValues.poPurchGroup.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (Filters.FilterValues.poPurchGroup[i] == "[Blanks]")
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.PoPurchGroup] + "] IS NULL";
                    else
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.PoPurchGroup] + "] = " + "'" + Filters.FilterValues.poPurchGroup[i] + "'";

                    if (i != (Filters.FilterValues.poPurchGroup.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }


            // IR Supp Name
            if (Filters.FilterValues.irSuppName.Count > 0)
            {
                for (int i = 0; i < Filters.FilterValues.irSuppName.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (Filters.FilterValues.irSuppName[i] == "[Blanks]")
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.IRSuppName] + "] IS NULL";
                    else
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.IRSuppName] + "] = " + "'" + Filters.FilterValues.irSuppName[i] + "'";

                    if (i != (Filters.FilterValues.irSuppName.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            

            // Fxd Supp Name
            if(Filters.FilterValues.fxdSuppName.Count > 0)
            {
                for (int i = 0; i < Filters.FilterValues.fxdSuppName.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (Filters.FilterValues.fxdSuppName[i] == "[Blanks]")
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.FxdSuppName] + "] IS NULL";
                    else
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.FxdSuppName] + "] = " + "'" + Filters.FilterValues.fxdSuppName[i] + "'";

                    if (i != (Filters.FilterValues.fxdSuppName.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            

            // Dsrd Supp Name
            if(Filters.FilterValues.dsrdSuppName.Count > 0)
            {
                for (int i = 0; i < Filters.FilterValues.dsrdSuppName.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (Filters.FilterValues.dsrdSuppName[i] == "[Blanks]")
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.DsrdSuppName] + "] IS NULL";
                    else
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.DsrdSuppName] + "] = " + "'" + Filters.FilterValues.dsrdSuppName[i] + "'";

                    if (i != (Filters.FilterValues.dsrdSuppName.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            

            // Comm Category
            if(Filters.FilterValues.commCategory.Count > 0)
            {
                for (int i = 0; i < Filters.FilterValues.commCategory.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (Filters.FilterValues.commCategory[i] == "[Blanks]")
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.CommCat] + "] IS NULL";
                    else
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.CommCat] + "] = " + "'" + Filters.FilterValues.commCategory[i] + "'";


                    if (i != (Filters.FilterValues.commCategory.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }


            // Final Receipt Date
            if (Filters.FilterValues.finalRecDate.Count > 0)
            {
                for (int i = 0; i < Filters.FilterValues.finalRecDate.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    if (Filters.FilterValues.finalRecDate[i] == "[Blanks]")
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.FinalReceiptDate] + "] IS NULL";
                    else
                        filters += Values.Globals.SelectedCountry + ".[" + FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.FinalReceiptDate] + "] = " + "'" + Filters.FilterValues.finalRecDate[i] + "'";


                    if (i != (Filters.FilterValues.finalRecDate.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
        }






        /// <summary>
        /// This function will ensure that values that are checked stay checked
        /// after the check boxes are updated and populated with new values.
        /// </summary>
        private void UpdateCheckedItems()
        {
            int index = 0;

            // Project Number
            if (Filters.FilterValues.projectNumber.Count > 0)
            {
                ChkdListBx_ProjectNumber.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FilterValues.projectNumber)
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
            if (Filters.FilterValues.wbsElement.Count > 0)
            {
                ChkdListBx_WBSElement.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FilterValues.wbsElement)
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
            if (Filters.FilterValues.material.Count > 0)
            {
                ChkdListBx_Material.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FilterValues.material)
                {
                    index = ChkdListBx_Material.Items.IndexOf(str);
                    if(index >= 0)
                    {
                        if (!ChkdListBx_Material.GetItemChecked(index))
                            ChkdListBx_Material.SetItemChecked(index, true);
                    }
                }
                ChkdListBx_Material.ItemCheck += ckdListBox_ItemCheck;
            }


            // Material Group
            if (Filters.FilterValues.materialGroup.Count > 0)
            {
                ChkdListBx_MaterialGroup.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FilterValues.materialGroup)
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
            if (Filters.FilterValues.vendor.Count > 0)
            {
                ChkdListBx_Vendor.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FilterValues.vendor)
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
            if (Filters.FilterValues.vendorDesc.Count > 0)
            {
                ChkdListBx_VendorDesc.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FilterValues.vendorDesc)
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
            if (Filters.FilterValues.purchGroup.Count > 0)
            {
                ChkdListBx_PrPurchGroup.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FilterValues.purchGroup)
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
            if (Filters.FilterValues.poPurchGroup.Count > 0)
            {
                ChkdListBx_PoPurchGroup.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FilterValues.poPurchGroup)
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
            if (Filters.FilterValues.irSuppName.Count > 0)
            {
                ChkdListBx_IRSuppName.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FilterValues.irSuppName)
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
            if (Filters.FilterValues.fxdSuppName.Count > 0)
            {
                ChkdListBx_FxdSuppName.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FilterValues.fxdSuppName)
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
            if (Filters.FilterValues.dsrdSuppName.Count > 0)
            {
                ChkdListBx_DsrdSuppName.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FilterValues.dsrdSuppName)
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
            if (Filters.FilterValues.commCategory.Count > 0)
            {
                ChkdListBx_CommodityCat.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FilterValues.commCategory)
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

            // Final Receipt Date
            if (Filters.FilterValues.finalRecDate.Count > 0)
            {
                ChkdListBx_FinalReceiptDate.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FilterValues.finalRecDate)
                {
                    index = ChkdListBx_FinalReceiptDate.Items.IndexOf(str);
                    if (index >= 0)
                    {
                        if (!ChkdListBx_FinalReceiptDate.GetItemChecked(index))
                            ChkdListBx_FinalReceiptDate.SetItemChecked(index, true);
                    }
                }
                ChkdListBx_FinalReceiptDate.ItemCheck += ckdListBox_ItemCheck;
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
            HasFiltersAdded();

            if (DateFiltersAdded)
            {
                if (FilterByPrDate)
                {
                    FilterByPrDate = false;
                    chkBox_PrDateRange.Checked = false;
                }

                if (FilterByPoDate)
                {
                    FilterByPoDate = false;
                    chkBox_PoDateRange.Checked = false;
                }
            }


            if (ColumnFiltersAdded)
            {
                // Project Number
                foreach (int i in ChkdListBx_ProjectNumber.CheckedIndices)
                {
                    ChkdListBx_ProjectNumber.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_ProjectNumber.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_ProjectNumber.ItemCheck += ckdListBox_ItemCheck;
                }

                // WBS Element
                foreach (int i in ChkdListBx_WBSElement.CheckedIndices)
                {
                    ChkdListBx_WBSElement.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_WBSElement.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_WBSElement.ItemCheck += ckdListBox_ItemCheck;

                }

                // Material
                foreach (int i in ChkdListBx_Material.CheckedIndices)
                {
                    ChkdListBx_Material.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_Material.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_Material.ItemCheck += ckdListBox_ItemCheck;

                }

                // Material Group
                foreach (int i in ChkdListBx_MaterialGroup.CheckedIndices)
                {
                    ChkdListBx_MaterialGroup.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_MaterialGroup.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_MaterialGroup.ItemCheck += ckdListBox_ItemCheck;

                }

                // Vendor
                foreach (int i in ChkdListBx_Vendor.CheckedIndices)
                {
                    ChkdListBx_Vendor.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_Vendor.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_Vendor.ItemCheck += ckdListBox_ItemCheck;
                }

                // Vendor Desc
                foreach (int i in ChkdListBx_VendorDesc.CheckedIndices)
                {
                    ChkdListBx_VendorDesc.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_VendorDesc.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_VendorDesc.ItemCheck += ckdListBox_ItemCheck;
                }

                // PR Purchase Group
                foreach (int i in ChkdListBx_PrPurchGroup.CheckedIndices)
                {
                    ChkdListBx_PrPurchGroup.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_PrPurchGroup.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_PrPurchGroup.ItemCheck += ckdListBox_ItemCheck;
                }

                // PO Purch Group
                foreach (int i in ChkdListBx_PoPurchGroup.CheckedIndices)
                {
                    ChkdListBx_PoPurchGroup.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_PoPurchGroup.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_PoPurchGroup.ItemCheck += ckdListBox_ItemCheck;
                }

                // IR Supp Name
                foreach (int i in ChkdListBx_IRSuppName.CheckedIndices)
                {
                    ChkdListBx_IRSuppName.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_IRSuppName.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_IRSuppName.ItemCheck += ckdListBox_ItemCheck;
                }

                // Fxd Supp Name
                foreach (int i in ChkdListBx_FxdSuppName.CheckedIndices)
                {
                    ChkdListBx_FxdSuppName.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_FxdSuppName.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_FxdSuppName.ItemCheck += ckdListBox_ItemCheck;
                }

                // Dsrd Supp Name
                foreach (int i in ChkdListBx_DsrdSuppName.CheckedIndices)
                {
                    ChkdListBx_DsrdSuppName.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_DsrdSuppName.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_DsrdSuppName.ItemCheck += ckdListBox_ItemCheck;
                }

                // Commodity Category
                foreach (int i in ChkdListBx_CommodityCat.CheckedIndices)
                {
                    ChkdListBx_CommodityCat.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_CommodityCat.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_CommodityCat.ItemCheck += ckdListBox_ItemCheck;
                }

                // Final Receipt Date
                foreach (int i in ChkdListBx_FinalReceiptDate.CheckedIndices)
                {
                    ChkdListBx_FinalReceiptDate.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_FinalReceiptDate.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_FinalReceiptDate.ItemCheck += ckdListBox_ItemCheck;
                }

                Filters.FilterValues.Clear();
                filters = string.Empty;
                FilterUtils.LoadFilters(filters);
            }

            UpdateFilterButtons();
        }




        private void GetCheckedColumnFilters()
        {
            Filters.FilterValues.Clear();

            // Project Number
            foreach (int i in ChkdListBx_ProjectNumber.CheckedIndices)
            {
                Filters.FilterValues.projectNumber.Add(ChkdListBx_ProjectNumber.Items[i].ToString());
            }

            // WBS Element
            foreach (int i in ChkdListBx_WBSElement.CheckedIndices)
            {
                Filters.FilterValues.wbsElement.Add(ChkdListBx_WBSElement.Items[i].ToString());
            }

            // Material
            foreach (int i in ChkdListBx_Material.CheckedIndices)
            {
                Filters.FilterValues.material.Add(ChkdListBx_Material.Items[i].ToString());
            }

            // Material Group
            foreach (int i in ChkdListBx_MaterialGroup.CheckedIndices)
            {
                Filters.FilterValues.materialGroup.Add(ChkdListBx_MaterialGroup.Items[i].ToString());
            }

            // Vendor
            foreach (int i in ChkdListBx_Vendor.CheckedIndices)
            {
                Filters.FilterValues.vendor.Add(ChkdListBx_Vendor.Items[i].ToString());
            }

            // Vendor Desc
            foreach (int i in ChkdListBx_VendorDesc.CheckedIndices)
            {
                Filters.FilterValues.vendorDesc.Add(ChkdListBx_VendorDesc.Items[i].ToString());
            }

            // PR Purchase Group
            foreach (int i in ChkdListBx_PrPurchGroup.CheckedIndices)
            {
                Filters.FilterValues.purchGroup.Add(ChkdListBx_PrPurchGroup.Items[i].ToString());
            }

            // PO Purchase Group
            foreach (int i in ChkdListBx_PoPurchGroup.CheckedIndices)
            {
                Filters.FilterValues.poPurchGroup.Add(ChkdListBx_PoPurchGroup.Items[i].ToString());
            }

            // IR Supp Name:
            foreach (int i in ChkdListBx_IRSuppName.CheckedIndices)
            {
                Filters.FilterValues.irSuppName.Add(ChkdListBx_IRSuppName.Items[i].ToString());
            }

            // Fxd Supp Name
            foreach (int i in ChkdListBx_FxdSuppName.CheckedIndices)
            {
                Filters.FilterValues.fxdSuppName.Add(ChkdListBx_FxdSuppName.Items[i].ToString());
            }

            // Dsrd Supp Name
            foreach (int i in ChkdListBx_DsrdSuppName.CheckedIndices)
            {
                Filters.FilterValues.dsrdSuppName.Add(ChkdListBx_DsrdSuppName.Items[i].ToString());
            }

            // Commodity Cat
            foreach (int i in ChkdListBx_CommodityCat.CheckedIndices)
            {
                Filters.FilterValues.commCategory.Add(ChkdListBx_CommodityCat.Items[i].ToString());
            }

            // Final Receipt Date
            foreach (int i in ChkdListBx_FinalReceiptDate.CheckedIndices)
            {
                Filters.FilterValues.finalRecDate.Add(ChkdListBx_FinalReceiptDate.Items[i].ToString());
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
                    Filters.FilterByPrDateRange = false;
                    return;
                }
                else
                {
                    Filters.PrFromDate = dp_PRFromDate.Value;
                    Filters.PrToDate = dp_PRToDate.Value;
                    Filters.FilterByPrDateRange = true;
                }
            }
            else
            {
                Filters.FilterByPrDateRange = false;
            }


            if(FilterByPoDate)
            {
                if (CheckDateRange(2))
                {
                    Filters.FilterByPoDateRange = false;
                    return;
                }
                else
                {
                    Filters.PoFromDate = dp_POFromDate.Value;
                    Filters.PoToDate = dp_POToDate.Value;
                    Filters.FilterByPoDateRange = true;
                }
            }
            else
            {
                Filters.FilterByPoDateRange = false;
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

            InitializeDataLoadProcess();
        }






        /// <summary>
        /// Clear the filters and set everything back to default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_clearFilters_Click(object sender, EventArgs e)
        {

            ResetFilters();
            UpdateFilterButtons();
            DataReader.LoadOverallData(ref overallData);
            InitializeFilterLoadProcess();
        }







        /// <summary>
        /// 
        /// </summary>
        internal void ResetFilters()
        {
            Filters.FilterValues.Clear();
            Filters.FilterQuery = string.Empty;
            Filters.SecondaryFilterQuery = string.Empty;

            Filters.FilterByPrDateRange = false;
            Filters.FilterByPoDateRange = false;
            FilterByPrDate = false;
            FilterByPoDate = false;
            chkBox_PrDateRange.Checked = false;
            chkBox_PoDateRange.Checked = false;

            ColumnFiltersAdded = false;
            ColumnFiltersApplied = false;
            DateFiltersAdded = false;
            DateFiltersApplied = false;
        }






        /// <summary>
        /// If the user has applied filters against the data, this function will assign FiltersAdded to true.
        /// </summary>
        public void HasFiltersAdded()
        {
            ColumnFiltersAdded = false;

            // Check if the user enable the option to filter by PR or PO date range.
            if (FilterByPrDate || FilterByPoDate)
                DateFiltersAdded = true;
             else
                DateFiltersAdded = false;


            // Check if the user selected any filters from the following check list boxes.
            if (Filters.FilterValues.projectNumber.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FilterValues.wbsElement.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FilterValues.material.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FilterValues.material.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FilterValues.materialGroup.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FilterValues.vendor.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FilterValues.vendorDesc.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FilterValues.purchGroup.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FilterValues.poPurchGroup.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FilterValues.irSuppName.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FilterValues.fxdSuppName.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FilterValues.dsrdSuppName.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FilterValues.commCategory.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FilterValues.finalRecDate.Count > 0) ColumnFiltersAdded = true;
        }




        /// <summary>
        /// 
        /// </summary>
        private void EnableApplyFiltersButton()
        {
            btn_applyFilters.Enabled = true;
            btn_applyFilters.BackColor = System.Drawing.Color.MediumSeaGreen;
            btn_applyFilters.ForeColor = System.Drawing.SystemColors.ButtonFace;
        }


        /// <summary>
        /// 
        /// </summary>
        private void EnableClearSelectedButton()
        {
            btn_clearSelected.Enabled = true;
            btn_clearSelected.BackColor = System.Drawing.Color.DarkSlateGray;
            btn_clearSelected.ForeColor = System.Drawing.SystemColors.ButtonFace;
        }



        private void EnableClearFiltersButton()
        {
            btn_clearFilters.Enabled = true;
            btn_clearFilters.BackColor = System.Drawing.Color.IndianRed;
            btn_clearFilters.ForeColor = System.Drawing.SystemColors.ButtonFace;
        }


        /// <summary>
        /// 
        /// </summary>
        private void DisableButton(Button btn)
        {
            btn.Enabled = false;
            btn.BackColor = System.Drawing.Color.LightGray;
            btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
        }



        /// <summary>
        /// 
        /// </summary>
        private void UpdateFilterButtons()
        {
            HasFiltersAdded();
            if(ColumnFiltersAdded || DateFiltersAdded)
            {
                EnableApplyFiltersButton();
                EnableClearSelectedButton();
            }
            else
            {
                DisableButton(btn_applyFilters);
                DisableButton(btn_clearSelected);
            }


            if(ColumnFiltersApplied || DateFiltersApplied)
            {
                EnableClearFiltersButton();
            }
            else
            {
                DisableButton(btn_clearFilters);
            }
        }




        /// <summary>
        /// Determines if the PR or PO date ranges are valid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dp_DateRangeChange(object sender, EventArgs e)
        {
            if(FilterByPrDate || FilterByPoDate)
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
                default:
                    break;
            }
            return false;
        }




        /// <summary>
        /// this event will toggle the PR date range check box and enable the
        /// program to check for a PR date range.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prDateRangeCheckBox_OnChange(object sender, EventArgs e)
        {
            if (chkBox_PrDateRange.Checked)
            {
                // if this checkbox is checked then we will want to enable the ability to filter by PR date range.
                FilterByPrDate = true;
                CheckDateRange(0);
                UpdateFilterButtons();
            }
            else
            {
                // we want to turn off the ability to filter by PR date range.
                FilterByPrDate = false;
                UpdateFilterButtons();
            }
        }





        /// <summary>
        /// this event will toggle the PO date range check box and enable the
        /// program to check for a PO date range.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void poDateRangeCheckBox_OnChange(object sender, EventArgs e)
        {
            if (chkBox_PoDateRange.Checked)
            {
                // if this checkbox is checked then we will want to enable the ability to filter by PO date range.
                FilterByPoDate = true;
                CheckDateRange(2);
                UpdateFilterButtons();
            }
            else
            {
                // we want to turn off the ability to filter by PO date range
                FilterByPoDate = false;
                UpdateFilterButtons();
            }
        }






        /// <summary>
        /// When the user clicks the label "PR Date Range: " label, this event will toggle the PR date range check box and enable the
        /// program to check for a PR date range.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prDateRangeLabel_Click(object sender, EventArgs e)
        {
            if (chkBox_PrDateRange.Checked)
            {
                chkBox_PrDateRange.Checked = false;
                FilterByPrDate = false;
                CheckDateRange(0);
                UpdateFilterButtons();
            }
            else
            {
                chkBox_PrDateRange.Checked = true;
                FilterByPrDate = true;
                UpdateFilterButtons();
            }
        }





        /// <summary>
        /// When the user clicks the label "PO Date Range: " label, this event will toggle the PO date range check box and enable the
        /// program to check for a PO date range.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void poDateRangeLabel_Click(object sender, EventArgs e)
        {
            if (chkBox_PoDateRange.Checked)
            {
                chkBox_PoDateRange.Checked = false;
                FilterByPoDate = false;
                CheckDateRange(2);
                UpdateFilterButtons();
            }
            else
            {
                chkBox_PoDateRange.Checked = true;
                FilterByPoDate = true;
                UpdateFilterButtons();
            }
        }
    }
}
