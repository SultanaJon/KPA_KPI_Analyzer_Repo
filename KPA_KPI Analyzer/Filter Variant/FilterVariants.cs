﻿using KPA_KPI_Analyzer.Diagnostics;
using System.Collections.Generic;

namespace KPA_KPI_Analyzer.Filter_Variant
{
    public class FilterVariants : Storable<FilterVariants>, Loadable<FilterVariants>
    {
        // Call-back functions to update variants tools.
        public delegate void UpdateVariantToolsHandler();
        public static event UpdateVariantToolsHandler UpdateVariantTools;



        private List<Variant> variants;



        /// <summary>
        /// Property to easily get and set variants to the list of variants applied by the user.
        /// </summary>
        public List<Variant> Variants
        {
            get { return variants; }
            set
            {
                variants = value;
            }
        }




        /// <summary>
        /// Indexers for the names of the fitler categories.
        /// </summary>
        public enum FilterCategory
        {
            PrDateRange,
            PoLineCreateDateRange,
            FinalRecDateRange,
            AdvancedFilters,
            ProjectNumber,
            WbsElement,
            Material,
            MaterialGroup,
            Vendor,
            VendorDesciption,
            PrPurchGroup,
            PoPurchGroup,
            IrSuppName,
            FxdSuppName,
            DsrdSuppName,
            CommCategory,
            Escaped,
            PoDocType,
            ProdOrdMaterial
        }






        /// <summary>
        /// The names of the filter categories.
        /// </summary>
        public static string[] filterCategories =
        {
            "PR Date Range",
            "PO Line Creation Date Range",
            "Final Receipt Date Range",
            "Advanced Filters",
            "Project Number",
            "WBS Element",
            "Material",
            "Material Group",
            "Vendor",
            "Vendor Description",
            "PR Purch Group",
            "PO Purchase Group",
            "IR Supp Name",
            "Fxd Supp Name",
            "Dsrd Supp Name",
            "Commodity Category",
            "Escaped",
            "PO Document Type",
            "Production Order Material"
        };




        /// <summary>
        /// Default Constructor
        /// </summary>
        public FilterVariants()
        {
            variants = new List<Variant>();
        }





        /// <summary>
        /// Adds the variant to the list of fitler variants.
        /// </summary>
        /// <param name="_variant">The new variant added by the user.</param>
        /// <returns></returns>
        public void AddVariant(Variant _variant)
        {
            // add the variant to the list of variants
            variants.Add(_variant);
            UpdateVariantTools();
        }






        /// <summary>
        /// Loads the Fitler Variants from a JSON file.
        bool Loadable<FilterVariants>.Load(FilterVariants obj)
        {
            return false;
        }





        /// <summary>
        /// Saves the Filter Variants to a JSON file.
        /// </summary>
        bool Storable<FilterVariants>.Save(FilterVariants obj)
        {
            return false;
        }
    }
}