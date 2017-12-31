namespace Filters.Variants
{
    partial class VariantsDetailDisplayWindow
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
            this.pnl_titlePanel = new System.Windows.Forms.Panel();
            this.lbl_title = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnl_logo = new System.Windows.Forms.Panel();
            this.pnl_MainNavigation = new System.Windows.Forms.Panel();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.pnl_CountrySelectorButton = new System.Windows.Forms.Panel();
            this.lbl_VariantName = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lbl_VariantDescription = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel21 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bdc_logo = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bdc_title = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bdc_titlePanel = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bdc_topPanel = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ok = new System.Windows.Forms.Button();
            this.dgv_details = new System.Windows.Forms.DataGridView();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.prDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.poLineCreateDateRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finalRecDateRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdvancedFilters = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wbsElement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prPurchGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.poPurchGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.irSuppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fxdSuppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsrdSuppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.escaped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.poDocumentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodOrdMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_TopUIPanel.SuspendLayout();
            this.pnl_topPanel.SuspendLayout();
            this.pnl_titlePanel.SuspendLayout();
            this.pnl_MainNavigation.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.pnl_CountrySelectorButton.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_details)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_TopUIPanel
            // 
            this.pnl_TopUIPanel.BackColor = System.Drawing.Color.Black;
            this.pnl_TopUIPanel.Controls.Add(this.pnl_topPanel);
            this.pnl_TopUIPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_TopUIPanel.Location = new System.Drawing.Point(0, 0);
            this.pnl_TopUIPanel.Name = "pnl_TopUIPanel";
            this.pnl_TopUIPanel.Size = new System.Drawing.Size(986, 26);
            this.pnl_TopUIPanel.TabIndex = 59;
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
            this.pnl_topPanel.Size = new System.Drawing.Size(986, 25);
            this.pnl_topPanel.TabIndex = 0;
            // 
            // pnl_Minimize
            // 
            this.pnl_Minimize.BackgroundImage = Properties.Resources.Minimize;
            this.pnl_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_Minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Minimize.Location = new System.Drawing.Point(886, 0);
            this.pnl_Minimize.Name = "pnl_Minimize";
            this.pnl_Minimize.Size = new System.Drawing.Size(50, 25);
            this.pnl_Minimize.TabIndex = 4;
            this.pnl_Minimize.Click += new System.EventHandler(this.btn_Minimize_Click);
            this.pnl_Minimize.MouseEnter += new System.EventHandler(this.btn_Minimize_MouseEnter);
            this.pnl_Minimize.MouseLeave += new System.EventHandler(this.btn_Minimize_MouseLeave);
            // 
            // pnl_Close
            // 
            this.pnl_Close.BackgroundImage = Properties.Resources.Close;
            this.pnl_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Close.Location = new System.Drawing.Point(936, 0);
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
            this.pnl_titlePanel.Size = new System.Drawing.Size(185, 25);
            this.pnl_titlePanel.TabIndex = 1;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lbl_title.Location = new System.Drawing.Point(8, 6);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(165, 13);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "KPA - KPI Analyzer - Variant View";
            // 
            // pnl_logo
            // 
            this.pnl_logo.BackgroundImage = Properties.Resources.comau_logo;
            this.pnl_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_logo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_logo.Location = new System.Drawing.Point(0, 0);
            this.pnl_logo.Name = "pnl_logo";
            this.pnl_logo.Size = new System.Drawing.Size(50, 25);
            this.pnl_logo.TabIndex = 0;
            // 
            // pnl_MainNavigation
            // 
            this.pnl_MainNavigation.BackColor = System.Drawing.Color.Black;
            this.pnl_MainNavigation.Controls.Add(this.tableLayoutPanel14);
            this.pnl_MainNavigation.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_MainNavigation.Location = new System.Drawing.Point(0, 26);
            this.pnl_MainNavigation.Name = "pnl_MainNavigation";
            this.pnl_MainNavigation.Size = new System.Drawing.Size(986, 51);
            this.pnl_MainNavigation.TabIndex = 60;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 3;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Controls.Add(this.pnl_CountrySelectorButton, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.panel8, 2, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(986, 51);
            this.tableLayoutPanel14.TabIndex = 0;
            // 
            // pnl_CountrySelectorButton
            // 
            this.pnl_CountrySelectorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.pnl_CountrySelectorButton.Controls.Add(this.lbl_VariantName);
            this.pnl_CountrySelectorButton.Controls.Add(this.bunifuCustomLabel3);
            this.pnl_CountrySelectorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_CountrySelectorButton.Location = new System.Drawing.Point(0, 0);
            this.pnl_CountrySelectorButton.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_CountrySelectorButton.Name = "pnl_CountrySelectorButton";
            this.pnl_CountrySelectorButton.Size = new System.Drawing.Size(200, 51);
            this.pnl_CountrySelectorButton.TabIndex = 0;
            this.pnl_CountrySelectorButton.Tag = "1";
            // 
            // lbl_VariantName
            // 
            this.lbl_VariantName.AutoSize = true;
            this.lbl_VariantName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VariantName.ForeColor = System.Drawing.Color.White;
            this.lbl_VariantName.Location = new System.Drawing.Point(10, 25);
            this.lbl_VariantName.Name = "lbl_VariantName";
            this.lbl_VariantName.Size = new System.Drawing.Size(72, 13);
            this.lbl_VariantName.TabIndex = 0;
            this.lbl_VariantName.Text = "Checking...";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(10, 9);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(74, 13);
            this.bunifuCustomLabel3.TabIndex = 0;
            this.bunifuCustomLabel3.Text = "Variant Name:";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.panel8.Controls.Add(this.lbl_VariantDescription);
            this.panel8.Controls.Add(this.bunifuCustomLabel21);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(201, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(785, 51);
            this.panel8.TabIndex = 5;
            this.panel8.Tag = "1";
            // 
            // lbl_VariantDescription
            // 
            this.lbl_VariantDescription.AutoSize = true;
            this.lbl_VariantDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VariantDescription.ForeColor = System.Drawing.Color.White;
            this.lbl_VariantDescription.Location = new System.Drawing.Point(10, 25);
            this.lbl_VariantDescription.Name = "lbl_VariantDescription";
            this.lbl_VariantDescription.Size = new System.Drawing.Size(72, 13);
            this.lbl_VariantDescription.TabIndex = 0;
            this.lbl_VariantDescription.Text = "Checking...";
            // 
            // bunifuCustomLabel21
            // 
            this.bunifuCustomLabel21.AutoSize = true;
            this.bunifuCustomLabel21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.bunifuCustomLabel21.Location = new System.Drawing.Point(10, 9);
            this.bunifuCustomLabel21.Name = "bunifuCustomLabel21";
            this.bunifuCustomLabel21.Size = new System.Drawing.Size(96, 13);
            this.bunifuCustomLabel21.TabIndex = 0;
            this.bunifuCustomLabel21.Text = "Variant Description";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bdc_logo
            // 
            this.bdc_logo.Fixed = true;
            this.bdc_logo.Horizontal = true;
            this.bdc_logo.TargetControl = this.pnl_logo;
            this.bdc_logo.Vertical = true;
            // 
            // bdc_title
            // 
            this.bdc_title.Fixed = true;
            this.bdc_title.Horizontal = true;
            this.bdc_title.TargetControl = this.lbl_title;
            this.bdc_title.Vertical = true;
            // 
            // bdc_titlePanel
            // 
            this.bdc_titlePanel.Fixed = true;
            this.bdc_titlePanel.Horizontal = true;
            this.bdc_titlePanel.TargetControl = this.pnl_titlePanel;
            this.bdc_titlePanel.Vertical = true;
            // 
            // bdc_topPanel
            // 
            this.bdc_topPanel.Fixed = true;
            this.bdc_topPanel.Horizontal = true;
            this.bdc_topPanel.TargetControl = this.pnl_topPanel;
            this.bdc_topPanel.Vertical = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_ok);
            this.panel1.Controls.Add(this.dgv_details);
            this.panel1.Location = new System.Drawing.Point(1, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 325);
            this.panel1.TabIndex = 61;
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Location = new System.Drawing.Point(883, 281);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(90, 32);
            this.btn_ok.TabIndex = 64;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            // 
            // dgv_details
            // 
            this.dgv_details.AllowUserToAddRows = false;
            this.dgv_details.AllowUserToDeleteRows = false;
            this.dgv_details.AllowUserToResizeRows = false;
            this.dgv_details.BackgroundColor = System.Drawing.Color.White;
            this.dgv_details.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_details.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prDate,
            this.poLineCreateDateRange,
            this.finalRecDateRange,
            this.AdvancedFilters,
            this.projectNumber,
            this.wbsElement,
            this.material,
            this.materialGroup,
            this.vendor,
            this.vendorDescription,
            this.prPurchGroup,
            this.poPurchGroup,
            this.irSuppName,
            this.fxdSuppName,
            this.dsrdSuppName,
            this.commCategory,
            this.escaped,
            this.poDocumentType,
            this.prodOrdMaterial});
            this.dgv_details.Location = new System.Drawing.Point(12, 11);
            this.dgv_details.Name = "dgv_details";
            this.dgv_details.RowHeadersVisible = false;
            this.dgv_details.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect;
            this.dgv_details.Size = new System.Drawing.Size(961, 261);
            this.dgv_details.TabIndex = 63;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 5;
            this.bunifuElipse2.TargetControl = this.panel1;
            // 
            // prDate
            // 
            this.prDate.HeaderText = "PR Date";
            this.prDate.Name = "prDate";
            this.prDate.ReadOnly = true;
            this.prDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // poLineCreateDateRange
            // 
            this.poLineCreateDateRange.HeaderText = "PO Line Creation Date Range";
            this.poLineCreateDateRange.Name = "poLineCreateDateRange";
            this.poLineCreateDateRange.ReadOnly = true;
            this.poLineCreateDateRange.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // finalRecDateRange
            // 
            this.finalRecDateRange.HeaderText = "finalRecDateRange";
            this.finalRecDateRange.Name = "finalRecDateRange";
            this.finalRecDateRange.ReadOnly = true;
            this.finalRecDateRange.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AdvancedFilters
            // 
            this.AdvancedFilters.HeaderText = "Advanced Filters";
            this.AdvancedFilters.Name = "AdvancedFilters";
            this.AdvancedFilters.ReadOnly = true;
            this.AdvancedFilters.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // projectNumber
            // 
            this.projectNumber.HeaderText = "Project Number";
            this.projectNumber.Name = "projectNumber";
            this.projectNumber.ReadOnly = true;
            this.projectNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // wbsElement
            // 
            this.wbsElement.HeaderText = "WBS Element";
            this.wbsElement.Name = "wbsElement";
            this.wbsElement.ReadOnly = true;
            this.wbsElement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // material
            // 
            this.material.HeaderText = "Material";
            this.material.Name = "material";
            this.material.ReadOnly = true;
            this.material.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // materialGroup
            // 
            this.materialGroup.HeaderText = "Material Group";
            this.materialGroup.Name = "materialGroup";
            this.materialGroup.ReadOnly = true;
            this.materialGroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // vendor
            // 
            this.vendor.HeaderText = "Vendor";
            this.vendor.Name = "vendor";
            this.vendor.ReadOnly = true;
            this.vendor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // vendorDescription
            // 
            this.vendorDescription.HeaderText = "Vendor Desciption";
            this.vendorDescription.Name = "vendorDescription";
            this.vendorDescription.ReadOnly = true;
            this.vendorDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // prPurchGroup
            // 
            this.prPurchGroup.HeaderText = "PR Purch Group";
            this.prPurchGroup.Name = "prPurchGroup";
            this.prPurchGroup.ReadOnly = true;
            this.prPurchGroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // poPurchGroup
            // 
            this.poPurchGroup.HeaderText = "PO Purch Group";
            this.poPurchGroup.Name = "poPurchGroup";
            this.poPurchGroup.ReadOnly = true;
            this.poPurchGroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // irSuppName
            // 
            this.irSuppName.HeaderText = "IR Supp Name";
            this.irSuppName.Name = "irSuppName";
            this.irSuppName.ReadOnly = true;
            this.irSuppName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // fxdSuppName
            // 
            this.fxdSuppName.HeaderText = "Fxd Supp Name";
            this.fxdSuppName.Name = "fxdSuppName";
            this.fxdSuppName.ReadOnly = true;
            this.fxdSuppName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dsrdSuppName
            // 
            this.dsrdSuppName.HeaderText = "Dsrd Supp Name";
            this.dsrdSuppName.Name = "dsrdSuppName";
            this.dsrdSuppName.ReadOnly = true;
            this.dsrdSuppName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // commCategory
            // 
            this.commCategory.HeaderText = "Commodity Category";
            this.commCategory.Name = "commCategory";
            this.commCategory.ReadOnly = true;
            this.commCategory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // escaped
            // 
            this.escaped.HeaderText = "Escaped";
            this.escaped.Name = "escaped";
            this.escaped.ReadOnly = true;
            this.escaped.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // poDocumentType
            // 
            this.poDocumentType.HeaderText = "PO Document Type";
            this.poDocumentType.Name = "poDocumentType";
            this.poDocumentType.ReadOnly = true;
            this.poDocumentType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // prodOrdMaterial
            // 
            this.prodOrdMaterial.HeaderText = "Production Order Material";
            this.prodOrdMaterial.Name = "prodOrdMaterial";
            this.prodOrdMaterial.ReadOnly = true;
            this.prodOrdMaterial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // VariantsDetailDisplayWindow
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(986, 406);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_MainNavigation);
            this.Controls.Add(this.pnl_TopUIPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VariantsDetailDisplayWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VariantsDetailDisplayWindow";
            this.Load += new System.EventHandler(this.VariantsDetailDisplayWindow_Load);
            this.pnl_TopUIPanel.ResumeLayout(false);
            this.pnl_topPanel.ResumeLayout(false);
            this.pnl_titlePanel.ResumeLayout(false);
            this.pnl_titlePanel.PerformLayout();
            this.pnl_MainNavigation.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.pnl_CountrySelectorButton.ResumeLayout(false);
            this.pnl_CountrySelectorButton.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_details)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_TopUIPanel;
        private System.Windows.Forms.Panel pnl_topPanel;
        private System.Windows.Forms.Panel pnl_Minimize;
        private System.Windows.Forms.Panel pnl_Close;
        private System.Windows.Forms.Panel pnl_titlePanel;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_title;
        private System.Windows.Forms.Panel pnl_logo;
        private System.Windows.Forms.Panel pnl_MainNavigation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.Panel pnl_CountrySelectorButton;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private System.Windows.Forms.Panel panel8;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_VariantDescription;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel21;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_VariantName;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bdc_logo;
        private Bunifu.Framework.UI.BunifuDragControl bdc_title;
        private Bunifu.Framework.UI.BunifuDragControl bdc_titlePanel;
        private Bunifu.Framework.UI.BunifuDragControl bdc_topPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.DataGridView dgv_details;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.DataGridViewTextBoxColumn prDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn poLineCreateDateRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn finalRecDateRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdvancedFilters;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn wbsElement;
        private System.Windows.Forms.DataGridViewTextBoxColumn material;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn prPurchGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn poPurchGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn irSuppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fxdSuppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsrdSuppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn commCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn escaped;
        private System.Windows.Forms.DataGridViewTextBoxColumn poDocumentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodOrdMaterial;
    }
}