using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    public class FilterOptions
    {
        public string Name { get; set; }
        public Options Value { get; set; }


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
            DsrdSuppName,
            CommodityCategory,
            PODocumentType,
            ProductionOrderMaterial
        }



        private static List<string> options = new List<string>()
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
            "Production Order Material"
        };





        /// <summary>
        /// Get the list of filter options.
        /// </summary>
        /// <returns></returns>
        public List<FilterOptions> GetFilterOptions()
        {
            List<FilterOptions> tempOptions = new List<FilterOptions>();
            foreach (Options option in Enum.GetValues(typeof(Options)))
            {
                tempOptions.Add(new FilterOptions() { Name = options[(int)option], Value = option });
            }
            return tempOptions;
        }
    }
}
