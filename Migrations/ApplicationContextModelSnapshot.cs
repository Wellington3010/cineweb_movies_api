﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cineweb_movies_api.Context;

namespace cineweb_movies_api.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("cineweb_movies_api.Entities.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .HasColumnType("text");

                    b.Property<string>("NomeCliente")
                        .HasColumnType("text");

                    b.HasKey("IdCliente");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("cineweb_movies_api.Entities.Filme", b =>
                {
                    b.Property<byte[]>("Id")
                        .HasColumnType("varbinary(16)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("HomeMovie")
                        .HasColumnType("tinyint(1)");

                    b.Property<byte[]>("Poster")
                        .HasColumnType("varbinary(4000)");

                    b.Property<string>("Sinopse")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("filme");
                });

            modelBuilder.Entity("cineweb_movies_api.Entities.Ingresso", b =>
                {
                    b.Property<int>("IdIngresso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("FilmeId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("IdIngresso");

                    b.HasIndex("FilmeId")
                        .IsUnique();

                    b.ToTable("ingresso");
                });

            modelBuilder.Entity("cineweb_movies_api.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("FilmeId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdIngresso")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("ingresso")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilmeId");

                    b.HasIndex("ingresso");

                    b.ToTable("pedido");
                });

            modelBuilder.Entity("cineweb_movies_api.Entities.Ingresso", b =>
                {
                    b.HasOne("cineweb_movies_api.Entities.Filme", "Filme")
                        .WithOne("Ingresso")
                        .HasForeignKey("cineweb_movies_api.Entities.Ingresso", "FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("cineweb_movies_api.Entities.Pedido", b =>
                {
                    b.HasOne("cineweb_movies_api.Entities.Filme", "Filme")
                        .WithMany()
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cineweb_movies_api.Entities.Ingresso", "Ingresso")
                        .WithMany()
                        .HasForeignKey("ingresso");

                    b.Navigation("Filme");

                    b.Navigation("Ingresso");
                });

            modelBuilder.Entity("cineweb_movies_api.Entities.Filme", b =>
                {
                    b.Navigation("Ingresso");
                });
#pragma warning restore 612, 618
        }
    }
}
