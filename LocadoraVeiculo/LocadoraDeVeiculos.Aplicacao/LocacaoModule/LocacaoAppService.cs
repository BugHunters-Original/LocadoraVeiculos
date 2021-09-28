using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using Serilog.Core;
using System;

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

            logger.Debug("REGISTRANDO LOCAÇÃO {Locacao} | {DataEHora} ", locacao.ToString(), DateTime.Now.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                locacaoRepo.Inserir(locacao);

                logger.Debug("LOCAÇÃO {Locacao} REGISTRADA COM SUCESSO | {DataEHora}", locacao.ToString(), DateTime.Now.ToString());

                veiculoRepo.LocarVeiculo(locacao.Veiculo);

                logger.Debug("VEÍCULO {Veiculo} LOCADO COM SUCESSO | {DataEHora}", locacao.Veiculo.ToString(), DateTime.Now.ToString());

                if (locacao.Desconto != null)
                {
                    locacao.Desconto.Usos++;

                    descontoRepo.Editar(locacao.Desconto.Id, locacao.Desconto);
                }

                logger.Debug("MONTANDO PDF DA LOCAÇÃO ID: {Id}", locacao.Id);

                pdf.MontarPDF(locacao, logger);

                logger.Debug("ENVIANDO EMAIL LOCAÇÃO ID: {Id}", locacao.Id);

                Task.Run(() => email.EnviarEmail(locacao, logger));

            }
            else
            {
                logger.Error("NÃO FOI POSSÍVEL REGISTRAR LOCAÇÃO {Locacao} | {DataEHora}", locacao.ToString(), DateTime.Now.ToString());
            }
        }
        public void ConcluirLocacao(int id, Locacao locacao)
        {
            logger.Debug("CONCLUINDO LOCAÇÃO {Locacao} | {DataEHora} ", locacao.ToString(), DateTime.Now.ToString());

            locacaoRepo.ConcluirLocacao(id, locacao);

            logger.Debug("DEVOLVENDO VEÍCULO {Veiculo} | {DataEHora} ", locacao.Veiculo.ToString(), DateTime.Now.ToString());

            veiculoRepo.DevolverVeiculo(locacao.Veiculo);

            logger.Debug("ATUALIZAR QUILOMETRAGEM DO VEÍCULO {Veiculo} | {DataEHora} ", locacao.Veiculo.ToString(), DateTime.Now.ToString());

            veiculoRepo.AtualizarQuilometragem(locacao.Veiculo);
        }
        public void EditarLocacao(int id, Locacao locacao)
        {
            string resultadoValidacaoDominio = locacao.Validar();

            logger.Debug("EDITANDO LOCAÇÃO {Locacao} | {DataEHora} ", locacao.ToString(), DateTime.Now.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                locacaoRepo.Editar(id, locacao);

                logger.Debug("LOCAÇÃO {Locacao} EDITADA COM SUCESSO | {DataEHora}", locacao.ToString(), DateTime.Now.ToString());
            }
            else
            {
                logger.Error("NÃO FOI POSSÍVEL EDITAR LOCAÇÃO {Locacao} | {DataEHora}", locacao.ToString(), DateTime.Now.ToString());
            }
        }

        public bool ExcluirLocacao(int id)
        {
            logger.Debug("REMOVENDO LOCAÇÃO {Id} | {DataEHora}", id, DateTime.Now.ToString());

            var locacao = locacaoRepo.SelecionarPorId(id);

            var excluiu = locacaoRepo.Excluir(id);

            if (excluiu)
                logger.Debug("LOCAÇÃO {Id} REMOVIDA COM SUCESSO | {DataEHora}", locacao.Id, DateTime.Now.ToString());
            else
                logger.Error("NÃO FOI POSSÍVEL REMOVER LOCAÇÃO {Id} | {DataEHora}.", locacao.Id, DateTime.Now.ToString());

            return excluiu;
        }
        public List<Locacao> SelecionarTodasLocacoes()
        {
            logger.Debug("SELECIONANDO TODAS AS LOCAÇÕES | {DataEHora}", DateTime.Now.ToString());

            List<Locacao> locacao = locacaoRepo.SelecionarTodos();

            if (locacao.Count == 0)
                logger.Information("NÃO HÁ LOCAÇÕES CADASTRADAS | {DataEHora}", DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) EXISTENTE(S) | {DataEHora}", locacao.Count, DateTime.Now.ToString());

            return locacao;
        }
        public Locacao SelecionarLocacaoPorId(int id)
        {
            logger.Debug("SELECIONANDO A LOCAÇÃO ID: {Id} | {DataEHora}", id, DateTime.Now.ToString());

            Locacao locacao = locacaoRepo.SelecionarPorId(id);

            if (locacao == null)
                logger.Information("NÃO FOI POSSÍVEL ENCONTRAR A LOCAÇÃO ID {Id} | {DataEHora}", locacao.Id, DateTime.Now.ToString());
            else
                logger.Debug("LOCAÇÃO ID {Id} SELECIONADA COM SUCESSO | {DataEHora}", locacao.Id, DateTime.Now.ToString());

            return locacao;
        }
        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            logger.Debug("SELECIONANDO TODAS AS LOCAÇÕES CONCLUÍDAS | {DataEHora}", DateTime.Now.ToString());

            List<Locacao> locacao = locacaoRepo.SelecionarTodasLocacoesConcluidas();

            if (locacao.Count == 0)
                logger.Information("NÃO HÁ LOCAÇÕES CONCLUÍDAS CADASTRADAS | {DataEHora}", DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) CONCLUÍDA(S) EXISTENTE(S) | {DataEHora}", locacao.Count, DateTime.Now.ToString());

            return locacao;
        }
        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
            logger.Debug("SELECIONANDO TODAS AS LOCAÇÕES PENDENTES | {DataEHora}", DateTime.Now.ToString());

            List<Locacao> locacao = locacaoRepo.SelecionarTodasLocacoesPendentes();

            if (locacao.Count == 0)
                logger.Information("NÃO HÁ LOCAÇÕES PENDENTES CADASTRADAS | {DataEHora}", DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) PENDENTES(S) EXISTENTE(S) | {DataEHora}", locacao.Count, DateTime.Now.ToString());

            return locacao;
        }
        public int SelecionarQuantidadeLocacoesPendentes()
        {
            logger.Debug("SELECIONANDO TODAS AS LOCAÇÕES PENDENTES | {DataEHora}", DateTime.Now.ToString());

            var qtdLocacao = locacaoRepo.SelecionarQuantidadeLocacoesPendentes();

            if (qtdLocacao == 0)
                logger.Information("NÃO HÁ LOCAÇÕES PENDENTES CADASTRADAS | {DataEHora}", DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) PENDENTES(S) EXISTENTE(S) | {DataEHora}", qtdLocacao, DateTime.Now.ToString());

            return qtdLocacao;
        }
        public int SelecionarLocacoesComCupons(string cupom)
        {
            logger.Debug("SELECIONANDO TODAS AS LOCAÇÕES COM CUPOM | {DataEHora}", DateTime.Now.ToString());

            var qtdLocacao = locacaoRepo.SelecionarQuantidadeLocacoesPendentes();

            if (qtdLocacao == 0)
                logger.Information("NÃO HÁ LOCAÇÕES COM CUPOM | {DataEHora}", DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) COM CUPOM EXISTENTE(S) | {DataEHora}", qtdLocacao, DateTime.Now.ToString());

            return qtdLocacao;
        }
    }
}
