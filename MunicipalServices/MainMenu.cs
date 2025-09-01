using System;
using System.Windows.Forms;

namespace MunicipalServices
{

    // The main menu form of the application.
    // It presents the user with the main tasks they can perform.
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        // Event handler for the "Report an Issue" button click.
        // This is the only active button as per the requirements.
        private void btnReportIssue_Click(object sender, EventArgs e)
        {
            // Create an instance of the ReportIssueForm.
            ReportIssueForm reportForm = new ReportIssueForm();

            // Hide the main menu.
            this.Hide();

            // Show the report issue form as a dialog. This means the user
            // must interact with it before returning to other parts of the app.
            reportForm.ShowDialog();

            // After the report form is closed, show the main menu again.
            this.Show();
        }
    }
}
