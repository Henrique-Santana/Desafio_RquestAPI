using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestBRQ.Domains
{
    public partial class TestBrqContext : DbContext
    {
        public TestBrqContext()
        {
        }

        public TestBrqContext(DbContextOptions<TestBrqContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DadosPessoais> DadosPessoais { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string Database = "DESKTOP-T6D66PF\\SQLEXPRESS";

                optionsBuilder.UseSqlServer($"Data Source={Database}; Initial Catalog=TestBrq; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DadosPessoais>(entity =>
            {
                entity.HasKey(e => e.IdDadosPessoais);

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__DadosPes__C1F89731691B39C6")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sobrenome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.DadosPessoais)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__DadosPess__IdEnd__398D8EEE");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco1)
                    .IsRequired()
                    .HasColumnName("Endereco")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
