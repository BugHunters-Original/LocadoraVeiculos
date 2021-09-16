using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.ClienteModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion
        public void Inserir(ClienteCPF cliente)
        {
            cliente.Id = Db.Insert(sqlInserirCondutor, ObtemParametrosCondutor(cliente));
        }

        public void Editar(int id, ClienteCPF cliente)
        {
            cliente.Id = id;
            Db.Update(sqlEditarCondutor, ObtemParametrosCondutor(cliente));
        }

        public bool Excluir(int id)
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

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteCondutor, AdicionarParametro("ID", id));
        }

        public List<ClienteCPF> SelecionarPesquisa(string coluna, string pesquisa)
        {
            throw new NotImplementedException();
        }

        public ClienteCPF SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarCondutorPorId, ConverterEmCondutor, AdicionarParametro("ID", id));
        }

        public List<ClienteCPF> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosCondutores, ConverterEmCondutor);
        }

        public List<ClienteCPF> SelecionarPorIdEmpresa(int id)
        {
            return Db.GetAll(sqlSelecionarCondutorPorIdEmpresa, ConverterEmCondutor, AdicionarParametro("ID", id));
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
