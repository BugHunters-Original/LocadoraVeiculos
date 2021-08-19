using LocadoraVeiculo.Shared;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculo.GrupoVeiculoModule
{
    public class GrupoVeiculo : EntidadeBase, IEquatable<GrupoVeiculo>
    {
        public string NomeTipo { get; set; }
        public decimal? ValorDiarioPDiario { get; set; }
        public decimal? ValorKmRodadoPDiario { get; set; }
        public decimal? ValorDiarioPControlado { get; set; }
        public decimal? LimitePControlado { get; set; }
        public decimal? ValorKmRodadoPControlado { get; set; }
        public decimal? ValorDiarioPLivre { get; set; }

        public GrupoVeiculo(string nomeTipo, decimal? valorDiarioPDiario, decimal? valorKmRodadoPDiario,
            decimal? valorDiarioPControlado, decimal? limitePControlado, decimal? valorKmRodadoPControlado,
            decimal? valorDiarioPLivre)
        {
            NomeTipo = nomeTipo;
            ValorDiarioPDiario = valorDiarioPDiario;
            ValorKmRodadoPDiario = valorKmRodadoPDiario;
            ValorDiarioPControlado = valorDiarioPControlado;
            LimitePControlado = limitePControlado;
            ValorKmRodadoPControlado = valorKmRodadoPControlado;
            ValorDiarioPLivre = valorDiarioPLivre;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(NomeTipo))
                resultadoValidacao = "O campo Categoria é obrigatório";

            if (ValorDiarioPDiario == null || ValorDiarioPDiario <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Valor Diária no Plano Diário não pode ser nulo ou menor que zero";

            if (ValorKmRodadoPDiario == null || ValorKmRodadoPDiario <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Valor Km Rodado no Plano Diário não pode ser nulo ou menor que zero";

            if (ValorDiarioPControlado == null || ValorDiarioPControlado <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Valor Diária no Plano Controlado não pode ser nulo ou menor que zero";

            if (LimitePControlado <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Limite KM no Plano Controlado não pode ser nulo ou menor que zero";

            if (ValorKmRodadoPControlado == null || ValorKmRodadoPControlado <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Valor Km Rodado no Plano Controlado não pode ser nulo ou menor que zero";

            if (ValorDiarioPLivre == null || ValorDiarioPLivre <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Valor Diária no Plano Controlado não pode ser nulo ou menor que zero";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override string ToString()
        {
            return NomeTipo;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GrupoVeiculo);
        }

        public bool Equals(GrupoVeiculo other)
        {
            return other != null
                && Id == other.Id
                && NomeTipo == other.NomeTipo
                && ValorDiarioPDiario == other.ValorDiarioPDiario
                && ValorKmRodadoPDiario == other.ValorKmRodadoPDiario
                && ValorDiarioPControlado == other.ValorDiarioPControlado
                && ValorKmRodadoPControlado == other.ValorKmRodadoPControlado
                && LimitePControlado == other.LimitePControlado
                && ValorDiarioPLivre == other.ValorDiarioPLivre;
        }

        public override int GetHashCode()
        {
            int hashCode = -1108870241;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NomeTipo);
            hashCode = hashCode * -1521134295 + ValorDiarioPDiario.GetHashCode();
            hashCode = hashCode * -1521134295 + ValorKmRodadoPDiario.GetHashCode();
            hashCode = hashCode * -1521134295 + ValorDiarioPControlado.GetHashCode();
            hashCode = hashCode * -1521134295 + LimitePControlado.GetHashCode();
            hashCode = hashCode * -1521134295 + ValorKmRodadoPControlado.GetHashCode();
            hashCode = hashCode * -1521134295 + ValorDiarioPLivre.GetHashCode();
            return hashCode;
        }
    }
}
