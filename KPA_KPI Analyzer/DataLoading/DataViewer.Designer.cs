namespace KPA_KPI_Analyzer.DataLoading
{
    partial class DataViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.topPanelDragCntl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnl_menuStrip = new System.Windows.Forms.Panel();
            this.ms_topPanelMenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_topPanel = new System.Windows.Forms.Panel();
            this.pnl_Minimize = new System.Windows.Forms.Panel();
            this.pnl_Maximize = new System.Windows.Forms.Panel();
            this.pnl_Close = new System.Windows.Forms.Panel();
            this.pnl_title = new System.Windows.Forms.Panel();
            this.lbl_title = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnl_Logo = new System.Windows.Forms.Panel();
            this.pnl_TopUIPanel = new System.Windows.Forms.Panel();
            this.dc_logoDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.dc_titlePanelDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.dc_titleDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnl_datagridview = new System.Windows.Forms.Panel();
            this.dgv_dataViewerDgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.tblpnl_loadingScreen = new System.Windows.Forms.TableLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.cpb_loadingScreenCircProgBar = new CircularProgressBar.CircularProgressBar();
            this.tmr_waitTimer = new System.Windows.Forms.Timer(this.components);
            this.tmr_ExportTimer = new System.Windows.Forms.Timer(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.be_dataViewerUI = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_menuStrip.SuspendLayout();
            this.ms_topPanelMenuStrip.SuspendLayout();
            this.pnl_topPanel.SuspendLayout();
            this.pnl_title.SuspendLayout();
            this.pnl_TopUIPanel.SuspendLayout();
            this.pnl_datagridview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dataViewerDgv)).BeginInit();
            this.tblpnl_loadingScreen.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanelDragCntl
            // 
            this.topPanelDragCntl.Fixed = true;
            this.topPanelDragCntl.Horizontal = true;
            this.topPanelDragCntl.TargetControl = this.pnl_menuStrip;
            this.topPanelDragCntl.Vertical = true;
            // 
            // pnl_menuStrip
            // 
            this.pnl_menuStrip.Controls.Add(this.ms_topPanelMenuStrip);
            this.pnl_menuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_menuStrip.Location = new System.Drawing.Point(251, 0);
            this.pnl_menuStrip.Name = "pnl_menuStrip";
            this.pnl_menuStrip.Size = new System.Drawing.Size(799, 25);
            this.pnl_menuStrip.TabIndex = 5;
            this.pnl_menuStrip.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnl_TopPanel_MouseDoubleClick);
            // 
            // ms_topPanelMenuStrip
            // 
            this.ms_topPanelMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.ms_topPanelMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ms_topPanelMenuStrip.Enabled = false;
            this.ms_topPanelMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.ms_topPanelMenuStrip.Location = new System.Drawing.Point(3, 1);
            this.ms_topPanelMenuStrip.Name = "ms_topPanelMenuStrip";
            this.ms_topPanelMenuStrip.Size = new System.Drawing.Size(55, 24);
            this.ms_topPanelMenuStrip.TabIndex = 0;
            this.ms_topPanelMenuStrip.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.exportToolStripMenuItem.Text = "Export to Excel";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // pnl_topPanel
            // 
            this.pnl_topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.pnl_topPanel.Controls.Add(this.pnl_menuStrip);
            this.pnl_topPanel.Controls.Add(this.pnl_Minimize);
            this.pnl_topPanel.Controls.Add(this.pnl_Maximize);
            this.pnl_topPanel.Controls.Add(this.pnl_Close);
            this.pnl_topPanel.Controls.Add(this.pnl_title);
            this.pnl_topPanel.Controls.Add(this.pnl_Logo);
            this.pnl_topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_topPanel.Location = new System.Drawing.Point(0, 0);
            this.pnl_topPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnl_topPanel.Name = "pnl_topPanel";
            this.pnl_topPanel.Size = new System.Drawing.Size(1200, 25);
            this.pnl_topPanel.TabIndex = 0;
            this.pnl_topPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnl_TopPanel_MouseDoubleClick);
            // 
            // pnl_Minimize
            // 
            this.pnl_Minimize.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.Minimize;
            this.pnl_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_Minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Minimize.Location = new System.Drawing.Point(1050, 0);
            this.pnl_Minimize.Name = "pnl_Minimize";
            this.pnl_Minimize.Size = new System.Drawing.Size(50, 25);
            this.pnl_Minimize.TabIndex = 4;
            this.pnl_Minimize.Click += new System.EventHandler(this.btn_Minimize_Click);
            this.pnl_Minimize.MouseLeave += new System.EventHandler(this.btn_Minimize_MouseLeave);
            this.pnl_Minimize.MouseHover += new System.EventHandler(this.btn_Minimize_MouseEnter);
            // 
            // pnl_Maximize
            // 
            this.pnl_Maximize.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.Maximize;
            this.pnl_Maximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_Maximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Maximize.Location = new System.Drawing.Point(1100, 0);
            this.pnl_Maximize.Name = "pnl_Maximize";
            this.pnl_Maximize.Size = new System.Drawing.Size(50, 25);
            this.pnl_Maximize.TabIndex = 3;
            this.pnl_Maximize.Click += new System.EventHandler(this.btn_Expand_Click);
            this.pnl_Maximize.MouseLeave += new System.EventHandler(this.btn_Expand_MouseLeave);
            this.pnl_Maximize.MouseHover += new System.EventHandler(this.btn_Expand_MouseHover);
            // 
            // pnl_Close
            // 
            this.pnl_Close.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.Close;
            this.pnl_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Close.Location = new System.Drawing.Point(1150, 0);
            this.pnl_Close.Name = "pnl_Close";
            this.pnl_Close.Size = new System.Drawing.Size(50, 25);
            this.pnl_Close.TabIndex = 2;
            this.pnl_Close.Click += new System.EventHandler(this.btn_Close_Click);
            this.pnl_Close.MouseLeave += new System.EventHandler(this.btn_Close_MouseLeave);
            this.pnl_Close.MouseHover += new System.EventHandler(this.btn_Close_MouseHover);
            // 
            // pnl_title
            // 
            this.pnl_title.Controls.Add(this.lbl_title);
            this.pnl_title.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_title.Location = new System.Drawing.Point(50, 0);
            this.pnl_title.Name = "pnl_title";
            this.pnl_title.Size = new System.Drawing.Size(201, 25);
            this.pnl_title.TabIndex = 1;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lbl_title.Location = new System.Drawing.Point(8, 6);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(164, 13);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "KPA - KPI Analyzer - Data Viewer";
            // 
            // pnl_Logo
            // 
            this.pnl_Logo.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.comau_logo;
            this.pnl_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_Logo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Logo.Location = new System.Drawing.Point(0, 0);
            this.pnl_Logo.Name = "pnl_Logo";
            this.pnl_Logo.Size = new System.Drawing.Size(50, 25);
            this.pnl_Logo.TabIndex = 0;
            // 
            // pnl_TopUIPanel
            // 
            this.pnl_TopUIPanel.BackColor = System.Drawing.Color.Black;
            this.pnl_TopUIPanel.Controls.Add(this.pnl_topPanel);
            this.pnl_TopUIPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_TopUIPanel.Location = new System.Drawing.Point(0, 0);
            this.pnl_TopUIPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnl_TopUIPanel.Name = "pnl_TopUIPanel";
            this.pnl_TopUIPanel.Size = new System.Drawing.Size(1200, 26);
            this.pnl_TopUIPanel.TabIndex = 57;
            // 
            // dc_logoDragControl
            // 
            this.dc_logoDragControl.Fixed = true;
            this.dc_logoDragControl.Horizontal = true;
            this.dc_logoDragControl.TargetControl = this.pnl_Logo;
            this.dc_logoDragControl.Vertical = true;
            // 
            // dc_titlePanelDragControl
            // 
            this.dc_titlePanelDragControl.Fixed = true;
            this.dc_titlePanelDragControl.Horizontal = true;
            this.dc_titlePanelDragControl.TargetControl = this.pnl_title;
            this.dc_titlePanelDragControl.Vertical = true;
            // 
            // dc_titleDragControl
            // 
            this.dc_titleDragControl.Fixed = true;
            this.dc_titleDragControl.Horizontal = true;
            this.dc_titleDragControl.TargetControl = this.lbl_title;
            this.dc_titleDragControl.Vertical = true;
            // 
            // pnl_datagridview
            // 
            this.pnl_datagridview.Controls.Add(this.dgv_dataViewerDgv);
            this.pnl_datagridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_datagridview.Location = new System.Drawing.Point(0, 26);
            this.pnl_datagridview.Name = "pnl_datagridview";
            this.pnl_datagridview.Size = new System.Drawing.Size(1200, 674);
            this.pnl_datagridview.TabIndex = 59;
            // 
            // dgv_dataViewerDgv
            // 
            this.dgv_dataViewerDgv.AllowUserToAddRows = false;
            this.dgv_dataViewerDgv.AllowUserToDeleteRows = false;
            this.dgv_dataViewerDgv.AllowUserToOrderColumns = true;
            this.dgv_dataViewerDgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_dataViewerDgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_dataViewerDgv.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_dataViewerDgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_dataViewerDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_dataViewerDgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_dataViewerDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_dataViewerDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_dataViewerDgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_dataViewerDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_dataViewerDgv.DoubleBuffered = true;
            this.dgv_dataViewerDgv.EnableHeadersVisualStyles = false;
            this.dgv_dataViewerDgv.HeaderBgColor = System.Drawing.SystemColors.Control;
            this.dgv_dataViewerDgv.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.dgv_dataViewerDgv.Location = new System.Drawing.Point(0, 0);
            this.dgv_dataViewerDgv.Name = "dgv_dataViewerDgv";
            this.dgv_dataViewerDgv.ReadOnly = true;
            this.dgv_dataViewerDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(198)))), ((int)(((byte)(187)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_dataViewerDgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_dataViewerDgv.RowTemplate.Height = 18;
            this.dgv_dataViewerDgv.Size = new System.Drawing.Size(1200, 674);
            this.dgv_dataViewerDgv.TabIndex = 6;
            this.dgv_dataViewerDgv.DataSourceChanged += new System.EventHandler(this.dgv_dataViewerDgv_DataSourceChanged);
            // 
            // tblpnl_loadingScreen
            // 
            this.tblpnl_loadingScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.tblpnl_loadingScreen.ColumnCount = 3;
            this.tblpnl_loadingScreen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpnl_loadingScreen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 234F));
            this.tblpnl_loadingScreen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpnl_loadingScreen.Controls.Add(this.panel9, 1, 1);
            this.tblpnl_loadingScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpnl_loadingScreen.Location = new System.Drawing.Point(0, 26);
            this.tblpnl_loadingScreen.Name = "tblpnl_loadingScreen";
            this.tblpnl_loadingScreen.RowCount = 3;
            this.tblpnl_loadingScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpnl_loadingScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 234F));
            this.tblpnl_loadingScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpnl_loadingScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblpnl_loadingScreen.Size = new System.Drawing.Size(1200, 674);
            this.tblpnl_loadingScreen.TabIndex = 7;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.cpb_loadingScreenCircProgBar);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(483, 220);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(234, 234);
            this.panel9.TabIndex = 0;
            // 
            // cpb_loadingScreenCircProgBar
            // 
            this.cpb_loadingScreenCircProgBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.cpb_loadingScreenCircProgBar.AnimationSpeed = 500;
            this.cpb_loadingScreenCircProgBar.BackColor = System.Drawing.Color.Transparent;
            this.cpb_loadingScreenCircProgBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.cpb_loadingScreenCircProgBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.cpb_loadingScreenCircProgBar.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.cpb_loadingScreenCircProgBar.InnerMargin = 2;
            this.cpb_loadingScreenCircProgBar.InnerWidth = -1;
            this.cpb_loadingScreenCircProgBar.Location = new System.Drawing.Point(2, 0);
            this.cpb_loadingScreenCircProgBar.MarqueeAnimationSpeed = 1000;
            this.cpb_loadingScreenCircProgBar.Name = "cpb_loadingScreenCircProgBar";
            this.cpb_loadingScreenCircProgBar.OuterColor = System.Drawing.Color.Gainsboro;
            this.cpb_loadingScreenCircProgBar.OuterMargin = -25;
            this.cpb_loadingScreenCircProgBar.OuterWidth = 26;
            this.cpb_loadingScreenCircProgBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(198)))), ((int)(((byte)(187)))));
            this.cpb_loadingScreenCircProgBar.ProgressWidth = 5;
            this.cpb_loadingScreenCircProgBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.cpb_loadingScreenCircProgBar.Size = new System.Drawing.Size(231, 234);
            this.cpb_loadingScreenCircProgBar.StartAngle = 270;
            this.cpb_loadingScreenCircProgBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.cpb_loadingScreenCircProgBar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpb_loadingScreenCircProgBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cpb_loadingScreenCircProgBar.SubscriptText = "";
            this.cpb_loadingScreenCircProgBar.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpb_loadingScreenCircProgBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cpb_loadingScreenCircProgBar.SuperscriptText = "";
            this.cpb_loadingScreenCircProgBar.TabIndex = 1;
            this.cpb_loadingScreenCircProgBar.Text = "Loading Data...";
            this.cpb_loadingScreenCircProgBar.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.cpb_loadingScreenCircProgBar.Value = 36;
            // 
            // tmr_waitTimer
            // 
            this.tmr_waitTimer.Enabled = true;
            this.tmr_waitTimer.Tick += new System.EventHandler(this.tmr_waitTimer_Tick);
            // 
            // tmr_ExportTimer
            // 
            this.tmr_ExportTimer.Tick += new System.EventHandler(this.tmr_ExportTimer_Tick);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // be_dataViewerUI
            // 
            this.be_dataViewerUI.ElipseRadius = 5;
            this.be_dataViewerUI.TargetControl = this;
            // 
            // DataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tblpnl_loadingScreen);
            this.Controls.Add(this.pnl_datagridview);
            this.Controls.Add(this.pnl_TopUIPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.ms_topPanelMenuStrip;
            this.Name = "DataViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataViewer";
            this.Load += new System.EventHandler(this.DataViewer_Load);
            this.pnl_menuStrip.ResumeLayout(false);
            this.pnl_menuStrip.PerformLayout();
            this.ms_topPanelMenuStrip.ResumeLayout(false);
            this.ms_topPanelMenuStrip.PerformLayout();
            this.pnl_topPanel.ResumeLayout(false);
            this.pnl_title.ResumeLayout(false);
            this.pnl_title.PerformLayout();
            this.pnl_TopUIPanel.ResumeLayout(false);
            this.pnl_datagridview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dataViewerDgv)).EndInit();
            this.tblpnl_loadingScreen.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuDragControl topPanelDragCntl;
        private System.Windows.Forms.Panel pnl_TopUIPanel;
        private System.Windows.Forms.Panel pnl_topPanel;
        private System.Windows.Forms.Panel pnl_Minimize;
        private System.Windows.Forms.Panel pnl_Maximize;
        private System.Windows.Forms.Panel pnl_Close;
        private System.Windows.Forms.Panel pnl_title;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_title;
        private System.Windows.Forms.Panel pnl_Logo;
        private Bunifu.Framework.UI.BunifuDragControl dc_logoDragControl;
        private Bunifu.Framework.UI.BunifuDragControl dc_titlePanelDragControl;
        private Bunifu.Framework.UI.BunifuDragControl dc_titleDragControl;
        private System.Windows.Forms.Panel pnl_menuStrip;
        private System.Windows.Forms.MenuStrip ms_topPanelMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.Panel pnl_datagridview;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgv_dataViewerDgv;
        private System.Windows.Forms.TableLayoutPanel tblpnl_loadingScreen;
        private System.Windows.Forms.Panel panel9;
        private CircularProgressBar.CircularProgressBar cpb_loadingScreenCircProgBar;
        private System.Windows.Forms.Timer tmr_waitTimer;
        private System.Windows.Forms.Timer tmr_ExportTimer;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private Bunifu.Framework.UI.BunifuElipse be_dataViewerUI;
    }
}