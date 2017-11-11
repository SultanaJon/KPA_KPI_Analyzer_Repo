using KPA_KPI_Analyzer.Filter_Variant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.FilterFeeature
{
    public static class Filters
    {
        private static string filters = string.Empty;
        private static string secFilters = string.Empty;



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






        /// <summary> 
        /// Structure & Lists that hold the values of the currently selected filters.
        /// </summary>
        public struct FilterValues
        {
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




            /// <summary>
            /// Clear the contents of all the lists within FilterValues.
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
        }


        /// <summary>
        /// This function is used for filter variants to get the list of selected filters to store as a variant.
        /// </summary>
        /// <returns>A dictionary with a key of string and a value of list of strings. This object is stored within the saved variants.</returns>
        public static Dictionary<string, List<string>> GetSelectedFilters()
        {
            Dictionary<string, List<string>> selectedFilters = new Dictionary<string, List<string>>();
            string prDateRange = string.Format(PrFromDate.ToString() + " to " + PrToDate.ToString());
            string poDateRange = string.Format(PoFromDate.ToString() + " to " + PoFromDate.ToString());
            string finalRecDateRange = string.Format(FinalReceiptFromDate.ToString() + " to " + FinalReceiptToDate.ToString());

            // Get all of the unselected advanced filters
            List<string> advancedFilters = AdvancedFilters.GetSelectedAdvancedFilters();


            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PrDateRange], new List<string>() { prDateRange });
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PoLineCreateDateRange], new List<string>() { poDateRange });
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.FinalRecDateRange], new List<string>() { finalRecDateRange });
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.AdvancedFilters], advancedFilters);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.ProjectNumber], FilterValues.projectNumber);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.WbsElement], FilterValues.wbsElement);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.Material], FilterValues.material);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.MaterialGroup], FilterValues.materialGroup);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.Vendor], FilterValues.vendor);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.VendorDesciption], FilterValues.vendorDesc);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PrPurchGroup], FilterValues.purchGroup);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PoPurchGroup], FilterValues.poPurchGroup);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.IrSuppName], FilterValues.irSuppName);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.FxdSuppName], FilterValues.fxdSuppName);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.DsrdSuppName], FilterValues.dsrdSuppName);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.CommCategory], FilterValues.commCategory);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.Escaped], FilterValues.escaped);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.PoDocType], FilterValues.poDocumentType);
            selectedFilters.Add(FilterVariants.filterCategories[(int)FilterVariants.FilterCategory.ProdOrdMaterial], FilterValues.prodOrderMat);


            return selectedFilters;
        }
    }
}
