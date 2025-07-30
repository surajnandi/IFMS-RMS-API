using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RMS.Dal.Entities;

namespace RMS.Dal;

public partial class RmsDbContext : DbContext
{
    public RmsDbContext()
    {
    }

    public RmsDbContext(DbContextOptions<RmsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EbillJitIntMap> EbillJitIntMaps { get; set; }

    public virtual DbSet<JitBillDetail> JitBillDetails { get; set; }

    public virtual DbSet<MvFtoSummaryByRefno> MvFtoSummaryByRefnos { get; set; }

    public virtual DbSet<MwBillFtoSummaryReport> MwBillFtoSummaryReports { get; set; }

    public virtual DbSet<ProcessLog> ProcessLogs { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<TokenFlow> TokenFlows { get; set; }

    public virtual DbSet<TsaAgencymaster> TsaAgencymasters { get; set; }

    public virtual DbSet<TsaExpDetail> TsaExpDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:DBConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EbillJitIntMap>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.EbillRefNo).IsFixedLength();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsRejected).HasDefaultValue(false);
        });

        modelBuilder.Entity<JitBillDetail>(entity =>
        {
            entity.Property(e => e.BillNo).IsFixedLength();
            entity.Property(e => e.BillType).IsFixedLength();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.DdoCode).IsFixedLength();
            entity.Property(e => e.Demand).IsFixedLength();
            entity.Property(e => e.DetailHead).IsFixedLength();
            entity.Property(e => e.FormRevisionNo).HasDefaultValue((short)1);
            entity.Property(e => e.FormVersion).HasDefaultValue((short)1);
            entity.Property(e => e.GstAmount).HasDefaultValue(0L);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.IsExtendedPartFilled).HasDefaultValue(false);
            entity.Property(e => e.IsGem).HasDefaultValue(false);
            entity.Property(e => e.IsGst).HasDefaultValue(false);
            entity.Property(e => e.MajorHead).IsFixedLength();
            entity.Property(e => e.MinorHead).IsFixedLength();
            entity.Property(e => e.PlanStatus).IsFixedLength();
            entity.Property(e => e.ReceivedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Actual Date when bill is being received from JIT-Billing");
            entity.Property(e => e.ReferenceNo).IsFixedLength();
            entity.Property(e => e.SchemeHead).IsFixedLength();
            entity.Property(e => e.SubMajorHead).IsFixedLength();
            entity.Property(e => e.TreasuryCode).IsFixedLength();
        });

        modelBuilder.Entity<MvFtoSummaryByRefno>(entity =>
        {
            entity.ToView("mv_fto_summary_by_refno");

            entity.Property(e => e.BillNo).IsFixedLength();
        });

        modelBuilder.Entity<MwBillFtoSummaryReport>(entity =>
        {
            entity.ToView("mw_bill_fto_summary_report");

            entity.Property(e => e.BillNo).IsFixedLength();
        });

        modelBuilder.Entity<ProcessLog>(entity =>
        {
            entity.Property(e => e.EntryDate).HasDefaultValueSql("now()");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.Property(e => e.AgBt).HasDefaultValue(0L);
            entity.Property(e => e.BtAmount).HasDefaultValue(0L);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.DdoCode).IsFixedLength();
            entity.Property(e => e.EntityId).HasComment("Bill Id");
            entity.Property(e => e.EntityName).IsFixedLength();
            entity.Property(e => e.GrossAmount).HasDefaultValue(0L);
            entity.Property(e => e.GstAmount).HasDefaultValue(0L);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.NetAmount).HasDefaultValue(0L);
            entity.Property(e => e.Status).HasComment("Token Current Status");
            entity.Property(e => e.TreasuryBt).HasDefaultValue(0L);
            entity.Property(e => e.TreasuryCode).IsFixedLength();
        });

        modelBuilder.Entity<TokenFlow>(entity =>
        {
            entity.Property(e => e.ActionTakenAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.TokenOwnerType).HasComment("1 = Front Office Clerk\n2 = Accountant\n3 = Treasury Officer");
        });

        modelBuilder.Entity<TsaAgencymaster>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
