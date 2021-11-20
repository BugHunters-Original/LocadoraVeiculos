using LocadoraDeVeiculos.Dominio.Shared;
using System;

namespace LocadoraDeVeiculos.Dominio.FuncionarioModule
{
    public class Funcionario : EntidadeBase, IEquatable<Funcionario>
    {
        public string Nome { get; set; }
        public decimal? Salario { get; set; }
        public DateTime DataEntrada { get; set; }
        public string CpfFuncionario { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public Funcionario(string nome, decimal? salario, DateTime dataEntrada, string cpf_funcionario, string usuario, string senha)
        {
            this.Nome = nome;
            this.Salario = salario;
            this.DataEntrada = dataEntrada;
            this.CpfFuncionario = cpf_funcionario;
            this.Usuario = usuario;
            this.Senha = senha;
        }

        public Funcionario()
        {

        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (Senha.Length < 7)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Senha possui menos de sete dígitos";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Digite o Nome do funcionário";

            if (DataEntrada == DateTime.MinValue)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Data é obrigatório";

            if (DateTime.Now.Year - DataEntrada.Year > 70)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Data não aceita datas muito antigas";

            if (DataEntrada > DateTime.Now)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Data não aceita datas futuras";

            if (Salario <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Salário é obrigatório e maior que 0";

            if (Salario == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Salário está inválido";

            if (CpfFuncionario.Length != 14)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo CPF está inválido";

            if (string.IsNullOrEmpty(Usuario))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Usuário está inválido";

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
                && CpfFuncionario == other.CpfFuncionario
                && Salario == other.Salario
                && DataEntrada == other.DataEntrada
                && Usuario == other.Usuario
                && Senha == other.Senha;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Salario, DataEntrada, CpfFuncionario, Usuario, Senha);
        }
    }
}
