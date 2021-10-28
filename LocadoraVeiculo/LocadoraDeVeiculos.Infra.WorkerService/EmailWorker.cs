using LocadoraDeVeiculos.Dominio.ReciboModule;
using LocadoraDeVeiculos.Infra.EmailManager;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.Logger;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.WorkerService
{
    public class EmailWorker : BackgroundService
    {
        private readonly IReciboRepository reciboRepository;

        public EmailWorker(IReciboRepository reciboRepository)
        {
            this.reciboRepository = reciboRepository;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Serilogger.Logger.Aqui().Information("Pegando todos os recibos pendentes");
                var recibosPendentes = reciboRepository.GetAllRecibosPendentes();
                Serilogger.Logger.Aqui().Information("Iniciando loop de envios");
                Parallel.ForEach(recibosPendentes, recibo =>
                {
                    EnviarEmails(recibo);
                });

                await Task.Delay(5000, stoppingToken);
            }
        }

        private void EnviarEmails(Recibo e)
        {
            Serilogger.Logger.Aqui().Information("Tentando enviar email para {email}", e.Locacao.Cliente.Email);
            if (EmailSender.EnviarEmail(e))
                reciboRepository.ConcluirRecibo(e);
        }
    }
}
