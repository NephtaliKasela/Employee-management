namespace MyProject_v002
{
    partial class Confirmation_Reset_TheApp
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
            this.guna2btnNotReset = new Guna.UI2.WinForms.Guna2Button();
            this.guna2btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.guna2CstmRbtnResetHistory = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.guna2CstmRbtnReseEverything = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2btnNotReset
            // 
            this.guna2btnNotReset.BorderRadius = 15;
            this.guna2btnNotReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2btnNotReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnNotReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnNotReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2btnNotReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2btnNotReset.FillColor = System.Drawing.Color.IndianRed;
            this.guna2btnNotReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2btnNotReset.ForeColor = System.Drawing.Color.White;
            this.guna2btnNotReset.Location = new System.Drawing.Point(139, 11);
            this.guna2btnNotReset.Name = "guna2btnNotReset";
            this.guna2btnNotReset.Size = new System.Drawing.Size(80, 37);
            this.guna2btnNotReset.TabIndex = 5;
            this.guna2btnNotReset.Text = "No";
            this.guna2btnNotReset.Click += new System.EventHandler(this.guna2btnNotReset_Click);
            // 
            // guna2btnReset
            // 
            this.guna2btnReset.BorderRadius = 15;
            this.guna2btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2btnReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2btnReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2btnReset.FillColor = System.Drawing.Color.Navy;
            this.guna2btnReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2btnReset.ForeColor = System.Drawing.Color.White;
            this.guna2btnReset.Location = new System.Drawing.Point(29, 11);
            this.guna2btnReset.Name = "guna2btnReset";
            this.guna2btnReset.Size = new System.Drawing.Size(80, 37);
            this.guna2btnReset.TabIndex = 4;
            this.guna2btnReset.Text = "Yes";
            this.guna2btnReset.Click += new System.EventHandler(this.guna2btnReset_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(250, 76);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Are you sure ?";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.guna2btnNotReset);
            this.panel2.Controls.Add(this.guna2btnReset);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 161);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 72);
            this.panel2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 76);
            this.panel1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.guna2CstmRbtnReseEverything);
            this.panel3.Controls.Add(this.guna2CstmRbtnResetHistory);
            this.panel3.Location = new System.Drawing.Point(0, 79);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 76);
            this.panel3.TabIndex = 6;
            // 
            // guna2CstmRbtnResetHistory
            // 
            this.guna2CstmRbtnResetHistory.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CstmRbtnResetHistory.CheckedState.BorderThickness = 0;
            this.guna2CstmRbtnResetHistory.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2CstmRbtnResetHistory.CheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2CstmRbtnResetHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2CstmRbtnResetHistory.Location = new System.Drawing.Point(53, 8);
            this.guna2CstmRbtnResetHistory.Name = "guna2CstmRbtnResetHistory";
            this.guna2CstmRbtnResetHistory.Size = new System.Drawing.Size(20, 20);
            this.guna2CstmRbtnResetHistory.TabIndex = 0;
            this.guna2CstmRbtnResetHistory.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CstmRbtnResetHistory.UncheckedState.BorderThickness = 2;
            this.guna2CstmRbtnResetHistory.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.guna2CstmRbtnResetHistory.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // guna2CstmRbtnReseEverything
            // 
            this.guna2CstmRbtnReseEverything.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CstmRbtnReseEverything.CheckedState.BorderThickness = 0;
            this.guna2CstmRbtnReseEverything.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2CstmRbtnReseEverything.CheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2CstmRbtnReseEverything.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2CstmRbtnReseEverything.Location = new System.Drawing.Point(53, 42);
            this.guna2CstmRbtnReseEverything.Name = "guna2CstmRbtnReseEverything";
            this.guna2CstmRbtnReseEverything.Size = new System.Drawing.Size(20, 20);
            this.guna2CstmRbtnReseEverything.TabIndex = 1;
            this.guna2CstmRbtnReseEverything.Text = "Only the History";
            this.guna2CstmRbtnReseEverything.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CstmRbtnReseEverything.UncheckedState.BorderThickness = 2;
            this.guna2CstmRbtnReseEverything.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.guna2CstmRbtnReseEverything.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(81, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Only the History";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(81, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Everything";
            // 
            // Confirmation_Reset_TheApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(250, 233);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Confirmation_Reset_TheApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmation_Reset_TheApp";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2btnNotReset;
        private Guna.UI2.WinForms.Guna2Button guna2btnReset;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CustomRadioButton guna2CstmRbtnReseEverything;
        private Guna.UI2.WinForms.Guna2CustomRadioButton guna2CstmRbtnResetHistory;
    }
}