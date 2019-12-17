namespace LuckyForm
{
    partial class lucky
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblset = new System.Windows.Forms.Label();
            this.lbln = new System.Windows.Forms.Label();
            this.lblcc = new System.Windows.Forms.Label();
            this.btnbc = new System.Windows.Forms.Button();
            this.lblno = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.btnonoff = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("隶书", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(214, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 21);
            this.label2.TabIndex = 27;
            this.label2.Text = "设　置:";
            // 
            // lblset
            // 
            this.lblset.AutoSize = true;
            this.lblset.BackColor = System.Drawing.Color.Transparent;
            this.lblset.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblset.Location = new System.Drawing.Point(269, 97);
            this.lblset.Name = "lblset";
            this.lblset.Size = new System.Drawing.Size(23, 24);
            this.lblset.TabIndex = 25;
            this.lblset.Text = "0";
            // 
            // lbln
            // 
            this.lbln.AutoSize = true;
            this.lbln.BackColor = System.Drawing.Color.Transparent;
            this.lbln.Font = new System.Drawing.Font("隶书", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbln.ForeColor = System.Drawing.Color.Yellow;
            this.lbln.Location = new System.Drawing.Point(617, 67);
            this.lbln.Name = "lbln";
            this.lbln.Size = new System.Drawing.Size(87, 21);
            this.lbln.TabIndex = 28;
            this.lbln.Text = "已抽出:";
            // 
            // lblcc
            // 
            this.lblcc.AutoSize = true;
            this.lblcc.BackColor = System.Drawing.Color.Transparent;
            this.lblcc.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblcc.Location = new System.Drawing.Point(670, 93);
            this.lblcc.Name = "lblcc";
            this.lblcc.Size = new System.Drawing.Size(23, 24);
            this.lblcc.TabIndex = 26;
            this.lblcc.Text = "0";
            // 
            // btnbc
            // 
            this.btnbc.Font = new System.Drawing.Font("隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnbc.ForeColor = System.Drawing.Color.Red;
            this.btnbc.Location = new System.Drawing.Point(67, 494);
            this.btnbc.Name = "btnbc";
            this.btnbc.Size = new System.Drawing.Size(146, 62);
            this.btnbc.TabIndex = 24;
            this.btnbc.TabStop = false;
            this.btnbc.Text = "结束";
            this.btnbc.UseVisualStyleBackColor = true;
            this.btnbc.Click += new System.EventHandler(this.btnbc_Click);
            // 
            // lblno
            // 
            this.lblno.AutoSize = true;
            this.lblno.BackColor = System.Drawing.Color.Transparent;
            this.lblno.Font = new System.Drawing.Font("隶书", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblno.ForeColor = System.Drawing.Color.Yellow;
            this.lblno.Location = new System.Drawing.Point(30, 9);
            this.lblno.Name = "lblno";
            this.lblno.Size = new System.Drawing.Size(192, 56);
            this.lblno.TabIndex = 22;
            this.lblno.Text = "一等奖";
            // 
            // lblname
            // 
            this.lblname.BackColor = System.Drawing.Color.Transparent;
            this.lblname.Font = new System.Drawing.Font("隶书", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblname.ForeColor = System.Drawing.Color.Yellow;
            this.lblname.Location = new System.Drawing.Point(146, 97);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(204, 70);
            this.lblname.TabIndex = 23;
            this.lblname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnonoff
            // 
            this.btnonoff.Font = new System.Drawing.Font("隶书", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnonoff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnonoff.Location = new System.Drawing.Point(773, 495);
            this.btnonoff.Name = "btnonoff";
            this.btnonoff.Size = new System.Drawing.Size(146, 61);
            this.btnonoff.TabIndex = 21;
            this.btnonoff.TabStop = false;
            this.btnonoff.Text = "开始";
            this.btnonoff.UseVisualStyleBackColor = true;
            this.btnonoff.Click += new System.EventHandler(this.btnonoff_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("隶书", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(710, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 35);
            this.label1.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(428, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 510);
            this.panel1.TabIndex = 42;
            // 
            // lucky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LuckyForm.Properties.Resources.www_sc115_com_ok;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(970, 604);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblset);
            this.Controls.Add(this.lbln);
            this.Controls.Add(this.lblcc);
            this.Controls.Add(this.btnbc);
            this.Controls.Add(this.lblno);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.btnonoff);
            this.Controls.Add(this.label1);
            this.Name = "lucky";
            this.Text = "award8";
            this.Load += new System.EventHandler(this.lucky_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblset;
        private System.Windows.Forms.Label lbln;
        private System.Windows.Forms.Label lblcc;
        private System.Windows.Forms.Button btnbc;
        private System.Windows.Forms.Label lblno;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Button btnonoff;
        private System.Windows.Forms.Timer timer1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}