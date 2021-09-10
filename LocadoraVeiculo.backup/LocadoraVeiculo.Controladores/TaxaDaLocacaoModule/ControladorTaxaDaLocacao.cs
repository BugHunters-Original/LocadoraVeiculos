using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.Controladores.ClienteModule;
using LocadoraVeiculo.Controladores.CondutorModule;
using LocadoraVeiculo.Controladores.DescontoModule;
using LocadoraVeiculo.Controladores.LocacaoModule;
using LocadoraVeiculo.Controladores.ServicoModule;
using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.DescontoModule;
using LocadoraVeiculo.LocacaoModule;
using LocadoraVeiculo.ServicoModule;
using LocadoraVeiculo.TaxaDaLocacaoModule;
using LocadoraVeiculo.VeiculoModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Controladores.TaxaDaLocacaoModule
{
    public class ControladorTaxaDaLocacao : Controlador<TaxaDaLocacao>
    {
        #region Queries
        private const string sqlInserirTaxaLocacao =
       @"INSERT INTO TBTAXASDALOCACAO
	                (   
		                [ID_LOCACAO], 
		                [ID_TAXA] 		                
	                ) 
	                VALUES
	                (
		                @ID_LOCACAO, 
		                @ID_TAXA		              
	                )";

        private const string sqlExcluirTaxaLocacao =
            @"DELETE 
	                FROM
                        TBTAXASDALOCACAO
                    WHERE 
                        ID_LOCACAO = @ID_LOCACAO";

        private const string sqlEditarTaxaLocacao =
            @"UPDATE TBTAXASDALOCACAO
                    SET
		                [ID_LOCACAO] = @ID_LOCACAO, 
		                [ID_TAXA] = @ID_TAXA
		                
                    WHERE 
                        ID_LOCACAO = @ID_LOCACAO";

        private const string sqlSelecionarTaxaLocacaoPorId =
            @"SELECT    
                        T.[ID],
		                T.[ID_LOCACAO], 
		                T.[ID_TAXA],
                        L.[ID_CONDUTOR], 
		                L.[ID_CLIENTELOCADOR], 
		                L.[ID_VEICULO],
		                L.[ID_DESCONTO],
                        L.[DATA_SAIDA], 
		                L.[DATA_RETORNOESPERADO],
                        L.[PLANO],
                        L.[TIPOCLIENTE],
                        L.[PRECOSERVICOS],
                        L.[DIAS],
                        L.[STATUS],    
                        L.[PRECOCOMBUSTIVEL],    
                        L.[PRECOPLANO],    
                        L.[PRECOTOTAL]
	                FROM
                        TBTAXASDALOCACAO AS T INNER JOIN
                        TBLOCACAO AS L
                      ON
                        L.ID = T.ID_LOCACAO
                   WHERE 
                        T.ID_LOCACAO = @ID_LOCACAOTAXA";

        private const string sqlSelecionarTaxaLocacaoEspecifica =
           @"SELECT                
		                [ID_LOCACAO], 
		                [ID_TAXA]
		                
	                FROM
                        TBTAXASDALOCACAO
                    WHERE 
                        ID_LOCACAO = @ID_LOCACAO";
        #endregion

        public override string Editar(int id, TaxaDaLocacao registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarTaxaLocacao, ObtemParametrosTaxaLocacao(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirTaxaLocacao, AdicionarParametro("ID_LOCACAO", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public override string InserirNovo(TaxaDaLocacao registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirTaxaLocacao, ObtemParametrosTaxaLocacao(registro));
            }

            return resultadoValidacao;
        }

        private Dictionary<string, object> ObtemParametrosTaxaLocacao(TaxaDaLocacao taxaLocacao)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", taxaLocacao.Id);
            parametros.Add("ID_LOCACAO", taxaLocacao.LocacaoEscolhida.Id);
            parametros.Add("ID_TAXA", taxaLocacao.TaxaLocacao.Id);

            return parametros;
        }

        public override TaxaDaLocacao SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarTaxaLocacaoPorId, ConverterEmTaxaLocacao, AdicionarParametro("ID", id));
        }

        public override List<TaxaDaLocacao> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTaxaLocacaoEspecifica, ConverterEmTaxaLocacao);
        }

        public List<TaxaDaLocacao> SelecionarTaxasDeUmaLocacao(int id)
        {
            return Db.GetAll(sqlSelecionarTaxaLocacaoPorId, ConverterEmTaxaLocacao, AdicionarParametro("ID_LOCACAOTAXA", id));
        }


        private TaxaDaLocacao ConverterEmTaxaLocacao(IDataReader reader)
        {
            int id_taxa = Convert.ToInt32(reader["ID_TAXA"]);

            ControladorServico controladorServico = new ControladorServico();
            Servico servico = controladorServico.SelecionarPorId(id_taxa);

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

            ClienteCPF condutor = controladorCPF.SelecionarPorId(idCondutor);
            Veiculo veiculo = controladorVeiculo.SelecionarPorId(idVeiculo);

            ClienteBase clienteLocador;

            if (tipoCliente == 1)
                clienteLocador = controladorCNPJ.SelecionarPorId(idClienteLocador);
            else
                clienteLocador = controladorCPF.SelecionarPorId(idClienteLocador);



            LocacaoVeiculo locacao = new LocacaoVeiculo(clienteLocador, veiculo, desconto, condutor,
                                                    dataSaida, dataRetorno, plano, tipoCliente, precoServico,
                                                    dias, status, precoGas, precoPlano, precoTotal, null);


            TaxaDaLocacao taxaLocacao = new TaxaDaLocacao(servico, locacao);



            return taxaLocacao;
        }
    }
}
