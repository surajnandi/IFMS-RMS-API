using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RMS.Dal.Entities;

[Keyless]
public partial class MvFtoSummaryByRefno
{
    [Column("ref_no")]
    [StringLength(50)]
    public string? RefNo { get; set; }

    [Column("agency_name")]
    [StringLength(200)]
    public string? AgencyName { get; set; }

    [Column("agency_code")]
    [StringLength(100)]
    public string? AgencyCode { get; set; }

    [Column("ddo_code")]
    [StringLength(9)]
    public string? DdoCode { get; set; }

    [Column("treasury_code")]
    [StringLength(3)]
    public string? TreasuryCode { get; set; }

    [Column("sls_code")]
    [StringLength(50)]
    public string? SlsCode { get; set; }

    [Column("fto_type")]
    public short? FtoType { get; set; }

    [Column("fto_date")]
    public DateOnly? FtoDate { get; set; }

    [Column("payee_count")]
    public int? PayeeCount { get; set; }

    [Column("gross_amount")]
    [Precision(12, 2)]
    public decimal? GrossAmount { get; set; }

    [Column("fto_forward_date", TypeName = "timestamp without time zone")]
    public DateTime? FtoForwardDate { get; set; }

    [Column("bill_no")]
    [StringLength(15)]
    public string? BillNo { get; set; }

    [Column("bill_date")]
    public DateOnly? BillDate { get; set; }

    [Column("token_no")]
    public long? TokenNo { get; set; }

    [Column("token_date")]
    public DateOnly? TokenDate { get; set; }

    [Column("mandate_date", TypeName = "timestamp without time zone")]
    public DateTime? MandateDate { get; set; }

    [Column("push_to_pfms_date", TypeName = "timestamp without time zone")]
    public DateTime? PushToPfmsDate { get; set; }

    [Column("dn_receive_from_pfms_date", TypeName = "timestamp without time zone")]
    public DateTime? DnReceiveFromPfmsDate { get; set; }

    [Column("cn_receive_from_rbi_date", TypeName = "timestamp without time zone")]
    public DateTime? CnReceiveFromRbiDate { get; set; }

    [Column("rbi_payment_file_push_date", TypeName = "timestamp without time zone")]
    public DateTime? RbiPaymentFilePushDate { get; set; }

    [Column("rbi_dn_receive_date", TypeName = "timestamp without time zone")]
    public DateTime? RbiDnReceiveDate { get; set; }

    [Column("delay_by_ddo")]
    public decimal? DelayByDdo { get; set; }

    [Column("delay_by_treasury")]
    public decimal? DelayByTreasury { get; set; }

    [Column("delay_in_pushing_to_pfms")]
    public decimal? DelayInPushingToPfms { get; set; }

    [Column("delay_in_pfms_dn")]
    public decimal? DelayInPfmsDn { get; set; }

    [Column("delay_in_rbi_for_cn")]
    public decimal? DelayInRbiForCn { get; set; }

    [Column("delay_in_rbi_payment_file_push")]
    public decimal? DelayInRbiPaymentFilePush { get; set; }

    [Column("delay_in_rbi_for_dn")]
    public decimal? DelayInRbiForDn { get; set; }

    [Column("last_refreshed")]
    public DateTime? LastRefreshed { get; set; }
}
