﻿// <auto-generated />
using System;
using LeonesApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LeonesApi.Migrations
{
    [DbContext(typeof(SmartsofMarcoslescanoContext))]
    [Migration("20231121181436_Init4")]
    partial class Init4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("LeonesApi.Models.Cuota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("Año")
                        .HasColumnType("int(11)");

                    b.Property<bool>("Cobrada")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Mes")
                        .HasColumnType("int(11)");

                    b.Property<decimal>("Monto")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.Property<int>("SocioId")
                        .HasColumnType("int(11)");

                    b.Property<int>("TesoreroId")
                        .HasColumnType("int(11)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "SocioId" }, "IX_Cuotas_SocioId");

                    b.HasIndex(new[] { "TesoreroId" }, "IX_Cuotas_TesoreroId");

                    b.ToTable("Cuotas");
                });

            modelBuilder.Entity("LeonesApi.Models.EfmigrationsHistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("MigrationId")
                        .HasName("PRIMARY");

                    b.ToTable("__EFMigrationsHistory2", (string)null);
                });

            modelBuilder.Entity("LeonesApi.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("DateTime")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Egreso")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.Property<decimal>("Ingreso")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("LeonesApi.Models.Socio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("ApellidoNombre")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Apellido_Nombre");

                    b.Property<string>("Dirección")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("DNI");

                    b.Property<string>("Teléfono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Socios");
                });

            modelBuilder.Entity("LeonesApi.Models.Tesorero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("ApellidoNombre")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Apellido_Nombre");

                    b.Property<string>("Período")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Tesoreros");
                });

            modelBuilder.Entity("LeonesApi.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int(11)");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("LeonesApi.Models.Cuota", b =>
                {
                    b.HasOne("LeonesApi.Models.Socio", "Socio")
                        .WithMany("Cuota")
                        .HasForeignKey("SocioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeonesApi.Models.Tesorero", "Tesorero")
                        .WithMany("Cuota")
                        .HasForeignKey("TesoreroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Socio");

                    b.Navigation("Tesorero");
                });

            modelBuilder.Entity("LeonesApi.Models.Socio", b =>
                {
                    b.Navigation("Cuota");
                });

            modelBuilder.Entity("LeonesApi.Models.Tesorero", b =>
                {
                    b.Navigation("Cuota");
                });
#pragma warning restore 612, 618
        }
    }
}
