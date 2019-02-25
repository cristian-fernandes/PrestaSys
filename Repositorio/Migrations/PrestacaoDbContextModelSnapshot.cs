﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositorio;

namespace Repositorio.Migrations
{
    [DbContext(typeof(PrestacaoDbContext))]
    partial class PrestacaoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Repositorio.Models.Database.Prestacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("Id");

                    b.HasIndex("AprovadorFinanceiroId");

                    b.HasIndex("AprovadorId");

                    b.HasIndex("EmitenteId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TipoId");

                    b.ToTable("Prestacao");
                });

            modelBuilder.Entity("Repositorio.Models.Database.PrestacaoStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("Repositorio.Models.Database.PrestacaoTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("Repositorio.Models.Database.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("FlagGerente");

                    b.Property<bool>("FlagGerenteFinanceiro");

                    b.Property<int?>("GerenteFinanceiroId");

                    b.Property<int?>("GerenteId");

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

            modelBuilder.Entity("Repositorio.Models.Database.Prestacao", b =>
                {
                    b.HasOne("Repositorio.Models.Database.Usuario", "AprovadorFinanceiro")
                        .WithMany("PrestacaoAprovadorFinanceiro")
                        .HasForeignKey("AprovadorFinanceiroId")
                        .HasConstraintName("FK_Usuario_PrestacaoAprovadorFinanceiroId");

                    b.HasOne("Repositorio.Models.Database.Usuario", "Aprovador")
                        .WithMany("PrestacaoAprovador")
                        .HasForeignKey("AprovadorId")
                        .HasConstraintName("FK_Usuario_PrestacaoAprovadorId");

                    b.HasOne("Repositorio.Models.Database.Usuario", "Emitente")
                        .WithMany("PrestacaoEmitente")
                        .HasForeignKey("EmitenteId")
                        .HasConstraintName("FK_Usuario_PrestacaoEmitenteId");

                    b.HasOne("Repositorio.Models.Database.PrestacaoStatus", "Status")
                        .WithMany("Prestacao")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("FK_PrestacaoStatus_Prestacao");

                    b.HasOne("Repositorio.Models.Database.PrestacaoTipo", "Tipo")
                        .WithMany("Prestacao")
                        .HasForeignKey("TipoId")
                        .HasConstraintName("FK_PrestacaoTipo_Prestacao");
                });

            modelBuilder.Entity("Repositorio.Models.Database.Usuario", b =>
                {
                    b.HasOne("Repositorio.Models.Database.Usuario", "GerenteFinanceiro")
                        .WithMany("InverseGerenteFinanceiro")
                        .HasForeignKey("GerenteFinanceiroId")
                        .HasConstraintName("FK_Usuario_Id_GerenteFinanceiroId");

                    b.HasOne("Repositorio.Models.Database.Usuario", "Gerente")
                        .WithMany("InverseGerente")
                        .HasForeignKey("GerenteId")
                        .HasConstraintName("FK_Usuario_Id_GerenteId");
                });
#pragma warning restore 612, 618
        }
    }
}
