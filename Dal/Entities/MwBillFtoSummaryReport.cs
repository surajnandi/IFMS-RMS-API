using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RMS.Dal.Entities;

[Keyless]
public partial class MwBillFtoSummaryReport
{
    [StringLength(200)]
    public string? AgencyName { get; set; }

    [StringLength(100)]
    public string? AgencyCode { get; set; }

    [StringLength(9)]
    public string? DdoCode { get; set; }

    [StringLength(3)]
    public string? TreasuryCode { get; set; }

    [StringLength(50)]
    public string? SlsCode { get; set; }

    [StringLength(50)]
    public string? RefNo { get; set; }

    public short? FtoType { get; set; }

    public DateOnly? EntryDate { get; set; }

    public int? PayeeCount { get; set; }

    [Precision(12, 2)]
    public decimal? GrossAmount { get; set; }

    public DateTime? FtoForwardDate { get; set; }

    [StringLength(15)]
    public string? BillNo { get; set; }

    public DateOnly? BillDate { get; set; }

    public long? TokenNo { get; set; }

    public DateOnly? TokenDate { get; set; }

    public string? DelayByDdo { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? MandateDate { get; set; }

    public string? DelayByTreasury { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? PushToPfmsDate { get; set; }

    public string? DelayInPushingToPfms { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? DnReceiveFromPfmsDate { get; set; }

    public string? DelayInPfmsDn { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? CnReceiveFromRbiDate { get; set; }

    public string? DelayInRbiForCn { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? RbiPaymentFilePushDate { get; set; }

    public string? DelayInRbiPaymentFilePush { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? RbiDnReciveDate { get; set; }

    public string? DelayInRbiForDn { get; set; }

    public string? BillStatus { get; set; }
}
