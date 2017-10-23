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
        /// Callback function used to update the checklist boxes on the filter page.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filter"></param>
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
            CommCat
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
            "Commodity category"
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
                temp = "SELECT DISTINCT " + Values.Globals.SelectedCountry + ".[" + column + "] FROM " + Values.Globals.SelectedCountry;
            }
            else
            {
                temp = "SELECT DISTINCT " + Values.Globals.SelectedCountry + ".[" + column + "] FROM " + Values.Globals.SelectedCountry + " WHERE " + filters;
            }
            query = temp;
        }




        private static void getQuery(Filters col)
        {
            string filters = string.Empty;
            string temp;
            string column = filterCols[(int)col];

            if (filters == string.Empty)
            {
                temp = "SELECT DISTINCT " + Values.Globals.SelectedCountry + ".[" + column + "] FROM " + Values.Globals.SelectedCountry;
            }
            else
            {
                temp = "SELECT DISTINCT " + Values.Globals.SelectedCountry + ".[" + column + "] FROM " + Values.Globals.SelectedCountry + " WHERE " + filters;
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
        internal static void LoadFilters(string filters)
        {
            filters = string.Empty;
            OleDbCommand cmd = new OleDbCommand();
            strData = new HashSet<string>();
            try
            {
                foreach (Filters col in Enum.GetValues(typeof(Filters)))
                {
                    getQuery(col, filters);
                    cmd = new OleDbCommand(query, DatabaseUtils.PRPO_DB_Utils.DatabaseConnection);
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
                MessageBox.Show(ex.Message, "Filter Utils - Load Filters Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                strData.Clear();
                strData = null;
                GC.Collect();
            }
        }






        /// <summary>
        /// Loads the filters for each unique filter column excluding the ignored filter
        /// </summary>
        /// <param name="filters">The current filters</param>
        /// <param name="ignoredCol">The column that we want to ignore</param>
        internal static void LoadFiltersExcluded(string filters, Filters ignoredCol)
        {
            OleDbCommand cmd = new OleDbCommand();
            strData = new HashSet<string>();
            try
            {

                foreach (Filters col in Enum.GetValues(typeof(Filters)))
                {
                    if (ignoredCol == col)
                    {
                        continue;
                    }

                    if (col == Filters.ProjectNUm_ProdOrdWbs && ignoredCol == Filters.ProjectNum_WBS_Element)
                        continue;

                    if (col == Filters.ProjectNum_WBS_Element && ignoredCol == Filters.ProjectNUm_ProdOrdWbs)
                        continue;

                    getQuery(col, filters);
                    cmd = new OleDbCommand(query, DatabaseUtils.PRPO_DB_Utils.DatabaseConnection);

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


                        UpdateFilter(strData, col);
                    }
                    strData.Clear();
                }
                FiltersLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter Utils - Load Filters Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                strData.Clear();
                strData = null;
                GC.Collect();
            }
        }




        /// <summary>
        /// Loads the fitler of the supplied filter name excluding the rest.
        /// </summary>
        /// <param name="filters">The filters used to query the data.</param>
        /// <param name="filtersToLoad">The filter column that needs to be loaded into the application</param>
        internal static void LoadFilter(Filters filtersToLoad)
        {
            OleDbCommand cmd = new OleDbCommand();
            strData = new HashSet<string>();
            try
            {


                foreach (Filters col in Enum.GetValues(typeof(Filters)))
                {
                    if (filtersToLoad != col)
                    {
                        if (filtersToLoad == Filters.ProjectNum_WBS_Element && col == Filters.ProjectNUm_ProdOrdWbs)
                            ;
                        else if (filtersToLoad == Filters.ProjectNUm_ProdOrdWbs && col == Filters.ProjectNum_WBS_Element)
                            ;
                        else
                            continue;
                    }


                    

                    getQuery(col);
                    cmd = new OleDbCommand(query, DatabaseUtils.PRPO_DB_Utils.DatabaseConnection);

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


                        UpdateFilter(strData, col);
                    }
                    strData.Clear();
                }
                FiltersLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter Utils - Load Filters Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (poTestDate < FilterFeeature.Filters.PoFromDate || poTestDate > FilterFeeature.Filters.PoToDate)
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

            if (reqTestDate < FilterFeeature.Filters.PrFromDate || reqTestDate > FilterFeeature.Filters.PrToDate)
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

            if (finalRecDate < FilterFeeature.Filters.FinalReceiptFromDate || finalRecDate > FilterFeeature.Filters.FinalReceiptToDate)
            {
                // This records final receipt date is not within the filters final receipt date range.
                return false;
            }
            return true;
        }
    }
}
