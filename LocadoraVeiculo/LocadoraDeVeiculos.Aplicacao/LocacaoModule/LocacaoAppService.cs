using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Infra.Logger;
using LocadoraDeVeiculos.Infra.WorkerEmail;

namespace LocadoraDeVeiculos.Aplicacao.LocacaoModule
{
    public class LocacaoAppService
    {
        private readonly ILocacaoRepository locacaoRepo;
        private readonly IDescontoRepository descontoRepo;
        private readonly IVeiculoRepository veiculoRepo;
        private readonly ITaxaRepository taxaDaLocacaoRepo;
        private readonly IEmail email;
        private readonly IPDF pdf;
        public LocacaoAppService(ILocacaoRepository locacaoRepo, IEmail email,
                                 IPDF pdf, IDescontoRepository descontoRepo,
                                 IVeiculoRepository veiculoRepo, ITaxaRepository taxaDaLocacaoRepo)
        {
            this.veiculoRepo = veiculoRepo;
            this.locacaoRepo = locacaoRepo;
            this.descontoRepo = descontoRepo;
            this.taxaDaLocacaoRepo = taxaDaLocacaoRepo;
            this.email = email;
            this.pdf = pdf;
        }
        public void RegistrarNovaLocacao(Locacao locacao)
        {
            string resultadoValidacaoDominio = locacao.Validar();

            Serilogger.Logger.Aqui().Debug("REGISTRANDO LOCAÇÃO {Locacao}", locacao.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                locacaoRepo.Inserir(locacao);

                locacaoRepo.AbrirLocacao(locacao);

                if (locacao.Servicos != null)
                    locacao.Servicos.ForEach(x => taxaDaLocacaoRepo.Inserir(new TaxaDaLocacao(x, locacao)));

                Serilogger.Logger.Aqui().Debug("LOCAÇÃO {Locacao} REGISTRADA COM SUCESSO", locacao.ToString());

                veiculoRepo.LocarVeiculo(locacao.Veiculo);

                Serilogger.Logger.Aqui().Debug("VEÍCULO {Veiculo} LOCADO COM SUCESSO", locacao.Veiculo.ToString());

                if (locacao.Desconto != null)
                {
                    locacao.Desconto.Usos++;

                    descontoRepo.Editar(locacao.Desconto);
                }

                Serilogger.Logger.Aqui().Debug("MONTANDO PDF DA LOCAÇÃO ID: {Id}", locacao.Id);

                pdf.MontarPDF(locacao);
            }
            else
            {
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR LOCAÇÃO {Locacao}", locacao.ToString());
            }
        }
        public void ConcluirLocacao(Locacao locacao)
        {
            Serilogger.Logger.Aqui().Debug("CONCLUINDO LOCAÇÃO {Locacao}", locacao.ToString());

            locacaoRepo.ConcluirLocacao(locacao);

            Serilogger.Logger.Aqui().Debug("DEVOLVENDO VEÍCULO {Veiculo}", locacao.Veiculo.ToString());

            veiculoRepo.DevolverVeiculo(locacao.Veiculo);

            Serilogger.Logger.Aqui().Debug("ATUALIZAR QUILOMETRAGEM DO VEÍCULO {Veiculo}", locacao.Veiculo.ToString());

            veiculoRepo.AtualizarQuilometragem(locacao.Veiculo);
        }
        public void EditarLocacao(Locacao locacao)
        {
            string resultadoValidacaoDominio = locacao.Validar();

            Serilogger.Logger.Aqui().Debug("EDITANDO LOCAÇÃO {Locacao}", locacao.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                locacaoRepo.Editar(locacao);

                taxaDaLocacaoRepo.ExcluirTaxa(locacao.Id);

                if (locacao.Servicos != null)
                    locacao.Servicos.ForEach(x => taxaDaLocacaoRepo.Inserir(new TaxaDaLocacao(x, locacao)));

                Serilogger.Logger.Aqui().Debug("LOCAÇÃO {Locacao} EDITADA COM SUCESSO", locacao.ToString());
            }
            else
            {
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR LOCAÇÃO {Locacao}", locacao.ToString());
            }
        }

        public bool ExcluirLocacao(Locacao locacao)
        {
            Serilogger.Logger.Aqui().Debug("REMOVENDO LOCAÇÃO {Id}", locacao);

            locacaoRepo.ConcluirLocacao(locacao);

            veiculoRepo.DevolverVeiculo(locacao.Veiculo);

            taxaDaLocacaoRepo.ExcluirTaxa(locacao.Id);

            var excluiu = locacaoRepo.Excluir(locacao);

            if (excluiu)
                Serilogger.Logger.Aqui().Debug("LOCAÇÃO {Id} REMOVIDA COM SUCESSO", locacao.Id);
            else
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER LOCAÇÃO {Id}.", locacao.Id);

            return excluiu;
        }
        public List<Locacao> SelecionarTodasLocacoes()
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO TODAS AS LOCAÇÕES");

            List<Locacao> locacao = locacaoRepo.GetAll();

            if (locacao.Count == 0)
                Serilogger.Logger.Aqui().Information("NÃO HÁ LOCAÇÕES CADASTRADAS");
            else
                Serilogger.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) EXISTENTE(S)", locacao.Count);

            return locacao;
        }
        public Locacao SelecionarLocacaoPorId(int id)
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO A LOCAÇÃO ID: {Id}", id);

            Locacao locacao = locacaoRepo.GetById(id);

            if (locacao == null)
                Serilogger.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR A LOCAÇÃO ID {Id}", locacao.Id);
            else
                Serilogger.Logger.Aqui().Debug("LOCAÇÃO ID {Id} SELECIONADA COM SUCESSO", locacao.Id);

            return locacao;
        }
        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO TODAS AS LOCAÇÕES CONCLUÍDAS");

            List<Locacao> locacao = locacaoRepo.SelecionarTodasLocacoesConcluidas();

            if (locacao.Count == 0)
                Serilogger.Logger.Aqui().Information("NÃO HÁ LOCAÇÕES CONCLUÍDAS CADASTRADAS");
            else
                Serilogger.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) CONCLUÍDA(S) EXISTENTE(S)", locacao.Count);

            return locacao;
        }
        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO TODAS AS LOCAÇÕES PENDENTES");

            List<Locacao> locacao = locacaoRepo.SelecionarTodasLocacoesPendentes();

            if (locacao.Count == 0)
                Serilogger.Logger.Aqui().Information("NÃO HÁ LOCAÇÕES PENDENTES CADASTRADAS");
            else
                Serilogger.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) PENDENTES(S) EXISTENTE(S)", locacao.Count);

            return locacao;
        }
        public int SelecionarQuantidadeLocacoesPendentes()
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO TODAS AS LOCAÇÕES PENDENTES");

            var qtdLocacao = locacaoRepo.SelecionarQuantidadeLocacoesPendentes();

            if (qtdLocacao == 0)
                Serilogger.Logger.Aqui().Information("NÃO HÁ LOCAÇÕES PENDENTES CADASTRADAS");
            else
                Serilogger.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) PENDENTES(S) EXISTENTE(S)", qtdLocacao);

            return qtdLocacao;
        }
        public int SelecionarLocacoesComCupons(string cupom)
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO TODAS AS LOCAÇÕES COM CUPOM");

            var qtdLocacao = locacaoRepo.SelecionarQuantidadeLocacoesPendentes();

            if (qtdLocacao == 0)
                Serilogger.Logger.Aqui().Information("NÃO HÁ LOCAÇÕES COM CUPOM");
            else
                Serilogger.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) COM CUPOM EXISTENTE(S)", qtdLocacao);

            return qtdLocacao;
        }
    }
}
