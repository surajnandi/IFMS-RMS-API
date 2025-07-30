using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class BillFtoSummaryReportModel
    {
        public string? AgencyName { get; set; }
        public string? AgencyCode { get; set; }
        public string? DdoCode { get; set; }
        public string? TreasuryCode { get; set; }
        public string? SlsCode { get; set; }
        public string? RefNo { get; set; }
        public short? FtoType { get; set; }
        public DateOnly? EntryDate { get; set; }
        public int? PayeeCount { get; set; }
        public decimal? GrossAmount { get; set; }
        public DateTime? FtoForwardDate { get; set; }
        public string? BillNo { get; set; }
        public DateOnly? BillDate { get; set; }
        public long? TokenNo { get; set; }
        public DateOnly? TokenDate { get; set; }
        public string? DelayByDdo { get; set; }
        public DateTime? MandateDate { get; set; }
        public string? DelayByTreasury { get; set; }
        public DateTime? PushToPfmsDate { get; set; }
        public string? DelayInPushingToPfms { get; set; }
        public DateTime? DnReceiveFromPfmsDate { get; set; }
        public string? DelayInPfmsDn { get; set; }
        public DateTime? CnReceiveFromRbiDate { get; set; }
        public string? DelayInRbiForCn { get; set; }
        public DateTime? RbiPaymentFilePushDate { get; set; }
        public string? DelayInRbiPaymentFilePush { get; set; }
        public DateTime? RbiDnReciveDate { get; set; }
        public string? DelayInRbiForDn { get; set; }
        public string? BillStatus { get; set; }
    }
}
