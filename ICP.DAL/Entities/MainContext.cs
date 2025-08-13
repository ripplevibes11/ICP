using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ICP.DAL.Entities;

public partial class MainContext : DbContext
{
    public MainContext()
    {
    }

    public MainContext(DbContextOptions<MainContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OTPVerification> OTPVerifications { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCreditCard> UserCreditCards { get; set; }

    public virtual DbSet<UserDebitCard> UserDebitCards { get; set; }

    public virtual DbSet<UserEmiratesInfo> UserEmiratesInfos { get; set; }

    public virtual DbSet<UserLoanBank> UserLoanBanks { get; set; }

    public virtual DbSet<UserLoanInfo> UserLoanInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=XEVEN-LAPTOP-02;Database=ICPSmartServices;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OTPVerification>(entity =>
        {
            entity.HasKey(e => e.OTPID);

            entity.ToTable("OTPVerification");

            entity.Property(e => e.IsVerified).HasDefaultValue(false);
            entity.Property(e => e.OTPCode).HasMaxLength(10);
            entity.Property(e => e.SentAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.OTPVerifications)
                .HasForeignKey(d => d.UserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OTPVerification_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmailAddress).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.MobileNumber).HasMaxLength(20);
        });

        modelBuilder.Entity<UserCreditCard>(entity =>
        {
            entity.HasKey(e => e.CreditCardID);

            entity.Property(e => e.AvailableBalance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CVV)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CardNumber).HasMaxLength(20);
            entity.Property(e => e.ExpiryDate)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.User).WithMany(p => p.UserCreditCards)
                .HasForeignKey(d => d.UserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserCreditCards_Users");
        });

        modelBuilder.Entity<UserDebitCard>(entity =>
        {
            entity.HasKey(e => e.DebitCardID);

            entity.Property(e => e.AvailableBalance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CVV)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CardNumber).HasMaxLength(20);
            entity.Property(e => e.ExpiryDate)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.User).WithMany(p => p.UserDebitCards)
                .HasForeignKey(d => d.UserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserDebitCards_Users");
        });

        modelBuilder.Entity<UserEmiratesInfo>(entity =>
        {
            entity.HasKey(e => e.EmiratesInfoID);

            entity.ToTable("UserEmiratesInfo");

            entity.Property(e => e.EmiratesID).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.UserEmiratesInfos)
                .HasForeignKey(d => d.UserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserEmiratesInfo_Users");
        });

        modelBuilder.Entity<UserLoanBank>(entity =>
        {
            entity.HasKey(e => e.LoanBankID);

            entity.Property(e => e.BankName).HasMaxLength(100);

            entity.HasOne(d => d.LoanInfo).WithMany(p => p.UserLoanBanks)
                .HasForeignKey(d => d.LoanInfoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserLoanBanks_UserLoanInfo");
        });

        modelBuilder.Entity<UserLoanInfo>(entity =>
        {
            entity.HasKey(e => e.LoanInfoID);

            entity.ToTable("UserLoanInfo");

            entity.Property(e => e.VerificationMethod).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.UserLoanInfos)
                .HasForeignKey(d => d.UserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserLoanInfo_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
