using System;
using System.Collections.Generic;
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
            IRSuppName,
            FxdSuppName,
            DsrdSuppName,
            CommCat,
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
            "IR Supp Name",
            "Fxd Supp Name",
            "Dsrd Supp Name",
            "Commodity category",
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
                        strData.Clear();
                    }
                }
                FiltersLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter Utils - Load Filters Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        strData.Clear();
                    }
                }
                FiltersLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter Utils - Load Filters Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        strData.Clear();
                    }
                }
                FiltersLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter Utils - Load Filters Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
