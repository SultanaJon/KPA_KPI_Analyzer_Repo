using Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Selective
{
    public static class SelectiveUtils
    {
        /// <summary>
        /// 
        /// </summary>
        public static bool SelectiveActive { get; set;}



        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="_filterOption"></param>
        /// <param name="_uniqueFilter"></param>
        /// <returns></returns>
        public static DataRow[] SelectiveCheck(DataTable dt, FilterOptions.Options _filterOption, string _uniqueFilter)
        {
            // expression string to use against the dataTable
            string expression = string.Empty;

            if (_uniqueFilter == "[Blanks]")
                return new DataRow[0];

            switch (_filterOption)
            {
                case FilterOptions.Options.ProjectNumber:
                    expression = "[Prd Ord WBS] LIKE '%" + _uniqueFilter + "%' AND [WBS Element] LIKE '%" + _uniqueFilter + "%'";
                    break;
                case FilterOptions.Options.WBSElement:
                    expression = "[WBS Element] = " + _uniqueFilter;
                    break;
                case FilterOptions.Options.Material:
                    expression = "[Material] = " + _uniqueFilter;
                    break;
                case FilterOptions.Options.MaterialGroup:
                    expression = "[Material Group] = " + _uniqueFilter;
                    break;
                case FilterOptions.Options.Vendor:
                    expression = "[Vendor] = " + _uniqueFilter;
                    break;
                case FilterOptions.Options.VendorDescription:
                    expression = "[Vendor Description] = " + _uniqueFilter;
                    break;
                case FilterOptions.Options.PRPurchaseGroup:
                    expression = "[PR Purchase Group] = " + _uniqueFilter;
                    break;
                case FilterOptions.Options.POPurchaseGroup:
                    expression = "[PO Purchase Group] = " + _uniqueFilter;
                    break;
                case FilterOptions.Options.IRSuppName:
                    expression = "[IR Supp Name] = " + _uniqueFilter;
                    break;
                case FilterOptions.Options.DsrdSuppName:
                    expression = "[Dsrd Supp Name] = " + _uniqueFilter;
                    break;
                case FilterOptions.Options.CommodityCategory:
                    expression = "[Commodity Category] = " + _uniqueFilter;
                    break;
                case FilterOptions.Options.PODocumentType:
                    expression = "[PO Document Type] = " + _uniqueFilter;
                    break;
                case FilterOptions.Options.ProductionOrderMaterial:
                    expression = "[Production Order Material] = " + _uniqueFilter;
                    break;
            }

            return dt.Select(expression);
        }
    }
}
