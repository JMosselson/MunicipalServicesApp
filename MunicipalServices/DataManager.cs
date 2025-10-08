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

        // --- Data Structures for Part 3: Service Requests ---
        
        // Binary Search Tree to store and efficiently search Service Requests by Reference ID
        public static BinarySearchTree ServiceRequests { get; private set; } = new BinarySearchTree();
        
        // AVL Tree for balanced service request storage with guaranteed O(log n) operations
        public static AVLTree AVLServiceRequests { get; private set; } = new AVLTree();
        
        // Red-Black Tree for balanced service request storage with good practical performance
        public static RedBlackTree RBServiceRequests { get; private set; } = new RedBlackTree();
        
        // Min-Heap for priority queuing of urgent service requests
        public static MinHeap PriorityQueue { get; private set; } = new MinHeap();
        
        // Graph to represent the dispatch grid for optimal route calculation
        public static Graph DispatchGrid { get; private set; } = new Graph();

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

        // Static constructor to initialize the DataManager with comprehensive sample data.
        // This runs only once when the class is first accessed.
        static DataManager()
        {
            // Populate with diverse events across multiple categories and dates
            
            // Community Events
            AddEvent(new Event("Community Market Day", "Community", new DateTime(2025, 10, 5), "Join us for a day of fun, food, and local crafts at the central park."));
            AddEvent(new Event("Town Hall Meeting", "Community", new DateTime(2025, 10, 15), "Public meeting to discuss the new budget. All are welcome."));
            AddEvent(new Event("Library Book Fair", "Community", new DateTime(2025, 10, 20), "Visit the library for a wide range of second-hand books on sale."));
            AddEvent(new Event("Neighbourhood Watch Meeting", "Community", new DateTime(2025, 11, 2), "Monthly meeting to discuss community safety and security matters."));
            AddEvent(new Event("Senior Citizens Tea Party", "Community", new DateTime(2025, 11, 8), "Social gathering for senior members of our community with refreshments."));
            AddEvent(new Event("Community Clean-Up Day", "Community", new DateTime(2025, 11, 15), "Volunteer event to clean and beautify our local parks and streets."));
            AddEvent(new Event("Holiday Festival Planning", "Community", new DateTime(2025, 12, 1), "Help plan our annual holiday festival and winter celebrations."));
            
            // Sports Events
            AddEvent(new Event("Youth Day Soccer Tournament", "Sports", new DateTime(2025, 10, 12), "Annual youth soccer tournament at the community sports ground."));
            AddEvent(new Event("Marathon Training Sessions", "Sports", new DateTime(2025, 10, 18), "Free coaching sessions for the upcoming city marathon in December."));
            AddEvent(new Event("Swimming Gala", "Sports", new DateTime(2025, 11, 5), "Inter-school swimming competition at the municipal pool."));
            AddEvent(new Event("Cricket Championship Finals", "Sports", new DateTime(2025, 11, 12), "Local cricket league championship match at the sports complex."));
            AddEvent(new Event("Tennis Club Open Day", "Sports", new DateTime(2025, 11, 18), "Free tennis lessons and equipment trial for new members."));
            AddEvent(new Event("Cycling Safety Workshop", "Sports", new DateTime(2025, 12, 8), "Learn road safety and maintenance tips for cycling enthusiasts."));
            AddEvent(new Event("New Year Fun Run", "Sports", new DateTime(2026, 1, 1), "Start the new year with a healthy 5km fun run through the city."));
            
            // Utilities & Infrastructure
            AddEvent(new Event("Load Shedding: Stage 2", "Utilities", new DateTime(2025, 10, 8), "Stage 2 load shedding will be implemented from 6 PM to 10 PM."));
            AddEvent(new Event("Water Maintenance Notice", "Utilities", new DateTime(2025, 10, 25), "Scheduled water supply interruption from 8 AM to 4 PM in sectors 3-5."));
            AddEvent(new Event("Electricity Meter Upgrades", "Utilities", new DateTime(2025, 11, 10), "Smart meter installation program begins in residential areas."));
            AddEvent(new Event("Internet Infrastructure Upgrade", "Utilities", new DateTime(2025, 11, 20), "Fiber optic cable installation may cause temporary service disruptions."));
            AddEvent(new Event("Waste Collection Schedule Change", "Utilities", new DateTime(2025, 12, 15), "New waste collection times and recycling guidelines take effect."));
            
            // Roads & Transportation
            AddEvent(new Event("Main Street Road Closure", "Roads", new DateTime(2025, 10, 10), "Main Street will be closed between 9 AM and 3 PM for repairs."));
            AddEvent(new Event("Traffic Light Installation", "Roads", new DateTime(2025, 10, 28), "New traffic lights being installed at Oak Avenue intersection."));
            AddEvent(new Event("Bridge Maintenance Work", "Roads", new DateTime(2025, 11, 6), "River bridge will have single-lane traffic during maintenance hours."));
            AddEvent(new Event("Pothole Repair Program", "Roads", new DateTime(2025, 11, 22), "City-wide pothole repairs starting in residential neighborhoods."));
            AddEvent(new Event("Bus Route Extension", "Roads", new DateTime(2025, 12, 3), "New bus route 47 extends to serve the eastern suburbs."));
            
            // Markets & Shopping
            AddEvent(new Event("Weekend Farmers Market", "Markets", new DateTime(2025, 10, 6), "Fresh produce, baked goods, and local crafts every Saturday morning."));
            AddEvent(new Event("Artisan Craft Fair", "Markets", new DateTime(2025, 10, 14), "Local artists and craftspeople showcase handmade goods and artwork."));
            AddEvent(new Event("Food Truck Festival", "Markets", new DateTime(2025, 11, 9), "Variety of food trucks offering cuisines from around the world."));
            AddEvent(new Event("Holiday Shopping Market", "Markets", new DateTime(2025, 12, 10), "Special holiday market with gift ideas and seasonal decorations."));
            AddEvent(new Event("Vintage Car Boot Sale", "Markets", new DateTime(2025, 12, 17), "Browse vintage items, antiques, and collectibles from local sellers."));
            
            // Health & Wellness
            AddEvent(new Event("Free Health Screening", "Health", new DateTime(2025, 10, 22), "Basic health checks including blood pressure and diabetes screening."));
            AddEvent(new Event("Mental Health Awareness Workshop", "Health", new DateTime(2025, 11, 14), "Educational session on stress management and mental wellness."));
            AddEvent(new Event("Vaccination Drive", "Health", new DateTime(2025, 11, 25), "Annual flu vaccination program at the community health center."));
            AddEvent(new Event("Fitness Bootcamp", "Health", new DateTime(2025, 12, 5), "Free outdoor fitness classes for all fitness levels in the park."));
            
            // Education & Learning
            AddEvent(new Event("Computer Literacy Classes", "Education", new DateTime(2025, 10, 30), "Basic computer skills training for seniors and beginners."));
            AddEvent(new Event("Financial Planning Seminar", "Education", new DateTime(2025, 11, 16), "Learn about budgeting, savings, and investment strategies."));
            AddEvent(new Event("Career Development Workshop", "Education", new DateTime(2025, 12, 12), "Resume writing and interview skills for job seekers."));
            AddEvent(new Event("Small Business Support Session", "Education", new DateTime(2026, 1, 8), "Resources and guidance for starting and running small businesses."));
            
            // Environmental
            AddEvent(new Event("Tree Planting Initiative", "Environment", new DateTime(2025, 10, 26), "Community tree planting event to increase green spaces in our area."));
            AddEvent(new Event("Recycling Education Program", "Environment", new DateTime(2025, 11, 30), "Learn proper recycling techniques and waste reduction strategies."));
            AddEvent(new Event("Earth Hour Participation", "Environment", new DateTime(2026, 3, 29), "Join the global movement to raise awareness about climate change."));
            
            // Cultural Events
            AddEvent(new Event("Heritage Day Celebration", "Culture", new DateTime(2025, 10, 24), "Celebrate our diverse cultural heritage with music, dance, and food."));
            AddEvent(new Event("Local Art Exhibition", "Culture", new DateTime(2025, 11, 7), "Showcasing artwork from talented local artists and students."));
            AddEvent(new Event("Music in the Park", "Culture", new DateTime(2025, 11, 21), "Live outdoor concert featuring local bands and musicians."));
            AddEvent(new Event("Christmas Carol Service", "Culture", new DateTime(2025, 12, 22), "Traditional carol singing event at the community center."));
            
            // Initialize Service Request data structures
            InitializeDispatchGrid();
            InitializeServiceRequests();
        }

        // Initialize the dispatch grid with sample locations and routes
        private static void InitializeDispatchGrid()
        {
            // Add nodes (locations) to the dispatch grid
            DispatchGrid.AddNode("Dispatch Center");
            DispatchGrid.AddNode("Downtown");
            DispatchGrid.AddNode("Residential Area A");
            DispatchGrid.AddNode("Residential Area B");
            DispatchGrid.AddNode("Industrial Zone");
            DispatchGrid.AddNode("Commercial District");
            DispatchGrid.AddNode("Parks and Recreation");
            DispatchGrid.AddNode("Hospital District");
            DispatchGrid.AddNode("School Zone");
            DispatchGrid.AddNode("Shopping Center");
            
            // Add edges (routes) with travel times in minutes
            DispatchGrid.AddEdge("Dispatch Center", "Downtown", 5);
            DispatchGrid.AddEdge("Dispatch Center", "Residential Area A", 8);
            DispatchGrid.AddEdge("Dispatch Center", "Industrial Zone", 12);
            DispatchGrid.AddEdge("Downtown", "Commercial District", 4);
            DispatchGrid.AddEdge("Downtown", "Hospital District", 6);
            DispatchGrid.AddEdge("Residential Area A", "Residential Area B", 7);
            DispatchGrid.AddEdge("Residential Area A", "School Zone", 5);
            DispatchGrid.AddEdge("Residential Area B", "Shopping Center", 6);
            DispatchGrid.AddEdge("Industrial Zone", "Commercial District", 10);
            DispatchGrid.AddEdge("Commercial District", "Shopping Center", 8);
            DispatchGrid.AddEdge("Hospital District", "School Zone", 9);
            DispatchGrid.AddEdge("Parks and Recreation", "School Zone", 4);
            DispatchGrid.AddEdge("Parks and Recreation", "Shopping Center", 7);
        }
        
        // Initialize sample service requests for testing and demonstration
        private static void InitializeServiceRequests()
        {
            // Create sample service requests with various statuses, categories, and proper times
            var request1 = new ServiceRequest("SR-20250915-001", "Pothole on Main Street", "Roads", 
                "Large pothole causing traffic issues on Main Street near the intersection with Oak Avenue.", 
                "Downtown", new DateTime(2025, 9, 15, 8, 30, 0));
            request1.UpdateStatus("Under Review");
            request1.UpdateStatus("Assigned to Road Maintenance Team");
            request1.UpdateStatus("Repair Completed");
            InsertIntoAllTrees(request1);
            
            var request2 = new ServiceRequest("SR-20250916-002", "Street Light Out", "Utilities", 
                "Street light not working on Pine Street, creating safety concerns for pedestrians.", 
                "Residential Area A", new DateTime(2025, 9, 16, 19, 45, 0));
            request2.UpdateStatus("Under Review");
            request2.UpdateStatus("Assigned to Electrical Team");
            InsertIntoAllTrees(request2);
            
            var request3 = new ServiceRequest("SR-20250918-003", "Water Leak", "Utilities", 
                "Water pipe leak causing flooding in the parking area of the shopping center.", 
                "Shopping Center", new DateTime(2025, 9, 18, 14, 20, 0));
            request3.UpdateStatus("Under Review");
            request3.UpdateStatus("Emergency Team Dispatched");
            request3.UpdateStatus("Repair In Progress");
            InsertIntoAllTrees(request3);
            PriorityQueue.Insert(new PriorityServiceRequest(request3, 1));
            
            var request4 = new ServiceRequest("SR-20250920-004", "Trash Collection Missed", "Sanitation", 
                "Weekly trash collection was missed in Residential Area B for the second time this month.", 
                "Residential Area B", new DateTime(2025, 9, 20, 7, 15, 0));
            request4.UpdateStatus("Under Review");
            request4.UpdateStatus("Collection Team Notified");
            InsertIntoAllTrees(request4);
            PriorityQueue.Insert(new PriorityServiceRequest(request4, 3));
            
            var request5 = new ServiceRequest("SR-20250922-005", "Park Equipment Damage", "Parks", 
                "Playground equipment in the community park has been vandalized and poses safety risks.", 
                "Parks and Recreation", new DateTime(2025, 9, 22, 16, 30, 0));
            request5.UpdateStatus("Under Review");
            request5.UpdateStatus("Maintenance Team Assigned");
            request5.UpdateStatus("Safety Barrier Installed");
            InsertIntoAllTrees(request5);
            PriorityQueue.Insert(new PriorityServiceRequest(request5, 2));
            
            var request6 = new ServiceRequest("SR-20250923-006", "Traffic Signal Malfunction", "Roads", 
                "Traffic signal at busy intersection is not working properly, causing traffic congestion.", 
                "Commercial District", new DateTime(2025, 9, 23, 12, 10, 0));
            request6.UpdateStatus("Under Review");
            request6.UpdateStatus("Assigned to Traffic Department");
            InsertIntoAllTrees(request6);
            PriorityQueue.Insert(new PriorityServiceRequest(request6, 1));

            // Additional service requests for more comprehensive data
            var request7 = new ServiceRequest("SR-20250924-007", "Broken Storm Drain", "Utilities", 
                "Storm drain cover is broken and creating a hazard for vehicles and pedestrians.", 
                "Industrial Zone", new DateTime(2025, 9, 24, 9, 45, 0));
            request7.UpdateStatus("Under Review");
            request7.UpdateStatus("Assigned to Infrastructure Team");
            InsertIntoAllTrees(request7);
            PriorityQueue.Insert(new PriorityServiceRequest(request7, 1));

            var request8 = new ServiceRequest("SR-20250925-008", "Graffiti Removal", "Parks", 
                "Graffiti vandalism on park benches and pavilion structures needs cleaning.", 
                "Parks and Recreation", new DateTime(2025, 9, 25, 11, 20, 0));
            request8.UpdateStatus("Under Review");
            InsertIntoAllTrees(request8);
            PriorityQueue.Insert(new PriorityServiceRequest(request8, 3));

            var request9 = new ServiceRequest("SR-20250926-009", "Noise Complaint", "Community", 
                "Ongoing construction noise exceeding permitted hours in residential area.", 
                "Residential Area A", new DateTime(2025, 9, 26, 22, 15, 0));
            request9.UpdateStatus("Under Review");
            request9.UpdateStatus("Inspector Assigned");
            request9.UpdateStatus("Violation Notice Issued");
            InsertIntoAllTrees(request9);
            PriorityQueue.Insert(new PriorityServiceRequest(request9, 2));

            var request10 = new ServiceRequest("SR-20250927-010", "Sidewalk Repair", "Roads", 
                "Cracked and uneven sidewalk creating trip hazards for pedestrians.", 
                "School Zone", new DateTime(2025, 9, 27, 13, 40, 0));
            request10.UpdateStatus("Under Review");
            request10.UpdateStatus("Assigned to Road Maintenance");
            InsertIntoAllTrees(request10);
            PriorityQueue.Insert(new PriorityServiceRequest(request10, 2));

            var request11 = new ServiceRequest("SR-20250928-011", "Fire Hydrant Blocked", "Utilities", 
                "Fire hydrant access blocked by overgrown vegetation and parked vehicles.", 
                "Hospital District", new DateTime(2025, 9, 28, 15, 55, 0));
            request11.UpdateStatus("Under Review");
            request11.UpdateStatus("Emergency - High Priority");
            request11.UpdateStatus("Vegetation Cleared");
            InsertIntoAllTrees(request11);
            PriorityQueue.Insert(new PriorityServiceRequest(request11, 1));

            var request12 = new ServiceRequest("SR-20250929-012", "Public Wi-Fi Down", "Technology", 
                "Public Wi-Fi hotspot in shopping center not functioning properly.", 
                "Shopping Center", new DateTime(2025, 9, 29, 10, 25, 0));
            request12.UpdateStatus("Under Review");
            request12.UpdateStatus("IT Team Assigned");
            InsertIntoAllTrees(request12);
            PriorityQueue.Insert(new PriorityServiceRequest(request12, 3));

            var request13 = new ServiceRequest("SR-20250930-013", "Bus Stop Maintenance", "Transportation", 
                "Bus stop shelter has broken glass and needs cleaning and repair.", 
                "Commercial District", new DateTime(2025, 9, 30, 17, 10, 0));
            request13.UpdateStatus("Under Review");
            request13.UpdateStatus("Maintenance Scheduled");
            InsertIntoAllTrees(request13);
            PriorityQueue.Insert(new PriorityServiceRequest(request13, 2));

            var request14 = new ServiceRequest("SR-20251001-014", "Animal Control", "Community", 
                "Stray dogs reported in residential area, safety concern for children.", 
                "Residential Area B", new DateTime(2025, 10, 1, 8, 0, 0));
            request14.UpdateStatus("Under Review");
            request14.UpdateStatus("Animal Control Dispatched");
            InsertIntoAllTrees(request14);
            PriorityQueue.Insert(new PriorityServiceRequest(request14, 2));

            var request15 = new ServiceRequest("SR-20251002-015", "Sewer Odor", "Sanitation", 
                "Strong sewer odor emanating from manholes in downtown area.", 
                "Downtown", new DateTime(2025, 10, 2, 14, 30, 0));
            request15.UpdateStatus("Under Review");
            request15.UpdateStatus("Sanitation Team Investigating");
            InsertIntoAllTrees(request15);
            PriorityQueue.Insert(new PriorityServiceRequest(request15, 2));

            var request16 = new ServiceRequest("SR-20251003-016", "Parking Meter Broken", "Transportation", 
                "Multiple parking meters not accepting payments on High Street.", 
                "Commercial District", new DateTime(2025, 10, 3, 11, 45, 0));
            request16.UpdateStatus("Under Review");
            InsertIntoAllTrees(request16);
            PriorityQueue.Insert(new PriorityServiceRequest(request16, 3));

            var request17 = new ServiceRequest("SR-20251004-017", "Street Cleaning", "Sanitation", 
                "Debris and litter accumulation on Market Street after weekend events.", 
                "Downtown", new DateTime(2025, 10, 4, 6, 20, 0));
            request17.UpdateStatus("Under Review");
            request17.UpdateStatus("Cleaning Crew Assigned");
            request17.UpdateStatus("Completed");
            InsertIntoAllTrees(request17);
            PriorityQueue.Insert(new PriorityServiceRequest(request17, 3));

            var request18 = new ServiceRequest("SR-20251005-018", "Power Outage", "Utilities", 
                "Partial power outage affecting several blocks in industrial zone.", 
                "Industrial Zone", new DateTime(2025, 10, 5, 4, 15, 0));
            request18.UpdateStatus("Under Review");
            request18.UpdateStatus("Emergency - Utility Company Notified");
            request18.UpdateStatus("Power Restored");
            InsertIntoAllTrees(request18);
            PriorityQueue.Insert(new PriorityServiceRequest(request18, 1));

            var request19 = new ServiceRequest("SR-20251006-019", "Tree Trimming", "Parks", 
                "Overgrown tree branches blocking traffic signals and street signs.", 
                "Residential Area A", new DateTime(2025, 10, 6, 13, 0, 0));
            request19.UpdateStatus("Under Review");
            request19.UpdateStatus("Assigned to Parks Department");
            InsertIntoAllTrees(request19);
            PriorityQueue.Insert(new PriorityServiceRequest(request19, 2));

            var request20 = new ServiceRequest("SR-20251007-020", "Road Salt Shortage", "Roads", 
                "Request for additional road salt supplies before winter season.", 
                "Dispatch Center", new DateTime(2025, 10, 7, 9, 30, 0));
            request20.UpdateStatus("Under Review");
            request20.UpdateStatus("Supply Order Placed");
            InsertIntoAllTrees(request20);
            PriorityQueue.Insert(new PriorityServiceRequest(request20, 3));
        }
        
        // Helper method to insert service request into all tree data structures
        private static void InsertIntoAllTrees(ServiceRequest request)
        {
            ServiceRequests.Insert(request);
            AVLServiceRequests.Insert(request);
            RBServiceRequests.Insert(request);
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
        
        // Method to create a ServiceRequest from an Issue for integration between the two systems
        public static ServiceRequest CreateServiceRequestFromIssue(Issue issue)
        {
            if (issue == null) return null;
            
            // Create a ServiceRequest using the Issue data
            var serviceRequest = new ServiceRequest(
                issue.ReferenceId, 
                $"Issue: {issue.Category} - {issue.Location}", 
                issue.Category, 
                issue.Description, 
                issue.Location, 
                issue.ReportedDate
            );
            
            // Add the ServiceRequest to all our data structures
            InsertIntoAllTrees(serviceRequest);
            
            // Determine priority based on category (example logic)
            int priority = GetPriorityByCategory(issue.Category);
            PriorityQueue.Insert(new PriorityServiceRequest(serviceRequest, priority));
            
            return serviceRequest;
        }
        
        // Helper method to determine priority based on category
        private static int GetPriorityByCategory(string category)
        {
            return category?.ToLower() switch
            {
                "utilities" => 1,  // High priority
                "roads" => 1,      // High priority
                "sanitation" => 2, // Medium priority
                "parks" => 3,      // Low priority
                _ => 2             // Default medium priority
            };
        }
        
        // Method to get all service requests for browsing functionality
        public static List<ServiceRequest> GetAllServiceRequests()
        {
            return ServiceRequests.GetAllRequests();
        }
        
        // Method to get service requests filtered by status
        public static List<ServiceRequest> GetServiceRequestsByStatus(string status)
        {
            var allRequests = GetAllServiceRequests();
            return allRequests.Where(req => req.GetCurrentStatus().Contains(status)).ToList();
        }
        
        // Method to get service requests filtered by category
        public static List<ServiceRequest> GetServiceRequestsByCategory(string category)
        {
            var allRequests = GetAllServiceRequests();
            return allRequests.Where(req => req.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        
        // Method to get high priority service requests from the heap
        public static List<PriorityServiceRequest> GetHighPriorityRequests(int count = 5)
        {
            var result = new List<PriorityServiceRequest>();
            var tempHeap = new MinHeap();
            
            // Copy items to temp heap to preserve original
            foreach (var item in PriorityQueue.GetAllItems())
            {
                tempHeap.Insert(item);
            }
            
            // Extract top priority items
            for (int i = 0; i < count && tempHeap.Count > 0; i++)
            {
                result.Add(tempHeap.ExtractMin());
            }
            
            return result;
        }
        
        // Method to get dispatch network optimization using MST
        public static List<Graph.Edge> GetOptimalDispatchNetwork()
        {
            return DispatchGrid.KruskalMST();
        }
        
        // Method to demonstrate graph traversals
        public static Dictionary<string, List<string>> GetGraphTraversals(string startNode = "Dispatch Center")
        {
            return new Dictionary<string, List<string>>
            {
                ["DFS"] = DispatchGrid.DepthFirstSearch(startNode),
                ["BFS"] = DispatchGrid.BreadthFirstSearch(startNode)
            };
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
