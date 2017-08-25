using System.Drawing;

namespace KPA_KPI_Analyzer
{
    partial class LoadingScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingScreen));
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.bunifuCircleProgressbar2 = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lbl_loadingStatus = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.tableLayoutPanel9.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 234F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Controls.Add(this.panel9, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.panel10, 1, 2);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new Point(0, 0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 4;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 234F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new Size(972, 650);
            this.tableLayoutPanel9.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.bunifuCircleProgressbar2);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new Point(369, 191);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new Size(234, 234);
            this.panel9.TabIndex = 0;
            // 
            // bunifuCircleProgressbar2
            // 
            this.bunifuCircleProgressbar2.animated = true;
            this.bunifuCircleProgressbar2.animationIterval = 5;
            this.bunifuCircleProgressbar2.animationSpeed = 300;
            this.bunifuCircleProgressbar2.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuCircleProgressbar2.BackgroundImage = ((Image)(resources.GetObject("bunifuCircleProgressbar2.BackgroundImage")));
            this.bunifuCircleProgressbar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.bunifuCircleProgressbar2.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuCircleProgressbar2.LabelVisible = false;
            this.bunifuCircleProgressbar2.LineProgressThickness = 8;
            this.bunifuCircleProgressbar2.LineThickness = 5;
            this.bunifuCircleProgressbar2.Location = new Point(10, 9);
            this.bunifuCircleProgressbar2.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.bunifuCircleProgressbar2.MaxValue = 100;
            this.bunifuCircleProgressbar2.Name = "bunifuCircleProgressbar2";
            this.bunifuCircleProgressbar2.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.bunifuCircleProgressbar2.ProgressColor = System.Drawing.Color.Teal;
            this.bunifuCircleProgressbar2.Size = new Size(216, 216);
            this.bunifuCircleProgressbar2.TabIndex = 2;
            this.bunifuCircleProgressbar2.Value = 25;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.lbl_loadingStatus);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new Point(369, 425);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new Size(234, 34);
            this.panel10.TabIndex = 1;
            // 
            // lbl_loadingStatus
            // 
            this.lbl_loadingStatus.AutoSize = true;
            this.lbl_loadingStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F,System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_loadingStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_loadingStatus.Location = new Point(64, 7);
            this.lbl_loadingStatus.Name = "lbl_loadingStatus";
            this.lbl_loadingStatus.Size = new Size(105, 20);
            this.lbl_loadingStatus.TabIndex = 0;
            this.lbl_loadingStatus.Text = "Loading Data";
            // 
            // LoadingScreen
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel9);
            this.Name = "LoadingScreen";
            this.Size = new Size(972, 650);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Panel panel9;
        private Bunifu.Framework.UI.BunifuCircleProgressbar bunifuCircleProgressbar2;
        private System.Windows.Forms.Panel panel10;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_loadingStatus;
    }
}
