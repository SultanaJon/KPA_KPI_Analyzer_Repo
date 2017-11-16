namespace KPA_KPI_Analyzer.Correlation
{
    partial class CorrelationConfiguration
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
            this.dc_topPanel = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.dc_title = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.dc_titlePanel = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.dc_logo = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnl_topPanel = new System.Windows.Forms.Panel();
            this.pnl_logo = new System.Windows.Forms.Panel();
            this.pnl_titlePanel = new System.Windows.Forms.Panel();
            this.lbl_title = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnl_Close = new System.Windows.Forms.Panel();
            this.pnl_Minimize = new System.Windows.Forms.Panel();
            this.pnl_TopUIPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dp_PRFromDate = new Bunifu.Framework.UI.BunifuDatepicker();
            this.lbl_poLineCreationDateRage = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dp_POFromDate = new Bunifu.Framework.UI.BunifuDatepicker();
            this.dp_PRToDate = new Bunifu.Framework.UI.BunifuDatepicker();
            this.dp_POToDate = new Bunifu.Framework.UI.BunifuDatepicker();
            this.chkBox_PrDateRange = new Bunifu.Framework.UI.BunifuCheckbox();
            this.chkBox_PoDateRange = new Bunifu.Framework.UI.BunifuCheckbox();
            this.lbl_prDateRange = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btn_startCorrelation = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnl_topPanel.SuspendLayout();
            this.pnl_titlePanel.SuspendLayout();
            this.pnl_TopUIPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dc_topPanel
            // 
            this.dc_topPanel.Fixed = true;
            this.dc_topPanel.Horizontal = true;
            this.dc_topPanel.TargetControl = this.pnl_topPanel;
            this.dc_topPanel.Vertical = true;
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
            // dc_logo
            // 
            this.dc_logo.Fixed = true;
            this.dc_logo.Horizontal = true;
            this.dc_logo.TargetControl = this.pnl_logo;
            this.dc_logo.Vertical = true;
            // 
            // pnl_topPanel
            // 
            this.pnl_topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.pnl_topPanel.Controls.Add(this.pnl_Minimize);
            this.pnl_topPanel.Controls.Add(this.pnl_Close);
            this.pnl_topPanel.Controls.Add(this.pnl_titlePanel);
            this.pnl_topPanel.Controls.Add(this.pnl_logo);
            this.pnl_topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_topPanel.Location = new System.Drawing.Point(0, 0);
            this.pnl_topPanel.Name = "pnl_topPanel";
            this.pnl_topPanel.Size = new System.Drawing.Size(648, 25);
            this.pnl_topPanel.TabIndex = 0;
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
            // pnl_titlePanel
            // 
            this.pnl_titlePanel.Controls.Add(this.lbl_title);
            this.pnl_titlePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_titlePanel.Location = new System.Drawing.Point(50, 0);
            this.pnl_titlePanel.Name = "pnl_titlePanel";
            this.pnl_titlePanel.Size = new System.Drawing.Size(213, 25);
            this.pnl_titlePanel.TabIndex = 1;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lbl_title.Location = new System.Drawing.Point(8, 6);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(189, 13);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "KPA - KPI Analyzer - Correlation Config";
            // 
            // pnl_Close
            // 
            this.pnl_Close.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.Close;
            this.pnl_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Close.Location = new System.Drawing.Point(598, 0);
            this.pnl_Close.Name = "pnl_Close";
            this.pnl_Close.Size = new System.Drawing.Size(50, 25);
            this.pnl_Close.TabIndex = 2;
            this.pnl_Close.Click += new System.EventHandler(this.btn_Close_Click);
            this.pnl_Close.MouseLeave += new System.EventHandler(this.btn_Close_MouseLeave);
            this.pnl_Close.MouseHover += new System.EventHandler(this.btn_Close_MouseHover);
            // 
            // pnl_Minimize
            // 
            this.pnl_Minimize.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.Minimize;
            this.pnl_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_Minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Minimize.Location = new System.Drawing.Point(548, 0);
            this.pnl_Minimize.Name = "pnl_Minimize";
            this.pnl_Minimize.Size = new System.Drawing.Size(50, 25);
            this.pnl_Minimize.TabIndex = 4;
            this.pnl_Minimize.Click += new System.EventHandler(this.btn_Minimize_Click);
            this.pnl_Minimize.MouseEnter += new System.EventHandler(this.btn_Minimize_MouseEnter);
            this.pnl_Minimize.MouseHover += new System.EventHandler(this.btn_Minimize_MouseLeave);
            // 
            // pnl_TopUIPanel
            // 
            this.pnl_TopUIPanel.BackColor = System.Drawing.Color.Black;
            this.pnl_TopUIPanel.Controls.Add(this.pnl_topPanel);
            this.pnl_TopUIPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_TopUIPanel.Location = new System.Drawing.Point(0, 0);
            this.pnl_TopUIPanel.Name = "pnl_TopUIPanel";
            this.pnl_TopUIPanel.Size = new System.Drawing.Size(648, 26);
            this.pnl_TopUIPanel.TabIndex = 57;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_prDateRange);
            this.panel1.Controls.Add(this.chkBox_PoDateRange);
            this.panel1.Controls.Add(this.chkBox_PrDateRange);
            this.panel1.Controls.Add(this.dp_POToDate);
            this.panel1.Controls.Add(this.dp_PRToDate);
            this.panel1.Controls.Add(this.dp_POFromDate);
            this.panel1.Controls.Add(this.lbl_poLineCreationDateRage);
            this.panel1.Controls.Add(this.dp_PRFromDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 148);
            this.panel1.TabIndex = 1;
            // 
            // dp_PRFromDate
            // 
            this.dp_PRFromDate.BackColor = System.Drawing.Color.LightGray;
            this.dp_PRFromDate.BorderRadius = 1;
            this.dp_PRFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.dp_PRFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp_PRFromDate.FormatCustom = "MMMM dd, yyyy";
            this.dp_PRFromDate.Location = new System.Drawing.Point(9, 39);
            this.dp_PRFromDate.Name = "dp_PRFromDate";
            this.dp_PRFromDate.Size = new System.Drawing.Size(224, 29);
            this.dp_PRFromDate.TabIndex = 8;
            this.dp_PRFromDate.Tag = "0";
            this.dp_PRFromDate.Value = new System.DateTime(2017, 7, 5, 12, 11, 51, 273);
            // 
            // lbl_poLineCreationDateRage
            // 
            this.lbl_poLineCreationDateRage.AutoSize = true;
            this.lbl_poLineCreationDateRage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_poLineCreationDateRage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lbl_poLineCreationDateRage.Location = new System.Drawing.Point(35, 83);
            this.lbl_poLineCreationDateRage.Name = "lbl_poLineCreationDateRage";
            this.lbl_poLineCreationDateRage.Size = new System.Drawing.Size(179, 13);
            this.lbl_poLineCreationDateRage.TabIndex = 4;
            this.lbl_poLineCreationDateRage.Text = "PO Line Creation Date Range:";
            // 
            // dp_POFromDate
            // 
            this.dp_POFromDate.BackColor = System.Drawing.Color.LightGray;
            this.dp_POFromDate.BorderRadius = 1;
            this.dp_POFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.dp_POFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp_POFromDate.FormatCustom = "MMMM dd, yyyy";
            this.dp_POFromDate.Location = new System.Drawing.Point(9, 105);
            this.dp_POFromDate.Name = "dp_POFromDate";
            this.dp_POFromDate.Size = new System.Drawing.Size(224, 29);
            this.dp_POFromDate.TabIndex = 7;
            this.dp_POFromDate.Tag = "2";
            this.dp_POFromDate.Value = new System.DateTime(2017, 7, 5, 12, 11, 51, 273);
            // 
            // dp_PRToDate
            // 
            this.dp_PRToDate.BackColor = System.Drawing.Color.LightGray;
            this.dp_PRToDate.BorderRadius = 1;
            this.dp_PRToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.dp_PRToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp_PRToDate.FormatCustom = "MMMM dd, yyyy";
            this.dp_PRToDate.Location = new System.Drawing.Point(261, 39);
            this.dp_PRToDate.Name = "dp_PRToDate";
            this.dp_PRToDate.Size = new System.Drawing.Size(224, 29);
            this.dp_PRToDate.TabIndex = 6;
            this.dp_PRToDate.Tag = "1";
            this.dp_PRToDate.Value = new System.DateTime(2017, 7, 5, 12, 11, 51, 273);
            // 
            // dp_POToDate
            // 
            this.dp_POToDate.BackColor = System.Drawing.Color.LightGray;
            this.dp_POToDate.BorderRadius = 1;
            this.dp_POToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.dp_POToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp_POToDate.FormatCustom = "MMMM dd, yyyy";
            this.dp_POToDate.Location = new System.Drawing.Point(261, 105);
            this.dp_POToDate.Name = "dp_POToDate";
            this.dp_POToDate.Size = new System.Drawing.Size(224, 29);
            this.dp_POToDate.TabIndex = 5;
            this.dp_POToDate.Tag = "3";
            this.dp_POToDate.Value = new System.DateTime(2017, 7, 5, 12, 11, 51, 273);
            // 
            // chkBox_PrDateRange
            // 
            this.chkBox_PrDateRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.chkBox_PrDateRange.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.chkBox_PrDateRange.Checked = false;
            this.chkBox_PrDateRange.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(198)))), ((int)(((byte)(187)))));
            this.chkBox_PrDateRange.ForeColor = System.Drawing.Color.White;
            this.chkBox_PrDateRange.Location = new System.Drawing.Point(9, 12);
            this.chkBox_PrDateRange.Name = "chkBox_PrDateRange";
            this.chkBox_PrDateRange.Size = new System.Drawing.Size(20, 20);
            this.chkBox_PrDateRange.TabIndex = 10;
            // 
            // chkBox_PoDateRange
            // 
            this.chkBox_PoDateRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.chkBox_PoDateRange.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.chkBox_PoDateRange.Checked = false;
            this.chkBox_PoDateRange.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(198)))), ((int)(((byte)(187)))));
            this.chkBox_PoDateRange.ForeColor = System.Drawing.Color.White;
            this.chkBox_PoDateRange.Location = new System.Drawing.Point(9, 79);
            this.chkBox_PoDateRange.Name = "chkBox_PoDateRange";
            this.chkBox_PoDateRange.Size = new System.Drawing.Size(20, 20);
            this.chkBox_PoDateRange.TabIndex = 9;
            // 
            // lbl_prDateRange
            // 
            this.lbl_prDateRange.AutoSize = true;
            this.lbl_prDateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_prDateRange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lbl_prDateRange.Location = new System.Drawing.Point(35, 16);
            this.lbl_prDateRange.Name = "lbl_prDateRange";
            this.lbl_prDateRange.Size = new System.Drawing.Size(100, 13);
            this.lbl_prDateRange.TabIndex = 11;
            this.lbl_prDateRange.Text = "PR Date Range:";
            // 
            // btn_startCorrelation
            // 
            this.btn_startCorrelation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.btn_startCorrelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_startCorrelation.FlatAppearance.BorderSize = 0;
            this.btn_startCorrelation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_startCorrelation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btn_startCorrelation.Location = new System.Drawing.Point(0, 154);
            this.btn_startCorrelation.Margin = new System.Windows.Forms.Padding(0);
            this.btn_startCorrelation.Name = "btn_startCorrelation";
            this.btn_startCorrelation.Size = new System.Drawing.Size(648, 29);
            this.btn_startCorrelation.TabIndex = 0;
            this.btn_startCorrelation.Text = "Start Correlation";
            this.btn_startCorrelation.UseVisualStyleBackColor = false;
            this.btn_startCorrelation.Click += new System.EventHandler(this.btn_startCorrelation_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_startCorrelation, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.15301F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.84699F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(648, 183);
            this.tableLayoutPanel1.TabIndex = 58;
            // 
            // CorrelationConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 209);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pnl_TopUIPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CorrelationConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CorrelationConfiguration";
            this.pnl_topPanel.ResumeLayout(false);
            this.pnl_titlePanel.ResumeLayout(false);
            this.pnl_titlePanel.PerformLayout();
            this.pnl_TopUIPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl dc_topPanel;
        private System.Windows.Forms.Panel pnl_topPanel;
        private System.Windows.Forms.Panel pnl_Minimize;
        private System.Windows.Forms.Panel pnl_Close;
        private System.Windows.Forms.Panel pnl_titlePanel;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_title;
        private System.Windows.Forms.Panel pnl_logo;
        private Bunifu.Framework.UI.BunifuDragControl dc_title;
        private Bunifu.Framework.UI.BunifuDragControl dc_titlePanel;
        private Bunifu.Framework.UI.BunifuDragControl dc_logo;
        private System.Windows.Forms.Panel pnl_TopUIPanel;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_prDateRange;
        private Bunifu.Framework.UI.BunifuCheckbox chkBox_PoDateRange;
        private Bunifu.Framework.UI.BunifuCheckbox chkBox_PrDateRange;
        private Bunifu.Framework.UI.BunifuDatepicker dp_POToDate;
        private Bunifu.Framework.UI.BunifuDatepicker dp_PRToDate;
        private Bunifu.Framework.UI.BunifuDatepicker dp_POFromDate;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_poLineCreationDateRage;
        private Bunifu.Framework.UI.BunifuDatepicker dp_PRFromDate;
        private System.Windows.Forms.Button btn_startCorrelation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}