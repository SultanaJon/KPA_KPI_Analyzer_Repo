namespace KPA_KPI_Analyzer.Filter_Variant
{
    partial class VariantsViewWindow
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
            this.dgv_variants = new System.Windows.Forms.DataGridView();
            this.VariantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VariantDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_apply = new System.Windows.Forms.Button();
            this.btn_view = new System.Windows.Forms.Button();
            this.btn_remove = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bdc_logo = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bdc_title = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bdc_titlePanel = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bdc_topPanel = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pnl_TopUIPanel.SuspendLayout();
            this.pnl_topPanel.SuspendLayout();
            this.pnl_titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_variants)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_TopUIPanel
            // 
            this.pnl_TopUIPanel.BackColor = System.Drawing.Color.Black;
            this.pnl_TopUIPanel.Controls.Add(this.pnl_topPanel);
            this.pnl_TopUIPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_TopUIPanel.Location = new System.Drawing.Point(0, 0);
            this.pnl_TopUIPanel.Name = "pnl_TopUIPanel";
            this.pnl_TopUIPanel.Size = new System.Drawing.Size(616, 26);
            this.pnl_TopUIPanel.TabIndex = 58;
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
            this.pnl_topPanel.Size = new System.Drawing.Size(616, 25);
            this.pnl_topPanel.TabIndex = 0;
            // 
            // pnl_Minimize
            // 
            this.pnl_Minimize.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.Minimize;
            this.pnl_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_Minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Minimize.Location = new System.Drawing.Point(516, 0);
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
            this.pnl_Close.Location = new System.Drawing.Point(566, 0);
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
            this.lbl_title.Size = new System.Drawing.Size(170, 13);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "KPA - KPI Analyzer - Variants View";
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
            // dgv_variants
            // 
            this.dgv_variants.AllowUserToAddRows = false;
            this.dgv_variants.AllowUserToDeleteRows = false;
            this.dgv_variants.AllowUserToResizeRows = false;
            this.dgv_variants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_variants.BackgroundColor = System.Drawing.Color.White;
            this.dgv_variants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_variants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VariantName,
            this.Active,
            this.VariantDescription});
            this.dgv_variants.Location = new System.Drawing.Point(11, 74);
            this.dgv_variants.Name = "dgv_variants";
            this.dgv_variants.Size = new System.Drawing.Size(592, 293);
            this.dgv_variants.TabIndex = 0;
            // 
            // VariantName
            // 
            this.VariantName.HeaderText = "Name";
            this.VariantName.Name = "VariantName";
            this.VariantName.ReadOnly = true;
            // 
            // Active
            // 
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            // 
            // VariantDescription
            // 
            this.VariantDescription.HeaderText = "Description";
            this.VariantDescription.Name = "VariantDescription";
            this.VariantDescription.ReadOnly = true;
            // 
            // btn_apply
            // 
            this.btn_apply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_apply.Location = new System.Drawing.Point(226, 373);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(90, 32);
            this.btn_apply.TabIndex = 1;
            this.btn_apply.Text = "Apply";
            this.btn_apply.UseVisualStyleBackColor = true;
            // 
            // btn_view
            // 
            this.btn_view.Location = new System.Drawing.Point(322, 373);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(90, 32);
            this.btn_view.TabIndex = 2;
            this.btn_view.Text = "View";
            this.btn_view.UseVisualStyleBackColor = true;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // btn_remove
            // 
            this.btn_remove.Location = new System.Drawing.Point(418, 373);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(90, 32);
            this.btn_remove.TabIndex = 3;
            this.btn_remove.Text = "Remove";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(514, 373);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(90, 32);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "OK";
            this.btn_cancel.UseVisualStyleBackColor = true;
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
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 42);
            this.panel1.TabIndex = 63;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Enabled = false;
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.textBox3.Location = new System.Drawing.Point(41, 13);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(540, 15);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "Here you can view all saved variants. You cannot edit these variants. You can onl" +
    "y apply, view, or remove them.";
            // 
            // VariantsViewWindow
            // 
            this.AcceptButton = this.btn_apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(616, 417);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.btn_view);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.dgv_variants);
            this.Controls.Add(this.pnl_TopUIPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VariantsViewWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VariantsViewWindow";
            this.Load += new System.EventHandler(this.VariantsViewWindow_Load);
            this.pnl_TopUIPanel.ResumeLayout(false);
            this.pnl_topPanel.ResumeLayout(false);
            this.pnl_titlePanel.ResumeLayout(false);
            this.pnl_titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_variants)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.DataGridView dgv_variants;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.Button btn_view;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn VariantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn VariantDescription;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bdc_logo;
        private Bunifu.Framework.UI.BunifuDragControl bdc_title;
        private Bunifu.Framework.UI.BunifuDragControl bdc_titlePanel;
        private Bunifu.Framework.UI.BunifuDragControl bdc_topPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox3;
    }
}