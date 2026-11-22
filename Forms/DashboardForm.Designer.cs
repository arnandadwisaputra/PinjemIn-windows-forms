namespace PinjemIn.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.panelUsers = new System.Windows.Forms.Panel();
            this.lblTotalUsers = new System.Windows.Forms.Label();
            this.lblUsersLabel = new System.Windows.Forms.Label();
            this.panelCategories = new System.Windows.Forms.Panel();
            this.lblTotalCategories = new System.Windows.Forms.Label();
            this.lblCategoriesLabel = new System.Windows.Forms.Label();
            this.panelItems = new System.Windows.Forms.Panel();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.lblItemsLabel = new System.Windows.Forms.Label();
            this.panelRentals = new System.Windows.Forms.Panel();
            this.lblTotalRentals = new System.Windows.Forms.Label();
            this.lblRentalsLabel = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelStats.SuspendLayout();
            this.panelUsers.SuspendLayout();
            this.panelCategories.SuspendLayout();
            this.panelItems.SuspendLayout();
            this.panelRentals.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDashboardTitle
            // 
            this.lblDashboardTitle.AutoSize = true;
            this.lblDashboardTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboardTitle.Location = new System.Drawing.Point(20, 20);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(158, 31);
            this.lblDashboardTitle.TabIndex = 0;
            this.lblDashboardTitle.Text = "Dashboard";
            // 
            // panelStats
            // 
            this.panelStats.Controls.Add(this.panelUsers);
            this.panelStats.Controls.Add(this.panelCategories);
            this.panelStats.Controls.Add(this.panelItems);
            this.panelStats.Controls.Add(this.panelRentals);
            this.panelStats.Location = new System.Drawing.Point(20, 70);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(950, 150);
            this.panelStats.TabIndex = 1;
            // 
            // panelUsers
            // 
            this.panelUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelUsers.Controls.Add(this.lblTotalUsers);
            this.panelUsers.Controls.Add(this.lblUsersLabel);
            this.panelUsers.Location = new System.Drawing.Point(10, 10);
            this.panelUsers.Name = "panelUsers";
            this.panelUsers.Size = new System.Drawing.Size(220, 130);
            this.panelUsers.TabIndex = 0;
            // 
            // lblTotalUsers
            // 
            this.lblTotalUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalUsers.ForeColor = System.Drawing.Color.White;
            this.lblTotalUsers.Location = new System.Drawing.Point(10, 50);
            this.lblTotalUsers.Name = "lblTotalUsers";
            this.lblTotalUsers.Size = new System.Drawing.Size(200, 54);
            this.lblTotalUsers.TabIndex = 1;
            this.lblTotalUsers.Text = "0";
            this.lblTotalUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsersLabel
            // 
            this.lblUsersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsersLabel.ForeColor = System.Drawing.Color.White;
            this.lblUsersLabel.Location = new System.Drawing.Point(10, 15);
            this.lblUsersLabel.Name = "lblUsersLabel";
            this.lblUsersLabel.Size = new System.Drawing.Size(200, 23);
            this.lblUsersLabel.TabIndex = 0;
            this.lblUsersLabel.Text = "Total Pengguna";
            this.lblUsersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCategories
            // 
            this.panelCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.panelCategories.Controls.Add(this.lblTotalCategories);
            this.panelCategories.Controls.Add(this.lblCategoriesLabel);
            this.panelCategories.Location = new System.Drawing.Point(250, 10);
            this.panelCategories.Name = "panelCategories";
            this.panelCategories.Size = new System.Drawing.Size(220, 130);
            this.panelCategories.TabIndex = 1;
            // 
            // lblTotalCategories
            // 
            this.lblTotalCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCategories.ForeColor = System.Drawing.Color.White;
            this.lblTotalCategories.Location = new System.Drawing.Point(10, 50);
            this.lblTotalCategories.Name = "lblTotalCategories";
            this.lblTotalCategories.Size = new System.Drawing.Size(200, 54);
            this.lblTotalCategories.TabIndex = 1;
            this.lblTotalCategories.Text = "0";
            this.lblTotalCategories.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCategoriesLabel
            // 
            this.lblCategoriesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoriesLabel.ForeColor = System.Drawing.Color.White;
            this.lblCategoriesLabel.Location = new System.Drawing.Point(10, 15);
            this.lblCategoriesLabel.Name = "lblCategoriesLabel";
            this.lblCategoriesLabel.Size = new System.Drawing.Size(200, 23);
            this.lblCategoriesLabel.TabIndex = 0;
            this.lblCategoriesLabel.Text = "Total Kategori";
            this.lblCategoriesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelItems
            // 
            this.panelItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.panelItems.Controls.Add(this.lblTotalItems);
            this.panelItems.Controls.Add(this.lblItemsLabel);
            this.panelItems.Location = new System.Drawing.Point(490, 10);
            this.panelItems.Name = "panelItems";
            this.panelItems.Size = new System.Drawing.Size(220, 130);
            this.panelItems.TabIndex = 2;
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItems.ForeColor = System.Drawing.Color.White;
            this.lblTotalItems.Location = new System.Drawing.Point(10, 50);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(200, 54);
            this.lblTotalItems.TabIndex = 1;
            this.lblTotalItems.Text = "0";
            this.lblTotalItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemsLabel
            // 
            this.lblItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsLabel.ForeColor = System.Drawing.Color.White;
            this.lblItemsLabel.Location = new System.Drawing.Point(10, 15);
            this.lblItemsLabel.Name = "lblItemsLabel";
            this.lblItemsLabel.Size = new System.Drawing.Size(200, 23);
            this.lblItemsLabel.TabIndex = 0;
            this.lblItemsLabel.Text = "Total Barang";
            this.lblItemsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelRentals
            // 
            this.panelRentals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.panelRentals.Controls.Add(this.lblTotalRentals);
            this.panelRentals.Controls.Add(this.lblRentalsLabel);
            this.panelRentals.Location = new System.Drawing.Point(730, 10);
            this.panelRentals.Name = "panelRentals";
            this.panelRentals.Size = new System.Drawing.Size(220, 130);
            this.panelRentals.TabIndex = 3;
            // 
            // lblTotalRentals
            // 
            this.lblTotalRentals.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRentals.ForeColor = System.Drawing.Color.White;
            this.lblTotalRentals.Location = new System.Drawing.Point(10, 50);
            this.lblTotalRentals.Name = "lblTotalRentals";
            this.lblTotalRentals.Size = new System.Drawing.Size(200, 54);
            this.lblTotalRentals.TabIndex = 1;
            this.lblTotalRentals.Text = "0";
            this.lblTotalRentals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRentalsLabel
            // 
            this.lblRentalsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRentalsLabel.ForeColor = System.Drawing.Color.White;
            this.lblRentalsLabel.Location = new System.Drawing.Point(10, 15);
            this.lblRentalsLabel.Name = "lblRentalsLabel";
            this.lblRentalsLabel.Size = new System.Drawing.Size(200, 23);
            this.lblRentalsLabel.TabIndex = 0;
            this.lblRentalsLabel.Text = "Total Transaksi";
            this.lblRentalsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(20, 240);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 40);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 540);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.lblDashboardTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardForm";
            this.Text = "Dashboard";
            this.panelStats.ResumeLayout(false);
            this.panelUsers.ResumeLayout(false);
            this.panelCategories.ResumeLayout(false);
            this.panelItems.ResumeLayout(false);
            this.panelRentals.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panelUsers;
        private System.Windows.Forms.Label lblTotalUsers;
        private System.Windows.Forms.Label lblUsersLabel;
        private System.Windows.Forms.Panel panelCategories;
        private System.Windows.Forms.Label lblTotalCategories;
        private System.Windows.Forms.Label lblCategoriesLabel;
        private System.Windows.Forms.Panel panelItems;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Label lblItemsLabel;
        private System.Windows.Forms.Panel panelRentals;
        private System.Windows.Forms.Label lblTotalRentals;
        private System.Windows.Forms.Label lblRentalsLabel;
        private System.Windows.Forms.Button btnRefresh;
    }
}