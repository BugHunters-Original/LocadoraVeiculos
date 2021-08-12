using LocadoraVeiculo.CombustivelModule;
using LocadoraVeiculo.Controladores.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Controladores.CombustivelModule
{
    public class ControladorCombustivel
    {
        #region Queries
        private const string sqlEditarCombustivel =
            @" UPDATE [TBTIPOCOMBUSTIVEL]
                SET 
                    [PRECO_GASOLINA] = @PRECO_GASOLINA,       
                    [PRECO_DIESEL] = @PRECO_DIESEL, 
                    [PRECO_ALCOOL] = @PRECO_ALCOOL
                WHERE [ID] = @ID";

        private const string sqlSelecionarCombustivelPorId =
           @"SELECT
                        [ID],
		                [PRECO_GASOLINA], 
		                [PRECO_DIESEL], 
		                [PRECO_ALCOOL]
	                FROM
                       TBTIPOCOMBUSTIVEL
                    WHERE 
                        ID = @ID";
        #endregion

        public string Editar(int id, Combustivel registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarCombustivel, ObtemParametrosCombustivel(registro));
            }
            return resultadoValidacao;
        }

        private Dictionary<string, object> ObtemParametrosCombustivel(Combustivel combustivel)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", combustivel.Id);
            parametros.Add("PRECO_GASOLINA", combustivel.preco_Gasolina);
            parametros.Add("PRECO_DIESEL", combustivel.preco_Diesel);
            parametros.Add("PRECO_ALCOOL", combustivel.preco_Alcool);
            return parametros;
        }

        public Combustivel SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarCombustivelPorId, ConverterEmCombustivel, AdicionarParametro("ID", id));
        }

        private Combustivel ConverterEmCombustivel(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            decimal precoGasolina = Convert.ToDecimal(reader["PRECO_GASOLINA"]);
            decimal precoAlcool = Convert.ToDecimal(reader["PRECO_ALCOOL"]);
            decimal precoDiesel = Convert.ToDecimal(reader["PRECO_DIESEL"]);

            Combustivel combustivel = new Combustivel(precoGasolina, precoDiesel, precoAlcool);

            combustivel.Id = id;

            return combustivel;
        }

        protected Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}
