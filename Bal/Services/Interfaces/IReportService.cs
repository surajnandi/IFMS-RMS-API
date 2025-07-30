using RMS.Dal.Entities;
using RMS.Helpers;

namespace RMS.Bal.Services.Interfaces
{
    public interface IReportService
    {
        Task<PaginatedResponseObject<IEnumerable<MwBillFtoSummaryReport>>> GetFtoSummaryReport(QueryParameters queryParameters);
    }
}
