using LocadoraVeiculo.Shared;
using System;

namespace LocadoraVeiculo.FuncionarioModule
{
    public class Funcionario : EntidadeBase, IEquatable<Funcionario>
    {

        private string nome;
        private decimal? salario;
        private DateTime dataEntrada;
        private string cpf_funcionario;
        private string usuario;
        private string senha;

        public string Nome { get => nome; set => nome = value; }
        public decimal? Salario { get => salario; set => salario = value; }
        public DateTime DataEntrada { get => dataEntrada; set => dataEntrada = value; }
        public string Cpf_funcionario { get => cpf_funcionario; set => cpf_funcionario = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Senha { get => senha; set => senha = value; }

        public Funcionario(string nome, decimal? salario, DateTime dataEntrada, string cpf_funcionario, string usuario, string senha)
        {
            this.Nome = nome;
            this.Salario = salario;
            this.DataEntrada = dataEntrada;
            this.Cpf_funcionario = cpf_funcionario;
            this.Usuario = usuario;
            this.Senha = senha;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";
            if (Cpf_funcionario.Length < 10)
                resultadoValidacao = "O campo CPF está inválido";

            if (Senha.Length < 7)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo senha possui menos de sete dígitos";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Digite o nome do funcionário";

            if (DataEntrada == DateTime.MinValue)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Data é obrigatório";

            if (Salario <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Salário é obrigatório e maior que 0";


            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Funcionario);
        }

        public bool Equals(Funcionario other)
        {
            return other != null
                && Id == other.Id
                && Nome == other.Nome
                && Cpf_funcionario == other.Cpf_funcionario
                && Salario == other.Salario
                && DataEntrada == other.DataEntrada
                && Usuario == other.Usuario
                && Senha == other.Senha;
        }


    }
}
