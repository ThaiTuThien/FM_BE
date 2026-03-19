using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FM.Domain.Entities;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EncryptionKey> EncryptionKeys { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentCard> PaymentCards { get; set; }

    public virtual DbSet<PaymentVnpay> PaymentVnpays { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productdetail> Productdetails { get; set; }

    public virtual DbSet<Purchaseorder> Purchaseorders { get; set; }

    public virtual DbSet<Purchaseorderdetail> Purchaseorderdetails { get; set; }

    public virtual DbSet<Purchasepayment> Purchasepayments { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<Shiftlog> Shiftlogs { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<VSalesReport> VSalesReports { get; set; }

    public virtual DbSet<VSalesReportStore> VSalesReportStores { get; set; }

    public virtual DbSet<VWarehouseStock> VWarehouseStocks { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=FAMILY_MART_PROJECT;Password=123;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("FAMILY_MART_PROJECT")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Accountid).HasName("PK_ACCOUNT");

            entity.ToTable("ACCOUNTS");

            entity.HasIndex(e => e.Username, "SYS_C008269").IsUnique();

            entity.Property(e => e.Accountid)
                .HasDefaultValueSql("SYS_GUID() ")
                .HasColumnName("ACCOUNTID");
            entity.Property(e => e.Employid).HasColumnName("EMPLOYID");
            entity.Property(e => e.Passwordhash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORDHASH");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.Employ).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.Employid)
                .HasConstraintName("FK_ACCOUNT_EMPLOYEE");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("CATEGORY");

            entity.Property(e => e.Categoryid)
                .HasDefaultValueSql("SYS_GUID() ")
                .HasColumnName("CATEGORYID");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CATEGORYNAME");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("CUSTOMER");

            entity.Property(e => e.Customerid)
                .HasDefaultValueSql("SYS_GUID() ")
                .HasColumnName("CUSTOMERID");
            entity.Property(e => e.Customeremail)
                .HasMaxLength(200)
                .ValueGeneratedOnAdd()
                .HasColumnName("CUSTOMEREMAIL");
            entity.Property(e => e.Customername)
                .HasMaxLength(200)
                .ValueGeneratedOnAdd()
                .HasColumnName("CUSTOMERNAME");
            entity.Property(e => e.Customerphonenumber)
                .HasMaxLength(200)
                .ValueGeneratedOnAdd()
                .HasColumnName("CUSTOMERPHONENUMBER");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Employid);

            entity.ToTable("EMPLOYEE");

            entity.HasIndex(e => e.Employname, "IDX_EMPLOYEE_NAME");

            entity.Property(e => e.Employid)
                .HasDefaultValueSql("SYS_GUID() ")
                .HasColumnName("EMPLOYID");
            entity.Property(e => e.Employbirth)
                .HasColumnType("DATE")
                .HasColumnName("EMPLOYBIRTH");
            entity.Property(e => e.Employname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMPLOYNAME");
            entity.Property(e => e.Employonboarddate)
                .HasColumnType("DATE")
                .HasColumnName("EMPLOYONBOARDDATE");
            entity.Property(e => e.Employphonenumber)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("EMPLOYPHONENUMBER");
            entity.Property(e => e.Employrole)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMPLOYROLE");
            entity.Property(e => e.Storeid).HasColumnName("STOREID");

            entity.HasOne(d => d.Store).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Storeid)
                .HasConstraintName("FK_EMP_STORE");
        });

        modelBuilder.Entity<EncryptionKey>(entity =>
        {
            entity.HasKey(e => e.Keyid).HasName("SYS_C008290");

            entity.ToTable("ENCRYPTION_KEY");

            entity.Property(e => e.Keyid)
                .HasColumnType("NUMBER")
                .HasColumnName("KEYID");
            entity.Property(e => e.Secretkey)
                .HasMaxLength(32)
                .HasColumnName("SECRETKEY");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("PK_ORDER");

            entity.ToTable("ORDERS");

            entity.HasIndex(e => new { e.Storeid, e.Orderdate }, "IDX_ORDER_STORE_DATE");

            entity.Property(e => e.Orderid)
                .HasDefaultValueSql("SYS_GUID() ")
                .HasColumnName("ORDERID");
            entity.Property(e => e.Customerid).HasColumnName("CUSTOMERID");
            entity.Property(e => e.Employid).HasColumnName("EMPLOYID");
            entity.Property(e => e.Orderdate)
                .HasColumnType("DATE")
                .HasColumnName("ORDERDATE");
            entity.Property(e => e.Orderpaystatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ORDERPAYSTATUS");
            entity.Property(e => e.Ordertotalprice)
                .HasColumnType("NUMBER")
                .HasColumnName("ORDERTOTALPRICE");
            entity.Property(e => e.Storeid).HasColumnName("STOREID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("FK_ORDER_CUSTOMER");

            entity.HasOne(d => d.Employ).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Employid)
                .HasConstraintName("FK_ORDER_EMPLOYEE");

            entity.HasOne(d => d.Store).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Storeid)
                .HasConstraintName("FK_ORDER_STORE");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.ToTable("ORDERDETAIL");

            entity.HasIndex(e => e.Orderid, "IDX_ORDERDETAIL_ORDER");

            entity.Property(e => e.Orderdetailid)
                .HasDefaultValueSql("SYS_GUID() ")
                .HasColumnName("ORDERDETAILID");
            entity.Property(e => e.Orderid)
                .HasColumnName("ORDERID");
            entity.Property(e => e.Productid)
                .HasColumnName("PRODUCTID");
            entity.Property(e => e.Quantity)
                .HasColumnType("NUMBER")
                .HasColumnName("QUANTITY");
            entity.Property(e => e.Subtotal)
                .HasColumnType("NUMBER")
                .HasColumnName("SUBTOTAL");
            entity.Property(e => e.Unitprice)
                .HasColumnType("NUMBER")
                .HasColumnName("UNITPRICE");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("FK_ORDERDETAIL_ORDER");

            entity.HasOne(d => d.Product).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("FK_ORDERDETAIL_PRODUCT");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Paymentid).HasName("SYS_C008274");

            entity.ToTable("PAYMENT");

            entity.Property(e => e.Paymentid)
                .HasDefaultValueSql("SYS_GUID() ")
                .HasColumnName("PAYMENTID");
            entity.Property(e => e.Orderid)
                .ValueGeneratedOnAdd()
                .HasColumnName("ORDERID");
            entity.Property(e => e.Paymentamount)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("PAYMENTAMOUNT");
            entity.Property(e => e.Paymentdate)
                .HasDefaultValueSql("SYSDATE")
                .HasColumnType("DATE")
                .HasColumnName("PAYMENTDATE");
            entity.Property(e => e.Paymentmethod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PAYMENTMETHOD");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("FK_PAYMENT_ORDER");
        });

        modelBuilder.Entity<PaymentCard>(entity =>
        {
            entity.HasKey(e => e.Paymentid).HasName("SYS_C008288");

            entity.ToTable("PAYMENT_CARD");

            entity.Property(e => e.Paymentid)
                .ValueGeneratedNever()
                .HasColumnName("PAYMENTID");
            entity.Property(e => e.Cardnumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CARDNUMBER");
            entity.Property(e => e.Cardtype)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CARDTYPE");

            entity.HasOne(d => d.Payment).WithOne(p => p.PaymentCard)
                .HasForeignKey<PaymentCard>(d => d.Paymentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CARD_PAYMENT");
        });

        modelBuilder.Entity<PaymentVnpay>(entity =>
        {
            entity.HasKey(e => e.Paymentid).HasName("SYS_C008285");

            entity.ToTable("PAYMENT_VNPAY");

            entity.Property(e => e.Paymentid)
                .ValueGeneratedNever()
                .HasColumnName("PAYMENTID");
            entity.Property(e => e.Transactioncode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TRANSACTIONCODE");

            entity.HasOne(d => d.Payment).WithOne(p => p.PaymentVnpay)
                .HasForeignKey<PaymentVnpay>(d => d.Paymentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VNPAY_PAYMENT");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("PK_PRODUCT");

            entity.ToTable("PRODUCTS");

            entity.HasIndex(e => e.Productname, "IDX_PRODUCT_NAME");

            entity.Property(e => e.Productid)
                .HasDefaultValueSql("SYS_GUID() ")
                .HasColumnName("PRODUCTID");
            entity.Property(e => e.Categoryid).HasColumnName("CATEGORYID");
            entity.Property(e => e.Prodes)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PRODES");
            entity.Property(e => e.Productname)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("PRODUCTNAME");
            entity.Property(e => e.Supplierid).HasColumnName("SUPPLIERID");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.Categoryid)
                .HasConstraintName("FK_PRODUCT_CATEGORY");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.Supplierid)
                .HasConstraintName("FK_PRODUCT_SUPPLIER");
        });

        modelBuilder.Entity<Productdetail>(entity =>
        {
            entity.HasKey(e => e.Productdetail1);

            entity.ToTable("PRODUCTDETAIL");

            entity.Property(e => e.Productdetail1)
                .HasDefaultValueSql("SYS_GUID() ")
                .HasColumnName("PRODUCTDETAIL");
            entity.Property(e => e.Productid).HasColumnName("PRODUCTID");
            entity.Property(e => e.Productprice)
                .HasColumnType("NUMBER")
                .HasColumnName("PRODUCTPRICE");

            entity.HasOne(d => d.Product).WithMany(p => p.Productdetails)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("FK_PRODUCTDETAIL_PRODUCT");
        });

        modelBuilder.Entity<Purchaseorder>(entity =>
        {
            entity.ToTable("PURCHASEORDER");

            entity.HasIndex(e => new { e.Storeid, e.Purchaseorderdate }, "IDX_PURCHASE_STORE_DATE");

            entity.Property(e => e.Purchaseorderid)
                .HasDefaultValueSql("SYS_GUID() ")
                .HasColumnName("PURCHASEORDERID");
            entity.Property(e => e.Employid).HasColumnName("EMPLOYID");
            entity.Property(e => e.Purchaseorderdate)
                .HasColumnType("DATE")
                .HasColumnName("PURCHASEORDERDATE");
            entity.Property(e => e.Purchaseorderstatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PURCHASEORDERSTATUS");
            entity.Property(e => e.Storeid).HasColumnName("STOREID");
            entity.Property(e => e.Supplierid).HasColumnName("SUPPLIERID");
            entity.Property(e => e.Totalamount)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTALAMOUNT");

            entity.HasOne(d => d.Employ).WithMany(p => p.Purchaseorders)
                .HasForeignKey(d => d.Employid)
                .HasConstraintName("FK_PURCHASEORDER_EMPLOYEE");

            entity.HasOne(d => d.Store).WithMany(p => p.Purchaseorders)
                .HasForeignKey(d => d.Storeid)
                .HasConstraintName("FK_PURCHASEORDER_STORE");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Purchaseorders)
                .HasForeignKey(d => d.Supplierid)
                .HasConstraintName("FK_PURCHASE_SUPPLIER");
        });

        modelBuilder.Entity<Purchaseorderdetail>(entity =>
        {
            entity.HasKey(e => e.Purchaseorderdetailid).HasName("SYS_C008262");

            entity.ToTable("PURCHASEORDERDETAIL");

            entity.HasIndex(e => e.Purchaseorderid, "IDX_PURCHASEDETAIL_ORDER");

            entity.Property(e => e.Purchaseorderdetailid)
                .HasDefaultValueSql("SYS_GUID() ")
                .HasColumnName("PURCHASEORDERDETAILID");
            entity.Property(e => e.Importprice)
                .HasColumnType("NUMBER")
                .HasColumnName("IMPORTPRICE");
            entity.Property(e => e.Productid)
                .HasColumnName("PRODUCTID");
            entity.Property(e => e.Purchaseorderid)
                .HasColumnName("PURCHASEORDERID");
            entity.Property(e => e.Quantity)
                .HasColumnType("NUMBER")
                .HasColumnName("QUANTITY");
            entity.Property(e => e.Subtotal)
                .HasColumnType("NUMBER")
                .HasColumnName("SUBTOTAL");

            entity.HasOne(d => d.Product).WithMany(p => p.Purchaseorderdetails)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("FK_PURCHASEORDERDETAIL_PRODUCT");

            entity.HasOne(d => d.Purchaseorder).WithMany(p => p.Purchaseorderdetails)
                .HasForeignKey(d => d.Purchaseorderid)
                .HasConstraintName("FK_PURCHASEORDERDETAIL_PURCHASEORDER");
        });

        modelBuilder.Entity<Purchasepayment>(entity =>
        {
            entity.HasKey(e => e.Paymentid).HasName("SYS_C008278");

            entity.ToTable("PURCHASEPAYMENT");

            entity.HasIndex(e => e.Purchaseorderid, "SYS_C008279").IsUnique();

            entity.Property(e => e.Paymentid)
                .HasDefaultValueSql("SYS_GUID() ")
                .HasColumnName("PAYMENTID");
            entity.Property(e => e.Paymentamount)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("PAYMENTAMOUNT");
            entity.Property(e => e.Paymentdate)
                .HasDefaultValueSql("SYSDATE")
                .HasColumnType("DATE")
                .HasColumnName("PAYMENTDATE");
            entity.Property(e => e.Paymentmethod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("'VNPAY'")
                .HasColumnName("PAYMENTMETHOD");
            entity.Property(e => e.Purchaseorderid)
                .ValueGeneratedOnAdd()
                .HasColumnName("PURCHASEORDERID");

            entity.HasOne(d => d.Purchaseorder).WithOne(p => p.Purchasepayment)
                .HasForeignKey<Purchasepayment>(d => d.Purchaseorderid)
                .HasConstraintName("FK_PURCHASE_PAYMENT");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.ToTable("SHIFT");

            entity.Property(e => e.Shiftid)
                .HasDefaultValueSql("SYS_GUID() ")
                .HasColumnName("SHIFTID");
            entity.Property(e => e.Endtime)
                .HasColumnType("DATE")
                .HasColumnName("ENDTIME");
            entity.Property(e => e.Starttime)
                .HasColumnType("DATE")
                .HasColumnName("STARTTIME");
            entity.Property(e => e.Storeid).HasColumnName("STOREID");

            entity.HasOne(d => d.Store).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.Storeid)
                .HasConstraintName("FK_SHIFT_STORE");
        });

        modelBuilder.Entity<Shiftlog>(entity =>
        {
            entity.ToTable("SHIFTLOG");

            entity.Property(e => e.Shiftlogid)
                .HasDefaultValueSql("SYS_GUID() ")
                .HasColumnName("SHIFTLOGID");
            entity.Property(e => e.Employid).HasColumnName("EMPLOYID");
            entity.Property(e => e.Shiftdate)
                .HasColumnType("DATE")
                .HasColumnName("SHIFTDATE");
            entity.Property(e => e.Shiftid).HasColumnName("SHIFTID");

            entity.HasOne(d => d.Employ).WithMany(p => p.Shiftlogs)
                .HasForeignKey(d => d.Employid)
                .HasConstraintName("FK_SHIFTLOG_EMPLOYEE");

            entity.HasOne(d => d.Shift).WithMany(p => p.Shiftlogs)
                .HasForeignKey(d => d.Shiftid)
                .HasConstraintName("FK_SHIFTLOG_SHIFT");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.Storeid).HasName("PK_STORE");

            entity.ToTable("STORES");

            entity.Property(e => e.Storeid)
                .HasDefaultValueSql("SYS_GUID() ")
                .HasColumnName("STOREID");
            entity.Property(e => e.Storeaddress)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("STOREADDRESS");
            entity.Property(e => e.Storecontactinfo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("STORECONTACTINFO");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("SUPPLIER");

            entity.Property(e => e.Supplierid)
                .HasDefaultValueSql("SYS_GUID() ")
                .HasColumnName("SUPPLIERID");
            entity.Property(e => e.Supplieraddress)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SUPPLIERADDRESS");
            entity.Property(e => e.Supplieremail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SUPPLIEREMAIL");
            entity.Property(e => e.Suppliername)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SUPPLIERNAME");
        });

        modelBuilder.Entity<VSalesReport>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_SALES_REPORT");

            entity.Property(e => e.Orderdate)
                .HasColumnType("DATE")
                .HasColumnName("ORDERDATE");
            entity.Property(e => e.Revenue)
                .HasColumnType("NUMBER")
                .HasColumnName("REVENUE");
        });

        modelBuilder.Entity<VSalesReportStore>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_SALES_REPORT_STORES");

            entity.Property(e => e.Orderdate)
                .HasColumnType("DATE")
                .HasColumnName("ORDERDATE");
            entity.Property(e => e.Revenue)
                .HasColumnType("NUMBER")
                .HasColumnName("REVENUE");
            entity.Property(e => e.Storeaddress)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("STOREADDRESS");
        });

        modelBuilder.Entity<VWarehouseStock>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_WAREHOUSE_STOCK");

            entity.Property(e => e.Productname)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("PRODUCTNAME");
            entity.Property(e => e.Quantity)
                .HasColumnType("NUMBER")
                .HasColumnName("QUANTITY");
            entity.Property(e => e.Storeaddress)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("STOREADDRESS");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => new { e.Storeid, e.Productid });

            entity.ToTable("WAREHOUSE");

            entity.Property(e => e.Storeid).HasColumnName("STOREID");
            entity.Property(e => e.Productid).HasColumnName("PRODUCTID");
            entity.Property(e => e.Quantity)
                .HasColumnType("NUMBER")
                .HasColumnName("QUANTITY");

            entity.HasOne(d => d.Product).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WAREHOUSE_PRODUCT");

            entity.HasOne(d => d.Store).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.Storeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WAREHOUSE_STORE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
