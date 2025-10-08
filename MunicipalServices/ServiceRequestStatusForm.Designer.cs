namespace MunicipalServices
{
    partial class ServiceRequestStatusForm
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
            this.txtReferenceId = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblTableTitle = new System.Windows.Forms.Label();
            this.lvServiceRequests = new System.Windows.Forms.ListView();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.lblLocationLabel = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtRouteInfo = new System.Windows.Forms.TextBox();
            this.btnCalculateRoute = new System.Windows.Forms.Button();
            this.lblHistoryLabel = new System.Windows.Forms.Label();
            this.lstStatusHistory = new System.Windows.Forms.ListBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescriptionLabel = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblCategoryLabel = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.lblRequestId = new System.Windows.Forms.Label();
            this.lblRequestIdLabel = new System.Windows.Forms.Label();
            this.lblEnterId = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(332, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Service Request Status";
            // 
            // txtReferenceId
            // 
            this.txtReferenceId.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferenceId.Location = new System.Drawing.Point(31, 95);
            this.txtReferenceId.Name = "txtReferenceId";
            this.txtReferenceId.Size = new System.Drawing.Size(350, 26);
            this.txtReferenceId.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(387, 93);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblTableTitle
            // 
            this.lblTableTitle.AutoSize = true;
            this.lblTableTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTableTitle.Location = new System.Drawing.Point(720, 40);
            this.lblTableTitle.Name = "lblTableTitle";
            this.lblTableTitle.Size = new System.Drawing.Size(214, 22);
            this.lblTableTitle.TabIndex = 6;
            this.lblTableTitle.Text = "Current Service Requests";
            // 
            // lvServiceRequests
            // 
            this.lvServiceRequests.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvServiceRequests.FullRowSelect = true;
            this.lvServiceRequests.GridLines = true;
            this.lvServiceRequests.Location = new System.Drawing.Point(590, 70);
            this.lvServiceRequests.Name = "lvServiceRequests";
            this.lvServiceRequests.Size = new System.Drawing.Size(680, 540);
            this.lvServiceRequests.TabIndex = 4;
            this.lvServiceRequests.UseCompatibleStateImageBehavior = false;
            this.lvServiceRequests.View = System.Windows.Forms.View.Details;
            this.lvServiceRequests.SelectedIndexChanged += new System.EventHandler(this.lvServiceRequests_SelectedIndexChanged);
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.lblLocationLabel);
            this.pnlDetails.Controls.Add(this.lblLocation);
            this.pnlDetails.Controls.Add(this.txtRouteInfo);
            this.pnlDetails.Controls.Add(this.btnCalculateRoute);
            this.pnlDetails.Controls.Add(this.lblHistoryLabel);
            this.pnlDetails.Controls.Add(this.lstStatusHistory);
            this.pnlDetails.Controls.Add(this.txtDescription);
            this.pnlDetails.Controls.Add(this.lblDescriptionLabel);
            this.pnlDetails.Controls.Add(this.lblCategory);
            this.pnlDetails.Controls.Add(this.lblCategoryLabel);
            this.pnlDetails.Controls.Add(this.lblStatus);
            this.pnlDetails.Controls.Add(this.lblStatusLabel);
            this.pnlDetails.Controls.Add(this.lblRequestId);
            this.pnlDetails.Controls.Add(this.lblRequestIdLabel);
            this.pnlDetails.Location = new System.Drawing.Point(12, 140);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(570, 500);
            this.pnlDetails.TabIndex = 3;
            this.pnlDetails.Visible = false;
            // 
            // lblLocationLabel
            // 
            this.lblLocationLabel.AutoSize = true;
            this.lblLocationLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationLabel.Location = new System.Drawing.Point(15, 80);
            this.lblLocationLabel.Name = "lblLocationLabel";
            this.lblLocationLabel.Size = new System.Drawing.Size(80, 19);
            this.lblLocationLabel.TabIndex = 13;
            this.lblLocationLabel.Text = "Location:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(101, 81);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(35, 18);
            this.lblLocation.TabIndex = 12;
            this.lblLocation.Text = "N/A";
            // 
            // txtRouteInfo
            // 
            this.txtRouteInfo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRouteInfo.Location = new System.Drawing.Point(19, 388);
            this.txtRouteInfo.Multiline = true;
            this.txtRouteInfo.Name = "txtRouteInfo";
            this.txtRouteInfo.ReadOnly = true;
            this.txtRouteInfo.Size = new System.Drawing.Size(530, 100);
            this.txtRouteInfo.TabIndex = 11;
            // 
            // btnCalculateRoute
            // 
            this.btnCalculateRoute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnCalculateRoute.Enabled = false;
            this.btnCalculateRoute.FlatAppearance.BorderSize = 0;
            this.btnCalculateRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculateRoute.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculateRoute.ForeColor = System.Drawing.Color.White;
            this.btnCalculateRoute.Location = new System.Drawing.Point(379, 347);
            this.btnCalculateRoute.Name = "btnCalculateRoute";
            this.btnCalculateRoute.Size = new System.Drawing.Size(170, 35);
            this.btnCalculateRoute.TabIndex = 10;
            this.btnCalculateRoute.Text = "Calculate Dispatch Route";
            this.btnCalculateRoute.UseVisualStyleBackColor = false;
            this.btnCalculateRoute.Click += new System.EventHandler(this.btnCalculateRoute_Click);
            // 
            // lblHistoryLabel
            // 
            this.lblHistoryLabel.AutoSize = true;
            this.lblHistoryLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistoryLabel.Location = new System.Drawing.Point(15, 213);
            this.lblHistoryLabel.Name = "lblHistoryLabel";
            this.lblHistoryLabel.Size = new System.Drawing.Size(119, 19);
            this.lblHistoryLabel.TabIndex = 9;
            this.lblHistoryLabel.Text = "Status History";
            // 
            // lstStatusHistory
            // 
            this.lstStatusHistory.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstStatusHistory.FormattingEnabled = true;
            this.lstStatusHistory.ItemHeight = 16;
            this.lstStatusHistory.Location = new System.Drawing.Point(19, 235);
            this.lstStatusHistory.Name = "lstStatusHistory";
            this.lstStatusHistory.Size = new System.Drawing.Size(530, 100);
            this.lstStatusHistory.TabIndex = 8;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(19, 131);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(530, 70);
            this.txtDescription.TabIndex = 7;
            // 
            // lblDescriptionLabel
            // 
            this.lblDescriptionLabel.AutoSize = true;
            this.lblDescriptionLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionLabel.Location = new System.Drawing.Point(15, 109);
            this.lblDescriptionLabel.Name = "lblDescriptionLabel";
            this.lblDescriptionLabel.Size = new System.Drawing.Size(100, 19);
            this.lblDescriptionLabel.TabIndex = 6;
            this.lblDescriptionLabel.Text = "Description";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(101, 46);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(35, 18);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "N/A";
            // 
            // lblCategoryLabel
            // 
            this.lblCategoryLabel.AutoSize = true;
            this.lblCategoryLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryLabel.Location = new System.Drawing.Point(15, 45);
            this.lblCategoryLabel.Name = "lblCategoryLabel";
            this.lblCategoryLabel.Size = new System.Drawing.Size(82, 19);
            this.lblCategoryLabel.TabIndex = 4;
            this.lblCategoryLabel.Text = "Category:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblStatus.Location = new System.Drawing.Point(364, 11);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(180, 40);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "N/A";
            // 
            // lblStatusLabel
            // 
            this.lblStatusLabel.AutoSize = true;
            this.lblStatusLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusLabel.Location = new System.Drawing.Point(292, 17);
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new System.Drawing.Size(64, 19);
            this.lblStatusLabel.TabIndex = 2;
            this.lblStatusLabel.Text = "Status:";
            // 
            // lblRequestId
            // 
            this.lblRequestId.AutoSize = true;
            this.lblRequestId.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestId.Location = new System.Drawing.Point(125, 18);
            this.lblRequestId.Name = "lblRequestId";
            this.lblRequestId.Size = new System.Drawing.Size(35, 18);
            this.lblRequestId.TabIndex = 1;
            this.lblRequestId.Text = "N/A";
            // 
            // lblRequestIdLabel
            // 
            this.lblRequestIdLabel.AutoSize = true;
            this.lblRequestIdLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestIdLabel.Location = new System.Drawing.Point(15, 17);
            this.lblRequestIdLabel.Name = "lblRequestIdLabel";
            this.lblRequestIdLabel.Size = new System.Drawing.Size(113, 19);
            this.lblRequestIdLabel.TabIndex = 0;
            this.lblRequestIdLabel.Text = "Reference ID:";
            // 
            // lblEnterId
            // 
            this.lblEnterId.AutoSize = true;
            this.lblEnterId.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterId.Location = new System.Drawing.Point(28, 74);
            this.lblEnterId.Name = "lblEnterId";
            this.lblEnterId.Size = new System.Drawing.Size(200, 18);
            this.lblEnterId.TabIndex = 4;
            this.lblEnterId.Text = "Enter your Reference ID below:";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(31, 630);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 35);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back to Menu";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ServiceRequestStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1300, 680);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblEnterId);
            this.Controls.Add(this.lblTableTitle);
            this.Controls.Add(this.lvServiceRequests);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtReferenceId);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServiceRequestStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Service Request Status";
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtReferenceId;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblTableTitle;
        private System.Windows.Forms.ListView lvServiceRequests;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label lblRequestIdLabel;
        private System.Windows.Forms.Label lblRequestId;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblCategoryLabel;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescriptionLabel;
        private System.Windows.Forms.ListBox lstStatusHistory;
        private System.Windows.Forms.Label lblHistoryLabel;
        private System.Windows.Forms.Button btnCalculateRoute;
        private System.Windows.Forms.TextBox txtRouteInfo;
        private System.Windows.Forms.Label lblEnterId;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblLocationLabel;
        private System.Windows.Forms.Button btnBack;
    }
}
