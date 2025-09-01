using System;

namespace MunicipalServices
{ 
    // Represents a single issue reported by a citizen.
    // This class acts as a model to hold all the data for a service request.
    public class Issue
    {
        // A unique identifier for the reported issue.
        public string ReferenceId { get; private set; }

        // The location of the issue as provided by the user.
        public string Location { get; set; }

        // The category of the issue (e.g., Sanitation, Roads, Utilities).
        public string Category { get; set; }

        // A detailed description of the issue.
        public string Description { get; set; }

        // The file path to any media attached by the user.
        public string AttachmentPath { get; set; }


        // The date and time when the issue was reported.
        public DateTime ReportedDate { get; private set; }

        // Constructor for the Issue class.
        // It automatically generates a unique reference ID and sets the report date.

        // "location" The location of the issue.
        // "category" The category of the issue.
        // "description" The detailed description of the issue.
        // "attachmentPath" The file path of the attached media.
        public Issue(string location, string category, string description, string attachmentPath)
        {
            Location = location;
            Category = category;
            Description = description;
            AttachmentPath = attachmentPath;

            // Generate a unique reference ID (e.g., MS-20250729-ABC12)
            ReferenceId = $"MS-{DateTime.Now:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 5).ToUpper()}";
            ReportedDate = DateTime.Now;
        }
    }
}
