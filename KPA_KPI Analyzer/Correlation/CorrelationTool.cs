using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Correlation
{
    public partial class CorrelationTool : Form
    {
        //private FormData frmData = new FormData();
        //private Thread[] rawDataLoadThreads = new Thread[CorrelationLoaderUtils.NumberOfCorrelationHeaders];
        //private Thread[] correlationDataLoadThreads = new Thread[CorrelationLoaderUtils.NumberOfCorrelationHeaders];

        //private CorrelationData data;
       

        //public CorrelationTool()
        //{
        //    InitializeComponent();
        //}

        ///// <summary>
        ///// This form prevents flickering of the UI when it repaints.
        ///// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        var ccp = base.CreateParams;
        //        ccp.ExStyle |= 0x02000000;
        //        return ccp;
        //    }
        //}






        ///////////////////////////////////////////////////// UI DIALOGS //////////////////////////////////////////////////
        ////
        ////  here we can control the behavior of the form.
        //// 
        ////  These functions perform the following
        ////  1) minimize the form into the taskbar.
        ////  2) maximize the form to the size of the screen and min down to normal size.
        ////  3) close the application.
        ////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //#region UI_Dialogs
        ///// <summary>
        ///// This event will change the button background image while the user has their cursor over it.
        ///// </summary>
        ///// <param name="sender">The button</param>
        ///// <param name="e">The Mouse Hover Event</param>
        //private void btn_Expand_MouseHover(object sender, EventArgs e)
        //{
        //    pnl_Maximize.BackgroundImage = Properties.Resources.Maximize_Hover_icon;
        //}






        ///// <summary>
        ///// This event will change the background of the image back to the original image.
        ///// </summary>
        ///// <param name="sender">the button</param>
        ///// <param name="e">the Mouse Leave Event</param>
        //private void btn_Expand_MouseLeave(object sender, EventArgs e)
        //{
        //    pnl_Maximize.BackgroundImage = Properties.Resources.Maximize;
        //}






        ///// <summary>
        ///// This event will trigger when the user clicks the expand button and the form will expand.
        ///// </summary>
        ///// <param name="sender">The expand button</param>
        ///// <param name="e">The click event.</param>
        //private void btn_Expand_Click(object sender, EventArgs e)
        //{
        //    FormSizer();
        //}






        ///// <summary>
        ///// This event will change the background of the button when the user hovers over it.
        ///// </summary>
        ///// <param name="sender">the button</param>
        ///// <param name="e">The Mouse Enter Event</param>
        //private void btn_Minimize_MouseEnter(object sender, EventArgs e)
        //{
        //    pnl_Minimize.BackgroundImage = Properties.Resources.Minimize_Hover_Icon;
        //}






        ///// <summary>
        ///// This event will change the background of the image back to the original image.
        ///// </summary>
        ///// <param name="sender">the button</param>
        ///// <param name="e">the Mouse Leave event</param>
        //private void btn_Minimize_MouseLeave(object sender, EventArgs e)
        //{
        //    pnl_Minimize.BackgroundImage = Properties.Resources.Minimize;
        //}






        ///// <summary>
        ///// This event will trigger when the user clicks the minimize button. The form will minimize into the taskbar.
        ///// </summary>
        ///// <param name="sender">The minimize button</param>
        ///// <param name="e">The click event.</param>
        //private void btn_Minimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;






        ///// <summary>
        ///// This event will change the background of the button when the user hovers over it.
        ///// </summary>
        ///// <param name="sender">the button</param>
        ///// <param name="e">The Mouse Over event</param>
        //private void btn_Close_MouseHover(object sender, EventArgs e)
        //{
        //    pnl_Close.BackgroundImage = Properties.Resources.Close_Hover_icon;
        //}






        ///// <summary>
        ///// This event will change the background of the button back to the original background image.
        ///// </summary>
        ///// <param name="sender">the close button</param>
        ///// <param name="e">The MouseLeave event</param>
        //private void btn_Close_MouseLeave(object sender, EventArgs e)
        //{
        //    pnl_Close.BackgroundImage = Properties.Resources.Close;
        //}






        ///// <summary>
        ///// This event will close the entire application (process)
        ///// </summary>
        ///// <param name="sender">The Close button</param>
        ///// <param name="e">The click event</param>
        //private void btn_Close_Click(object sender, EventArgs e)
        //{
        //    DialogResult = DialogResult.Cancel;
        //}
        //#endregion






        ///////////////////////////////////////////////////// TOP PANEL //////////////////////////////////////////////////
        ////
        ////  Here we can control the behavior of the for with the top panel.
        //// 
        ////  These functions perform the following.
        ////  1) size the form to the size of the screen when double clicked.
        ////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //#region Top_Panel
        ///// <summary>
        ///// This event will trigger when the user double clicks the top panel of the the UI. This will max out the size of 
        ///// the screen based on the size of the working area of the computer.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void pnl_TopPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    FormSizer();
        //}








        ///// <summary>
        ///// This function will expand or minimize to original window size.
        ///// </summary>
        //private void FormSizer()
        //{
        //    Screen screen = Screen.FromControl(this);

        //    if (Width == screen.WorkingArea.Width && Height == screen.WorkingArea.Height) // the form is maxed
        //    {
        //        Width = Values.Constants.minFormWidth;
        //        Height = Values.Constants.minFormHeight;
        //        Left = frmData.FrmX;
        //        Top = frmData.FrmY;
        //    }
        //    else // the form is its default size
        //    {
        //        frmData.FrmX = Left;
        //        frmData.FrmY = Top;
        //        Left = screen.WorkingArea.Left;
        //        Top = screen.WorkingArea.Top;
        //        Height = screen.WorkingArea.Height;
        //        Width = screen.WorkingArea.Width;

        //    }
        //    //RefreshTemplate();
        //}
        //#endregion





        ///// <summary>
        ///// 
        ///// </summary>
        //private void InitializeRawDataLoadThreads()
        //{
        //    rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty] = new Thread(() =>
        //    { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]] = CorrelationDataRetriever.GetPoQtyData(); });

        //    rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty] = new Thread(() =>
        //    { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]] = CorrelationDataRetriever.GetPrQtyData(); });

        //    rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice] = new Thread(() =>
        //    { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]] = CorrelationDataRetriever.GetPrPriceData(); });

        //    rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue] = new Thread(() =>
        //    { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]] = CorrelationDataRetriever.GetPrPosValueData(); });

        //    rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice] = new Thread(() =>
        //    { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]] = CorrelationDataRetriever.GetPoNetPriceData(); });

        //    rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue] = new Thread(() =>
        //    { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]] = CorrelationDataRetriever.GetPoValueData(); });

        //    rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit] = new Thread(() =>
        //    { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]] = CorrelationDataRetriever.GetPriceUnitData(); });

        //    rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime] = new Thread(() =>
        //    { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]] = CorrelationDataRetriever.GetPlannedDelivTimeData(); });

        //    rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered] = new Thread(() =>
        //    { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]] = CorrelationDataRetriever.GetQtyOrderedData(); });

        //    rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered] = new Thread(() =>
        //    { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]] = CorrelationDataRetriever.GetDeliveredData(); });

        //    rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf] = new Thread(() =>
        //    { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]] = CorrelationDataRetriever.GetQtyConfData(); });

        //    rawDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty] = new Thread(() =>
        //    { data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]] = CorrelationDataRetriever.GetOpenPrQtyData(); });
        //}






        ///// <summary>
        ///// 
        ///// </summary>
        //private void InitializeCorrelationDataLoadThreads()
        //{
        //    correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty] = new Thread(() => 
        //    { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]]); });

        //    correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty] = new Thread(() =>
        //    { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]]); });

        //    correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice] = new Thread(() =>
        //    { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]]); });

        //    correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue] = new Thread(() =>
        //    { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]]); });

        //    correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice] = new Thread(() =>
        //    { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]]); });

        //    correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue] = new Thread(() =>
        //    { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]]); });

        //    correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit] = new Thread(() =>
        //    { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]]); });

        //    correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime] = new Thread(() =>
        //    { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]]); });

        //    correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered] = new Thread(() =>
        //    { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]]); });

        //    correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered] = new Thread(() =>
        //    { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]]); });

        //    correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf] = new Thread(() =>
        //    { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]]); });

        //    correlationDataLoadThreads[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty] = new Thread(() =>
        //    { data.correlationData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]] = CorrelationDataRetriever.FindCorrelation(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]]); });
        //}







        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void tmr_dataloader_Tick(object sender, EventArgs e)
        //{
        //    if(!CorrelationLoaderUtils.TableLoadProcessStarted)
        //    {
        //        CorrelationLoaderUtils.TableLoadProcessStarted = true;
        //        Thread tableLoadThread = new Thread(() => { Database.DatabaseUtils.LoadCorrelationFields(); });
        //        tableLoadThread.Start();
        //    }


        //    if(CorrelationLoaderUtils.TablesLoaded && !CorrelationLoaderUtils.CorrelationRawDataLoadProcessStarted)
        //    {
        //        CorrelationLoaderUtils.CorrelationRawDataLoadProcessStarted = true;

        //        foreach (Thread thrd in rawDataLoadThreads)
        //        {
        //            thrd.Start();
        //        }
        //    }


        //    if(CorrelationLoaderUtils.CorrelationRawDataLoaded)
        //    {
        //        CorrelationLoaderUtils.CorrelationRawDataLoaded = false;
        //        foreach(Thread thrd in correlationDataLoadThreads)
        //        {
        //            try
        //            {
        //                thrd.Start();
        //            }
        //            catch(Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //            }
        //        }
        //    }


        //    if(CorrelationLoaderUtils.CorrelationCalculated)
        //    {
        //        CorrelationLoaderUtils.CorrelationCalculated = false;
        //        tmr_dataloader.Stop();
        //        LoadCorrelationMatrix();
        //        ColorDataGridCells();
        //        tblpnl_correlationTool.BringToFront();
        //        CorrelationLoaderUtils.Reset(); // reset the loading variables
        //    }
        //}



        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void CorrelationTool_Load(object sender, EventArgs e)
        //{
        //    data = new CorrelationData();
        //    InitializeRawDataLoadThreads();
        //    InitializeCorrelationDataLoadThreads();
        //    StartDataLoadProcess();
        //}




        ///// <summary>
        ///// 
        ///// </summary>
        //private void StartDataLoadProcess()
        //{
        //    CorrelationLoaderUtils.Reset();
        //    pnl_loadingScreen.BringToFront();
        //    tmr_dataloader.Start();
        //}




        //private void LoadCorrelationMatrix()
        //{
        //    foreach(CorrelationHeaders.CorrelationMatrixIndexer index in Enum.GetValues(typeof(CorrelationHeaders.CorrelationMatrixIndexer)))
        //    {
        //        List<double> tempList = data.correlationData[CorrelationHeaders.correlationHeaders[(int)index]];
        //        double corrOne = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty], 3);
        //        double corrTwo = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty], 3);
        //        double corrThree = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice], 3);
        //        double corrFour = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue], 3);
        //        double corrFive = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice], 3);
        //        double corrSix = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue], 3);
        //        double corrSeven = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit], 3);
        //        double corrEight = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime], 3);
        //        double corrNine = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered], 3);
        //        double corrTen = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered], 3);
        //        double corrEleven = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf], 3);
        //        double corrTwelve = Math.Round(tempList[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty], 3);

        //        dgv_correlationmatrix.Rows.Add(CorrelationHeaders.correlationHeaders[(int)index], corrOne, corrTwo, corrThree, corrFour, corrFive, corrSix, corrSeven, corrEight, corrNine, corrTen, corrEleven, corrTwelve);
        //    }
        //}





        //private void ColorDataGridCells()
        //{
        //    foreach(DataGridViewRow dgvr in dgv_correlationmatrix.Rows)
        //    {
        //        foreach(DataGridViewCell cell in dgvr.Cells)
        //        {
        //            if (cell.Value.ToString() == string.Empty)
        //                return;

        //            if (cell.ColumnIndex == 0)
        //                continue;

        //            double value = double.Parse(cell.Value.ToString());
                    
        //            if(value == 1)
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(5, 48, 97);
        //                cell.Style.ForeColor = System.Drawing.Color.White;
        //            }
        //            else if(value < 1 && value > 0.8)
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(17, 72, 132);
        //                cell.Style.ForeColor = System.Drawing.Color.White;
        //            }
        //            else if (value == 0.8)
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(32, 99, 168);
        //                cell.Style.ForeColor = System.Drawing.Color.White;
        //            }
        //            else if(value < 0.8 && value > 0.6)
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(49, 123, 183);
        //                cell.Style.ForeColor = System.Drawing.Color.White;
        //            }
        //            else if (value == 0.6)
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(64, 145, 194);
        //                cell.Style.ForeColor = System.Drawing.Color.White;
        //            }
        //            else if (value < 0.6 && value > 0.4)
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(103, 170, 207);
        //                cell.Style.ForeColor = System.Drawing.Color.White;
        //            }
        //            else if (value == 0.4)
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(143, 195, 221);
        //            }
        //            else if (value < 0.4 && value > 0.2)
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(177, 213, 230);
        //            }
        //            else if (value == 0.2)
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(207, 228, 239);
        //            }
        //            else if (value <= 0.2 && value > 0)
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(235, 243, 248);
        //            }
        //            else if (value == 0)
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
        //            }
        //            else if (value < 0 && value > (-0.2))
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(254, 237, 229);
        //            }
        //            else if (value == (-0.2))
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(252, 217, 196);
        //            }
        //            else if (value < (-0.2) && value > (-0.4))
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(247, 188, 160);
        //            }
        //            else if (value == (-0.4))
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(242, 162, 128);
        //            }
        //            else if (value < (-0.4) && value > (-0.6))
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(228, 129, 103);
        //                cell.Style.ForeColor = System.Drawing.Color.White;
        //            }
        //            else if (value == (-0.6))
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(212, 93, 75);
        //                cell.Style.ForeColor = System.Drawing.Color.White;
        //            }
        //            else if (value < (-0.6) && value > (-0.8))
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(194, 57, 57);
        //                cell.Style.ForeColor = System.Drawing.Color.White;
        //            }
        //            else if (value == (-0.8))
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(171, 23, 41);
        //                cell.Style.ForeColor = System.Drawing.Color.White;
        //            }
        //            else if (value < (-0.8) && value > (-1))
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(135, 16, 35);
        //                cell.Style.ForeColor = System.Drawing.Color.White;
        //            }
        //            else // value == (-1)
        //            {
        //                cell.Style.BackColor = System.Drawing.Color.FromArgb(106, 11, 31);
        //                cell.Style.ForeColor = System.Drawing.Color.White;
        //            }
        //        }
        //    }
        //}

        //private void dgv_correlationmatrix_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        switch(e.RowIndex)
        //        {
        //            case 0:
        //                switch (e.ColumnIndex)
        //                {
        //                    case 0:
        //                        break;
        //                    case 1:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]]);
        //                        break;
        //                    case 2:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]]);
        //                        break;
        //                    case 3:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]]);
        //                        break;
        //                    case 4:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]]);
        //                        break;
        //                    case 5:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]]);
        //                        break;
        //                    case 6:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]]);
        //                        break;
        //                    case 7:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]]);
        //                        break;
        //                    case 8:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]]);
        //                        break;
        //                    case 9:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]]);
        //                        break;
        //                    case 10:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]]);
        //                        break;
        //                    case 11:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]]);
        //                        break;
        //                    case 12:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]]);
        //                        break;
        //                }
        //                break;
        //            case 1:
        //                switch (e.ColumnIndex)
        //                {
        //                    case 0:
        //                        break;
        //                    case 1:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]]);
        //                        break;
        //                    case 2:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]]);
        //                        break;
        //                    case 3:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]]);
        //                        break;
        //                    case 4:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]]);
        //                        break;
        //                    case 5:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]]);
        //                        break;
        //                    case 6:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]]);
        //                        break;
        //                    case 7:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]]);
        //                        break;
        //                    case 8:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]]);
        //                        break;
        //                    case 9:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]]);
        //                        break;
        //                    case 10:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]]);
        //                        break;
        //                    case 11:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]]);
        //                        break;
        //                    case 12:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]]);
        //                        break;
        //                }
        //                break;
        //            case 2:
        //                switch (e.ColumnIndex)
        //                {
        //                    case 0:
        //                        break;
        //                    case 1:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]]);
        //                        break;
        //                    case 2:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]]);
        //                        break;
        //                    case 3:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]]);
        //                        break;
        //                    case 4:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]]);
        //                        break;
        //                    case 5:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]]);
        //                        break;
        //                    case 6:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]]);
        //                        break;
        //                    case 7:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]]);
        //                        break;
        //                    case 8:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]]);
        //                        break;
        //                    case 9:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]]);
        //                        break;
        //                    case 10:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]]);
        //                        break;
        //                    case 11:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]]);
        //                        break;
        //                    case 12:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]]);
        //                        break;
        //                }
        //                break;
        //            case 3:
        //                switch (e.ColumnIndex)
        //                {
        //                    case 0:
        //                        break;
        //                    case 1:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]]);
        //                        break;
        //                    case 2:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]]);
        //                        break;
        //                    case 3:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]]);
        //                        break;
        //                    case 4:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]]);
        //                        break;
        //                    case 5:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]]);
        //                        break;
        //                    case 6:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]]);
        //                        break;
        //                    case 7:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]]);
        //                        break;
        //                    case 8:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]]);
        //                        break;
        //                    case 9:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]]);
        //                        break;
        //                    case 10:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]]);
        //                        break;
        //                    case 11:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]]);
        //                        break;
        //                    case 12:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]]);
        //                        break;
        //                }
        //                break;
        //            case 4:
        //                switch (e.ColumnIndex)
        //                {
        //                    case 0:
        //                        break;
        //                    case 1:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]]);
        //                        break;
        //                    case 2:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]]);
        //                        break;
        //                    case 3:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]]);
        //                        break;
        //                    case 4:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]]);
        //                        break;
        //                    case 5:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]]);
        //                        break;
        //                    case 6:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]]);
        //                        break;
        //                    case 7:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]]);
        //                        break;
        //                    case 8:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]]);
        //                        break;
        //                    case 9:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]]);
        //                        break;
        //                    case 10:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]]);
        //                        break;
        //                    case 11:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]]);
        //                        break;
        //                    case 12:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]]);
        //                        break;
        //                }
        //                break;
        //            case 5:
        //                switch (e.ColumnIndex)
        //                {
        //                    case 0:
        //                        break;
        //                    case 1:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]]);
        //                        break;
        //                    case 2:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]]);
        //                        break;
        //                    case 3:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]]);
        //                        break;
        //                    case 4:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]]);
        //                        break;
        //                    case 5:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]]);
        //                        break;
        //                    case 6:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]]);
        //                        break;
        //                    case 7:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]]);
        //                        break;
        //                    case 8:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]]);
        //                        break;
        //                    case 9:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]]);
        //                        break;
        //                    case 10:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]]);
        //                        break;
        //                    case 11:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]]);
        //                        break;
        //                    case 12:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]]);
        //                        break;
        //                }
        //                break;
        //            case 6:
        //                switch (e.ColumnIndex)
        //                {
        //                    case 0:
        //                        break;
        //                    case 1:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]]);
        //                        break;
        //                    case 2:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]]);
        //                        break;
        //                    case 3:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]]);
        //                        break;
        //                    case 4:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]]);
        //                        break;
        //                    case 5:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]]);
        //                        break;
        //                    case 6:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]]);
        //                        break;
        //                    case 7:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]]);
        //                        break;
        //                    case 8:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]]);
        //                        break;
        //                    case 9:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]]);
        //                        break;
        //                    case 10:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]]);
        //                        break;
        //                    case 11:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]]);
        //                        break;
        //                    case 12:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]]);
        //                        break;
        //                }
        //                break;
        //            case 7:
        //                switch (e.ColumnIndex)
        //                {
        //                    case 0:
        //                        break;
        //                    case 1:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]]);
        //                        break;
        //                    case 2:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]]);
        //                        break;
        //                    case 3:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]]);
        //                        break;
        //                    case 4:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]]);
        //                        break;
        //                    case 5:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]]);
        //                        break;
        //                    case 6:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]]);
        //                        break;
        //                    case 7:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]]);
        //                        break;
        //                    case 8:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]]);
        //                        break;
        //                    case 9:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]]);
        //                        break;
        //                    case 10:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]]);
        //                        break;
        //                    case 11:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]]);
        //                        break;
        //                    case 12:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]]);
        //                        break;
        //                }
        //                break;
        //            case 8:
        //                switch (e.ColumnIndex)
        //                {
        //                    case 0:
        //                        break;
        //                    case 1:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]]);
        //                        break;
        //                    case 2:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]]);
        //                        break;
        //                    case 3:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]]);
        //                        break;
        //                    case 4:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]]);
        //                        break;
        //                    case 5:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]]);
        //                        break;
        //                    case 6:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]]);
        //                        break;
        //                    case 7:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]]);
        //                        break;
        //                    case 8:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]]);
        //                        break;
        //                    case 9:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]]);
        //                        break;
        //                    case 10:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]]);
        //                        break;
        //                    case 11:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]]);
        //                        break;
        //                    case 12:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]]);
        //                        break;
        //                }
        //                break;
        //            case 9:
        //                switch (e.ColumnIndex)
        //                {
        //                    case 0:
        //                        break;
        //                    case 1:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]]);
        //                        break;
        //                    case 2:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]]);
        //                        break;
        //                    case 3:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]]);
        //                        break;
        //                    case 4:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]]);
        //                        break;
        //                    case 5:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]]);
        //                        break;
        //                    case 6:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]]);
        //                        break;
        //                    case 7:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]]);
        //                        break;
        //                    case 8:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]]);
        //                        break;
        //                    case 9:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]]);
        //                        break;
        //                    case 10:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]]);
        //                        break;
        //                    case 11:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]]);
        //                        break;
        //                    case 12:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]]);
        //                        break;
        //                }
        //                break;
        //            case 10:
        //                switch (e.ColumnIndex)
        //                {
        //                    case 0:
        //                        break;
        //                    case 1:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]]);
        //                        break;
        //                    case 2:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]]);
        //                        break;
        //                    case 3:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]]);
        //                        break;
        //                    case 4:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]]);
        //                        break;
        //                    case 5:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]]);
        //                        break;
        //                    case 6:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]]);
        //                        break;
        //                    case 7:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]]);
        //                        break;
        //                    case 8:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]]);
        //                        break;
        //                    case 9:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]]);
        //                        break;
        //                    case 10:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]]);
        //                        break;
        //                    case 11:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]]);
        //                        break;
        //                    case 12:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]]);
        //                        break;
        //                }
        //                break;
        //            case 11:
        //                switch (e.ColumnIndex)
        //                {
        //                    case 0:
        //                        break;
        //                    case 1:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoQty]]);
        //                        break;
        //                    case 2:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrQty]]);
        //                        break;
        //                    case 3:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPrice]]);
        //                        break;
        //                    case 4:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PrPosValue]]);
        //                        break;
        //                    case 5:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoNetPrice]]);
        //                        break;
        //                    case 6:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PoValue]]);
        //                        break;
        //                    case 7:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PriceUnit]]);
        //                        break;
        //                    case 8:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.PlDelivTime]]);
        //                        break;
        //                    case 9:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyOrdered]]);
        //                        break;
        //                    case 10:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.Delivered]]);
        //                        break;
        //                    case 11:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.QtyConf]]);
        //                        break;
        //                    case 12:
        //                        RenderScatterPlot(data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]], data.rawData[CorrelationHeaders.correlationHeaders[(int)CorrelationHeaders.CorrelationMatrixIndexer.OpenPrQty]]);
        //                        break;
        //                }
        //                break;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}




        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="dataOne"></param>
        ///// <param name="dataTwo"></param>
        //public void RenderScatterPlot(List<double> dataOne, List<double> dataTwo)
        //{
        //    SeriesCollection seriesColl = new SeriesCollection
        //    {
        //        new ScatterSeries
        //        {
        //            Title = "Series A",
        //            Values = new ChartValues<ObservablePoint>(),
        //            PointGeometry = DefaultGeometries.Circle


        //        },
        //        new ScatterSeries
        //        {
        //            Title = "Series B",
        //            Values = new ChartValues<ObservablePoint>(),
        //            PointGeometry = DefaultGeometries.Square
        //        },
        //    };


        //    foreach (var series in seriesColl)
        //    {
        //        for (var i = 0; i < 20; i++)
        //        {
        //            series.Values.Add(new ObservablePoint(dataOne[i], dataTwo[i]));
        //        }
        //    }

        //    cartesianChart1.DisableAnimations = true;
        //    cartesianChart1.Hoverable = false;
        //    cartesianChart1.DataTooltip = null;
        //    cartesianChart1.Series = seriesColl;
        //    cartesianChart1.LegendLocation = LegendLocation.Bottom;
        //}
    }
}
