﻿// <auto-generated />
using System;
using Magazin_Online.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Magazin_Online.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240424215958_Initial7")]
    partial class Initial7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Magazin_Online.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UtilizatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Admini");
                });

            modelBuilder.Entity("Magazin_Online.Models.Comanda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataComanda")
                        .HasColumnType("datetime2");

                    b.Property<int>("Nr_buc")
                        .HasColumnType("int");

                    b.Property<string>("Nr_comanda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StareComanda")
                        .HasColumnType("int");

                    b.Property<int>("UtilizatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("UtilizatorId");

                    b.ToTable("Comenzi");
                });

            modelBuilder.Entity("Magazin_Online.Models.Produs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("Categorie")
                        .HasColumnType("int");

                    b.Property<int>("ComandaId")
                        .HasColumnType("int");

                    b.Property<string>("Denumire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descriere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumarBucati")
                        .HasColumnType("int");

                    b.Property<int>("Orase")
                        .HasColumnType("int");

                    b.Property<float>("Pret")
                        .HasColumnType("real");

                    b.Property<int>("UtilizatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("ComandaId");

                    b.HasIndex("UtilizatorId");

                    b.ToTable("Produse");
                });

            modelBuilder.Entity("Magazin_Online.Models.ProdusComanda", b =>
                {
                    b.Property<int>("ProdusId")
                        .HasColumnType("int");

                    b.Property<int>("ComandaId")
                        .HasColumnType("int");

                    b.HasKey("ProdusId", "ComandaId");

                    b.HasIndex("ComandaId");

                    b.ToTable("ProdusComanda");
                });

            modelBuilder.Entity("Magazin_Online.Models.Utilizator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Oras")
                        .HasColumnType("int");

                    b.Property<string>("Parola")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Utilizatori");
                });

            modelBuilder.Entity("Magazin_Online.Models.Comanda", b =>
                {
                    b.HasOne("Magazin_Online.Models.Admin", "Admin")
                        .WithMany("Comanda")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Magazin_Online.Models.Utilizator", "Utilizator")
                        .WithMany("Comanda")
                        .HasForeignKey("UtilizatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Utilizator");
                });

            modelBuilder.Entity("Magazin_Online.Models.Produs", b =>
                {
                    b.HasOne("Magazin_Online.Models.Admin", "Admin")
                        .WithMany("Produs")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Magazin_Online.Models.Comanda", "Comanda")
                        .WithMany("Produs")
                        .HasForeignKey("ComandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Magazin_Online.Models.Utilizator", "Utilizator")
                        .WithMany("Produs")
                        .HasForeignKey("UtilizatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Comanda");

                    b.Navigation("Utilizator");
                });

            modelBuilder.Entity("Magazin_Online.Models.ProdusComanda", b =>
                {
                    b.HasOne("Magazin_Online.Models.Comanda", "Comanda")
                        .WithMany("ProdusComanda")
                        .HasForeignKey("ComandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Magazin_Online.Models.Produs", "Produs")
                        .WithMany("ProdusComanda")
                        .HasForeignKey("ProdusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comanda");

                    b.Navigation("Produs");
                });

            modelBuilder.Entity("Magazin_Online.Models.Utilizator", b =>
                {
                    b.HasOne("Magazin_Online.Models.Admin", "Admin")
                        .WithMany("Utilizator")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Magazin_Online.Models.Admin", b =>
                {
                    b.Navigation("Comanda");

                    b.Navigation("Produs");

                    b.Navigation("Utilizator");
                });

            modelBuilder.Entity("Magazin_Online.Models.Comanda", b =>
                {
                    b.Navigation("Produs");

                    b.Navigation("ProdusComanda");
                });

            modelBuilder.Entity("Magazin_Online.Models.Produs", b =>
                {
                    b.Navigation("ProdusComanda");
                });

            modelBuilder.Entity("Magazin_Online.Models.Utilizator", b =>
                {
                    b.Navigation("Comanda");

                    b.Navigation("Produs");
                });
#pragma warning restore 612, 618
        }
    }
}
