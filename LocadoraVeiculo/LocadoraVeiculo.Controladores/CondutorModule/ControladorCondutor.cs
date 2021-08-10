using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.CondutorModule;
using LocadoraVeiculo.Controladores.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Controladores.CondutorModule
{
    public class ControladorCondutor : Controlador<Condutor>
    {
        private const string sqlInserirCondutor =
            @"INSERT INTO TBCONDUTOR 
	                (
		                [NOME], 
		                [ENDERECO], 
		                [TELEFONE],
                        [CPF], 
		                [RG],
                        [CNH],
                        [DATA_VALIDADE],
                        [ID_CLIENTE]
	                ) 
	                VALUES
	                (
		                @NOME, 
		                @ENDERECO, 
		                @TELEFONE,
                        @CPF, 
		                @RG,
                        @CNH,
                        @DATA_VALIDADE,
                        @ID_CLIENTE
	                )";

        private const string sqlEditarCondutor =
            @"UPDATE TBCONDUTOR
                    SET
		                [NOME] = @NOME, 
		                [ENDERECO] = @ENDERECO, 
		                [TELEFONE] = @TELEFONE,
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
                        TBCONDUTOR
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarCondutorPorId =
            @"SELECT
                        [ID],
		                [NOME], 
		                [ENDERECO], 
		                [TELEFONE],
                        [CPF], 
		                [RG],
                        [CNH],
                        [DATA_VALIDADE],
                        [ID_CLIENTE]
	                FROM
                        TBCLIENTE
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosCondutores =
            @"SELECT
                        [ID],
		                [NOME], 
		                [ENDERECO], 
		                [TELEFONE],
                        [CPF], 
		                [RG],
                        [CNH],
                        [DATA_VALIDADE],
                        [ID_CLIENTE]
	                FROM
                        TBCONDUTOR";

        private const string sqlExisteCondutor =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCONDUTOR]
            WHERE 
                [ID] = @ID";
        public override string Editar(int id, Condutor registro)
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

        public override string InserirNovo(Condutor registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirCondutor, ObtemParametrosCondutor(registro));
            }

            return resultadoValidacao;
        }

        public override Condutor SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarCondutorPorId, ConverterEmCondutor, AdicionarParametro("ID", id));
        }

        public override List<Condutor> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosCondutores, ConverterEmCondutor);
        }
        private Dictionary<string, object> ObtemParametrosCondutor(Condutor condutor)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", condutor.Id);
            parametros.Add("NOME", condutor.Nome);
            parametros.Add("ENDERECO", condutor.Endereco);
            parametros.Add("TELEFONE", condutor.Telefone);
            parametros.Add("CPF_CNPJ", condutor.Cpf);
            parametros.Add("TIPO", condutor.Rg);
            parametros.Add("TIPO", condutor.Cnh);
            parametros.Add("ID_CLIENTE", condutor.Cliente.Id);

            return parametros;
        }
        private Condutor ConverterEmCondutor(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME"]);
            string endereco = Convert.ToString(reader["ENDERECO"]);
            string telefone = Convert.ToString(reader["TELEFONE"]);
            string cpf = Convert.ToString(reader["CPF"]);
            string rg = Convert.ToString(reader["RG"]);
            string cnh = Convert.ToString(reader["CNH"]);
            DateTime dataValidade = Convert.ToDateTime(reader["DATA_VALIDADE"]);

            var nomeC = Convert.ToString(reader["NOME"]);
            var enderecoC = Convert.ToString(reader["ENDERECO"]);
            var telefoneC = Convert.ToString(reader["TELEFONE"]);
            var cpf_cnpj = Convert.ToString(reader["CPF_CNPJ"]);
            var tipo = Convert.ToString(reader["TIPO"]);

            Cliente cliente = new Cliente(nomeC, enderecoC, telefoneC, cpf_cnpj, tipo);
            cliente.Id = Convert.ToInt32(reader["ID_CLIENTE"]);

            Condutor condutor = new Condutor(nome, endereco, telefone, cpf, rg, cnh, dataValidade, cliente);

            condutor.Id = id;

            return condutor;
        }
    }
}
