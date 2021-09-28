using LocadoraDeVeiculos.Dominio.ClienteModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.Shared;
using LocadoraDeVeiculos.Infra.SQL.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.SQL.ClienteCPFModule;
using LocadoraDeVeiculos.Infra.SQL.DescontoModule;
using LocadoraDeVeiculos.Infra.SQL.TaxaServicoModule.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Infra.SQL.VeiculoModule;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraDeVeiculos.Infra.SQL.LocacaoModule
{
    public class LocacaoDAO : ILocacaoRepository
    {
        private readonly DescontoDAO descontoDAO;
        private readonly ClienteCPFDAO clienteCPFDAO;
        private readonly ClienteCNPJDAO clienteCNPJDAO;
        private readonly VeiculoDAO veiculoDAO;
        private readonly TaxaDaLocacaoDAO taxaDaLocacaoDAO;
        private readonly Logger logger;

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
        public LocacaoDAO(Logger log)
        {
            logger = log;
            descontoDAO = new(logger);
            clienteCPFDAO = new(logger);
            clienteCNPJDAO = new(logger);
            veiculoDAO = new(logger);
            taxaDaLocacaoDAO = new(logger);
        }
        public void Inserir(Locacao registro)
        {
            try
            {
                registro.Id = Db.Insert(sqlInserirLocacao, ObtemParametrosLocacao(registro));

                logger.Aqui().Information("SUCESSO AO INSERIR LOCAÇÃO ID: {Id}  ", registro.Id );
            }
            catch (Exception ex)
            {
                 logger.Aqui().Error(ex , "ERRO AO INSERIR LOCAÇÃO ID: {Id}  ", registro.Id );
            }
        }
        public void ConcluirLocacao(int id, Locacao locacao)
        {
            try
            {
                locacao.Id = id;

                locacao.StatusLocacao = "Concluída";

                Db.Update(sqlEditarLocacao, ObtemParametrosLocacao(locacao));

                logger.Aqui().Information("SUCESSO AO CONCLUIR LOCAÇÃO ID: {Id}  ", locacao.Id );
            }
            catch (Exception ex)
            {
                 logger.Aqui().Error(ex , "ERRO AO CONCLUIR LOCAÇÃO ID: {Id}  ", locacao.Id );
            }
        }
        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            try
            {
                List<Locacao> locacoes = Db.GetAll(sqlSelecionarLocacoesConcluidas, ConverterEmLocacao);

                if (locacoes != null)
                    logger.Aqui().Debug("SUCESSO AO SELECIONAR TODAS AS LOCAÇÕES CONCLUÍDAS  " );
                else
                    logger.Aqui().Information("NÃO FOI POSSÍVEL SELECIONAR TODAS AS LOCAÇÕES CONCLUÍDAS  " );

                return locacoes;
            }
            catch (Exception ex)
            {
                 logger.Aqui().Error(ex , "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODAS AS LOCAÇÕES CONCLUÍDAS  " );

                return null;
            }
        }
        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
            try
            {
                List<Locacao> locacoes = Db.GetAll(sqlSelecionarLocacoesPendentes, ConverterEmLocacao);

                if (locacoes != null)
                    logger.Aqui().Debug("SUCESSO AO SELECIONAR TODAS AS LOCAÇÕES PENDENTES  " );
                else
                    logger.Aqui().Information("NÃO FOI POSSÍVEL SELECIONAR TODAS AS LOCAÇÕES PENDENTES  " );

                return locacoes;
            }
            catch (Exception ex)
            {
                 logger.Aqui().Error(ex , "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODAS AS LOCAÇÕES PENDENTES  " );

                return null;
            }
        }
        public int SelecionarQuantidadeLocacoesPendentes()
        {
            try
            {
                int qtdLocacoesPendentes = Db.GetAll(sqlLocacoesPendentes, ConverterEmLocacao).Count;

                if (qtdLocacoesPendentes == 0)
                    logger.Aqui().Debug("SUCESSO AO SELECIONAR A QUANTIDADE DE LOCAÇÕES PENDENTES  " );
                else
                    logger.Aqui().Information("NÃO FOI POSSÍVEL SELECIONAR A QUANTIDADE DE LOCAÇÕES PENDENTES  " );

                return qtdLocacoesPendentes;
            
            }
            catch (Exception ex)
            {
                 logger.Aqui().Error(ex , "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR A QUANTIDADE DE LOCACOES PENDENTES  " );

                return 0;
            }
        }
        public void Editar(int id, Locacao registro)
        {
            try
            {
                registro.Id = id;
                Db.Update(sqlEditarLocacao, ObtemParametrosLocacao(registro));

                logger.Aqui().Information("SUCESSO AO EDITAR LOCAÇÃO ID: {Id}  ", registro.Id );
            }
            catch (Exception ex)
            {
                 logger.Aqui().Error(ex , "ERRO AO EDITAR LOCAÇÃO ID: {Id}  ", registro.Id );
            }

        }
        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirLocacao, AdicionarParametro("ID", id));

                logger.Aqui().Information("SUCESSO AO REMOVER LOCAÇÃO ID: {Id}  ", id );
            }
            catch (Exception ex)
            {
                 logger.Aqui().Error(ex , "ERRO AO REMOVER LOCAÇÃO ID: {Id}  ", id );

                return false;
            }

            return true;
        }
        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteLocacao, AdicionarParametro("ID", id));
        }
        public Locacao SelecionarPorId(int id)
        {
            try
            {
                Locacao locacao = Db.Get(sqlSelecionarLocacaoPorId, ConverterEmLocacao, AdicionarParametro("ID", id));

                if (locacao != null)
                    logger.Aqui().Debug("SUCESSO AO SELECIONAR LOCAÇÃO ID: {Id}  ", locacao.Id );
                else
                    logger.Aqui().Information("NÃO FOI POSSÍVEL SELECIONAR LOCAÇÃO ID: {Id}  ", locacao.Id );

                return locacao;
            }
            catch (Exception ex)
            {
                 logger.Aqui().Error(ex , "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR LOCAÇÃO ID: {Id}  ", id );

                return null;
            }
        }
        public List<Locacao> SelecionarTodos()
        {
            try
            {
                List<Locacao> locacoes = Db.GetAll(sqlSelecionarTodasLocacoes, ConverterEmLocacao);

                if (locacoes != null)
                    logger.Aqui().Debug("SUCESSO AO SELECIONAR TODAS AS LOCAÇÕES  " );
                else
                    logger.Aqui().Information("NÃO FOI POSSÍVEL SELECIONAR TODAS AS LOCAÇÕES  " );

                return locacoes;
            }
            catch (Exception ex)
            {
                 logger.Aqui().Error(ex , "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODAS AS LOCAÇÕES  " );

                return null;
            }
        }
        public int SelecionarLocacoesComCupons(string cupom)
        {
            try
            {
                int qtdLocacoesComCupom = Db.GetAll(sqlSelecionarLocacoesComCupons, ConverterEmLocacao, AdicionarParametro("CUPOM", cupom)).Count;

                if (qtdLocacoesComCupom == 0)
                    logger.Aqui().Debug("SUCESSO AO SELECIONAR A QUANTIDADE DE LOCAÇÕES COM CUPOM  " );
                else
                    logger.Aqui().Information("NÃO FOI POSSÍVEL SELECIONAR A QUANTIDADE DE LOCAÇÕES COM CUPOM  " );

                return qtdLocacoesComCupom;

            }
            catch (Exception ex)
            {
                 logger.Aqui().Error(ex , "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR A QUANTIDADE DE LOCAÇÕES COM CUPOM  " );

                return 0;
            }
        }
        public List<Locacao> SelecionarPesquisa(string combobox, string pesquisa)
        {
            throw new NotImplementedException();
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
                int idDesconto = Convert.ToInt32(reader["ID_DESCONTO"]);
                desconto = descontoDAO.SelecionarPorId(idDesconto);
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


            ClienteCPF condutor = clienteCPFDAO.SelecionarPorId(idCondutor);

            Veiculo veiculo = veiculoDAO.SelecionarPorId(idVeiculo);

            ClienteBase clienteLocador;

            if (tipoCliente == 1)
                clienteLocador = clienteCNPJDAO.SelecionarPorId(idClienteLocador);
            else
                clienteLocador = clienteCPFDAO.SelecionarPorId(idClienteLocador);

            var taxas = taxaDaLocacaoDAO.SelecionarTaxasDeUmaLocacao(id);

            List<Servico> servicos = new List<Servico>();

            foreach (var item in taxas)
                servicos.Add(item.TaxaLocacao);

            Locacao locacao = new Locacao(clienteLocador, veiculo, desconto, condutor, dataSaida, dataRetorno, plano,
                                          tipoCliente, precoServico, dias, status, precoGas, precoPlano, precoTotal, servicos);

            locacao.Id = id;

            return locacao;
        }
        private Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }

    }
}
