using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

using ApplicationIOLibarary.ApplicationFiles;
using ApplicationIOLibarary.Interfaces;


namespace Filters.Variants
{
    public class FilterVariants : IStorable, ILoadable<FilterVariants>
    {
        private List<Variant> variants;


        /// <summary>
        /// JavaScript serializer used to serialize and deserializer ApplicationConfig objects
        /// </summary>
        private JavaScriptSerializer ser;
        private string dataJSONString;


        // Call-back functions to update variants tools.
        public delegate void UpdateVariantToolsHandler();
        public static event UpdateVariantToolsHandler UpdateVariantTools;




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
            ser = new JavaScriptSerializer();
        }




        /// <summary>
        /// Adds the variant to the list of fitler variants.
        /// </summary>
        /// <param name="_variant">The new variant added by the user.</param>
        /// <returns>boolean value indicating whether or not the Add operation for the variant was successful.</returns>
        public void AddVariant(Variant _variant)
        {
            // add the variant to the list of variants
            variants.Add(_variant);
            UpdateVariantTools();
        }




        /// <summary>
        /// Deavtivate the variants.
        /// </summary>
        public void DeactivateVariants()
        {
            foreach (Variant variant in variants)
                variant.Active = false;

            // Save the update variants
            Save();
        }




        /// <summary>
        /// Loads the filter variant from a JSON file.
        /// </summary>
        /// <returns></returns>
        public void Load(ref FilterVariants variants)
        {
            try
            {
                dataJSONString = File.ReadAllText(FileUtils.variantFiles[(int)VariantFile.FilterVariants]);
                variants = ser.Deserialize<FilterVariants>(dataJSONString);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter Variants File Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        /// <summary>
        /// Saves the filter variants to a JSON file.
        /// </summary>
        /// <returns>Boolean value indicating whether or not the save operation was successful.</returns>
        public void Save()
        {
            try
            {
                dataJSONString = ser.Serialize(this);
                File.WriteAllText(FileUtils.variantFiles[(int)VariantFile.FilterVariants], dataJSONString);   
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter Variants File Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}