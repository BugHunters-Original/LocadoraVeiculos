﻿using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.Controladores.Shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculo.Controladores.CondutorModule
{
    public class ControladorClienteCPF : Controlador<ClienteCPF>
    {
        private const string sqlInserirCondutor =
            @"INSERT INTO TBCLIENTECPF
	                (
		                [NOMEC], 
		                [ENDERECOC], 
		                [TELEFONEC],
                        [CPF], 
		                [RG],
                        [CNH],
                        [DATA_VALIDADE],
                        [ID_CLIENTE]
	                ) 
	                VALUES
	                (
		                @NOMEC, 
		                @ENDERECOC, 
		                @TELEFONEC,
                        @CPF, 
		                @RG,
                        @CNH,
                        @DATA_VALIDADE,
                        @ID_CLIENTE
	                )";

        private const string sqlEditarCondutor =
            @"UPDATE TBCLIENTECPF
                    SET
		                [NOMEC] = @NOMEC, 
		                [ENDERECOC] = @ENDERECOC, 
		                [TELEFONEC] = @TELEFONEC,
                        [CPF] = @CPF, 
		                [RG] = @RG,
                        [CNH] = @CNH,
                        [DATA_VALIDADE] = @DATA_VALIDADE,
                        [ID_CLIENTE] = @ID_CLIENTE
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirCondutor =
            @"DELETE 
	                FROM
                        TBCLIENTECPF
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarCondutorPorId =
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
                        CT.ID = CD.ID_CLIENTE
                    WHERE 
                        CD.ID = @ID";

        private const string sqlSelecionarTodosCondutores =
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

        private const string sqlExisteCondutor =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCLIENTECPF]
            WHERE 
                [ID] = @ID";
        public override string Editar(int id, ClienteCPF registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarCondutor, ObtemParametrosCondutor(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirCondutor, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteCondutor, AdicionarParametro("ID", id));
        }

        public override string InserirNovo(ClienteCPF registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirCondutor, ObtemParametrosCondutor(registro));
            }

            return resultadoValidacao;
        }

        public override ClienteCPF SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarCondutorPorId, ConverterEmCondutor, AdicionarParametro("ID", id));
        }

        public override List<ClienteCPF> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosCondutores, ConverterEmCondutor);
        }
        private Dictionary<string, object> ObtemParametrosCondutor(ClienteCPF condutor)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", condutor.Id);
            parametros.Add("NOMEC", condutor.Nome);
            parametros.Add("ENDERECOC", condutor.Endereco);
            parametros.Add("TELEFONEC", condutor.Telefone);
            parametros.Add("CPF", condutor.Cpf);
            parametros.Add("RG", condutor.Rg);
            parametros.Add("CNH", condutor.Cnh);
            parametros.Add("DATA_VALIDADE", condutor.DataValidade);
            parametros.Add("ID_CLIENTE", condutor.Cliente?.Id);

            return parametros;
        }
        private ClienteCPF ConverterEmCondutor(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOMEC"]);
            string endereco = Convert.ToString(reader["ENDERECOC"]);
            string telefone = Convert.ToString(reader["TELEFONEC"]);
            string cpf = Convert.ToString(reader["CPF"]);
            string rg = Convert.ToString(reader["RG"]);
            string cnh = Convert.ToString(reader["CNH"]);
            DateTime dataValidade = Convert.ToDateTime(reader["DATA_VALIDADE"]);

            var nomeC = Convert.ToString(reader["NOME"]);
            var enderecoC = Convert.ToString(reader["ENDERECO"]);
            var telefoneC = Convert.ToString(reader["TELEFONE"]);
            var cpf_cnpj = Convert.ToString(reader["CNPJ"]);

            ClienteCNPJ cliente = null;
            if (reader["ID_CLIENTE"] != DBNull.Value)
            {
                cliente = new ClienteCNPJ(nomeC, enderecoC, telefoneC, cpf_cnpj);
                cliente.Id = Convert.ToInt32(reader["ID_CLIENTE"]);
            }

            ClienteCPF condutor = new ClienteCPF(nome, telefone, endereco, cpf, rg, cnh, dataValidade, cliente);

            condutor.Id = id;

            return condutor;
        }
    }
}