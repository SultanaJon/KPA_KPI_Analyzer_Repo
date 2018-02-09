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

            switch (_option)
            {
                case Options.ProjectNumber:
                    if (filter == "[Blanks]")
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.ProjectNUm_ProdOrdWbs] + "] IS NULL OR [" + FIlterColumns.filterColumns[(int)FilterColumn.ProjectNum_WBS_Element] + "] IS NULL";
                    else
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.ProjectNUm_ProdOrdWbs] + "] LIKE " + "'%" + filter + "%' OR [" + FIlterColumns.filterColumns[(int)FilterColumn.ProjectNum_WBS_Element] + "] LIKE '%" + filter + "%'";
                    break;
                case Options.WBSElement:
                    if (filter == "[Blanks]")
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.WBS_Element] + "] IS NULL";
                    else
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.WBS_Element] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.Material:
                    if (filter == "[Blanks]")
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.Material] + "] IS NULL";
                    else
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.Material] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.MaterialGroup:
                    if (filter == "[Blanks]")
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.MaterialGroup] + "] IS NULL";
                    else
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.MaterialGroup] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.Vendor:
                    if (filter == "[Blanks]")
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.Vendor] + "] IS NULL";
                    else
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.Vendor] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.VendorDescription:
                    if (filter == "[Blanks]")
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.VendorDescription] + "] IS NULL";
                    else
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.VendorDescription] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.PRPurchaseGroup:
                    if (filter == "[Blanks]")
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.PurchGroup] + "] IS NULL";
                    else
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.PurchGroup] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.POPurchaseGroup:
                    if (filter == "[Blanks]")
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.PoPurchGroup] + "] IS NULL";
                    else
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.PoPurchGroup] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.IRSuppName:
                    if (filter == "[Blanks]")
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.IRSuppName] + "] IS NULL";
                    else
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.IRSuppName] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.FxdSuppName:
                    if (filter == "[Blanks]")
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.FxdSuppName] + "] IS NULL";
                    else
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.FxdSuppName] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.DsrdSuppName:
                    if (filter == "[Blanks]")
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.DsrdSuppName] + "] IS NULL";
                    else
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.DsrdSuppName] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.CommodityCategory:
                    if (filter == "[Blanks]")
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.CommCat] + "] IS NULL";
                    else
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.CommCat] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.Escaped:
                    if (filter == "[Blanks]")
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.Escaped] + "] IS NULL";
                    else
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.Escaped] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.PODocumentType:
                    if (filter == "[Blanks]")
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.PoDocumentType] + "] IS NULL";
                    else
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.PoDocumentType] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.ProductionOrderMaterial:
                    if (filter == "[Blanks]")
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.ProdOrderMaterial] + "] IS NULL";
                    else
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.ProdOrderMaterial] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.StorageLocation:
                    if (filter == "[Blanks]")
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.StorageLocation] + "] IS NULL";
                    else
                        result = "[" + FIlterColumns.filterColumns[(int)FilterColumn.StorageLocation] + "] LIKE " + "'%" + filter + "%'";
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
