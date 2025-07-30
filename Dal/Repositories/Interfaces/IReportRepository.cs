using RMS.Dal.Entities;
using RMS.Helpers;

namespace RMS.Dal.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Task<PaginatedResponseObject<IEnumerable<MwBillFtoSummaryReport>>> GetFtoSummaryReport(QueryParameters queryParameters);
    }
}
