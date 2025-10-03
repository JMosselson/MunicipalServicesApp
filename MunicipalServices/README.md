# Municipal Services Application - PROG7312 Project

This repository contains a C# .NET Framework Windows Forms application developed for the PROG7312 Portfolio of Evidence. The application provides a platform for citizens to report municipal issues, with the goal of improving service delivery and citizen engagement.

---

## Table of Contents
1.  **Project Overview**
2.  **Features**
3.  **Technical Requirements**
4.  **How to Compile and Run**
5.  **How to Use the Application**
6.  **User Engagement Strategy**

---

## 1. Project Overview
This application is designed for a South African municipality to streamline citizen engagement with municipal services. It provides a comprehensive platform that combines issue reporting with community information access. The application currently features three fully functional modules: **"Report Issues"** for submitting service delivery problems, **"Local Events & Announcements"** for discovering community activities and municipal updates, and **"Service Request Status"** for tracking submitted requests. The application demonstrates advanced data structures and algorithms for efficient municipal service management.

---

## 2. Features
### Main Menu
A central navigation screen with three options:
* **Report Issues**: Fully implemented and functional.
* **Local Events and Announcements**: Fully implemented and functional.
* **Service Request Status**: Fully implemented and functional.

### Issue Reporting Form
A detailed form for submitting issues, which includes:
* **Location Input**: A textbox for specifying the issue's location.
* **Category Selection**: A dropdown list for classifying the issue (e.g., Sanitation, Roads, Utilities).
* **Detailed Description**: A rich text box for providing comprehensive details.
* **Media Attachment**: A button to open a file dialog, allowing users to attach relevant photos or documents.  

### Local Events & Announcements
A comprehensive form for viewing and discovering community information, which includes:
- **Chronological Event List**: Displays events sorted by date in an easy-to-read ListView format.  
- **Search Functionality**: A search bar with button to find events by keywords across names and descriptions.  
- **Category Filtering**: A dropdown to filter events by category (e.g., Community, Sports, Utilities, Markets, Roads).  
- **Detailed Event View**: Shows the full details of a selected event including date, category, and complete description.  
- **Smart Recommendation Engine**: Suggests up to 5 relevant upcoming events based on the user's search history and interests.
- **Interactive Interface**: Click-to-select events with real-time detail updates and seamless navigation.  

### Service Request Status
A comprehensive tracking system for monitoring submitted service requests, which includes:
- **Current Service Requests Table**: View all active requests in a large, scrollable table with clear column headers and the title "Current Service Requests".
- **Search by Reference ID**: Enter your reference number to quickly locate your specific request.
- **Detailed Request View**: Click any request in the table or search by reference number to see full details in a spacious, readable format including:
  - Reference ID
  - Status (highlighted for visibility)
  - Category
  - Location
  - Complete description
  - Status history timeline
  - Route information (when available)
- **Advanced Data Structures**: Utilizes AVL Trees, Red-Black Trees, and Min-Heaps for efficient data management and priority handling.
- **Responsive Layout**: All information is displayed without crowding, ensuring easy readability.

### Data Storage & Management
- **List\<Issue\>**: Used for simple, flexible in-memory storage of reported issues with unique reference IDs.  
- **SortedDictionary\<DateTime, List\<Event\>\>**: Automatically stores events in chronological order for efficient date-based operations.  
- **HashSet\<string\>**: Stores unique event categories for fast lookup and dropdown population.  
- **Queue\<string\>**: Manages recent search history in FIFO order (limited to 5 recent searches for recommendations).
- **Advanced Data Structures**: AVL Trees, Red-Black Trees, and Min-Heaps for service request management and priority queuing.
- **Centralized DataManager**: Static class providing unified access to all application data with automatic initialization of comprehensive sample data.

### User Engagement
The application implements a **Transparent Feedback Loop** to keep the user informed throughout all processes.

---

## 3. Technical Requirements
To compile and run this application, you will need the following:
* **Framework**: .NET 8.0 (Windows target framework)
* **Language**: C#
* **IDE**: Microsoft Visual Studio (2019 or newer)
* **Project Type**: Windows Forms App (.NET)
* **Operating System**: Windows (Windows Forms dependency)

### Key Technical Features
* **Async/Await Pattern**: Used in form submissions for responsive UI
* **LINQ Integration**: Efficient data querying and filtering throughout the application
* **Windows Forms**: Modern .NET implementation with designer support
* **In-Memory Data Management**: Fast, session-based data storage with automatic initialization
* **Advanced Algorithms**: Implementation of tree structures and heaps for educational demonstration

---

## 4. How to Compile and Run
Follow these steps to run the project locally:

### 1. Clone The Repo

git clone https://github.com/JMosselson/MunicipalServicesApp.git

### 2. Open in Visual Studio
- Open the solution file (.sln) in Visual Studio
- Ensure .NET 8.0 is installed

### 3. Build and Run
- Build the solution (Ctrl+Shift+B)
- Run the application (F5)

---

## 5. How to Use the Application

### **1. Launch the Application**
The **Main Menu** will be displayed upon launch.

## Using the Report Issues Feature

### **2. Start a Report**
Click the "**Report an Issue**" button to access the issue reporting functionality.

### **3. Fill in the Details**
* The **Report an Issue** form will open.
* Enter the location of the issue in the **Location** field.
* Select the appropriate **Category** from the dropdown list.
* Provide a detailed **Description** of the problem.
* **(Optional)** Click the "**Attach Image/Document...**" button to add a supporting file.

### **4. Submit the Report**
Click the "**Submit Report**" button.

### **5. Observe the Feedback**
* A progress bar and status label at the bottom will update to show the submission progress.
* A message box will appear, confirming the submission and providing a unique **Reference ID**.
* The form will automatically close, and you will be returned to the **Main Menu**.

## Using the Local Events & Announcements Feature

### **6. Access Local Events**
Click the "**Local Events & Announcements**" button from the main menu.

### **7. Browse Events**
* The **Events** form will display a chronological list of all upcoming local events and announcements.
* Events are displayed in a list showing Date, Event Name, and Category.
* Click on any event in the list to view its full details in the description panel.

### **8. Search for Events**
* Use the **Search** text box to find specific events by entering keywords.
* Click the "**Search**" button or press Enter to filter events containing your search terms.
* Search works across event names and descriptions.

### **9. Filter by Category**
* Use the **Category Filter** dropdown to view events from specific categories only.
* Available categories include: Community, Sports, Utilities, Markets, Roads, and others.
* Select "All Categories" to view all events again.

### **10. View Recommendations**
* After performing a search, the **Recommendations** panel will automatically suggest other relevant events.
* Recommendations are based on your search history and show similar events in the same category.
* Click on any recommended event to view its details.
* The system keeps track of your last 5 searches to improve recommendations.

### **11. Return to Main Menu**
Click the "**Back to Menu**" button to return to the main application menu.

## Using the Service Request Status Feature

### **12. Access Service Request Status**
Click the "**Service Request Status**" button from the main menu.

### **13. View All Requests**
* The form displays a large table titled "Current Service Requests" showing all active requests.
* The table includes columns for Reference ID, Status, Category, Location, and Date Submitted.
* All data is clearly visible without crowding.

### **14. Search for Specific Request**
* Enter a reference ID in the search box at the top of the form.
* Click "**Search**" to locate your specific request.
* The request details will appear in the expanded details panel.

### **15. View Request Details**
* Click on any request in the table to view detailed information.
* The details panel shows:
  - Complete request information
  - Status history timeline
  - Location details
  - Route information (if available)
* All information is displayed in a spacious, readable format.

### **16. Return to Main Menu**
Click the "**Back to Menu**" button to return to the main application menu.

---

## 6. User Engagement Strategy
The application implements multiple engagement strategies to build user trust and encourage active community participation:

### Transparent Feedback Loop (Issue Reporting)
- **Visual Progress Indicators**: Real-time progress bar and status messages during report submission
- **Step-by-step Feedback**: Clear status updates ("Submitting...", "Report Received!", "Logged with Reference ID...")
- **Unique Reference IDs**: Each report receives a trackable reference ID (format: MS-YYYYMMDD-XXXXX)
- **Confirmation Messaging**: Success messages reassure users their reports are valued and recorded

### Personalized Event Discovery
- **Search History Tracking**: System remembers user interests through search patterns
- **Smart Recommendations**: Suggests relevant upcoming events based on previous searches
- **Category-based Filtering**: Allows users to focus on their areas of interest
- **Interactive Event Details**: Click-to-view functionality for comprehensive event information

### Comprehensive Request Tracking
- **Real-time Status Updates**: Clear visibility into request progress and current status
- **Detailed History Timeline**: Complete audit trail of all status changes
- **Advanced Search Capabilities**: Quick lookup by reference ID with immediate results
- **Intuitive Interface Design**: Spacious layout ensures all information is easily readable

### Community Information Access
- **Pre-loaded Sample Data**: Application comes with diverse community events and service requests
- **Chronological Organization**: Events and requests displayed in logical order for easy planning
- **Multi-category Coverage**: Supports various community needs (Community, Sports, Utilities, Markets, Roads)

---

**Gemini Chat link For Comments and README.md**: https://g.co/gemini/share/210b550ce628