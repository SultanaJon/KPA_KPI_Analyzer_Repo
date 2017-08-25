using System.Drawing;

namespace KPA_KPI_Analyzer
{
    partial class SplashScreen
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
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_CheckStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.bunifuCustomLabel1.Enabled = false;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft MHei", 18F,System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.DimGray;
            this.bunifuCustomLabel1.Location = new Point(202, 72);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new Size(192, 32);
            this.bunifuCustomLabel1.TabIndex = 1;
            this.bunifuCustomLabel1.Text = "KPA-KPI Analyzer";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.bunifuCustomLabel2.Enabled = false;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Microsoft MHei", 12F,System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel2.Location = new Point(418, 17);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new Size(167, 21);
            this.bunifuCustomLabel2.TabIndex = 1;
            this.bunifuCustomLabel2.Text = "Key Process Area (KPA)";
            this.bunifuCustomLabel2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new Point(422, 41);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(348, 45);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Areas where the responsibility for results lies with a specific department or emp" +
    "loyee.";
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new Point(422, 113);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(348, 45);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "Indicators which are both financial and non-financial in nature and are used to m" +
    "easure the performance of an oranganization.";
            this.textBox2.Visible = false;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.bunifuCustomLabel3.Enabled = false;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Microsoft MHei", 12F,System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel3.Location = new Point(418, 89);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new Size(231, 21);
            this.bunifuCustomLabel3.TabIndex = 3;
            this.bunifuCustomLabel3.Text = "Key Performance Indicators (KPI)";
            this.bunifuCustomLabel3.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_CheckStatus
            // 
            this.lbl_CheckStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lbl_CheckStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_CheckStatus.Enabled = false;
            this.lbl_CheckStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_CheckStatus.Location = new Point(208, 136);
            this.lbl_CheckStatus.Name = "lbl_CheckStatus";
            this.lbl_CheckStatus.Size = new Size(320, 13);
            this.lbl_CheckStatus.TabIndex = 7;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::KPA_KPI_Analyzer.Properties.Resources.splashscreen;
            this.ClientSize = new Size(616, 171);
            this.Controls.Add(this.lbl_CheckStatus);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SplashScreen_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox lbl_CheckStatus;
    }
}