﻿using System;
using System.Collections.Generic;

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
            }
        }
    }
}
