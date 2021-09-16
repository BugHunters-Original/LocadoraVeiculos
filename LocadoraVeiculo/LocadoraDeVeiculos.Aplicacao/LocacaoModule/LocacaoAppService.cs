using LocadoraDeVeiculos.Dominio.LocacaoModule;
using log4net;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.LocacaoModule
{
    public class LocacaoAppService
    {
        private readonly ILocacaoRepository locacaoRepo;
        private readonly ILog logger;
        private readonly IEmail email;
        private readonly IPDF pdf;
        public LocacaoAppService(ILocacaoRepository locacaoRepo, ILog logger,
                                IEmail email, IPDF pdf)
        {
            this.locacaoRepo = locacaoRepo;
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

                locacaoRepo.Inserir(locacao);

                logger.Debug($"Locação {locacao} registrado com sucesso!");

                pdf.MontarPDF(locacao);

                logger.Debug($"PDF da Locação {locacao.Id} registrado com sucesso!");

                var enviouOEmail = email.EnviarEmail(locacao);

                if (enviouOEmail)
                    logger.Debug($"E-Mail enviado para {locacao.Cliente.Email} com sucesso!");
                else
                    logger.Debug($"Erro ao enviar E-Mail para {locacao.Cliente.Email}!");
            }
        }
        public void ConcluirLocacao(int id, Locacao locacao)
        {
            locacaoRepo.ConcluirLocacao(id, locacao);
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
            return locacaoRepo.Excluir(id);
        }
        public List<Locacao> SelecionarTodasLocacoes()
        {
            return locacaoRepo.SelecionarTodos();
        }
        public Locacao SelecionarLocacaoPorId(int id)
        {
            return locacaoRepo.SelecionarPorId(id);
        }
        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            return locacaoRepo.SelecionarTodasLocacoesConcluidas();
        }
        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
            return locacaoRepo.SelecionarTodasLocacoesPendentes();
        }
        public int SelecionarQuantidadeLocacoesPendentes()
        {
            return locacaoRepo.SelecionarQuantidadeLocacoesPendentes();
        }
        public int SelecionarLocacoesComCupons(string cupom)
        {
            return locacaoRepo.SelecionarLocacoesComCupons(cupom);
        }
    }
}
