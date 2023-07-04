namespace FiestaHeroes_UL
{
    partial class OptionsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsWindow));
            this.PatchVersionResetButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.IntegrityCheckButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PatchVersionResetButton
            // 
            this.PatchVersionResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatchVersionResetButton.Location = new System.Drawing.Point(12, 9);
            this.PatchVersionResetButton.Name = "PatchVersionResetButton";
            this.PatchVersionResetButton.Size = new System.Drawing.Size(192, 38);
            this.PatchVersionResetButton.TabIndex = 0;
            this.PatchVersionResetButton.Text = "Patch Version Reset";
            this.PatchVersionResetButton.UseVisualStyleBackColor = true;
            this.PatchVersionResetButton.Click += new System.EventHandler(this.PatchVersionResetButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Enabled = false;
            this.ApplyButton.Location = new System.Drawing.Point(6, 28);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(85, 28);
            this.ApplyButton.TabIndex = 1;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RestoreButton);
            this.groupBox1.Controls.Add(this.ApplyButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 75);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Optimize Client";
            // 
            // RestoreButton
            // 
            this.RestoreButton.Enabled = false;
            this.RestoreButton.Location = new System.Drawing.Point(101, 28);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(85, 28);
            this.RestoreButton.TabIndex = 2;
            this.RestoreButton.Text = "Restore";
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // IntegrityCheckButton
            // 
            this.IntegrityCheckButton.Enabled = false;
            this.IntegrityCheckButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IntegrityCheckButton.Location = new System.Drawing.Point(12, 53);
            this.IntegrityCheckButton.Name = "IntegrityCheckButton";
            this.IntegrityCheckButton.Size = new System.Drawing.Size(192, 38);
            this.IntegrityCheckButton.TabIndex = 3;
            this.IntegrityCheckButton.Text = "Integrity Check";
            this.IntegrityCheckButton.UseVisualStyleBackColor = true;
            this.IntegrityCheckButton.Click += new System.EventHandler(this.IntegrityCheckButton_Click);
            // 
            // OptionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 184);
            this.Controls.Add(this.IntegrityCheckButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PatchVersionResetButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher Options";
            this.Load += new System.EventHandler(this.OptionsWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PatchVersionResetButton;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.Button IntegrityCheckButton;
    }
}