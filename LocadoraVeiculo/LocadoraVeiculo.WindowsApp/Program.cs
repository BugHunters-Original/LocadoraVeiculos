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

            RunProgram();
        }

        private static void RunProgram()
        {
            DarkMode.TrocarModo();

            AutoFacDI.Container.Resolve<TelaLoginForm>().ShowDialog();

            LocadoraDeVeiculos.Infra.WorkerService.Program.Main(Array.Empty<string>());

            Application.Run();
        }
    }
}
