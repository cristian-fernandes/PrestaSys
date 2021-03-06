﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Unisul.PrestaSys.Repositorio.Migrations
{
    [DbContext(typeof(PrestaSysDbContext))]
    internal class PrestacaoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Unisul.PrestaSys.Entidades.Prestacoes.Prestacao", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("AprovadorFinanceiroId");

                b.Property<int>("AprovadorId");

                b.Property<DateTime>("Data")
                    .HasColumnType("datetime");

                b.Property<int>("EmitenteId");

                b.Property<byte[]>("ImagemComprovante");

                b.Property<string>("Justificativa")
                    .IsRequired();

                b.Property<string>("JustificativaAprovacao");

                b.Property<string>("JustificativaAprovacaoFinanceira");

                b.Property<int>("StatusId");

                b.Property<int>("TipoId");

                b.Property<string>("Titulo")
                    .IsRequired()
                    .HasMaxLength(50);

                b.Property<decimal>("Valor")
                    .HasColumnType("decimal(18, 2)");

                b.HasKey("Id");

                b.HasIndex("AprovadorFinanceiroId");

                b.HasIndex("AprovadorId");

                b.HasIndex("EmitenteId");

                b.HasIndex("StatusId");

                b.HasIndex("TipoId");

                b.ToTable("Prestacao");
            });

            modelBuilder.Entity("Unisul.PrestaSys.Entidades.Prestacoes.PrestacaoStatus", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Status")
                    .IsRequired()
                    .HasMaxLength(50);

                b.HasKey("Id");

                b.ToTable("PrestacaoStatus");

                b.HasData(
                    new
                    {
                        Id = 1,
                        Status = "Em Aprovação Operacional"
                    },
                    new
                    {
                        Id = 2,
                        Status = "Em Aprovação Financeira"
                    },
                    new
                    {
                        Id = 3,
                        Status = "Finalizada"
                    },
                    new
                    {
                        Id = 4,
                        Status = "Rejeitada"
                    });
            });

            modelBuilder.Entity("Unisul.PrestaSys.Entidades.Prestacoes.PrestacaoTipo", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Tipo")
                    .IsRequired()
                    .HasMaxLength(50);

                b.HasKey("Id");

                b.ToTable("PrestacaoTipo");

                b.HasData(
                    new
                    {
                        Id = 1,
                        Tipo = "Viagem"
                    },
                    new
                    {
                        Id = 2,
                        Tipo = "Curso de Idioma"
                    },
                    new
                    {
                        Id = 3,
                        Tipo = "Alimentação"
                    },
                    new
                    {
                        Id = 4,
                        Tipo = "Taxi/Uber"
                    });
            });

            modelBuilder.Entity("Unisul.PrestaSys.Entidades.Usuarios.Usuario", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Email")
                    .IsRequired()
                    .HasMaxLength(50);

                b.Property<bool>("FlagGerente");

                b.Property<bool>("FlagGerenteFinanceiro");

                b.Property<int>("GerenteFinanceiroId");

                b.Property<int>("GerenteId");

                b.Property<string>("Nome")
                    .IsRequired()
                    .HasMaxLength(50);

                b.Property<string>("Senha")
                    .IsRequired()
                    .HasMaxLength(50);

                b.Property<string>("Sobrenome")
                    .IsRequired()
                    .HasMaxLength(50);

                b.HasKey("Id");

                b.HasIndex("Email")
                    .IsUnique()
                    .HasName("U_UsuarioEmail");

                b.HasIndex("GerenteFinanceiroId");

                b.HasIndex("GerenteId");

                b.ToTable("Usuario");

                b.HasData(
                    new
                    {
                        Id = 1,
                        Email = "cristian.fernandes@unisul.br",
                        FlagGerente = true,
                        FlagGerenteFinanceiro = true,
                        GerenteFinanceiroId = 1,
                        GerenteId = 1,
                        Nome = "Cristian",
                        Senha = "asdf",
                        Sobrenome = "Fernandes"
                    });
            });

            modelBuilder.Entity("Unisul.PrestaSys.Entidades.Prestacoes.Prestacao", b =>
            {
                b.HasOne("Unisul.PrestaSys.Entidades.Usuarios.Usuario", "AprovadorFinanceiro")
                    .WithMany("PrestacaoAprovadorFinanceiro")
                    .HasForeignKey("AprovadorFinanceiroId")
                    .HasConstraintName("FK_Usuario_PrestacaoAprovadorFinanceiroId");

                b.HasOne("Unisul.PrestaSys.Entidades.Usuarios.Usuario", "Aprovador")
                    .WithMany("PrestacaoAprovador")
                    .HasForeignKey("AprovadorId")
                    .HasConstraintName("FK_Usuario_PrestacaoAprovadorId");

                b.HasOne("Unisul.PrestaSys.Entidades.Usuarios.Usuario", "Emitente")
                    .WithMany("PrestacaoEmitente")
                    .HasForeignKey("EmitenteId")
                    .HasConstraintName("FK_Usuario_PrestacaoEmitenteId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("Unisul.PrestaSys.Entidades.Prestacoes.PrestacaoStatus", "Status")
                    .WithMany("Prestacao")
                    .HasForeignKey("StatusId")
                    .HasConstraintName("FK_PrestacaoStatus_Prestacao");

                b.HasOne("Unisul.PrestaSys.Entidades.Prestacoes.PrestacaoTipo", "Tipo")
                    .WithMany("Prestacao")
                    .HasForeignKey("TipoId")
                    .HasConstraintName("FK_PrestacaoTipo_Prestacao");
            });

            modelBuilder.Entity("Unisul.PrestaSys.Entidades.Usuarios.Usuario", b =>
            {
                b.HasOne("Unisul.PrestaSys.Entidades.Usuarios.Usuario", "GerenteFinanceiro")
                    .WithMany("InverseGerenteFinanceiro")
                    .HasForeignKey("GerenteFinanceiroId")
                    .HasConstraintName("FK_Usuario_Id_GerenteFinanceiroId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("Unisul.PrestaSys.Entidades.Usuarios.Usuario", "Gerente")
                    .WithMany("InverseGerente")
                    .HasForeignKey("GerenteId")
                    .HasConstraintName("FK_Usuario_Id_GerenteId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
#pragma warning restore 612, 618
        }
    }
}
