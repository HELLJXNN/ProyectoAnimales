using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoAnimales.Models;

public partial class ProyectoAnimalesContext : DbContext
{
    public ProyectoAnimalesContext()
    {
    }

    public ProyectoAnimalesContext(DbContextOptions<ProyectoAnimalesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animale> Animales { get; set; }

    public virtual DbSet<Propietario> Propietarios { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=JENN\\SQLEXPRESS;Initial Catalog=proyecto_animales;integrated security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animale>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("PK__Animales__A21A7327CE3250B1");

            entity.Property(e => e.AnimalId).HasColumnName("AnimalID");
            entity.Property(e => e.Especie).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.PropietarioId).HasColumnName("PropietarioID");

            entity.HasOne(d => d.Propietario).WithMany(p => p.Animales)
                .HasForeignKey(d => d.PropietarioId)
                .HasConstraintName("FK__Animales__Propie__4BAC3F29");
        });

        modelBuilder.Entity<Propietario>(entity =>
        {
            entity.HasKey(e => e.PropietarioId).HasName("PK__Propieta__BDE3FD656FE2D35B");

            entity.Property(e => e.PropietarioId).HasColumnName("PropietarioID");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Ciudad).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
