using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UBORA_FASHION_Backend.Models;

public partial class UboraFashionDbContext : DbContext
{
    public UboraFashionDbContext()
    {
    }

    public UboraFashionDbContext(DbContextOptions<UboraFashionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<TCustomer> TCustomers { get; set; }

    public virtual DbSet<TOrder> TOrders { get; set; }

    public virtual DbSet<TOrderLine> TOrderLines { get; set; }

    public virtual DbSet<TOrderLineProduct> TOrderLineProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=UF.Connection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__9834FB9A34EF4804");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("Product_Name");
            entity.Property(e => e.ProductSpec).HasColumnName("Product_Spec");
        });

        modelBuilder.Entity<TCustomer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("PK__T_Custom__2D8FDE5FCEE29954");

            entity.ToTable("T_Customer");

            entity.HasIndex(e => e.EmailCustomer, "UQ__T_Custom__0A045DC7B9D5F6AA").IsUnique();

            entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");
            entity.Property(e => e.AddressCustomer)
                .HasMaxLength(255)
                .HasColumnName("Address_Customer");
            entity.Property(e => e.EmailCustomer)
                .HasMaxLength(100)
                .HasColumnName("Email_Customer");
            entity.Property(e => e.FirstNameCustomer)
                .HasMaxLength(50)
                .HasColumnName("FirstName_Customer");
            entity.Property(e => e.LastNameCustomer)
                .HasMaxLength(50)
                .HasColumnName("LastName_Customer");
            entity.Property(e => e.PhoneNumberCustomer)
                .HasMaxLength(20)
                .HasColumnName("PhoneNumber_Customer");
        });

        modelBuilder.Entity<TOrder>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__T_Order__EC9FA9553A0CC50A");

            entity.ToTable("T_Order");

            entity.Property(e => e.IdOrder).HasColumnName("ID_Order");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.DateCreated).HasColumnName("Date_Created");
            entity.Property(e => e.DateDelivery).HasColumnName("Date_Delivery");
            entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");
            entity.Property(e => e.NoOfDays).HasColumnName("NoOf_Days");
            entity.Property(e => e.OrderDescription).HasColumnName("Order_Description");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(20)
                .HasColumnName("Order_Status");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.TOrders)
                .HasForeignKey(d => d.IdCustomer)
                .HasConstraintName("FK__T_Order__ID_Cust__267ABA7A");
        });

        modelBuilder.Entity<TOrderLine>(entity =>
        {
            entity.HasKey(e => e.IdOrderLine).HasName("PK__T_Order___8338F7448E492051");

            entity.ToTable("T_Order_Line");

            entity.Property(e => e.IdOrderLine).HasColumnName("ID_Order_Line");
            entity.Property(e => e.DescriptionOrderLine)
                .HasMaxLength(255)
                .HasColumnName("Description_Order_Line");
            entity.Property(e => e.IdOrder).HasColumnName("ID_Order");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Unit_Price");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.TOrderLines)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("FK__T_Order_L__ID_Or__2A4B4B5E");
        });

        modelBuilder.Entity<TOrderLineProduct>(entity =>
        {
            entity.HasKey(e => e.IdProductOrderLine).HasName("PK__T_Order___1166CF2992BE623C");

            entity.ToTable("T_Order_Line_product");

            entity.Property(e => e.IdProductOrderLine).HasColumnName("ID_Product_Order_line");
            entity.Property(e => e.IdOrderLine).HasColumnName("ID_Order_Line");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.QuantityOrdered).HasColumnName("Quantity_Ordered");

            entity.HasOne(d => d.IdOrderLineNavigation).WithMany(p => p.TOrderLineProducts)
                .HasForeignKey(d => d.IdOrderLine)
                .HasConstraintName("FK__T_Order_L__ID_Or__2F10007B");

            entity.HasOne(d => d.Product).WithMany(p => p.TOrderLineProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__T_Order_L__Produ__300424B4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
