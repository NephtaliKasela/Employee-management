namespace MyProject_v002.User_Controlers
{
    partial class UC_Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Home));
            this.guna2PictureBox = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2PictureBox
            // 
            this.guna2PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox.Image")));
            this.guna2PictureBox.ImageRotate = 0F;
            this.guna2PictureBox.Location = new System.Drawing.Point(0, 0);
            this.guna2PictureBox.Name = "guna2PictureBox";
            this.guna2PictureBox.Size = new System.Drawing.Size(915, 612);
            this.guna2PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox.TabIndex = 0;
            this.guna2PictureBox.TabStop = false;
            // 
            // UC_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.guna2PictureBox);
            this.Name = "UC_Home";
            this.Size = new System.Drawing.Size(915, 612);
            this.Load += new System.EventHandler(this.UC_Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox;
    }
}
