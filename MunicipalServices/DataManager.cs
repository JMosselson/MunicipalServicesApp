using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalServices
{
    // A static class to manage all application data.
    // This acts as a centralized, in-memory database for the app's lifecycle.
    public static class DataManager
    {
        // --- Data from Part 1 ---
        public static List<Issue> ReportedIssues { get; private set; } = new List<Issue>();

        // --- Data Structures for Part 2: Events ---
            

        // A SortedDictionary to store all events.
        // Key: The date of the event.
        // Value: A list of events scheduled for that date.
        // This structure automatically keeps events organized chronologically.
        public static SortedDictionary<DateTime, List<Event>> EventsByDate { get; private set; }
            = new SortedDictionary<DateTime, List<Event>>();

        // A HashSet to store all unique event categories.
        // This is efficient for populating filter dropdowns and preventing duplicate categories.
        public static HashSet<string> UniqueEventCategories { get; private set; } = new HashSet<string>();

        // A Queue to store the user's recent search queries.
        // Used for the recommendation feature. It keeps a running list of the last 5 searches.
        public static Queue<string> UserSearchHistory { get; private set; } = new Queue<string>();

        // Static constructor to initialize the DataManager with some sample data.
        // This runs only once when the class is first accessed.
        static DataManager()
        {
            // Populate with some sample events for demonstration.
            AddEvent(new Event("Community Market Day", "Markets", new DateTime(2025, 8, 16), "Join us for a day of fun, food, and local crafts at the central park."));
            AddEvent(new Event("Load Shedding: Stage 4", "Utilities", new DateTime(2025, 8, 15), "Stage 4 load shedding will be implemented from 4 PM to 10 PM."));
            AddEvent(new Event("Town Hall Meeting", "Community", new DateTime(2025, 8, 20), "Public meeting to discuss the new budget. All are welcome."));
            AddEvent(new Event("Road Closure Notice", "Roads", new DateTime(2025, 8, 18), "Main Street will be closed between 9 AM and 3 PM for repairs."));
            AddEvent(new Event("Youth Day Soccer Tournament", "Sports", new DateTime(2025, 8, 23), "Annual youth soccer tournament at the community sports ground."));
            AddEvent(new Event("Library Book Fair", "Community", new DateTime(2025, 8, 23), "Visit the library for a wide range of second-hand books on sale."));
        }

        // Helper method to add a new event to our data structures.
        private static void AddEvent(Event newEvent)
        {
            // Add the event to the SortedDictionary.
            DateTime eventDate = newEvent.Date.Date; // Use .Date to ignore the time part for grouping.
            if (!EventsByDate.ContainsKey(eventDate))
            {
                EventsByDate[eventDate] = new List<Event>();
            }
            EventsByDate[eventDate].Add(newEvent);

            // Add the category to the HashSet of unique categories.
            UniqueEventCategories.Add(newEvent.Category);
        }

        // Adds a search term to the user's history queue.
        public static void AddSearchTerm(string term)
        {
            if (string.IsNullOrWhiteSpace(term)) return;

            UserSearchHistory.Enqueue(term.ToLower());
            // Keep the queue size limited to the last 5 searches.
            if (UserSearchHistory.Count > 5)
            {
                UserSearchHistory.Dequeue();
            }
        }
    }

    // Represents a single local event or announcement.
    public class Event
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Event(string name, string category, DateTime date, string description)
        {
            Name = name;
            Category = category;
            Date = date;
            Description = description;
        }
    }
}
