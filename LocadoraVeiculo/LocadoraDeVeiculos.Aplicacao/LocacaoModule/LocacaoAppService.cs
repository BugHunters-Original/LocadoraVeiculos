using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using Serilog.Core;

namespace LocadoraDeVeiculos.Aplicacao.LocacaoModule
{
    public class LocacaoAppService
    {
        private readonly ILocacaoRepository locacaoRepo;
        private readonly IDescontoRepository descontoRepo;
        private readonly IVeiculoRepository veiculoRepo;
        private readonly Logger logger;
        private readonly IEmail email;
        private readonly IPDF pdf;
        public LocacaoAppService(ILocacaoRepository locacaoRepo, Logger logger,
                                 IEmail email, IPDF pdf, IDescontoRepository descontoRepo,
                                 IVeiculoRepository veiculoRepo)
        {
            this.veiculoRepo = veiculoRepo;
            this.locacaoRepo = locacaoRepo;
            this.descontoRepo = descontoRepo;
            this.logger = logger;
            this.email = email;
            this.pdf = pdf;
        }
        public void RegistrarNovaLocacao(Locacao locacao)
        {
            string resultadoValidacaoDominio = locacao.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Registrando Locação {locacao}...");

                if (locacao.Desconto != null)
                {
                    locacao.Desconto.Usos++;

                    descontoRepo.Editar(locacao.Desconto.Id, locacao.Desconto);
                }

                locacaoRepo.Inserir(locacao);

                logger.Debug($"Locação {locacao} registrado com sucesso!");

                pdf.MontarPDF(locacao);

                logger.Debug($"PDF da Locação {locacao.Id} registrado com sucesso!");

                Task.Run(() => email.EnviarEmail(locacao, logger));
            }
        }
        public void ConcluirLocacao(int id, Locacao locacao)
        {
            locacaoRepo.ConcluirLocacao(id, locacao);

            logger.Debug($"Locação {locacao} concluída com sucesso!");

            veiculoRepo.DevolverVeiculo(locacao.Veiculo);

            veiculoRepo.AtualizarQuilometragem(locacao.Veiculo);
        }
        public void EditarLocacao(int id, Locacao locacao)
        {
            string resultadoValidacaoDominio = locacao.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Editando Locação {locacao}...");

                locacaoRepo.Editar(id, locacao);

                logger.Debug($"Locação {locacao} editada com sucesso!");
            }
        }

        public bool ExcluirLocacao(int id)
        {
            var excluiu = locacaoRepo.Excluir(id);

            if (excluiu)
                logger.Debug($"Excluiu Locação ID: {id}!");
            else
                logger.Error($"Não excluiu Locação ID: {id}!");

            return excluiu;
        }
        public List<Locacao> SelecionarTodasLocacoes()
        {
            logger.Debug($"Selecionando todas Locações!");
            return locacaoRepo.SelecionarTodos();
        }
        public Locacao SelecionarLocacaoPorId(int id)
        {
            Locacao locacao = locacaoRepo.SelecionarPorId(id);

            logger.Debug($"Selecionando Locação ID: {id} Nome: {locacao}!");

            return locacao;
        }
        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            logger.Debug($"Selecionando todas Locações Concluídas!");
            return locacaoRepo.SelecionarTodasLocacoesConcluidas();
        }
        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
            logger.Debug($"Selecionando todas Locações Pendentes!");
            return locacaoRepo.SelecionarTodasLocacoesPendentes();
        }
        public int SelecionarQuantidadeLocacoesPendentes()
        {
            logger.Debug($"Selecionando quantidade de Locações Pendentes!");
            return locacaoRepo.SelecionarQuantidadeLocacoesPendentes();
        }
        public int SelecionarLocacoesComCupons(string cupom)
        {
            logger.Debug($"Selecionando todas Locações com Cupom: {cupom}!");
            return locacaoRepo.SelecionarLocacoesComCupons(cupom);
        }

    }
}
