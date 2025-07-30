using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RMS.Dal.Entities;

[Keyless]
[Table("ebill_jit_int_map", Schema = "billing")]
public partial class EbillJitIntMap
{
    [Column("id")]
    public long Id { get; set; }

    [Column("ebill_ref_no")]
    [StringLength(20)]
    public string EbillRefNo { get; set; } = null!;

    [Column("jit_ref_no")]
    [StringLength(50)]
    public string JitRefNo { get; set; } = null!;

    [Column("is_active")]
    public bool? IsActive { get; set; }

    [Column("error_details", TypeName = "jsonb")]
    public string? ErrorDetails { get; set; }

    [Column("is_rejected")]
    public bool? IsRejected { get; set; }

    [Column("bill_id")]
    public long BillId { get; set; }

    [Column("file_name")]
    [StringLength(32)]
    public string? FileName { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    [Column("financial_year")]
    public short? FinancialYear { get; set; }
}
