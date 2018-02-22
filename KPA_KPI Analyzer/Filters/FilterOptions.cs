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
            "Fxd Supp Name",
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
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.ProjectNUm_ProdOrdWbs] + "]) IS NULL AND ([" + FilterManager.reportingFilterColumns[(int)FilterColumn.ProjectNum_WBS_Element] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.ProjectNUm_ProdOrdWbs] + "] LIKE " + "'%" + filter + "%' OR [" + FilterManager.reportingFilterColumns[(int)FilterColumn.ProjectNum_WBS_Element] + "] LIKE '%" + filter + "%'";
                    break;
                case Options.WBSElement:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.WBS_Element] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.WBS_Element] + "]  = '" + filter + "'";
                    break;
                case Options.Material:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.Material] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.Material] + "]  = '" + filter + "'";
                    break;
                case Options.MaterialGroup:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.MaterialGroup] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.MaterialGroup] + "]  = '" + filter + "'";
                    break;
                case Options.Vendor:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.Vendor] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.Vendor] + "]  = '" + filter + "'";
                    break;
                case Options.VendorDescription:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.VendorDescription] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.VendorDescription] + "]  = '" + filter + "'";
                    break;
                case Options.PRPurchaseGroup:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.PurchGroup] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.PurchGroup] + "]  = '" + filter + "'";
                    break;
                case Options.POPurchaseGroup:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.PoPurchGroup] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.PoPurchGroup] + "]  = '" + filter + "'";
                    break;
                case Options.IRSuppName:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.IRSuppName] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.IRSuppName] + "]  = '" + filter + "'";
                    break;
                case Options.FxdSuppName:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.FxdSuppName] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.FxdSuppName] + "]  = '" + filter + "'";
                    break;
                case Options.DsrdSuppName:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.DsrdSuppName] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.DsrdSuppName] + "]  = '" + filter + "'";
                    break;
                case Options.CommodityCategory:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.CommCat] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.CommCat] + "]  = '" + filter + "'";
                    break;
                case Options.PODocumentType:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.PoDocumentType] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.PoDocumentType] + "]  = '" + filter + "'";
                    break;
                case Options.ProductionOrderMaterial:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.ProdOrderMaterial] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.ProdOrderMaterial] + "]  = '" + filter + "'";
                    break;
                case Options.StorageLocation:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.StorageLocation] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.StorageLocation] + "]  = '" + filter + "'";
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
