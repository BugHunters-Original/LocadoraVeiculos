using LocadoraVeiculo.Shared;
using System;
namespace LocadoraVeiculo.CombustivelModule
{
    public class Combustivel : EntidadeBase
    {
        public double? PrecoGasolina { get; set; }
        public double? PrecoDiesel { get; set; }
        public double? PrecoAlcool { get; set; }

        public Combustivel(double? preco_Gasolina, double? preco_Diesel, double? preco_Alcool)
        {
            this.PrecoAlcool = preco_Alcool;
            this.PrecoDiesel = preco_Diesel;
            this.PrecoGasolina = preco_Gasolina;
        }
        public override string Validar()
        {
            string resultadoValidacao = "";

            if (PrecoGasolina == null || PrecoGasolina <= 0)
                resultadoValidacao = "O campo preço Gasolina é obrigatório ou deve ser maior que 0";

            if (PrecoAlcool == null || PrecoAlcool <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo preço Alcool é obrigatório ou deve ser maior que 0";

            if (PrecoDiesel == null || PrecoDiesel <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo preço Diesel é obrigatório ou deve ser maior que 0";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
