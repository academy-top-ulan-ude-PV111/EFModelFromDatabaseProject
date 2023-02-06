using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFModelFromDatabaseProject.AppModel;

public partial class AppContext : DbContext
{
    public AppContext()
    {
    }

    public AppContext(DbContextOptions<AppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Employe> Employes { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<ViewCompanye> ViewCompanyes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CompanyDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        
    }
        
         
        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasIndex(e => e.CountryId, "IX_Companies_CountryId");

            entity.HasOne(d => d.Country).WithMany(p => p.Companies).HasForeignKey(d => d.CountryId);
        });

        modelBuilder.Entity<Employe>(entity =>
        {
            entity.HasIndex(e => e.CompanyId, "IX_Employes_CompanyId");

            entity.HasIndex(e => e.PositionId, "IX_Employes_PositionId");

            entity.HasOne(d => d.Company).WithMany(p => p.Employes).HasForeignKey(d => d.CompanyId);

            entity.HasOne(d => d.Position).WithMany(p => p.Employes).HasForeignKey(d => d.PositionId);
        });

        modelBuilder.Entity<ViewCompanye>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Companyes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
