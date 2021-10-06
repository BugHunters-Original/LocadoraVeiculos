using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Configurations.FuncionarioModule
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("TBFuncionarios");

            builder.HasKey(funcionario => funcionario.Id);

            builder.Property(funcionario => funcionario.Nome).HasColumnType("VARCHAR(50)").IsRequired();

            builder.Property(funcionario => funcionario.Salario).HasColumnType("FLOAT").IsRequired();

            builder.Property(funcionario => funcionario.CpfFuncionario).HasColumnType("VARCHAR(50)").IsRequired();

            builder.Property(funcionario => funcionario.DataEntrada).HasColumnType("DATE").IsRequired();

            builder.Property(funcionario => funcionario.Usuario).HasColumnType("VARCHAR(50)").IsRequired();

            builder.Property(funcionario => funcionario.Senha).HasColumnType("VARCHAR(64)").IsRequired();

        }
    }
}
