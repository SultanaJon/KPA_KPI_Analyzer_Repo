using DataImporter.Access;
using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.FilterFeeature;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace KPA_KPI_Analyzer.KPA_KPI_Overall
{
    public class Overall
    {
        public KPA kpa;
        public KPI kpi;

        public static DataTable prsOnPOsDt;
        public static DataTable posRecCompDt;
        public static DataTable pr2ndLvlRelDateDt;
        public static DataTable AllDt;




        public static volatile object locker = new object();




        /// <summary>
        /// The Overall.SelectedCountry that the user selected to load into the application.
        /// </summary>
        public static AccessInfo.MainTables SelectedCountry { get; set; }




        /// <summary>
        /// Default Overall Constructor
        /// </summary>
        public Overall()
        {
            kpa = new KPA();
            kpi = new KPI();
        }



        /// <summary>
        /// Loads the data that will be used in the KPI sections for data calculations
        /// </summary>
        public void LoadKPITables()
        {
            prsOnPOsDt = new DataTable();
            posRecCompDt = new DataTable();
            pr2ndLvlRelDateDt = new DataTable();
            AllDt = new DataTable();

            try
            {
                using (OleDbCommand cmd = new OleDbCommand() { Connection = PRPO_DB_Utils.DatabaseConnection })
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        cmd.CommandText = PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.AllPOs] + Filters.FilterQuery;
                        da.SelectCommand = cmd;
                        da.Fill(prsOnPOsDt);

                        cmd.CommandText = PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.POLinesRecComplete] + Filters.FilterQuery;
                        da.SelectCommand = cmd;
                        da.Fill(posRecCompDt);

                        cmd.CommandText = PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.PR_2ndLvlRel] + Filters.FilterQuery;
                        da.SelectCommand = cmd;
                        da.Fill(pr2ndLvlRelDateDt);


                        if(Filters.FilterQuery == string.Empty)
                            cmd.CommandText = PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.AllData];
                        else
                            cmd.CommandText = PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.AllData] + " WHERE " + Filters.SecondaryFilterQuery;

                        da.SelectCommand = cmd;
                        da.Fill(AllDt);



                        PRPO_DB_Utils.CompletedKpaDataLoads++;
                        PRPO_DB_Utils.KPITablesLoaded = true;
                        UpdateLoadProgress();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI Data Load");
            }           
        }





        internal static void UpdateLoadProgress()
        {
            lock(locker)
            {
                PRPO_DB_Utils.CompletedDataLoads++;
                MethodInvoker del = delegate
                {
                    PRPO_DB_Utils.UpdateDataLoadProgress();
                };
                del.Invoke();
            }
        }
    }
}
