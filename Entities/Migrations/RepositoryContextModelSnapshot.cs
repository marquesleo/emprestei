﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.Amigo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AmigoId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("amigo");
                });

            modelBuilder.Entity("Entities.Models.Emprestimo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmprestimoId");

                    b.Property<byte>("Emprestado");

                    b.Property<Guid>("amigoId");

                    b.Property<Guid>("jogoId");

                    b.HasKey("Id");

                    b.HasIndex("amigoId");

                    b.HasIndex("jogoId");

                    b.ToTable("emprestimo");
                });

            modelBuilder.Entity("Entities.Models.Jogo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("JogoId");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("jogo");
                });

            modelBuilder.Entity("Entities.Models.Emprestimo", b =>
                {
                    b.HasOne("Entities.Models.Amigo", "Amigo")
                        .WithMany()
                        .HasForeignKey("amigoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Models.Jogo", "Jogo")
                        .WithMany()
                        .HasForeignKey("jogoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
