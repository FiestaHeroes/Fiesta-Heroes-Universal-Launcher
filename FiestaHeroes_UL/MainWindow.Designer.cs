namespace FiestaLauncher
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.BannerImage = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DownloadProgressLabel = new System.Windows.Forms.Label();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.DownloadProgress = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StartButton = new System.Windows.Forms.Button();
            this.OptionsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BannerImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BannerImage
            // 
            this.BannerImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.BannerImage.Location = new System.Drawing.Point(0, 0);
            this.BannerImage.Name = "BannerImage";
            this.BannerImage.Size = new System.Drawing.Size(500, 95);
            this.BannerImage.TabIndex = 0;
            this.BannerImage.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.DownloadProgressLabel);
            this.groupBox1.Controls.Add(this.FileNameLabel);
            this.groupBox1.Controls.Add(this.DownloadProgress);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 106);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Updates";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(6, 80);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(464, 13);
            this.textBox1.TabIndex = 5;
            this.textBox1.TabStop = false;
            // 
            // DownloadProgressLabel
            // 
            this.DownloadProgressLabel.AutoSize = true;
            this.DownloadProgressLabel.Location = new System.Drawing.Point(429, 35);
            this.DownloadProgressLabel.Name = "DownloadProgressLabel";
            this.DownloadProgressLabel.Size = new System.Drawing.Size(0, 14);
            this.DownloadProgressLabel.TabIndex = 2;
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Location = new System.Drawing.Point(3, 35);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(60, 14);
            this.FileNameLabel.TabIndex = 1;
            this.FileNameLabel.Text = "Checking...";
            // 
            // DownloadProgress
            // 
            this.DownloadProgress.Location = new System.Drawing.Point(6, 51);
            this.DownloadProgress.Name = "DownloadProgress";
            this.DownloadProgress.Size = new System.Drawing.Size(464, 23);
            this.DownloadProgress.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 247);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(500, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(174, 17);
            this.toolStripStatusLabel1.Text = "Fiesta Heroes Copyright © 2023";
            // 
            // StartButton
            // 
            this.StartButton.Enabled = false;
            this.StartButton.Location = new System.Drawing.Point(332, 213);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 7;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // OptionsButton
            // 
            this.OptionsButton.Enabled = false;
            this.OptionsButton.Location = new System.Drawing.Point(413, 213);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(75, 23);
            this.OptionsButton.TabIndex = 8;
            this.OptionsButton.Text = "Options";
            this.OptionsButton.UseVisualStyleBackColor = true;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 269);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BannerImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainWindow_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.BannerImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BannerImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label DownloadProgressLabel;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.ProgressBar DownloadProgress;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button OptionsButton;
    }
}

