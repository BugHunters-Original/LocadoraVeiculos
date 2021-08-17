﻿using LocadoraVeiculo.GrupoVeiculoModule;
using LocadoraVeiculo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public int? numero_Portas { get; set; }
        public int? capacidade_Tanque { get; set; }
        public char tamanhoPortaMalas { get; set; }
        public int? km_Inicial { get; set; }
        public string tipo_Combustivel { get; set; }
        public int disponibilidade_Veiculo { get; set; }
        public GrupoVeiculo grupoVeiculo { get; set; }

        public Veiculo(string nome, string numero_Placa, string numero_Chassi, byte[] foto, string cor,
            string marca, int? ano, int? numero_Portas, int? capacidade_Tanque, char tamanhoPortaMalas, int? km_Inicial,
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

            if (foto.Length == 0)
                resultadoValidacao = "O campo Foto é obrigatório";

            if (string.IsNullOrEmpty(nome))
                resultadoValidacao = "O campo Nome é obrigatório";

            if (string.IsNullOrEmpty(numero_Placa))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Placa é obrigatório";

            if (char.IsWhiteSpace(tamanhoPortaMalas))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Tamanho Porta-Malas é obrigatório";

            if (string.IsNullOrEmpty(numero_Chassi))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Chassi é obrigatório";

            if (string.IsNullOrEmpty(cor))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Cor é obrigatório";

            if (string.IsNullOrEmpty(marca))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Marca é obrigatório";

            if (string.IsNullOrEmpty(tipo_Combustivel))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Combústivel é obrigatório";

            if (ano == null || ano < 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Ano é obrigatório";

            if (numero_Portas == null || numero_Portas <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Nº de Portas é obrigatório";

            if (capacidade_Tanque == null || capacidade_Tanque <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Capacidade do Tanque é obrigatório";

            if (km_Inicial == null || km_Inicial <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Quilometragem Inicial obrigatório";

            if (Convert.ToInt32(ano) > DateTime.Now.Year || Convert.ToInt32(ano) < 1900)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Ano não pode ser maior que o ano atual ou muito antigo";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override string ToString()
        {
            return nome;
        }
        public bool ValidarDisponibilidade()
        {
            if (disponibilidade_Veiculo == 1)
                return true;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            return obj is Veiculo veiculo &&
                   Id == veiculo.Id &&
                   nome == veiculo.nome &&
                   numero_Placa == veiculo.numero_Placa &&
                   numero_Chassi == veiculo.numero_Chassi &&
                   EqualityComparer<byte[]>.Default.Equals(foto, veiculo.foto) &&
                   cor == veiculo.cor &&
                   marca == veiculo.marca &&
                   ano == veiculo.ano &&
                   numero_Portas == veiculo.numero_Portas &&
                   capacidade_Tanque == veiculo.capacidade_Tanque &&
                   tamanhoPortaMalas == veiculo.tamanhoPortaMalas &&
                   km_Inicial == veiculo.km_Inicial &&
                   tipo_Combustivel == veiculo.tipo_Combustivel &&
                   disponibilidade_Veiculo == veiculo.disponibilidade_Veiculo &&
                   EqualityComparer<GrupoVeiculo>.Default.Equals(grupoVeiculo, veiculo.grupoVeiculo) &&
                   foto.SequenceEqual(veiculo.foto);
        }
    }
}
