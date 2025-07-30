using AutoMapper;
using RMS.Bal.Services.Interfaces;
using RMS.Dal.Entities;
using RMS.Dal.Repositories.Interfaces;
using RMS.Helpers;

namespace RMS.Bal.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;
        public ReportService(IReportRepository reportRepository, IMapper mapper) 
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedResponseObject<IEnumerable<MwBillFtoSummaryReport>>> GetFtoSummaryReport(QueryParameters queryParameters)
        {
            return await _reportRepository.GetFtoSummaryReport(queryParameters);
        }
    }
}
