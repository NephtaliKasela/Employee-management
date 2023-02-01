namespace MyProject_v002.User_Controlers
{
    partial class UC_History
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2DataGridViewHistory = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ClName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnPostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnGivenName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnRaison = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2btnRepportEmpAdded = new Guna.UI2.WinForms.Guna2Button();
            this.guna2btnRepportEmpDeleted = new Guna.UI2.WinForms.Guna2Button();
            this.guna2TxtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2btnRepportUserConnected = new Guna.UI2.WinForms.Guna2Button();
            this.guna2btnRepportAll = new Guna.UI2.WinForms.Guna2Button();
            this.guna2btnRepportEmpUpdated = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridViewHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.Controls.Add(this.guna2DataGridViewHistory);
            this.guna2Panel1.Location = new System.Drawing.Point(81, 172);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(959, 534);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2DataGridViewHistory
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Aqua;
            this.guna2DataGridViewHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.guna2DataGridViewHistory.BackgroundColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridViewHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridViewHistory.ColumnHeadersHeight = 40;
            this.guna2DataGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridViewHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClName,
            this.ClnPostName,
            this.ClnGivenName,
            this.ClnID,
            this.ClnRaison,
            this.ClnDate});
            this.guna2DataGridViewHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridViewHistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.guna2DataGridViewHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2DataGridViewHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridViewHistory.Location = new System.Drawing.Point(0, 0);
            this.guna2DataGridViewHistory.Name = "guna2DataGridViewHistory";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Olive;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Olive;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridViewHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.guna2DataGridViewHistory.RowHeadersVisible = false;
            this.guna2DataGridViewHistory.RowHeadersWidth = 35;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Aqua;
            this.guna2DataGridViewHistory.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.guna2DataGridViewHistory.RowTemplate.Height = 50;
            this.guna2DataGridViewHistory.Size = new System.Drawing.Size(959, 534);
            this.guna2DataGridViewHistory.TabIndex = 0;
            this.guna2DataGridViewHistory.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridViewHistory.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridViewHistory.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridViewHistory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridViewHistory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridViewHistory.ThemeStyle.BackColor = System.Drawing.Color.DarkCyan;
            this.guna2DataGridViewHistory.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridViewHistory.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridViewHistory.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridViewHistory.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridViewHistory.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridViewHistory.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridViewHistory.ThemeStyle.HeaderStyle.Height = 40;
            this.guna2DataGridViewHistory.ThemeStyle.ReadOnly = false;
            this.guna2DataGridViewHistory.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2DataGridViewHistory.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridViewHistory.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridViewHistory.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridViewHistory.ThemeStyle.RowsStyle.Height = 50;
            this.guna2DataGridViewHistory.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2DataGridViewHistory.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // ClName
            // 
            this.ClName.HeaderText = "Name";
            this.ClName.MinimumWidth = 6;
            this.ClName.Name = "ClName";
            // 
            // ClnPostName
            // 
            this.ClnPostName.HeaderText = "Post name";
            this.ClnPostName.MinimumWidth = 6;
            this.ClnPostName.Name = "ClnPostName";
            // 
            // ClnGivenName
            // 
            this.ClnGivenName.HeaderText = "Given name";
            this.ClnGivenName.MinimumWidth = 6;
            this.ClnGivenName.Name = "ClnGivenName";
            // 
            // ClnID
            // 
            this.ClnID.HeaderText = "ID";
            this.ClnID.MinimumWidth = 6;
            this.ClnID.Name = "ClnID";
            // 
            // ClnRaison
            // 
            this.ClnRaison.HeaderText = "Raison";
            this.ClnRaison.MinimumWidth = 6;
            this.ClnRaison.Name = "ClnRaison";
            // 
            // ClnDate
            // 
            this.ClnDate.HeaderText = "Date";
            this.ClnDate.MinimumWidth = 6;
            this.ClnDate.Name = "ClnDate";
            // 
            // guna2btnRepportEmpAdded
            // 
            this.guna2btnRepportEmpAdded.BorderRadius = 10;
            this.guna2btnRepportEmpAdded.CheckedState.FillColor = System.Drawing.Color.Teal;
            this.guna2btnRepportEmpAdded.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2btnRepportEmpAdded.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnRepportEmpAdded.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnRepportEmpAdded.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2btnRepportEmpAdded.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2btnRepportEmpAdded.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2btnRepportEmpAdded.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2btnRepportEmpAdded.ForeColor = System.Drawing.Color.White;
            this.guna2btnRepportEmpAdded.Location = new System.Drawing.Point(192, 11);
            this.guna2btnRepportEmpAdded.Name = "guna2btnRepportEmpAdded";
            this.guna2btnRepportEmpAdded.Size = new System.Drawing.Size(270, 45);
            this.guna2btnRepportEmpAdded.TabIndex = 1;
            this.guna2btnRepportEmpAdded.Text = "Employees that were added";
            this.guna2btnRepportEmpAdded.Click += new System.EventHandler(this.guna2btnRepportEmpAdded_Click);
            // 
            // guna2btnRepportEmpDeleted
            // 
            this.guna2btnRepportEmpDeleted.BorderRadius = 10;
            this.guna2btnRepportEmpDeleted.CheckedState.FillColor = System.Drawing.Color.Teal;
            this.guna2btnRepportEmpDeleted.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2btnRepportEmpDeleted.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnRepportEmpDeleted.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnRepportEmpDeleted.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2btnRepportEmpDeleted.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2btnRepportEmpDeleted.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2btnRepportEmpDeleted.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2btnRepportEmpDeleted.ForeColor = System.Drawing.Color.White;
            this.guna2btnRepportEmpDeleted.Location = new System.Drawing.Point(487, 11);
            this.guna2btnRepportEmpDeleted.Name = "guna2btnRepportEmpDeleted";
            this.guna2btnRepportEmpDeleted.Size = new System.Drawing.Size(270, 45);
            this.guna2btnRepportEmpDeleted.TabIndex = 2;
            this.guna2btnRepportEmpDeleted.Text = "Employees that were deleted";
            this.guna2btnRepportEmpDeleted.Click += new System.EventHandler(this.guna2btnRepportEmpDeleted_Click);
            // 
            // guna2TxtSearch
            // 
            this.guna2TxtSearch.BorderRadius = 10;
            this.guna2TxtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TxtSearch.DefaultText = "";
            this.guna2TxtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TxtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TxtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TxtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TxtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TxtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TxtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TxtSearch.Location = new System.Drawing.Point(81, 94);
            this.guna2TxtSearch.Name = "guna2TxtSearch";
            this.guna2TxtSearch.PasswordChar = '\0';
            this.guna2TxtSearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TxtSearch.PlaceholderText = "Search";
            this.guna2TxtSearch.SelectedText = "";
            this.guna2TxtSearch.Size = new System.Drawing.Size(349, 36);
            this.guna2TxtSearch.TabIndex = 3;
            this.guna2TxtSearch.TextChanged += new System.EventHandler(this.guna2TxtSearch_TextChanged);
            // 
            // guna2btnRepportUserConnected
            // 
            this.guna2btnRepportUserConnected.BorderRadius = 10;
            this.guna2btnRepportUserConnected.CheckedState.FillColor = System.Drawing.Color.DimGray;
            this.guna2btnRepportUserConnected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2btnRepportUserConnected.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnRepportUserConnected.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnRepportUserConnected.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2btnRepportUserConnected.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2btnRepportUserConnected.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2btnRepportUserConnected.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2btnRepportUserConnected.ForeColor = System.Drawing.Color.White;
            this.guna2btnRepportUserConnected.Location = new System.Drawing.Point(1077, 11);
            this.guna2btnRepportUserConnected.Name = "guna2btnRepportUserConnected";
            this.guna2btnRepportUserConnected.Size = new System.Drawing.Size(270, 45);
            this.guna2btnRepportUserConnected.TabIndex = 4;
            this.guna2btnRepportUserConnected.Text = "Users that were connected";
            this.guna2btnRepportUserConnected.Click += new System.EventHandler(this.guna2btnRepportUserConnected_Click);
            // 
            // guna2btnRepportAll
            // 
            this.guna2btnRepportAll.BorderRadius = 10;
            this.guna2btnRepportAll.CheckedState.FillColor = System.Drawing.Color.Teal;
            this.guna2btnRepportAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2btnRepportAll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnRepportAll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnRepportAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2btnRepportAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2btnRepportAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2btnRepportAll.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2btnRepportAll.ForeColor = System.Drawing.Color.White;
            this.guna2btnRepportAll.Location = new System.Drawing.Point(81, 11);
            this.guna2btnRepportAll.Name = "guna2btnRepportAll";
            this.guna2btnRepportAll.Size = new System.Drawing.Size(86, 45);
            this.guna2btnRepportAll.TabIndex = 5;
            this.guna2btnRepportAll.Text = "All";
            this.guna2btnRepportAll.Click += new System.EventHandler(this.guna2btnRepportAll_Click);
            // 
            // guna2btnRepportEmpUpdated
            // 
            this.guna2btnRepportEmpUpdated.BorderRadius = 10;
            this.guna2btnRepportEmpUpdated.CheckedState.FillColor = System.Drawing.Color.Teal;
            this.guna2btnRepportEmpUpdated.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2btnRepportEmpUpdated.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnRepportEmpUpdated.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnRepportEmpUpdated.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2btnRepportEmpUpdated.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2btnRepportEmpUpdated.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2btnRepportEmpUpdated.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2btnRepportEmpUpdated.ForeColor = System.Drawing.Color.White;
            this.guna2btnRepportEmpUpdated.Location = new System.Drawing.Point(782, 11);
            this.guna2btnRepportEmpUpdated.Name = "guna2btnRepportEmpUpdated";
            this.guna2btnRepportEmpUpdated.Size = new System.Drawing.Size(270, 45);
            this.guna2btnRepportEmpUpdated.TabIndex = 6;
            this.guna2btnRepportEmpUpdated.Text = "Employees that were updated";
            this.guna2btnRepportEmpUpdated.Click += new System.EventHandler(this.guna2btnRepportEmpUpdated_Click);
            // 
            // UC_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.Controls.Add(this.guna2btnRepportEmpUpdated);
            this.Controls.Add(this.guna2btnRepportAll);
            this.Controls.Add(this.guna2btnRepportUserConnected);
            this.Controls.Add(this.guna2TxtSearch);
            this.Controls.Add(this.guna2btnRepportEmpDeleted);
            this.Controls.Add(this.guna2btnRepportEmpAdded);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "UC_History";
            this.Size = new System.Drawing.Size(1120, 746);
            this.Load += new System.EventHandler(this.UC_History_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridViewHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridViewHistory;
        private Guna.UI2.WinForms.Guna2Button guna2btnRepportEmpAdded;
        private Guna.UI2.WinForms.Guna2Button guna2btnRepportEmpDeleted;
        private Guna.UI2.WinForms.Guna2TextBox guna2TxtSearch;
        private Guna.UI2.WinForms.Guna2Button guna2btnRepportUserConnected;
        private Guna.UI2.WinForms.Guna2Button guna2btnRepportAll;
        private Guna.UI2.WinForms.Guna2Button guna2btnRepportEmpUpdated;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnPostName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnGivenName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnRaison;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnDate;
    }
}
