using LocadoraVeiculo.Shared;
namespace LocadoraVeiculo.GrupoVeiculoModule
{
    public class GrupoVeiculo : EntidadeBase
    {
        public string categoriaVeiculo { get; set; }
        public float valor_Diario_PDiario  { get; set; }
        public float preco_KMDiario { get; set; }
        public float valor_Diario_PControlado { get; set; }
        public float kmDia__KMControlado { get; set; }
        public float preco_KMLivre { get; set; }

        public GrupoVeiculo(string categoriaVeiculo, float valor_Diario_PDiario, float preco_KMDiario, float valor_Diario_PControlado, float kmDia__KMControlado, float preco_KMLivre)
        {
            this.categoriaVeiculo = categoriaVeiculo;
            this.valor_Diario_PDiario = valor_Diario_PDiario;
            this.preco_KMDiario = preco_KMDiario;
            this.valor_Diario_PControlado = valor_Diario_PControlado;
            this.kmDia__KMControlado = kmDia__KMControlado;
            this.preco_KMLivre = preco_KMLivre;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(categoriaVeiculo))
                resultadoValidacao = "O campo categoria é obrigatório";

            if (float.IsNaN(valor_Diario_PDiario))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo valor diário aceita apenas números";

            if (float.IsNaN(preco_KMDiario))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo preço aceita apenas números";

            if (float.IsNaN(valor_Diario_PControlado))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo valor aceita apenas números";

            if (float.IsNaN(kmDia__KMControlado))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo km/dia aceita apenas números";

            if (float.IsNaN(preco_KMLivre))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo preço aceita apenas números";

            if (float.(preco_KMLivre))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo preço aceita apenas números";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override string ToString()
        {
            return categoriaVeiculo;
        }
    }
}
