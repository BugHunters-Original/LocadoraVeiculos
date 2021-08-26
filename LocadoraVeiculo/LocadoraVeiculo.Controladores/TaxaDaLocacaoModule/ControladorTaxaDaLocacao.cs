using LocadoraVeiculo.Controladores.LocacaoModule;
using LocadoraVeiculo.Controladores.ServicoModule;
using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.LocacaoModule;
using LocadoraVeiculo.ServicoModule;
using LocadoraVeiculo.TaxaDaLocacaoModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Controladores.TaxaDaLocacaoModule
{
    public class ControladorTaxaDaLocacao: Controlador<TaxaDaLocacao>
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
                        ID = @ID";

        private const string sqlEditarTaxaLocacao =
            @"UPDATE TBTAXASDALOCACAO
                    SET
		                [ID_LOCACAO] = @ID_LOCACAO, 
		                [ID_TAXA] = @ID_TAXA
		                
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodasTaxasLocacoes =
            @"SELECT
                        [ID],                
		                [ID_LOCACAO], 
		                [ID_TAXA] 
		                
	                FROM
                        TBTAXASDALOCACAO";

        private const string sqlSelecionarTaxaLocacaoPorId =
            @"SELECT
                        [ID],                
		                [ID_LOCACAO], 
		                [ID_TAXA]
		                
	                FROM
                        TBTAXASDALOCACAO
                    WHERE 
                        ID = @ID";

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
                Db.Delete(sqlExcluirTaxaLocacao, AdicionarParametro("ID", id));
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

        public List<TaxaDaLocacao> SelecionarTodasTaxas(int id)
        {
            return Db.GetAll(sqlSelecionarTaxaLocacaoEspecifica, ConverterEmTaxaLocacao, AdicionarParametro("ID_LOCACAO", id));
        }


        private TaxaDaLocacao ConverterEmTaxaLocacao(IDataReader reader)
        {
            
            int id_locacao = Convert.ToInt32(reader["ID_LOCACAO"]);
            int id_taxa = Convert.ToInt32(reader["ID_TAXA"]);

            ControladorServico controladorServico = new ControladorServico();
            Servico servico = controladorServico.SelecionarPorId(id_taxa);

            ControladorLocacao conroladorLocacao = new ControladorLocacao();
            LocacaoVeiculo locacaoVeiculo = conroladorLocacao.SelecionarPorId(id_locacao);
                       



            TaxaDaLocacao taxaLocacao = new TaxaDaLocacao(servico, locacaoVeiculo);

            

            return taxaLocacao;
        }
    }
}
