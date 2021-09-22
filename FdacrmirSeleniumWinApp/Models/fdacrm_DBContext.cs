using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FdacrmirSeleniumWinApp.Models
{
    public partial class fdacrm_DBContext : DbContext
    {
        public fdacrm_DBContext()
        {
        }

        public fdacrm_DBContext(DbContextOptions<fdacrm_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAddress> TblAddresses { get; set; }
        public virtual DbSet<TblBrand> TblBrands { get; set; }
        public virtual DbSet<TblDetail> TblDetails { get; set; }
        public virtual DbSet<TblFactoryName> TblFactoryNames { get; set; }
        public virtual DbSet<TblLog> TblLogs { get; set; }
        public virtual DbSet<TblPackingDetail> TblPackingDetails { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }
        public virtual DbSet<TblTelephoneNumber> TblTelephoneNumbers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=fdacrm_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Persian_100_CI_AS");

            modelBuilder.Entity<TblAddress>(entity =>
            {
                entity.ToTable("Tbl_Address");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FldAddress).HasColumnName("Fld_Address");
            });

            modelBuilder.Entity<TblBrand>(entity =>
            {
                entity.ToTable("Tbl_Brand");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FldBrand)
                    .IsRequired()
                    .HasColumnName("Fld_Brand");
            });

            modelBuilder.Entity<TblDetail>(entity =>
            {
                entity.ToTable("Tbl_Details");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.FldAddressId).HasColumnName("Fld_Address_ID");

                entity.Property(e => e.FldBrandId).HasColumnName("Fld_Brand_ID");

                entity.Property(e => e.FldExpireDate)
                    .HasMaxLength(10)
                    .HasColumnName("Fld_ExpireDate");

                entity.Property(e => e.FldFactoryNameId).HasColumnName("Fld_FactoryName_ID");

                entity.Property(e => e.FldIssueDate)
                    .HasMaxLength(10)
                    .HasColumnName("Fld_IssueDate");

                entity.Property(e => e.FldManufacturingLicenseNumber)
                    .HasMaxLength(8)
                    .HasColumnName("Fld_ManufacturingLicenseNumber");

                entity.Property(e => e.FldPackingDetailsId).HasColumnName("Fld_PackingDetails_ID");

                entity.Property(e => e.FldProductId).HasColumnName("Fld_Product_ID");

                entity.Property(e => e.FldTelephoneNumberId).HasColumnName("Fld_TelephoneNumber_ID");

                entity.HasOne(d => d.FldAddress)
                    .WithMany(p => p.TblDetails)
                    .HasForeignKey(d => d.FldAddressId)
                    .HasConstraintName("FK_Tbl_Details_Tbl_Address");

                entity.HasOne(d => d.FldBrand)
                    .WithMany(p => p.TblDetails)
                    .HasForeignKey(d => d.FldBrandId)
                    .HasConstraintName("FK_Tbl_Details_Tbl_Brand");

                entity.HasOne(d => d.FldPackingDetails)
                    .WithMany(p => p.TblDetails)
                    .HasForeignKey(d => d.FldPackingDetailsId)
                    .HasConstraintName("FK_Tbl_Details_Tbl_PackingDetails");

                entity.HasOne(d => d.FldProduct)
                    .WithMany(p => p.TblDetails)
                    .HasForeignKey(d => d.FldProductId)
                    .HasConstraintName("FK_Tbl_Details_Tbl_Product");

                entity.HasOne(d => d.FldTelephoneNumber)
                    .WithMany(p => p.TblDetails)
                    .HasForeignKey(d => d.FldTelephoneNumberId)
                    .HasConstraintName("FK_Tbl_Details_Tbl_TelephoneNumber");
            });

            modelBuilder.Entity<TblFactoryName>(entity =>
            {
                entity.ToTable("Tbl_FactoryName");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FldFactoryName)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_FactoryName");
            });

            modelBuilder.Entity<TblLog>(entity =>
            {
                entity.ToTable("TblLog");
            });

            modelBuilder.Entity<TblPackingDetail>(entity =>
            {
                entity.ToTable("Tbl_PackingDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FldPackingDetails).HasColumnName("Fld_PackingDetails");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.ToTable("Tbl_Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FldProduct)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("Fld_Product");
            });

            modelBuilder.Entity<TblTelephoneNumber>(entity =>
            {
                entity.ToTable("Tbl_TelephoneNumber");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FldTelephone)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_Telephone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
