using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Correlation
{
    public partial class CorrelationControl : UserControl
    {
        private FormData frmData = new FormData();
        private Thread[] rawDataLoadThreads = new Thread[CorrelationLoaderUtils.NumberOfCorrelationHeaders];
        private Thread[] correlationDataLoadThreads = new Thread[CorrelationLoaderUtils.NumberOfCorrelationHeaders];

        private CorrelationData data;


        public CorrelationControl()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CorrelationWindowcs_Load(object sender, EventArgs e)
        {
            data = new CorrelationData();
            InitializeRawDataLoadThreads();
            InitializeCorrelationDataLoadThreads();
            StartDataLoadProcess();
        }


        /// <summary>
        /// This form prevents flickering of the UI when it repaints.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                var ccp = base.CreateParams;
                ccp.ExStyle |= 0x02000000;
                return ccp;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void InitializeRawDataLoadThreads()
        {
            rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty] = new Thread(() =>
            { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]] = CorrelationDataRetriever.GetPoQtyData(); });

            rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty] = new Thread(() =>
            { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]] = CorrelationDataRetriever.GetPrQtyData(); });

            rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice] = new Thread(() =>
            { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]] = CorrelationDataRetriever.GetPrPriceData(); });

            rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue] = new Thread(() =>
            { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]] = CorrelationDataRetriever.GetPrPosValueData(); });

            rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice] = new Thread(() =>
            { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]] = CorrelationDataRetriever.GetPoNetPriceData(); });

            rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue] = new Thread(() =>
            { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]] = CorrelationDataRetriever.GetPoValueData(); });

            rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit] = new Thread(() =>
            { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]] = CorrelationDataRetriever.GetPriceUnitData(); });

            rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime] = new Thread(() =>
            { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]] = CorrelationDataRetriever.GetPlannedDelivTimeData(); });

            rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered] = new Thread(() =>
            { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]] = CorrelationDataRetriever.GetQtyOrderedData(); });

            rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered] = new Thread(() =>
            { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]] = CorrelationDataRetriever.GetDeliveredData(); });

            rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf] = new Thread(() =>
            { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]] = CorrelationDataRetriever.GetQtyConfData(); });

            rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty] = new Thread(() =>
            { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]] = CorrelationDataRetriever.GetOpenPrQtyData(); });
        }


        /// <summary>
        /// 
        /// </summary>
        private void InitializeCorrelationDataLoadThreads()
        {
            correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty] = new Thread(() =>
            { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]]); });

            correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty] = new Thread(() =>
            { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]]); });

            correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice] = new Thread(() =>
            { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]]); });

            correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue] = new Thread(() =>
            { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]]); });

            correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice] = new Thread(() =>
            { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]]); });

            correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue] = new Thread(() =>
            { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]]); });

            correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit] = new Thread(() =>
            { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]]); });

            correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime] = new Thread(() =>
            { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]]); });

            correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered] = new Thread(() =>
            { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]]); });

            correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered] = new Thread(() =>
            { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]]); });

            correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf] = new Thread(() =>
            { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]]); });

            correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty] = new Thread(() =>
            { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]]); });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_dataloader_Tick(object sender, EventArgs e)
        {
            if (!CorrelationLoaderUtils.TableLoadProcessStarted)
            {
                CorrelationLoaderUtils.TableLoadProcessStarted = true;
                Thread tableLoadThread = new Thread(() => { Database.DatabaseUtils.LoadCorrelationFields(); });
                tableLoadThread.Start();
            }


            if (CorrelationLoaderUtils.TablesLoaded && !CorrelationLoaderUtils.CorrelationRawDataLoadProcessStarted)
            {
                CorrelationLoaderUtils.CorrelationRawDataLoadProcessStarted = true;

                foreach (Thread thrd in rawDataLoadThreads)
                {
                    thrd.Start();
                }
            }


            if (CorrelationLoaderUtils.CorrelationRawDataLoaded)
            {
                CorrelationLoaderUtils.CorrelationRawDataLoaded = false;
                foreach (Thread thrd in correlationDataLoadThreads)
                {
                    try
                    {
                        thrd.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }


            if (CorrelationLoaderUtils.CorrelationCalculated)
            {
                CorrelationLoaderUtils.CorrelationCalculated = false;
                tmr_dataloader.Stop();
                LoadCorrelationMatrix();
                ColorDataGridCells();
                tblpnl_correlationTool.BringToFront();
                CorrelationLoaderUtils.Reset(); // reset the loading variables
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void StartDataLoadProcess()
        {
            CorrelationLoaderUtils.Reset();
            pnl_loadingScreen.BringToFront();
            tmr_dataloader.Start();
        }


        /// <summary>
        /// 
        /// </summary>
        private void LoadCorrelationMatrix()
        {
            foreach (CorrelationHeaders.CorrelationMatrixIndexer index in Enum.GetValues(typeof(CorrelationHeaders.CorrelationMatrixIndexer)))
            {
                List<double> tempList = data.correlationData[CorrelationHeaders.correlationHeaders[(int)index]];
                double corrOne = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty], 3);
                double corrTwo = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty], 3);
                double corrThree = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice], 3);
                double corrFour = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue], 3);
                double corrFive = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice], 3);
                double corrSix = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue], 3);
                double corrSeven = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit], 3);
                double corrEight = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime], 3);
                double corrNine = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered], 3);
                double corrTen = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered], 3);
                double corrEleven = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf], 3);
                double corrTwelve = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty], 3);

                tblpnl_correlationTool.Rows.Add(CorrelationHeaders.correlationHeaders[(int)index], corrOne, corrTwo, corrThree, corrFour, corrFive, corrSix, corrSeven, corrEight, corrNine, corrTen, corrEleven, corrTwelve);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void ColorDataGridCells()
        {
            foreach (DataGridViewRow dgvr in tblpnl_correlationTool.Rows)
            {
                foreach (DataGridViewCell cell in dgvr.Cells)
                {
                    if (cell.Value.ToString() == string.Empty)
                        return;

                    if (cell.ColumnIndex == 0)
                        continue;

                    double value = double.Parse(cell.Value.ToString());

                    if (value == 1)
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(5, 48, 97);
                        cell.Style.ForeColor = System.Drawing.Color.White;
                    }
                    else if (value < 1 && value > 0.8)
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(17, 72, 132);
                        cell.Style.ForeColor = System.Drawing.Color.White;
                    }
                    else if (value == 0.8)
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(32, 99, 168);
                        cell.Style.ForeColor = System.Drawing.Color.White;
                    }
                    else if (value < 0.8 && value > 0.6)
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(49, 123, 183);
                        cell.Style.ForeColor = System.Drawing.Color.White;
                    }
                    else if (value == 0.6)
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(64, 145, 194);
                        cell.Style.ForeColor = System.Drawing.Color.White;
                    }
                    else if (value < 0.6 && value > 0.4)
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(103, 170, 207);
                        cell.Style.ForeColor = System.Drawing.Color.White;
                    }
                    else if (value == 0.4)
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(143, 195, 221);
                    }
                    else if (value < 0.4 && value > 0.2)
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(177, 213, 230);
                    }
                    else if (value == 0.2)
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(207, 228, 239);
                    }
                    else if (value <= 0.2 && value > 0)
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(235, 243, 248);
                    }
                    else if (value == 0)
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                    }
                    else if (value < 0 && value > (-0.2))
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(254, 237, 229);
                    }
                    else if (value == (-0.2))
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(252, 217, 196);
                    }
                    else if (value < (-0.2) && value > (-0.4))
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(247, 188, 160);
                    }
                    else if (value == (-0.4))
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(242, 162, 128);
                    }
                    else if (value < (-0.4) && value > (-0.6))
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(228, 129, 103);
                        cell.Style.ForeColor = System.Drawing.Color.White;
                    }
                    else if (value == (-0.6))
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(212, 93, 75);
                        cell.Style.ForeColor = System.Drawing.Color.White;
                    }
                    else if (value < (-0.6) && value > (-0.8))
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(194, 57, 57);
                        cell.Style.ForeColor = System.Drawing.Color.White;
                    }
                    else if (value == (-0.8))
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(171, 23, 41);
                        cell.Style.ForeColor = System.Drawing.Color.White;
                    }
                    else if (value < (-0.8) && value > (-1))
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(135, 16, 35);
                        cell.Style.ForeColor = System.Drawing.Color.White;
                    }
                    else // value == (-1)
                    {
                        cell.Style.BackColor = System.Drawing.Color.FromArgb(106, 11, 31);
                        cell.Style.ForeColor = System.Drawing.Color.White;
                    }
                }
            }
        }
    }
}