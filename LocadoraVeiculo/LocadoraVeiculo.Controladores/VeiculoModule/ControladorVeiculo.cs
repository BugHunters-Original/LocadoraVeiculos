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
                TV.[NOME]      
            FROM
                [TBVEICULOS] AS V INNER JOIN
                [TBTIPOVEICULO] AS TV
            ON
                TV.ID = V.ID";

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
                TV.[NOME]      
            FROM
                [TBVEICULOS] AS V INNER JOIN
                [TBTIPOVEICULO] AS TV
            ON
                TV.ID = V.ID
            WHERE 
                V.[ID] = @ID";

        private const string sqlExisteVeiculo =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBVEICULOS]
            WHERE 
                [ID] = @ID";
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

        private Veiculo ConverterEmVeiculo(IDataReader reader)
        {
            var nome = Convert.ToString(reader["NOME"]);
            var numero_Placa = Convert.ToString(reader["NUMERO_PLACA"]);
            var numero_Chassi = Convert.ToString(reader["NUMERO_CHASSI"]);
            //var foto = Convert.ToString(reader["FOTO"]);
            var cor = Convert.ToString(reader["COR"]);
            var marca = Convert.ToString(reader["MARCA"]);
            var ano = Convert.ToInt32(reader["ANO"]);
            var numero_Portas = Convert.ToInt32(reader["NUMERO_PORTAS"]);
            var capacidade_Tanque = Convert.ToInt32(reader["CAPACIDADE_TANQUE"]);
            var tamanhoPortaMalas = Convert.ToChar(reader["TAMANHO_PORTA_MALA"]);
            var km_Inicial = Convert.ToInt32(reader["KM_INICIAL"]);
            var tipo_Combustivel = Convert.ToString(reader["TIPO_COMBUSTIVEL"]);
            var disponibilidade_Veiculo = Convert.ToBoolean(reader["DISPONIBILIDADE"]);

            var categoriaVeiculo = Convert.ToString(reader["NOME"]);
            var valor_Diario_PDiario = Convert.ToDecimal(reader["VALOR_DIARIO_PDIARIO"]);
            var preco_KMDiario = Convert.ToDecimal(reader["PRECO_KMDIARIO"]);
            var valor_Diario_PControlado = Convert.ToDecimal(reader["VALOR_DIARIO_PCONTROLADO"]);
            var kmDia__KMControlado = Convert.ToInt32(reader["KMDIA__KMCONTROLADO"]);
            var preco_KMLivre = Convert.ToDecimal(reader["PRECO_KMLIVRE"]);

            GrupoVeiculo grupoVeiculo = null;

            if (reader["ID_TIPO_VEICULO"] != DBNull.Value)
            {
                grupoVeiculo = new GrupoVeiculo(categoriaVeiculo, valor_Diario_PDiario, preco_KMDiario, valor_Diario_PControlado, kmDia__KMControlado, preco_KMLivre);
                grupoVeiculo.Id = Convert.ToInt32(reader["ID_TIPO_VEICULO"]);
            }

            Veiculo veiculo = new Veiculo(nome, numero_Placa, numero_Chassi, cor, marca, ano, numero_Portas,
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
            //parametros.Add("FOTO", veiculo.foto);
            parametros.Add("COR", veiculo.cor);
            parametros.Add("MARCA", veiculo.marca);
            parametros.Add("ANO", veiculo.ano);
            parametros.Add("NUMERO_PORTAS", veiculo.numero_Portas);
            parametros.Add("CAPACIDADE_TANQUE", veiculo.capacidade_Tanque);
            parametros.Add("TAMANHO_PORTA_MALA", veiculo.tamanhoPortaMalas);
            parametros.Add("KM_INICIAL", veiculo.km_Inicial);
            parametros.Add("TIPO_COMBUSTIVEL", veiculo.tipo_Combustivel);
            parametros.Add("DISPONIBILIDADE", veiculo.disponibilidade_Veiculo);
            parametros.Add("ID_TIPO_VEICULO", veiculo.grupoVeiculo.Id);

            return parametros;
        }
    }
}
