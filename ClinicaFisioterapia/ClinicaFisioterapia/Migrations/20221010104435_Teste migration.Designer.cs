﻿// <auto-generated />
using System;
using ClinicaFisioterapia.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClinicaFisioterapia.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221010104435_Teste migration")]
    partial class Testemigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("ClinicaFisioterapia.Models.Agendamento", b =>
                {
                    b.Property<int>("IdAgendamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("datetime");

                    b.Property<int>("IdFuncionario")
                        .HasColumnType("int");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("int");

                    b.Property<string>("NomeFunciorio")
                        .HasColumnType("text");

                    b.Property<string>("NomePaciente")
                        .HasColumnType("text");

                    b.Property<int>("PendenteAvaliacao")
                        .HasColumnType("int");

                    b.HasKey("IdAgendamento");

                    b.HasIndex("IdFuncionario");

                    b.HasIndex("IdPaciente")
                        .IsUnique();

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Altura")
                        .HasColumnType("double");

                    b.Property<string>("AvaliacaoPostural")
                        .HasColumnType("text");

                    b.Property<bool>("Cirurgia")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Comobirdades")
                        .HasColumnType("text");

                    b.Property<string>("CondutaCurtoPrazo")
                        .HasColumnType("text");

                    b.Property<string>("CondutaLongoPrazo")
                        .HasColumnType("text");

                    b.Property<string>("CondutaMedioPrazo")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataAvaliacao")
                        .HasColumnType("datetime");

                    b.Property<string>("Diagnostico")
                        .HasColumnType("text");

                    b.Property<bool>("DormeBem")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Fuma")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("HMA")
                        .HasColumnType("text");

                    b.Property<bool>("HistoricoLesao")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("HistoricoLesaoDescricao")
                        .HasColumnType("text");

                    b.Property<int>("IdFuncionario")
                        .HasColumnType("int");

                    b.Property<int>("IdMedico")
                        .HasColumnType("int");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("int");

                    b.Property<string>("MedicacaoEmUso")
                        .HasColumnType("text");

                    b.Property<string>("MedicacaoLesao")
                        .HasColumnType("text");

                    b.Property<int>("MembroDominante")
                        .HasColumnType("int");

                    b.Property<string>("MembrosAtivos")
                        .HasColumnType("text");

                    b.Property<string>("MembrosPassivos")
                        .HasColumnType("text");

                    b.Property<string>("NomeFuncionario")
                        .HasColumnType("text");

                    b.Property<string>("NomeMedico")
                        .HasColumnType("text");

                    b.Property<string>("NomePaciente")
                        .HasColumnType("text");

                    b.Property<string>("ObservacaoAtividade")
                        .HasColumnType("text");

                    b.Property<string>("ObservacaoCirurgia")
                        .HasColumnType("text");

                    b.Property<string>("ObservacaoFuma")
                        .HasColumnType("text");

                    b.Property<string>("OutrasObservacoes")
                        .HasColumnType("text");

                    b.Property<double>("Peso")
                        .HasColumnType("double");

                    b.Property<bool>("PraticaAtividadeFisica")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RegistroMedico")
                        .HasColumnType("text");

                    b.Property<string>("TestesEspeciais")
                        .HasColumnType("text");

                    b.Property<string>("TestesFuncionais")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdFuncionario");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdPaciente")
                        .IsUnique();

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("text");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cidade")
                        .HasColumnType("text");

                    b.Property<string>("Estado")
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .HasColumnType("text");

                    b.Property<string>("Uf")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Evolucao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEvolucao")
                        .HasColumnType("datetime");

                    b.Property<int>("IdSessao")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdSessao")
                        .IsUnique();

                    b.ToTable("Evolucao");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AgendamentoIdAgendamento")
                        .HasColumnType("int");

                    b.Property<int>("CarteiraConvenio")
                        .HasColumnType("int");

                    b.Property<string>("Celular")
                        .HasColumnType("text");

                    b.Property<string>("Convenio")
                        .HasColumnType("text");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Profissao")
                        .HasColumnType("int");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<bool>("Situacao")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AgendamentoIdAgendamento");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameMedico")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarteiraConvenio")
                        .HasColumnType("int");

                    b.Property<string>("Celular")
                        .HasColumnType("text");

                    b.Property<string>("Convenio")
                        .HasColumnType("text");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Profissao")
                        .HasColumnType("int");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<bool>("Situacao")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Sessao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataSessao")
                        .HasColumnType("datetime");

                    b.Property<int>("IdAvaliacao")
                        .HasColumnType("int");

                    b.Property<int>("IdFuncionario")
                        .HasColumnType("int");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAvaliacao");

                    b.HasIndex("IdFuncionario");

                    b.HasIndex("IdPaciente");

                    b.ToTable("Sessao");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(767)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Agendamento", b =>
                {
                    b.HasOne("ClinicaFisioterapia.Models.Funcionario", "Funcionario")
                        .WithMany("Agendamentos")
                        .HasForeignKey("IdFuncionario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaFisioterapia.Models.Paciente", "Paciente")
                        .WithOne("Agendamento")
                        .HasForeignKey("ClinicaFisioterapia.Models.Agendamento", "IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Avaliacao", b =>
                {
                    b.HasOne("ClinicaFisioterapia.Models.Funcionario", "Funcionario")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("IdFuncionario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaFisioterapia.Models.Medico", "Medico")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaFisioterapia.Models.Paciente", "Paciente")
                        .WithOne("Avaliacao")
                        .HasForeignKey("ClinicaFisioterapia.Models.Avaliacao", "IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Evolucao", b =>
                {
                    b.HasOne("ClinicaFisioterapia.Models.Sessao", "Sessao")
                        .WithOne("Evolucao")
                        .HasForeignKey("ClinicaFisioterapia.Models.Evolucao", "IdSessao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sessao");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Funcionario", b =>
                {
                    b.HasOne("ClinicaFisioterapia.Models.Agendamento", "Agendamento")
                        .WithMany()
                        .HasForeignKey("AgendamentoIdAgendamento");

                    b.HasOne("ClinicaFisioterapia.Models.Endereco", "Endereco")
                        .WithOne("Funcionario")
                        .HasForeignKey("ClinicaFisioterapia.Models.Funcionario", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agendamento");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Paciente", b =>
                {
                    b.HasOne("ClinicaFisioterapia.Models.Endereco", "Endereco")
                        .WithOne("Paciente")
                        .HasForeignKey("ClinicaFisioterapia.Models.Paciente", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Sessao", b =>
                {
                    b.HasOne("ClinicaFisioterapia.Models.Avaliacao", "Avaliacao")
                        .WithMany("Sessoes")
                        .HasForeignKey("IdAvaliacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaFisioterapia.Models.Funcionario", "Funcionario")
                        .WithMany("Sessoes")
                        .HasForeignKey("IdFuncionario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaFisioterapia.Models.Paciente", "Paciente")
                        .WithMany("Sessoes")
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Avaliacao");

                    b.Navigation("Funcionario");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Avaliacao", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Endereco", b =>
                {
                    b.Navigation("Funcionario");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Funcionario", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Avaliacoes");

                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Medico", b =>
                {
                    b.Navigation("Avaliacoes");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Paciente", b =>
                {
                    b.Navigation("Agendamento");

                    b.Navigation("Avaliacao");

                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Sessao", b =>
                {
                    b.Navigation("Evolucao");
                });
#pragma warning restore 612, 618
        }
    }
}
