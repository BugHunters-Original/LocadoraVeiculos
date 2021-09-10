using LocadoraVeiculo.Shared;
using System;
using System.Collections.Generic;

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
        public string CpfFuncionario { get => cpf_funcionario; set => cpf_funcionario = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Senha { get => senha; set => senha = value; }

        public Funcionario(string nome, decimal? salario, DateTime dataEntrada, string cpf_funcionario, string usuario, string senha)
        {
            this.Nome = nome;
            this.Salario = salario;
            this.DataEntrada = dataEntrada;
            this.CpfFuncionario = cpf_funcionario;
            this.Usuario = usuario;
            this.Senha = senha;
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

            if(CpfFuncionario.Length != 14)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo CPF está inválido";

            if(string.IsNullOrEmpty(Usuario))
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
            int hashCode = 445399706;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nome);
            hashCode = hashCode * -1521134295 + salario.GetHashCode();
            hashCode = hashCode * -1521134295 + dataEntrada.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cpf_funcionario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(usuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(senha);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + Salario.GetHashCode();
            hashCode = hashCode * -1521134295 + DataEntrada.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CpfFuncionario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Usuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Senha);
            return hashCode;
        }
    }
}
