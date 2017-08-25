using System.Collections.Generic;
using System;
namespace KPA_KPI_Analyzer.FilterFeeature
{
    public static class Filters
    {
        private static string filters = string.Empty;
        private static string secFilters = string.Empty;
        private static DateTime prFromDate = new DateTime();
        private static DateTime poFromDate = new DateTime();




        /// <summary>
        /// The filters that will be applied to the database when loading the data.
        /// </summary>
        public static string FilterQuery { get { return filters; } set { if (value == null) filters = ""; else filters = value; } }



        /// <summary>
        /// Boolean value indicating whether or not the user has applied a PR date range filter
        /// </summary>
        public static bool PrDateRangeFilterAdded { get; set; }





        /// <summary>
        /// Boolean value indicating whether or not the user has applied a PO date range filter
        /// </summary>
        public static bool PoDateRangeFilterAdded { get; set; }





        /// <summary>
        /// The PR from date to be applied to the fitlers.
        /// </summary>
        public static DateTime PrFromDate { get; set; }






        /// <summary>
        /// The PR to date to be applied to the filters.
        /// </summary>
        public static DateTime PrToDate { get; set; }






        /// <summary>
        /// The PO from date to be applied to the filters.
        /// </summary>
        public static DateTime PoFromDate { get; set; }






        /// <summary>
        /// The PO to date to be applied to the filters.
        /// </summary>
        public static DateTime PoToDate { get; set; }





        /// <summary>
        /// 
        /// </summary>
        public static string SecondaryFilterQuery { get { return secFilters; } set { if (value == null) secFilters = ""; else secFilters = value; } }






        /// <summary> 
        /// Structure & Lists that hold the values of the currently selected filters.
        /// </summary>
        public struct FitlerValues
        {
            public static List<string> wbsElmntPrdOrd = new List<string>();
            public static List<string> wbsProject = new List<string>();
            public static List<string> material = new List<string>();
            public static List<string> materialGroup = new List<string>();
            public static List<string> vendor = new List<string>();
            public static List<string> vendorDesc = new List<string>();
            public static List<string> purchGroup = new List<string>();
            public static List<string> irSuppName = new List<string>();
            public static List<string> fxdSuppName = new List<string>();
            public static List<string> dsrdSuppName = new List<string>();
            public static List<string> commCategory = new List<string>();






            /// <summary>
            /// Clear the contents of all the lists within FilterValues.
            /// </summary>
            public static void Clear()
            {
                wbsElmntPrdOrd.Clear();
                wbsProject.Clear();
                material.Clear();
                materialGroup.Clear();
                vendor.Clear();
                vendorDesc.Clear();
                purchGroup.Clear();
                irSuppName.Clear();
                fxdSuppName.Clear();
                dsrdSuppName.Clear();
                commCategory.Clear();
            }
        }






        /// <summary>
        /// structure to contain all the dictionary values of the filters.
        /// 
        /// Every dictionary will contain a value(string of the value checked in the check box) 
        /// and a list of distinct database column values.
        /// </summary>
        public struct ClbDictionaryValues
        {
            // The dictionaries that will contain the value check in the checkbox and the 
            // current database values based on those check values.
            public static Dictionary<string, List<string>> wbsElmnt_PrdOrdWbs = new Dictionary<string, List<string>>();
            public static Dictionary<string, List<string>> wbsProject = new Dictionary<string, List<string>>();
            public static Dictionary<string, List<string>> material = new Dictionary<string, List<string>>();
            public static Dictionary<string, List<string>> materialGroup = new Dictionary<string, List<string>>();
            public static Dictionary<string, List<string>> vendor = new Dictionary<string, List<string>>();
            public static Dictionary<string, List<string>> vendorDesc = new Dictionary<string, List<string>>();
            public static Dictionary<string, List<string>> purchGroup = new Dictionary<string, List<string>>();
            public static Dictionary<string, List<string>> irSuppName = new Dictionary<string, List<string>>();
            public static Dictionary<string, List<string>> fxdSuppName = new Dictionary<string, List<string>>();
            public static Dictionary<string, List<string>> dsrdSuppName = new Dictionary<string, List<string>>();
            public static Dictionary<string, List<string>> commCategory = new Dictionary<string, List<string>>();






            /// <summary>
            /// Clear the contents of all the dictionary values back to their default value.
            /// </summary>
            public static void Clear()
            {
                wbsElmnt_PrdOrdWbs.Clear();
                wbsProject.Clear();
                material.Clear();
                materialGroup.Clear();
                vendor.Clear();
                vendorDesc.Clear();
                purchGroup.Clear();
                irSuppName.Clear();
                fxdSuppName.Clear();
                dsrdSuppName.Clear();
                commCategory.Clear();
            }
        }
    }
}
