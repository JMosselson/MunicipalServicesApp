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
            btnLocalEvents.Enabled = true;
            btnLocalEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            btnLocalEvents.Text = "Local Events & Announcements";
        }

        // Event handler for the "Report an Issue" button click.
        private void btnReportIssue_Click(object sender, EventArgs e)
        {
            ReportIssueForm reportForm = new ReportIssueForm();
            this.Hide();
            reportForm.ShowDialog();
            this.Show();
        }

        // Event handler for the "Local Events" button click.
        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            EventsForm eventsForm = new EventsForm();
            this.Hide();
            eventsForm.ShowDialog();
            this.Show();
        }
    }
}
