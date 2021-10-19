using Autofac;
using LocadoraDeVeiculos.WindowsApp.Shared;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using LocadoraVeiculo.WindowsApp.Features.LoginFeature;
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
            DarkMode.TrocarModo();
            AutoFacDI.Container.Resolve<TelaLoginForm>().ShowDialog();
            Application.Run();
        }
    }
}
