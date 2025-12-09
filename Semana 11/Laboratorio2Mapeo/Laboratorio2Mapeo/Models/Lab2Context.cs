using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio2Mapeo.Models;

public partial class Lab2Context : DbContext
{
    public Lab2Context()
    {
    }

    public Lab2Context(DbContextOptions<Lab2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ComponentesPc> ComponentesPcs { get; set; }
    public object ComponentesPc { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-9C7BQPH\\SQLEXPRESS; Database=Lab2; User Id=sa; Password=1234;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComponentesPc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ComponentesPC");

            entity.Property(e => e.Modelo).HasMaxLength(100);
            entity.Property(e => e.Procesador).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
