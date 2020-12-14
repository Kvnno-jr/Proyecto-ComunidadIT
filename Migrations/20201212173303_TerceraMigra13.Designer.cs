﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Publicaciones.Models;

namespace Krofect.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201212173303_TerceraMigra13")]
    partial class TerceraMigra13
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Publicaciones.Models.Comentario", b =>
                {
                    b.Property<int>("ComentarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PublicacionID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Texto")
                        .HasColumnType("TEXT");

                    b.Property<string>("UsuarioID")
                        .HasColumnType("TEXT");

                    b.HasKey("ComentarioID");

                    b.HasIndex("PublicacionID");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("Publicaciones.Models.Like", b =>
                {
                    b.Property<string>("PubComResID")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ComentarioID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PublicacionID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RespuestaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UsuarioID")
                        .HasColumnType("TEXT");

                    b.HasKey("PubComResID");

                    b.HasIndex("ComentarioID");

                    b.HasIndex("PublicacionID");

                    b.HasIndex("RespuestaID");

                    b.ToTable("Like");
                });

            modelBuilder.Entity("Publicaciones.Models.Publicacion", b =>
                {
                    b.Property<int>("PublicacionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Texto")
                        .HasColumnType("TEXT");

                    b.Property<string>("UsuarioID")
                        .HasColumnType("TEXT");

                    b.HasKey("PublicacionID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Publicacion");
                });

            modelBuilder.Entity("Publicaciones.Models.Respuesta", b =>
                {
                    b.Property<int>("RespuestaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ComentarioID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Texto")
                        .HasColumnType("TEXT");

                    b.Property<string>("UsuarioID")
                        .HasColumnType("TEXT");

                    b.HasKey("RespuestaID");

                    b.HasIndex("ComentarioID");

                    b.ToTable("Respuesta");
                });

            modelBuilder.Entity("Publicaciones.Models.Seguido", b =>
                {
                    b.Property<string>("A_Seguir")
                        .HasColumnType("TEXT");

                    b.Property<string>("UsuarioID")
                        .HasColumnType("TEXT");

                    b.HasKey("A_Seguir", "UsuarioID");

                    b.ToTable("Seguido");
                });

            modelBuilder.Entity("Publicaciones.Models.Usuario", b =>
                {
                    b.Property<string>("UsuarioID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImgPerfil")
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioID");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Publicaciones.Models.Comentario", b =>
                {
                    b.HasOne("Publicaciones.Models.Publicacion", null)
                        .WithMany("Comentarios")
                        .HasForeignKey("PublicacionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Publicaciones.Models.Like", b =>
                {
                    b.HasOne("Publicaciones.Models.Comentario", null)
                        .WithMany("Likes")
                        .HasForeignKey("ComentarioID");

                    b.HasOne("Publicaciones.Models.Publicacion", null)
                        .WithMany("Likes")
                        .HasForeignKey("PublicacionID");

                    b.HasOne("Publicaciones.Models.Respuesta", null)
                        .WithMany("Likes")
                        .HasForeignKey("RespuestaID");
                });

            modelBuilder.Entity("Publicaciones.Models.Publicacion", b =>
                {
                    b.HasOne("Publicaciones.Models.Usuario", null)
                        .WithMany("Publicaciones")
                        .HasForeignKey("UsuarioID");
                });

            modelBuilder.Entity("Publicaciones.Models.Respuesta", b =>
                {
                    b.HasOne("Publicaciones.Models.Comentario", null)
                        .WithMany("Respuestas")
                        .HasForeignKey("ComentarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Publicaciones.Models.Comentario", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("Respuestas");
                });

            modelBuilder.Entity("Publicaciones.Models.Publicacion", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("Publicaciones.Models.Respuesta", b =>
                {
                    b.Navigation("Likes");
                });

            modelBuilder.Entity("Publicaciones.Models.Usuario", b =>
                {
                    b.Navigation("Publicaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
