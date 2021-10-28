﻿// <auto-generated />
using System;
using LocadoraDeVeiculos.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    [DbContext(typeof(LocacaoContext))]
    partial class LocacaoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ClienteModule.ClienteBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)");

                    b.HasKey("Id");

                    b.ToTable("TBClientesBase");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.DescontoModule.Desconto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("IdParceiro")
                        .HasColumnType("int");

                    b.Property<string>("Meio")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("Usos")
                        .HasColumnType("INT");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("DATE");

                    b.Property<double>("Valor")
                        .HasColumnType("FLOAT");

                    b.Property<double>("ValorMinimo")
                        .HasColumnType("FLOAT");

                    b.HasKey("Id");

                    b.HasIndex("IdParceiro");

                    b.ToTable("TBDescontos");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.FuncionarioModule.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CpfFuncionario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("DATE");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<double>("Salario")
                        .HasColumnType("FLOAT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("TBFuncionarios");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.GrupoVeiculoModule.GrupoVeiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("LimitePControlado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NomeTipo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<double>("ValorDiarioPControlado")
                        .HasColumnType("FLOAT");

                    b.Property<double>("ValorDiarioPDiario")
                        .HasColumnType("FLOAT");

                    b.Property<double>("ValorDiarioPLivre")
                        .HasColumnType("FLOAT");

                    b.Property<double>("ValorKmRodadoPControlado")
                        .HasColumnType("FLOAT");

                    b.Property<double>("ValorKmRodadoPDiario")
                        .HasColumnType("FLOAT");

                    b.HasKey("Id");

                    b.ToTable("TBTiposVeiculo");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.LocacaoModule.Locacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataRetorno")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("DataSaida")
                        .HasColumnType("DATE");

                    b.Property<int>("Dias")
                        .HasColumnType("INT");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int?>("IdCondutor")
                        .HasColumnType("int");

                    b.Property<int?>("IdDesconto")
                        .HasColumnType("INT");

                    b.Property<int?>("IdVeiculo")
                        .HasColumnType("int");

                    b.Property<double?>("PrecoCombustivel")
                        .HasColumnType("FLOAT");

                    b.Property<double>("PrecoPlano")
                        .HasColumnType("FLOAT");

                    b.Property<double?>("PrecoServicos")
                        .HasColumnType("FLOAT");

                    b.Property<double>("PrecoTotal")
                        .HasColumnType("FLOAT");

                    b.Property<string>("StatusEnvioEmail")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("StatusLocacao")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<int>("TipoCliente")
                        .HasColumnType("INT");

                    b.Property<string>("TipoLocacao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdCondutor")
                        .IsUnique()
                        .HasFilter("[IdCondutor] IS NOT NULL");

                    b.HasIndex("IdDesconto");

                    b.HasIndex("IdVeiculo");

                    b.ToTable("TBLocacoes");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ParceiroModule.Parceiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("TBParceiros");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ReciboModule.Recibo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Ms")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("TBRecibos");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ServicoModule.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<double>("Preco")
                        .HasColumnType("FLOAT");

                    b.Property<int>("TipoCalculo")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.ToTable("TBServicos");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule.TaxaDaLocacao", b =>
                {
                    b.Property<int?>("IdLocacao")
                        .HasColumnType("int");

                    b.Property<int?>("IdTaxa")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdLocacao", "IdTaxa");

                    b.HasIndex("IdTaxa");

                    b.ToTable("TBTaxasDaLocacao");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.VeiculoModule.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Ano")
                        .HasColumnType("int");

                    b.Property<int?>("CapacidadePessoas")
                        .IsRequired()
                        .HasColumnType("INT");

                    b.Property<int?>("CapacidadeTanque")
                        .IsRequired()
                        .HasColumnType("INT");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<int>("DisponibilidadeVeiculo")
                        .HasColumnType("INT");

                    b.Property<byte[]>("Foto")
                        .IsRequired()
                        .HasColumnType("image");

                    b.Property<int>("IdGrupoVeiculo")
                        .HasColumnType("INT");

                    b.Property<int?>("KmInicial")
                        .IsRequired()
                        .HasColumnType("INT");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("NumeroChassi")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("NumeroPlaca")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<int?>("NumeroPortas")
                        .IsRequired()
                        .HasColumnType("INT");

                    b.Property<string>("TamanhoPortaMalas")
                        .IsRequired()
                        .HasColumnType("CHAR(1)");

                    b.Property<string>("TipoCombustivel")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.HasKey("Id");

                    b.HasIndex("IdGrupoVeiculo");

                    b.ToTable("TBVeiculos");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule.ClienteCNPJ", b =>
                {
                    b.HasBaseType("LocadoraDeVeiculos.Dominio.ClienteModule.ClienteBase");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.ToTable("TBClientesCNPJ");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule.ClienteCPF", b =>
                {
                    b.HasBaseType("LocadoraDeVeiculos.Dominio.ClienteModule.ClienteBase");

                    b.Property<string>("Cnh")
                        .IsRequired()
                        .HasColumnType("VARCHAR(12)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("VARCHAR(14)");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)");

                    b.HasIndex("IdCliente");

                    b.ToTable("TBClientesCPF");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.DescontoModule.Desconto", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ParceiroModule.Parceiro", "Parceiro")
                        .WithMany("Descontos")
                        .HasForeignKey("IdParceiro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parceiro");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.LocacaoModule.Locacao", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ClienteModule.ClienteBase", "Cliente")
                        .WithMany("Locacoes")
                        .HasForeignKey("IdCliente");

                    b.HasOne("LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule.ClienteCPF", "Condutor")
                        .WithOne("Locacao")
                        .HasForeignKey("LocadoraDeVeiculos.Dominio.LocacaoModule.Locacao", "IdCondutor");

                    b.HasOne("LocadoraDeVeiculos.Dominio.DescontoModule.Desconto", "Desconto")
                        .WithMany("Locacoes")
                        .HasForeignKey("IdDesconto");

                    b.HasOne("LocadoraDeVeiculos.Dominio.VeiculoModule.Veiculo", "Veiculo")
                        .WithMany("Locacoes")
                        .HasForeignKey("IdVeiculo");

                    b.Navigation("Cliente");

                    b.Navigation("Condutor");

                    b.Navigation("Desconto");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule.TaxaDaLocacao", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.LocacaoModule.Locacao", "LocacaoEscolhida")
                        .WithMany("TaxasDaLocacao")
                        .HasForeignKey("IdLocacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraDeVeiculos.Dominio.ServicoModule.Servico", "Servico")
                        .WithMany("TaxasDaLocacao")
                        .HasForeignKey("IdTaxa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocacaoEscolhida");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.VeiculoModule.Veiculo", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.GrupoVeiculoModule.GrupoVeiculo", "GrupoVeiculo")
                        .WithMany("Veiculos")
                        .HasForeignKey("IdGrupoVeiculo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoVeiculo");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule.ClienteCNPJ", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ClienteModule.ClienteBase", null)
                        .WithOne()
                        .HasForeignKey("LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule.ClienteCNPJ", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule.ClienteCPF", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ClienteModule.ClienteBase", null)
                        .WithOne()
                        .HasForeignKey("LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule.ClienteCPF", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule.ClienteCNPJ", "Cliente")
                        .WithMany("Condutores")
                        .HasForeignKey("IdCliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ClienteModule.ClienteBase", b =>
                {
                    b.Navigation("Locacoes");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.DescontoModule.Desconto", b =>
                {
                    b.Navigation("Locacoes");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.GrupoVeiculoModule.GrupoVeiculo", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.LocacaoModule.Locacao", b =>
                {
                    b.Navigation("TaxasDaLocacao");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ParceiroModule.Parceiro", b =>
                {
                    b.Navigation("Descontos");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ServicoModule.Servico", b =>
                {
                    b.Navigation("TaxasDaLocacao");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.VeiculoModule.Veiculo", b =>
                {
                    b.Navigation("Locacoes");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule.ClienteCNPJ", b =>
                {
                    b.Navigation("Condutores");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule.ClienteCPF", b =>
                {
                    b.Navigation("Locacao");
                });
#pragma warning restore 612, 618
        }
    }
}
