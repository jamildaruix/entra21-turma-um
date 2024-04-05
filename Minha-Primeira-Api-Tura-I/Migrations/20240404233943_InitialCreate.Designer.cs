﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Minha_Primeira_Api_Tura_I.Models;

#nullable disable

namespace Minha_Primeira_Api_Tura_I.Migrations
{
    [DbContext(typeof(TodoContextDB))]
    [Migration("20240404233943_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Minha_Primeira_Api_Tura_I.Models.TodoItemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apelido")
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Cadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("TodoItem");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apelido = "UM",
                            Ativo = true,
                            Cadastro = new DateTime(2024, 4, 4, 20, 39, 43, 48, DateTimeKind.Local).AddTicks(8252),
                            Nome = "Teste UM"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = false,
                            Cadastro = new DateTime(2024, 4, 4, 20, 39, 43, 48, DateTimeKind.Local).AddTicks(8262),
                            Nome = "Teste DOIS"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
