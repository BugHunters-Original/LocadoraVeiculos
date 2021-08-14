using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.Controladores.ClienteModule;
using LocadoraVeiculo.Controladores.CondutorModule;
using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.GrupoVeiculoModule;
using LocadoraVeiculo.LocacaoModule;
using LocadoraVeiculo.VeiculoModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculo.Controladores.LocacaoModule
{
    public class ControladorLocacao : Controlador<LocacaoVeiculo>
    {
        private const string sqlInserirLocacao =
       @"INSERT INTO TBLOCACAO
	                (
		                [ID_CONDUTOR], 
		                [ID_CLIENTELOCADOR], 
		                [ID_VEICULO],
                        [DATA_SAIDA], 
		                [DATA_RETORNOESPERADO],
                        [PLANO],
                        [TIPOCLIENTE]
	                ) 
	                VALUES
	                (
		                @ID_CONDUTOR, 
		                @ENDERECOC, 
		                @TELEFONEC,
                        @CPF, 
		                @RG,
                        @CNH,
                        @DATA_VALIDADE,
                        @ID_CLIENTE
	                )";

        private const string sqlEditarLocacao =
            @"UPDATE TBLOCACAO
                    SET
	                (
		                [ID_CONDUTOR] = @ID_CONDUTOR, 
		                [ID_CLIENTELOCADOR] = @ID_CLIENTELOCADOR, 
		                [ID_VEICULO] = @ID_VEICULO,
                        [DATA_SAIDA] = @DATA_SAIDA, 
		                [DATA_RETORNOESPERADO] = @DATA_RETORNOESPERADO,
                        [PLANO] = @PLANO,
                        [TIPOCLIENTE] = @TÍPOCLIENTE
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
                        CD.[ID],
		                CD.[NOMEC], 
		                CD.[ENDERECOC], 
		                CD.[TELEFONEC],
                        CD.[CPF], 
		                CD.[RG],
                        CD.[CNH],
                        CD.[DATA_VALIDADE],
                        CD.[ID_CLIENTE],
                        CT.[NOME],
                        CT.[ENDERECO],
                        CT.[TELEFONE],
                        CT.[CNPJ]
	                FROM
                        TBLOCACAO AS LC LEFT JOIN
                        TBCLIENTECNPJ AS CT
                    ON
                        CT.ID = CD.ID_CLIENTE
                    WHERE 
                        CD.ID = @ID";

        private const string sqlSelecionarTodasLocacoes =
            @"SELECT
                        CD.[ID],
		                CD.[NOMEC], 
		                CD.[ENDERECOC], 
		                CD.[TELEFONEC],
                        CD.[CPF], 
		                CD.[RG],
                        CD.[CNH],
                        CD.[DATA_VALIDADE],
                        CD.[ID_CLIENTE],
                        CT.[NOME],
                        CT.[ENDERECO],
                        CT.[TELEFONE],
                        CT.[CNPJ]
	                FROM
                        TBCLIENTECPF AS CD LEFT JOIN
                        TBCLIENTECNPJ AS CT
                    ON
                        CT.ID = CD.ID_CLIENTE";

        private const string sqlExisteLocacao =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBLOCACAO]
            WHERE 
                [ID] = @ID";
        public override string Editar(int id, LocacaoVeiculo registro)
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

        public override string InserirNovo(LocacaoVeiculo registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirLocacao, ObtemParametrosLocacao(registro));
            }

            return resultadoValidacao;
        }

        public override LocacaoVeiculo SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarLocacaoPorId, ConverterEmLocacao, AdicionarParametro("ID", id));
        }

        public override List<LocacaoVeiculo> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodasLocacoes, ConverterEmLocacao);
        }
        private Dictionary<string, object> ObtemParametrosLocacao(LocacaoVeiculo locacao)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", locacao.Id);
            parametros.Add("TIPOCLIENTE", locacao.TipoCliente);
            parametros.Add("ID_CONDUTOR", locacao.Condutor.Id);
            parametros.Add("ID_CLIENTELOCADOR", locacao.Cliente.Id);
            parametros.Add("ID_VEICULO", locacao.Veiculo.Id);
            parametros.Add("DATA_SAIDA", locacao.DataSaida);
            parametros.Add("DATA_RETORNOESPERADO", locacao.DataRetorno);
            parametros.Add("PLANO", locacao.TipoLocacao);

            return parametros;
        }
        private LocacaoVeiculo ConverterEmLocacao(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            int tipoCliente = Convert.ToInt32(reader["TIPOCLIENTE"]);
            int idCondutor = Convert.ToInt32(reader["ID_CONDUTOR"]);
            int idClienteLocador = Convert.ToInt32(reader["ID_CLIENTELOCADOR"]);
            int idVeiculo = Convert.ToInt32(reader["ID_VEICULO"]);
            DateTime dataSaida = Convert.ToDateTime(reader["DATA_SAIDA"]);
            DateTime dataRetorno = Convert.ToDateTime(reader["DATA_RETORNOESPERADO"]);
            int plano = Convert.ToInt32(reader["PLANO"]);

            ControladorClienteCPF controladorCPF = new ControladorClienteCPF();
            ControladorClienteCNPJ controladorCNPJ = new ControladorClienteCNPJ();
            ControladorVeiculo controladorVeiculo = new ControladorVeiculo();

            ClienteCPF condutor = controladorCPF.SelecionarPorId(idCondutor);
            Veiculo veiculo = controladorVeiculo.SelecionarPorId(idVeiculo);

            Cliente clienteLocador;

            if (tipoCliente == 1)
                clienteLocador = controladorCNPJ.SelecionarPorId(idClienteLocador);
            else
                clienteLocador = controladorCPF.SelecionarPorId(idClienteLocador);


            LocacaoVeiculo locacao = new LocacaoVeiculo(clienteLocador, veiculo, condutor,
                                                    dataSaida, dataRetorno, plano, tipoCliente);

            locacao.Id = id;

            return locacao;
        }
    }
}
