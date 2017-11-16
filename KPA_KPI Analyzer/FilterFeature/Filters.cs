using KPA_KPI_Analyzer.Filter_Variant;
using System;
using System.Collections.Generic;





namespace KPA_KPI_Analyzer.FilterFeeature
{
    public static class Filters
    {
        #region FIELD DATA
        private static string filters = string.Empty;
        private static string secFilters = string.Empty;
        #endregion

        #region PROPERTIES
        /// <summary>
        /// The filters that will be applied to the database when loading the data.
        /// </summary>
        public static string FilterQuery
        {
            get { return filters; }
            set { if (value == null) filters = ""; else filters = value; }
        }






        /// <summary>
        /// 
        /// </summary>
        public static string SecondaryFilterQuery
        {
            get { return secFilters; }
            set { if (value == null) secFilters = ""; else secFilters = value; }
        }
        #endregion

        #region STRUCTURES
        /// <summary>
        /// Field data, properties, and methods that deal with advanced filters.
        /// </summary>
        public struct AdvancedFilters
        {
            #region FIELD DATA
            /// <summary>
            /// 
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
            /// 
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
            /// 
            /// </summary>
            public static bool FilterByServicePrPo { get; set; } = true;



            /// <summary>
            /// 
            /// </summary>
            public static bool FilterBySteelPrPo { get; set; } = true;



            /// <summary>
            /// 
            /// </summary>
            public static bool FilterByPouPrPo { get; set; } = true;



            /// <summary>
            /// 
            /// </summary>
            public static bool FilterByIntercompPo { get; set; } = true;



            /// <summary>
            /// 
            /// </summary>
            public static bool FilterByCodifiedMatNonSubcont { get; set; } = true;



            /// <summary>
            /// 
            /// </summary>
            public static bool FilterByCodifiedMatSubcont { get; set; } = true;


            /// <summary>
            /// 
            /// </summary>
            public static bool FilterByManualPr { get; set; } = true;
            #endregion

            #region HELPER FUNCTIONS
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
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
            /// 
            /// </summary>
            public static void ResetAdvanceFilters()
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
            /// 
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
            #endregion
        }




        /// <summary>
        /// Field data, properties, and methods that deal with column filters.
        /// </summary>
        public struct ColumnFilters
        {
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
            public static void Clear()
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
        }
        #endregion

        #region HELPER FUNCTIONS
        /// <summary>
        /// This function is used for filter variants to get the list of selected filters to store as a variant.
        /// </summary>
        /// <returns>A dictionary with a key of string and a value of list of strings. This object is stored within the saved variants.</returns>
        public static Dictionary<string, List<string>> GetSelectedFilters()
        {
            Dictionary<string, List<string>> selectedFilters = new Dictionary<string, List<string>>();
            string prDateRange = string.Empty;
            string poDateRange = string.Empty;
            string finalRecDateRange = string.Empty;


            if(DateFilters.FilterByPrDateRange)
                prDateRange = string.Format(DateFilters.PrFromDate.ToString() + " to " + DateFilters.PrToDate.ToString());

            if(DateFilters.FilterByPoDateRange)
                poDateRange = string.Format(DateFilters.PoFromDate.ToString() + " to " + DateFilters.PoFromDate.ToString());

            if(DateFilters.FilterByFinalReceiptDate)
                finalRecDateRange = string.Format(DateFilters.FinalReceiptFromDate.ToString() + " to " + DateFilters.FinalReceiptToDate.ToString());

            // Get all of the unselected advanced filters
            List<string> advancedFilters = AdvancedFilters.GetSelectedAdvancedFilters();


            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PrDateRange], new List<string>() { prDateRange });
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PoLineCreateDateRange], new List<string>() { poDateRange });
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.FinalRecDateRange], new List<string>() { finalRecDateRange });
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.AdvancedFilters], advancedFilters);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.ProjectNumber], ColumnFilters.projectNumber);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.WbsElement], ColumnFilters.wbsElement);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.Material], ColumnFilters.material);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.MaterialGroup], ColumnFilters.materialGroup);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.Vendor], ColumnFilters.vendor);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.VendorDesciption], ColumnFilters.vendorDesc);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PrPurchGroup], ColumnFilters.purchGroup);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PoPurchGroup], ColumnFilters.poPurchGroup);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.IrSuppName], ColumnFilters.irSuppName);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.FxdSuppName], ColumnFilters.fxdSuppName);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.DsrdSuppName], ColumnFilters.dsrdSuppName);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.CommCategory], ColumnFilters.commCategory);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.Escaped], ColumnFilters.escaped);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PoDocType], ColumnFilters.poDocumentType);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.ProdOrdMaterial], ColumnFilters.prodOrderMat);


            return selectedFilters;
        }




        /// <summary>
        /// Calibrates the filters based on the values that were saved in the users custom variant.
        /// </summary>
        /// <param name="variantDetails">the details(filters) of the saved variant.</param>
        public static void CalibrateFilters(Dictionary<string, List<string>> variantDetails)
        {

        }
        #endregion
    }
}
