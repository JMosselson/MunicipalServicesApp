using System;
using System.Drawing;
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
            
            // Also create a ServiceRequest for status tracking integration
            DataManager.CreateServiceRequestFromIssue(newIssue);

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

            // Show a custom success dialog with copyable reference ID
            ShowSuccessDialog(newIssue.ReferenceId);

            // Close the form after user acknowledges
            this.Close();
        }
        
        // Show a custom success dialog with copyable reference ID
        private void ShowSuccessDialog(string referenceId)
        {
            Form successForm = new Form()
            {
                Text = "Submission Successful",
                Size = new Size(500, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label titleLabel = new Label()
            {
                Text = "Thank you for your submission!",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(44, 62, 80),
                Location = new Point(20, 20),
                Size = new Size(450, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label messageLabel = new Label()
            {
                Text = "Your issue has been successfully logged. Please save your Reference ID below to track the status of your request:",
                Font = new Font("Arial", 10),
                Location = new Point(20, 60),
                Size = new Size(450, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label refLabel = new Label()
            {
                Text = "Reference ID:",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(20, 120),
                Size = new Size(100, 20)
            };

            TextBox refTextBox = new TextBox()
            {
                Text = referenceId,
                Font = new Font("Courier New", 12, FontStyle.Bold),
                Location = new Point(20, 145),
                Size = new Size(300, 25),
                ReadOnly = true,
                BackColor = System.Drawing.Color.LightYellow,
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = HorizontalAlignment.Center
            };

            Button copyButton = new Button()
            {
                Text = "Copy to Clipboard",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(330, 143),
                Size = new Size(120, 29),
                BackColor = System.Drawing.Color.FromArgb(52, 152, 219),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat
            };
            copyButton.FlatAppearance.BorderSize = 0;

            Button okButton = new Button()
            {
                Text = "OK",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(200, 200),
                Size = new Size(100, 35),
                BackColor = System.Drawing.Color.FromArgb(46, 204, 113),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.OK
            };
            okButton.FlatAppearance.BorderSize = 0;

            // Add tooltips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(refTextBox, "Click to select all text, then Ctrl+C to copy");
            toolTip.SetToolTip(copyButton, "Click to copy Reference ID to clipboard");

            // Copy button click event
            copyButton.Click += async (sender, e) =>
            {
                Clipboard.SetText(referenceId);
                copyButton.Text = "Copied!";
                copyButton.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
                
                await Task.Delay(2000);
                
                // Check if the button is still valid and has a handle before invoking
                if (!copyButton.IsDisposed && copyButton.IsHandleCreated)
                {
                    copyButton.Text = "Copy to Clipboard";
                    copyButton.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
                }
            };

            // Select all text when textbox is clicked
            refTextBox.Click += (sender, e) => refTextBox.SelectAll();
            refTextBox.Enter += (sender, e) => refTextBox.SelectAll();

            successForm.Controls.Add(titleLabel);
            successForm.Controls.Add(messageLabel);
            successForm.Controls.Add(refLabel);
            successForm.Controls.Add(refTextBox);
            successForm.Controls.Add(copyButton);
            successForm.Controls.Add(okButton);

            successForm.AcceptButton = okButton;
            successForm.ShowDialog(this);
        }
    }
}
