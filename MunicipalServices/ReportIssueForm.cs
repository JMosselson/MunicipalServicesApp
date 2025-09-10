using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServices
{
    // The form for reporting a new issue.
    // It collects all necessary details from the user and includes the user engagement feature.
    public partial class ReportIssueForm : Form
    {
        // A private field to store the path of the file the user attaches.
        private string attachedFilePath = string.Empty;

        public ReportIssueForm()
        {
            InitializeComponent();
            // Set a default selection for the category dropdown.
            cmbCategory.SelectedIndex = 0;
        }


        // Event handler for the "Back to Menu" button click.
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Closes the current form. The main menu will then become visible again.
            this.Close();
        }

        // Event handler for the "Attach Image/Document" button click.
        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            // Create a new OpenFileDialog to allow the user to select a file.
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a file to attach";
                // Filter for common image and document types.
                openFileDialog.Filter = "Media Files|*.jpg;*.jpeg;*.png;*.bmp;*.pdf;*.doc;*.docx|All files (*.*)|*.*";

                // If the user selects a file and clicks OK...
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Store the path of the selected file.
                    attachedFilePath = openFileDialog.FileName;
                    // Update the label to show the name of the attached file.
                    lblAttachment.Text = Path.GetFileName(attachedFilePath);
                }
            }
        }

        // Event handler for the "Submit Report" button click.
        // This method is async to allow for the engagement feature simulation without freezing the UI.
        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            // --- 1. Validation ---
            // Check if essential fields are filled out.
            if (string.IsNullOrWhiteSpace(txtLocation.Text) ||
                string.IsNullOrWhiteSpace(rtbDescription.Text) ||
                cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill out all required fields (Location, Category, and Description).",
                                "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop the submission process.
            }

            // --- 2. Data Handling ---
            // Create a new Issue object with the data from the form.
            var newIssue = new Issue(
                txtLocation.Text,
                cmbCategory.SelectedItem.ToString(),
                rtbDescription.Text,
                attachedFilePath
            );

            // Add the new issue to our static list (in-memory data store).
            DataManager.ReportedIssues.Add(newIssue);

            // --- 3. User Engagement and Feedback ---
            // Disable buttons to prevent multiple submissions.
            btnSubmit.Enabled = false;
            btnBack.Enabled = false;

            // Simulate the "Transparent Feedback Loop"
            lblEngagementStatus.Text = "Submitting your report...";
            engagementProgressBar.Value = 25;
            await Task.Delay(1000); // Wait for 1 second

            lblEngagementStatus.Text = "Report successfully received!";
            engagementProgressBar.Value = 75;
            await Task.Delay(1000); // Wait for 1 second

            lblEngagementStatus.Text = $"Logged with Reference ID: {newIssue.ReferenceId}";
            engagementProgressBar.Value = 100;

            // Show a final success message to the user.
            MessageBox.Show($"Thank you for your submission!\n\nYour Reference ID is: {newIssue.ReferenceId}\n\nPlease use this ID to track the status of your request in the future.",
                            "Submission Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Close the form after a short delay.
            await Task.Delay(1500);
            this.Close();
        }
    }
}
