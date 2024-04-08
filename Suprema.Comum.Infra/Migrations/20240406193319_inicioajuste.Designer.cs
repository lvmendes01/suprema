﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Suprema.Comum.Infra;

#nullable disable

namespace Suprema.Comum.Infra.Migrations
{
    [DbContext(typeof(ComumBDContext))]
    [Migration("20240406193319_inicioajuste")]
    partial class inicioajuste
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Suprema.Entidade.Entidades.PlayerTableEntidade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("PokerTableEntidadeId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserEntidadeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PokerTableEntidadeId");

                    b.HasIndex("UserEntidadeId");

                    b.ToTable("Tb_Suprema_PlayerTable");
                });

            modelBuilder.Entity("Suprema.Entidade.Entidades.PokerTableEntidade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("WinnerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Tb_Suprema_PokerTable");
                });

            modelBuilder.Entity("Suprema.Entidade.Entidades.UserEntidade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tb_Suprema_User");
                });

            modelBuilder.Entity("Suprema.Entidade.Entidades.PlayerTableEntidade", b =>
                {
                    b.HasOne("Suprema.Entidade.Entidades.PokerTableEntidade", null)
                        .WithMany("Players")
                        .HasForeignKey("PokerTableEntidadeId");

                    b.HasOne("Suprema.Entidade.Entidades.UserEntidade", "UserEntidade")
                        .WithMany()
                        .HasForeignKey("UserEntidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserEntidade");
                });

            modelBuilder.Entity("Suprema.Entidade.Entidades.PokerTableEntidade", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
