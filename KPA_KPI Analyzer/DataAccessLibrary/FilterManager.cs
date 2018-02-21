using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DataAccessLibrary
{
    public enum ReportingFilterColumn : byte
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
        PoDocumentType,
        ProdOrderMaterial,
        StorageLocation
    }


    /// <summary>
    /// The names of the columns that will be included in the category filters.
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
        ProdOrderMaterial,
        StorageLocation
    }


    

    public static class FilterManager
    {
        /// <summary>
        /// The names of the columns that store the data that will be used in the filters.
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
            "Prd Ord Mat",
            "Stor# Location"
        };


        public static string[] reportingFilterColumns =
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
            "PO Doc# Type",
            "Prd Ord Mat",
            "Stor# Location"
        };









        /// <summary>
        /// When the Loading Filters for the "Project Number" Checked List Box, both the WBS Element and Prod Ord. WBS fields need to be
        /// combined which is performed in the LoadFilters function. The peropose of this function is to take loop through each record,
        /// remove any value that contains an underscore and talk the first part of any remaining value within the hashtable
        /// and get the first part of that value before the first occurence of '-'. This will leave us with the project number where we
        /// then store it into the hashtable where duplicates are not created.
        /// </summary>
        private static void CleanUpProjectNumbers(ref HashSet<string> strData)
        {
            HashSet<string> tempHash = new HashSet<string>();
            foreach (var str in strData)
            {
                if (str.Contains("_"))
                {
                    continue;
                }
                else
                {
                    string[] tempStrArray = str.Split('-');

                    // Get the project number only
                    tempHash.Add(tempStrArray[0]);
                }
            }

            strData = tempHash;
            tempHash = null;
        }







        /// <summary>
        /// Makes a call to the database getting the unique filters based on the command string supplied
        /// </summary>
        /// <param name="_cmdString">The unique command string used to request the filters</param>
        /// <returns>returns the result (unique filters)</returns>
        private static void GetFilterData(ref HashSet<string> _uniqueFilters, FilterColumn _column)
        {
            try
            {
                // Create a command string based on the filter column supplied.
                string cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)_column] + "] FROM " + DatabaseManager.TargetTable;

                // Get the connection to the database
                OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                // Create a new SQL Statement
                OleDbCommand cmd = new OleDbCommand(cmdString, conn);


                // Read each result returned from the SQL Statement
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // If the cell in the database is blank, mark is as [Blanks] like excel
                        if (reader[filterColumns[(int)_column]] == DBNull.Value)
                        {
                            _uniqueFilters.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            // Add the unique filter to the list of filters.
                            _uniqueFilters.Add(reader[filterColumns[(int)_column]].ToString());
                        }
                    }
                }
            }
            catch(InvalidOperationException)
            {
                MessageBox.Show("An invalid operation exception was thrown", "Unique Filter Request", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Close the application
                Application.Exit();
            }
        }









        /// <summary>
        /// Get the unique project numbers. This function will get both the project number and the WBS Element. This function will then clean them up by only gettings
        /// the unique project number contained in both fields.
        /// </summary>
        /// <returns></returns>
        public static HashSet<string> GetUniqueProjectNumber()
        {
            HashSet<string> uniqueFitlerData = new HashSet<string>();

            // Get the unique filters from the WBS Project Number
            GetFilterData(ref uniqueFitlerData, FilterColumn.ProjectNUm_ProdOrdWbs);

            // Get the unique filters from the WBS Element Column
            GetFilterData(ref uniqueFitlerData, FilterColumn.ProjectNum_WBS_Element);

            // Clean up the two sets of data and create one list of unique filters for project number
            CleanUpProjectNumbers(ref uniqueFitlerData);

            // Return the unique filters gathered to the caller
            return uniqueFitlerData;
        }









        /// <summary>
        /// Gets the unique WBS Element filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueWbsElement()
        {
            HashSet<string> uniqueFilterData = new HashSet<string>();

            // Get the unique filters from the WBS Element column
            GetFilterData(ref uniqueFilterData, FilterColumn.ProjectNum_WBS_Element);

            // Return the unique filters gathered to the caller
            return uniqueFilterData;
        }









        /// <summary>
        /// Gets the unique Material filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueMaterial()
        {
            HashSet<string> uniqueFilterData = new HashSet<string>();

            // Get the unique filters from the material column
            GetFilterData(ref uniqueFilterData, FilterColumn.Material);

            // Return the unique filters gathered to the caller
            return uniqueFilterData;
        }









        /// <summary>
        /// Gets the unique Unique Material Group filters.
        /// </summary>
        /// <returns>A HashSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueMaterialGroup()
        {
            HashSet<string> uniqueFilterData = new HashSet<string>();

            // Get the unique filters from the material group column
            GetFilterData(ref uniqueFilterData, FilterColumn.MaterialGroup);

            // Return the unique filters gathered to the caller
            return uniqueFilterData;
        }









        /// <summary>
        /// Gets the unique Unique Vendor filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueVendor()
        {
            HashSet<string> uniqueFilterData = new HashSet<string>();

            // Get the unique filters from the vendor column
            GetFilterData(ref uniqueFilterData, FilterColumn.Vendor);

            // Return the unique filters gathered to the caller
            return uniqueFilterData;
        }









        /// <summary>
        /// Gets the unique Vendor Description filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueVendorDescription()
        {
            HashSet<string> uniqueFilterData = new HashSet<string>();

            // Get the unique filters from the vendor description column
            GetFilterData(ref uniqueFilterData, FilterColumn.VendorDescription);

            // Return the unique filters gathered to the caller
            return uniqueFilterData;
        }









        /// <summary>
        /// Gets the unique PR Purchase Group filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniquePrPurchaseGroup()
        {
            HashSet<string> uniqueFilterData = new HashSet<string>();

            // Get the unique filters from the vendor PR Purchase Group column
            GetFilterData(ref uniqueFilterData, FilterColumn.PurchGroup);

            // Return the unique filters gathered to the caller
            return uniqueFilterData;
        }








        /// <summary>
        /// Gets the unique PO Purchase Group filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniquePoPurchaseGroup()
        {
            HashSet<string> uniqueFilterData = new HashSet<string>();

            // Get the unique filters from the vendor PO Purchase Group column
            GetFilterData(ref uniqueFilterData, FilterColumn.PoPurchGroup);

            // Return the unique filters gathered to the caller
            return uniqueFilterData;
        }









        /// <summary>
        /// Gets the IR Supplier Name filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueIrSuppName()
        {
            HashSet<string> uniqueFilterData = new HashSet<string>();

            // Get the unique filters from the vendor IR Supplier Name column
            GetFilterData(ref uniqueFilterData, FilterColumn.IRSuppName);

            // Return the unique filters gathered to the caller
            return uniqueFilterData;
        }









        /// <summary>
        /// Gets the unique Fixed Supplier Name filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueFxdSuppName()
        {
            HashSet<string> uniqueFilterData = new HashSet<string>();

            // Get the unique filters from the vendor FX Supplier Name column
            GetFilterData(ref uniqueFilterData, FilterColumn.FxdSuppName);

            // Return the unique filters gathered to the caller
            return uniqueFilterData;
        }









        /// <summary>
        /// Gets the unique Desired Supplier Name filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueDsrdSuppName()
        {
            HashSet<string> uniqueFilterData = new HashSet<string>();

            // Get the unique filters from the vendor Desired Supplier Name column
            GetFilterData(ref uniqueFilterData, FilterColumn.DsrdSuppName);

            // Return the unique filters gathered to the caller
            return uniqueFilterData;
        }









        /// <summary>
        /// Gets the unique Commodity Category filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueCommodityCategory()
        {
            HashSet<string> uniqueFilterData = new HashSet<string>();

            // Get the unique filters from the Commodity Category column
            GetFilterData(ref uniqueFilterData, FilterColumn.CommCat);

            // Return the unique filters gathered to the caller
            return uniqueFilterData;
        }









        /// <summary>
        /// Gets the unique Escaped filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueEscaped()
        {
            HashSet<string> uniqueFilterData = new HashSet<string>();

            // Get the unique filters from the Escaped column
            GetFilterData(ref uniqueFilterData, FilterColumn.Escaped);

            // Return the unique filters gathered to the caller
            return uniqueFilterData;
        }









        /// <summary>
        /// Gets the unique PO Document type filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniquePoDocumentType()
        {
            HashSet<string> uniqueFilterData = new HashSet<string>();

            // Get the unique filters from the PO Document column
            GetFilterData(ref uniqueFilterData, FilterColumn.PoDocumentType);

            // Return the unique filters gathered to the caller
            return uniqueFilterData;
        }









        /// <summary>
        /// Gets the unique production order material filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueProductionOrderMaterial()
        {
            HashSet<string> uniqueFilterData = new HashSet<string>();

            // Get the unique filters from the Production Order Material column
            GetFilterData(ref uniqueFilterData, FilterColumn.ProdOrderMaterial);

            // Return the unique filters gathered to the caller
            return uniqueFilterData;
        }









        /// <summary>
        /// Gets the unique storage location filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueStorageLocation()
        {
            HashSet<string> uniqueFilterData = new HashSet<string>();

            // Get the unique filters from the Storage Location column
            GetFilterData(ref uniqueFilterData, FilterColumn.StorageLocation);

            // Return the unique filters gathered to the caller
            return uniqueFilterData;
        }
    }
}
