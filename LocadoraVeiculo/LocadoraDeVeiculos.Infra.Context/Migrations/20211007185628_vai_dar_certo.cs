using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Context.Migrations
{
    public partial class vai_dar_certo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdCliente = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteBase_ClienteBase_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClienteBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CpfFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GruposVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorDiarioPDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorKmRodadoPDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorDiarioPControlado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LimitePControlado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorKmRodadoPControlado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorDiarioPLivre = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposVeiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parceiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroPlaca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroChassi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ano = table.Column<int>(type: "int", nullable: true),
                    NumeroPortas = table.Column<int>(type: "int", nullable: true),
                    CapacidadeTanque = table.Column<int>(type: "int", nullable: true),
                    CapacidadePessoas = table.Column<int>(type: "int", nullable: true),
                    TamanhoPortaMalas = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    KmInicial = table.Column<int>(type: "int", nullable: true),
                    TipoCombustivel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisponibilidadeVeiculo = table.Column<int>(type: "int", nullable: false),
                    GrupoVeiculoId = table.Column<int>(type: "int", nullable: true),
                    IdGrupoVeiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculos_GruposVeiculo_GrupoVeiculoId",
                        column: x => x.GrupoVeiculoId,
                        principalTable: "GruposVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Descontos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorMinimo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Validade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParceiroId = table.Column<int>(type: "int", nullable: true),
                    IdParceiro = table.Column<int>(type: "int", nullable: false),
                    Meio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descontos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descontos_Parceiros_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "Parceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Locacoes_ClienteBase_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClienteBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locacoes_ClienteBase_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "ClienteBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locacoes_Descontos_DescontoId",
                        column: x => x.DescontoId,
                        principalTable: "Descontos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locacoes_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TipoCalculo = table.Column<int>(type: "int", nullable: false),
                    LocacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_Locacoes_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "Locacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxasDaLocacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLocacao = table.Column<int>(type: "int", nullable: true),
                    IdTaxa = table.Column<int>(type: "int", nullable: true),
                    ServicoId = table.Column<int>(type: "int", nullable: true),
                    LocacaoEscolhidaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxasDaLocacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxasDaLocacao_Locacoes_LocacaoEscolhidaId",
                        column: x => x.LocacaoEscolhidaId,
                        principalTable: "Locacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxasDaLocacao_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteBase_ClienteId",
                table: "ClienteBase",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Descontos_ParceiroId",
                table: "Descontos",
                column: "ParceiroId");

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
                name: "IX_Servicos_LocacaoId",
                table: "Servicos",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxasDaLocacao_LocacaoEscolhidaId",
                table: "TaxasDaLocacao",
                column: "LocacaoEscolhidaId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxasDaLocacao_ServicoId",
                table: "TaxasDaLocacao",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_GrupoVeiculoId",
                table: "Veiculos",
                column: "GrupoVeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "TaxasDaLocacao");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Locacoes");

            migrationBuilder.DropTable(
                name: "ClienteBase");

            migrationBuilder.DropTable(
                name: "Descontos");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Parceiros");

            migrationBuilder.DropTable(
                name: "GruposVeiculo");
        }
    }
}
