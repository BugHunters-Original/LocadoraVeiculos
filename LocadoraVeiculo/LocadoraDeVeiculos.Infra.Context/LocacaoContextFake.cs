using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Context
{
    public class LocadoraContextFake : DbContext
    {
        public LocadoraContextFake()
        {
        }

        public LocadoraContextFake(DbContextOptions<LocadoraVeiculosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbclienteCnpj> TbclienteCnpjs { get; set; }
        public virtual DbSet<TbclienteCpf> TbclienteCpfs { get; set; }
        public virtual DbSet<Tbdesconto> Tbdescontos { get; set; }
        public virtual DbSet<Tbfuncionario> Tbfuncionarios { get; set; }
        public virtual DbSet<Tblocacao> Tblocacaos { get; set; }
        public virtual DbSet<Tbparceiro> Tbparceiros { get; set; }
        public virtual DbSet<TbtaxasDaLocacao> TbtaxasDaLocacaos { get; set; }
        public virtual DbSet<TbtaxasServico> TbtaxasServicos { get; set; }
        public virtual DbSet<TbtipoVeiculo> TbtipoVeiculos { get; set; }
        public virtual DbSet<Tbveiculo> Tbveiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LocadoraVeiculos;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;TrustServerCertificate=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbclienteCnpj>(entity =>
            {
                entity.ToTable("TBClienteCNPJ");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbclienteCpf>(entity =>
            {
                entity.ToTable("TBClienteCPF");

                entity.Property(e => e.Cnh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CNH");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.DataValidade)
                    .HasColumnType("date")
                    .HasColumnName("Data_Validade");

                entity.Property(e => e.EmailC)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EnderecoC)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.NomeC)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RG");

                entity.Property(e => e.TelefoneC)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbdesconto>(entity =>
            {
                entity.ToTable("TBDesconto");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdParceiro).HasColumnName("Id_Parceiro");

                entity.Property(e => e.Meio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomeCupom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Validade).HasColumnType("date");

                entity.HasOne(d => d.IdParceiroNavigation)
                    .WithMany(p => p.Tbdescontos)
                    .HasForeignKey(d => d.IdParceiro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBDesconto_TBParceiros");
            });

            modelBuilder.Entity<Tbfuncionario>(entity =>
            {
                entity.ToTable("TBFuncionario");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.DataEntrada)
                    .HasColumnType("date")
                    .HasColumnName("Data_entrada");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tblocacao>(entity =>
            {
                entity.ToTable("TBLocacao");

                entity.Property(e => e.DataRetornoEsperado)
                    .HasColumnType("date")
                    .HasColumnName("Data_retornoEsperado");

                entity.Property(e => e.DataSaida)
                    .HasColumnType("date")
                    .HasColumnName("Data_saida");

                entity.Property(e => e.IdClienteLocador).HasColumnName("Id_ClienteLocador");

                entity.Property(e => e.IdCondutor).HasColumnName("Id_Condutor");

                entity.Property(e => e.IdDesconto).HasColumnName("Id_Desconto");

                entity.Property(e => e.IdVeiculo).HasColumnName("Id_Veiculo");

                entity.Property(e => e.Plano)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCondutorNavigation)
                    .WithMany(p => p.Tblocacaos)
                    .HasForeignKey(d => d.IdCondutor)
                    .HasConstraintName("FK_TBLocacao_Id_Condutor");

                entity.HasOne(d => d.IdDescontoNavigation)
                    .WithMany(p => p.Tblocacaos)
                    .HasForeignKey(d => d.IdDesconto)
                    .HasConstraintName("FK_TBLocacao_TBDesconto");

                entity.HasOne(d => d.IdVeiculoNavigation)
                    .WithMany(p => p.Tblocacaos)
                    .HasForeignKey(d => d.IdVeiculo)
                    .HasConstraintName("FK_TBLocacao_TBVeiculos");
            });

            modelBuilder.Entity<Tbparceiro>(entity =>
            {
                entity.ToTable("TBParceiros");

                entity.Property(e => e.NomeParceiro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Parceiro");
            });

            modelBuilder.Entity<TbtaxasDaLocacao>(entity =>
            {
                entity.ToTable("TBTaxasDaLocacao");

                entity.Property(e => e.IdLocacao).HasColumnName("Id_Locacao");

                entity.Property(e => e.IdTaxa).HasColumnName("Id_Taxa");

                entity.HasOne(d => d.IdLocacaoNavigation)
                    .WithMany(p => p.TbtaxasDaLocacaos)
                    .HasForeignKey(d => d.IdLocacao)
                    .HasConstraintName("FK_TBTaxasDaLocacao_TBLocacao");

                entity.HasOne(d => d.IdTaxaNavigation)
                    .WithMany(p => p.TbtaxasDaLocacaos)
                    .HasForeignKey(d => d.IdTaxa)
                    .HasConstraintName("FK_TBTaxasDaLocacao_TBTaxasServicos");
            });

            modelBuilder.Entity<TbtaxasServico>(entity =>
            {
                entity.ToTable("TBTaxasServicos");

                entity.Property(e => e.NomeTaxa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nome_taxa");

                entity.Property(e => e.PrecoTaxa).HasColumnName("Preco_taxa");

                entity.Property(e => e.TipoCalculo).HasColumnName("Tipo_calculo");
            });

            modelBuilder.Entity<TbtipoVeiculo>(entity =>
            {
                entity.ToTable("TBTipoVeiculo");

                entity.Property(e => e.LimitePcontrolado).HasColumnName("Limite_PControlado");

                entity.Property(e => e.NomeTipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValorDiarioPcontrolado).HasColumnName("Valor_Diario_PControlado");

                entity.Property(e => e.ValorDiarioPdiario).HasColumnName("Valor_Diario_PDiario");

                entity.Property(e => e.ValorDiarioPlivre).HasColumnName("Valor_Diario_PLivre");

                entity.Property(e => e.ValorKmrodadPcontrolado).HasColumnName("Valor_KMRodad_PControlado");

                entity.Property(e => e.ValorKmrodadoPdiario).HasColumnName("Valor_KMRodado_PDiario");
            });

            modelBuilder.Entity<Tbveiculo>(entity =>
            {
                entity.ToTable("TBVeiculos");

                entity.Property(e => e.CapacidadePessoas).HasColumnName("Capacidade_Pessoas");

                entity.Property(e => e.CapacidadeTanque).HasColumnName("Capacidade_tanque");

                entity.Property(e => e.Cor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisponibilidadeVeiculo).HasColumnName("Disponibilidade_veiculo");

                entity.Property(e => e.Foto).HasColumnType("image");

                entity.Property(e => e.IdTipoVeiculo).HasColumnName("Id_Tipo_Veiculo");

                entity.Property(e => e.KmInicial).HasColumnName("KM_inicial");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroChassi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Numero_chassi");

                entity.Property(e => e.NumeroPlaca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Numero_placa");

                entity.Property(e => e.NumeroPortas).HasColumnName("Numero_portas");

                entity.Property(e => e.TamanhoPortaMala)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Tamanho_porta_mala")
                    .IsFixedLength(true);

                entity.Property(e => e.TipoCombustivel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_combustivel");

                entity.HasOne(d => d.IdTipoVeiculoNavigation)
                    .WithMany(p => p.Tbveiculos)
                    .HasForeignKey(d => d.IdTipoVeiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBVeiculos_TBTipoVeiculo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

}
