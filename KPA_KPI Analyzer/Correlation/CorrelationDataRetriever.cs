namespace KPA_KPI_Analyzer.Correlation
{
    public static class CorrelationDataRetriever
    {
        ///// <summary>
        ///// Gets the data that falls under Po Qty
        ///// </summary>
        ///// <returns>A list of data from the PO Qty field</returns>
        //public static List<double> GetPoQtyData()
        //{
        //    List<double> tempDataList = new List<double>();  
        //    foreach (DataRow dr in Database.DatabaseUtils.ds.Tables[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]].Rows)
        //    {
        //        #region CheckDateRanges
        //        if (CorrelationSettings.FilterByPrDate)
        //        {
        //            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
        //            {
        //                // The PR Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }

        //        if (CorrelationSettings.FilterbyPoDate)
        //        {
        //            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
        //            {
        //                // The PO Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }
        //        #endregion

        //       tempDataList.Add(double.Parse(dr["PO Qty"].ToString()));
        //    }

        //    CorrelationLoaderUtils.NumberOfCompletedRawDataLoads++;
        //    MethodInvoker del = delegate
        //    {
        //        UpdateRawDataLoadProcess();
        //    };
        //    del.Invoke();

        //    return tempDataList;
        //}


        ///// <summary>
        ///// Gets the data that falls under Pr Qty
        ///// </summary>
        ///// <returns></returns>
        //public static List<double> GetPrQtyData()
        //{
        //    List<double> tempDataList = new List<double>();

        //    foreach (DataRow dr in Database.DatabaseUtils.ds.Tables[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]].Rows)
        //    {
        //        #region CheckDateRanges
        //        if (CorrelationSettings.FilterByPrDate)
        //        {
        //            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
        //            {
        //                // The PR Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }

        //        if (CorrelationSettings.FilterbyPoDate)
        //        {
        //            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
        //            {
        //                // The PO Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }
        //        #endregion

        //        tempDataList.Add(double.Parse(dr["PR Qty"].ToString()));
        //    }

        //    CorrelationLoaderUtils.NumberOfCompletedRawDataLoads++;
        //    MethodInvoker del = delegate
        //    {
        //        UpdateRawDataLoadProcess();
        //    };
        //    del.Invoke();

        //    return tempDataList;
        //}



        ///// <summary>
        ///// Returns the data that falls under PR Price
        ///// </summary>
        ///// <returns></returns>
        //public static List<double> GetPrPriceData()
        //{
        //    List<double> tempDataList = new List<double>();

        //    foreach (DataRow dr in Database.DatabaseUtils.ds.Tables[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]].Rows)
        //    {
        //        #region CheckDateRanges
        //        if (CorrelationSettings.FilterByPrDate)
        //        {
        //            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
        //            {
        //                // The PR Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }

        //        if (CorrelationSettings.FilterbyPoDate)
        //        {
        //            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
        //            {
        //                // The PO Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }
        //        #endregion

        //        tempDataList.Add(double.Parse(dr["PR Price"].ToString()));
        //    }

        //    CorrelationLoaderUtils.NumberOfCompletedRawDataLoads++;
        //    MethodInvoker del = delegate
        //    {
        //        UpdateRawDataLoadProcess();
        //    };
        //    del.Invoke();

        //    return tempDataList;
        //}



        ///// <summary>
        ///// Returns the data that falls under PR Pos Value
        ///// </summary>
        ///// <returns></returns>
        //public static List<double> GetPrPosValueData()
        //{
        //    List<double> tempDataList = new List<double>();

        //    foreach (DataRow dr in Database.DatabaseUtils.ds.Tables[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]].Rows)
        //    {
        //        #region CheckDateRanges
        //        if (CorrelationSettings.FilterByPrDate)
        //        {
        //            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
        //            {
        //                // The PR Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }

        //        if (CorrelationSettings.FilterbyPoDate)
        //        {
        //            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
        //            {
        //                // The PO Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }
        //        #endregion

        //        tempDataList.Add(double.Parse(dr["PR Pos#Value"].ToString()));
        //    }

        //    CorrelationLoaderUtils.NumberOfCompletedRawDataLoads++;
        //    MethodInvoker del = delegate
        //    {
        //        UpdateRawDataLoadProcess();
        //    };
        //    del.Invoke();

        //    return tempDataList;
        //}




        ///// <summary>
        ///// Returns the data that falls under PO Net Price
        ///// </summary>
        ///// <returns></returns>
        //public static List<double> GetPoNetPriceData()
        //{
        //    List<double> tempDataList = new List<double>();

        //    foreach (DataRow dr in Database.DatabaseUtils.ds.Tables[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]].Rows)
        //    {
        //        #region CheckDateRanges
        //        if (CorrelationSettings.FilterByPrDate)
        //        {
        //            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
        //            {
        //                // The PR Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }

        //        if (CorrelationSettings.FilterbyPoDate)
        //        {
        //            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
        //            {
        //                // The PO Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }
        //        #endregion

        //        tempDataList.Add(double.Parse(dr["PO Net Price"].ToString()));
        //    }

        //    CorrelationLoaderUtils.NumberOfCompletedRawDataLoads++;
        //    MethodInvoker del = delegate
        //    {
        //        UpdateRawDataLoadProcess();
        //    };
        //    del.Invoke();

        //    return tempDataList;
        //}



        ///// <summary>
        ///// Returns the data that falls under PO Value Data
        ///// </summary>
        ///// <returns></returns>
        //public static List<double> GetPoValueData()
        //{
        //    List<double> tempDataList = new List<double>();

        //    foreach (DataRow dr in Database.DatabaseUtils.ds.Tables[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]].Rows)
        //    {
        //        #region CheckDateRanges
        //        if (CorrelationSettings.FilterByPrDate)
        //        {
        //            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
        //            {
        //                // The PR Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }

        //        if (CorrelationSettings.FilterbyPoDate)
        //        {
        //            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
        //            {
        //                // The PO Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }
        //        #endregion

        //        tempDataList.Add(double.Parse(dr["PO Value"].ToString()));
        //    }

        //    CorrelationLoaderUtils.NumberOfCompletedRawDataLoads++;
        //    MethodInvoker del = delegate
        //    {
        //        UpdateRawDataLoadProcess();
        //    };
        //    del.Invoke();

        //    return tempDataList;
        //}


        ///// <summary>
        ///// Returns the data that falls under Price Unit
        ///// </summary>
        ///// <returns></returns>
        //public static List<double> GetPriceUnitData()
        //{
        //    List<double> tempDataList = new List<double>();

        //    foreach (DataRow dr in Database.DatabaseUtils.ds.Tables[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]].Rows)
        //    {
        //        #region CheckDateRanges
        //        if (CorrelationSettings.FilterByPrDate)
        //        {
        //            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
        //            {
        //                // The PR Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }

        //        if (CorrelationSettings.FilterbyPoDate)
        //        {
        //            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
        //            {
        //                // The PO Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }
        //        #endregion

        //        tempDataList.Add(double.Parse(dr["Price Unit"].ToString()));
        //    }

        //    CorrelationLoaderUtils.NumberOfCompletedRawDataLoads++;
        //    MethodInvoker del = delegate
        //    {
        //        UpdateRawDataLoadProcess();
        //    };
        //    del.Invoke();

        //    return tempDataList;
        //}


        ///// <summary>
        ///// Returns the data that falls under Planned Deliv Time 
        ///// </summary>
        ///// <returns></returns>
        //public static List<double> GetPlannedDelivTimeData()
        //{
        //    List<double> tempDataList = new List<double>();

        //    foreach (DataRow dr in Database.DatabaseUtils.ds.Tables[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]].Rows)
        //    {
        //        #region CheckDateRanges
        //        if (CorrelationSettings.FilterByPrDate)
        //        {
        //            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
        //            {
        //                // The PR Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }

        //        if (CorrelationSettings.FilterbyPoDate)
        //        {
        //            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
        //            {
        //                // The PO Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }
        //        #endregion

        //        tempDataList.Add(double.Parse(dr["Pl# Deliv# Time"].ToString()));
        //    }

        //    CorrelationLoaderUtils.NumberOfCompletedRawDataLoads++;
        //    MethodInvoker del = delegate
        //    {
        //        UpdateRawDataLoadProcess();
        //    };
        //    del.Invoke();

        //    return tempDataList;
        //}



        ///// <summary>
        ///// Returns the data that falls under Qty Ordered.
        ///// </summary>
        ///// <returns></returns>
        //public static List<double> GetQtyOrderedData()
        //{
        //    List<double> tempDataList = new List<double>();

        //    foreach (DataRow dr in Database.DatabaseUtils.ds.Tables[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]].Rows)
        //    {
        //        #region CheckDateRanges
        //        if (CorrelationSettings.FilterByPrDate)
        //        {
        //            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
        //            {
        //                // The PR Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }

        //        if (CorrelationSettings.FilterbyPoDate)
        //        {
        //            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
        //            {
        //                // The PO Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }
        //        #endregion

        //        tempDataList.Add(double.Parse(dr["Qty Ordered"].ToString()));
        //    }

        //    CorrelationLoaderUtils.NumberOfCompletedRawDataLoads++;
        //    MethodInvoker del = delegate
        //    {
        //        UpdateRawDataLoadProcess();
        //    };
        //    del.Invoke();

        //    return tempDataList;
        //}



        ///// <summary>
        ///// Returns the data that falls under Delivered
        ///// </summary>
        ///// <returns></returns>
        //public static List<double> GetDeliveredData()
        //{
        //    List<double> tempDataList = new List<double>();

        //    foreach (DataRow dr in Database.DatabaseUtils.ds.Tables[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]].Rows)
        //    {
        //        #region CheckDateRanges
        //        if (CorrelationSettings.FilterByPrDate)
        //        {
        //            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
        //            {
        //                // The PR Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }

        //        if (CorrelationSettings.FilterbyPoDate)
        //        {
        //            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
        //            {
        //                // The PO Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }
        //        #endregion

        //        tempDataList.Add(double.Parse(dr["Delivered"].ToString()));
        //    }

        //    CorrelationLoaderUtils.NumberOfCompletedRawDataLoads++;
        //    MethodInvoker del = delegate
        //    {
        //        UpdateRawDataLoadProcess();
        //    };
        //    del.Invoke();

        //    return tempDataList;
        //}




        ///// <summary>
        ///// Returns the data that falls under Qty Confirmed
        ///// </summary>
        ///// <returns></returns>
        //public static List<double> GetQtyConfData()
        //{
        //    List<double> tempDataList = new List<double>();

        //    foreach (DataRow dr in Database.DatabaseUtils.ds.Tables[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]].Rows)
        //    {
        //        #region CheckDateRanges
        //        if (CorrelationSettings.FilterByPrDate)
        //        {
        //            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
        //            {
        //                // The PR Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }

        //        if (CorrelationSettings.FilterbyPoDate)
        //        {
        //            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
        //            {
        //                // The PO Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }
        //        #endregion

        //        tempDataList.Add(double.Parse(dr["Qty Conf#"].ToString()));
        //    }

        //    CorrelationLoaderUtils.NumberOfCompletedRawDataLoads++;
        //    MethodInvoker del = delegate
        //    {
        //        UpdateRawDataLoadProcess();
        //    };
        //    del.Invoke();

        //    return tempDataList;
        //}







        ///// <summary>
        ///// Returns the data that falls under Open PR Qty
        ///// </summary>
        ///// <returns></returns>
        //public static List<double> GetOpenPrQtyData()
        //{
        //    List<double> tempDataList = new List<double>();

        //    foreach (DataRow dr in Database.DatabaseUtils.ds.Tables[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]].Rows)
        //    {
        //        #region CheckDateRanges
        //        if (CorrelationSettings.FilterByPrDate)
        //        {
        //            if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
        //            {
        //                // The PR Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }

        //        if (CorrelationSettings.FilterbyPoDate)
        //        {
        //            if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
        //            {
        //                // The PO Date was not in range of the filter the user applied.
        //                continue;
        //            }
        //        }
        //        #endregion

        //        tempDataList.Add(double.Parse(dr["Open PR Qty"].ToString()));
        //    }

        //    CorrelationLoaderUtils.NumberOfCompletedRawDataLoads++;
        //    MethodInvoker del = delegate
        //    {
        //        UpdateRawDataLoadProcess();
        //    };
        //    del.Invoke();

        //    return tempDataList;
        //}








        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //public static List<double> FindCorrelation(List<double> data)
        //{
        //    List<double> tempCorrelationList = new List<double>();
        //    List<double> result = new List<double>();
        //    DataTable tempDataTable = new DataTable();

        //    try
        //    {
        //        foreach (CorrelationHeaders.CorrelationMatrixIndexer index in Enum.GetValues(typeof(CorrelationHeaders.CorrelationMatrixIndexer)))
        //        {
        //            tempDataTable = Database.DatabaseUtils.ds.Tables[CorrelationHeaders.correlationHeaders[(int)index]];
        //            foreach (DataRow row in tempDataTable.Rows)
        //            {
        //                tempCorrelationList.Add(double.Parse(row[CorrelationHeaders.correlationQueryHeaders[(int)index]].ToString()));
        //            }
        //            result.Add(MathNet.Numerics.Statistics.Correlation.Pearson(data, tempCorrelationList));
        //            tempCorrelationList.Clear();
        //        }

        //        CorrelationLoaderUtils.NumberOfCompletedCorrelationLoads++;
        //        MethodInvoker del = delegate
        //        {
        //            UpdateCorrelationLoadProcess();
        //        };
        //        del.Invoke();
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }


        //    return result;
        //}







        ///// <summary>
        ///// 
        ///// </summary>
        //public static void UpdateRawDataLoadProcess()
        //{
        //    if(CorrelationLoaderUtils.NumberOfCorrelationHeaders == CorrelationLoaderUtils.NumberOfCompletedRawDataLoads)
        //    {
        //        CorrelationLoaderUtils.CorrelationRawDataLoaded = true;
        //    }
        //}






        ///// <summary>
        ///// 
        ///// </summary>
        //public static void UpdateCorrelationLoadProcess()
        //{
        //    if(CorrelationLoaderUtils.NumberOfCorrelationHeaders == CorrelationLoaderUtils.NumberOfCompletedCorrelationLoads)
        //    {
        //        CorrelationLoaderUtils.CorrelationCalculated = true;
        //    }
        //}
    }
}
