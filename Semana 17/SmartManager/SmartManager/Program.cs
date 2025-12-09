

using System;
using System.Windows.Forms;
using SmartManager.Presentation; 

namespace SmartManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostrar primero el login
            using (Login loginForm = new Login())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new SmartManager()); 
                }
            }
        }
    }
}