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
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.WBS_Element] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.Material:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.Material] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.Material] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.MaterialGroup:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.MaterialGroup] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.MaterialGroup] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.Vendor:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.Vendor] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.Vendor] + "] = " + filter;
                    break;
                case Options.VendorDescription:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.VendorDescription] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.VendorDescription] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.PRPurchaseGroup:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.PurchGroup] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.PurchGroup] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.POPurchaseGroup:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.PoPurchGroup] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.PoPurchGroup] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.IRSuppName:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.IRSuppName] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.IRSuppName] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.FxdSuppName:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.FxdSuppName] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.FxdSuppName] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.DsrdSuppName:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.DsrdSuppName] + "]) IS NULL";
                    else
                    {
                        if (filter == "FESTO")
                        {
                            result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.DsrdSuppName] + "] LIKE " + "'%" + filter + "%'";
                        }
                        else
                        {
                            result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.DsrdSuppName] + "] LIKE " + "'%" + filter + "%'";
                        }
                    }
                    break;
                case Options.CommodityCategory:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.CommCat] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.CommCat] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.PODocumentType:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.PoDocumentType] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.PoDocumentType] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.ProductionOrderMaterial:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.ProdOrderMaterial] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.ProdOrderMaterial] + "] LIKE " + "'%" + filter + "%'";
                    break;
                case Options.StorageLocation:
                    if (filter == "[Blanks]")
                        result = "([" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.StorageLocation] + "]) IS NULL";
                    else
                        result = "[" + FilterManager.reportingFilterColumns[(int)ReportingFilterColumn.StorageLocation] + "] LIKE " + "'%" + filter + "%'";
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
