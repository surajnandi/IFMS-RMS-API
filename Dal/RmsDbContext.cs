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

    public virtual DbSet<BillDetail> BillDetails { get; set; }

    public virtual DbSet<EbillJitIntMap> EbillJitIntMaps { get; set; }

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
        modelBuilder.Entity<BillDetail>(entity =>
        {
            entity.Property(e => e.AgBt).HasDefaultValue(0L);
            entity.Property(e => e.BillId).ValueGeneratedOnAdd();
            entity.Property(e => e.BillMode).HasDefaultValue((short)0);
            entity.Property(e => e.BillNo).IsFixedLength();
            entity.Property(e => e.BtAmount).HasDefaultValue(0L);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.DdoCode).IsFixedLength();
            entity.Property(e => e.Demand).IsFixedLength();
            entity.Property(e => e.DetailHead).IsFixedLength();
            entity.Property(e => e.FormRevisionNo).HasDefaultValue((short)1);
            entity.Property(e => e.FormVersion).HasDefaultValue((short)1);
            entity.Property(e => e.GrossAmount).HasDefaultValue(0L);
            entity.Property(e => e.GstAmount).HasDefaultValue(0L);
            entity.Property(e => e.IsCancelled).HasDefaultValue(false);
            entity.Property(e => e.IsCpinRegenerated).HasDefaultValue(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.IsExtendedPartFilled).HasDefaultValue(false);
            entity.Property(e => e.IsGem).HasDefaultValue(false);
            entity.Property(e => e.IsGst).HasDefaultValue(false);
            entity.Property(e => e.IsRegenerated).HasDefaultValue(false);
            entity.Property(e => e.IsReissued).HasDefaultValue(false);
            entity.Property(e => e.MajorHead).IsFixedLength();
            entity.Property(e => e.MinorHead).IsFixedLength();
            entity.Property(e => e.NetAmount).HasDefaultValue(0L);
            entity.Property(e => e.PlanStatus).IsFixedLength();
            entity.Property(e => e.ReferenceNo).IsFixedLength();
            entity.Property(e => e.SanctionAmt).HasDefaultValue(0L);
            entity.Property(e => e.SchemeHead).IsFixedLength();
            entity.Property(e => e.SubMajorHead).IsFixedLength();
            entity.Property(e => e.TreasuryBt).HasDefaultValue(0L);
            entity.Property(e => e.TreasuryCode).IsFixedLength();
        });

        modelBuilder.Entity<EbillJitIntMap>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.EbillRefNo).IsFixedLength();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsRejected).HasDefaultValue(false);
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

        modelBuilder.Entity<TsaExpDetail>(entity =>
        {
            entity.Property(e => e.ComponentAmount).HasComment("Sum of all component amounts from linked payees");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.DedAmount).HasComment("Total deductions across all associated payees");
            entity.Property(e => e.FinancialYear).HasDefaultValueSql("get_active_fin_year()");
            entity.Property(e => e.FtoCategory)
                .HasDefaultValue((short)100)
                .HasComment("Defines the scheme funding type: \n  100 = Centrally Sponsored Scheme (CSS), \n  200 = State Sponsored Scheme (SSS). \nDefault is 100 (Centrally Sponsored).");
            entity.Property(e => e.FtoMode).HasDefaultValue((short)0);
            entity.Property(e => e.FtoModule)
                .HasDefaultValue((short)2000)
                .HasComment("Specifies the module generating the FTO (Fund Transfer Order): \n  2000 = SYSTEM (Default), \n  2010 = FOODDEPT, \n  2020 = OMMAS, \n  2030 = NRLM.");
            entity.Property(e => e.FtoType)
                .HasDefaultValue((short)1000)
                .HasComment("Indicates the type of FTO (Fund Transfer Order): \n  1000 = JIT (Just-in-Time), \n  1050 = API-based, \n  1100 = TPI (Third-Party Integration). \nDefault is 1000 (JIT).");
            entity.Property(e => e.FtoUuid).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.GstAmount).HasComment("Aggregated GST/TDS amounts from all payees");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.IsGstFailed).HasDefaultValue(false);
            entity.Property(e => e.IsRegenerate).HasDefaultValue(false);
            entity.Property(e => e.IsReissue).HasDefaultValue(false);
            entity.Property(e => e.VoucherAmount).HasComment("Total voucher amount across all payees (previously gross_amount)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
