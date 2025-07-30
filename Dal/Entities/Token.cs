using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RMS.Dal.Entities;

[Keyless]
[Table("token", Schema = "cts")]
public partial class Token
{
    [Column("id")]
    public long Id { get; set; }

    [Column("token_number")]
    public long TokenNumber { get; set; }

    [Column("token_date")]
    public DateOnly TokenDate { get; set; }

    /// <summary>
    /// Bill Id
    /// </summary>
    [Column("entity_id")]
    public long EntityId { get; set; }

    [Column("entity_name")]
    [StringLength(200)]
    public string EntityName { get; set; } = null!;

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public long CreatedBy { get; set; }

    [Column("ddo_code")]
    [StringLength(9)]
    public string? DdoCode { get; set; }

    [Column("token_flow_id")]
    public long? TokenFlowId { get; set; }

    [Column("remarks", TypeName = "character varying")]
    public string? Remarks { get; set; }

    [Column("treasury_code")]
    [StringLength(3)]
    public string? TreasuryCode { get; set; }

    [Column("financial_year_id")]
    public short? FinancialYearId { get; set; }

    /// <summary>
    /// Token Current Status
    /// </summary>
    [Column("status")]
    public short? Status { get; set; }

    [Column("module_id")]
    public short? ModuleId { get; set; }

    [Column("payment_advice_id")]
    public long? PaymentAdviceId { get; set; }

    [Column("gross_amount")]
    public long? GrossAmount { get; set; }

    [Column("net_amount")]
    public long? NetAmount { get; set; }

    [Column("bt_amount")]
    public long? BtAmount { get; set; }

    [Column("treasury_bt")]
    public long? TreasuryBt { get; set; }

    [Column("ag_bt")]
    public long? AgBt { get; set; }

    [Column("gst_amount")]
    public long? GstAmount { get; set; }

    [Column("scheme_code")]
    [StringLength(50)]
    public string? SchemeCode { get; set; }

    [Column("voucher_no")]
    [StringLength(15)]
    public string? VoucherNo { get; set; }

    [Column("voucher_id")]
    public long? VoucherId { get; set; }

    [Column("voucher_date")]
    public DateOnly? VoucherDate { get; set; }

    [Column("pfms_lot_id")]
    public long? PfmsLotId { get; set; }

    [Column("rbi_lot_id")]
    public long? RbiLotId { get; set; }

    [Column("status_code")]
    public short? StatusCode { get; set; }

    [Column("current_status")]
    public int? CurrentStatus { get; set; }

    [Column("payment_mode")]
    [StringLength(20)]
    public string? PaymentMode { get; set; }
}
