namespace MunicipalServices
{
    partial class EventsForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lsvEvents = new System.Windows.Forms.ListView();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblFilterCategory = new System.Windows.Forms.Label();
            this.cmbFilterCategory = new System.Windows.Forms.ComboBox();
            this.rtbEventDetails = new System.Windows.Forms.RichTextBox();
            this.lblEventDetails = new System.Windows.Forms.Label();
            this.lblRecommendations = new System.Windows.Forms.Label();
            this.lsvRecommendations = new System.Windows.Forms.ListView();
            this.colRecName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRecCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(414, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Local Events && Announcements";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(622, 549);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 40);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back to Menu";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lsvEvents
            // 
            this.lsvEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colName,
            this.colCategory});
            this.lsvEvents.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lsvEvents.FullRowSelect = true;
            this.lsvEvents.GridLines = true;
            this.lsvEvents.HideSelection = false;
            this.lsvEvents.Location = new System.Drawing.Point(36, 136);
            this.lsvEvents.MultiSelect = false;
            this.lsvEvents.Name = "lsvEvents";
            this.lsvEvents.Size = new System.Drawing.Size(450, 250);
            this.lsvEvents.TabIndex = 11;
            this.lsvEvents.UseCompatibleStateImageBehavior = false;
            this.lsvEvents.View = System.Windows.Forms.View.Details;
            this.lsvEvents.SelectedIndexChanged += new System.EventHandler(this.lsvEvents_SelectedIndexChanged);
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 100;
            // 
            // colName
            // 
            this.colName.Text = "Event Name";
            this.colName.Width = 220;
            // 
            // colCategory
            // 
            this.colCategory.Text = "Category";
            this.colCategory.Width = 120;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblSearch.Location = new System.Drawing.Point(33, 93);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(109, 17);
            this.lblSearch.TabIndex = 12;
            this.lblSearch.Text = "Search Events:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Arial", 11.25F);
            this.txtSearch.Location = new System.Drawing.Point(148, 90);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(257, 25);
            this.txtSearch.TabIndex = 13;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(411, 89);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 27);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblFilterCategory
            // 
            this.lblFilterCategory.AutoSize = true;
            this.lblFilterCategory.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblFilterCategory.Location = new System.Drawing.Point(513, 93);
            this.lblFilterCategory.Name = "lblFilterCategory";
            this.lblFilterCategory.Size = new System.Drawing.Size(125, 17);
            this.lblFilterCategory.TabIndex = 15;
            this.lblFilterCategory.Text = "Filter by Category:";
            // 
            // cmbFilterCategory
            // 
            this.cmbFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterCategory.Font = new System.Drawing.Font("Arial", 11.25F);
            this.cmbFilterCategory.FormattingEnabled = true;
            this.cmbFilterCategory.Location = new System.Drawing.Point(516, 136);
            this.cmbFilterCategory.Name = "cmbFilterCategory";
            this.cmbFilterCategory.Size = new System.Drawing.Size(256, 25);
            this.cmbFilterCategory.TabIndex = 16;
            this.cmbFilterCategory.SelectedIndexChanged += new System.EventHandler(this.cmbFilterCategory_SelectedIndexChanged);
            // 
            // rtbEventDetails
            // 
            this.rtbEventDetails.Font = new System.Drawing.Font("Arial", 9.75F);
            this.rtbEventDetails.Location = new System.Drawing.Point(36, 424);
            this.rtbEventDetails.Name = "rtbEventDetails";
            this.rtbEventDetails.ReadOnly = true;
            this.rtbEventDetails.Size = new System.Drawing.Size(450, 165);
            this.rtbEventDetails.TabIndex = 17;
            this.rtbEventDetails.Text = "";
            // 
            // lblEventDetails
            // 
            this.lblEventDetails.AutoSize = true;
            this.lblEventDetails.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblEventDetails.Location = new System.Drawing.Point(33, 403);
            this.lblEventDetails.Name = "lblEventDetails";
            this.lblEventDetails.Size = new System.Drawing.Size(103, 18);
            this.lblEventDetails.TabIndex = 18;
            this.lblEventDetails.Text = "Event Details:";
            // 
            // lblRecommendations
            // 
            this.lblRecommendations.AutoSize = true;
            this.lblRecommendations.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblRecommendations.Location = new System.Drawing.Point(513, 187);
            this.lblRecommendations.Name = "lblRecommendations";
            this.lblRecommendations.Size = new System.Drawing.Size(161, 18);
            this.lblRecommendations.TabIndex = 19;
            this.lblRecommendations.Text = "You Might Also Like...";
            // 
            // lsvRecommendations
            // 
            this.lsvRecommendations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRecName,
            this.colRecCategory});
            this.lsvRecommendations.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lsvRecommendations.Location = new System.Drawing.Point(516, 208);
            this.lsvRecommendations.Name = "lsvRecommendations";
            this.lsvRecommendations.Size = new System.Drawing.Size(256, 178);
            this.lsvRecommendations.TabIndex = 20;
            this.lsvRecommendations.UseCompatibleStateImageBehavior = false;
            this.lsvRecommendations.View = System.Windows.Forms.View.Details;
            // 
            // colRecName
            // 
            this.colRecName.Text = "Event Name";
            this.colRecName.Width = 150;
            // 
            // colRecCategory
            // 
            this.colRecCategory.Text = "Category";
            this.colRecCategory.Width = 100;
            // 
            // EventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 611);
            this.Controls.Add(this.lsvRecommendations);
            this.Controls.Add(this.lblRecommendations);
            this.Controls.Add(this.lblEventDetails);
            this.Controls.Add(this.rtbEventDetails);
            this.Controls.Add(this.cmbFilterCategory);
            this.Controls.Add(this.lblFilterCategory);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lsvEvents);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EventsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Events and Announcements";
            this.Load += new System.EventHandler(this.EventsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ListView lsvEvents;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblFilterCategory;
        private System.Windows.Forms.ComboBox cmbFilterCategory;
        private System.Windows.Forms.RichTextBox rtbEventDetails;
        private System.Windows.Forms.Label lblEventDetails;
        private System.Windows.Forms.Label lblRecommendations;
        private System.Windows.Forms.ListView lsvRecommendations;
        private System.Windows.Forms.ColumnHeader colRecName;
        private System.Windows.Forms.ColumnHeader colRecCategory;
    }
}
