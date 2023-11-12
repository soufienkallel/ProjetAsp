﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetAsp.Models;

#nullable disable

namespace ProjetAsp.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetAsp.Models.Categorie", b =>
                {
                    b.Property<int>("CatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CatID"));

                    b.Property<string>("CatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CatID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProjetAsp.Models.Employee", b =>
                {
                    b.Property<int>("IdEmployee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmployee"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateEmbauche")
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdService")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salaire")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ServiceIDService")
                        .HasColumnType("int");

                    b.HasKey("IdEmployee");

                    b.HasIndex("ServiceIDService");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("ProjetAsp.Models.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilmId"));

                    b.Property<int>("CatId")
                        .HasColumnType("int");

                    b.Property<string>("FilmDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilmName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FilmId");

                    b.HasIndex("CatId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("ProjetAsp.Models.Service", b =>
                {
                    b.Property<int>("IDService")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDService"));

                    b.Property<string>("NomService")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDService");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("ProjetAsp.Models.Employee", b =>
                {
                    b.HasOne("ProjetAsp.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceIDService")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ProjetAsp.Models.Film", b =>
                {
                    b.HasOne("ProjetAsp.Models.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");
                });
#pragma warning restore 612, 618
        }
    }
}
