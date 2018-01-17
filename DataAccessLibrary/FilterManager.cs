using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DataAccessLibrary
{
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
        /// Get the unique project numbers. This function will get both the project number and the WBS Element. This function will then clean them up by only gettings
        /// the unique project number contained in both fields.
        /// </summary>
        /// <returns></returns>
        public static HashSet<string> GetUniqueProjectNumber()
        {
            HashSet<string> strData = new HashSet<string>();

            try
            {
                OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                string cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)FilterColumn.ProjectNUm_ProdOrdWbs] + "] FROM " + DatabaseManager.TargetTable;

                OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[filterColumns[(int)FilterColumn.ProjectNUm_ProdOrdWbs]] == DBNull.Value)
                        {
                            strData.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            strData.Add(reader[filterColumns[(int)FilterColumn.ProjectNUm_ProdOrdWbs]].ToString());
                        }
                    }
                }





                cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)FilterColumn.ProjectNum_WBS_Element] + "] FROM " + DatabaseManager.TargetTable;

                cmd = new OleDbCommand(cmdString, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[filterColumns[(int)FilterColumn.ProjectNum_WBS_Element]] == DBNull.Value)
                        {
                            strData.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            strData.Add(reader[filterColumns[(int)FilterColumn.ProjectNum_WBS_Element]].ToString());
                        }
                    }
                }


                CleanUpProjectNumbers(ref strData);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
            }

            return strData;
        }









        /// <summary>
        /// Gets the unique WBS Element filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueWbsElement()
        {
            HashSet<string> strData = new HashSet<string>();

            try
            {
                OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                string cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)FilterColumn.ProjectNum_WBS_Element] + "] FROM " + DatabaseManager.TargetTable;

                OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[filterColumns[(int)FilterColumn.ProjectNum_WBS_Element]] == DBNull.Value)
                        {
                            strData.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            strData.Add(reader[filterColumns[(int)FilterColumn.ProjectNum_WBS_Element]].ToString());
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
            }

            return strData;
        }









        /// <summary>
        /// Gets the unique Material filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueMaterial()
        {
            HashSet<string> strData = new HashSet<string>();

            try
            {
                OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                string cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)FilterColumn.Material] + "] FROM " + DatabaseManager.TargetTable;


                OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[filterColumns[(int)FilterColumn.Material]] == DBNull.Value)
                        {
                            strData.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            strData.Add(reader[filterColumns[(int)FilterColumn.Material]].ToString());
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
            }

            return strData;
        }









        /// <summary>
        /// Gets the unique Unique Material Group filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueMaterialGroup()
        {
            HashSet<string> strData = new HashSet<string>();

            try
            {
                OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                string cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)FilterColumn.MaterialGroup] + "] FROM " + DatabaseManager.TargetTable;


                OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[filterColumns[(int)FilterColumn.MaterialGroup]] == DBNull.Value)
                        {
                            strData.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            strData.Add(reader[filterColumns[(int)FilterColumn.MaterialGroup]].ToString());
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
            }

            return strData;
        }









        /// <summary>
        /// Gets the unique Unique Vendor filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueVendor()
        {
            HashSet<string> strData = new HashSet<string>();

            try
            {
                OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                string cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)FilterColumn.Vendor] + "] FROM " + DatabaseManager.TargetTable;

                OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[filterColumns[(int)FilterColumn.Vendor]] == DBNull.Value)
                        {
                            strData.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            strData.Add(reader[filterColumns[(int)FilterColumn.Vendor]].ToString());
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
            }

            return strData;
        }









        /// <summary>
        /// Gets the unique Vendor Description filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueVendorDescription()
        {
            HashSet<string> strData = new HashSet<string>();

            try
            {
                OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                string cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)FilterColumn.VendorDescription] + "] FROM " + DatabaseManager.TargetTable;


                OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[filterColumns[(int)FilterColumn.VendorDescription]] == DBNull.Value)
                        {
                            strData.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            strData.Add(reader[filterColumns[(int)FilterColumn.VendorDescription]].ToString());
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
            }

            return strData;
        }









        /// <summary>
        /// Gets the unique PR Purchase Group filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniquePrPurchaseGroup()
        {
            HashSet<string> strData = new HashSet<string>();

            try
            {
                OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                string cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)FilterColumn.PurchGroup] + "] FROM " + DatabaseManager.TargetTable;


                OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[filterColumns[(int)FilterColumn.PurchGroup]] == DBNull.Value)
                        {
                            strData.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            strData.Add(reader[filterColumns[(int)FilterColumn.PurchGroup]].ToString());
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
            }

            return strData;
        }








        /// <summary>
        /// Gets the unique PO Purchase Group filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniquePoPurchaseGroup()
        {
            HashSet<string> strData = new HashSet<string>();

            try
            {
                OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                string cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)FilterColumn.PoPurchGroup] + "] FROM " + DatabaseManager.TargetTable;


                OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[filterColumns[(int)FilterColumn.PoPurchGroup]] == DBNull.Value)
                        {
                            strData.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            strData.Add(reader[filterColumns[(int)FilterColumn.PoPurchGroup]].ToString());
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
            }

            return strData;
        }









        /// <summary>
        /// Gets the IR Supplier Name filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueIrSuppName()
        {
            HashSet<string> strData = new HashSet<string>();

            try
            {
                OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                string cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)FilterColumn.IRSuppName] + "] FROM " + DatabaseManager.TargetTable;

                OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[filterColumns[(int)FilterColumn.IRSuppName]] == DBNull.Value)
                        {
                            strData.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            strData.Add(reader[filterColumns[(int)FilterColumn.IRSuppName]].ToString());
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
            }

            return strData;
        }









        /// <summary>
        /// Gets the unique Fixed Supplier Name filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueFxdSuppName()
        {
            HashSet<string> strData = new HashSet<string>();

            try
            {
                OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                string cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)FilterColumn.FxdSuppName] + "] FROM " + DatabaseManager.TargetTable;


                OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[filterColumns[(int)FilterColumn.FxdSuppName]] == DBNull.Value)
                        {
                            strData.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            strData.Add(reader[filterColumns[(int)FilterColumn.FxdSuppName]].ToString());
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
            }

            return strData;
        }









        /// <summary>
        /// Gets the unique Desired Supplier Name filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueDsrdSuppName()
        {
            HashSet<string> strData = new HashSet<string>();

            try
            {
                OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                string cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)FilterColumn.DsrdSuppName] + "] FROM " + DatabaseManager.TargetTable;

                OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[filterColumns[(int)FilterColumn.DsrdSuppName]] == DBNull.Value)
                        {
                            strData.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            strData.Add(reader[filterColumns[(int)FilterColumn.DsrdSuppName]].ToString());
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
            }

            return strData;
        }









        /// <summary>
        /// Gets the unique Commodity Category filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueCommodityCategory()
        {
            HashSet<string> strData = new HashSet<string>();

            try
            {
                OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                string cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)FilterColumn.CommCat] + "] FROM " + DatabaseManager.TargetTable;

                OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[filterColumns[(int)FilterColumn.CommCat]] == DBNull.Value)
                        {
                            strData.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            strData.Add(reader[filterColumns[(int)FilterColumn.CommCat]].ToString());
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
            }

            return strData;
        }









        /// <summary>
        /// Gets the unique Escaped filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueEscaped()
        {
            HashSet<string> strData = new HashSet<string>();

            try
            {
                OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                string cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)FilterColumn.Escaped] + "] FROM " + DatabaseManager.TargetTable;

                OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[filterColumns[(int)FilterColumn.Escaped]] == DBNull.Value)
                        {
                            strData.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            strData.Add(reader[filterColumns[(int)FilterColumn.Escaped]].ToString());
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
            }

            return strData;
        }









        /// <summary>
        /// Gets the unique PO Document type filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniquePoDocumentType()
        {
            HashSet<string> strData = new HashSet<string>();

            try
            {
                OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                string cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)FilterColumn.PoDocumentType] + "] FROM " + DatabaseManager.TargetTable;

                OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[filterColumns[(int)FilterColumn.PoDocumentType]] == DBNull.Value)
                        {
                            strData.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            strData.Add(reader[filterColumns[(int)FilterColumn.PoDocumentType]].ToString());
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
            }

            return strData;
        }









        /// <summary>
        /// Gets the unique production order material filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueProductionOrderMaterial()
        {
            HashSet<string> strData = new HashSet<string>();

            try
            {
                OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                string cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)FilterColumn.ProdOrderMaterial] + "] FROM " + DatabaseManager.TargetTable;

                OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[filterColumns[(int)FilterColumn.ProdOrderMaterial]] == DBNull.Value)
                        {
                            strData.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            strData.Add(reader[filterColumns[(int)FilterColumn.ProdOrderMaterial]].ToString());
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
            }

            return strData;
        }









        /// <summary>
        /// Gets the unique storage location filters.
        /// </summary>
        /// <returns>A HasSet<string> data type containing the filters</returns>
        public static HashSet<string> GetUniqueStorageLocation()
        {
            HashSet<string> strData = new HashSet<string>();


            try
            {
                // Get the database connection
                OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                string cmdString = "SELECT DISTINCT " + DatabaseManager.TargetTable + ".[" + filterColumns[(int)FilterColumn.StorageLocation] + "] FROM " + DatabaseManager.TargetTable;

                OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[filterColumns[(int)FilterColumn.StorageLocation]] == DBNull.Value)
                        {
                            strData.Add("[Blanks]");
                            continue;
                        }
                        else
                        {
                            strData.Add(reader[filterColumns[(int)FilterColumn.StorageLocation]].ToString());
                        }
                    }
                }
            }
            catch(InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception was thrown", "Get Unique Storage Locations", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return strData;
        }
    }
}
