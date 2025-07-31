using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RMS.Dal.Entities;

[Keyless]
[Table("tsa_exp_details", Schema = "wbtsa")]
public partial class TsaExpDetail
{
    [Column("id")]
    public long Id { get; set; }

    [Column("last_processing_flag")]
    public short LastProcessingFlag { get; set; }

    [Column("process_log_id")]
    public long? ProcessLogId { get; set; }

    [Column("financial_year")]
    public int FinancialYear { get; set; }

    [Column("ref_no")]
    [StringLength(50)]
    public string RefNo { get; set; } = null!;

    [Column("sls_code")]
    [StringLength(50)]
    public string SlsCode { get; set; } = null!;

    [Column("treas_code")]
    [StringLength(3)]
    public string TreasCode { get; set; } = null!;

    [Column("ddo_code")]
    [StringLength(9)]
    public string DdoCode { get; set; } = null!;

    [Column("exp_for")]
    [StringLength(1)]
    public string? ExpFor { get; set; }

    [Column("officeletter_no")]
    [StringLength(250)]
    public string? OfficeletterNo { get; set; }

    [Column("officeletter_file")]
    public byte[]? OfficeletterFile { get; set; }

    [Column("sanction_date")]
    public DateOnly? SanctionDate { get; set; }

    [Column("payee_count")]
    public int PayeeCount { get; set; }

    /// <summary>
    /// Total voucher amount across all payees (previously gross_amount)
    /// </summary>
    [Column("voucher_amount")]
    [Precision(12, 2)]
    public decimal VoucherAmount { get; set; }

    [Column("net_amount")]
    [Precision(12, 2)]
    public decimal NetAmount { get; set; }

    [Column("narration")]
    public string? Narration { get; set; }

    [Column("maker_id")]
    [StringLength(50)]
    public string MakerId { get; set; } = null!;

    [Column("entry_date")]
    public DateOnly EntryDate { get; set; }

    [Column("mother_senc_no")]
    [StringLength(500)]
    public string? MotherSencNo { get; set; }

    [Column("mother_senc_date")]
    public DateOnly? MotherSencDate { get; set; }

    [Column("maker_check_status")]
    [StringLength(1)]
    public string? MakerCheckStatus { get; set; }

    [Column("maker_check_date")]
    public DateOnly? MakerCheckDate { get; set; }

    [Column("maker_check_remark")]
    public string? MakerCheckRemark { get; set; }

    [Column("checker_check_status")]
    [StringLength(1)]
    public string? CheckerCheckStatus { get; set; }

    [Column("checker_check_date")]
    public DateOnly? CheckerCheckDate { get; set; }

    [Column("checker_check_remark")]
    public string? CheckerCheckRemark { get; set; }

    [Column("agencyid")]
    [StringLength(100)]
    public string Agencyid { get; set; } = null!;

    [Column("freze")]
    [StringLength(1)]
    public string? Freze { get; set; }

    [Column("back_bill_status")]
    [StringLength(1)]
    public string? BackBillStatus { get; set; }

    [Column("attachment_sanction")]
    public byte[]? AttachmentSanction { get; set; }

    [Column("ddo_back")]
    [StringLength(1)]
    public string? DdoBack { get; set; }

    [Column("checker_id")]
    [StringLength(100)]
    public string? CheckerId { get; set; }

    [Column("ddo_back_date")]
    public DateOnly? DdoBackDate { get; set; }

    [Column("ddo_back_remarks")]
    public string? DdoBackRemarks { get; set; }

    [Column("hoa_id")]
    public long HoaId { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("sanction_details", TypeName = "jsonb")]
    public string SanctionDetails { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("fto_uuid")]
    public Guid FtoUuid { get; set; }

    [Column("fto_file_id")]
    public long? FtoFileId { get; set; }

    [Column("is_regenerate")]
    public bool? IsRegenerate { get; set; }

    [Column("old_ref_no")]
    [StringLength(50)]
    public string? OldRefNo { get; set; }

    [Column("fto_version")]
    public int? FtoVersion { get; set; }

    /// <summary>
    /// Sum of all component amounts from linked payees
    /// </summary>
    [Column("component_amount")]
    [Precision(12, 2)]
    public decimal ComponentAmount { get; set; }

    /// <summary>
    /// Total deductions across all associated payees
    /// </summary>
    [Column("ded_amount")]
    [Precision(12, 2)]
    public decimal DedAmount { get; set; }

    /// <summary>
    /// Aggregated GST/TDS amounts from all payees
    /// </summary>
    [Column("gst_amount")]
    [Precision(12, 2)]
    public decimal GstAmount { get; set; }

    [Column("success_net_amount")]
    [Precision(12, 2)]
    public decimal? SuccessNetAmount { get; set; }

    [Column("failed_amount")]
    [Precision(12, 2)]
    public decimal? FailedAmount { get; set; }

    [Column("failed_payee_count")]
    public short? FailedPayeeCount { get; set; }

    [Column("is_reissue")]
    public bool IsReissue { get; set; }

    [Column("agency_master_id")]
    public long? AgencyMasterId { get; set; }

    [Column("gross_amount")]
    [Precision(12, 2)]
    public decimal? GrossAmount { get; set; }

    [Column("fto_mode")]
    public short FtoMode { get; set; }

    [Column("gst_failed_amount")]
    [Precision(12, 2)]
    public decimal? GstFailedAmount { get; set; }

    [Column("is_gst_failed")]
    public bool IsGstFailed { get; set; }

    [Column("gst_failed_count")]
    public short? GstFailedCount { get; set; }

    [Column("success_gross_amount")]
    [Precision(12, 2)]
    public decimal? SuccessGrossAmount { get; set; }

    [Column("success_gst_amount")]
    [Precision(12, 2)]
    public decimal? SuccessGstAmount { get; set; }

    /// <summary>
    /// Indicates the type of FTO (Fund Transfer Order): 
    ///   1000 = JIT (Just-in-Time), 
    ///   1050 = API-based, 
    ///   1100 = TPI (Third-Party Integration). 
    /// Default is 1000 (JIT).
    /// </summary>
    [Column("fto_type")]
    public short FtoType { get; set; }

    /// <summary>
    /// Specifies the module generating the FTO (Fund Transfer Order): 
    ///   2000 = SYSTEM (Default), 
    ///   2010 = FOODDEPT, 
    ///   2020 = OMMAS, 
    ///   2030 = NRLM.
    /// </summary>
    [Column("fto_module")]
    public short FtoModule { get; set; }

    /// <summary>
    /// Defines the scheme funding type: 
    ///   100 = Centrally Sponsored Scheme (CSS), 
    ///   200 = State Sponsored Scheme (SSS). 
    /// Default is 100 (Centrally Sponsored).
    /// </summary>
    [Column("fto_category")]
    public short FtoCategory { get; set; }
}
