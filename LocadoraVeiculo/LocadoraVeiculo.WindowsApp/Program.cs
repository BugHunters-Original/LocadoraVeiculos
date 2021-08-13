using LocadoraVeiculo.WindowsApp.Features.Login;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp
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
            Application.Run(new TelaLoginForm());
        }
    }
}
