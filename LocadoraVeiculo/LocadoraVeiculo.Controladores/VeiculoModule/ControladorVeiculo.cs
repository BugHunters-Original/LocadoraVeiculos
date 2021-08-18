using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.GrupoVeiculoModule;
using LocadoraVeiculo.VeiculoModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculo.Controladores.VeiculoModule
{
    public class ControladorVeiculo : Controlador<Veiculo>
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
                [TBVEICULOS]
           WHERE 
                [DISPONIBILIDADE_VEICULO] = 1";

        private const string sqlQuantidadeDisponiveis =
            @"SELECT 
                *
            FROM 
                [TBVEICULOS]
            WHERE 
                [DISPONIBILIDADE_VEICULO] = 0";

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
        #endregion

        public override string InserirNovo(Veiculo registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirVeiculo, ObtemParametrosVeiculo(registro));
            }

            return resultadoValidacao;
        }

        public override string Editar(int id, Veiculo registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarVeiculo, ObtemParametrosVeiculo(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirVeiculo, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteVeiculo, AdicionarParametro("ID", id));
        }

        public override Veiculo SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarVeiculoPorId, ConverterEmVeiculo, AdicionarParametro("ID", id));
        }

        public override List<Veiculo> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosVeiculos, ConverterEmVeiculo);
        }

        public List<Veiculo> SelecionarTodosAlugados()
        {
            return Db.GetAll(sqlVeiculoAlugado, ConverterEmVeiculo);
        }

        public List<Veiculo> SelecionarTodosDisponiveis()
        {
            return Db.GetAll(sqlVeiculoDisponivel, ConverterEmVeiculo);
        }

        public int ReturnQuantidadeAlugados()
        {
            return Db.GetAll(sqlQuantidadeAlugados, ConverterEmVeiculo).Count;
        }

        public int ReturnQuantidadeDisponiveis()
        {
            return Db.GetAll(sqlQuantidadeDisponiveis, ConverterEmVeiculo).Count;
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
                capacidade_Tanque, tamanhoPortaMalas, km_Inicial, tipo_Combustivel, disponibilidade_Veiculo, grupoVeiculo);
            veiculo.Id = Convert.ToInt32(reader["ID"]);

            return veiculo;
        }

        private Dictionary<string, object> ObtemParametrosVeiculo(Veiculo veiculo)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", veiculo.Id);
            parametros.Add("NOME", veiculo.nome);
            parametros.Add("NUMERO_PLACA", veiculo.numero_Placa);
            parametros.Add("NUMERO_CHASSI", veiculo.numero_Chassi);
            parametros.Add("FOTO", veiculo.foto);
            parametros.Add("COR", veiculo.cor);
            parametros.Add("MARCA", veiculo.marca);
            parametros.Add("ANO", veiculo.ano);
            parametros.Add("NUMERO_PORTAS", veiculo.numero_Portas);
            parametros.Add("CAPACIDADE_TANQUE", veiculo.capacidade_Tanque);
            parametros.Add("TAMANHO_PORTA_MALA", veiculo.tamanhoPortaMalas);
            parametros.Add("KM_INICIAL", veiculo.km_Inicial);
            parametros.Add("TIPO_COMBUSTIVEL", veiculo.tipo_Combustivel);
            parametros.Add("DISPONIBILIDADE_VEICULO", veiculo.disponibilidade_Veiculo);
            parametros.Add("ID_TIPO_VEICULO", veiculo.grupoVeiculo.Id);

            return parametros;
        }
    }
}
