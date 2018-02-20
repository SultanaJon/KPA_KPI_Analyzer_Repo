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
        public static string GetSelectStatement(Options _option, string filter)
        {
            string result = string.Empty;

            switch (_option)
            {
                case Options.ProjectNumber:
                    if (filter == "[Blanks]")
                        result = "ISNULL([" + FilterColumns.filterColumns[(int)FilterColumn.ProjectNUm_ProdOrdWbs] + "], '') = '' AND ISNULL([" + FilterColumns.filterColumns[(int)FilterColumn.ProjectNum_WBS_Element] + "], '') = ''";
                    else
                        result = "[" + FilterColumns.filterColumns[(int)FilterColumn.ProjectNUm_ProdOrdWbs] + "] LIKE " + "'%" + filter + "%' OR [" + FilterColumns.filterColumns[(int)FilterColumn.ProjectNum_WBS_Element] + "] LIKE '%" + filter + "%'";
                    break;
                case Options.WBSElement:
                    if (filter == "[Blanks]")
                        result = "ISNULL([" + FilterColumns.filterColumns[(int)FilterColumn.WBS_Element] + "], '') = ''";

                    else
                        result = "[" + FilterColumns.filterColumns[(int)FilterColumn.WBS_Element] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.Material:
                    if (filter == "[Blanks]")
                        result = "ISNULL([" + FilterColumns.filterColumns[(int)FilterColumn.Material] + "], '') = ''";
                    else
                        result = "[" + FilterColumns.filterColumns[(int)FilterColumn.Material] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.MaterialGroup:
                    if (filter == "[Blanks]")
                        result = "ISNULL([" + FilterColumns.filterColumns[(int)FilterColumn.MaterialGroup] + "], '') = ''";
                    else
                        result = "[" + FilterColumns.filterColumns[(int)FilterColumn.MaterialGroup] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.Vendor:
                    if (filter == "[Blanks]")
                        result = "ISNULL([" + FilterColumns.filterColumns[(int)FilterColumn.Vendor] + "], '') = ''";
                    else
                        result = "[" + FilterColumns.filterColumns[(int)FilterColumn.Vendor] + "] = " + filter;
                    break;
                case Options.VendorDescription:
                    if (filter == "[Blanks]")
                        result = "ISNULL([" + FilterColumns.filterColumns[(int)FilterColumn.VendorDescription] + "], '') = ''";
                    else
                        result = "[" + FilterColumns.filterColumns[(int)FilterColumn.VendorDescription] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.PRPurchaseGroup:
                    if (filter == "[Blanks]")
                        result = "ISNULL([" + FilterColumns.filterColumns[(int)FilterColumn.PurchGroup] + "], '') = ''";
                    else
                        result = "[" + FilterColumns.filterColumns[(int)FilterColumn.PurchGroup] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.POPurchaseGroup:
                    if (filter == "[Blanks]")
                        result = "ISNULL([" + FilterColumns.filterColumns[(int)FilterColumn.PoPurchGroup] + "], '') = ''";
                    else
                        result = "[" + FilterColumns.filterColumns[(int)FilterColumn.PoPurchGroup] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.IRSuppName:
                    if (filter == "[Blanks]")
                        result = "ISNULL([" + FilterColumns.filterColumns[(int)FilterColumn.IRSuppName] + "], '') = ''";
                    else
                        result = "[" + FilterColumns.filterColumns[(int)FilterColumn.IRSuppName] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.FxdSuppName:
                    if (filter == "[Blanks]")
                        result = "ISNULL([" + FilterColumns.filterColumns[(int)FilterColumn.FxdSuppName] + "], '') = ''";
                    else
                        result = "[" + FilterColumns.filterColumns[(int)FilterColumn.FxdSuppName] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.DsrdSuppName:
                    if (filter == "[Blanks]")
                        result = "ISNULL([" + FilterColumns.filterColumns[(int)FilterColumn.DsrdSuppName] + "], '') = ''";
                    else
                        result = "[" + FilterColumns.filterColumns[(int)FilterColumn.DsrdSuppName] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.CommodityCategory:
                    if (filter == "[Blanks]")
                        result = "ISNULL([" + FilterColumns.filterColumns[(int)FilterColumn.CommCat] + "], '') = ''";
                    else
                        result = "[" + FilterColumns.filterColumns[(int)FilterColumn.CommCat] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.Escaped:
                    if (filter == "[Blanks]")
                        result = "ISNULL([" + FilterColumns.filterColumns[(int)FilterColumn.Escaped] + "], '') = ''";
                    else
                        result = "[" + FilterColumns.filterColumns[(int)FilterColumn.Escaped] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.PODocumentType:
                    if (filter == "[Blanks]")
                        result = "ISNULL([" + FilterColumns.filterColumns[(int)FilterColumn.PoDocumentType] + "], '') = ''";
                    else
                        result = "[" + FilterColumns.filterColumns[(int)FilterColumn.PoDocumentType] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.ProductionOrderMaterial:
                    if (filter == "[Blanks]")
                        result = "ISNULL([" + FilterColumns.filterColumns[(int)FilterColumn.ProdOrderMaterial] + "], '') = ''";
                    else
                        result = "[" + FilterColumns.filterColumns[(int)FilterColumn.ProdOrderMaterial] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.StorageLocation:
                    if (filter == "[Blanks]")
                        result = "ISNULL([" + FilterColumns.filterColumns[(int)FilterColumn.StorageLocation] + "], '') = ''";
                    else
                        result = "[" + FilterColumns.filterColumns[(int)FilterColumn.StorageLocation] + "] LIKE " + "'%" + filter + "%'";
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
