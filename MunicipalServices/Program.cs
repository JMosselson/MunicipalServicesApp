using System;
using System.Windows.Forms;

namespace MunicipalServices
{
    static class Program
    {
        /// The main entry point for the application.
        [STAThread]
        static void Main()
        {
            // The DataManager static constructor will be called automatically here,
            // initializing all our data.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }
    }
}
