using KPA_KPI_Analyzer.Values;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.FilterFeeature
{
    public static class FilterUtils
    {
        private static HashSet<string> strData;
        public static string query = string.Empty;



        /// <summary>
        /// Callback function and event used to update the checklist boxes on the filter page.
        /// </summary>
        public delegate void UpdateFilterHandler(HashSet<string> data, Filters filter);
        public static event UpdateFilterHandler UpdateFilter;



        /// <summary>
        /// Data used to updated the progress of the filter load process.
        /// </summary>
        public static bool FilterLoadProcessStarted { get; set; }
        public static bool FiltersLoaded { get; set; }
        public static int NumThreadsStarted { get; set; }
        public static int NumThreadCompleted { get; set; }



        /// <summary>
        /// The names of the columns that will be included in the category filters.
        /// </summary>
        public enum Filters : byte
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
        /// The names of the columns that store the data that will be used in the filters.
        /// </summary>
        public static string[] filterCols =
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




        /// <summary>
        /// Returns the query that will be used to get the unique data contained within the columns of the PRPO report
        /// </summary>
        /// <param name="col"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        private static void getQuery(Filters col, string filters)
        {
            string temp;
            string column = filterCols[(int)col];

            if (filters == string.Empty)
            {
                temp = "SELECT DISTINCT " + Database.QueryManager.GetDatabaseTableName() + ".[" + column + "] FROM " + Database.QueryManager.GetDatabaseTableName();
            }
            else
            {
                temp = "SELECT DISTINCT " + Database.QueryManager.GetDatabaseTableName() + ".[" + column + "] FROM " + Database.QueryManager.GetDatabaseTableName() + " WHERE " + filters;
            }
            query = temp;
        }





        /// <summary>
        /// When the Loading Filters for the "Project Number" Checked List Box, both the WBS Element and Prod Ord. WBS fields need to be
        /// combined which is performed in the LoadFilters function. The peropose of this function is to take loop through each record,
        /// remove any value that contains an underscore and talk the first part of any remaining value within the hashtable
        /// and get the first part of that value before the first occurence of '-'. This will leave us with the project number where we
        /// then store it into the hashtable where duplicates are not created.
        /// </summary>
        private static void CleanUpProjectNumbers()
        {
            HashSet<string> tempHash = new HashSet<string>();
            foreach(var str in strData)
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
            GC.Collect(); 
        }





        /// <summary>
        /// Loads the unique filters into the application.
        /// </summary>
        /// <param name="filters">the current filters loaded.</param>
        public static void LoadFilters(string filters)
        {
            OleDbCommand cmd = new OleDbCommand();
            strData = new HashSet<string>();
            try
            {
                foreach (Filters col in Enum.GetValues(typeof(Filters)))
                {
                    getQuery(col, filters);
                    cmd = new OleDbCommand(query, Database.DatabaseUtils.DatabaseConnection);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader[filterCols[(int)col]] == DBNull.Value)
                            {
                                strData.Add("[Blanks]");
                                continue;
                            }
                            else
                            {
                                strData.Add(reader[filterCols[(int)col]].ToString());
                            }
                        }

                        // We want to continue to add Prod Ord WBS element to the already added WBS elements to create the project numbers
                        if (col == Filters.ProjectNum_WBS_Element) continue;


                        // Now that we have combined all unique values from WBS Element and Prod Ord. WBS fields, we want to clean them up before storing them
                        // in the Checked list views.
                        if (col == Filters.ProjectNUm_ProdOrdWbs)
                            CleanUpProjectNumbers();


                        MethodInvoker del = delegate
                        {
                            UpdateFilter(strData, col);
                        };
                        del.Invoke();
                    }
                    strData.Clear();
                }
                FiltersLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Filter Utils - Load Filters Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                strData.Clear();
                strData = null;
                GC.Collect();
            }
        }






        /// <summary>
        /// Returns whether or no the PO Line Creation date is within the data row is
        /// </summary>
        /// <param name="dr">The data row we are usin to get the data for this specific PR or PO line.</param>
        /// <returns>Returns a boolean indicating whether or no the PO line creation date is within the spcified filter dates</returns>
        public static bool PoCreateDateInRange(string createDate, string qtyOrdered)
        {
            // The user wnats to filter by PO date range
            string[] strPoLineCreateDate = createDate.Split('/');
            int poYear = int.Parse(strPoLineCreateDate[2]);
            int poMonth = int.Parse(strPoLineCreateDate[0]);
            int poDay = int.Parse(strPoLineCreateDate[1]);

            if (poYear == 0 && poMonth == 0 && poDay == 0)
            {
                // This record is not a PO so we dont care about it
                return false;
            }
            else
            {
                // This record shows as a PO but was it removed from the PO?
                if (qtyOrdered == "0")
                    return false;
                else
                {
                    poYear = int.Parse(strPoLineCreateDate[2]);
                    poMonth = int.Parse(strPoLineCreateDate[0].TrimStart('0'));
                    poDay = int.Parse(strPoLineCreateDate[1].TrimStart('0'));
                }
            }

            DateTime poTestDate = new DateTime(poYear, poMonth, poDay);

            if (poTestDate < FilterFeeature.Filters.DateFilters.PoFromDate || poTestDate > FilterFeeature.Filters.DateFilters.PoToDate)
            {
                // The PO date is not within the PO date range.
                return false;
            }
            return true;
        }




        /// <summary>
        /// Returns whether or no the Requisition date within the data row is
        /// </summary>
        /// <param name="dr">The data row we are usin to get the data for this specific PR or PO line.</param>
        /// <returns>Returns a boolean indicating whether or no the Requisition date is within the specified filter dates.</returns>
        public static bool PrDateInRange(string date)
        {
            // The user wants to filter by PR date range
            string[] requisnDate = date.Split('/');
            int reqYear = int.Parse(requisnDate[2]);
            int reqMonth = int.Parse(requisnDate[0].TrimStart('0'));
            int reqDay = int.Parse(requisnDate[1].TrimStart('0'));
            DateTime reqTestDate = new DateTime(reqYear, reqMonth, reqDay);

            if (reqTestDate < FilterFeeature.Filters.DateFilters.PrFromDate || reqTestDate > FilterFeeature.Filters.DateFilters.PrToDate)
            {
                // The PR date is not within the PR date range.
                return false;
            }

            return true;
        }



        /// <summary>
        /// Returns whether or no the PO Line Creation date is within the data row is
        /// </summary>
        /// <param name="dr">The data row we are usin to get the data for this specific PR or PO line.</param>
        /// <returns>Returns a boolean indicating whether or no the PO line creation date is within the spcified filter dates</returns>
        public static bool FinalReceiptDateInRange(string finalReceiptDate)
        {
            string[] strFinalRecDate = finalReceiptDate.Split('/');
            int finRecYear = int.Parse(strFinalRecDate[2]);
            int finRecMonth = int.Parse(strFinalRecDate[0]);
            int finRecDay = int.Parse(strFinalRecDate[1]);

            if (finRecYear == 0 && finRecMonth == 0 && finRecDay == 0)
            {
                // This record does not have a final receipt date
                return false;
            }
            else
            {
                finRecYear = int.Parse(strFinalRecDate[2]);
                finRecMonth = int.Parse(strFinalRecDate[0].TrimStart('0'));
                finRecDay = int.Parse(strFinalRecDate[1].TrimStart('0'));
            }

            DateTime finalRecDate = new DateTime(finRecYear, finRecMonth, finRecDay);

            if (finalRecDate < FilterFeeature.Filters.DateFilters.FinalReceiptFromDate || finalRecDate > FilterFeeature.Filters.DateFilters.FinalReceiptToDate)
            {
                // This records final receipt date is not within the filters final receipt date range.
                return false;
            }
            return true;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        public static bool CheckAdvancedFilters(DataRow dr)
        {
            if(!FilterFeeature.Filters.AdvancedFilters.FilterByServicePrPo)
            {
                string temp = dr["PR ItemCat1"].ToString();
                if(temp != string.Empty)
                {
                    if (int.Parse(temp) == Constants.ServicePOCategory)
                    {
                        return false;
                    }
                }                
            }


            if (!FilterFeeature.Filters.AdvancedFilters.FilterBySteelPrPo)
            {
                string material = dr["Material"].ToString();
                if (material.Contains("TAL-ST"))
                {
                    return false;
                }
            }


            if (!FilterFeeature.Filters.AdvancedFilters.FilterByPouPrPo)
            {
                string docType = dr["Document Type"].ToString();
                if (docType.Contains("POU"))
                {
                    return false;
                }
            }


            if (!FilterFeeature.Filters.AdvancedFilters.FilterByIntercompPo)
            {
                string vendorDesc = dr["Vendor Description"].ToString();
                if (vendorDesc.Contains("COMAU"))
                {
                    return false;
                }
            }


            if (!FilterFeeature.Filters.AdvancedFilters.FilterByCodifiedMatNonSubcont)
            {
                if (dr["Material"].ToString() != string.Empty)
                {
                    return false;
                }
            }


            if (!FilterFeeature.Filters.AdvancedFilters.FilterByCodifiedMatSubcont)
            {
                if (dr["Prd Ord Mat"].ToString() != string.Empty)
                {
                    return false;
                }
            }


            if (!FilterFeeature.Filters.AdvancedFilters.FilterByManualPr)
            {
                string material = dr["Material"].ToString();
                string prdOrdMat = dr["Prd Ord Mat"].ToString();

                if (material == string.Empty && prdOrdMat == string.Empty)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
