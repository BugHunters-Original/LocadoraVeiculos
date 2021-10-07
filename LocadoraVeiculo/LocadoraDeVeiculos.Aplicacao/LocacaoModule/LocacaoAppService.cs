using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.LogManager;

namespace LocadoraDeVeiculos.Aplicacao.LocacaoModule
{
    public class LocacaoAppService
    {
        private readonly ILocacaoRepository locacaoRepo;
        private readonly IDescontoRepository descontoRepo;
        private readonly IVeiculoRepository veiculoRepo;
        private readonly IEmail email;
        private readonly IPDF pdf;
        public LocacaoAppService(ILocacaoRepository locacaoRepo,IEmail email,
                                 IPDF pdf, IDescontoRepository descontoRepo,
                                 IVeiculoRepository veiculoRepo)
        {
            this.veiculoRepo = veiculoRepo;
            this.locacaoRepo = locacaoRepo;
            this.descontoRepo = descontoRepo;
            this.email = email;
            this.pdf = pdf;
        }
        public void RegistrarNovaLocacao(Locacao locacao)
        {
            string resultadoValidacaoDominio = locacao.Validar();

            Log.Logger.Aqui().Debug("REGISTRANDO LOCAÇÃO {Locacao}", locacao.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                locacaoRepo.Inserir(locacao);

                Log.Logger.Aqui().Debug("LOCAÇÃO {Locacao} REGISTRADA COM SUCESSO", locacao.ToString());

                veiculoRepo.LocarVeiculo(locacao.Veiculo);

                Log.Logger.Aqui().Debug("VEÍCULO {Veiculo} LOCADO COM SUCESSO", locacao.Veiculo.ToString());

                if (locacao.Desconto != null)
                {
                    locacao.Desconto.Usos++;

                    descontoRepo.Editar(locacao.Desconto);
                }

                Log.Logger.Aqui().Debug("MONTANDO PDF DA LOCAÇÃO ID: {Id}", locacao.Id);

                pdf.MontarPDF(locacao);

                Log.Logger.Aqui().Debug("ENVIANDO EMAIL LOCAÇÃO ID: {Id}", locacao.Id);

                Task.Run(() => email.EnviarEmail(locacao));
            }
            else
            {
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR LOCAÇÃO {Locacao}", locacao.ToString());
            }
        }
        public void ConcluirLocacao(int id, Locacao locacao)
        {
            Log.Logger.Aqui().Debug("CONCLUINDO LOCAÇÃO {Locacao}", locacao.ToString());

            locacaoRepo.ConcluirLocacao(id, locacao);

            Log.Logger.Aqui().Debug("DEVOLVENDO VEÍCULO {Veiculo}", locacao.Veiculo.ToString());

            veiculoRepo.DevolverVeiculo(locacao.Veiculo);

            Log.Logger.Aqui().Debug("ATUALIZAR QUILOMETRAGEM DO VEÍCULO {Veiculo}", locacao.Veiculo.ToString());

            veiculoRepo.AtualizarQuilometragem(locacao.Veiculo);
        }
        public void EditarLocacao(Locacao locacao)
        {
            string resultadoValidacaoDominio = locacao.Validar();

            Log.Logger.Aqui().Debug("EDITANDO LOCAÇÃO {Locacao}", locacao.ToString());

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                locacaoRepo.Editar(locacao);

                Log.Logger.Aqui().Debug("LOCAÇÃO {Locacao} EDITADA COM SUCESSO", locacao.ToString());
            }
            else
            {
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR LOCAÇÃO {Locacao}", locacao.ToString());
            }
        }

        public bool ExcluirLocacao(Locacao locacao)
        {
            Log.Logger.Aqui().Debug("REMOVENDO LOCAÇÃO {Id}", locacao);

            var excluiu = locacaoRepo.Excluir(locacao);

            if (excluiu)
                Log.Logger.Aqui().Debug("LOCAÇÃO {Id} REMOVIDA COM SUCESSO", locacao.Id);
            else
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER LOCAÇÃO {Id}.", locacao.Id);

            return excluiu;
        }
        public List<Locacao> SelecionarTodasLocacoes()
        {
            Log.Logger.Aqui().Debug("SELECIONANDO TODAS AS LOCAÇÕES");

            List<Locacao> locacao = locacaoRepo.GetAll();

            if (locacao.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ LOCAÇÕES CADASTRADAS");
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) EXISTENTE(S)", locacao.Count);

            return locacao;
        }
        public Locacao SelecionarLocacaoPorId(int id)
        {
            Log.Logger.Aqui().Debug("SELECIONANDO A LOCAÇÃO ID: {Id}", id);

            Locacao locacao = locacaoRepo.GetById(id);

            if (locacao == null)
                Log.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR A LOCAÇÃO ID {Id}", locacao.Id);
            else
                Log.Logger.Aqui().Debug("LOCAÇÃO ID {Id} SELECIONADA COM SUCESSO", locacao.Id);

            return locacao;
        }
        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            Log.Logger.Aqui().Debug("SELECIONANDO TODAS AS LOCAÇÕES CONCLUÍDAS");

            List<Locacao> locacao = locacaoRepo.SelecionarTodasLocacoesConcluidas();

            if (locacao.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ LOCAÇÕES CONCLUÍDAS CADASTRADAS");
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) CONCLUÍDA(S) EXISTENTE(S)", locacao.Count);

            return locacao;
        }
        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
            Log.Logger.Aqui().Debug("SELECIONANDO TODAS AS LOCAÇÕES PENDENTES");

            List<Locacao> locacao = locacaoRepo.SelecionarTodasLocacoesPendentes();

            if (locacao.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ LOCAÇÕES PENDENTES CADASTRADAS");
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) PENDENTES(S) EXISTENTE(S)", locacao.Count);

            return locacao;
        }
        public int SelecionarQuantidadeLocacoesPendentes()
        {
            Log.Logger.Aqui().Debug("SELECIONANDO TODAS AS LOCAÇÕES PENDENTES");

            var qtdLocacao = locacaoRepo.SelecionarQuantidadeLocacoesPendentes();

            if (qtdLocacao == 0)
                Log.Logger.Aqui().Information("NÃO HÁ LOCAÇÕES PENDENTES CADASTRADAS");
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) PENDENTES(S) EXISTENTE(S)", qtdLocacao);

            return qtdLocacao;
        }
        public int SelecionarLocacoesComCupons(string cupom)
        {
            Log.Logger.Aqui().Debug("SELECIONANDO TODAS AS LOCAÇÕES COM CUPOM");

            var qtdLocacao = locacaoRepo.SelecionarQuantidadeLocacoesPendentes();

            if (qtdLocacao == 0)
                Log.Logger.Aqui().Information("NÃO HÁ LOCAÇÕES COM CUPOM");
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} LOCAÇÃO(ÕES) COM CUPOM EXISTENTE(S)", qtdLocacao);

            return qtdLocacao;
        }
    }
}
