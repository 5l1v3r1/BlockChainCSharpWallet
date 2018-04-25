namespace SHCWalletC.GUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LabelYourWallet = new System.Windows.Forms.Label();
            this.LabelWalletAddress = new System.Windows.Forms.Label();
            this.LabelAddress = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LabelDaemonBlockHeight = new System.Windows.Forms.Label();
            this.DaemonBlockHeight = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.QRReceive = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QRReceive)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 429);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(703, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(531, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(116, 70);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // LabelYourWallet
            // 
            this.LabelYourWallet.AutoSize = true;
            this.LabelYourWallet.BackColor = System.Drawing.Color.Transparent;
            this.LabelYourWallet.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelYourWallet.Location = new System.Drawing.Point(63, 39);
            this.LabelYourWallet.Name = "LabelYourWallet";
            this.LabelYourWallet.Size = new System.Drawing.Size(146, 26);
            this.LabelYourWallet.TabIndex = 2;
            this.LabelYourWallet.Text = "Receive address";
            this.LabelYourWallet.Click += new System.EventHandler(this.LabelYourWallet_Click);
            // 
            // LabelWalletAddress
            // 
            this.LabelWalletAddress.AutoSize = true;
            this.LabelWalletAddress.Location = new System.Drawing.Point(17, 39);
            this.LabelWalletAddress.Name = "LabelWalletAddress";
            this.LabelWalletAddress.Size = new System.Drawing.Size(0, 13);
            this.LabelWalletAddress.TabIndex = 3;
            // 
            // LabelAddress
            // 
            this.LabelAddress.AutoSize = true;
            this.LabelAddress.BackColor = System.Drawing.Color.Transparent;
            this.LabelAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelAddress.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAddress.Location = new System.Drawing.Point(42, 108);
            this.LabelAddress.MaximumSize = new System.Drawing.Size(200, 0);
            this.LabelAddress.Name = "LabelAddress";
            this.LabelAddress.Size = new System.Drawing.Size(200, 45);
            this.LabelAddress.TabIndex = 4;
            this.LabelAddress.Text = "ashDSArjJae2GKzAo2783RCkBzk7UUCukLV9rXRmAByWdRdTYLXFeag7kjqc361rbt19uaEtQL6JxDyAn" +
    "RoEoYCD4Lmt7MiFDZ";
            this.LabelAddress.UseCompatibleTextRendering = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBox3.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(283, 430);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // LabelDaemonBlockHeight
            // 
            this.LabelDaemonBlockHeight.AutoSize = true;
            this.LabelDaemonBlockHeight.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDaemonBlockHeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LabelDaemonBlockHeight.Location = new System.Drawing.Point(843, 429);
            this.LabelDaemonBlockHeight.Name = "LabelDaemonBlockHeight";
            this.LabelDaemonBlockHeight.Size = new System.Drawing.Size(114, 26);
            this.LabelDaemonBlockHeight.TabIndex = 6;
            this.LabelDaemonBlockHeight.Text = "BlockHeight";
            this.LabelDaemonBlockHeight.Click += new System.EventHandler(this.LabelDaemonBlockHeight_Click);
            // 
            // DaemonBlockHeight
            // 
            this.DaemonBlockHeight.AutoSize = true;
            this.DaemonBlockHeight.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DaemonBlockHeight.Location = new System.Drawing.Point(843, 455);
            this.DaemonBlockHeight.Name = "DaemonBlockHeight";
            this.DaemonBlockHeight.Size = new System.Drawing.Size(23, 26);
            this.DaemonBlockHeight.TabIndex = 7;
            this.DaemonBlockHeight.Text = "0";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBox4.Location = new System.Drawing.Point(737, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(283, 430);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // QRReceive
            // 
            this.QRReceive.Location = new System.Drawing.Point(42, 190);
            this.QRReceive.Name = "QRReceive";
            this.QRReceive.Size = new System.Drawing.Size(184, 171);
            this.QRReceive.TabIndex = 9;
            this.QRReceive.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1016, 509);
            this.Controls.Add(this.QRReceive);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.DaemonBlockHeight);
            this.Controls.Add(this.LabelDaemonBlockHeight);
            this.Controls.Add(this.LabelAddress);
            this.Controls.Add(this.LabelWalletAddress);
            this.Controls.Add(this.LabelYourWallet);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Name = "MainForm";
            this.Text = "SHC Harrier Coin Core Wallet C#";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QRReceive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LabelYourWallet;
        private System.Windows.Forms.Label LabelWalletAddress;
        private System.Windows.Forms.Label LabelAddress;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label LabelDaemonBlockHeight;
        private System.Windows.Forms.Label DaemonBlockHeight;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox QRReceive;
    }
}