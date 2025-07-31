using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RMS.Dal.Entities;

[Keyless]
[Table("bill_details", Schema = "billing")]
public partial class BillDetail
{
    [Column("bill_id")]
    public long BillId { get; set; }

    [Column("bill_no")]
    [StringLength(15)]
    public string? BillNo { get; set; }

    [Column("bill_date")]
    public DateOnly BillDate { get; set; }

    [Column("bill_mode")]
    public short? BillMode { get; set; }

    [Column("reference_no")]
    [StringLength(20)]
    public string? ReferenceNo { get; set; }

    [Column("tr_master_id")]
    public short TrMasterId { get; set; }

    [Column("payment_mode")]
    public short PaymentMode { get; set; }

    [Column("financial_year")]
    public short FinancialYear { get; set; }

    [Column("demand")]
    [StringLength(2)]
    public string? Demand { get; set; }

    [Column("major_head")]
    [StringLength(4)]
    public string? MajorHead { get; set; }

    [Column("sub_major_head")]
    [StringLength(2)]
    public string? SubMajorHead { get; set; }

    [Column("minor_head")]
    [StringLength(3)]
    public string? MinorHead { get; set; }

    [Column("plan_status")]
    [StringLength(2)]
    public string? PlanStatus { get; set; }

    [Column("scheme_head")]
    [StringLength(3)]
    public string? SchemeHead { get; set; }

    [Column("detail_head")]
    [StringLength(2)]
    public string? DetailHead { get; set; }

    [Column("voted_charged")]
    [MaxLength(1)]
    public char? VotedCharged { get; set; }

    [Column("gross_amount")]
    public long? GrossAmount { get; set; }

    [Column("net_amount")]
    public long? NetAmount { get; set; }

    [Column("bt_amount")]
    public long? BtAmount { get; set; }

    [Column("sanction_no")]
    [StringLength(25)]
    public string? SanctionNo { get; set; }

    [Column("sanction_amt")]
    public long? SanctionAmt { get; set; }

    [Column("sanction_date")]
    public DateOnly? SanctionDate { get; set; }

    [Column("sanction_by")]
    [StringLength(100)]
    public string? SanctionBy { get; set; }

    [Column("remarks")]
    [StringLength(100)]
    public string? Remarks { get; set; }

    [Column("ddo_code")]
    [StringLength(9)]
    public string? DdoCode { get; set; }

    [Column("is_extended_part_filled")]
    public bool IsExtendedPartFilled { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("treasury_code")]
    [StringLength(3)]
    public string? TreasuryCode { get; set; }

    [Column("is_gem")]
    public bool IsGem { get; set; }

    [Column("status")]
    public short Status { get; set; }

    [Column("created_by_userid")]
    public long? CreatedByUserid { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_by_userid")]
    public long? UpdatedByUserid { get; set; }

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime? UpdatedAt { get; set; }

    [Column("form_version")]
    public short FormVersion { get; set; }

    [Column("form_revision_no")]
    public short FormRevisionNo { get; set; }

    [Column("sna_grant_type")]
    public int? SnaGrantType { get; set; }

    [Column("css_ben_type")]
    public int? CssBenType { get; set; }

    [Column("treasury_bt")]
    public long? TreasuryBt { get; set; }

    [Column("ag_bt")]
    public long? AgBt { get; set; }

    [Column("bill_components", TypeName = "jsonb")]
    public string? BillComponents { get; set; }

    [Column("aafs_project_id")]
    public int? AafsProjectId { get; set; }

    [Column("scheme_code")]
    [StringLength(50)]
    public string? SchemeCode { get; set; }

    [Column("scheme_name")]
    [StringLength(300)]
    public string? SchemeName { get; set; }

    [Column("bill_type")]
    [StringLength(15)]
    public string? BillType { get; set; }

    [Column("is_cancelled")]
    public bool? IsCancelled { get; set; }

    [Column("is_gst")]
    public bool? IsGst { get; set; }

    [Column("gst_amount")]
    public long? GstAmount { get; set; }

    [Column("tr_components", TypeName = "jsonb")]
    public string? TrComponents { get; set; }

    [Column("is_regenerated")]
    public bool? IsRegenerated { get; set; }

    [Column("service_provider_id")]
    public int? ServiceProviderId { get; set; }

    [Column("payee_count")]
    public short? PayeeCount { get; set; }

    [Column("is_reissued")]
    public bool? IsReissued { get; set; }

    [Column("is_cpin_regenerated")]
    public bool? IsCpinRegenerated { get; set; }
}
