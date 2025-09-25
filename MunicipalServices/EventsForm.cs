using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServices
{
    // Form to display, search, and filter local events and announcements.
    public partial class EventsForm : Form
    {
        public EventsForm()
        {
            InitializeComponent();
        }

        // Handles the form's Load event. This is where we initialize the display.
        private void EventsForm_Load(object sender, EventArgs e)
        {
            // Populate the category filter dropdown from our HashSet of unique categories.
            cmbFilterCategory.Items.Add("All Categories");
            foreach (var category in DataManager.UniqueEventCategories.OrderBy(c => c))
            {
                cmbFilterCategory.Items.Add(category);
            }
            cmbFilterCategory.SelectedIndex = 0;

            // Load all events initially.
            DisplayEvents(DataManager.EventsByDate.Values.SelectMany(list => list).ToList());
        }

        // A helper method to display a list of events in the main ListView.
        private void DisplayEvents(List<Event> events)
        {
            lsvEvents.Items.Clear(); // Clear previous results.
            foreach (var ev in events.OrderBy(e => e.Date))
            {
                var listViewItem = new ListViewItem(ev.Date.ToString("yyyy-MM-dd"));
                listViewItem.SubItems.Add(ev.Name);
                listViewItem.SubItems.Add(ev.Category);
                listViewItem.Tag = ev; // Store the full Event object in the Tag property.
                lsvEvents.Items.Add(listViewItem);
            }
        }

        // Handles the "Back to Menu" button click.
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Handles the "Search" button click.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower();

            // Add the search term to our history Queue for recommendations.
            DataManager.AddSearchTerm(searchTerm);

            // Perform the search across all events.
            var searchResults = DataManager.EventsByDate.Values
                .SelectMany(list => list) // Flatten the dictionary values into a single list of events
                .Where(ev => ev.Name.ToLower().Contains(searchTerm) ||
                             ev.Description.ToLower().Contains(searchTerm))
                .ToList();

            DisplayEvents(searchResults);
            UpdateRecommendations();
        }

        // Handles selection changes in the category filter dropdown.
        private void cmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedCategory = cmbFilterCategory.SelectedItem?.ToString();
            if (selectedCategory == null) return;

            if (selectedCategory == "All Categories")
            {
                // If "All" is selected, display all events.
                DisplayEvents(DataManager.EventsByDate.Values.SelectMany(list => list).ToList());
            }
            else
            {
                // Filter events by the selected category.
                var filteredResults = DataManager.EventsByDate.Values
                    .SelectMany(list => list)
                    .Where(ev => ev.Category == selectedCategory)
                    .ToList();
                DisplayEvents(filteredResults);
            }
        }

        // Handles selection changes in the main events ListView.
        private void lsvEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If an item is selected, display its full description.
            if (lsvEvents.SelectedItems.Count > 0)
            {
                var selectedEvent = (Event?)lsvEvents.SelectedItems[0].Tag;
                if (selectedEvent != null)
                {
                    rtbEventDetails.Text = $"Event: {selectedEvent.Name}\n" +
                                           $"Category: {selectedEvent.Category}\n" +
                                           $"Date: {selectedEvent.Date:dddd, dd MMMM yyyy}\n\n" +
                                           $"Description:\n{selectedEvent.Description}";
                }
            }
        }

        // Updates the recommendation list based on the user's search history.
        private void UpdateRecommendations()
        {
            lsvRecommendations.Items.Clear();
            if (DataManager.UserSearchHistory.Count == 0) return;

            // Get the category of the last search result to base recommendations on.
            string lastSearchTerm = DataManager.UserSearchHistory.Last();
            var lastSearchedEvent = DataManager.EventsByDate.Values
                .SelectMany(list => list)
                .FirstOrDefault(ev => ev.Name.ToLower().Contains(lastSearchTerm) ||
                                     ev.Description.ToLower().Contains(lastSearchTerm));

            if (lastSearchedEvent == null) return; // No matching event found for the last search.

            string targetCategory = lastSearchedEvent.Category;

            // Find other upcoming events in the same category.
            var recommendations = DataManager.EventsByDate.Values
                .SelectMany(list => list)
                .Where(ev => ev.Category == targetCategory &&
                             ev.Name != lastSearchedEvent.Name && // Exclude the event itself
                             ev.Date.Date >= DateTime.Today) // Only show future events
                .OrderBy(ev => ev.Date)
                .Take(5) // Limit to 5 recommendations.
                .ToList();

            foreach (var rec in recommendations)
            {
                var listViewItem = new ListViewItem(rec.Name);
                listViewItem.SubItems.Add(rec.Category);
                listViewItem.Tag = rec; // Store the full Event object in the Tag property.
                lsvRecommendations.Items.Add(listViewItem);
            }
        }
        
        // Handles selection changes in the recommendations ListView.
        private void lsvRecommendations_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If a recommendation is selected, display its full description.
            if (lsvRecommendations.SelectedItems.Count > 0)
            {
                var selectedEvent = (Event?)lsvRecommendations.SelectedItems[0].Tag;
                if (selectedEvent != null)
                {
                    rtbEventDetails.Text = $"Event: {selectedEvent.Name}\n" +
                                           $"Category: {selectedEvent.Category}\n" +
                                           $"Date: {selectedEvent.Date:dddd, dd MMMM yyyy}\n\n" +
                                           $"Description:\n{selectedEvent.Description}";
                }
            }
        }
    }
}
