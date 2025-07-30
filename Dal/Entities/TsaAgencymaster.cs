using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RMS.Dal.Entities;

[Keyless]
[Table("tsa_agencymaster", Schema = "wbtsa")]
public partial class TsaAgencymaster
{
    [Column("slscode")]
    [StringLength(50)]
    public string? Slscode { get; set; }

    [Column("agencycode")]
    [StringLength(100)]
    public string? Agencycode { get; set; }

    [Column("agencyname")]
    [StringLength(200)]
    public string? Agencyname { get; set; }

    [Column("bankname")]
    [StringLength(200)]
    public string? Bankname { get; set; }

    [Column("ifsccode")]
    [StringLength(20)]
    public string? Ifsccode { get; set; }

    [Column("accountnumber")]
    [StringLength(140)]
    public string? Accountnumber { get; set; }

    [Column("schemehierarchylevel")]
    [StringLength(200)]
    public string? Schemehierarchylevel { get; set; }

    [Column("parentagencycode")]
    [StringLength(100)]
    public string? Parentagencycode { get; set; }

    [Column("entrydate")]
    public DateOnly? Entrydate { get; set; }

    [Column("status")]
    [StringLength(10)]
    public string? Status { get; set; }

    [Column("lastsynced")]
    public DateOnly? Lastsynced { get; set; }

    [Column("syncedby")]
    [StringLength(50)]
    public string? Syncedby { get; set; }

    [Column("designation")]
    [StringLength(120)]
    public string? Designation { get; set; }

    [Column("contact_person_name")]
    [StringLength(255)]
    public string? ContactPersonName { get; set; }

    [Column("agency_phone")]
    [StringLength(15)]
    public string? AgencyPhone { get; set; }

    [Column("id")]
    public long Id { get; set; }
}
