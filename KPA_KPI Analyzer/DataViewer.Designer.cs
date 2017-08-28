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
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnl_TopPanel = new System.Windows.Forms.Panel();
            this.btn_Minimize = new System.Windows.Forms.Button();
            this.btn_Expand = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.panel20 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dgv_dataViewerDgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.pnl_TopPanel.SuspendLayout();
            this.panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dataViewerDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.pnl_TopPanel;
            this.bunifuDragControl1.Vertical = true;
            // 
            // pnl_TopPanel
            // 
            this.pnl_TopPanel.BackColor = System.Drawing.Color.Transparent;
            this.pnl_TopPanel.Controls.Add(this.btn_Minimize);
            this.pnl_TopPanel.Controls.Add(this.btn_Expand);
            this.pnl_TopPanel.Controls.Add(this.btn_Close);
            this.pnl_TopPanel.Controls.Add(this.panel20);
            this.pnl_TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_TopPanel.Location = new System.Drawing.Point(0, 0);
            this.pnl_TopPanel.Name = "pnl_TopPanel";
            this.pnl_TopPanel.Size = new System.Drawing.Size(1018, 50);
            this.pnl_TopPanel.TabIndex = 4;
            this.pnl_TopPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnl_TopPanel_MouseDoubleClick);
            // 
            // btn_Minimize
            // 
            this.btn_Minimize.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.Minimize;
            this.btn_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Minimize.FlatAppearance.BorderSize = 0;
            this.btn_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Minimize.Location = new System.Drawing.Point(859, 0);
            this.btn_Minimize.Name = "btn_Minimize";
            this.btn_Minimize.Size = new System.Drawing.Size(53, 50);
            this.btn_Minimize.TabIndex = 10;
            this.btn_Minimize.UseVisualStyleBackColor = true;
            this.btn_Minimize.Click += new System.EventHandler(this.btn_Minimize_Click);
            this.btn_Minimize.MouseLeave += new System.EventHandler(this.btn_Minimize_MouseLeave);
            this.btn_Minimize.MouseHover += new System.EventHandler(this.btn_Minimize_MouseEnter);
            // 
            // btn_Expand
            // 
            this.btn_Expand.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.Maximize;
            this.btn_Expand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Expand.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Expand.FlatAppearance.BorderSize = 0;
            this.btn_Expand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Expand.Location = new System.Drawing.Point(912, 0);
            this.btn_Expand.Name = "btn_Expand";
            this.btn_Expand.Size = new System.Drawing.Size(53, 50);
            this.btn_Expand.TabIndex = 9;
            this.btn_Expand.UseVisualStyleBackColor = true;
            this.btn_Expand.Click += new System.EventHandler(this.btn_Expand_Click);
            this.btn_Expand.MouseLeave += new System.EventHandler(this.btn_Expand_MouseLeave);
            this.btn_Expand.MouseHover += new System.EventHandler(this.btn_Expand_MouseHover);
            // 
            // btn_Close
            // 
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Location = new System.Drawing.Point(965, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(53, 50);
            this.btn_Close.TabIndex = 8;
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            this.btn_Close.MouseLeave += new System.EventHandler(this.btn_Close_MouseLeave);
            this.btn_Close.MouseHover += new System.EventHandler(this.btn_Close_MouseHover);
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.bunifuCustomLabel1);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel20.Location = new System.Drawing.Point(0, 0);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(128, 50);
            this.panel20.TabIndex = 7;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.DimGray;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(12, 18);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(97, 13);
            this.bunifuCustomLabel1.TabIndex = 2;
            this.bunifuCustomLabel1.Text = "KPA - KPI Analyzer";
            // 
            // dgv_dataViewerDgv
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_dataViewerDgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_dataViewerDgv.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_dataViewerDgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_dataViewerDgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_dataViewerDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_dataViewerDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dataViewerDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_dataViewerDgv.DoubleBuffered = true;
            this.dgv_dataViewerDgv.EnableHeadersVisualStyles = false;
            this.dgv_dataViewerDgv.HeaderBgColor = System.Drawing.Color.DimGray;
            this.dgv_dataViewerDgv.HeaderForeColor = System.Drawing.Color.White;
            this.dgv_dataViewerDgv.Location = new System.Drawing.Point(0, 50);
            this.dgv_dataViewerDgv.Name = "dgv_dataViewerDgv";
            this.dgv_dataViewerDgv.ReadOnly = true;
            this.dgv_dataViewerDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_dataViewerDgv.Size = new System.Drawing.Size(1018, 566);
            this.dgv_dataViewerDgv.TabIndex = 5;
            // 
            // DataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 616);
            this.Controls.Add(this.dgv_dataViewerDgv);
            this.Controls.Add(this.pnl_TopPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DataViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataViewer";
            this.pnl_TopPanel.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dataViewerDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel pnl_TopPanel;
        private System.Windows.Forms.Panel panel20;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgv_dataViewerDgv;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Expand;
        private System.Windows.Forms.Button btn_Minimize;
    }
}