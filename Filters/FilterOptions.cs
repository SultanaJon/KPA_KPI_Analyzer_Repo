using System.Collections.Generic;

namespace Filters
{
    public static class FilterOptions
    {
        public enum Options
        {
            ProjectNumber,
            WBSElement,
            Material,
            MaterialGroup,
            Vendor,
            VendorDescription,
            PRPurchaseGroup,
            POPurchaseGroup,
            IRSuppName,
            FxdSuppName,
            DsrdSuppName,
            CommodityCategory,
            Escaped,
            PODocumentType,
            ProductionOrderMaterial,
            StorageLocation
        }



        public static List<string> options = new List<string>()
        {
            "Project Number",
            "WBS Element",
            "Material",
            "Material Group",
            "Vendor",
            "Vendor Description",
            "PR Purchase Group",
            "PO Purchase Group",
            "IR Supp Name",
            "Dsrd Supp Name",
            "Commodity Category",
            "PO Document Type",
            "Production Order Material",
            "Storage Location"
        };




        /// <summary>
        /// Returns the a seelct 
        /// </summary>
        /// <param name="_option"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static string GetColumnNames(Options _option, string filter)
        {
            string result = string.Empty;

            switch(_option)
            {
                case Options.ProjectNumber:
                    result = "[" + options[(int)_option] + "] = '" + filter + "' or [" + options[(int)_option] + "] = '" + filter + "'";
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
