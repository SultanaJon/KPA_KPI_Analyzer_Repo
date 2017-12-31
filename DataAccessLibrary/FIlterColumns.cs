namespace DataAccessLibrary
{
    public class FIlterColumns
    {
        /// <summary>
        /// The names of the columns that will be included in the category DatabaseManager.Filters.
        /// </summary>
        public enum FilterColumn : byte
        {
            ProjectNum_WBS_Element,
            ProjectNUm_ProdOrdWbs,
            WBS_Element,
            Material,
            MaterialGroup,
            Vendor,
            VendorDescription,
            PurchGroup,
            PoPurchGroup,
            IRSuppName,
            FxdSuppName,
            DsrdSuppName,
            CommCat,
            Escaped,
            PoDocumentType,
            ProdOrderMaterial
        }




        /// <summary>
        /// The names of the columns that store the data that will be used in the DatabaseManager.Filters.
        /// </summary>
        public static string[] filterColumns =
        {
            "WBS Element",
            "Prd Ord WBS",
            "WBS Element",
            "Material",
            "Material Group",
            "Vendor",
            "Vendor Description",
            "Purch# Group",
            "POPurcGroup",
            "IR Supp Name",
            "Fxd Supp Name",
            "Dsrd Supp Name",
            "Commodity category",
            "Escaped",
            "PO Doc# Type",
            "Prd Ord Mat"
        };
    }
}
