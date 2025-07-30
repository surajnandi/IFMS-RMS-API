using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RMS.Bal.Services.Interfaces;
using RMS.Dal.Entities;
using RMS.Dal.Repositories.Interfaces;
using RMS.Helpers;

namespace RMS.Dal.Repositories
{
    public class ReportRepository : IReportRepository
    {
        protected readonly RmsDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        public ReportRepository(RmsDbContext context, IMapper mapper, IAuthService authService)
        { 
            _context = context;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<PaginatedResponseObject<IEnumerable<MwBillFtoSummaryReport>>> GetFtoSummaryReport(QueryParameters queryParameters)
        {
            //var query = _context.MwBillFtoSummaryReports;
            IQueryable<MwBillFtoSummaryReport> query = _context.MwBillFtoSummaryReports.AsQueryable();

            //query = query.Where(x => x.DdoCode == _authService.User.Scope);

            if (queryParameters.Filters.Any())
                query = query.ApplyFilters(queryParameters.Filters);

            query = queryParameters.Sorts.Any()
                ? query.ApplySorts(queryParameters.Sorts)
                : query.OrderByDescending(x => x.EntryDate);

            var allResults = await query.Select(b => new MwBillFtoSummaryReport
            {
                RefNo = b.RefNo,
                AgencyName = b.AgencyName,
                AgencyCode = b.AgencyCode,
                DdoCode = b.DdoCode,
                TreasuryCode = b.TreasuryCode,
                SlsCode = b.SlsCode,
                FtoType = b.FtoType,
                EntryDate = b.EntryDate,
                PayeeCount = b.PayeeCount,
                GrossAmount = b.GrossAmount,
                FtoForwardDate = b.FtoForwardDate,
                BillNo = b.BillNo,
                BillDate = b.BillDate,
                TokenNo = b.TokenNo,
                TokenDate = b.TokenDate,
                MandateDate = b.MandateDate,
                PushToPfmsDate = b.PushToPfmsDate,
                DnReceiveFromPfmsDate = b.DnReceiveFromPfmsDate,
                CnReceiveFromRbiDate = b.CnReceiveFromRbiDate,
                RbiPaymentFilePushDate = b.RbiPaymentFilePushDate,
                RbiDnReciveDate = b.RbiDnReciveDate,
                DelayByDdo = b.DelayByDdo,
                DelayByTreasury = b.DelayByTreasury,
                DelayInPushingToPfms = b.DelayInPushingToPfms,
                DelayInPfmsDn = b.DelayInPfmsDn,
                DelayInRbiForCn = b.DelayInRbiForCn,
                DelayInRbiPaymentFilePush = b.DelayInRbiPaymentFilePush,
                DelayInRbiForDn = b.DelayInRbiForDn,
                BillStatus = b.BillStatus
            }).ToListAsync();

            IEnumerable<MwBillFtoSummaryReport> results = !string.IsNullOrWhiteSpace(queryParameters.GlobalSearch)
            ? allResults.AsQueryable().ApplyGlobalSearch(queryParameters.GlobalSearch)
            : allResults;

            var totalItems = results.Count();

            var paginatedResults = results
                .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
                .Take(queryParameters.PageSize)
                .ToList();

            return new PaginatedResponseObject<IEnumerable<MwBillFtoSummaryReport>>
            {
                TotalCount = totalItems,
                PageSize = queryParameters.PageSize,
                PageNumber = queryParameters.PageNumber,
                Data = paginatedResults
            };
        }

    }
}
