using KPA_KPI_Analyzer.Variants;
using System;
using System.Collections.Generic;
using System.Windows.Forms;



namespace KPA_KPI_Analyzer.Filters
{
    public static class FilterData
    {
        #region FIELD DATA

        /// <summary>
        /// The string value used to query the data.
        /// </summary>
        public static string filters = string.Empty;

        /// <summary>
        /// The secondary string value used to query the data when the data query is wide open.
        /// </summary>
        public static string secFilters = string.Empty;

        #endregion


        #region PROPERTIES

        /// <summary>
        /// The filters that will be applied to the database when loading the data.
        /// </summary>
        public static string FilterQuery
        {
            get { return filters; }
            set { if (value == null) filters = string.Empty; else filters = value; }
        }


        /// <summary>
        /// This string is used when there are no filters applied and the data query is wide open.
        /// </summary>
        public static string SecondaryFilterQuery
        {
            get { return secFilters; }
            set { if (value == null) secFilters = string.Empty; else secFilters = value; }
        }

        #endregion


        #region FILTER STRUCTURES

        /// <summary>
        /// Field data, properties, and methods that deal with advanced filters.
        /// </summary>
        public struct AdvancedFilters
        {
            #region FIELD DATA

            /// <summary>
            /// Indexers used to get the name of the advanced filter.
            /// </summary>
            public enum AdvancedFilter
            {
                ServicePrPo,
                SteelPrPo,
                PouPrPo,
                IntercompanyPo,
                CodifiedMatNonSubCont,
                CodifiedMatSubCont,
                ManualPr
            }


            /// <summary>
            /// string array of advanced filter names.
            /// </summary>
            public static string[] advancedFilters =
            {
                "Service PR/PO",
                "Steel PR/PO",
                "POU PR/PO",
                "Intercompany PO",
                "Codified Material (Non-Subcontract)",
                "Codified Material (Subcontract)",
                "Manual PR"
            };

            #endregion


            #region PROPERTIES

            /// <summary>
            /// Boolean value to determine whether or not advanced filters have been added.
            /// </summary>
            public static bool Added { get; set; }


            /// <summary>
            /// Boolean value to determine whether or not the advanced filters have been applied.
            /// </summary>
            public static bool Applied { get; set; }


            /// <summary>
            /// Boolean value indicating whether or not the user is excluding Service POs
            /// </summary>
            public static bool FilterByServicePrPo { get; set; } = true;


            /// <summary>
            /// Boolean value indicating whether or not the user is excluding Steel PR and POs
            /// </summary>
            public static bool FilterBySteelPrPo { get; set; } = true;


            /// <summary>
            /// Boolean value indicating whether or not the user is excluding Pou PR PO.
            /// </summary>
            public static bool FilterByPouPrPo { get; set; } = true;


            /// <summary>
            /// Boolean value indicating whether or not the user is excluding Inter Company PO
            /// </summary>
            public static bool FilterByIntercompPo { get; set; } = true;


            /// <summary>
            /// Boolean value indicating whether or not the user is excluding Codified Material Non Sub Contract
            /// </summary>
            public static bool FilterByCodifiedMatNonSubcont { get; set; } = true;


            /// <summary>
            /// Boolean value indicating whether or not the user is excluding Codified Material Sub Contract.
            /// </summary>
            public static bool FilterByCodifiedMatSubcont { get; set; } = true;


            /// <summary>
            /// Boolean value indicating whether or not the user is excluding manual prs
            /// </summary>
            public static bool FilterByManualPr { get; set; } = true;

            #endregion


            #region HELPER FUNCTIONS

            /// <summary>
            /// Checks to see if the advanced filters have been changed.
            /// </summary>
            /// <returns>A boolean value.</returns>
            public static bool AdvanceFiltersChanged()
            {
                if (FilterByServicePrPo &&
                    FilterBySteelPrPo &&
                    FilterByPouPrPo &&
                    FilterByIntercompPo &&
                    FilterByCodifiedMatNonSubcont &&
                    FilterByCodifiedMatSubcont &&
                    FilterByManualPr)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }





            /// <summary>
            /// Resets the advanced filter back to their default state.
            /// </summary>
            public static void Reset()
            {
                FilterByServicePrPo = true;
                FilterBySteelPrPo = true;
                FilterByPouPrPo = true;
                FilterByIntercompPo = true;
                FilterByCodifiedMatNonSubcont = true;
                FilterByCodifiedMatSubcont = true;
                FilterByManualPr = true;
            }



            /// <summary>
            /// Finds all of the selected advanced fitlers that the user does not want included in the data.
            /// </summary>
            /// <returns>The selected advanced filters</returns>
            public static List<string> GetSelectedAdvancedFilters()
            {
                List<string> temp = new List<string>();
                if (!FilterByServicePrPo) temp.Add(advancedFilters[(int)AdvancedFilter.ServicePrPo]);
                if (!FilterBySteelPrPo) temp.Add(advancedFilters[(int)AdvancedFilter.SteelPrPo]);
                if (!FilterByPouPrPo) temp.Add(advancedFilters[(int)AdvancedFilter.PouPrPo]);
                if (!FilterByIntercompPo) temp.Add(advancedFilters[(int)AdvancedFilter.IntercompanyPo]);
                if (!FilterByCodifiedMatNonSubcont) temp.Add(advancedFilters[(int)AdvancedFilter.CodifiedMatNonSubCont]);
                if (!FilterByCodifiedMatSubcont) temp.Add(advancedFilters[(int)AdvancedFilter.CodifiedMatSubCont]);
                if (!FilterByManualPr) temp.Add(advancedFilters[(int)AdvancedFilter.ManualPr]);

                return temp;
            }



            /// <summary>
            /// Calibrates the advance filters.
            /// </summary>
            /// <param name="category"></param>
            public static void CalibrateAdvancedFilters(List<string> advFilterDetails)
            {
                foreach(string filter in advFilterDetails)
                {
                    if(filter == advancedFilters[(int)AdvancedFilter.ServicePrPo])
                    {
                        FilterByServicePrPo = false;
                    }
                    else if(filter == advancedFilters[(int)AdvancedFilter.SteelPrPo])
                    {
                        FilterBySteelPrPo = false;
                    }
                    else if (filter == advancedFilters[(int)AdvancedFilter.PouPrPo])
                    {
                        FilterByPouPrPo = false;
                    }
                    else if (filter == advancedFilters[(int)AdvancedFilter.IntercompanyPo])
                    {
                        FilterByIntercompPo = false;
                    }
                    else if (filter == advancedFilters[(int)AdvancedFilter.CodifiedMatNonSubCont])
                    {
                        FilterByCodifiedMatNonSubcont = false;
                    }
                    else if (filter == advancedFilters[(int)AdvancedFilter.CodifiedMatSubCont])
                    {
                        FilterByCodifiedMatSubcont = false;
                    }
                    else if (filter == advancedFilters[(int)AdvancedFilter.ManualPr])
                    {
                        FilterByManualPr = false;
                    }
                }
            }

            #endregion
        }




        /// <summary>
        /// Field data, properties, and methods that deal with column filters.
        /// </summary>
        public struct ColumnFilters
        {
            #region PROPERTIES

            /// <summary>
            /// Boolean value to determine whether or not advanced filters have been added.
            /// </summary>
            public static bool Added { get; set; }


            /// <summary>
            /// Boolean value to determine whether or not the advanced filters have been applied.
            /// </summary>
            public static bool Applied { get; set; }

            #endregion  


            #region FIELD DATA

            public static List<string> projectNumber = new List<string>();
            public static List<string> wbsElement = new List<string>();
            public static List<string> material = new List<string>();
            public static List<string> materialGroup = new List<string>();
            public static List<string> vendor = new List<string>();
            public static List<string> vendorDesc = new List<string>();
            public static List<string> purchGroup = new List<string>();
            public static List<string> poPurchGroup = new List<string>();
            public static List<string> irSuppName = new List<string>();
            public static List<string> fxdSuppName = new List<string>();
            public static List<string> dsrdSuppName = new List<string>();
            public static List<string> commCategory = new List<string>();
            public static List<string> escaped = new List<string>();
            public static List<string> poDocumentType = new List<string>();
            public static List<string> prodOrderMat = new List<string>();

            #endregion


            #region HELPER FUNCTIONS

            /// <summary>
            /// Clear the contents of all the lists within ColumnFilters.
            /// </summary>
            public static void Reset()
            {
                projectNumber.Clear();
                wbsElement.Clear();
                material.Clear();
                materialGroup.Clear();
                vendor.Clear();
                vendorDesc.Clear();
                purchGroup.Clear();
                poPurchGroup.Clear();
                irSuppName.Clear();
                fxdSuppName.Clear();
                dsrdSuppName.Clear();
                commCategory.Clear();
                escaped.Clear();
                poDocumentType.Clear();
                prodOrderMat.Clear();
            }

            #endregion
        }




        /// <summary>
        /// Field data, properties, and methods that deal with date filters.
        /// </summary>
        public struct DateFilters
        {
            #region PROPERTIES

            /// <summary>
            /// Boolean value to determine whether or not advanced filters have been added.
            /// </summary>
            public static bool Added { get; set; }


            /// <summary>
            /// Boolean value to determine whether or not the advanced filters have been applied.
            /// </summary>
            public static bool Applied { get; set; }


            /// <summary>
            /// Boolean value indicating whether or not the user wants to filter by PR date range
            /// </summary>
            public static bool FilterByPrDateRange { get; set; }


            /// <summary>
            /// Boolean value indicating whether or not the user wants to filter by PO date range
            /// </summary>
            public static bool FilterByPoDateRange { get; set; }


            /// <summary>
            /// Boolean value indicating whether or not the user wants to filter by PO date range
            /// </summary>
            public static bool FilterByFinalReceiptDate { get; set; }


            /// <summary>
            /// When PR Date range filter is applied this will be the PR from date.
            /// </summary>
            public static DateTime PrFromDate { get; set; }


            /// <summary>
            /// When PR Date range filter is applied this will be the PR to date.
            /// </summary>
            public static DateTime PrToDate { get; set; }


            /// <summary>
            /// When the PO date range filter is applied this will be the PO from date
            /// </summary>
            public static DateTime PoFromDate { get; set; }


            /// <summary>
            /// When the PO date range filter is applied this will be the PO to date.
            /// </summary>
            public static DateTime PoToDate { get; set; }


            /// <summary>
            /// When the Final Receipt Date range filter is applie this will be the Final Recipt from date.
            /// </summary>
            public static DateTime FinalReceiptFromDate { get; set; }


            /// <summary>
            /// When the Final Receipt Date range filter is applie this will be the Final Recipt to date.
            /// </summary>
            public static DateTime FinalReceiptToDate { get; set; }
            #endregion


            #region HELPER FUNCTIONS

            /// <summary>
            ///  Resets the date filter setting so that the program does not filter by dates.
            /// </summary>
            public static void Reset()
            {
                FilterByPrDateRange = false;
                FilterByPoDateRange = false;
                FilterByFinalReceiptDate = false;
            }


            /// <summary>
            /// Calibrates the date filters
            /// </summary>
            /// <param name="prDateRange">The PR Date Range</param>
            /// <param name="poDateRange">The PO Date Range</param>
            /// <param name="finRecDateRange">The Final Receipt Date Range</param>
             public static void CalibrateDateRanges(string prDateRange, string poDateRange, string finRecDateRange)
            {
                try
                {
                    if (prDateRange != string.Empty)
                    {
                        string[] prDtSplitRange = prDateRange.Split(' ');
                        PrFromDate = DateTime.Parse(prDtSplitRange[0]);
                        PrToDate = DateTime.Parse(prDtSplitRange[2]);
                        FilterByPrDateRange = true;
                    }
                    else
                    {
                        FilterByPrDateRange = false;
                    }

                    if (poDateRange != string.Empty)
                    {
                        string[] poDtSplitRange = poDateRange.Split(' ');
                        PoFromDate = DateTime.Parse(poDtSplitRange[0]);
                        PrToDate = DateTime.Parse(poDtSplitRange[2]);
                        FilterByPoDateRange = true;
                    }
                    else
                    {
                        FilterByPoDateRange = false;
                    }

                    if (finRecDateRange != string.Empty)
                    {
                        string[] finRecDtSplitRange = finRecDateRange.Split(' ');
                        FinalReceiptFromDate = DateTime.Parse(finRecDtSplitRange[0]);
                        FinalReceiptToDate = DateTime.Parse(finRecDtSplitRange[2]);
                        FilterByFinalReceiptDate = true;
                    }
                    else
                    {
                        FilterByFinalReceiptDate = false;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Filters string to date Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            #endregion
        }

        #endregion


        #region HELPER FUNCTIONS

        /// <summary>
        /// Resets the filter settings
        /// </summary>
        public static void ResetFilters()
        {
            // Clear any active filter queries
            filters = string.Empty;
            secFilters = string.Empty;

            // Reset the advance filters
            AdvancedFilters.Reset();

            // Reset the column filters
            ColumnFilters.Reset();

            // Reset the date filters
            DateFilters.Reset();
        }



        /// <summary>
        /// This function is used for filter variants to get the list of selected filters to store as a variant.
        /// </summary>
        /// <returns>A dictionary with a key of string and a value of list of strings. This object is stored within the saved variants.</returns>
        public static Dictionary<string, List<string>> GetSelectedFilters()
        {
            Dictionary<string, List<string>> selectedFilters = new Dictionary<string, List<string>>();

            string dateFormat = "{0:d}";
            string prDateRange = string.Empty;
            string poDateRange = string.Empty;
            string finalRecDateRange = string.Empty;


            if(DateFilters.FilterByPrDateRange)
                prDateRange = string.Format(dateFormat, DateFilters.PrFromDate) + " to " + string.Format(dateFormat, DateFilters.PrToDate);

            if(DateFilters.FilterByPoDateRange)
                poDateRange = string.Format(dateFormat, DateFilters.PoFromDate) + " to " + string.Format(dateFormat, DateFilters.PoToDate);

            if (DateFilters.FilterByFinalReceiptDate)
                finalRecDateRange = string.Format(dateFormat, DateFilters.FinalReceiptFromDate) + " to " + string.Format(dateFormat, DateFilters.FinalReceiptToDate);


            // Get all of the unselected advanced filters
            List<string> advancedFilters = AdvancedFilters.GetSelectedAdvancedFilters();

            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PrDateRange], new List<string>() { prDateRange });
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PoLineCreateDateRange], new List<string>() { poDateRange });
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.FinalRecDateRange], new List<string>() { finalRecDateRange });
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.AdvancedFilters], advancedFilters);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.ProjectNumber], new List<string>(ColumnFilters.projectNumber));
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.WbsElement], new List<string>(ColumnFilters.wbsElement));
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.Material], new List<string>(ColumnFilters.material));
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.MaterialGroup], new List<string>(ColumnFilters.materialGroup));
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.Vendor], new List<string>(ColumnFilters.vendor));
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.VendorDesciption], new List<string>(ColumnFilters.vendorDesc));
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PrPurchGroup], new List<string>(ColumnFilters.purchGroup));
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PoPurchGroup], new List<string>(ColumnFilters.poPurchGroup));
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.IrSuppName], new List<string>(ColumnFilters.irSuppName));
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.FxdSuppName], new List<string>(ColumnFilters.fxdSuppName));
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.DsrdSuppName], new List<string>(ColumnFilters.dsrdSuppName));
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.CommCategory], new List<string>(ColumnFilters.commCategory));
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.Escaped], new List<string>(ColumnFilters.escaped));
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PoDocType], new List<string>(ColumnFilters.poDocumentType));
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.ProdOrdMaterial], new List<string>(ColumnFilters.prodOrderMat));

            return selectedFilters;
        }




        /// <summary>
        /// Calibrates the filters based on the values that were saved in the users custom variant.
        /// </summary>
        /// <param name="variantDetails">the details(filters) of the saved variant.</param>
        public static void CalibrateFilters(Dictionary<string, List<string>> variantDetails)
        {
            string prDateRange = variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PrDateRange]][0];
            string poDateRange = variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PoLineCreateDateRange]][0];
            string finalRecDateRange = variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.FinalRecDateRange]][0];

            DateFilters.CalibrateDateRanges(prDateRange, poDateRange, finalRecDateRange);

            // Calibrate the advanced filters.
            AdvancedFilters.CalibrateAdvancedFilters(variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.AdvancedFilters]]);

            // Add the column filters.
            ColumnFilters.projectNumber = new List<string>(variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.ProjectNumber]]);
            ColumnFilters.wbsElement = new List<string>(variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.WbsElement]]);
            ColumnFilters.material = new List<string>(variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.Material]]);
            ColumnFilters.materialGroup = new List<string>(variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.MaterialGroup]]);
            ColumnFilters.vendor = new List<string>(variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.Vendor]]);
            ColumnFilters.vendorDesc = new List<string>(variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.VendorDesciption]]);
            ColumnFilters.purchGroup = new List<string>(variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PrPurchGroup]]);
            ColumnFilters.poPurchGroup = new List<string>(variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PoPurchGroup]]);
            ColumnFilters.irSuppName = new List<string>(variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.IrSuppName]]);
            ColumnFilters.fxdSuppName = new List<string>(variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.FxdSuppName]]);
            ColumnFilters.dsrdSuppName = new List<string>(variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.DsrdSuppName]]);
            ColumnFilters.commCategory = new List<string>(variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.CommCategory]]);
            ColumnFilters.escaped = new List<string>(variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.Escaped]]);
            ColumnFilters.poDocumentType = new List<string>(variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PoDocType]]);
            ColumnFilters.prodOrderMat = new List<string>(variantDetails[FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.ProdOrdMaterial]]);
        }

        #endregion
    }
}