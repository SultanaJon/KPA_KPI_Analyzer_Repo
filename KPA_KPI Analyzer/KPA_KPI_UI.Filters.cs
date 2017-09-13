using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI : Form
    {
        private static string filters = string.Empty;

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






        /// <summary>
        /// This function will populate the checklist boxes with the new data after a load.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filter"></param>
        public void UpdateFilters(List<string> data, FilterUtils.Filters filter)
        {
            HasFiltersAdded();

            UpdateFilterButtons();


            switch ((int)filter)
            {
                case 0:
                case 1:
                    break;
                case 2: // WBS Project
                    ChkdListBx_WBSProject.Invoke((MethodInvoker)delegate {
                        ChkdListBx_WBSProject.Items.Clear();
                        ChkdListBx_WBSProject.Items.AddRange(data.ToArray());
                    });
                    break;
                case 3: // Material
                    ChkdListBx_Material.Invoke((MethodInvoker)delegate {
                        ChkdListBx_Material.Items.Clear();
                        ChkdListBx_Material.Items.AddRange(data.ToArray());
                    });
                    break;
                case 4: // Material Group
                    ChkdListBx_MaterialGroup.Invoke((MethodInvoker)delegate {
                        ChkdListBx_MaterialGroup.Items.Clear();
                        ChkdListBx_MaterialGroup.Items.AddRange(data.ToArray());
                    });
                    break;
                case 5:// Vendor
                    ChkdListBx_Vendor.Invoke((MethodInvoker)delegate {
                        ChkdListBx_Vendor.Items.Clear();
                        ChkdListBx_Vendor.Items.AddRange(data.ToArray());
                    });
                    break;
                case 6: // Vendor Description
                    ChkdListBx_VendorDesc.Invoke((MethodInvoker)delegate {
                        ChkdListBx_VendorDesc.Items.Clear();
                        ChkdListBx_VendorDesc.Items.AddRange(data.ToArray());
                    });
                    break;
                case 7: // Purch Group
                    ChkdListBx_PurchGroup.Invoke((MethodInvoker)delegate {
                        ChkdListBx_PurchGroup.Items.Clear();
                        ChkdListBx_PurchGroup.Items.AddRange(data.ToArray());
                    });
                    break;
                case 8: // IR Supp Name
                    ChkdListBx_IRSuppName.Invoke((MethodInvoker)delegate {
                        ChkdListBx_IRSuppName.Items.Clear();
                        ChkdListBx_IRSuppName.Items.AddRange(data.ToArray());
                    });
                    break;
                case 9: // Fxd Supp Name
                    ChkdListBx_FxdSuppName.Invoke((MethodInvoker)delegate {
                        ChkdListBx_FxdSuppName.Items.Clear();
                        ChkdListBx_FxdSuppName.Items.AddRange(data.ToArray());
                    });
                    break;
                case 10: // Dsrd Supp Name
                    ChkdListBx_DsrdSuppName.Invoke((MethodInvoker)delegate {
                        ChkdListBx_DsrdSuppName.Items.Clear();
                        ChkdListBx_DsrdSuppName.Items.AddRange(data.ToArray());
                    });
                    break;
                case 11: // Commodity Category
                    ChkdListBx_CommodityCat.Invoke((MethodInvoker)delegate {
                        ChkdListBx_CommodityCat.Items.Clear();
                        ChkdListBx_CommodityCat.Items.AddRange(data.ToArray());
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
                    break;
                case 1:
                    break;
                case 2: // Material
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FitlerValues.material.Add(clb.Items[e.Index].ToString());
                        AddFilterSnapShot(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.Material);
                    }
                    else
                    {
                        Filters.FitlerValues.material.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.Material);
                        RevertFilterData(clb.Items[e.Index].ToString());
                    }
                    UpdateCheckedItems();
                    break;
                case 3: // Material Group
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FitlerValues.materialGroup.Add(clb.Items[e.Index].ToString());
                        AddFilterSnapShot(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.MaterialGroup);
                    }
                    else
                    {
                        Filters.FitlerValues.materialGroup.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.MaterialGroup);
                        RevertFilterData(clb.Items[e.Index].ToString());
                    }
                    UpdateCheckedItems();
                    break;
                case 4: // Vendor
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FitlerValues.vendor.Add(clb.Items[e.Index].ToString());
                        AddFilterSnapShot(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.Vendor);
                    }
                    else
                    {
                        Filters.FitlerValues.vendor.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.Vendor);
                        RevertFilterData(clb.Items[e.Index].ToString());
                    }
                    UpdateCheckedItems();
                    break;
                case 5: // Vendor Desc
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FitlerValues.vendorDesc.Add(clb.Items[e.Index].ToString());
                        AddFilterSnapShot(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.VendorDescription);
                    }
                    else
                    {
                        Filters.FitlerValues.vendorDesc.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.VendorDescription);
                        RevertFilterData(clb.Items[e.Index].ToString());
                    }
                    UpdateCheckedItems();
                    break;
                case 6: // Purch Group
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FitlerValues.purchGroup.Add(clb.Items[e.Index].ToString());
                        AddFilterSnapShot(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.PurchGroup);
                    }
                    else
                    {
                        Filters.FitlerValues.purchGroup.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.PurchGroup);
                        RevertFilterData(clb.Items[e.Index].ToString());
                    }
                    UpdateCheckedItems();
                    break;
                case 7: // IR Supp Name
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FitlerValues.irSuppName.Add(clb.Items[e.Index].ToString());
                        AddFilterSnapShot(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.IRSuppName);
                    }
                    else
                    {
                        Filters.FitlerValues.irSuppName.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.IRSuppName);
                        RevertFilterData(clb.Items[e.Index].ToString());
                    }
                    UpdateCheckedItems();
                    break;
                case 8: // Fxd Supp Name
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FitlerValues.fxdSuppName.Add(clb.Items[e.Index].ToString());
                        AddFilterSnapShot(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.FxdSuppName);
                    }
                    else
                    {
                        Filters.FitlerValues.fxdSuppName.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.FxdSuppName);
                        RevertFilterData(clb.Items[e.Index].ToString());
                    }
                    UpdateCheckedItems();
                    break;
                case 9: // Dsrd Supp Name
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FitlerValues.dsrdSuppName.Add(clb.Items[e.Index].ToString());
                        AddFilterSnapShot(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.DsrdSuppName);
                    }
                    else
                    {
                        Filters.FitlerValues.dsrdSuppName.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.DsrdSuppName);
                        RevertFilterData(clb.Items[e.Index].ToString());
                    }
                    UpdateCheckedItems();
                    break;
                case 10: // Commodity Category
                    if (e.NewValue == CheckState.Checked)
                    {
                        Filters.FitlerValues.commCategory.Add(clb.Items[e.Index].ToString());
                        AddFilterSnapShot(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.CommCat);
                    }
                    else
                    {
                        Filters.FitlerValues.commCategory.Remove(clb.Items[e.Index].ToString());
                        BuildQueryFilters();
                        FilterUtils.LoadFilters(filters, FilterUtils.Filters.CommCat);
                        RevertFilterData(clb.Items[e.Index].ToString());
                    }
                    UpdateCheckedItems();
                    break;
            }
        }






        /// <summary>
        /// This will take a snapshot of all the data in the all of the check list boxes
        /// so when the user unchecks a checkbox, they can be repopulated with the data 
        /// they had.
        /// </summary>
        /// <param name="key"></param>
        private void AddFilterSnapShot(string key)
        {
            List<string> temp;
            if (ChkdListBx_Material.Items.Count > 0)
            {
                temp = new List<string>();
                foreach (var item in ChkdListBx_Material.Items)
                {
                    temp.Add(item.ToString());
                }

                try
                {
                    Filters.ClbDictionaryValues.material.Add(key, temp);
                }
                catch(ArgumentException)
                {

                }
            }
            else
            {
                temp = new List<string>();
                try
                {
                    Filters.ClbDictionaryValues.material.Add(key, temp);
                }
                catch (ArgumentException)
                {

                }
            }


            if (ChkdListBx_MaterialGroup.Items.Count > 0)
            {
                temp = new List<string>();
                foreach (var item in ChkdListBx_MaterialGroup.Items)
                {
                    temp.Add(item.ToString());
                }

                try
                {
                    Filters.ClbDictionaryValues.materialGroup.Add(key, temp);
                }
                catch (ArgumentException)
                {

                }
            }
            else
            {
                temp = new List<string>();

                try
                {
                    Filters.ClbDictionaryValues.materialGroup.Add(key, temp);
                }
                catch (ArgumentException)
                {

                }
            }



            if (ChkdListBx_Vendor.Items.Count > 0)
            {
                temp = new List<string>();
                foreach (var item in ChkdListBx_Vendor.Items)
                {
                    temp.Add(item.ToString());
                }

                try
                {
                    Filters.ClbDictionaryValues.vendor.Add(key, temp);
                }
                catch (ArgumentException)
                {

                }
            }
            else
            {
                temp = new List<string>();

                try
                {
                    Filters.ClbDictionaryValues.vendor.Add(key, temp);
                }
                catch (ArgumentException)
                {

                }
            }



            if (ChkdListBx_VendorDesc.Items.Count > 0)
            {
                temp = new List<string>();
                foreach (var item in ChkdListBx_VendorDesc.Items)
                {
                    temp.Add(item.ToString());
                }

                try
                {
                    Filters.ClbDictionaryValues.vendorDesc.Add(key, temp);
                }
                catch (ArgumentException)
                {

                }
            }
            else
            {
                temp = new List<string>();

                try
                {
                    Filters.ClbDictionaryValues.vendorDesc.Add(key, temp);
                }
                catch (ArgumentException)
                {

                }
            }



            if (ChkdListBx_PurchGroup.Items.Count > 0)
            {
                temp = new List<string>();
                foreach (var item in ChkdListBx_PurchGroup.Items)
                {
                    temp.Add(item.ToString());
                }

                try
                {
                    Filters.ClbDictionaryValues.purchGroup.Add(key, temp);
                }
                catch (ArgumentException)
                {

                }
            }
            else
            {
                temp = new List<string>();
                try
                {
                    Filters.ClbDictionaryValues.purchGroup.Add(key, temp);
                }
                catch (ArgumentException)
                {

                }
            }



            if (ChkdListBx_IRSuppName.Items.Count > 0)
            {
                temp = new List<string>();
                foreach (var item in ChkdListBx_IRSuppName.Items)
                {
                    temp.Add(item.ToString());
                }


                try
                {
                    Filters.ClbDictionaryValues.irSuppName.Add(key, temp);
                }
                catch (ArgumentException)
                {

                }
            }
            else
            {
                temp = new List<string>();

                try
                {
                    Filters.ClbDictionaryValues.irSuppName.Add(key, temp);
                }
                catch (ArgumentException)
                {

                }
            }



            if (ChkdListBx_FxdSuppName.Items.Count > 0)
            {
                temp = new List<string>();
                foreach (var item in ChkdListBx_FxdSuppName.Items)
                {
                    temp.Add(item.ToString());
                }


                try
                {
                    Filters.ClbDictionaryValues.fxdSuppName.Add(key, temp);
                }
                catch (ArgumentException)
                {

                }
            }
            else
            {
                temp = new List<string>();

                try
                {
                    Filters.ClbDictionaryValues.fxdSuppName.Add(key, temp);
                }
                catch (ArgumentException)
                {

                }
            }



            if (ChkdListBx_DsrdSuppName.Items.Count > 0)
            {
                temp = new List<string>();
                foreach (var item in ChkdListBx_DsrdSuppName.Items)
                {
                    temp.Add(item.ToString());
                }

                try
                {
                    Filters.ClbDictionaryValues.dsrdSuppName.Add(key, temp);
                }
                catch (ArgumentException)
                {

                }
            }
            else
            {
                temp = new List<string>();

                try
                {
                    Filters.ClbDictionaryValues.dsrdSuppName.Add(key, temp);
                }
                catch (ArgumentException)
                {

                }
            }


            if (ChkdListBx_CommodityCat.Items.Count > 0)
            {
                temp = new List<string>();
                foreach (var item in ChkdListBx_CommodityCat.Items)
                {
                    temp.Add(item.ToString());
                }

                try
                {
                    Filters.ClbDictionaryValues.commCategory.Add(key, temp);
                }
                catch (ArgumentException)
                {

                }
            }
            else
            {
                temp = new List<string>();

                try
                {
                    Filters.ClbDictionaryValues.commCategory.Add(key, temp);
                }
                catch (ArgumentException)
                {

                }
            }
        }






        /// <summary>
        /// Reverts the states of the check list boxes back to what they were based
        /// on the checkbox that was clicked.
        /// </summary>
        private void RevertFilterData(string key)
        {
            List<string> temp;

            if(Filters.ClbDictionaryValues.material.Count > 0)
            {
                temp = Filters.ClbDictionaryValues.material[key];
                ChkdListBx_Material.Items.Clear();
                ChkdListBx_Material.Items.AddRange(temp.ToArray());
                Filters.ClbDictionaryValues.material.Remove(key);
            }


            if(Filters.ClbDictionaryValues.materialGroup.Count > 0)
            {
                temp = Filters.ClbDictionaryValues.materialGroup[key];
                ChkdListBx_MaterialGroup.Items.Clear();
                ChkdListBx_MaterialGroup.Items.AddRange(temp.ToArray());
                Filters.ClbDictionaryValues.materialGroup.Remove(key);
            }


            if(Filters.ClbDictionaryValues.vendor.Count > 0)
            {
                temp = Filters.ClbDictionaryValues.vendor[key];
                ChkdListBx_Vendor.Items.Clear();
                ChkdListBx_Vendor.Items.AddRange(temp.ToArray());
                Filters.ClbDictionaryValues.vendor.Remove(key);
            }


            if(Filters.ClbDictionaryValues.vendorDesc.Count > 0)
            {
                temp = Filters.ClbDictionaryValues.vendorDesc[key];
                ChkdListBx_VendorDesc.Items.Clear();
                ChkdListBx_VendorDesc.Items.AddRange(temp.ToArray());
                Filters.ClbDictionaryValues.vendorDesc.Remove(key);
            }


            if(Filters.ClbDictionaryValues.purchGroup.Count > 0)
            {
                temp = Filters.ClbDictionaryValues.purchGroup[key];
                ChkdListBx_PurchGroup.Items.Clear();
                ChkdListBx_PurchGroup.Items.AddRange(temp.ToArray());
                Filters.ClbDictionaryValues.purchGroup.Remove(key);
            }


            if(Filters.ClbDictionaryValues.irSuppName.Count > 0)
            {
                temp = Filters.ClbDictionaryValues.irSuppName[key];
                ChkdListBx_IRSuppName.Items.Clear();
                ChkdListBx_IRSuppName.Items.AddRange(temp.ToArray());
                Filters.ClbDictionaryValues.irSuppName.Remove(key);
            }


            if(Filters.ClbDictionaryValues.fxdSuppName.Count > 0)
            {
                temp = Filters.ClbDictionaryValues.fxdSuppName[key];
                ChkdListBx_FxdSuppName.Items.Clear();
                ChkdListBx_FxdSuppName.Items.AddRange(temp.ToArray());
                Filters.ClbDictionaryValues.fxdSuppName.Remove(key);
            }


            if(Filters.ClbDictionaryValues.dsrdSuppName.Count > 0)
            {
                temp = Filters.ClbDictionaryValues.dsrdSuppName[key];
                ChkdListBx_DsrdSuppName.Items.Clear();
                ChkdListBx_DsrdSuppName.Items.AddRange(temp.ToArray());
                Filters.ClbDictionaryValues.dsrdSuppName.Remove(key);
            }


            if(Filters.ClbDictionaryValues.commCategory.Count > 0)
            {
                temp = Filters.ClbDictionaryValues.commCategory[key];
                ChkdListBx_CommodityCat.Items.Clear();
                ChkdListBx_CommodityCat.Items.AddRange(temp.ToArray());
                Filters.ClbDictionaryValues.commCategory.Remove(key);
            }
        }






        /// <summary>
        /// Builds the query that consists of the filters that will load the data.
        /// </summary>
        private void BuildQueryFilters()
        {
            filters = string.Empty;
            if(Filters.FitlerValues.material.Count > 0)
            {
                for (int i = 0; i < Filters.FitlerValues.material.Count; ++i)
                {
                    if (i == 0)
                        filters += "(";
                    filters += Overall.SelectedCountry + ".[" + FilterFeeature.FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.Material] + "] = " + "'" + Filters.FitlerValues.material[i] + "'";
                    if (i != (Filters.FitlerValues.material.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            

            if(Filters.FitlerValues.materialGroup.Count > 0)
            {
                for (int i = 0; i < Filters.FitlerValues.materialGroup.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";


                    filters += Overall.SelectedCountry + ".[" + FilterFeeature.FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.MaterialGroup] + "] = " + "'" + Filters.FitlerValues.materialGroup[i] + "'";
                    if (i != (Filters.FitlerValues.materialGroup.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            

            if(Filters.FitlerValues.vendor.Count > 0)
            {
                for (int i = 0; i < Filters.FitlerValues.vendor.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    filters += Overall.SelectedCountry + ".[" + FilterFeeature.FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.Vendor] + "] = " + Filters.FitlerValues.vendor[i];
                    if (i != (Filters.FitlerValues.vendor.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            

            if(Filters.FitlerValues.vendorDesc.Count > 0)
            {
                for (int i = 0; i < Filters.FitlerValues.vendorDesc.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    filters += Overall.SelectedCountry + ".[" + FilterFeeature.FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.VendorDescription] + "] = " + "'" + Filters.FitlerValues.vendorDesc[i] + "'";
                    if (i != (Filters.FitlerValues.vendorDesc.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            

            if(Filters.FitlerValues.purchGroup.Count > 0)
            {
                for (int i = 0; i < Filters.FitlerValues.purchGroup.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    filters += Overall.SelectedCountry + ".[" + FilterFeeature.FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.PurchGroup] + "] = " + "'" + Filters.FitlerValues.purchGroup[i] + "'";
                    if (i != (Filters.FitlerValues.purchGroup.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            


            if(Filters.FitlerValues.irSuppName.Count > 0)
            {
                for (int i = 0; i < Filters.FitlerValues.irSuppName.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    filters += Overall.SelectedCountry + ".[" + FilterFeeature.FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.IRSuppName] + "] = " + "'" + Filters.FitlerValues.irSuppName[i] + "'";
                    if (i != (Filters.FitlerValues.irSuppName.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            


            if(Filters.FitlerValues.fxdSuppName.Count > 0)
            {
                for (int i = 0; i < Filters.FitlerValues.fxdSuppName.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    filters += Overall.SelectedCountry + ".[" + FilterFeeature.FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.FxdSuppName] + "] = " + "'" + Filters.FitlerValues.fxdSuppName[i] + "'";
                    if (i != (Filters.FitlerValues.fxdSuppName.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            


            if(Filters.FitlerValues.dsrdSuppName.Count > 0)
            {
                for (int i = 0; i < Filters.FitlerValues.dsrdSuppName.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";


                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    filters += Overall.SelectedCountry + ".[" + FilterFeeature.FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.DsrdSuppName] + "] = " + "'" + Filters.FitlerValues.dsrdSuppName[i] + "'";
                    if (i != (Filters.FitlerValues.dsrdSuppName.Count - 1))
                        filters += " OR ";
                    else
                        filters += ")";
                }
            }
            

            if(Filters.FitlerValues.commCategory.Count > 0)
            {
                for (int i = 0; i < Filters.FitlerValues.commCategory.Count; ++i)
                {
                    if (i == 0 && filters != string.Empty)
                        filters += " AND (";

                    if (i == 0 && filters == string.Empty)
                        filters += "(";

                    filters += Overall.SelectedCountry + ".[" + FilterFeeature.FilterUtils.filterCols[(int)FilterFeeature.FilterUtils.Filters.CommCat] + "] = " + "'" + Filters.FitlerValues.commCategory[i] + "'";
                    if (i != (Filters.FitlerValues.commCategory.Count - 1))
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
            int index;

            // Material
            if(Filters.FitlerValues.material.Count > 0)
            {
                ChkdListBx_Material.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FitlerValues.material)
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
            if (Filters.FitlerValues.materialGroup.Count > 0)
            {
                ChkdListBx_MaterialGroup.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FitlerValues.materialGroup)
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
            if (Filters.FitlerValues.vendor.Count > 0)
            {
                ChkdListBx_Vendor.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FitlerValues.vendor)
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
            if (Filters.FitlerValues.vendorDesc.Count > 0)
            {
                ChkdListBx_VendorDesc.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FitlerValues.vendorDesc)
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


            // Purch Group
            if (Filters.FitlerValues.purchGroup.Count > 0)
            {
                ChkdListBx_PurchGroup.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FitlerValues.purchGroup)
                {
                    index = ChkdListBx_PurchGroup.Items.IndexOf(str);
                    if (index >= 0)
                    {
                        if (!ChkdListBx_PurchGroup.GetItemChecked(index))
                            ChkdListBx_PurchGroup.SetItemChecked(index, true);
                    }
                }
                ChkdListBx_PurchGroup.ItemCheck += ckdListBox_ItemCheck;
            }


            // IR Supp Name
            if (Filters.FitlerValues.irSuppName.Count > 0)
            {
                ChkdListBx_IRSuppName.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FitlerValues.irSuppName)
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
            if (Filters.FitlerValues.fxdSuppName.Count > 0)
            {
                ChkdListBx_FxdSuppName.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FitlerValues.fxdSuppName)
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
            if (Filters.FitlerValues.dsrdSuppName.Count > 0)
            {
                ChkdListBx_DsrdSuppName.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FitlerValues.dsrdSuppName)
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


            // Dsrd Supp Name
            if (Filters.FitlerValues.commCategory.Count > 0)
            {
                ChkdListBx_CommodityCat.ItemCheck -= ckdListBox_ItemCheck;
                foreach (string str in Filters.FitlerValues.commCategory)
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
                foreach (int i in ChkdListBx_Material.CheckedIndices)
                {
                    ChkdListBx_Material.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_Material.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_Material.ItemCheck += ckdListBox_ItemCheck;

                }

                foreach (int i in ChkdListBx_MaterialGroup.CheckedIndices)
                {
                    ChkdListBx_MaterialGroup.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_MaterialGroup.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_MaterialGroup.ItemCheck += ckdListBox_ItemCheck;

                }

                foreach (int i in ChkdListBx_Vendor.CheckedIndices)
                {
                    ChkdListBx_Vendor.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_Vendor.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_Vendor.ItemCheck += ckdListBox_ItemCheck;
                }

                foreach (int i in ChkdListBx_VendorDesc.CheckedIndices)
                {
                    ChkdListBx_VendorDesc.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_VendorDesc.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_VendorDesc.ItemCheck += ckdListBox_ItemCheck;
                }

                foreach (int i in ChkdListBx_PurchGroup.CheckedIndices)
                {
                    ChkdListBx_PurchGroup.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_PurchGroup.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_PurchGroup.ItemCheck += ckdListBox_ItemCheck;
                }

                foreach (int i in ChkdListBx_IRSuppName.CheckedIndices)
                {
                    ChkdListBx_IRSuppName.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_IRSuppName.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_IRSuppName.ItemCheck += ckdListBox_ItemCheck;
                }

                foreach (int i in ChkdListBx_FxdSuppName.CheckedIndices)
                {
                    ChkdListBx_FxdSuppName.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_FxdSuppName.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_FxdSuppName.ItemCheck += ckdListBox_ItemCheck;
                }

                foreach (int i in ChkdListBx_DsrdSuppName.CheckedIndices)
                {
                    ChkdListBx_DsrdSuppName.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_DsrdSuppName.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_DsrdSuppName.ItemCheck += ckdListBox_ItemCheck;
                }

                foreach (int i in ChkdListBx_CommodityCat.CheckedIndices)
                {
                    ChkdListBx_CommodityCat.ItemCheck -= ckdListBox_ItemCheck;
                    ChkdListBx_CommodityCat.SetItemCheckState(i, CheckState.Unchecked);
                    ChkdListBx_CommodityCat.ItemCheck += ckdListBox_ItemCheck;
                }

                Filters.FitlerValues.Clear();
                Filters.ClbDictionaryValues.Clear();
                filters = string.Empty;
                FilterUtils.LoadFilters(filters);
            }

            UpdateFilterButtons();
        }




        private void GetCheckedColumnFilters()
        {
            Filters.FitlerValues.Clear();

            foreach (int i in ChkdListBx_Material.CheckedIndices)
            {
                Filters.FitlerValues.material.Add(ChkdListBx_Material.Items[i].ToString());
            }

            foreach (int i in ChkdListBx_MaterialGroup.CheckedIndices)
            {
                Filters.FitlerValues.materialGroup.Add(ChkdListBx_MaterialGroup.Items[i].ToString());
            }

            foreach (int i in ChkdListBx_Vendor.CheckedIndices)
            {
                Filters.FitlerValues.vendor.Add(ChkdListBx_Vendor.Items[i].ToString());
            }

            foreach (int i in ChkdListBx_VendorDesc.CheckedIndices)
            {
                Filters.FitlerValues.vendorDesc.Add(ChkdListBx_VendorDesc.Items[i].ToString());
            }

            foreach (int i in ChkdListBx_PurchGroup.CheckedIndices)
            {
                Filters.FitlerValues.purchGroup.Add(ChkdListBx_PurchGroup.Items[i].ToString());
            }

            foreach (int i in ChkdListBx_IRSuppName.CheckedIndices)
            {
                Filters.FitlerValues.irSuppName.Add(ChkdListBx_IRSuppName.Items[i].ToString());
            }

            foreach (int i in ChkdListBx_FxdSuppName.CheckedIndices)
            {
                Filters.FitlerValues.fxdSuppName.Add(ChkdListBx_FxdSuppName.Items[i].ToString());
            }

            foreach (int i in ChkdListBx_DsrdSuppName.CheckedIndices)
            {
                Filters.FitlerValues.dsrdSuppName.Add(ChkdListBx_DsrdSuppName.Items[i].ToString());
            }

            foreach (int i in ChkdListBx_CommodityCat.CheckedIndices)
            {
                Filters.FitlerValues.commCategory.Add(ChkdListBx_CommodityCat.Items[i].ToString());
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

            Filters.FilterByPrDateRange = false;
            Filters.FilterByPoDateRange = false;

            if (FilterByPrDate)
            {
                if (CheckDateRange(0))
                {
                    return;
                }
                else
                {
                    Filters.PrFromDate = dp_PRFromDate.Value;
                    Filters.PrToDate = dp_PRToDate.Value;
                    Filters.FilterByPrDateRange = true;
                }
            }


            if(FilterByPoDate)
            {
                if (CheckDateRange(2))
                {
                    return;
                }
                else
                {
                    Filters.PoFromDate = dp_POFromDate.Value;
                    Filters.PoToDate = dp_POToDate.Value;
                    Filters.FilterByPoDateRange = true;
                }
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




            overallData = new Overall();
            PRPO_DB_Utils.DataLoadProcessStarted = false;
            PRPO_DB_Utils.DataLoaded = false;
            PRPO_DB_Utils.CompletedDataLoads = 0;
            PRPO_DB_Utils.ScheduledDataLoads = 0;
            DataLoaderTimer.Start();
        }






        /// <summary>
        /// Clear the filters and set everything back to default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_clearFilters_Click(object sender, EventArgs e)
        {
            Filters.ClbDictionaryValues.Clear();
            Filters.FitlerValues.Clear();
            Filters.FilterQuery = string.Empty;
            Filters.SecondaryFilterQuery = string.Empty;

            Filters.FilterByPrDateRange = false;
            Filters.FilterByPoDateRange = false;
            FilterByPrDate = false;
            FilterByPoDate = false;
            chkBox_PrDateRange.Checked = false;
            chkBox_PoDateRange.Checked = false;

            ColumnFiltersApplied = false;
            DateFiltersApplied = false;
            overallData = new Overall();
            PRPO_DB_Utils.DataLoadProcessStarted = false;
            PRPO_DB_Utils.DataLoaded = false;
            PRPO_DB_Utils.CompletedDataLoads = 0;
            PRPO_DB_Utils.ScheduledDataLoads = 0;
            DataLoaderTimer.Start();
            UpdateFilterButtons();
        }






        /// <summary>
        /// If the user has applied filters against the data, this function will assign FiltersAdded to true.
        /// </summary>
        public void HasFiltersAdded()
        {
            ColumnFiltersAdded = false;
            DateFiltersAdded = false;

            // Check if the user enable the option to filter by PR or PO date range.
            if (FilterByPrDate || FilterByPoDate)
                DateFiltersAdded = true;

            // Check if the user selected any filters from the following check list boxes.
            if (Filters.FitlerValues.material.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FitlerValues.materialGroup.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FitlerValues.vendor.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FitlerValues.vendorDesc.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FitlerValues.purchGroup.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FitlerValues.irSuppName.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FitlerValues.fxdSuppName.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FitlerValues.dsrdSuppName.Count > 0) ColumnFiltersAdded = true;
            if (Filters.FitlerValues.commCategory.Count > 0) ColumnFiltersAdded = true;
        }







        /// <summary>
        /// 
        /// </summary>
        private void UpdateFilterButtons()
        {
            HasFiltersAdded();
            if(ColumnFiltersAdded || DateFiltersAdded)
            {
                btn_applyFilters.Enabled = true;
                btn_clearSelected.Enabled = true;
            }
            else
            {
                btn_applyFilters.Enabled = false;
                btn_clearSelected.Enabled = false;
            }


            if(ColumnFiltersApplied || DateFiltersApplied)
            {
                btn_clearFilters.Enabled = true;
            }
            else
            {
                btn_clearFilters.Enabled = false;
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
