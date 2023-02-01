namespace MyProject_v002
{
    partial class Confirmation_Delete_Employee
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2btnNotDelete = new Guna.UI2.WinForms.Guna2Button();
            this.guna2btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 81);
            this.label1.TabIndex = 0;
            this.label1.Text = "Are you sure ?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 81);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.guna2btnNotDelete);
            this.panel2.Controls.Add(this.guna2btnDelete);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 72);
            this.panel2.TabIndex = 4;
            // 
            // guna2btnNotDelete
            // 
            this.guna2btnNotDelete.BorderRadius = 15;
            this.guna2btnNotDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2btnNotDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnNotDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnNotDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2btnNotDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2btnNotDelete.FillColor = System.Drawing.Color.IndianRed;
            this.guna2btnNotDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2btnNotDelete.ForeColor = System.Drawing.Color.White;
            this.guna2btnNotDelete.Location = new System.Drawing.Point(135, 14);
            this.guna2btnNotDelete.Name = "guna2btnNotDelete";
            this.guna2btnNotDelete.Size = new System.Drawing.Size(80, 37);
            this.guna2btnNotDelete.TabIndex = 5;
            this.guna2btnNotDelete.Text = "No";
            this.guna2btnNotDelete.Click += new System.EventHandler(this.guna2btnNotDelete_Click);
            // 
            // guna2btnDelete
            // 
            this.guna2btnDelete.BorderRadius = 15;
            this.guna2btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2btnDelete.FillColor = System.Drawing.Color.Navy;
            this.guna2btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2btnDelete.ForeColor = System.Drawing.Color.White;
            this.guna2btnDelete.Location = new System.Drawing.Point(25, 14);
            this.guna2btnDelete.Name = "guna2btnDelete";
            this.guna2btnDelete.Size = new System.Drawing.Size(80, 37);
            this.guna2btnDelete.TabIndex = 4;
            this.guna2btnDelete.Text = "Yes";
            this.guna2btnDelete.Click += new System.EventHandler(this.guna2btnDelete_Click);
            // 
            // Confirmation_Delete_Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 159);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Confirmation_Delete_Employee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmation";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button guna2btnDelete;
        private Guna.UI2.WinForms.Guna2Button guna2btnNotDelete;
    }
}