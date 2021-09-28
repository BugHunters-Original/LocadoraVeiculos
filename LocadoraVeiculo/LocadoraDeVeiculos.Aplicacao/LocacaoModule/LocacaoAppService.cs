using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using Serilog.Core;
using System;
using LocadoraDeVeiculos.Infra.ExtensionMethods;

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

            logger.Aqui().Debug("REGISTRANDO LOCAÇÃO {Locacao}", locacao.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                locacaoRepo.Inserir(locacao);

                logger.Aqui().Debug("LOCAÇÃO {Locacao} REGISTRADA COM SUCESSO", locacao.ToString());

                veiculoRepo.LocarVeiculo(locacao.Veiculo);

                logger.Aqui().Debug("VEÍCULO {Veiculo} LOCADO COM SUCESSO", locacao.Veiculo.ToString());

                if (locacao.Desconto != null)
                {
                    locacao.Desconto.Usos++;

                    descontoRepo.Editar(locacao.Desconto.Id, locacao.Desconto);
                }

                logger.Aqui().Debug("MONTANDO PDF DA LOCAÇÃO ID: {Id}", locacao.Id);

                pdf.MontarPDF(locacao, logger);

                logger.Aqui().Debug("ENVIANDO EMAIL LOCAÇÃO ID: {Id}", locacao.Id);

                Task.Run(() => email.EnviarEmail(locacao, logger));

            }
            else
            {
                logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR LOCAÇÃO {Locacao}", locacao.ToString());
            }
        }
        public void ConcluirLocacao(int id, Locacao locacao)
        {
            logger.Aqui().Debug("CONCLUINDO LOCAÇÃO {Locacao}", locacao.ToString());

            locacaoRepo.ConcluirLocacao(id, locacao);

            logger.Aqui().Debug("DEVOLVENDO VEÍCULO {Veiculo}", locacao.Veiculo.ToString());

            veiculoRepo.DevolverVeiculo(locacao.Veiculo);

            logger.Aqui().Debug("ATUALIZAR QUILOMETRAGEM DO VEÍCULO {Veiculo}", locacao.Veiculo.ToString());

            veiculoRepo.AtualizarQuilometragem(locacao.Veiculo);
        }
        public void EditarLocacao(int id, Locacao locacao)
        {
            string resultadoValidacaoDominio = locacao.Validar();

            logger.Aqui().Debug("EDITANDO LOCAÇÃO {Locacao}", locacao.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                locacaoRepo.Editar(id, locacao);

                logger.Aqui().Debug("LOCAÇÃO {Locacao} EDITADA COM SUCESSO", locacao.ToString());
            }
            else
            {
                logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR LOCAÇÃO {Locacao}", locacao.ToString());
            }
        }

        public bool ExcluirLocacao(int id)
        {
            logger.Aqui().Debug("REMOVENDO LOCAÇÃO {Id}", id);

            var locacao = locacaoRepo.SelecionarPorId(id);

            var excluiu = locacaoRepo.Excluir(id);

            if (excluiu)
                logger.Aqui().Debug("LOCAÇÃO {Id} REMOVIDA COM SUCESSO", locacao.Id);
            else
                logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER LOCAÇÃO {Id}.", locacao.Id);

            return excluiu;
        }
        public List<Locacao> SelecionarTodasLocacoes()
        {
            logger.Aqui().Debug("SELECIONANDO TODAS AS LOCAÇÕES");

            List<Locacao> locacao = locacaoRepo.SelecionarTodos();

            if (locacao.Count == 0)
                logger.Aqui().Information("NÃO HÁ LOCAÇÕES CADASTRADAS");
            else
                logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) EXISTENTE(S)", locacao.Count);

            return locacao;
        }
        public Locacao SelecionarLocacaoPorId(int id)
        {
            logger.Aqui().Debug("SELECIONANDO A LOCAÇÃO ID: {Id}", id);

            Locacao locacao = locacaoRepo.SelecionarPorId(id);

            if (locacao == null)
                logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR A LOCAÇÃO ID {Id}", locacao.Id);
            else
                logger.Aqui().Debug("LOCAÇÃO ID {Id} SELECIONADA COM SUCESSO", locacao.Id);

            return locacao;
        }
        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            logger.Aqui().Debug("SELECIONANDO TODAS AS LOCAÇÕES CONCLUÍDAS");

            List<Locacao> locacao = locacaoRepo.SelecionarTodasLocacoesConcluidas();

            if (locacao.Count == 0)
                logger.Aqui().Information("NÃO HÁ LOCAÇÕES CONCLUÍDAS CADASTRADAS");
            else
                logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) CONCLUÍDA(S) EXISTENTE(S)", locacao.Count);

            return locacao;
        }
        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
            logger.Aqui().Debug("SELECIONANDO TODAS AS LOCAÇÕES PENDENTES");

            List<Locacao> locacao = locacaoRepo.SelecionarTodasLocacoesPendentes();

            if (locacao.Count == 0)
                logger.Aqui().Information("NÃO HÁ LOCAÇÕES PENDENTES CADASTRADAS");
            else
                logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) PENDENTES(S) EXISTENTE(S)", locacao.Count);

            return locacao;
        }
        public int SelecionarQuantidadeLocacoesPendentes()
        {
            logger.Aqui().Debug("SELECIONANDO TODAS AS LOCAÇÕES PENDENTES");

            var qtdLocacao = locacaoRepo.SelecionarQuantidadeLocacoesPendentes();

            if (qtdLocacao == 0)
                logger.Aqui().Information("NÃO HÁ LOCAÇÕES PENDENTES CADASTRADAS");
            else
                logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) PENDENTES(S) EXISTENTE(S)", qtdLocacao);

            return qtdLocacao;
        }
        public int SelecionarLocacoesComCupons(string cupom)
        {
            logger.Aqui().Debug("SELECIONANDO TODAS AS LOCAÇÕES COM CUPOM");

            var qtdLocacao = locacaoRepo.SelecionarQuantidadeLocacoesPendentes();

            if (qtdLocacao == 0)
                logger.Aqui().Information("NÃO HÁ LOCAÇÕES COM CUPOM");
            else
                logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) COM CUPOM EXISTENTE(S)", qtdLocacao);

            return qtdLocacao;
        }
    }
}
