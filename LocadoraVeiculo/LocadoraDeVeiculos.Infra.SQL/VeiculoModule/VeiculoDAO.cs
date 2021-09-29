using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.Shared;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Data;


namespace LocadoraDeVeiculos.Infra.SQL.VeiculoModule
{
    public class VeiculoDAO : IVeiculoRepository
    {

        #region Queries
        private const string sqlInserirVeiculo =
            @"INSERT INTO [TBVEICULOS]
                (
                    [NOME],       
                    [NUMERO_PLACA], 
                    [NUMERO_CHASSI],
                    [FOTO],                  
                    [COR],                                                           
                    [MARCA],
                    [ANO],
                    [NUMERO_PORTAS],
                    [CAPACIDADE_TANQUE],
                    [CAPACIDADE_PESSOAS],
                    [TAMANHO_PORTA_MALA],
                    [KM_INICIAL],
                    [TIPO_COMBUSTIVEL],
                    [ID_TIPO_VEICULO],
                    [DISPONIBILIDADE_VEICULO]            
                )
            VALUES
                (
                    @NOME,
                    @NUMERO_PLACA,
                    @NUMERO_CHASSI,
                    @FOTO,
                    @COR,
                    @MARCA,
                    @ANO,
                    @NUMERO_PORTAS,
                    @CAPACIDADE_TANQUE,
                    @CAPACIDADE_PESSOAS,
                    @TAMANHO_PORTA_MALA,
                    @KM_INICIAL,
                    @TIPO_COMBUSTIVEL,
                    @ID_TIPO_VEICULO,
                    @DISPONIBILIDADE_VEICULO
                )";

        private const string sqlEditarVeiculo =
            @" UPDATE [TBVEICULOS]
                SET 
                    [NOME] = @NOME, 
                    [NUMERO_PLACA] = @NUMERO_PLACA, 
                    [NUMERO_CHASSI] = @NUMERO_CHASSI,
                    [FOTO] = @FOTO, 
                    [COR] = @COR,
                    [MARCA] =@MARCA,
                    [ANO] =@ANO,
                    [NUMERO_PORTAS] =@NUMERO_PORTAS,
                    [CAPACIDADE_TANQUE] =@CAPACIDADE_TANQUE,
                    [CAPACIDADE_PESSOAS] =@CAPACIDADE_PESSOAS,
                    [TAMANHO_PORTA_MALA] =@TAMANHO_PORTA_MALA,
                    [KM_INICIAL] =@KM_INICIAL,
                    [TIPO_COMBUSTIVEL] =@TIPO_COMBUSTIVEL,
                    [ID_TIPO_VEICULO] =@ID_TIPO_VEICULO,
                    [DISPONIBILIDADE_VEICULO] = @DISPONIBILIDADE_VEICULO

                WHERE [ID] = @ID";

        private const string sqlExcluirVeiculo =
            @"DELETE FROM [TBVEICULOS] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarTodosVeiculos =
            @"SELECT 
                V.[ID],       
                V.[NOME],
                V.[NUMERO_PLACA],
                V.[NUMERO_CHASSI],             
                V.[FOTO],                    
                V.[COR],                                
                V.[MARCA],
                V.[ANO],
                V.[NUMERO_PORTAS],
                V.[CAPACIDADE_TANQUE],
                V.[CAPACIDADE_PESSOAS],
                V.[TAMANHO_PORTA_MALA],
                V.[KM_INICIAL],
                V.[TIPO_COMBUSTIVEL],
                V.[ID_TIPO_VEICULO],
                V.[DISPONIBILIDADE_VEICULO],
                TV.[NOMETIPO],       
                TV.[VALOR_DIARIO_PDIARIO], 
                TV.[VALOR_KMRODADO_PDIARIO],
                TV.[VALOR_DIARIO_PCONTROLADO],                    
                TV.[LIMITE_PCONTROLADO],                                                           
                TV.[VALOR_KMRODAD_PCONTROLADO],        
                TV.[VALOR_DIARIO_PLIVRE]  
            FROM
                [TBVEICULOS] AS V INNER JOIN
                [TBTIPOVEICULO] AS TV
            ON
                TV.ID = V.ID_TIPO_VEICULO";


        private const string sqlSelecionarVeiculoPorId =
            @"SELECT 
                V.[ID],       
                V.[NOME],
                V.[NUMERO_PLACA],
                V.[NUMERO_CHASSI],             
                V.[FOTO],                    
                V.[COR],                                
                V.[MARCA],
                V.[ANO],
                V.[NUMERO_PORTAS],
                V.[CAPACIDADE_TANQUE],
                V.[CAPACIDADE_PESSOAS],
                V.[TAMANHO_PORTA_MALA],
                V.[KM_INICIAL],
                V.[TIPO_COMBUSTIVEL],
                V.[ID_TIPO_VEICULO],
                V.[DISPONIBILIDADE_VEICULO],
                TV.[NOMETIPO],       
                TV.[VALOR_DIARIO_PDIARIO], 
                TV.[VALOR_KMRODADO_PDIARIO],
                TV.[VALOR_DIARIO_PCONTROLADO],                    
                TV.[LIMITE_PCONTROLADO],                                                           
                TV.[VALOR_KMRODAD_PCONTROLADO],        
                TV.[VALOR_DIARIO_PLIVRE]
            FROM
                [TBVEICULOS] AS V INNER JOIN
                [TBTIPOVEICULO] AS TV
            ON
                TV.ID = V.ID_TIPO_VEICULO
            WHERE 
                V.[ID] = @ID";



        private const string sqlExisteVeiculo =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBVEICULOS]
            WHERE 
                [ID] = @ID";

        private const string sqlQuantidadeAlugados =
            @"SELECT 
                *
            FROM
                [TBVEICULOS] AS V INNER JOIN
                [TBTIPOVEICULO] AS TV
            ON
                TV.ID = V.ID_TIPO_VEICULO
            WHERE 
                [DISPONIBILIDADE_VEICULO] = 0";

        private const string sqlQuantidadeDisponiveis =
            @"SELECT 
                *
            FROM
                [TBVEICULOS] AS V INNER JOIN
                [TBTIPOVEICULO] AS TV
            ON
                TV.ID = V.ID_TIPO_VEICULO
            WHERE 
                [DISPONIBILIDADE_VEICULO] = 1";

        private const string sqlVeiculoAlugado =
            @"SELECT 
                V.[ID],       
                V.[NOME],
                V.[NUMERO_PLACA],
                V.[NUMERO_CHASSI],             
                V.[FOTO],                    
                V.[COR],                                
                V.[MARCA],
                V.[ANO],
                V.[NUMERO_PORTAS],
                V.[CAPACIDADE_TANQUE],
                V.[CAPACIDADE_PESSOAS],
                V.[TAMANHO_PORTA_MALA],
                V.[KM_INICIAL],
                V.[TIPO_COMBUSTIVEL],
                V.[ID_TIPO_VEICULO],
                V.[DISPONIBILIDADE_VEICULO],
                TV.[NOMETIPO],       
                TV.[VALOR_DIARIO_PDIARIO], 
                TV.[VALOR_KMRODADO_PDIARIO],
                TV.[VALOR_DIARIO_PCONTROLADO],                    
                TV.[LIMITE_PCONTROLADO],                                                           
                TV.[VALOR_KMRODAD_PCONTROLADO],        
                TV.[VALOR_DIARIO_PLIVRE]
            FROM
                [TBVEICULOS] AS V INNER JOIN
                [TBTIPOVEICULO] AS TV
            ON
                TV.ID = V.ID_TIPO_VEICULO
            WHERE 
                [DISPONIBILIDADE_VEICULO] = 0";

        private const string sqlVeiculoDisponivel =
            @"SELECT 
                V.[ID],       
                V.[NOME],
                V.[NUMERO_PLACA],
                V.[NUMERO_CHASSI],             
                V.[FOTO],                    
                V.[COR],                                
                V.[MARCA],
                V.[ANO],
                V.[NUMERO_PORTAS],
                V.[CAPACIDADE_TANQUE],
                V.[CAPACIDADE_PESSOAS],
                V.[TAMANHO_PORTA_MALA],
                V.[KM_INICIAL],
                V.[TIPO_COMBUSTIVEL],
                V.[ID_TIPO_VEICULO],
                V.[DISPONIBILIDADE_VEICULO],
                TV.[NOMETIPO],       
                TV.[VALOR_DIARIO_PDIARIO], 
                TV.[VALOR_KMRODADO_PDIARIO],
                TV.[VALOR_DIARIO_PCONTROLADO],                    
                TV.[LIMITE_PCONTROLADO],                                                           
                TV.[VALOR_KMRODAD_PCONTROLADO],        
                TV.[VALOR_DIARIO_PLIVRE]
            FROM
                [TBVEICULOS] AS V INNER JOIN
                [TBTIPOVEICULO] AS TV
            ON
                TV.ID = V.ID_TIPO_VEICULO
            WHERE 
                [DISPONIBILIDADE_VEICULO] = 1";

        private const string sqlSelecionarVeiculoPesquisa =
           @"SELECT 
                V.[ID],       
                V.[NOME],
                V.[NUMERO_PLACA],
                V.[NUMERO_CHASSI],             
                V.[FOTO],                    
                V.[COR],                                
                V.[MARCA],
                V.[ANO],
                V.[NUMERO_PORTAS],
                V.[CAPACIDADE_TANQUE],
                V.[CAPACIDADE_PESSOAS],
                V.[TAMANHO_PORTA_MALA],
                V.[KM_INICIAL],
                V.[TIPO_COMBUSTIVEL],
                V.[ID_TIPO_VEICULO],
                V.[DISPONIBILIDADE_VEICULO],
                TV.[NOMETIPO],       
                TV.[VALOR_DIARIO_PDIARIO], 
                TV.[VALOR_KMRODADO_PDIARIO],
                TV.[VALOR_DIARIO_PCONTROLADO],                    
                TV.[LIMITE_PCONTROLADO],                                                           
                TV.[VALOR_KMRODAD_PCONTROLADO],        
                TV.[VALOR_DIARIO_PLIVRE]
            FROM
                [TBVEICULOS] AS V INNER JOIN
                [TBTIPOVEICULO] AS TV
            ON
                TV.ID = V.ID_TIPO_VEICULO
                    WHERE 
                        COLUNADEPESQUISA LIKE @SEGUNDAREF+'%'";

        private const string sqlMudarDisponibilidade =
           @"UPDATE TBVEICULOS
                    SET
                        [DISPONIBILIDADE_VEICULO] = @DISPONIBILIDADE_VEICULO";
        #endregion

        public void Editar(int id, Veiculo veiculo)
        {
            try
            {
                veiculo.Id = id;
                Db.Update(sqlEditarVeiculo, ObtemParametrosVeiculo(veiculo));
                Log.Logger.Aqui().Information("SUCESSO AO EDITAR VEÍCULO ID: {Id}  ", veiculo.Id );
            }

            catch(Exception ex)
            {

                 Log.Logger.Aqui().Error(ex , "ERRO AO EDITAR VEÍCULO ID: {Id}  ", veiculo.Id );

            }
        }

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirVeiculo, AdicionarParametro("ID", id));

                Log.Logger.Aqui().Information("SUCESSO AO REMOVER VEÍCULO ID: {Id}  ", id );

            }
            catch (Exception ex)
            {
                 Log.Logger.Aqui().Error(ex , "ERRO AO REMOVER VEÍCULO ID: {Id}  ", id );

                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteVeiculo, AdicionarParametro("ID", id));
        }

        public void Inserir(Veiculo veiculo)
        {
            try
            {
                veiculo.Id = Db.Insert(sqlInserirVeiculo, ObtemParametrosVeiculo(veiculo));
                Log.Logger.Aqui().Information("SUCESSO AO INSERIR VEÍCULO ID: {Id}  ", veiculo.Id );
            }

            catch(Exception ex)
            {
                 Log.Logger.Aqui().Error(ex , "ERRO AO INSERIR VEÍCULO ID: {Id}  ", veiculo.Id );

            }
        }

        public List<Veiculo> SelecionarPesquisa(string coluna, string pesquisa)
        {
            try
            {
                string sql = sqlSelecionarVeiculoPesquisa.Replace("COLUNADEPESQUISA", coluna);
                List<Veiculo> veiculos = Db.GetAll(sql, ConverterEmVeiculo, AdicionarParametro("@SEGUNDAREF", pesquisa));

                if (veiculos != null)
                    Log.Logger.Aqui().Debug("SUCESSO AO SELECIONAR VEÍCULO COM A PESQUISA: {Pesquisa}  ", pesquisa );
                else
                    Log.Logger.Aqui().Information("NÃO FOI POSSÍVEL SELECIONAR VEÍCULO COM A PESQUISA: {Pesquisa}  ", pesquisa );


                return veiculos;
            }

            catch(Exception ex) {

                 Log.Logger.Aqui().Error(ex , "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR VEÍCULO  " );

                return null;
            }
        }

        public void EditarDisponibilidade(Veiculo atual, Veiculo antigo)
        {
            try
            {
                atual.DisponibilidadeVeiculo = 0;
                antigo.DisponibilidadeVeiculo = 1;
                Db.Update(sqlEditarVeiculo, ObtemParametrosVeiculo(atual));
                Db.Update(sqlEditarVeiculo, ObtemParametrosVeiculo(antigo));
                Log.Logger.Aqui().Information("SUCESSO AO EDITAR DISPONIBILIDADE DO VEÍCULO ANTIGO ID: {Id} E DISPONIBILIDADE DO VEÍCULO ATUAL ID: {Id}  ",antigo.Id, atual.Id );

            }

            catch (Exception ex)
            {

                 Log.Logger.Aqui().Error(ex , "ERRO AO EDITAR DISPONIBILIDADE DO VEÍCULO ANTIGO ID: {Id} E DISPONIBILIDADE DO VEÍCULO ATUAL ID: {Id}  ", antigo.Id, atual.Id );

            }
        }

        public void DevolverVeiculo(Veiculo veiculo)
        {
            try
            {
                veiculo.DisponibilidadeVeiculo = 1;
                Db.Update(sqlMudarDisponibilidade, ObtemParametrosVeiculo(veiculo));
                Log.Logger.Aqui().Information("SUCESSO AO EDITAR DISPONILIDADE DO VEÍCULO ID: {Id}  ", veiculo.Id );

            }

            catch (Exception ex)
            {
                 Log.Logger.Aqui().Error(ex , "ERRO AO EDITAR DISPONIBILIDADE VEÍCULO ID: {Id}  ", veiculo.Id );

            }
        }

        public void LocarVeiculo(Veiculo veiculo)
        {
            try
            {
                veiculo.DisponibilidadeVeiculo = 0;
                Db.Update(sqlMudarDisponibilidade, ObtemParametrosVeiculo(veiculo));
                Log.Logger.Aqui().Information("SUCESSO AO EDITAR DISPONILIDADE DO VEÍCULO ID: {Id}  ", veiculo.Id );

            }

            catch (Exception ex)
            {
                 Log.Logger.Aqui().Error(ex , "ERRO AO EDITAR DISPONIBILIDADE VEÍCULO ID: {Id}  ", veiculo.Id );

            }
        }
        public void AtualizarQuilometragem(Veiculo veiculo)
        {
            try
            {
                Db.Update(sqlEditarVeiculo, ObtemParametrosVeiculo(veiculo));
                Log.Logger.Aqui().Information("SUCESSO AO EDITAR QUILOMETRAGEM DO VEÍCULO ID: {Id}  ", veiculo.Id );
            }

            catch(Exception ex)
            {
                 Log.Logger.Aqui().Error(ex , "ERRO AO EDITAR QUILOMETRAGEM DO VEÍCULO ID: {Id}  ", veiculo.Id );
            }
        }

        public Veiculo SelecionarPorId(int id)
        {
            try {
               
                Veiculo veiculo =  Db.Get(sqlSelecionarVeiculoPorId, ConverterEmVeiculo, AdicionarParametro("ID", id));

                if (veiculo != null)
                    Log.Logger.Aqui().Debug("SUCESSO AO SELECIONAR VEÍCULO ID: {Id}  ", veiculo.Id );
                else
                    Log.Logger.Aqui().Information("NÃO FOI POSSÍVEL SELECIONAR VEÍCULO ID: {Id}  ", veiculo.Id );

                return veiculo;
            }
            catch (Exception ex) {

                 Log.Logger.Aqui().Error(ex , "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR VEÍCULO ID: {Id}  ", id );

                return null;
            }
        }

        public List<Veiculo> SelecionarTodos()
        {
            try
            {
                List<Veiculo> veiculos =  Db.GetAll(sqlSelecionarTodosVeiculos, ConverterEmVeiculo);

                if(veiculos!=null)
                    Log.Logger.Aqui().Debug("SUCESSO AO SELECIONAR TODOS OS VEÍCULOS  " );

                else
                    Log.Logger.Aqui().Information("NÃO FOI POSSÍVEL SELECIONAR TODOS OS VEÍCULOS  " );

                return veiculos;
            }
            catch (Exception ex)
            {
                 Log.Logger.Aqui().Error(ex , "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODOS OS VEÍCULOS  " );

                return null;
            }
        }

        public List<Veiculo> SelecionarTodosAlugados()
        {
            try
            {
                List<Veiculo> veiculos = Db.GetAll(sqlVeiculoAlugado, ConverterEmVeiculo);

                if (veiculos != null)
                    Log.Logger.Aqui().Debug("SUCESSO AO SELECIONAR TODOS OS VEÍCULOS ALUGADOS  " );

                else
                    Log.Logger.Aqui().Information("NÃO FOI POSSÍVEL SELECIONAR TODOS OS VEÍCULOS ALUGADOS  " );

                return veiculos;
            }

            catch(Exception ex) {

                 Log.Logger.Aqui().Error(ex , "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODOS OS VEÍCULOS ALUGADOS  " );

                return null;
            }
        }

        public List<Veiculo> SelecionarTodosDisponiveis()
        {
            try
            {
                List<Veiculo> veiculos = Db.GetAll(sqlVeiculoDisponivel, ConverterEmVeiculo);

                if (veiculos != null)
                    Log.Logger.Aqui().Debug("SUCESSO AO SELECIONAR TODOS OS VEÍCULOS DISPONÍVEIS  " );

                else
                    Log.Logger.Aqui().Information("NÃO FOI POSSÍVEL SELECIONAR TODOS OS VEÍCULOS DISPONÍVEIS  " );

                return veiculos;
            }

            catch (Exception ex) {

                 Log.Logger.Aqui().Error(ex , "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODOS OS VEÍCULOS DISPONÍVEIS  " );

                return null;
            }
        }

        public int ReturnQuantidadeAlugados()
        {
            try
            {
                int alugados =   Db.GetAll(sqlQuantidadeAlugados, ConverterEmVeiculo).Count;

                if(alugados > 0)
                    Log.Logger.Aqui().Debug("SUCESSO AO RETORNAR QUANTIDADE DE VEÍCULOS ALUGADOS  " );

                else
                    Log.Logger.Aqui().Information("NÃO HÁ VEÍCULOS ALUGADOS  " );

                return alugados;
            }

            catch(Exception ex)
            {
                 Log.Logger.Aqui().Error(ex , "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA RETORNAR A QUANTIDADE DE VEÍCULOS ALUGADOS  " );

                return 0;
            }
        }

        public int ReturnQuantidadeDisponiveis()
        {
            try
            {
                int disponiveis = Db.GetAll(sqlQuantidadeDisponiveis, ConverterEmVeiculo).Count;

                if (disponiveis > 0)
                    Log.Logger.Aqui().Debug("SUCESSO AO RETORNAR QUANTIDADE DE VEÍCULOS DISPONÍVEIS  " );

                else
                    Log.Logger.Aqui().Information("NÃO HÁ VEÍCULOS DISPONÍVEIS  " );

                return disponiveis;
            }

            catch(Exception ex)
            {
                 Log.Logger.Aqui().Error(ex , "NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA RETORNAR A QUANTIDADE DE VEÍCULOS DISPONÍVEIS  " );

                return 0;
            }
        }

        private Veiculo ConverterEmVeiculo(IDataReader reader)
        {
            byte[] foto;
            var nome = Convert.ToString(reader["NOME"]);
            var numero_Placa = Convert.ToString(reader["NUMERO_PLACA"]);
            var numero_Chassi = Convert.ToString(reader["NUMERO_CHASSI"]);
            if (reader["FOTO"] != DBNull.Value)
                foto = (byte[])reader["FOTO"];
            else
                foto = null;
            var cor = Convert.ToString(reader["COR"]);
            var marca = Convert.ToString(reader["MARCA"]);
            var ano = Convert.ToInt32(reader["ANO"]);
            var numero_Portas = Convert.ToInt32(reader["NUMERO_PORTAS"]);
            var capacidade_Tanque = Convert.ToInt32(reader["CAPACIDADE_TANQUE"]);
            var capacidade_Pessoas = Convert.ToInt32(reader["CAPACIDADE_PESSOAS"]);
            var tamanhoPortaMalas = Convert.ToChar(reader["TAMANHO_PORTA_MALA"]);
            var km_Inicial = Convert.ToInt32(reader["KM_INICIAL"]);
            var tipo_Combustivel = Convert.ToString(reader["TIPO_COMBUSTIVEL"]);
            var disponibilidade_Veiculo = Convert.ToInt32(reader["DISPONIBILIDADE_VEICULO"]);

            var nomeTipo = Convert.ToString(reader["NOMETIPO"]);
            var valorDiarioPDiario = Convert.ToDecimal(reader["VALOR_DIARIO_PDIARIO"]);
            var valorKmRodadoPDiario = Convert.ToDecimal(reader["VALOR_KMRODADO_PDIARIO"]);
            var valorDiarioPControlado = Convert.ToDecimal(reader["VALOR_DIARIO_PCONTROLADO"]);
            var limitePControlado = Convert.ToDecimal(reader["LIMITE_PCONTROLADO"]);
            var valorKmRodadoPControlado = Convert.ToDecimal(reader["VALOR_KMRODAD_PCONTROLADO"]);
            var valorDiarioPLivre = Convert.ToDecimal(reader["VALOR_DIARIO_PLIVRE"]);

            GrupoVeiculo grupoVeiculo = null;

            if (reader["ID_TIPO_VEICULO"] != DBNull.Value)
            {
                grupoVeiculo = new GrupoVeiculo(nomeTipo, valorDiarioPDiario, valorKmRodadoPDiario, valorDiarioPControlado,
                                                                limitePControlado, valorKmRodadoPControlado, valorDiarioPLivre);
                grupoVeiculo.Id = Convert.ToInt32(reader["ID_TIPO_VEICULO"]);
            }

            Veiculo veiculo = new Veiculo(nome, numero_Placa, numero_Chassi, foto, cor, marca, ano, numero_Portas,
                capacidade_Tanque, capacidade_Pessoas, tamanhoPortaMalas, km_Inicial, tipo_Combustivel, disponibilidade_Veiculo, grupoVeiculo);
            veiculo.Id = Convert.ToInt32(reader["ID"]);

            return veiculo;
        }

        private Dictionary<string, object> ObtemParametrosVeiculo(Veiculo veiculo)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", veiculo.Id);
            parametros.Add("NOME", veiculo.Nome);
            parametros.Add("NUMERO_PLACA", veiculo.NumeroPlaca);
            parametros.Add("NUMERO_CHASSI", veiculo.NumeroChassi);
            parametros.Add("FOTO", veiculo.Foto);
            parametros.Add("COR", veiculo.Cor);
            parametros.Add("MARCA", veiculo.Marca);
            parametros.Add("ANO", veiculo.Ano);
            parametros.Add("NUMERO_PORTAS", veiculo.NumeroPortas);
            parametros.Add("CAPACIDADE_TANQUE", veiculo.CapacidadeTanque);
            parametros.Add("CAPACIDADE_PESSOAS", veiculo.CapacidadePessoas);
            parametros.Add("TAMANHO_PORTA_MALA", veiculo.TamanhoPortaMalas);
            parametros.Add("KM_INICIAL", veiculo.KmInicial);
            parametros.Add("TIPO_COMBUSTIVEL", veiculo.TipoCombustivel);
            parametros.Add("DISPONIBILIDADE_VEICULO", veiculo.DisponibilidadeVeiculo);
            parametros.Add("ID_TIPO_VEICULO", veiculo.GrupoVeiculo.Id);

            return parametros;
        }

        private Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }

    }
}
