namespace MunicipalServices
{
    internal static class Program
    {
        public static System.Collections.Generic.List<Issue> ReportedIssues = new System.Collections.Generic.List<Issue>();
        //  The main entry point for the application.
        [STAThread]

        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainMenu());
        }
    }
}