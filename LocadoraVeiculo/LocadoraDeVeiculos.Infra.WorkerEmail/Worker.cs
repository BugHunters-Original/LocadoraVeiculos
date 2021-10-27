using LocadoraDeVeiculos.Dominio.LocacaoModule;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.WorkerEmail
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ILocacaoRepository locacaoRepository;
        private readonly IEmail emailRepository;

        public Worker(ILogger<Worker> logger, ILocacaoRepository locacaoRepository, IEmail emailRepository)
        {
            _logger = logger;
            this.locacaoRepository = locacaoRepository;
            this.emailRepository = emailRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var emails = locacaoRepository.SolicitacoesDeEmail();

                if (emails.Any())
                    emails.ForEach(e => Task.Run(() => emailRepository.EnviarEmail(e)));

                await Task.Delay(3000, stoppingToken);
            }
        }

    }
}
