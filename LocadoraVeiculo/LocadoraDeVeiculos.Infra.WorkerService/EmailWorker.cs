using LocadoraDeVeiculos.Dominio.ReciboModule;
using LocadoraDeVeiculos.Infra.EmailManager;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.WorkerService
{
    public class EmailWorker : BackgroundService
    {
        private readonly ILogger<EmailWorker> _logger;
        private readonly IReciboRepository reciboRepository;

        public EmailWorker(ILogger<EmailWorker> logger, IReciboRepository reciboRepository)
        {
            _logger = logger;
            this.reciboRepository = reciboRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var recibosPendentes = reciboRepository.GetAllRecibosPendentes();

                recibosPendentes.ForEach(e => Task.Run(() => EnviarEmails(e)));

                await Task.Delay(5000, stoppingToken);
            }
        }

        private void EnviarEmails(Recibo e)
        {
            if(EmailSender.EnviarEmail(e))
                reciboRepository.ConcluirRecibo(e);
        }
    }
}
