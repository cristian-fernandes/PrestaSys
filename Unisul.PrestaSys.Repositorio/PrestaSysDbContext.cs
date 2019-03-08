using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Entidades.Usuarios;

namespace Unisul.PrestaSys.Repositorio
{
    public class PrestaSysDbContext : DbContext, IPrestaSysDbContext
    {
        private readonly DbContextOptions<PrestaSysDbContext> _options;

        public PrestaSysDbContext(DbContextOptions<PrestaSysDbContext> options)
            : base(options)
        {
            _options = options;
        }

        public new EntityEntry Add(object entity)
        {
            return base.Add(entity);
        }

        public new bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public new int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual DbSet<Prestacao> Prestacao { get; set; }
        public virtual DbSet<PrestacaoStatus> PrestacaoStatus { get; set; }
        public virtual DbSet<PrestacaoTipo> PrestacaoTipo { get; set; }

        public new EntityEntry Remove<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Remove(entity);
        }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }

        public new int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public new Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public new Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public new string ToString()
        {
            return base.ToString();
        }

        public new EntityEntry Update(object entity)
        {
            return base.Update(entity);
        }

        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Prestacao>(entity =>
            {
                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.Justificativa).IsRequired();

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.AprovadorFinanceiro)
                    .WithMany(p => p.PrestacaoAprovadorFinanceiro)
                    .HasForeignKey(d => d.AprovadorFinanceiroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_PrestacaoAprovadorFinanceiroId");

                entity.HasOne(d => d.Aprovador)
                    .WithMany(p => p.PrestacaoAprovador)
                    .HasForeignKey(d => d.AprovadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_PrestacaoAprovadorId");

                entity.HasOne(d => d.Emitente)
                    .WithMany(p => p.PrestacaoEmitente)
                    .HasForeignKey(d => d.EmitenteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Usuario_PrestacaoEmitenteId");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Prestacao)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrestacaoStatus_Prestacao");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Prestacao)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrestacaoTipo_Prestacao");
            });

            modelBuilder.Entity<PrestacaoStatus>(entity =>
            {
                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PrestacaoStatus>().HasData(
                new PrestacaoStatus
                {
                    Id = 1,
                    Status = "Em Aprovação Operacional"
                },
                new PrestacaoStatus
                {
                    Id = 2,
                    Status = "Em Aprovação Financeira"
                },
                new PrestacaoStatus
                {
                    Id = 3,
                    Status = "Finalizada"
                },
                new PrestacaoStatus
                {
                    Id = 4,
                    Status = "Rejeitada"
                }
            );

            modelBuilder.Entity<PrestacaoTipo>(entity =>
            {
                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PrestacaoTipo>().HasData(
                new PrestacaoTipo
                {
                    Id = 1,
                    Tipo = "Viagem"
                },
                new PrestacaoTipo
                {
                    Id = 2,
                    Tipo = "Curso de Idioma"
                },
                new PrestacaoTipo
                {
                    Id = 3,
                    Tipo = "Alimentação"
                },
                new PrestacaoTipo
                {
                    Id = 4,
                    Tipo = "Taxi/Uber"
                }
            );

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("U_UsuarioEmail")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sobrenome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.GerenteFinanceiro)
                    .WithMany(p => p.InverseGerenteFinanceiro)
                    .HasForeignKey(d => d.GerenteFinanceiroId)
                    .HasConstraintName("FK_Usuario_Id_GerenteFinanceiroId");

                entity.HasOne(d => d.Gerente)
                    .WithMany(p => p.InverseGerente)
                    .HasForeignKey(d => d.GerenteId)
                    .HasConstraintName("FK_Usuario_Id_GerenteId");
            });

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nome = "Cristian",
                    Sobrenome = "Fernandes",
                    Email = "cristian.fernandes@unisul.br",
                    Senha = "asdf",
                    GerenteId = 1,
                    GerenteFinanceiroId = 1,
                    FlagGerenteFinanceiro = true,
                    FlagGerente = true
                });
        }

        public void BulkUpdate<T>(IList<T> entities, BulkConfig bulkConfig = null, Action<decimal> progress = null) where T : class
        {
            this.BulkInsertOrUpdate(entities, bulkConfig, progress);
        }
    }
}
