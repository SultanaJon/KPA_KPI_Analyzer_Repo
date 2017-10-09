namespace KPA_KPI_Analyzer.Correlation
{
    partial class CorrelationAnalysisWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_TopUIPanel = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.pnl_Minimize = new System.Windows.Forms.Panel();
            this.pnl_Maximize = new System.Windows.Forms.Panel();
            this.pnl_Close = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_VariableMatrix = new Bunifu.Framework.UI.BunifuCustomDataGrid();
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
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataViz_scatterPlot = new Bunifu.DataViz.BunifuDataViz();
            this.button1 = new System.Windows.Forms.Button();
            this.pnl_TopUIPanel.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_VariableMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_TopUIPanel
            // 
            this.pnl_TopUIPanel.BackColor = System.Drawing.Color.Black;
            this.pnl_TopUIPanel.Controls.Add(this.panel11);
            this.pnl_TopUIPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_TopUIPanel.Location = new System.Drawing.Point(0, 0);
            this.pnl_TopUIPanel.Name = "pnl_TopUIPanel";
            this.pnl_TopUIPanel.Size = new System.Drawing.Size(1015, 26);
            this.pnl_TopUIPanel.TabIndex = 57;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.panel11.Controls.Add(this.button1);
            this.panel11.Controls.Add(this.pnl_Minimize);
            this.panel11.Controls.Add(this.pnl_Maximize);
            this.panel11.Controls.Add(this.pnl_Close);
            this.panel11.Controls.Add(this.panel14);
            this.panel11.Controls.Add(this.panel13);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1015, 25);
            this.panel11.TabIndex = 0;
            // 
            // pnl_Minimize
            // 
            this.pnl_Minimize.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.Minimize;
            this.pnl_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_Minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Minimize.Location = new System.Drawing.Point(865, 0);
            this.pnl_Minimize.Name = "pnl_Minimize";
            this.pnl_Minimize.Size = new System.Drawing.Size(50, 25);
            this.pnl_Minimize.TabIndex = 4;
            // 
            // pnl_Maximize
            // 
            this.pnl_Maximize.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.Maximize;
            this.pnl_Maximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_Maximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Maximize.Location = new System.Drawing.Point(915, 0);
            this.pnl_Maximize.Name = "pnl_Maximize";
            this.pnl_Maximize.Size = new System.Drawing.Size(50, 25);
            this.pnl_Maximize.TabIndex = 3;
            // 
            // pnl_Close
            // 
            this.pnl_Close.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.Close;
            this.pnl_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Close.Location = new System.Drawing.Point(965, 0);
            this.pnl_Close.Name = "pnl_Close";
            this.pnl_Close.Size = new System.Drawing.Size(50, 25);
            this.pnl_Close.TabIndex = 2;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.bunifuCustomLabel1);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(50, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(110, 25);
            this.panel14.TabIndex = 1;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(8, 6);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(97, 13);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "KPA - KPI Analyzer";
            // 
            // panel13
            // 
            this.panel13.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.comau_logo;
            this.panel13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(50, 25);
            this.panel13.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1015, 626);
            this.panel1.TabIndex = 58;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.06532F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.93467F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_VariableMatrix, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataViz_scatterPlot, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.24841F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.75159F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(995, 606);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv_VariableMatrix
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_VariableMatrix.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_VariableMatrix.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_VariableMatrix.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_VariableMatrix.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_VariableMatrix.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_VariableMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_VariableMatrix.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.Column13,
            this.Column14});
            this.tableLayoutPanel1.SetColumnSpan(this.dgv_VariableMatrix, 2);
            this.dgv_VariableMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_VariableMatrix.DoubleBuffered = true;
            this.dgv_VariableMatrix.EnableHeadersVisualStyles = false;
            this.dgv_VariableMatrix.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.dgv_VariableMatrix.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.dgv_VariableMatrix.Location = new System.Drawing.Point(0, 302);
            this.dgv_VariableMatrix.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.dgv_VariableMatrix.Name = "dgv_VariableMatrix";
            this.dgv_VariableMatrix.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_VariableMatrix.Size = new System.Drawing.Size(995, 304);
            this.dgv_VariableMatrix.TabIndex = 0;
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
            this.Column5.HeaderText = "PR Pos Value";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "PO Net Price";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "PO Value";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Price Unit";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Pl Deliv Time";
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
            // Column13
            // 
            this.Column13.HeaderText = "PO Source Time";
            this.Column13.Name = "Column13";
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Open PR Qty";
            this.Column14.Name = "Column14";
            // 
            // dataViz_scatterPlot
            // 
            this.dataViz_scatterPlot.animationEnabled = false;
            this.dataViz_scatterPlot.AxisLineColor = System.Drawing.Color.LightGray;
            this.dataViz_scatterPlot.AxisXFontColor = System.Drawing.Color.Gray;
            this.dataViz_scatterPlot.AxisXGridColor = System.Drawing.Color.Gray;
            this.dataViz_scatterPlot.AxisXGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dataViz_scatterPlot.AxisYFontColor = System.Drawing.Color.Gray;
            this.dataViz_scatterPlot.AxisYGridColor = System.Drawing.Color.Gray;
            this.dataViz_scatterPlot.AxisYGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dataViz_scatterPlot.BackColor = System.Drawing.Color.White;
            this.dataViz_scatterPlot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.SetColumnSpan(this.dataViz_scatterPlot, 2);
            this.dataViz_scatterPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViz_scatterPlot.Location = new System.Drawing.Point(3, 3);
            this.dataViz_scatterPlot.Name = "dataViz_scatterPlot";
            this.dataViz_scatterPlot.Size = new System.Drawing.Size(989, 286);
            this.dataViz_scatterPlot.TabIndex = 1;
            this.dataViz_scatterPlot.Theme = Bunifu.DataViz.BunifuDataViz._theme.theme1;
            this.dataViz_scatterPlot.Title = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(545, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CorrelationAnalysisWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 652);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_TopUIPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CorrelationAnalysisWindow";
            this.Text = "CorrelationAnalysisWindow";
            this.Load += new System.EventHandler(this.CorrelationAnalysisWindow_Load);
            this.pnl_TopUIPanel.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_VariableMatrix)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_TopUIPanel;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel pnl_Minimize;
        private System.Windows.Forms.Panel pnl_Maximize;
        private System.Windows.Forms.Panel pnl_Close;
        private System.Windows.Forms.Panel panel14;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgv_VariableMatrix;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private Bunifu.DataViz.BunifuDataViz dataViz_scatterPlot;
        private System.Windows.Forms.Button button1;
    }
}