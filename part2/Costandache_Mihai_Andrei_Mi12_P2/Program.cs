using System;
using System.Windows.Forms;
using CarService;

namespace CarServiceApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using(var unitOfWork=new UnitOfWork())
            {
                Application.Run(new MainForm(unitOfWork));
            }
        }
    }
}
