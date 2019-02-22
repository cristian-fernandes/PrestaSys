using Microsoft.EntityFrameworkCore;
using Repositorio.Models.Database;

namespace Repositorio
{
    public class PrestacaoDbContext : DbContext
    {
        public PrestacaoDbContext()
        {
        }

        public PrestacaoDbContext(DbContextOptions<PrestacaoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Prestacao> Prestacao { get; set; }
        public virtual DbSet<PrestacaoStatus> PrestacaoStatus { get; set; }
        public virtual DbSet<PrestacaoTipo> PrestacaoTipo { get; set; }
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

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
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

            modelBuilder.Entity<PrestacaoTipo>(entity =>
            {
                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50);
            });

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
        }
    }
}
