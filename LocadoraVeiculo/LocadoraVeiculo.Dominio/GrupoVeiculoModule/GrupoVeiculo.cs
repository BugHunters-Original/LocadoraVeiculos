using LocadoraVeiculo.Shared;
namespace LocadoraVeiculo.GrupoVeiculoModule
{
    public class GrupoVeiculo : EntidadeBase
    {
        public string categoriaVeiculo { get; set; }
        public decimal? valor_Diario_PDiario { get; set; }
        public decimal? preco_KMDiario { get; set; }
        public decimal? valor_Diario_PControlado { get; set; }
        public int? kmDia__KMControlado { get; set; }
        public decimal? preco_KMLivre { get; set; }

        public GrupoVeiculo(string categoriaVeiculo, decimal? valor_Diario_PDiario, decimal? preco_KMDiario, decimal? valor_Diario_PControlado, int? kmDia__KMControlado, decimal? preco_KMLivre)
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

            if (valor_Diario_PDiario == null || valor_Diario_PDiario < 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo valor diário não pode ser nulo ou menor que zero";

            if (preco_KMDiario == null || preco_KMDiario < 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo preço não pode ser nulo ou menor que zero";

            if (valor_Diario_PControlado == null || valor_Diario_PControlado < 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo valor não pode ser nulo ou menor que zero";

            if (kmDia__KMControlado == null || kmDia__KMControlado < 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo km/dia não pode ser nulo ou menor que zero";

            if (preco_KMLivre == null || preco_KMLivre < 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo preço não pode ser nulo ou menor que zero";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override string ToString()
        {
            return categoriaVeiculo;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GrupoVeiculo);
        }

        public bool Equals(GrupoVeiculo other)
        {
            return other != null
                && Id == other.Id
                && categoriaVeiculo == other.categoriaVeiculo
                && valor_Diario_PDiario == other.valor_Diario_PDiario
                && preco_KMDiario == other.preco_KMDiario
                && valor_Diario_PControlado == other.valor_Diario_PControlado
                && kmDia__KMControlado == other.kmDia__KMControlado
                && preco_KMLivre == other.preco_KMLivre;
        }
    }
}
