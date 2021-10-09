﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    public partial class certinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBClientesBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBClientesBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBFuncionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Salario = table.Column<double>(type: "FLOAT", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "DATE", nullable: false),
                    CpfFuncionario = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Usuario = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFuncionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBParceiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBParceiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBTiposVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipo = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    ValorDiarioPDiario = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    ValorKmRodadoPDiario = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    ValorDiarioPControlado = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    LimitePControlado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorKmRodadoPControlado = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    ValorDiarioPLivre = table.Column<decimal>(type: "DECIMAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTiposVeiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBClientesCNPJ",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Cnpj = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBClientesCNPJ", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBClientesCNPJ_TBClientesBase_Id",
                        column: x => x.Id,
                        principalTable: "TBClientesBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBDescontos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Codigo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Valor = table.Column<double>(type: "FLOAT", nullable: false),
                    ValorMinimo = table.Column<double>(type: "FLOAT", nullable: false),
                    Tipo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Validade = table.Column<DateTime>(type: "DATE", nullable: false),
                    IdParceiro = table.Column<int>(type: "int", nullable: false),
                    Meio = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Usos = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBDescontos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBDescontos_TBParceiros_IdParceiro",
                        column: x => x.IdParceiro,
                        principalTable: "TBParceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    NumeroPlaca = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    NumeroChassi = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    Foto = table.Column<byte[]>(type: "image", nullable: false),
                    Cor = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    Marca = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: true),
                    NumeroPortas = table.Column<int>(type: "INT", nullable: false),
                    CapacidadeTanque = table.Column<int>(type: "INT", nullable: false),
                    CapacidadePessoas = table.Column<int>(type: "INT", nullable: false),
                    TamanhoPortaMalas = table.Column<string>(type: "CHAR(1)", nullable: false),
                    KmInicial = table.Column<int>(type: "INT", nullable: false),
                    TipoCombustivel = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    DisponibilidadeVeiculo = table.Column<int>(type: "INT", nullable: false),
                    IdGrupoVeiculo = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVeiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBVeiculos_TBTiposVeiculo_IdGrupoVeiculo",
                        column: x => x.IdGrupoVeiculo,
                        principalTable: "TBTiposVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBClientesCPF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(14)", nullable: false),
                    Rg = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    Cnh = table.Column<string>(type: "VARCHAR(12)", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBClientesCPF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBClientesCPF_TBClientesBase_Id",
                        column: x => x.Id,
                        principalTable: "TBClientesBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBClientesCPF_TBClientesCNPJ_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "TBClientesCNPJ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    IdVeiculo = table.Column<int>(type: "int", nullable: false),
                    VeiculoId = table.Column<int>(type: "int", nullable: true),
                    IdDesconto = table.Column<int>(type: "int", nullable: false),
                    DescontoId = table.Column<int>(type: "int", nullable: true),
                    IdCondutor = table.Column<int>(type: "int", nullable: false),
                    CondutorId = table.Column<int>(type: "int", nullable: true),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRetorno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoLocacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusLocacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoCliente = table.Column<int>(type: "int", nullable: false),
                    Dias = table.Column<int>(type: "int", nullable: false),
                    PrecoServicos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrecoCombustivel = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrecoPlano = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrecoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locacoes_TBClientesBase_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBClientesBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locacoes_TBClientesCPF_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "TBClientesCPF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locacoes_TBDescontos_DescontoId",
                        column: x => x.DescontoId,
                        principalTable: "TBDescontos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locacoes_TBVeiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TBVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Preco = table.Column<double>(type: "FLOAT", nullable: false),
                    TipoCalculo = table.Column<int>(type: "INT", nullable: false),
                    LocacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBServicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBServicos_Locacoes_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "Locacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBTaxasDaLocacao",
                columns: table => new
                {
                    IdLocacao = table.Column<int>(type: "int", nullable: false),
                    IdTaxa = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTaxasDaLocacao", x => new { x.IdLocacao, x.IdTaxa });
                    table.ForeignKey(
                        name: "FK_TBTaxasDaLocacao_Locacoes_IdLocacao",
                        column: x => x.IdLocacao,
                        principalTable: "Locacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBTaxasDaLocacao_TBServicos_IdTaxa",
                        column: x => x.IdTaxa,
                        principalTable: "TBServicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_ClienteId",
                table: "Locacoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_CondutorId",
                table: "Locacoes",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_DescontoId",
                table: "Locacoes",
                column: "DescontoId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_VeiculoId",
                table: "Locacoes",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBClientesCPF_IdCliente",
                table: "TBClientesCPF",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TBDescontos_IdParceiro",
                table: "TBDescontos",
                column: "IdParceiro");

            migrationBuilder.CreateIndex(
                name: "IX_TBServicos_LocacaoId",
                table: "TBServicos",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBTaxasDaLocacao_IdTaxa",
                table: "TBTaxasDaLocacao",
                column: "IdTaxa");

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculos_IdGrupoVeiculo",
                table: "TBVeiculos",
                column: "IdGrupoVeiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBFuncionarios");

            migrationBuilder.DropTable(
                name: "TBTaxasDaLocacao");

            migrationBuilder.DropTable(
                name: "TBServicos");

            migrationBuilder.DropTable(
                name: "Locacoes");

            migrationBuilder.DropTable(
                name: "TBClientesCPF");

            migrationBuilder.DropTable(
                name: "TBDescontos");

            migrationBuilder.DropTable(
                name: "TBVeiculos");

            migrationBuilder.DropTable(
                name: "TBClientesCNPJ");

            migrationBuilder.DropTable(
                name: "TBParceiros");

            migrationBuilder.DropTable(
                name: "TBTiposVeiculo");

            migrationBuilder.DropTable(
                name: "TBClientesBase");
        }
    }
}
