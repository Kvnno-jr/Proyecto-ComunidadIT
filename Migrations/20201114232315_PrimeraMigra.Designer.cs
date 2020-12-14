﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Publicaciones.Models;

namespace Krofect.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201114232315_PrimeraMigra")]
    partial class PrimeraMigra
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Publicaciones.Models.MPublicacion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UsuarioID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("MPublicacion");
                });

            modelBuilder.Entity("Publicaciones.Models.MUsuario", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("MUsuario");
                });

            modelBuilder.Entity("Publicaciones.Models.MPublicacion", b =>
                {
                    b.HasOne("Publicaciones.Models.MUsuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
