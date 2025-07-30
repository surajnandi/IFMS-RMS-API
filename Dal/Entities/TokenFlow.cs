using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RMS.Dal.Entities;

[Keyless]
[Table("token_flow", Schema = "cts")]
public partial class TokenFlow
{
    [Column("id")]
    public long Id { get; set; }

    [Column("toke_id")]
    public long TokeId { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("action_taken_by")]
    public long? ActionTakenBy { get; set; }

    [Column("action_taken_at", TypeName = "timestamp without time zone")]
    public DateTime ActionTakenAt { get; set; }

    /// <summary>
    /// 1 = Front Office Clerk
    /// 2 = Accountant
    /// 3 = Treasury Officer
    /// </summary>
    [Column("token_owner_type")]
    public short? TokenOwnerType { get; set; }

    [Column("financial_year_id")]
    public short? FinancialYearId { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }
}
