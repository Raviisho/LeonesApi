using System;
using System.Collections.Generic;
using LeonesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LeonesApi.Data;

public partial class SmartsofMarcoslescanoContext : DbContext
{
    public SmartsofMarcoslescanoContext()
    {
    }

    public SmartsofMarcoslescanoContext(DbContextOptions<SmartsofMarcoslescanoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cuota> Cuotas { get; set; }

    public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Socio> Socios { get; set; }

    public virtual DbSet<Tesorero> Tesoreros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cuota>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.SocioId, "IX_Cuotas_SocioId");

            entity.HasIndex(e => e.TesoreroId, "IX_Cuotas_TesoreroId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Año).HasColumnType("int(11)");
            entity.Property(e => e.Mes).HasColumnType("int(11)");
            entity.Property(e => e.Monto).HasPrecision(12, 2);
            entity.Property(e => e.SocioId).HasColumnType("int(11)");
            entity.Property(e => e.TesoreroId).HasColumnType("int(11)");

            entity.HasOne(d => d.Socio).WithMany(p => p.Cuota).HasForeignKey(d => d.SocioId);

            entity.HasOne(d => d.Tesorero).WithMany(p => p.Cuota).HasForeignKey(d => d.TesoreroId);
        });

        modelBuilder.Entity<EfmigrationsHistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__EFMigrationsHistory2");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.DateTime).HasMaxLength(6);
            entity.Property(e => e.Egreso).HasPrecision(12, 2);
            entity.Property(e => e.Ingreso).HasPrecision(12, 2);
        });

        modelBuilder.Entity<Socio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ApellidoNombre).HasColumnName("Apellido_Nombre");
            entity.Property(e => e.Dni).HasColumnName("DNI");
        });

        modelBuilder.Entity<Tesorero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ApellidoNombre).HasColumnName("Apellido_Nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.TipoUsuario).HasColumnType("int(11)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
