using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.Logger;
using System.Collections.Generic;


namespace LocadoraDeVeiculos.Aplicacao.VeiculoModule
{
    public class VeiculoAppService
    {
        private readonly IVeiculoRepository veiculoRepository;

        public VeiculoAppService(IVeiculoRepository veiculoRepository)
        {
            this.veiculoRepository = veiculoRepository;
        }

        public void RegistrarNovoVeiculo(Veiculo veiculo)
        {
            string resultadoValidacaoDominio = veiculo.Validar();

            Serilogger.Logger.Aqui().Debug("REGISTRANDO VEÍCULO {VeiculoNome}", veiculo.Nome);


            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {

                veiculoRepository.Inserir(veiculo);
                Serilogger.Logger.Aqui().Debug("VEÍCULO {VeiculoNome} REGISTRADO COM SUCESSO", veiculo.Nome);

            }
            else
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR VEÍCULO {VeiculoNome}", veiculo.Nome);

        }

        public void EditarVeiculo(Veiculo veiculo)
        {
            string resultadoValidacaoDominio = veiculo.Validar();

            Serilogger.Logger.Aqui().Debug("EDITANDO VEÍCULO {VeiculoNome}", veiculo.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
               
                veiculoRepository.Editar(veiculo);
                Serilogger.Logger.Aqui().Debug("VEÍCULO {VeiculoNome} EDITADO COM SUCESSO", veiculo.Nome);

            }

            else
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR VEÍCULO {VeiculoNome}", veiculo.Nome);

        }

        public bool ExcluirVeiculo(Veiculo veiculo)
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO O VEÍCULO ID: {Id}", veiculo.Id);

            var excluiu = veiculoRepository.Excluir(veiculo);

            if (excluiu)
                Serilogger.Logger.Aqui().Debug("VEÍCULO {Id} REMOVIDO COM SUCESSO", veiculo.Id);
            else
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER GRUPO VEÍCULO {Id}.", veiculo.Id);

            return excluiu;
        }

        public Veiculo SelecionarVeiculoPorId(int id)
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO O VEÍCULO ID: {Id}", id);

            Veiculo veiculo =  veiculoRepository.GetById(id);


            if (veiculo == null)
                Serilogger.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O VEÍCULO ID {Id}", veiculo.Id);
            else
                Serilogger.Logger.Aqui().Debug("VEÍCULO ID {Id} SELECIONADO COM SUCESSO", veiculo.Id);

            return veiculo;
        }

        public List<Veiculo> SelecionarTodosVeiculos()
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO TODOS OS VEÍCULOS");

            List<Veiculo> veiculo = veiculoRepository.GetAll();

            if (veiculo.Count == 0)
                Serilogger.Logger.Aqui().Information("NÃO HÁ VEÍCULOS CADASTRADOS");
            else
                Serilogger.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} VEÍCULO(S) EXISTENTE(S)", veiculo.Count);

            return veiculo;             
        }       

        public void EditarDisponibilidadeVeiculo(Veiculo atual, Veiculo antigo)
        {
            Serilogger.Logger.Aqui().Debug("EDITANDO DISPONIBILIDADE DOS VEÍCULOS {VeiculoNomeAtual} E {VeiculoNomeAntigo}", atual.Nome, antigo.Nome);

            veiculoRepository.EditarDisponibilidade(atual, antigo);
        }

        public List<Veiculo> SelecionarTodosVeiculosAlugados()
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO TODOS OS VEÍCULOS ALUGADOS");

            List<Veiculo> veiculo = veiculoRepository.SelecionarTodosVeiculosAlugados();

            if (veiculo.Count == 0)
                Serilogger.Logger.Aqui().Information("NÃO HÁ VEÍCULOS ALUGADOS");
            else
                Serilogger.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} VEÍCULO(S) ALUGADO(S)", veiculo.Count);

            return veiculo;            
        }

        public List<Veiculo> SelecionarTodosVeiculosDisponiveis()
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO TODOS OS VEÍCULOS DISPONÍVEIS");

            List<Veiculo> veiculo = veiculoRepository.SelecionarTodosVeiculosDisponiveis();

            if (veiculo.Count == 0)
                Serilogger.Logger.Aqui().Information("NÃO HÁ VEÍCULOS DISPONÍVEIS");
            else
                Serilogger.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} VEÍCULO(S) DISPONÍVEIS", veiculo.Count);

            return veiculo;           
        }

        public int SelecionarQuantidadeVeiculosAlugados()
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO QUANTIDADE DE VEÍCULOS ALUGADOS");

            int quantidade = veiculoRepository.SelecionarQuantidadeVeiculosAlugados();

            if (quantidade == 0)
                Serilogger.Logger.Aqui().Information("NÃO HÁ VEÍCULOS ALUGADOS");
            else
                Serilogger.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} VEÍCULO(S) ALUGADOS",  quantidade);

            return quantidade;
           
        }

        public int SelecionarQuantidadeVeiculosDisponiveis()
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO QUANTIDADE DE VEÍCULOS DISPONÍVEIS");

            int quantidade = veiculoRepository.SelecionarQuantidadeVeiculosDisponiveis();

            if (quantidade == 0)
                Serilogger.Logger.Aqui().Information("NÃO HÁ VEÍCULOS DISPONÍVEIS");
            else
                Serilogger.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} VEÍCULO(S) DISPONÍVEIS", quantidade);

            return quantidade;
           
        }

    }
}

