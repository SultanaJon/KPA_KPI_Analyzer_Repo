namespace KPA_KPI_Analyzer.Correlation
{
    partial class CorrelationConfigurationWindow
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
            this.pnl_TopUIPanel = new System.Windows.Forms.Panel();
            this.pnl_topPanel = new System.Windows.Forms.Panel();
            this.pnl_Minimize = new System.Windows.Forms.Panel();
            this.pnl_Close = new System.Windows.Forms.Panel();
            this.pnl_TitlePanel = new System.Windows.Forms.Panel();
            this.lbl_WindowTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnl_WindowLogo = new System.Windows.Forms.Panel();
            this.CorrellationTopPanelDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.WindowTitleDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.WindowTitlePanelDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.LogoPanelDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox_dateRange = new System.Windows.Forms.GroupBox();
            this.chkBox_PoDateRange = new Bunifu.Framework.UI.BunifuCheckbox();
            this.chkBox_PrDateRange = new Bunifu.Framework.UI.BunifuCheckbox();
            this.bunifuCustomLabel7 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dp_POToDate = new Bunifu.Framework.UI.BunifuDatepicker();
            this.dp_PRToDate = new Bunifu.Framework.UI.BunifuDatepicker();
            this.dp_POFromDate = new Bunifu.Framework.UI.BunifuDatepicker();
            this.lbl_PODateRange = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dp_PRFromDate = new Bunifu.Framework.UI.BunifuDatepicker();
            this.lbl_PRDateRange = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lbl_DateRangesGroupBox = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.chkdBox_DateRanges = new Bunifu.Framework.UI.BunifuCheckbox();
            this.groupBox_AdditionalFeatures = new System.Windows.Forms.GroupBox();
            this.chkdListBox_addFeatures = new System.Windows.Forms.CheckedListBox();
            this.lbl_AddFeatGroupBox = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.chkdBox_AddFeatGroupBox = new Bunifu.Framework.UI.BunifuCheckbox();
            this.groupBox_Variables = new System.Windows.Forms.GroupBox();
            this.chkdListBox_variables = new System.Windows.Forms.CheckedListBox();
            this.btn_StartCorrelation = new System.Windows.Forms.Button();
            this.pnl_TopUIPanel.SuspendLayout();
            this.pnl_topPanel.SuspendLayout();
            this.pnl_TitlePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox_dateRange.SuspendLayout();
            this.groupBox_AdditionalFeatures.SuspendLayout();
            this.groupBox_Variables.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_TopUIPanel
            // 
            this.pnl_TopUIPanel.BackColor = System.Drawing.Color.Black;
            this.pnl_TopUIPanel.Controls.Add(this.pnl_topPanel);
            this.pnl_TopUIPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_TopUIPanel.Location = new System.Drawing.Point(0, 0);
            this.pnl_TopUIPanel.Name = "pnl_TopUIPanel";
            this.pnl_TopUIPanel.Size = new System.Drawing.Size(531, 26);
            this.pnl_TopUIPanel.TabIndex = 57;
            // 
            // pnl_topPanel
            // 
            this.pnl_topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.pnl_topPanel.Controls.Add(this.pnl_Minimize);
            this.pnl_topPanel.Controls.Add(this.pnl_Close);
            this.pnl_topPanel.Controls.Add(this.pnl_TitlePanel);
            this.pnl_topPanel.Controls.Add(this.pnl_WindowLogo);
            this.pnl_topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_topPanel.Location = new System.Drawing.Point(0, 0);
            this.pnl_topPanel.Name = "pnl_topPanel";
            this.pnl_topPanel.Size = new System.Drawing.Size(531, 25);
            this.pnl_topPanel.TabIndex = 0;
            // 
            // pnl_Minimize
            // 
            this.pnl_Minimize.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.Minimize;
            this.pnl_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_Minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Minimize.Location = new System.Drawing.Point(431, 0);
            this.pnl_Minimize.Name = "pnl_Minimize";
            this.pnl_Minimize.Size = new System.Drawing.Size(50, 25);
            this.pnl_Minimize.TabIndex = 4;
            this.pnl_Minimize.Click += new System.EventHandler(this.btn_Minimize_Click);
            this.pnl_Minimize.MouseEnter += new System.EventHandler(this.btn_Minimize_MouseEnter);
            this.pnl_Minimize.MouseLeave += new System.EventHandler(this.btn_Minimize_MouseLeave);
            // 
            // pnl_Close
            // 
            this.pnl_Close.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.Close;
            this.pnl_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Close.Location = new System.Drawing.Point(481, 0);
            this.pnl_Close.Name = "pnl_Close";
            this.pnl_Close.Size = new System.Drawing.Size(50, 25);
            this.pnl_Close.TabIndex = 2;
            this.pnl_Close.Click += new System.EventHandler(this.btn_Close_Click);
            this.pnl_Close.MouseLeave += new System.EventHandler(this.btn_Close_MouseLeave);
            this.pnl_Close.MouseHover += new System.EventHandler(this.btn_Close_MouseHover);
            // 
            // pnl_TitlePanel
            // 
            this.pnl_TitlePanel.Controls.Add(this.lbl_WindowTitle);
            this.pnl_TitlePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_TitlePanel.Location = new System.Drawing.Point(50, 0);
            this.pnl_TitlePanel.Name = "pnl_TitlePanel";
            this.pnl_TitlePanel.Size = new System.Drawing.Size(195, 25);
            this.pnl_TitlePanel.TabIndex = 1;
            // 
            // lbl_WindowTitle
            // 
            this.lbl_WindowTitle.AutoSize = true;
            this.lbl_WindowTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lbl_WindowTitle.Location = new System.Drawing.Point(8, 6);
            this.lbl_WindowTitle.Name = "lbl_WindowTitle";
            this.lbl_WindowTitle.Size = new System.Drawing.Size(180, 13);
            this.lbl_WindowTitle.TabIndex = 0;
            this.lbl_WindowTitle.Text = "KPA - KPI Analyzer - Correlation Tool";
            // 
            // pnl_WindowLogo
            // 
            this.pnl_WindowLogo.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.comau_logo;
            this.pnl_WindowLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_WindowLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_WindowLogo.Location = new System.Drawing.Point(0, 0);
            this.pnl_WindowLogo.Name = "pnl_WindowLogo";
            this.pnl_WindowLogo.Size = new System.Drawing.Size(50, 25);
            this.pnl_WindowLogo.TabIndex = 0;
            // 
            // CorrellationTopPanelDragControl
            // 
            this.CorrellationTopPanelDragControl.Fixed = true;
            this.CorrellationTopPanelDragControl.Horizontal = true;
            this.CorrellationTopPanelDragControl.TargetControl = this.pnl_topPanel;
            this.CorrellationTopPanelDragControl.Vertical = true;
            // 
            // WindowTitleDragControl
            // 
            this.WindowTitleDragControl.Fixed = true;
            this.WindowTitleDragControl.Horizontal = true;
            this.WindowTitleDragControl.TargetControl = this.lbl_WindowTitle;
            this.WindowTitleDragControl.Vertical = true;
            // 
            // WindowTitlePanelDragControl
            // 
            this.WindowTitlePanelDragControl.Fixed = true;
            this.WindowTitlePanelDragControl.Horizontal = true;
            this.WindowTitlePanelDragControl.TargetControl = this.pnl_TitlePanel;
            this.WindowTitlePanelDragControl.Vertical = true;
            // 
            // LogoPanelDragControl
            // 
            this.LogoPanelDragControl.Fixed = true;
            this.LogoPanelDragControl.Horizontal = true;
            this.LogoPanelDragControl.TargetControl = this.pnl_WindowLogo;
            this.LogoPanelDragControl.Vertical = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.panel1.Size = new System.Drawing.Size(531, 499);
            this.panel1.TabIndex = 60;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Controls.Add(this.groupBox_dateRange);
            this.flowLayoutPanel1.Controls.Add(this.groupBox_AdditionalFeatures);
            this.flowLayoutPanel1.Controls.Add(this.groupBox_Variables);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(20, 0, 1, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(529, 499);
            this.flowLayoutPanel1.TabIndex = 59;
            // 
            // groupBox_dateRange
            // 
            this.groupBox_dateRange.Controls.Add(this.chkBox_PoDateRange);
            this.groupBox_dateRange.Controls.Add(this.chkBox_PrDateRange);
            this.groupBox_dateRange.Controls.Add(this.bunifuCustomLabel7);
            this.groupBox_dateRange.Controls.Add(this.bunifuCustomLabel5);
            this.groupBox_dateRange.Controls.Add(this.dp_POToDate);
            this.groupBox_dateRange.Controls.Add(this.dp_PRToDate);
            this.groupBox_dateRange.Controls.Add(this.dp_POFromDate);
            this.groupBox_dateRange.Controls.Add(this.lbl_PODateRange);
            this.groupBox_dateRange.Controls.Add(this.dp_PRFromDate);
            this.groupBox_dateRange.Controls.Add(this.lbl_PRDateRange);
            this.groupBox_dateRange.Controls.Add(this.lbl_DateRangesGroupBox);
            this.groupBox_dateRange.Controls.Add(this.chkdBox_DateRanges);
            this.groupBox_dateRange.Location = new System.Drawing.Point(13, 13);
            this.groupBox_dateRange.Name = "groupBox_dateRange";
            this.groupBox_dateRange.Size = new System.Drawing.Size(502, 173);
            this.groupBox_dateRange.TabIndex = 60;
            this.groupBox_dateRange.TabStop = false;
            // 
            // chkBox_PoDateRange
            // 
            this.chkBox_PoDateRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.chkBox_PoDateRange.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.chkBox_PoDateRange.Checked = false;
            this.chkBox_PoDateRange.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(198)))), ((int)(((byte)(187)))));
            this.chkBox_PoDateRange.ForeColor = System.Drawing.Color.White;
            this.chkBox_PoDateRange.Location = new System.Drawing.Point(8, 99);
            this.chkBox_PoDateRange.Name = "chkBox_PoDateRange";
            this.chkBox_PoDateRange.Size = new System.Drawing.Size(20, 20);
            this.chkBox_PoDateRange.TabIndex = 12;
            // 
            // chkBox_PrDateRange
            // 
            this.chkBox_PrDateRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.chkBox_PrDateRange.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.chkBox_PrDateRange.Checked = false;
            this.chkBox_PrDateRange.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(198)))), ((int)(((byte)(187)))));
            this.chkBox_PrDateRange.ForeColor = System.Drawing.Color.White;
            this.chkBox_PrDateRange.Location = new System.Drawing.Point(8, 32);
            this.chkBox_PrDateRange.Name = "chkBox_PrDateRange";
            this.chkBox_PrDateRange.Size = new System.Drawing.Size(20, 20);
            this.chkBox_PrDateRange.TabIndex = 13;
            // 
            // bunifuCustomLabel7
            // 
            this.bunifuCustomLabel7.AutoSize = true;
            this.bunifuCustomLabel7.Location = new System.Drawing.Point(238, 129);
            this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
            this.bunifuCustomLabel7.Size = new System.Drawing.Size(16, 13);
            this.bunifuCustomLabel7.TabIndex = 10;
            this.bunifuCustomLabel7.Text = "to";
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(238, 65);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(16, 13);
            this.bunifuCustomLabel5.TabIndex = 11;
            this.bunifuCustomLabel5.Text = "to";
            // 
            // dp_POToDate
            // 
            this.dp_POToDate.BackColor = System.Drawing.Color.LightGray;
            this.dp_POToDate.BorderRadius = 1;
            this.dp_POToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.dp_POToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp_POToDate.FormatCustom = "MMMM dd, yyyy";
            this.dp_POToDate.Location = new System.Drawing.Point(260, 125);
            this.dp_POToDate.Name = "dp_POToDate";
            this.dp_POToDate.Size = new System.Drawing.Size(224, 29);
            this.dp_POToDate.TabIndex = 6;
            this.dp_POToDate.Tag = "3";
            this.dp_POToDate.Value = new System.DateTime(2017, 7, 5, 12, 11, 51, 273);
            // 
            // dp_PRToDate
            // 
            this.dp_PRToDate.BackColor = System.Drawing.Color.LightGray;
            this.dp_PRToDate.BorderRadius = 1;
            this.dp_PRToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.dp_PRToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp_PRToDate.FormatCustom = "MMMM dd, yyyy";
            this.dp_PRToDate.Location = new System.Drawing.Point(260, 59);
            this.dp_PRToDate.Name = "dp_PRToDate";
            this.dp_PRToDate.Size = new System.Drawing.Size(224, 29);
            this.dp_PRToDate.TabIndex = 7;
            this.dp_PRToDate.Tag = "1";
            this.dp_PRToDate.Value = new System.DateTime(2017, 7, 5, 12, 11, 51, 273);
            // 
            // dp_POFromDate
            // 
            this.dp_POFromDate.BackColor = System.Drawing.Color.LightGray;
            this.dp_POFromDate.BorderRadius = 1;
            this.dp_POFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.dp_POFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp_POFromDate.FormatCustom = "MMMM dd, yyyy";
            this.dp_POFromDate.Location = new System.Drawing.Point(8, 125);
            this.dp_POFromDate.Name = "dp_POFromDate";
            this.dp_POFromDate.Size = new System.Drawing.Size(224, 29);
            this.dp_POFromDate.TabIndex = 8;
            this.dp_POFromDate.Tag = "2";
            this.dp_POFromDate.Value = new System.DateTime(2017, 7, 5, 12, 11, 51, 273);
            // 
            // lbl_PODateRange
            // 
            this.lbl_PODateRange.AutoSize = true;
            this.lbl_PODateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PODateRange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lbl_PODateRange.Location = new System.Drawing.Point(33, 103);
            this.lbl_PODateRange.Name = "lbl_PODateRange";
            this.lbl_PODateRange.Size = new System.Drawing.Size(86, 13);
            this.lbl_PODateRange.TabIndex = 4;
            this.lbl_PODateRange.Text = "PO Date Range:";
            // 
            // dp_PRFromDate
            // 
            this.dp_PRFromDate.BackColor = System.Drawing.Color.LightGray;
            this.dp_PRFromDate.BorderRadius = 1;
            this.dp_PRFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.dp_PRFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp_PRFromDate.FormatCustom = "MMMM dd, yyyy";
            this.dp_PRFromDate.Location = new System.Drawing.Point(8, 59);
            this.dp_PRFromDate.Name = "dp_PRFromDate";
            this.dp_PRFromDate.Size = new System.Drawing.Size(224, 29);
            this.dp_PRFromDate.TabIndex = 9;
            this.dp_PRFromDate.Tag = "0";
            this.dp_PRFromDate.Value = new System.DateTime(2017, 7, 5, 12, 11, 51, 273);
            // 
            // lbl_PRDateRange
            // 
            this.lbl_PRDateRange.AutoSize = true;
            this.lbl_PRDateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PRDateRange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lbl_PRDateRange.Location = new System.Drawing.Point(32, 35);
            this.lbl_PRDateRange.Name = "lbl_PRDateRange";
            this.lbl_PRDateRange.Size = new System.Drawing.Size(86, 13);
            this.lbl_PRDateRange.TabIndex = 5;
            this.lbl_PRDateRange.Text = "PR Date Range:";
            // 
            // lbl_DateRangesGroupBox
            // 
            this.lbl_DateRangesGroupBox.AutoSize = true;
            this.lbl_DateRangesGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lbl_DateRangesGroupBox.Location = new System.Drawing.Point(30, 3);
            this.lbl_DateRangesGroupBox.Name = "lbl_DateRangesGroupBox";
            this.lbl_DateRangesGroupBox.Size = new System.Drawing.Size(70, 13);
            this.lbl_DateRangesGroupBox.TabIndex = 1;
            this.lbl_DateRangesGroupBox.Text = "Date Ranges";
            // 
            // chkdBox_DateRanges
            // 
            this.chkdBox_DateRanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.chkdBox_DateRanges.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.chkdBox_DateRanges.Checked = false;
            this.chkdBox_DateRanges.CheckedOnColor = System.Drawing.Color.IndianRed;
            this.chkdBox_DateRanges.ForeColor = System.Drawing.Color.White;
            this.chkdBox_DateRanges.Location = new System.Drawing.Point(8, 0);
            this.chkdBox_DateRanges.Name = "chkdBox_DateRanges";
            this.chkdBox_DateRanges.Size = new System.Drawing.Size(20, 20);
            this.chkdBox_DateRanges.TabIndex = 0;
            this.chkdBox_DateRanges.Tag = "0";
            this.chkdBox_DateRanges.OnChange += new System.EventHandler(this.CheckBoxGroupBox_OnChange);
            // 
            // groupBox_AdditionalFeatures
            // 
            this.groupBox_AdditionalFeatures.Controls.Add(this.chkdListBox_addFeatures);
            this.groupBox_AdditionalFeatures.Controls.Add(this.lbl_AddFeatGroupBox);
            this.groupBox_AdditionalFeatures.Controls.Add(this.chkdBox_AddFeatGroupBox);
            this.groupBox_AdditionalFeatures.Location = new System.Drawing.Point(13, 192);
            this.groupBox_AdditionalFeatures.Name = "groupBox_AdditionalFeatures";
            this.groupBox_AdditionalFeatures.Size = new System.Drawing.Size(161, 172);
            this.groupBox_AdditionalFeatures.TabIndex = 63;
            this.groupBox_AdditionalFeatures.TabStop = false;
            // 
            // chkdListBox_addFeatures
            // 
            this.chkdListBox_addFeatures.BackColor = System.Drawing.SystemColors.Control;
            this.chkdListBox_addFeatures.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkdListBox_addFeatures.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.chkdListBox_addFeatures.FormattingEnabled = true;
            this.chkdListBox_addFeatures.Items.AddRange(new object[] {
            "Mean",
            "Standard Deviation",
            "Variance",
            "Sum",
            "Min",
            "Max",
            "Mode",
            "Median",
            "Range"});
            this.chkdListBox_addFeatures.Location = new System.Drawing.Point(8, 26);
            this.chkdListBox_addFeatures.Name = "chkdListBox_addFeatures";
            this.chkdListBox_addFeatures.Size = new System.Drawing.Size(140, 135);
            this.chkdListBox_addFeatures.TabIndex = 2;
            // 
            // lbl_AddFeatGroupBox
            // 
            this.lbl_AddFeatGroupBox.AutoSize = true;
            this.lbl_AddFeatGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lbl_AddFeatGroupBox.Location = new System.Drawing.Point(30, 3);
            this.lbl_AddFeatGroupBox.Name = "lbl_AddFeatGroupBox";
            this.lbl_AddFeatGroupBox.Size = new System.Drawing.Size(113, 13);
            this.lbl_AddFeatGroupBox.TabIndex = 1;
            this.lbl_AddFeatGroupBox.Text = "Additional Calculations";
            // 
            // chkdBox_AddFeatGroupBox
            // 
            this.chkdBox_AddFeatGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.chkdBox_AddFeatGroupBox.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.chkdBox_AddFeatGroupBox.Checked = false;
            this.chkdBox_AddFeatGroupBox.CheckedOnColor = System.Drawing.Color.IndianRed;
            this.chkdBox_AddFeatGroupBox.ForeColor = System.Drawing.Color.White;
            this.chkdBox_AddFeatGroupBox.Location = new System.Drawing.Point(8, 0);
            this.chkdBox_AddFeatGroupBox.Name = "chkdBox_AddFeatGroupBox";
            this.chkdBox_AddFeatGroupBox.Size = new System.Drawing.Size(20, 20);
            this.chkdBox_AddFeatGroupBox.TabIndex = 0;
            this.chkdBox_AddFeatGroupBox.Tag = "1";
            this.chkdBox_AddFeatGroupBox.OnChange += new System.EventHandler(this.CheckBoxGroupBox_OnChange);
            // 
            // groupBox_Variables
            // 
            this.groupBox_Variables.Controls.Add(this.chkdListBox_variables);
            this.groupBox_Variables.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.groupBox_Variables.Location = new System.Drawing.Point(180, 192);
            this.groupBox_Variables.Name = "groupBox_Variables";
            this.groupBox_Variables.Size = new System.Drawing.Size(157, 222);
            this.groupBox_Variables.TabIndex = 64;
            this.groupBox_Variables.TabStop = false;
            this.groupBox_Variables.Text = "Variables";
            // 
            // chkdListBox_variables
            // 
            this.chkdListBox_variables.BackColor = System.Drawing.SystemColors.Control;
            this.chkdListBox_variables.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkdListBox_variables.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.chkdListBox_variables.FormattingEnabled = true;
            this.chkdListBox_variables.Items.AddRange(new object[] {
            "PO Quantity",
            "PR Quantity",
            "PR Price",
            "PR Position Value",
            "PO Net Price",
            "PO Value",
            "Price Unit",
            "Planned Delivery Time",
            "Quantity Ordered",
            "Delivered",
            "Quantity Confirmed",
            "PO Source Time",
            "Open PR Quantity"});
            this.chkdListBox_variables.Location = new System.Drawing.Point(8, 19);
            this.chkdListBox_variables.Name = "chkdListBox_variables";
            this.chkdListBox_variables.Size = new System.Drawing.Size(140, 195);
            this.chkdListBox_variables.TabIndex = 0;
            // 
            // btn_StartCorrelation
            // 
            this.btn_StartCorrelation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.btn_StartCorrelation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_StartCorrelation.FlatAppearance.BorderSize = 0;
            this.btn_StartCorrelation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_StartCorrelation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btn_StartCorrelation.Location = new System.Drawing.Point(0, 525);
            this.btn_StartCorrelation.Name = "btn_StartCorrelation";
            this.btn_StartCorrelation.Size = new System.Drawing.Size(531, 29);
            this.btn_StartCorrelation.TabIndex = 61;
            this.btn_StartCorrelation.Text = "Start Correlation";
            this.btn_StartCorrelation.UseVisualStyleBackColor = false;
            this.btn_StartCorrelation.Click += new System.EventHandler(this.btn_StartCorrelation_Click);
            // 
            // CorrelationConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(531, 554);
            this.Controls.Add(this.btn_StartCorrelation);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_TopUIPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CorrelationConfigurationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CorrelationConfigurationWindow";
            this.Load += new System.EventHandler(this.CorrelationConfigurationWindow_Load);
            this.pnl_TopUIPanel.ResumeLayout(false);
            this.pnl_topPanel.ResumeLayout(false);
            this.pnl_TitlePanel.ResumeLayout(false);
            this.pnl_TitlePanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox_dateRange.ResumeLayout(false);
            this.groupBox_dateRange.PerformLayout();
            this.groupBox_AdditionalFeatures.ResumeLayout(false);
            this.groupBox_AdditionalFeatures.PerformLayout();
            this.groupBox_Variables.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_TopUIPanel;
        private System.Windows.Forms.Panel pnl_topPanel;
        private System.Windows.Forms.Panel pnl_Minimize;
        private System.Windows.Forms.Panel pnl_Close;
        private System.Windows.Forms.Panel pnl_TitlePanel;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_WindowTitle;
        private System.Windows.Forms.Panel pnl_WindowLogo;
        private Bunifu.Framework.UI.BunifuDragControl CorrellationTopPanelDragControl;
        private Bunifu.Framework.UI.BunifuDragControl WindowTitleDragControl;
        private Bunifu.Framework.UI.BunifuDragControl WindowTitlePanelDragControl;
        private Bunifu.Framework.UI.BunifuDragControl LogoPanelDragControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox_dateRange;
        private Bunifu.Framework.UI.BunifuCheckbox chkBox_PoDateRange;
        private Bunifu.Framework.UI.BunifuCheckbox chkBox_PrDateRange;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel7;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        private Bunifu.Framework.UI.BunifuDatepicker dp_POToDate;
        private Bunifu.Framework.UI.BunifuDatepicker dp_PRToDate;
        private Bunifu.Framework.UI.BunifuDatepicker dp_POFromDate;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_PODateRange;
        private Bunifu.Framework.UI.BunifuDatepicker dp_PRFromDate;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_PRDateRange;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_DateRangesGroupBox;
        private Bunifu.Framework.UI.BunifuCheckbox chkdBox_DateRanges;
        private System.Windows.Forms.GroupBox groupBox_AdditionalFeatures;
        private System.Windows.Forms.CheckedListBox chkdListBox_addFeatures;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_AddFeatGroupBox;
        private Bunifu.Framework.UI.BunifuCheckbox chkdBox_AddFeatGroupBox;
        private System.Windows.Forms.GroupBox groupBox_Variables;
        private System.Windows.Forms.CheckedListBox chkdListBox_variables;
        private System.Windows.Forms.Button btn_StartCorrelation;
    }
}