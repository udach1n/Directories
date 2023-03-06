using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace testWeb.Models;

public partial class DirectoriesContext : DbContext
{
    public DirectoriesContext()
    {
    }

    public DirectoriesContext(DbContextOptions<DirectoriesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Directory> Directory { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Directories;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Directory>()
             .HasOne(d => d.Parent)
             .WithMany(d => d.Children)
             .HasForeignKey(d => d.IdParentDirectory);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
