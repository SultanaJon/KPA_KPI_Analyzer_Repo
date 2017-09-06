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
        public static bool FiltersAdded { get; set; }






        /// <summary>
        /// boolean value indicating whether or not the user has applied the filters to the data.
        /// </summary>
        public static bool FiltersApplied { get; set; }








        /// <summary>
        /// Boolean valid indicating whether or not the PR date range is valid or not.
        /// </summary>
        public static bool ValidPrDateRange { get; set; }







        /// <summary>
        /// Boolean vlid indicating whether or not the PO date range is valid
        /// </summary>
        public static bool ValidPoDateRange { get; set; }






        /// <summary>
        /// This function will populate the checklist boxes with the new data after a load.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filter"></param>
        public void UpdateFilters(List<string> data, FilterUtils.Filters filter)
        {
            HasFiltersAdded();
            
            if(!FiltersAdded)
            {
                btn_applyFilters.Enabled = false;
                btn_clearFilters.Enabled = false;
                btn_clearSelected.Enabled = false;
            }
            else
            {
                btn_applyFilters.Enabled = true;
                btn_clearFilters.Enabled = true;
                btn_clearSelected.Enabled = true;
            }


            if(!FiltersApplied)
                btn_clearFilters.Enabled = false;
            else
                btn_clearFilters.Enabled = true;




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
            foreach(int i in ChkdListBx_Material.CheckedIndices)
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
            valueCounts.Clear();
            filters = string.Empty;
            FilterUtils.LoadFilters(filters);
        }






        /// <summary>
        /// Apply the filters and load the data again with the filters applied.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_applyFilters_Click(object sender, EventArgs e)
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


            BuildQueryFilters();
            HasFiltersAdded();
            if(FiltersAdded)
            {
                Filters.SecondaryFilterQuery = filters;
                filters = " AND " + filters;
                Filters.FilterQuery = filters;
                FiltersApplied = true;
            }
            else
            {
                filters = string.Empty;
                Filters.FilterQuery = filters;
                Filters.SecondaryFilterQuery = filters;
                FiltersApplied = false;
            }




            // Check if the user added a PR date range
            if(Filters.PrDateRangeFilterAdded)
            {
                Filters.PrFromDate = dp_PRFromDate.Value;
                Filters.PrToDate = dp_PRToDate.Value;
                FiltersApplied = true;
            }



            // Check if the user added a PO date range
            if(Filters.PoDateRangeFilterAdded)
            {
                Filters.PoFromDate = dp_POFromDate.Value;
                Filters.PoToDate = dp_POToDate.Value;
                FiltersApplied = true;
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
            Filters.PrDateRangeFilterAdded = false;
            Filters.PoDateRangeFilterAdded = false;
            valueCounts.Clear();

            HasFiltersAdded();
            if(!FiltersAdded)
            {
                FiltersApplied = false;
                overallData = new Overall();
                PRPO_DB_Utils.DataLoadProcessStarted = false;
                PRPO_DB_Utils.DataLoaded = false;
                PRPO_DB_Utils.CompletedDataLoads = 0;
                PRPO_DB_Utils.ScheduledDataLoads = 0;
                DataLoaderTimer.Start();
            }
            else
            {
                MessageBox.Show("Loading data with no filters but filters has filters applied.");
            }
        }






        /// <summary>
        /// If the user has applied filters against the data, this function will assign FiltersAdded to true.
        /// </summary>
        /// <returns></returns>
        public void HasFiltersAdded()
        {
            FiltersAdded = false;
            if (Filters.FitlerValues.material.Count > 0) FiltersAdded = true;
            if (Filters.FitlerValues.materialGroup.Count > 0) FiltersAdded = true;
            if (Filters.FitlerValues.vendor.Count > 0) FiltersAdded = true;
            if (Filters.FitlerValues.vendorDesc.Count > 0) FiltersAdded = true;
            if (Filters.FitlerValues.purchGroup.Count > 0) FiltersAdded = true;
            if (Filters.FitlerValues.irSuppName.Count > 0) FiltersAdded = true;
            if (Filters.FitlerValues.fxdSuppName.Count > 0) FiltersAdded = true;
            if (Filters.FitlerValues.dsrdSuppName.Count > 0) FiltersAdded = true;
            if (Filters.FitlerValues.commCategory.Count > 0) FiltersAdded = true;
        }





        /// <summary>
        /// Determines if the PR or PO date ranges are valid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dp_DateRangeChange(object sender, EventArgs e)
        {

            Bunifu.Framework.UI.BunifuDatepicker dp = (Bunifu.Framework.UI.BunifuDatepicker)sender;
            DateTime prFromDt = new DateTime();
            DateTime prToDt = new DateTime();
            DateTime poFromDt = new DateTime();
            DateTime poToDt = new DateTime();

            int tag = int.Parse(dp.Tag.ToString());

            switch (tag)
            {
                case 0:
                case 1:
                    if (prDateSwitch.Value == false) return;

                    prFromDt = dp_PRFromDate.Value;
                    prToDt = dp_PRToDate.Value;

                    if (DateTime.Compare(prFromDt, prToDt) == 1)
                    {
                        ValidPrDateRange = false;
                        MessageBox.Show("The PR date range is invalid. Please update before applying filters.", "Invalid PR Date Range", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Filters.PrDateRangeFilterAdded = false;
                    }
                    else
                    {
                        ValidPrDateRange = true;
                        Filters.PrDateRangeFilterAdded = true;
                    }
                    break;
                case 2:
                case 3:
                    if (poDateSwitch.Value == false) return;
                    poFromDt = dp_POFromDate.Value;
                    poToDt = dp_POToDate.Value;

                    if(DateTime.Compare(prFromDt, prToDt) == 1)
                    {
                        ValidPoDateRange = false;
                        MessageBox.Show("The PO date range is invalid. Please update before applying filters.", "Invalid PO Date Range", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Filters.PoDateRangeFilterAdded = false;
                    }
                    else
                    {
                        ValidPoDateRange = true;
                        Filters.PoDateRangeFilterAdded = true;
                    }
                    break;
                default:
                    break;
            }
        }





        /// <summary>
        /// Toggles on or off whether or not the user will like to apply a date range filters
        /// to both the PR date and the PO date.
        /// </summary>
        /// <param name="sender">The bunifu switch</param>
        /// <param name="e">The click event</param>
        private void switch_ValueChange(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuSwitch dateSwitch = (Bunifu.Framework.UI.BunifuSwitch)sender;
            int tag = int.Parse(dateSwitch.Tag.ToString());

            switch (tag)
            {
                case 0:
                    if(dateSwitch.Value == true)
                    {
                        Filters.PrDateRangeFilterAdded = true;
                        btn_applyFilters.Enabled = true;
                    }
                    else
                    {
                        Filters.PrDateRangeFilterAdded = false;
                    }
                    break;
                case 1:
                    if (dateSwitch.Value == true)
                    {
                        Filters.PoDateRangeFilterAdded = true;
                        btn_applyFilters.Enabled = true;

                    }
                    else
                    {
                        Filters.PoDateRangeFilterAdded = false;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
