using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.LogManager;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.DescontoModule
{
    public class DescontoAppService
    {
        private readonly IDescontoRepository descontoRepository;

        public DescontoAppService(IDescontoRepository descontoRepo)
        {
            descontoRepository = descontoRepo;
        }


        public bool RegistrarNovoDesconto(Desconto desconto)
        {
            string resultadoValidacaoDominio = desconto.Validar();

            LogSerilog.Logger.Aqui().Debug("REGISTRANDO CUPOM DE DESCONTO {DescontoNome}", desconto.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {                
                descontoRepository.Inserir(desconto);

                LogSerilog.Logger.Aqui().Debug("CUPOM DE DESCONTO {DescontoNome} REGISTRADO COM SUCESSO", desconto.Nome);

                return true;
            }
            else
            {
                LogSerilog.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR CUPOM DE DESCONTO {DescontoNome}", desconto.Nome);

                return false;
            }
            
        }

        public bool EditarDesconto(Desconto desconto)
        {
            string resultadoValidacaoDominio = desconto.Validar();

            LogSerilog.Logger.Aqui().Debug("EDITANDO CUPOM DE DESCONTO {DescontoNome}", desconto.Nome);

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                descontoRepository.Editar(desconto);

                LogSerilog.Logger.Aqui().Debug("CUPOM DE DESCONTO {DescontoNome} EDITADO COM SUCESSO", desconto.Nome);

                return true;
            }
            else
            {
                LogSerilog.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR CUPOM DE DESCONTO {DescontoNome}", desconto.Nome);

                return false;
            }        
        }

        public bool ExcluirDesconto(Desconto desconto)
        {        
            LogSerilog.Logger.Aqui().Debug("REMOVENDO CUPOM DE DESCONTO {Id}", desconto.Id);

            var excluiu = descontoRepository.Excluir(desconto);

            if (excluiu)
                LogSerilog.Logger.Aqui().Debug("CUPOM DE DESCONTO {Id} REMOVIDO COM SUCESSO", desconto.Id);
            else
                LogSerilog.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER CUPOM DE DESCONTO {Id}.", desconto.Id);

            return excluiu;
        }

        public Desconto SelecionarPorId(int id)
        {
            LogSerilog.Logger.Aqui().Debug("SELECIONANDO O CUPOM DE DESCONTO ID: {Id}", id);

            Desconto desconto =  descontoRepository.GetById(id);

            if (desconto == null)
                LogSerilog.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O CUPOM DE DESCONTO ID {Id}", desconto.Id);
            else
                LogSerilog.Logger.Aqui().Debug("CUPOM DE DESCONTO ID {Id} SELECIONADO COM SUCESSO", desconto.Id);

            return desconto;
        }

        public List<Desconto> SelecionarTodosDescontos()
        {
            LogSerilog.Logger.Aqui().Debug("SELECIONANDO TODOS OS CUPONS DE DESCONTOS");

            List<Desconto> desconto = descontoRepository.GetAll();

            if(desconto.Count == 0)
                LogSerilog.Logger.Aqui().Information("NÃO HÁ CUPONS DE DESCONTOS CADASTRADOS");
            else
                LogSerilog.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} CUPOM(NS) DE DESCONTO(S) EXISTENTE(S)", desconto.Count);

            return desconto;
        }

        public bool VerificarCodigoExistente(string codigo)
        {
            LogSerilog.Logger.Aqui().Debug("VERIFICANDO SE O CUPOM DE DESCONTO COM O CÓDIGO {Codigo} EXISTE", codigo);

            var verificou =  descontoRepository.VerificarCodigoExistente(codigo);

            if (!verificou)
                LogSerilog.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O CUPOM DE DESCONTO COM O CÓDIGO {Codigo}", codigo);
            else
                LogSerilog.Logger.Aqui().Debug("CUPOM DE DESCONTO COM O CÓDIGO {Codigo} ENCONTRADO COM SUCESSO", codigo);

            return verificou;


        }
        public Desconto VerificarCodigoValido(string codigo)
        {
            LogSerilog.Logger.Aqui().Debug("VERIFICANDO SE O CUPOM DE DESCONTO COM O CÓDIGO {Codigo} É VÁLIDO", codigo);

            Desconto desconto = descontoRepository.VerificarCodigoValido(codigo);

            if (desconto == null)
                LogSerilog.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O CUPOM DE DESCONTO COM O CÓDIGO {Codigo}", codigo);
            else
                LogSerilog.Logger.Aqui().Debug("CUPOM DE DESCONTO COM O CÓDIGO {Codigo} ENCONTRADO COM SUCESSO", codigo);

            return desconto;
        }
    }
}
