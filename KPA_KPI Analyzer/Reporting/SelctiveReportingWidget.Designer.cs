namespace KPA_KPI_Analyzer.Reporting
{
    partial class SelctiveReportingWidget
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_GenerateReport = new MaterialSkin.Controls.MaterialFlatButton();
            this.comboBox_FitlerOption = new System.Windows.Forms.ComboBox();
            this.radioBtn_KpiReporting = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioBtn_KpaReporting = new MaterialSkin.Controls.MaterialRadioButton();
            this.label_FilterOption = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.bunifuCards1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.groupBox1);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(3, 3);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(301, 298);
            this.bunifuCards1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_GenerateReport);
            this.groupBox1.Controls.Add(this.comboBox_FitlerOption);
            this.groupBox1.Controls.Add(this.radioBtn_KpiReporting);
            this.groupBox1.Controls.Add(this.radioBtn_KpaReporting);
            this.groupBox1.Controls.Add(this.label_FilterOption);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Location = new System.Drawing.Point(17, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 263);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btn_GenerateReport
            // 
            this.btn_GenerateReport.AutoSize = true;
            this.btn_GenerateReport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_GenerateReport.Depth = 0;
            this.btn_GenerateReport.Location = new System.Drawing.Point(60, 206);
            this.btn_GenerateReport.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_GenerateReport.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_GenerateReport.Name = "btn_GenerateReport";
            this.btn_GenerateReport.Primary = false;
            this.btn_GenerateReport.Size = new System.Drawing.Size(135, 36);
            this.btn_GenerateReport.TabIndex = 3;
            this.btn_GenerateReport.Text = "Generate Report";
            this.btn_GenerateReport.UseVisualStyleBackColor = true;
            this.btn_GenerateReport.Click += new System.EventHandler(this.OnGenerateReport);
            // 
            // comboBox_FitlerOption
            // 
            this.comboBox_FitlerOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FitlerOption.FormattingEnabled = true;
            this.comboBox_FitlerOption.Location = new System.Drawing.Point(25, 147);
            this.comboBox_FitlerOption.Name = "comboBox_FitlerOption";
            this.comboBox_FitlerOption.Size = new System.Drawing.Size(214, 21);
            this.comboBox_FitlerOption.TabIndex = 2;
            this.comboBox_FitlerOption.SelectedIndexChanged += new System.EventHandler(this.comboBox_FitlerOption_SelectedIndexChanged);
            // 
            // radioBtn_KpiReporting
            // 
            this.radioBtn_KpiReporting.AutoSize = true;
            this.radioBtn_KpiReporting.Depth = 0;
            this.radioBtn_KpiReporting.Font = new System.Drawing.Font("Roboto", 10F);
            this.radioBtn_KpiReporting.Location = new System.Drawing.Point(142, 73);
            this.radioBtn_KpiReporting.Margin = new System.Windows.Forms.Padding(0);
            this.radioBtn_KpiReporting.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioBtn_KpiReporting.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioBtn_KpiReporting.Name = "radioBtn_KpiReporting";
            this.radioBtn_KpiReporting.Ripple = true;
            this.radioBtn_KpiReporting.Size = new System.Drawing.Size(95, 30);
            this.radioBtn_KpiReporting.TabIndex = 1;
            this.radioBtn_KpiReporting.Text = "KPI Report";
            this.radioBtn_KpiReporting.UseVisualStyleBackColor = true;
            // 
            // radioBtn_KpaReporting
            // 
            this.radioBtn_KpaReporting.AutoSize = true;
            this.radioBtn_KpaReporting.Checked = true;
            this.radioBtn_KpaReporting.Depth = 0;
            this.radioBtn_KpaReporting.Font = new System.Drawing.Font("Roboto", 10F);
            this.radioBtn_KpaReporting.Location = new System.Drawing.Point(23, 73);
            this.radioBtn_KpaReporting.Margin = new System.Windows.Forms.Padding(0);
            this.radioBtn_KpaReporting.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioBtn_KpaReporting.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioBtn_KpaReporting.Name = "radioBtn_KpaReporting";
            this.radioBtn_KpaReporting.Ripple = true;
            this.radioBtn_KpaReporting.Size = new System.Drawing.Size(100, 30);
            this.radioBtn_KpaReporting.TabIndex = 1;
            this.radioBtn_KpaReporting.TabStop = true;
            this.radioBtn_KpaReporting.Text = "KPA Report";
            this.radioBtn_KpaReporting.UseVisualStyleBackColor = true;
            this.radioBtn_KpaReporting.CheckedChanged += new System.EventHandler(this.PerformanceRadioBtn_CheckedChanged);
            // 
            // label_FilterOption
            // 
            this.label_FilterOption.AutoSize = true;
            this.label_FilterOption.Depth = 0;
            this.label_FilterOption.Font = new System.Drawing.Font("Roboto", 11F);
            this.label_FilterOption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_FilterOption.Location = new System.Drawing.Point(21, 125);
            this.label_FilterOption.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_FilterOption.Name = "label_FilterOption";
            this.label_FilterOption.Size = new System.Drawing.Size(95, 19);
            this.label_FilterOption.TabIndex = 0;
            this.label_FilterOption.Text = "Filter Option:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(7, -3);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(144, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "KPA && KPI Reporting";
            // 
            // SelctiveReportingWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bunifuCards1);
            this.Name = "SelctiveReportingWidget";
            this.Size = new System.Drawing.Size(301, 298);
            this.Load += new System.EventHandler(this.SelctiveReportingWidget_Load);
            this.bunifuCards1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialRadioButton radioBtn_KpaReporting;
        private MaterialSkin.Controls.MaterialRadioButton radioBtn_KpiReporting;
        private System.Windows.Forms.ComboBox comboBox_FitlerOption;
        private MaterialSkin.Controls.MaterialLabel label_FilterOption;
        private MaterialSkin.Controls.MaterialFlatButton btn_GenerateReport;
    }
}
