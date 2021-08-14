using LocadoraVeiculo.Shared;
using System;
namespace LocadoraVeiculo.CombustivelModule
{
    public class Combustivel : EntidadeBase
    {
        public decimal? preco_Gasolina { get; set; }
        public decimal? preco_Diesel { get; set; }
        public decimal? preco_Alcool { get; set; }

        public Combustivel(decimal? preco_Gasolina, decimal? preco_Diesel, decimal? preco_Alcool)
        {
            this.preco_Alcool = preco_Alcool;
            this.preco_Diesel = preco_Diesel;
            this.preco_Gasolina = preco_Gasolina;
        }
        public override string Validar()
        {
            string resultadoValidacao = "";

            if (preco_Gasolina == null || preco_Gasolina <= 0)
                resultadoValidacao = "O campo preço Gasolina é obrigatório ou deve ser maior que 0";

            if (preco_Alcool == null || preco_Alcool <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo preço Alcool é obrigatório ou deve ser maior que 0";

            if (preco_Diesel == null || preco_Diesel <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo preço Diesel é obrigatório ou deve ser maior que 0";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
