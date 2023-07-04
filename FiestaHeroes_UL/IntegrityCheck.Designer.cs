namespace FiestaHeroes_UL
{
    partial class IntegrityCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntegrityCheck));
            this.FileName = new System.Windows.Forms.GroupBox();
            this.ServerTextbox = new System.Windows.Forms.TextBox();
            this.LocalTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FileName.SuspendLayout();
            this.SuspendLayout();
            // 
            // SHNGroupbox
            // 
            this.FileName.Controls.Add(this.ServerTextbox);
            this.FileName.Controls.Add(this.LocalTextbox);
            this.FileName.Controls.Add(this.label2);
            this.FileName.Controls.Add(this.label1);
            this.FileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileName.Location = new System.Drawing.Point(12, 12);
            this.FileName.Name = "SHNGroupbox";
            this.FileName.Size = new System.Drawing.Size(330, 84);
            this.FileName.TabIndex = 2;
            this.FileName.TabStop = false;
            this.FileName.Text = "Loading...";
            // 
            // ServerTextbox
            // 
            this.ServerTextbox.Location = new System.Drawing.Point(58, 54);
            this.ServerTextbox.Name = "ServerTextbox";
            this.ServerTextbox.ReadOnly = true;
            this.ServerTextbox.Size = new System.Drawing.Size(266, 21);
            this.ServerTextbox.TabIndex = 3;
            this.ServerTextbox.TabStop = false;
            // 
            // LocalTextbox
            // 
            this.LocalTextbox.Location = new System.Drawing.Point(58, 27);
            this.LocalTextbox.Name = "LocalTextbox";
            this.LocalTextbox.ReadOnly = true;
            this.LocalTextbox.Size = new System.Drawing.Size(266, 21);
            this.LocalTextbox.TabIndex = 2;
            this.LocalTextbox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local:";
            // 
            // IntegrityCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 108);
            this.Controls.Add(this.FileName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IntegrityCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Integrity Check";
            this.Load += new System.EventHandler(this.IntegrityCheck_LoadAsync);
            this.FileName.ResumeLayout(false);
            this.FileName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox FileName;
        private System.Windows.Forms.TextBox ServerTextbox;
        private System.Windows.Forms.TextBox LocalTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}