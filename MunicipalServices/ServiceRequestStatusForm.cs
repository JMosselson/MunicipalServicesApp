using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServices
{
    public partial class ServiceRequestStatusForm : Form
    {
        private ServiceRequest? currentRequest;

        public ServiceRequestStatusForm()
        {
            InitializeComponent();
            LoadAllServiceRequests(); // Load all requests when form opens
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string refId = txtReferenceId.Text.Trim();
            if (string.IsNullOrEmpty(refId))
            {
                MessageBox.Show("Please enter a Reference ID.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Search the Binary Search Tree
            currentRequest = DataManager.ServiceRequests.Search(refId);

            if (currentRequest == null)
            {
                MessageBox.Show("Service Request not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearDetails();
            }
            else
            {
                DisplayDetails();
            }
        }

        private void DisplayDetails()
        {
            if (currentRequest == null) return;
            
            lblRequestId.Text = currentRequest.ReferenceId;
            lblStatus.Text = currentRequest.GetCurrentStatus().Split('(')[0].Trim(); // Show only status text
            lblCategory.Text = currentRequest.Category;
            lblLocation.Text = currentRequest.Location;
            txtDescription.Text = currentRequest.Description;

            lstStatusHistory.Items.Clear();
            foreach (var status in currentRequest.StatusHistory.AsEnumerable().Reverse())
            {
                lstStatusHistory.Items.Add(status);
            }

            pnlDetails.Visible = true;
            btnCalculateRoute.Enabled = true;
        }

        private void ClearDetails()
        {
            pnlDetails.Visible = false;
            btnCalculateRoute.Enabled = false;
            txtRouteInfo.Text = string.Empty;
        }

        private void btnCalculateRoute_Click(object sender, EventArgs e)
        {
            if (currentRequest == null) return;

            // Find the shortest path using the Graph (Dijkstra's)
            var pathInfo = DataManager.DispatchGrid.FindShortestPath("Dispatch Center", currentRequest.Location);

            if (pathInfo != null)
            {
                var path = string.Join(" -> ", pathInfo.Item1);
                var time = pathInfo.Item2;
                txtRouteInfo.Text = $"Optimal Dispatch Route:\r\n{path}\r\n\r\nEstimated Travel Time: {time} minutes.";
            }
            else
            {
                txtRouteInfo.Text = "Could not calculate a route to the specified location. Location may not be on the dispatch grid.";
            }
        }
        
        // Load all service requests into the ListView
        private void LoadAllServiceRequests()
        {
            // Configure ListView columns
            lvServiceRequests.Columns.Clear();
            lvServiceRequests.Columns.Add("Reference ID", 140);
            lvServiceRequests.Columns.Add("Title", 180);
            lvServiceRequests.Columns.Add("Category", 110);
            lvServiceRequests.Columns.Add("Status", 140);
            lvServiceRequests.Columns.Add("Location", 120);
            lvServiceRequests.Columns.Add("Date", 100);
            
            // Load all service requests
            var allRequests = DataManager.GetAllServiceRequests();
            lvServiceRequests.Items.Clear();
            
            foreach (var request in allRequests)
            {
                var item = new ListViewItem(request.ReferenceId);
                item.SubItems.Add(request.Title);
                item.SubItems.Add(request.Category);
                item.SubItems.Add(request.GetCurrentStatus().Split('(')[0].Trim());
                item.SubItems.Add(request.Location);
                item.SubItems.Add(request.ReportedDate.ToString("MM/dd/yyyy"));
                item.Tag = request; // Store the full request object
                lvServiceRequests.Items.Add(item);
            }
        }
        
        // Handle ListView selection to show details
        private void lvServiceRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvServiceRequests.SelectedItems.Count > 0)
            {
                currentRequest = (ServiceRequest?)lvServiceRequests.SelectedItems[0].Tag;
                if (currentRequest != null)
                {
                    DisplayDetails();
                }
            }
        }
        
        // Event handler for the "Back to Menu" button click.
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Closes the current form. The main menu will then become visible again.
            this.Close();
        }
    }
}
