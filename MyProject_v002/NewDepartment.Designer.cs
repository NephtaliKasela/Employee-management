namespace MyProject_v002
{
    partial class NewDepartment
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
            this.guna2TxtDepartmt = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2btnAddNewDepartment = new Guna.UI2.WinForms.Guna2Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.guna2btnDeleteDepartment = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // guna2TxtDepartmt
            // 
            this.guna2TxtDepartmt.BorderRadius = 5;
            this.guna2TxtDepartmt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TxtDepartmt.DefaultText = "";
            this.guna2TxtDepartmt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TxtDepartmt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TxtDepartmt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TxtDepartmt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TxtDepartmt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TxtDepartmt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TxtDepartmt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TxtDepartmt.ForeColor = System.Drawing.Color.Silver;
            this.guna2TxtDepartmt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TxtDepartmt.Location = new System.Drawing.Point(40, 116);
            this.guna2TxtDepartmt.Name = "guna2TxtDepartmt";
            this.guna2TxtDepartmt.PasswordChar = '\0';
            this.guna2TxtDepartmt.PlaceholderText = "Add here";
            this.guna2TxtDepartmt.SelectedText = "";
            this.guna2TxtDepartmt.Size = new System.Drawing.Size(326, 36);
            this.guna2TxtDepartmt.TabIndex = 0;
            // 
            // guna2btnAddNewDepartment
            // 
            this.guna2btnAddNewDepartment.BorderRadius = 10;
            this.guna2btnAddNewDepartment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2btnAddNewDepartment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnAddNewDepartment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnAddNewDepartment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2btnAddNewDepartment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2btnAddNewDepartment.FillColor = System.Drawing.Color.Green;
            this.guna2btnAddNewDepartment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2btnAddNewDepartment.ForeColor = System.Drawing.Color.White;
            this.guna2btnAddNewDepartment.Location = new System.Drawing.Point(384, 116);
            this.guna2btnAddNewDepartment.Name = "guna2btnAddNewDepartment";
            this.guna2btnAddNewDepartment.Size = new System.Drawing.Size(89, 36);
            this.guna2btnAddNewDepartment.TabIndex = 1;
            this.guna2btnAddNewDepartment.Text = "Add";
            this.guna2btnAddNewDepartment.Click += new System.EventHandler(this.guna2btnAddNewDepartment_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.Location = new System.Drawing.Point(372, 170);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(114, 72);
            this.lblWarning.TabIndex = 2;
            this.lblWarning.Text = "Checking";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(329, 69);
            this.label2.TabIndex = 3;
            this.label2.Text = "New Department";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.Color.Gray;
            this.listBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.ForeColor = System.Drawing.Color.Silver;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 20;
            this.listBox.Location = new System.Drawing.Point(40, 170);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(326, 244);
            this.listBox.TabIndex = 4;
            // 
            // guna2btnDeleteDepartment
            // 
            this.guna2btnDeleteDepartment.BorderRadius = 10;
            this.guna2btnDeleteDepartment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2btnDeleteDepartment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnDeleteDepartment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnDeleteDepartment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2btnDeleteDepartment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2btnDeleteDepartment.FillColor = System.Drawing.Color.Maroon;
            this.guna2btnDeleteDepartment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2btnDeleteDepartment.ForeColor = System.Drawing.Color.White;
            this.guna2btnDeleteDepartment.Location = new System.Drawing.Point(384, 378);
            this.guna2btnDeleteDepartment.Name = "guna2btnDeleteDepartment";
            this.guna2btnDeleteDepartment.Size = new System.Drawing.Size(89, 36);
            this.guna2btnDeleteDepartment.TabIndex = 5;
            this.guna2btnDeleteDepartment.Text = "Delete";
            this.guna2btnDeleteDepartment.Click += new System.EventHandler(this.guna2btnDeleteDepartment_Click);
            // 
            // NewDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(513, 443);
            this.Controls.Add(this.guna2btnDeleteDepartment);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.guna2btnAddNewDepartment);
            this.Controls.Add(this.guna2TxtDepartmt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NewDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox guna2TxtDepartmt;
        private Guna.UI2.WinForms.Guna2Button guna2btnAddNewDepartment;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox;
        private Guna.UI2.WinForms.Guna2Button guna2btnDeleteDepartment;
    }
}