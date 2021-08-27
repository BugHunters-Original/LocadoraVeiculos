using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.DescontoModule;
using LocadoraVeiculo.ParceiroModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Controladores.DescontoModule
{
    public class ControladorDesconto : Controlador<Desconto>
    {
        #region Queries
        private const string sqlInserirDesconto =
            @"INSERT INTO [TBDESCONTO]
                (
                    [CODIGO],       
                    [VALOR], 
                    [TIPO],
                    [VALIDADE],                    
                    [ID_PARCEIRO],                                                           
                    [MEIO] 
                )
            VALUES
                (
                    @CODIGO,
                    @VALOR,
                    @TIPO,
                    @VALIDADE,
                    @ID_PARCEIRO,
                    @MEIO
                )";

        private const string sqlEditarDesconto =
            @" UPDATE [TBDESCONTO]
                SET 
                    [CODIGO] = @CODIGO, 
                    [VALOR] = @VALOR, 
                    [TIPO] = @TIPO,
                    [VALIDADE] = @VALIDADE, 
                    [ID_PARCEIRO] = @ID_PARCEIRO,
                    [MEIO] = @MEIO

                WHERE [ID] = @ID";

        private const string sqlExcluirDesconto =
            @"DELETE FROM [TBDESCONTO] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarTodosDescontos =
            @"SELECT 
                [ID],       
                    [CODIGO],       
                    [VALOR], 
                    [TIPO],
                    [VALIDADE],                    
                    [ID_PARCEIRO],                                                           
                    [MEIO]
            FROM
                [TBDESCONTO]";

        private const string sqlSelecionarDescontoPorId =
            @"SELECT 
                [ID],       
                    [CODIGO],       
                    [VALOR], 
                    [TIPO],
                    [VALIDADE],                    
                    [ID_PARCEIRO],                                                           
                    [MEIO]
            FROM
                [TBDESCONTO]
            WHERE 
                [ID] = @ID";

        private const string sqlExisteDesconto =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBDESCONTO]
            WHERE 
                [ID] = @ID";
        #endregion

        public override string InserirNovo(Desconto registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirDesconto, ObtemParametrosDesconto(registro));
            }
            return resultadoValidacao;
        }

        public override string Editar(int id, Desconto registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarDesconto, ObtemParametrosDesconto(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirDesconto, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteDesconto, AdicionarParametro("ID", id));
        }

        public override Desconto SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarDescontoPorId, ConverterEmDesconto, AdicionarParametro("ID", id));
        }

        public override List<Desconto> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosDescontos, ConverterEmDesconto);
        }

        private Desconto ConverterEmDesconto(IDataReader reader)
        {
            var codigo = Convert.ToString(reader["CODIGO"]);
            var valor = Convert.ToDecimal(reader["VALOR"]);
            var tipo = Convert.ToString(reader["TIPO"]);
            var validade = Convert.ToDateTime(reader["VALIDADE"]);
            var meio = Convert.ToString(reader["MEIO"]);

            var nome = Convert.ToString(reader["NOME_PARCEIRO"]);

            ParceiroDesconto parceiroDesconto = null;

            if (reader["ID_PARCEIRO"] != DBNull.Value)
            {
                parceiroDesconto = new ParceiroDesconto(nome);
                parceiroDesconto.Id = Convert.ToInt32(reader["ID_PARCEIRO"]);
            }

            Desconto desconto = new Desconto(codigo, valor, tipo, validade, parceiroDesconto, meio);

            desconto.Id = Convert.ToInt32(reader["ID"]);

            return desconto;
        }

        private Dictionary<string, object> ObtemParametrosDesconto(Desconto desconto)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", desconto.Id);
            parametros.Add("CODIGO", desconto.Codigo);
            parametros.Add("VALOR", desconto.Valor);
            parametros.Add("TIPO", desconto.Tipo);
            parametros.Add("VALIDADE", desconto.Validade);
            parametros.Add("ID_PARCEIRO", desconto.Parceiro.Id);
            parametros.Add("MEIO", desconto.Meio);

            return parametros;
        }
    }
}
