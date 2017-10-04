namespace KPA_KPI_Analyzer
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
            this.topPanelDragCntl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnl_topPanel = new System.Windows.Forms.Panel();
            this.pnl_Minimize = new System.Windows.Forms.Panel();
            this.pnl_Maximize = new System.Windows.Forms.Panel();
            this.pnl_Close = new System.Windows.Forms.Panel();
            this.pnl_title = new System.Windows.Forms.Panel();
            this.lbl_title = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnl_Logo = new System.Windows.Forms.Panel();
            this.dgv_dataViewerDgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.pnl_TopUIPanel = new System.Windows.Forms.Panel();
            this.pnl_MainNavigation = new System.Windows.Forms.Panel();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.pnl_CountrySelectorButton = new System.Windows.Forms.Panel();
            this.lbl_Country = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnl_SectionSelectorButton = new System.Windows.Forms.Panel();
            this.lbl_Section = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel27 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnl_PerformanceSelectorButton = new System.Windows.Forms.Panel();
            this.lbl_Performance = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel17 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnl_CategorySelectorButton = new System.Windows.Forms.Panel();
            this.lbl_Category = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel29 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dc_logoDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.dc_titlePanelDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.dc_titleDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnl_topPanel.SuspendLayout();
            this.pnl_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dataViewerDgv)).BeginInit();
            this.pnl_TopUIPanel.SuspendLayout();
            this.pnl_MainNavigation.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.pnl_CountrySelectorButton.SuspendLayout();
            this.pnl_SectionSelectorButton.SuspendLayout();
            this.pnl_PerformanceSelectorButton.SuspendLayout();
            this.pnl_CategorySelectorButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanelDragCntl
            // 
            this.topPanelDragCntl.Fixed = true;
            this.topPanelDragCntl.Horizontal = true;
            this.topPanelDragCntl.TargetControl = this.pnl_topPanel;
            this.topPanelDragCntl.Vertical = true;
            // 
            // pnl_topPanel
            // 
            this.pnl_topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
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
            this.pnl_title.Size = new System.Drawing.Size(179, 25);
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
            // dgv_dataViewerDgv
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_dataViewerDgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_dataViewerDgv.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_dataViewerDgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_dataViewerDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_dataViewerDgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_dataViewerDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_dataViewerDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dataViewerDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_dataViewerDgv.DoubleBuffered = true;
            this.dgv_dataViewerDgv.EnableHeadersVisualStyles = false;
            this.dgv_dataViewerDgv.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.dgv_dataViewerDgv.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.dgv_dataViewerDgv.Location = new System.Drawing.Point(0, 77);
            this.dgv_dataViewerDgv.Name = "dgv_dataViewerDgv";
            this.dgv_dataViewerDgv.ReadOnly = true;
            this.dgv_dataViewerDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_dataViewerDgv.RowTemplate.Height = 18;
            this.dgv_dataViewerDgv.Size = new System.Drawing.Size(1200, 623);
            this.dgv_dataViewerDgv.TabIndex = 5;
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
            // pnl_MainNavigation
            // 
            this.pnl_MainNavigation.BackColor = System.Drawing.Color.Black;
            this.pnl_MainNavigation.Controls.Add(this.tableLayoutPanel14);
            this.pnl_MainNavigation.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_MainNavigation.Location = new System.Drawing.Point(0, 26);
            this.pnl_MainNavigation.Name = "pnl_MainNavigation";
            this.pnl_MainNavigation.Size = new System.Drawing.Size(1200, 51);
            this.pnl_MainNavigation.TabIndex = 58;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 7;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 275F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel14.Controls.Add(this.pnl_CountrySelectorButton, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.pnl_SectionSelectorButton, 4, 0);
            this.tableLayoutPanel14.Controls.Add(this.pnl_PerformanceSelectorButton, 2, 0);
            this.tableLayoutPanel14.Controls.Add(this.pnl_CategorySelectorButton, 6, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(1200, 51);
            this.tableLayoutPanel14.TabIndex = 0;
            // 
            // pnl_CountrySelectorButton
            // 
            this.pnl_CountrySelectorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.pnl_CountrySelectorButton.Controls.Add(this.lbl_Country);
            this.pnl_CountrySelectorButton.Controls.Add(this.bunifuCustomLabel3);
            this.pnl_CountrySelectorButton.Location = new System.Drawing.Point(0, 0);
            this.pnl_CountrySelectorButton.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_CountrySelectorButton.Name = "pnl_CountrySelectorButton";
            this.pnl_CountrySelectorButton.Size = new System.Drawing.Size(175, 50);
            this.pnl_CountrySelectorButton.TabIndex = 0;
            this.pnl_CountrySelectorButton.Tag = "1";
            // 
            // lbl_Country
            // 
            this.lbl_Country.AutoSize = true;
            this.lbl_Country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Country.ForeColor = System.Drawing.Color.White;
            this.lbl_Country.Location = new System.Drawing.Point(10, 25);
            this.lbl_Country.Name = "lbl_Country";
            this.lbl_Country.Size = new System.Drawing.Size(77, 13);
            this.lbl_Country.TabIndex = 0;
            this.lbl_Country.Text = "No Selected";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(10, 9);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(80, 13);
            this.bunifuCustomLabel3.TabIndex = 0;
            this.bunifuCustomLabel3.Text = "Current Country";
            // 
            // pnl_SectionSelectorButton
            // 
            this.pnl_SectionSelectorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.pnl_SectionSelectorButton.Controls.Add(this.lbl_Section);
            this.pnl_SectionSelectorButton.Controls.Add(this.bunifuCustomLabel27);
            this.pnl_SectionSelectorButton.Location = new System.Drawing.Point(352, 0);
            this.pnl_SectionSelectorButton.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_SectionSelectorButton.Name = "pnl_SectionSelectorButton";
            this.pnl_SectionSelectorButton.Size = new System.Drawing.Size(275, 50);
            this.pnl_SectionSelectorButton.TabIndex = 0;
            this.pnl_SectionSelectorButton.Tag = "3";
            // 
            // lbl_Section
            // 
            this.lbl_Section.AutoSize = true;
            this.lbl_Section.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Section.ForeColor = System.Drawing.Color.White;
            this.lbl_Section.Location = new System.Drawing.Point(12, 25);
            this.lbl_Section.Name = "lbl_Section";
            this.lbl_Section.Size = new System.Drawing.Size(81, 13);
            this.lbl_Section.TabIndex = 0;
            this.lbl_Section.Text = "Not Selected";
            // 
            // bunifuCustomLabel27
            // 
            this.bunifuCustomLabel27.AutoSize = true;
            this.bunifuCustomLabel27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.bunifuCustomLabel27.Location = new System.Drawing.Point(12, 9);
            this.bunifuCustomLabel27.Name = "bunifuCustomLabel27";
            this.bunifuCustomLabel27.Size = new System.Drawing.Size(80, 13);
            this.bunifuCustomLabel27.TabIndex = 0;
            this.bunifuCustomLabel27.Text = "Current Section";
            // 
            // pnl_PerformanceSelectorButton
            // 
            this.pnl_PerformanceSelectorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.pnl_PerformanceSelectorButton.Controls.Add(this.lbl_Performance);
            this.pnl_PerformanceSelectorButton.Controls.Add(this.bunifuCustomLabel17);
            this.pnl_PerformanceSelectorButton.Location = new System.Drawing.Point(176, 0);
            this.pnl_PerformanceSelectorButton.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_PerformanceSelectorButton.Name = "pnl_PerformanceSelectorButton";
            this.pnl_PerformanceSelectorButton.Size = new System.Drawing.Size(175, 50);
            this.pnl_PerformanceSelectorButton.TabIndex = 0;
            this.pnl_PerformanceSelectorButton.Tag = "2";
            // 
            // lbl_Performance
            // 
            this.lbl_Performance.AutoSize = true;
            this.lbl_Performance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Performance.ForeColor = System.Drawing.Color.White;
            this.lbl_Performance.Location = new System.Drawing.Point(9, 25);
            this.lbl_Performance.Name = "lbl_Performance";
            this.lbl_Performance.Size = new System.Drawing.Size(81, 13);
            this.lbl_Performance.TabIndex = 0;
            this.lbl_Performance.Text = "Not Selected";
            // 
            // bunifuCustomLabel17
            // 
            this.bunifuCustomLabel17.AutoSize = true;
            this.bunifuCustomLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.bunifuCustomLabel17.Location = new System.Drawing.Point(9, 9);
            this.bunifuCustomLabel17.Name = "bunifuCustomLabel17";
            this.bunifuCustomLabel17.Size = new System.Drawing.Size(104, 13);
            this.bunifuCustomLabel17.TabIndex = 0;
            this.bunifuCustomLabel17.Text = "Current Performance";
            // 
            // pnl_CategorySelectorButton
            // 
            this.pnl_CategorySelectorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_CategorySelectorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.pnl_CategorySelectorButton.Controls.Add(this.lbl_Category);
            this.pnl_CategorySelectorButton.Controls.Add(this.bunifuCustomLabel29);
            this.pnl_CategorySelectorButton.Location = new System.Drawing.Point(628, 0);
            this.pnl_CategorySelectorButton.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_CategorySelectorButton.Name = "pnl_CategorySelectorButton";
            this.pnl_CategorySelectorButton.Size = new System.Drawing.Size(572, 50);
            this.pnl_CategorySelectorButton.TabIndex = 0;
            this.pnl_CategorySelectorButton.Tag = "4";
            // 
            // lbl_Category
            // 
            this.lbl_Category.AutoSize = true;
            this.lbl_Category.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Category.ForeColor = System.Drawing.Color.White;
            this.lbl_Category.Location = new System.Drawing.Point(11, 25);
            this.lbl_Category.Name = "lbl_Category";
            this.lbl_Category.Size = new System.Drawing.Size(81, 13);
            this.lbl_Category.TabIndex = 0;
            this.lbl_Category.Text = "Not Selected";
            // 
            // bunifuCustomLabel29
            // 
            this.bunifuCustomLabel29.AutoSize = true;
            this.bunifuCustomLabel29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.bunifuCustomLabel29.Location = new System.Drawing.Point(11, 9);
            this.bunifuCustomLabel29.Name = "bunifuCustomLabel29";
            this.bunifuCustomLabel29.Size = new System.Drawing.Size(86, 13);
            this.bunifuCustomLabel29.TabIndex = 0;
            this.bunifuCustomLabel29.Text = "Current Category";
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
            // DataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.dgv_dataViewerDgv);
            this.Controls.Add(this.pnl_MainNavigation);
            this.Controls.Add(this.pnl_TopUIPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DataViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataViewer";
            this.pnl_topPanel.ResumeLayout(false);
            this.pnl_title.ResumeLayout(false);
            this.pnl_title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dataViewerDgv)).EndInit();
            this.pnl_TopUIPanel.ResumeLayout(false);
            this.pnl_MainNavigation.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.pnl_CountrySelectorButton.ResumeLayout(false);
            this.pnl_CountrySelectorButton.PerformLayout();
            this.pnl_SectionSelectorButton.ResumeLayout(false);
            this.pnl_SectionSelectorButton.PerformLayout();
            this.pnl_PerformanceSelectorButton.ResumeLayout(false);
            this.pnl_PerformanceSelectorButton.PerformLayout();
            this.pnl_CategorySelectorButton.ResumeLayout(false);
            this.pnl_CategorySelectorButton.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuDragControl topPanelDragCntl;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgv_dataViewerDgv;
        private System.Windows.Forms.Panel pnl_TopUIPanel;
        private System.Windows.Forms.Panel pnl_topPanel;
        private System.Windows.Forms.Panel pnl_Minimize;
        private System.Windows.Forms.Panel pnl_Maximize;
        private System.Windows.Forms.Panel pnl_Close;
        private System.Windows.Forms.Panel pnl_title;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_title;
        private System.Windows.Forms.Panel pnl_Logo;
        private System.Windows.Forms.Panel pnl_MainNavigation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.Panel pnl_CountrySelectorButton;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_Country;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private System.Windows.Forms.Panel pnl_SectionSelectorButton;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_Section;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel27;
        private System.Windows.Forms.Panel pnl_PerformanceSelectorButton;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_Performance;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel17;
        private System.Windows.Forms.Panel pnl_CategorySelectorButton;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_Category;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel29;
        private Bunifu.Framework.UI.BunifuDragControl dc_logoDragControl;
        private Bunifu.Framework.UI.BunifuDragControl dc_titlePanelDragControl;
        private Bunifu.Framework.UI.BunifuDragControl dc_titleDragControl;
    }
}