using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Dominio.VeiculoModule
{
    public class Veiculo : EntidadeBase, IEquatable<Veiculo>
    {
        public string Nome { get; set; }
        public string NumeroPlaca { get; set; }
        public string NumeroChassi { get; set; }
        public byte[] Foto { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
        public int? Ano { get; set; }
        public int? NumeroPortas { get; set; }
        public int? CapacidadeTanque { get; set; }
        public int? CapacidadePessoas { get; set; }
        public char TamanhoPortaMalas { get; set; }
        public int? KmInicial { get; set; }
        public string TipoCombustivel { get; set; }
        public int DisponibilidadeVeiculo { get; set; }
        public GrupoVeiculo GrupoVeiculo { get; set; }
        public virtual int IdGrupoVeiculo { get; set; }
        
        public ICollection<Locacao> Locacoes { get; set; }


        public Veiculo(string nome, string numero_Placa, string numero_Chassi, byte[] foto, string cor,
            string marca, int? ano, int? numero_Portas, int? capacidade_Tanque, int? capacidade_Pessoas, char tamanhoPortaMalas, int? km_Inicial,
            string tipo_Combustivel, int disponibilidade_Veiculo, GrupoVeiculo grupoVeiculo)
        {
            this.Nome = nome;
            this.NumeroPlaca = numero_Placa;
            this.NumeroChassi = numero_Chassi;
            this.Foto = foto;
            this.Cor = cor;
            this.Marca = marca;
            this.Ano = ano;
            this.NumeroPortas = numero_Portas;
            this.CapacidadeTanque = capacidade_Tanque;
            this.CapacidadePessoas = capacidade_Pessoas;
            this.TamanhoPortaMalas = tamanhoPortaMalas;
            this.KmInicial = km_Inicial;
            this.TipoCombustivel = tipo_Combustivel;
            this.DisponibilidadeVeiculo = disponibilidade_Veiculo;
            this.GrupoVeiculo = grupoVeiculo;
            Locacoes = new HashSet<Locacao>();

        }

        public Veiculo()
        {

        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (Foto.Length == 0)
                resultadoValidacao = "O campo Foto é obrigatório";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao = "O campo Nome é obrigatório";

            if (string.IsNullOrEmpty(NumeroPlaca))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Placa é obrigatório";

            if (!string.IsNullOrEmpty(NumeroPlaca) && NumeroPlaca.Length != 7)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Placa possui 7 dígitos";

            if (TamanhoPortaMalas != 'M' && TamanhoPortaMalas != 'P' && TamanhoPortaMalas != 'G')
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Tamanho Porta-Malas deve ser P, M ou G";

            if (string.IsNullOrEmpty(NumeroChassi))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Chassi é obrigatório";

            if (!string.IsNullOrEmpty(NumeroChassi) && NumeroChassi.Length != 17)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Chassi possui 17 dígitos";

            if (string.IsNullOrEmpty(Cor))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Cor é obrigatório";

            if (string.IsNullOrEmpty(Marca))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Marca é obrigatório";

            if (string.IsNullOrEmpty(TipoCombustivel))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Combustível é obrigatório";

            if (Ano == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Ano é obrigatório";

            if (NumeroPortas == null || NumeroPortas <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Nº de Portas é obrigatório";

            if (CapacidadeTanque == null || CapacidadeTanque <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Capacidade do Tanque é obrigatório";

            if (CapacidadePessoas == null || CapacidadePessoas <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Capacidade de Pessoas é obrigatório";

            if (KmInicial == null || KmInicial <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Quilometragem Inicial obrigatório";

            if (GrupoVeiculo == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo tipo é obrigatório";

            if (Convert.ToInt32(Ano) > DateTime.Now.Year || Convert.ToInt32(Ano) < 1900 && Ano != null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Ano não pode ser maior que o ano atual ou muito antigo";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override string ToString()
        {
            return Nome;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Veiculo);
        }

        public bool Equals(Veiculo other)
        {
            return other != null &&
               Id == other.Id &&
               Nome == other.Nome &&
               NumeroPlaca == other.NumeroPlaca &&
               NumeroChassi == other.NumeroChassi &&
               Cor == other.Cor &&
               Marca == other.Marca &&
               Ano == other.Ano &&
               NumeroPortas == other.NumeroPortas &&
               CapacidadeTanque == other.CapacidadeTanque &&
               TamanhoPortaMalas == other.TamanhoPortaMalas &&
               KmInicial == other.KmInicial &&
               TipoCombustivel == other.TipoCombustivel &&
               DisponibilidadeVeiculo == other.DisponibilidadeVeiculo &&
               EqualityComparer<GrupoVeiculo>.Default.Equals(GrupoVeiculo, other.GrupoVeiculo) &&
               Foto.SequenceEqual(other.Foto);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Nome);
            hash.Add(NumeroPlaca);
            hash.Add(NumeroChassi);
            hash.Add(Foto);
            hash.Add(Cor);
            hash.Add(Marca);
            hash.Add(Ano);
            hash.Add(NumeroPortas);
            hash.Add(CapacidadeTanque);
            hash.Add(CapacidadePessoas);
            hash.Add(TamanhoPortaMalas);
            hash.Add(KmInicial);
            hash.Add(TipoCombustivel);
            hash.Add(DisponibilidadeVeiculo);
            hash.Add(GrupoVeiculo);
            return hash.ToHashCode();
        }
    }
}
