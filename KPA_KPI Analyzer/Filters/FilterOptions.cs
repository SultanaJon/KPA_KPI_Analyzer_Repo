using DataAccessLibrary;
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

            //if (FilterData.ColumnFilters.projectNumber[i] == "[Blanks]")
            //    filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.ProjectNum_WBS_Element] + "] IS NULL OR " + DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.ProjectNUm_ProdOrdWbs] + "] IS NULL";
            //else
            //    filters += DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.ProjectNum_WBS_Element] + "] LIKE " + "'%" + FilterData.ColumnFilters.projectNumber[i] + "%' OR " + DatabaseManager.TargetTable + ".[" + FilterManager.filterColumns[(int)FilterColumn.ProjectNUm_ProdOrdWbs] + "] LIKE " + "'%" + FilterData.ColumnFilters.projectNumber[i] + "%'";

            switch (_option)
            {
                case Options.ProjectNumber:
                    if (filter == "[Blanks]")
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.ProjectNUm_ProdOrdWbs] + "] IS NULL OR [" + FIlterColumns.filterColumns[(int)FilterColumn.ProjectNum_WBS_Element] + "] IS NULL";
                    else
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.ProjectNUm_ProdOrdWbs] + "] LIKE " + "'%" + filter + "%' OR [" + FIlterColumns.filterColumns[(int)FilterColumn.ProjectNum_WBS_Element] + "] LIKE '%" + filter + "%'";
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
