using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Create a new instance of the Information form
            Information infoForm = new Information();

            // Set the form's WindowState property to maximized
            infoForm.WindowState = FormWindowState.Maximized;

            // Run the application with the Information form as the main form
            Application.Run(infoForm);
        }
    }
}
