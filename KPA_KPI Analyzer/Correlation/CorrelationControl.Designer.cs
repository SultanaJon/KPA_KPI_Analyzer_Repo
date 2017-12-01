namespace KPA_KPI_Analyzer.Correlation
{
    partial class CorrelationControl
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tblpnl_correlationTool = new Bunifu.Framework.UI.BunifuCustomDataGrid();
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
            this.tmr_dataloader = new System.Windows.Forms.Timer(this.components);
            this.pnl_loadingScreen = new System.Windows.Forms.Panel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.cpb_loadingScreenCircProgBar = new CircularProgressBar.CircularProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.tblpnl_correlationTool)).BeginInit();
            this.pnl_loadingScreen.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblpnl_correlationTool
            // 
            this.tblpnl_correlationTool.AllowUserToAddRows = false;
            this.tblpnl_correlationTool.AllowUserToDeleteRows = false;
            this.tblpnl_correlationTool.AllowUserToOrderColumns = true;
            this.tblpnl_correlationTool.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tblpnl_correlationTool.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.tblpnl_correlationTool.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblpnl_correlationTool.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.tblpnl_correlationTool.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tblpnl_correlationTool.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblpnl_correlationTool.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.tblpnl_correlationTool.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblpnl_correlationTool.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.tblpnl_correlationTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpnl_correlationTool.DoubleBuffered = true;
            this.tblpnl_correlationTool.EnableHeadersVisualStyles = false;
            this.tblpnl_correlationTool.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.tblpnl_correlationTool.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.tblpnl_correlationTool.Location = new System.Drawing.Point(0, 0);
            this.tblpnl_correlationTool.Name = "tblpnl_correlationTool";
            this.tblpnl_correlationTool.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tblpnl_correlationTool.Size = new System.Drawing.Size(1150, 650);
            this.tblpnl_correlationTool.TabIndex = 59;
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
            // tmr_dataloader
            // 
            this.tmr_dataloader.Tick += new System.EventHandler(this.tmr_dataloader_Tick);
            // 
            // pnl_loadingScreen
            // 
            this.pnl_loadingScreen.Controls.Add(this.tableLayoutPanel9);
            this.pnl_loadingScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_loadingScreen.Location = new System.Drawing.Point(0, 0);
            this.pnl_loadingScreen.Name = "pnl_loadingScreen";
            this.pnl_loadingScreen.Size = new System.Drawing.Size(1150, 650);
            this.pnl_loadingScreen.TabIndex = 60;
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
            this.tableLayoutPanel9.Size = new System.Drawing.Size(1150, 650);
            this.tableLayoutPanel9.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.cpb_loadingScreenCircProgBar);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(458, 208);
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
            this.cpb_loadingScreenCircProgBar.Text = "Loading Data...";
            this.cpb_loadingScreenCircProgBar.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.cpb_loadingScreenCircProgBar.Value = 36;
            // 
            // CorrelationWindowcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblpnl_correlationTool);
            this.Controls.Add(this.pnl_loadingScreen);
            this.Name = "CorrelationWindowcs";
            this.Size = new System.Drawing.Size(1150, 650);
            this.Load += new System.EventHandler(this.CorrelationWindowcs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblpnl_correlationTool)).EndInit();
            this.pnl_loadingScreen.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuCustomDataGrid tblpnl_correlationTool;
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
        private System.Windows.Forms.Timer tmr_dataloader;
        private System.Windows.Forms.Panel pnl_loadingScreen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Panel panel9;
        private CircularProgressBar.CircularProgressBar cpb_loadingScreenCircProgBar;
    }
}
