namespace KPA_KPI_Analyzer.Correlation
{
    partial class CorrelationTool
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
            this.pnl_TopUIPanel = new System.Windows.Forms.Panel();
            this.pnl_topPanel = new System.Windows.Forms.Panel();
            this.pnl_Minimize = new System.Windows.Forms.Panel();
            this.pnl_Maximize = new System.Windows.Forms.Panel();
            this.pnl_Close = new System.Windows.Forms.Panel();
            this.pnl_titlePanel = new System.Windows.Forms.Panel();
            this.lbl_title = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnl_logo = new System.Windows.Forms.Panel();
            this.dc_topPanel = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.dc_logo = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.dc_title = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.dc_titlePanel = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.tblpnl_correlationTool = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_correlationmatrix = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_CorrelationTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.pnl_loadingScreen = new System.Windows.Forms.Panel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.cpb_loadingScreenCircProgBar = new CircularProgressBar.CircularProgressBar();
            this.tmr_dataloader = new System.Windows.Forms.Timer(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_TopUIPanel.SuspendLayout();
            this.pnl_topPanel.SuspendLayout();
            this.pnl_titlePanel.SuspendLayout();
            this.tblpnl_correlationTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_correlationmatrix)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnl_loadingScreen.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_TopUIPanel
            // 
            this.pnl_TopUIPanel.BackColor = System.Drawing.Color.Black;
            this.pnl_TopUIPanel.Controls.Add(this.pnl_topPanel);
            this.pnl_TopUIPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_TopUIPanel.Location = new System.Drawing.Point(0, 0);
            this.pnl_TopUIPanel.Name = "pnl_TopUIPanel";
            this.pnl_TopUIPanel.Size = new System.Drawing.Size(1200, 26);
            this.pnl_TopUIPanel.TabIndex = 57;
            // 
            // pnl_topPanel
            // 
            this.pnl_topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.pnl_topPanel.Controls.Add(this.pnl_Minimize);
            this.pnl_topPanel.Controls.Add(this.pnl_Maximize);
            this.pnl_topPanel.Controls.Add(this.pnl_Close);
            this.pnl_topPanel.Controls.Add(this.pnl_titlePanel);
            this.pnl_topPanel.Controls.Add(this.pnl_logo);
            this.pnl_topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_topPanel.Location = new System.Drawing.Point(0, 0);
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
            this.pnl_Minimize.MouseEnter += new System.EventHandler(this.btn_Minimize_MouseEnter);
            this.pnl_Minimize.MouseHover += new System.EventHandler(this.btn_Minimize_MouseLeave);
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
            // pnl_titlePanel
            // 
            this.pnl_titlePanel.Controls.Add(this.lbl_title);
            this.pnl_titlePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_titlePanel.Location = new System.Drawing.Point(50, 0);
            this.pnl_titlePanel.Name = "pnl_titlePanel";
            this.pnl_titlePanel.Size = new System.Drawing.Size(249, 25);
            this.pnl_titlePanel.TabIndex = 1;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lbl_title.Location = new System.Drawing.Point(8, 6);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(180, 13);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "KPA - KPI Analyzer - Correlation Tool";
            // 
            // pnl_logo
            // 
            this.pnl_logo.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.comau_logo;
            this.pnl_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_logo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_logo.Location = new System.Drawing.Point(0, 0);
            this.pnl_logo.Name = "pnl_logo";
            this.pnl_logo.Size = new System.Drawing.Size(50, 25);
            this.pnl_logo.TabIndex = 0;
            // 
            // dc_topPanel
            // 
            this.dc_topPanel.Fixed = true;
            this.dc_topPanel.Horizontal = true;
            this.dc_topPanel.TargetControl = this.pnl_topPanel;
            this.dc_topPanel.Vertical = true;
            // 
            // dc_logo
            // 
            this.dc_logo.Fixed = true;
            this.dc_logo.Horizontal = true;
            this.dc_logo.TargetControl = this.pnl_logo;
            this.dc_logo.Vertical = true;
            // 
            // dc_title
            // 
            this.dc_title.Fixed = true;
            this.dc_title.Horizontal = true;
            this.dc_title.TargetControl = this.lbl_title;
            this.dc_title.Vertical = true;
            // 
            // dc_titlePanel
            // 
            this.dc_titlePanel.Fixed = true;
            this.dc_titlePanel.Horizontal = true;
            this.dc_titlePanel.TargetControl = this.pnl_titlePanel;
            this.dc_titlePanel.Vertical = true;
            // 
            // tblpnl_correlationTool
            // 
            this.tblpnl_correlationTool.ColumnCount = 1;
            this.tblpnl_correlationTool.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblpnl_correlationTool.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblpnl_correlationTool.Controls.Add(this.dgv_correlationmatrix, 0, 1);
            this.tblpnl_correlationTool.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tblpnl_correlationTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpnl_correlationTool.Location = new System.Drawing.Point(0, 26);
            this.tblpnl_correlationTool.Margin = new System.Windows.Forms.Padding(0);
            this.tblpnl_correlationTool.Name = "tblpnl_correlationTool";
            this.tblpnl_correlationTool.RowCount = 2;
            this.tblpnl_correlationTool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.66469F));
            this.tblpnl_correlationTool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.33531F));
            this.tblpnl_correlationTool.Size = new System.Drawing.Size(1200, 674);
            this.tblpnl_correlationTool.TabIndex = 58;
            // 
            // dgv_correlationmatrix
            // 
            this.dgv_correlationmatrix.AllowUserToAddRows = false;
            this.dgv_correlationmatrix.AllowUserToDeleteRows = false;
            this.dgv_correlationmatrix.AllowUserToOrderColumns = true;
            this.dgv_correlationmatrix.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_correlationmatrix.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_correlationmatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_correlationmatrix.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_correlationmatrix.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_correlationmatrix.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_correlationmatrix.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_correlationmatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_correlationmatrix.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column14});
            this.dgv_correlationmatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_correlationmatrix.DoubleBuffered = true;
            this.dgv_correlationmatrix.EnableHeadersVisualStyles = false;
            this.dgv_correlationmatrix.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.dgv_correlationmatrix.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.dgv_correlationmatrix.Location = new System.Drawing.Point(3, 330);
            this.dgv_correlationmatrix.Name = "dgv_correlationmatrix";
            this.dgv_correlationmatrix.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_correlationmatrix.Size = new System.Drawing.Size(1194, 341);
            this.dgv_correlationmatrix.TabIndex = 1;
            //this.dgv_correlationmatrix.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_correlationmatrix_CellDoubleClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.14953F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.85046F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1200, 327);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_CorrelationTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1180, 39);
            this.panel1.TabIndex = 0;
            // 
            // lbl_CorrelationTitle
            // 
            this.lbl_CorrelationTitle.AutoSize = true;
            this.lbl_CorrelationTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CorrelationTitle.Location = new System.Drawing.Point(-3, 10);
            this.lbl_CorrelationTitle.Name = "lbl_CorrelationTitle";
            this.lbl_CorrelationTitle.Size = new System.Drawing.Size(124, 20);
            this.lbl_CorrelationTitle.TabIndex = 0;
            this.lbl_CorrelationTitle.Text = "Correlation View";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.cartesianChart1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 49);
            this.panel2.Margin = new System.Windows.Forms.Padding(10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1180, 268);
            this.panel2.TabIndex = 1;
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart1.Location = new System.Drawing.Point(0, 0);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(1180, 268);
            this.cartesianChart1.TabIndex = 2;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // pnl_loadingScreen
            // 
            this.pnl_loadingScreen.Controls.Add(this.tableLayoutPanel9);
            this.pnl_loadingScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_loadingScreen.Location = new System.Drawing.Point(0, 26);
            this.pnl_loadingScreen.Name = "pnl_loadingScreen";
            this.pnl_loadingScreen.Size = new System.Drawing.Size(1200, 674);
            this.pnl_loadingScreen.TabIndex = 59;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 234F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Controls.Add(this.panel9, 1, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 234F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(1200, 674);
            this.tableLayoutPanel9.TabIndex = 1;
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
            this.cpb_loadingScreenCircProgBar.ForeColor = System.Drawing.Color.Silver;
            this.cpb_loadingScreenCircProgBar.InnerColor = System.Drawing.SystemColors.Control;
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
            this.cpb_loadingScreenCircProgBar.Text = "Loading Values...";
            this.cpb_loadingScreenCircProgBar.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.cpb_loadingScreenCircProgBar.Value = 36;
            // 
            // tmr_dataloader
            // 
            this.tmr_dataloader.Tick += new System.EventHandler(this.tmr_dataloader_Tick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "PO Qty";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "PR Qty";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "PR Price";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "PR Pos Val";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "PO Net Price";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "PO Val";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Price Unit";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Plan Del Time";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Qty Ordered";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Delivered";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Qty Conf";
            this.Column12.Name = "Column12";
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Open PR Qty";
            this.Column14.Name = "Column14";
            // 
            // CorrelationTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tblpnl_correlationTool);
            this.Controls.Add(this.pnl_loadingScreen);
            this.Controls.Add(this.pnl_TopUIPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "CorrelationTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CorrelationTool";
            this.Load += new System.EventHandler(this.CorrelationTool_Load);
            this.pnl_TopUIPanel.ResumeLayout(false);
            this.pnl_topPanel.ResumeLayout(false);
            this.pnl_titlePanel.ResumeLayout(false);
            this.pnl_titlePanel.PerformLayout();
            this.tblpnl_correlationTool.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_correlationmatrix)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnl_loadingScreen.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_TopUIPanel;
        private System.Windows.Forms.Panel pnl_topPanel;
        private System.Windows.Forms.Panel pnl_Minimize;
        private System.Windows.Forms.Panel pnl_Maximize;
        private System.Windows.Forms.Panel pnl_Close;
        private System.Windows.Forms.Panel pnl_titlePanel;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_title;
        private System.Windows.Forms.Panel pnl_logo;
        private Bunifu.Framework.UI.BunifuDragControl dc_topPanel;
        private Bunifu.Framework.UI.BunifuDragControl dc_logo;
        private Bunifu.Framework.UI.BunifuDragControl dc_title;
        private Bunifu.Framework.UI.BunifuDragControl dc_titlePanel;
        private System.Windows.Forms.TableLayoutPanel tblpnl_correlationTool;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgv_correlationmatrix;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_CorrelationTitle;
        private System.Windows.Forms.Panel pnl_loadingScreen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Panel panel9;
        private CircularProgressBar.CircularProgressBar cpb_loadingScreenCircProgBar;
        private System.Windows.Forms.Timer tmr_dataloader;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
    }
}