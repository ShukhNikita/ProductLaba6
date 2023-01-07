using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Product;

public partial class ProductAnalysisContext : DbContext
{
    public ProductAnalysisContext()
    {
    }

    public ProductAnalysisContext(DbContextOptions<ProductAnalysisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivityType> ActivityTypes { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<MeasurementUnit> MeasurementUnits { get; set; }

    public virtual DbSet<OwnershipForm> OwnershipForms { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductReleasePlan> ProductReleasePlans { get; set; }

    public virtual DbSet<ProductSalesPlan> ProductSalesPlans { get; set; }

    public virtual DbSet<ProductionType> ProductionTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-VEHNIKA\\SQLEXPRESS;Initial Catalog=ProductAnalysis;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Activity__3214EC07EAC18D29");

            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Companie__3214EC07DA4A0CFF");

            entity.Property(e => e.Fio)
                .HasMaxLength(150)
                .HasColumnName("FIO");
            entity.Property(e => e.Name).HasMaxLength(150);

            entity.HasOne(d => d.ActivityType).WithMany(p => p.Companies)
                .HasForeignKey(d => d.ActivityTypeId)
                .HasConstraintName("FK__Companies__Activ__29572725");

            entity.HasOne(d => d.OwnershipForm).WithMany(p => p.Companies)
                .HasForeignKey(d => d.OwnershipFormId)
                .HasConstraintName("FK__Companies__Owner__286302EC");
        });

        modelBuilder.Entity<MeasurementUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Measurem__3214EC07613C37C0");

            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<OwnershipForm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ownershi__3214EC079F2AE13A");

            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC074FCF1E1C");

            entity.Property(e => e.Characteristic).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Photo).HasMaxLength(150);

            entity.HasOne(d => d.MeasurementUnit).WithMany(p => p.Products)
                .HasForeignKey(d => d.MeasurementUnitId)
                .HasConstraintName("FK__Products__Measur__2E1BDC42");
        });

        modelBuilder.Entity<ProductReleasePlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductR__3214EC07A07E7867");

            entity.HasOne(d => d.Company).WithMany(p => p.ProductReleasePlans)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__ProductRe__Compa__34C8D9D1");

            entity.HasOne(d => d.ProductionType).WithMany(p => p.ProductReleasePlans)
                .HasForeignKey(d => d.ProductionTypeId)
                .HasConstraintName("FK__ProductRe__Produ__33D4B598");
        });

        modelBuilder.Entity<ProductSalesPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductS__3214EC07097FA3E8");

            entity.HasOne(d => d.Company).WithMany(p => p.ProductSalesPlans)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__ProductSa__Compa__38996AB5");

            entity.HasOne(d => d.ProductionType).WithMany(p => p.ProductSalesPlans)
                .HasForeignKey(d => d.ProductionTypeId)
                .HasConstraintName("FK__ProductSa__Produ__37A5467C");
        });

        modelBuilder.Entity<ProductionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producti__3214EC07CFA195B5");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductionTypes)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Productio__Produ__30F848ED");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
