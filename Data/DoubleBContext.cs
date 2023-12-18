using System;
using System.Collections.Generic;
using DoubleBack.Models;
using Microsoft.EntityFrameworkCore;

namespace DoubleBack.Data;

public partial class DoubleBContext : DbContext
{
    public DoubleBContext()
    {
    }

    public DoubleBContext(DbContextOptions<DoubleBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActiveDelivery> ActiveDeliveries { get; set; }

    public virtual DbSet<CoffeeStorage> CoffeeStorages { get; set; }

    public virtual DbSet<Coffeeshop> Coffeeshops { get; set; }

    public virtual DbSet<DeliveryCompany> DeliveryCompanies { get; set; }

    public virtual DbSet<DeliveryOrder> DeliveryOrders { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Human> Humans { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<UsersAuthentication> UsersAuthentications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DoubleB;Username=postgres;Password=polunin.me");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActiveDelivery>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("active_delivery_pkey");

            entity.ToTable("active_delivery");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Companyid).HasColumnName("companyid");
            entity.Property(e => e.Deliverydate).HasColumnName("deliverydate");
            entity.Property(e => e.Shopid).HasColumnName("shopid");

            entity.HasOne(d => d.Company).WithMany(p => p.ActiveDeliveries)
                .HasForeignKey(d => d.Companyid)
                .HasConstraintName("active_delivery_companyid_fkey");

            entity.HasOne(d => d.Shop).WithMany(p => p.ActiveDeliveries)
                .HasForeignKey(d => d.Shopid)
                .HasConstraintName("active_delivery_shopid_fkey");
        });

        modelBuilder.Entity<CoffeeStorage>(entity =>
        {
            entity.HasKey(e => e.Inventoryid).HasName("coffee_storage_pkey");

            entity.ToTable("coffee_storage");

            entity.Property(e => e.Inventoryid).HasColumnName("inventoryid");
            entity.Property(e => e.Products)
                .HasMaxLength(100)
                .HasColumnName("products");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Shopid).HasColumnName("shopid");

            entity.HasOne(d => d.Shop).WithMany(p => p.CoffeeStorages)
                .HasForeignKey(d => d.Shopid)
                .HasConstraintName("coffee_storage_shopid_fkey");
        });

        modelBuilder.Entity<Coffeeshop>(entity =>
        {
            entity.HasKey(e => e.Shopid).HasName("coffeeshops_pkey");

            entity.ToTable("coffeeshops");

            entity.Property(e => e.Shopid).HasColumnName("shopid");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DeliveryCompany>(entity =>
        {
            entity.HasKey(e => e.Companyid).HasName("delivery_companies_pkey");

            entity.ToTable("delivery_companies");

            entity.Property(e => e.Companyid).HasColumnName("companyid");
            entity.Property(e => e.Companyname)
                .HasMaxLength(100)
                .HasColumnName("companyname");
            entity.Property(e => e.Contactinfo)
                .HasMaxLength(255)
                .HasColumnName("contactinfo");
        });

        modelBuilder.Entity<DeliveryOrder>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("delivery_orders_pkey");

            entity.ToTable("delivery_orders");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Companyid).HasColumnName("companyid");
            entity.Property(e => e.Deliverydate).HasColumnName("deliverydate");
            entity.Property(e => e.Orderdate).HasColumnName("orderdate");
            entity.Property(e => e.Shopid).HasColumnName("shopid");

            entity.HasOne(d => d.Company).WithMany(p => p.DeliveryOrders)
                .HasForeignKey(d => d.Companyid)
                .HasConstraintName("delivery_orders_companyid_fkey");

            entity.HasOne(d => d.Shop).WithMany(p => p.DeliveryOrders)
                .HasForeignKey(d => d.Shopid)
                .HasConstraintName("delivery_orders_shopid_fkey");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.Expenseid).HasName("expenses_pkey");

            entity.ToTable("expenses");

            entity.Property(e => e.Expenseid).HasColumnName("expenseid");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Expensename)
                .HasMaxLength(100)
                .HasColumnName("expensename");
            entity.Property(e => e.Shopid).HasColumnName("shopid");

            entity.HasOne(d => d.Shop).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.Shopid)
                .HasConstraintName("expenses_shopid_fkey");
        });

        modelBuilder.Entity<Human>(entity =>
        {
            entity.HasKey(e => e.Employeeid).HasName("humans_pkey");

            entity.ToTable("humans");

            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Contacts)
                .HasMaxLength(255)
                .HasColumnName("contacts");
            entity.Property(e => e.Income)
                .HasPrecision(10, 2)
                .HasColumnName("income");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Workaddress)
                .HasColumnName("workAddress")
                .HasMaxLength(255);
            entity.Property(e => e.Shopid).HasColumnName("shopid");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");

            entity.HasOne(d => d.Shop).WithMany(p => p.Humans)
                .HasForeignKey(d => d.Shopid)
                .HasConstraintName("humans_shopid_fkey");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Saleid).HasName("sales_pkey");

            entity.ToTable("sales");

            entity.Property(e => e.Saleid).HasColumnName("saleid");
            entity.Property(e => e.Saledate).HasColumnName("saledate");
            entity.Property(e => e.Shopid).HasColumnName("shopid");
            entity.Property(e => e.Totalsales)
                .HasPrecision(10, 2)
                .HasColumnName("totalsales");

            entity.HasOne(d => d.Shop).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Shopid)
                .HasConstraintName("sales_shopid_fkey");
        });

        modelBuilder.Entity<UsersAuthentication>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_authentication_pkey");

            entity.ToTable("users_authentication");

            entity.HasIndex(e => e.Username, "users_authentication_username_key").IsUnique();

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Accesslevel).HasColumnName("accesslevel");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Shopid).HasColumnName("shopid");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Shop).WithMany(p => p.UsersAuthentications)
                .HasForeignKey(d => d.Shopid)
                .HasConstraintName("users_authentication_shopid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
