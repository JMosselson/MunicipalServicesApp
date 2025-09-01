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
This application is designed for a South African municipality to streamline the process of reporting service delivery issues. It provides a user-friendly interface for citizens to submit detailed reports, which can then be managed by the municipality. The current version focuses on the core **"Report Issues"** functionality. Future updates will expand the application to include features for local events and service request tracking.

---

## 2. Features
### Main Menu
A central navigation screen with three options:
* **Report Issues**: Fully implemented and functional.
* **Local Events and Announcements**: Disabled for future implementation.
* **Service Request Status**: Disabled for future implementation.

### Issue Reporting Form
A detailed form for submitting issues, which includes:
* **Location Input**: A textbox for specifying the issue's location.
* **Category Selection**: A dropdown list for classifying the issue (e.g., Sanitation, Roads, Utilities).
* **Detailed Description**: A rich text box for providing comprehensive details.
* **Media Attachment**: A button to open a file dialog, allowing users to attach relevant photos or documents.

### Data Storage
User-reported issues are stored in a simple, in-memory `List<Issue>` for the application's lifecycle.

### User Engagement
The application implements a **Transparent Feedback Loop** to keep the user informed throughout the submission process.

---

## 3. Technical Requirements
To compile and run this application, you will need the following:
* **Framework**: .NET Framework (e.g., 4.7.2 or newer)
* **Language**: C#
* **IDE**: Microsoft Visual Studio (e.g., 2019, 2022)
* **Project Type**: Windows Forms App (.NET Framework)

---

## 4. How to Compile and Run
Follow these steps to get the project running on your local machine.

### **1. Clone or Download the Code**
Ensure you have all the necessary files: `Program.cs`, `MainMenu.cs`, `MainMenu.Designer.cs`, `ReportIssueForm.cs`, `ReportIssueForm.Designer.cs`, and `Issue.cs`.

### **2. Create a New Project in Visual Studio**
* Launch Visual Studio and click on "**Create a new project**".
* In the project templates, search for and select "**Windows Forms App (.NET Framework)**". Be careful **not** to select the ".NET" or ".NET Core" version.
* Click "**Next**".

### **3. Configure Your Project**
* **Project Name**: Enter `MunicipalServices`.
* **Location**: Choose a directory to save your project.
* **Framework**: Select a .NET Framework version (e.g., .NET Framework 4.7.2).
* Click "**Create**".

### **4. Add the Code Files to Your Project**
* In the **Solution Explorer** pane on the right, right-click on the project name (`MunicipalServices`).
* Select **Add > Existing Item...**.
* Navigate to where you saved the code files and select all of them.
* Click "**Add**". You can delete the default `Form1.cs` file that Visual Studio creates.

### **5. Set the Startup Object**
* Open the `Program.cs` file. The line `Application.Run(new MainMenu());` should already be configured to run the `MainMenu` form first. If not, ensure it is set correctly.

### **6. Compile and Run**
* Press **F5** or click the "**Start**" button (with the green play icon) in the Visual Studio toolbar.
* The application will compile and the **Main Menu** window will appear.

---

## 5. How to Use the Application
### **1. Launch the Application**
The **Main Menu** will be displayed upon launch.

### **2. Start a Report**
Click the "**Report an Issue**" button. The other buttons are disabled for this version.

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

---

## 6. User Engagement Strategy
The application implements a **Transparent Feedback Loop** to build user trust and encourage future engagement. This is achieved by providing immediate, visual feedback upon submission. The progress bar and status messages (e.g., "Submitting...", "Report Received!", "Logged with Reference ID...") reassure the user that their report has been successfully processed and recorded. This confirms that their contribution is valued and helps to foster a sense of active participation in the community.

Gemini Chat link For Comments and README.md: https://g.co/gemini/share/210b550ce628