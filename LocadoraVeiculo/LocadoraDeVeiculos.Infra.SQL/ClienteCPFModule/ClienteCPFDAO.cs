﻿using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Infra.Shared;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraDeVeiculos.Infra.SQL.ClienteCPFModule
{
    public class ClienteCPFDAO : IClienteCPFRepository
    {
        #region Queries
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
                        [ID_CLIENTE],
                        [EMAILC]
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
                        @ID_CLIENTE,
                        @EMAILC
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
                        [ID_CLIENTE] = @ID_CLIENTE,
                        [EMAILC] = @EMAILC
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
                        CD.[EMAILC],
                        CT.[NOME],
                        CT.[ENDERECO],
                        CT.[TELEFONE],
                        CT.[CNPJ],
                        CT.[EMAIL]
	                FROM
                        TBCLIENTECPF AS CD LEFT JOIN
                        TBCLIENTECNPJ AS CT
                    ON
                        CT.ID = CD.ID_CLIENTE
                    WHERE 
                        CD.ID = @ID";

        private const string sqlSelecionarCondutorPorIdEmpresa =
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
                        CD.[EMAILC],
                        CT.[NOME],
                        CT.[ENDERECO],
                        CT.[TELEFONE],
                        CT.[CNPJ],
                        CT.[EMAIL]
	                FROM
                        TBCLIENTECPF AS CD LEFT JOIN
                        TBCLIENTECNPJ AS CT
                    ON
                        CT.ID = CD.ID_CLIENTE
                    WHERE 
                        CD.ID_CLIENTE = @ID";

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
                        CD.[EMAILC],
                        CT.[NOME],
                        CT.[ENDERECO],
                        CT.[TELEFONE],
                        CT.[CNPJ],
                        CT.[EMAIL]
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
        private const string sqlExisteCPF =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCLIENTECPF]
            WHERE 
                [CPF] = @CPF";
        #endregion

        private Logger logger;
        public ClienteCPFDAO(Logger logger)
        {
            this.logger = logger;
        }
        public void Inserir(ClienteCPF cliente)
        {
            try
            {
                cliente.Id = Db.Insert(sqlInserirCondutor, ObtemParametrosCondutor(cliente));

                logger.Information("SUCESSO AO INSERIR CLIENTE CPF ID: {Id} | DATA: {DataEHora}", cliente.Id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO INSERIR CLIENTE CPF ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", cliente.Id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);
            }
        }

        public void Editar(int id, ClienteCPF cliente)
        {
            try
            {
                cliente.Id = id;
                Db.Update(sqlEditarCondutor, ObtemParametrosCondutor(cliente));

                logger.Information("SUCESSO AO EDITAR CLIENTE CPF ID: {Id} | DATA: {DataEHora}", cliente.Id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO EDITAR CLIENTE CPF ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", cliente.Id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirCondutor, AdicionarParametro("ID", id));

                logger.Information("SUCESSO AO REMOVER CLIENTE CPF ID: {Id} | DATA: {DataEHora}", id, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("ERRO AO REMOVER CLIENTE CPF ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteCondutor, AdicionarParametro("ID", id));
        }
        public bool ExisteCPF(string cpf)
        {
            try
            {
                bool existe = Db.Exists(sqlExisteCPF, AdicionarParametro("CPF", cpf));

                if (existe)
                    logger.Information("O CPF {Cpf} JÁ EXISTE NO SISTEMA | DATA: {DataEHora}", cpf, DateTime.Now.ToString());
                else
                    logger.Debug("O CPF {Cpf} NÃO EXISTE NO SISTEMA| DATA: {DataEHora}", cpf, DateTime.Now.ToString());

                return existe;
            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR O CPF {Cpf} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", cpf, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return true;
            }
        }

        public List<ClienteCPF> SelecionarPesquisa(string coluna, string pesquisa)
        {
            throw new NotImplementedException();
        }

        public ClienteCPF SelecionarPorId(int id)
        {
            try
            {
                ClienteCPF clienteCPF = Db.Get(sqlSelecionarCondutorPorId, ConverterEmCondutor, AdicionarParametro("ID", id));

                if (clienteCPF != null)
                    logger.Debug("SUCESSO AO SELECIONAR CLIENTE CPF ID: {Id} | DATA: {DataEHora}", clienteCPF.Id, DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR CLIENTE CPF ID: {Id} | DATA: {DataEHora}", clienteCPF.Id, DateTime.Now.ToString());

                return clienteCPF;
            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR CLIENTE CPF ID: {Id} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return null;
            }
        }

        public List<ClienteCPF> SelecionarTodos()
        {
            try
            {
                List<ClienteCPF> clientesCPF = Db.GetAll(sqlSelecionarTodosCondutores, ConverterEmCondutor);

                if (clientesCPF != null)
                    logger.Debug("SUCESSO AO SELECIONAR TODOS OS CLIENTES CPF | DATA: {DataEHora}", DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODOS OS CLIENTES CPF | DATA: {DataEHora}", DateTime.Now.ToString());

                return clientesCPF;
            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODOS OS CLIENTES CPF | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return null;
            }
        }

        public List<ClienteCPF> SelecionarPorIdEmpresa(int id)
        {
            try
            {
                List<ClienteCPF> clientesCPF = Db.GetAll(sqlSelecionarCondutorPorIdEmpresa, ConverterEmCondutor, AdicionarParametro("ID", id));

                if (clientesCPF != null)
                    logger.Debug("SUCESSO AO SELECIONAR TODOS OS CLIENTES CPF VINCULADOS AO ID {ID} | DATA: {DataEHora}", id, DateTime.Now.ToString());
                else
                    logger.Information("NÃO FOI POSSÍVEL SELECIONAR TODOS OS CLIENTES CPF VINCULADOS AO ID {ID} | DATA: {DataEHora}", id, DateTime.Now.ToString());

                return clientesCPF;
            }
            catch (Exception ex)
            {
                logger.Error("NÃO FOI POSSÍVEL SE COMUNICAR COM O BANCO DE DADOS PARA SELECIONAR TODOS OS CLIENTES CPF VINCULADOS AO ID {ID} | DATA: {DataEHora} | FEATURE:{Feature} | CAMADA: {Camada} | SQL: {Query}", id, DateTime.Now.ToString(), this.ToString(), "Repository", ex.Message);

                return null;
            }
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
            parametros.Add("EMAILC", condutor.Email);

            return parametros;
        }

        private ClienteCPF ConverterEmCondutor(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nomeC = Convert.ToString(reader["NOMEC"]);
            string enderecoC = Convert.ToString(reader["ENDERECOC"]);
            string telefoneC = Convert.ToString(reader["TELEFONEC"]);
            string cpf = Convert.ToString(reader["CPF"]);
            string rg = Convert.ToString(reader["RG"]);
            string cnh = Convert.ToString(reader["CNH"]);
            DateTime dataValidade = Convert.ToDateTime(reader["DATA_VALIDADE"]);
            string emailC = Convert.ToString(reader["EMAILC"]);

            var nome = Convert.ToString(reader["NOME"]);
            var endereco = Convert.ToString(reader["ENDERECO"]);
            var telefone = Convert.ToString(reader["TELEFONE"]);
            var cpf_cnpj = Convert.ToString(reader["CNPJ"]);
            var email = Convert.ToString(reader["EMAIL"]);

            ClienteCNPJ cliente = null;
            if (reader["ID_CLIENTE"] != DBNull.Value)
            {
                cliente = new ClienteCNPJ(nome, endereco, telefone, cpf_cnpj, email);
                cliente.Id = Convert.ToInt32(reader["ID_CLIENTE"]);
            }

            ClienteCPF condutor = new ClienteCPF(nomeC, telefoneC, enderecoC, cpf, rg, cnh, dataValidade, emailC, cliente);

            condutor.Id = id;

            return condutor;
        }

        private Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}
