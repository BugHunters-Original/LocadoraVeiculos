using LocadoraDeVeiculos.Controladores.ClienteCNPJModule;
using LocadoraDeVeiculos.Controladores.ClienteCPFModule;
using LocadoraDeVeiculos.Controladores.DescontoModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Controladores.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Controladores.VeiculoModule;
using LocadoraDeVeiculos.Dominio.ClienteModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Controladores.LocacoModule
{
    public class ControladorLocacao : Controlador<Locacao>
    {
        #region Queries
        private const string sqlInserirLocacao =
            @"INSERT INTO TBLOCACAO
	                (
		                [ID_CONDUTOR], 
		                [ID_CLIENTELOCADOR], 
		                [ID_VEICULO],
		                [ID_DESCONTO],
                        [DATA_SAIDA], 
		                [DATA_RETORNOESPERADO],
                        [PLANO],
                        [TIPOCLIENTE],
                        [PRECOSERVICOS],
                        [DIAS],
                        [STATUS],    
                        [PRECOCOMBUSTIVEL],    
                        [PRECOPLANO],    
                        [PRECOTOTAL] 
	                ) 
	                VALUES
	                (
		                @ID_CONDUTOR, 
		                @ID_CLIENTELOCADOR, 
		                @ID_VEICULO,
		                @ID_DESCONTO,
                        @DATA_SAIDA, 
		                @DATA_RETORNOESPERADO,
                        @PLANO,
                        @TIPOCLIENTE,
                        @PRECOSERVICOS,
                        @DIAS,
                        @STATUS,
                        @PRECOCOMBUSTIVEL,
                        @PRECOPLANO,
                        @PRECOTOTAL
	                )";
        private const string sqlEditarLocacao =
            @"UPDATE TBLOCACAO
                    SET
		                [ID_CONDUTOR] = @ID_CONDUTOR, 
		                [ID_CLIENTELOCADOR] = @ID_CLIENTELOCADOR, 
		                [ID_VEICULO] = @ID_VEICULO,
		                [ID_DESCONTO] = @ID_DESCONTO,
                        [DATA_SAIDA] = @DATA_SAIDA, 
		                [DATA_RETORNOESPERADO] = @DATA_RETORNOESPERADO,
                        [PLANO] = @PLANO,
                        [TIPOCLIENTE] = @TIPOCLIENTE,
                        [PRECOSERVICOS] = @PRECOSERVICOS,
                        [DIAS] = @DIAS,
                        [STATUS] = @STATUS,
                        [PRECOCOMBUSTIVEL] = @PRECOCOMBUSTIVEL,
                        [PRECOPLANO] = @PRECOPLANO,
                        [PRECOTOTAL] = @PRECOTOTAL
                    WHERE 
                        ID = @ID";

        private const string sqlMudarDisponibilidade =
            @"UPDATE TBVEICULOS
                    SET
                        [DISPONIBILIDADE_VEICULO] = @DISPONIBILIDADE_VEICULO
                    WHERE 
                        ID = @ID_VEICULO";
        private const string sqlExcluirLocacao =
            @"DELETE 
	                FROM
                        TBLOCACAO
                    WHERE 
                        ID = @ID";
        private const string sqlSelecionarLocacaoPorId =
            @"SELECT
                        [ID],                
		                [ID_CONDUTOR], 
		                [ID_CLIENTELOCADOR], 
		                [ID_VEICULO],
		                [ID_DESCONTO],
                        [DATA_SAIDA], 
		                [DATA_RETORNOESPERADO],
                        [PLANO],
                        [TIPOCLIENTE],
                        [PRECOSERVICOS],
                        [DIAS],
                        [STATUS],    
                        [PRECOCOMBUSTIVEL],    
                        [PRECOPLANO],    
                        [PRECOTOTAL] 
	                FROM
                        TBLOCACAO
                    WHERE 
                        ID = @ID";
        private const string sqlSelecionarTodasLocacoes =
            @"SELECT
                        [ID],                
		                [ID_CONDUTOR], 
		                [ID_CLIENTELOCADOR], 
		                [ID_VEICULO],
                        [ID_DESCONTO],
                        [DATA_SAIDA], 
		                [DATA_RETORNOESPERADO],
                        [PLANO],
                        [TIPOCLIENTE],
                        [PRECOSERVICOS],
                        [DIAS],
                        [STATUS],    
                        [PRECOCOMBUSTIVEL],    
                        [PRECOPLANO],    
                        [PRECOTOTAL] 
	                FROM
                        TBLOCACAO";
        private const string sqlExisteLocacao =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBLOCACAO]
            WHERE 
                [ID] = @ID";

        private const string sqlLocacoesPendentes =
            @"SELECT 
                * 
            FROM 
                [TBLOCACAO]
            WHERE 
                [STATUS] = 'Em Aberto'";
        private const string sqlSelecionarLocacoesPendentes =
            @"SELECT
                        [ID],                
		                [ID_CONDUTOR], 
		                [ID_CLIENTELOCADOR], 
		                [ID_VEICULO],
                        [ID_DESCONTO],
                        [DATA_SAIDA], 
		                [DATA_RETORNOESPERADO],
                        [PLANO],
                        [TIPOCLIENTE],
                        [PRECOSERVICOS],
                        [DIAS],
                        [STATUS],    
                        [PRECOCOMBUSTIVEL],    
                        [PRECOPLANO],    
                        [PRECOTOTAL] 
	                FROM
                        TBLOCACAO
                    WHERE 
                        [STATUS] = 'Em Aberto'";
        private const string sqlSelecionarLocacoesConcluidas =
            @"SELECT
                        [ID],                
		                [ID_CONDUTOR], 
		                [ID_CLIENTELOCADOR], 
		                [ID_VEICULO],
		                [ID_DESCONTO],  
                        [DATA_SAIDA], 
		                [DATA_RETORNOESPERADO],
                        [PLANO],
                        [TIPOCLIENTE],
                        [PRECOSERVICOS],
                        [DIAS],
                        [STATUS],    
                        [PRECOCOMBUSTIVEL],    
                        [PRECOPLANO],    
                        [PRECOTOTAL] 
	                FROM
                        TBLOCACAO
                    WHERE 
                        [STATUS] = 'Concluída'";
        private const string sqlSelecionarLocacoesComCupons =
            @"SELECT
                        *
	                FROM
                        TBLOCACAO AS L INNER JOIN
                        TBDESCONTO AS D
                    ON
                        L.ID_DESCONTO = D.ID      
                    WHERE 
                        [CODIGO] = @CUPOM";
        #endregion

        public void ConcluirLocacao(int id, Locacao locacao)
        {
            locacao.Id = id;
            locacao.StatusLocacao = "Concluída";
            locacao.Veiculo.DisponibilidadeVeiculo = 1;
            Db.Update(sqlEditarLocacao, ObtemParametrosLocacao(locacao));
            Db.Update(sqlMudarDisponibilidade, ObtemParametrosLocacao(locacao));
        }
        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            return Db.GetAll(sqlSelecionarLocacoesConcluidas, ConverterEmLocacao);
        }
        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
            return Db.GetAll(sqlSelecionarLocacoesPendentes, ConverterEmLocacao);
        }
        public int SelecionarQuantidadeLocacoesPendentes()
        {
            return Db.GetAll(sqlLocacoesPendentes, ConverterEmLocacao).Count;
        }
        public override string Editar(int id, Locacao registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarLocacao, ObtemParametrosLocacao(registro));
            }

            return resultadoValidacao;
        }
        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirLocacao, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteLocacao, AdicionarParametro("ID", id));
        }
        public override string InserirNovo(Locacao registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirLocacao, ObtemParametrosLocacao(registro));
            }

            return resultadoValidacao;
        }
        public override Locacao SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarLocacaoPorId, ConverterEmLocacao, AdicionarParametro("ID", id));
        }
        public override List<Locacao> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodasLocacoes, ConverterEmLocacao);
        }
        public int SelecionarLocacoesComCupons(string cupom)
        {
            return Db.GetAll(sqlSelecionarLocacoesComCupons, ConverterEmLocacao, AdicionarParametro("CUPOM", cupom)).Count;
        }
        private Dictionary<string, object> ObtemParametrosLocacao(Locacao locacao)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", locacao.Id);
            parametros.Add("TIPOCLIENTE", locacao.TipoCliente);
            parametros.Add("ID_CONDUTOR", locacao.Condutor.Id);
            parametros.Add("ID_CLIENTELOCADOR", locacao.Cliente.Id);
            parametros.Add("ID_VEICULO", locacao.Veiculo.Id);
            parametros.Add("ID_DESCONTO", locacao.Desconto?.Id);
            parametros.Add("DATA_SAIDA", locacao.DataSaida);
            parametros.Add("DATA_RETORNOESPERADO", locacao.DataRetorno);
            parametros.Add("PLANO", locacao.TipoLocacao);
            parametros.Add("PRECOSERVICOS", locacao.PrecoServicos);
            parametros.Add("DIAS", locacao.Dias);
            parametros.Add("STATUS", locacao.StatusLocacao);
            parametros.Add("PRECOCOMBUSTIVEL", locacao.PrecoCombustivel);
            parametros.Add("PRECOPLANO", locacao.PrecoPlano);
            parametros.Add("PRECOTOTAL", locacao.PrecoTotal);
            parametros.Add("DISPONIBILIDADE_VEICULO", locacao.Veiculo.DisponibilidadeVeiculo);

            return parametros;
        }
        private Locacao ConverterEmLocacao(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            int tipoCliente = Convert.ToInt32(reader["TIPOCLIENTE"]);
            int idCondutor = Convert.ToInt32(reader["ID_CONDUTOR"]);
            int idClienteLocador = Convert.ToInt32(reader["ID_CLIENTELOCADOR"]);
            int idVeiculo = Convert.ToInt32(reader["ID_VEICULO"]);

            Desconto desconto = null;
            if (reader["ID_DESCONTO"] != DBNull.Value)
            {
                ControladorDesconto controladorDesconto = new ControladorDesconto();
                int idDesconto = Convert.ToInt32(reader["ID_DESCONTO"]);
                desconto = controladorDesconto.SelecionarPorId(idDesconto);
            }

            DateTime dataSaida = Convert.ToDateTime(reader["DATA_SAIDA"]);
            DateTime dataRetorno = Convert.ToDateTime(reader["DATA_RETORNOESPERADO"]);
            string plano = Convert.ToString(reader["PLANO"]);
            int dias = Convert.ToInt32(reader["DIAS"]);
            string status = Convert.ToString(reader["STATUS"]);


            decimal? precoGas = null;
            if (reader["PRECOCOMBUSTIVEL"] != DBNull.Value)
                precoGas = Convert.ToDecimal(reader["PRECOCOMBUSTIVEL"]);

            decimal? precoPlano = null;
            if (reader["PRECOPLANO"] != DBNull.Value)
                precoPlano = Convert.ToDecimal(reader["PRECOPLANO"]);

            decimal? precoTotal = null;
            if (reader["PRECOTOTAL"] != DBNull.Value)
                precoTotal = Convert.ToDecimal(reader["PRECOTOTAL"]);

            decimal? precoServico = null;
            if (reader["PRECOSERVICOS"] != DBNull.Value)
                precoServico = Convert.ToDecimal(reader["PRECOSERVICOS"]);

            ControladorClienteCPF controladorCPF = new ControladorClienteCPF();
            ControladorClienteCNPJ controladorCNPJ = new ControladorClienteCNPJ();
            ControladorVeiculo controladorVeiculo = new ControladorVeiculo();
            ControladorTaxaDaLocacao controladorTaxaDaLocacao = new ControladorTaxaDaLocacao();

            ClienteCPF condutor = controladorCPF.SelecionarPorId(idCondutor);
            Veiculo veiculo = controladorVeiculo.SelecionarPorId(idVeiculo);

            ClienteBase clienteLocador;

            if (tipoCliente == 1)
                clienteLocador = controladorCNPJ.SelecionarPorId(idClienteLocador);
            else
                clienteLocador = controladorCPF.SelecionarPorId(idClienteLocador);

            var taxas = controladorTaxaDaLocacao.SelecionarTaxasDeUmaLocacao(id);

            List<Servico> servicos = new List<Servico>();

            foreach (var item in taxas)
                servicos.Add(item.TaxaLocacao);

            Locacao locacao = new Locacao(clienteLocador, veiculo, desconto, condutor,
                                                    dataSaida, dataRetorno, plano, tipoCliente, precoServico,
                                                    dias, status, precoGas, precoPlano, precoTotal, servicos);

            locacao.Id = id;

            return locacao;
        }
    }
}
