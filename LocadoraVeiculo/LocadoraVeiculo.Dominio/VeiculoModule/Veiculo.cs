using LocadoraVeiculo.GrupoVeiculoModule;
using LocadoraVeiculo.Shared;
using System;
namespace LocadoraVeiculo.VeiculoModule
{
    public class Veiculo : EntidadeBase
    {
        public string nome { get; set; }
        public string numero_Placa { get; set; }
        public string numero_Chassi { get; set; }
        public byte[] foto { get; set; }
        public string cor { get; set; }
        public string marca { get; set; }
        public int? ano { get; set; }
        public int numero_Portas { get; set; }
        public int capacidade_Tanque { get; set; }
        public char tamanhoPortaMalas { get; set; }
        public int km_Inicial { get; set; }
        public string tipo_Combustivel { get; set; }
        public int disponibilidade_Veiculo { get; set; }
        public GrupoVeiculo grupoVeiculo { get; set; }

        public Veiculo(string nome, string numero_Placa, string numero_Chassi, string cor,
            string marca, int? ano, int numero_Portas, int capacidade_Tanque, char tamanhoPortaMalas, int km_Inicial,
            string tipo_Combustivel, int disponibilidade_Veiculo, GrupoVeiculo grupoVeiculo)
        {
            this.nome = nome;
            this.numero_Placa = numero_Placa;
            this.numero_Chassi = numero_Chassi;
            this.cor = cor;
            this.marca = marca;
            this.ano = ano;
            this.numero_Portas = numero_Portas;
            this.capacidade_Tanque = capacidade_Tanque;
            this.tamanhoPortaMalas = tamanhoPortaMalas;
            this.km_Inicial = km_Inicial;
            this.tipo_Combustivel = tipo_Combustivel;
            this.disponibilidade_Veiculo = disponibilidade_Veiculo;
            this.grupoVeiculo = grupoVeiculo;
        }

        public Veiculo(string nome, string numero_Placa, string numero_Chassi, byte[] foto, string cor,
            string marca, int? ano, int numero_Portas, int capacidade_Tanque, char tamanhoPortaMalas, int km_Inicial,
            string tipo_Combustivel, int disponibilidade_Veiculo, GrupoVeiculo grupoVeiculo)
        {
            this.nome = nome;
            this.numero_Placa = numero_Placa;
            this.numero_Chassi = numero_Chassi;
            this.foto = foto;
            this.cor = cor;
            this.marca = marca;
            this.ano = ano;
            this.numero_Portas = numero_Portas;
            this.capacidade_Tanque = capacidade_Tanque;
            this.tamanhoPortaMalas = tamanhoPortaMalas;
            this.km_Inicial = km_Inicial;
            this.tipo_Combustivel = tipo_Combustivel;
            this.disponibilidade_Veiculo = disponibilidade_Veiculo;
            this.grupoVeiculo = grupoVeiculo;

        }



        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nome))
                resultadoValidacao = "O campo nome é obrigatório";

            if (string.IsNullOrEmpty(numero_Placa))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo placa é obrigatório";

            if (string.IsNullOrEmpty(numero_Chassi))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo chassi é obrigatório";

            if (string.IsNullOrEmpty(cor))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo cor é obrigatório";

            if (string.IsNullOrEmpty(marca))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo marca é obrigatório";

            if (string.IsNullOrEmpty(tipo_Combustivel))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo combústivel é obrigatório";

            if (ano == null || ano < 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo ano é obrigatório";

            if (Convert.ToInt32(ano) > DateTime.Now.Year || Convert.ToInt32(ano) < 1900)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo ano não pode ser maior que o ano atual ou muito antigo";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public bool ValidarDisponibilidade()
        {
            if (disponibilidade_Veiculo == 1)
                return true;
            else
                return false;
        }
    }
}
