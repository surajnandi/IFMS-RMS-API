using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMS.Bal.Services.Interfaces;
using RMS.Dal.Entities;
using RMS.Dal.Enums;
using RMS.Helpers;

namespace RMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService) 
        {
            _reportService = reportService;
        }

        [HttpPost("GetFtoSummaryReport")]
        public async Task<IActionResult> GetFtoSummaryReport(QueryParameters queryParameters)
        {
            ServiceResponse<PaginatedResponseObject<IEnumerable<MwBillFtoSummaryReport>>> serviceResponse = new();

            try
            {
                var result = await _reportService.GetFtoSummaryReport(queryParameters);

                if (result == null || !result.Data.Any())
                {
                    serviceResponse.ResponseStatus = ResponseStatus.Warning;
                    serviceResponse.Message = AppConstants.DataNotFound;
                }
                else
                {
                    serviceResponse.ResponseStatus = ResponseStatus.Success;
                    serviceResponse.Message = AppConstants.DataFound;
                    serviceResponse.Result = result;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.ResponseStatus = ResponseStatus.Error;
                serviceResponse.Message = ex.Message;
            }

            return Ok(serviceResponse);
        }

        [HttpPost("ExportFtoSummaryReport")]
        public async Task<IActionResult> ExportFtoSummaryReport(QueryParameters queryParameters)
        {
            var results = await _reportService.GetFtoSummaryReport(queryParameters);

            if (results == null || !results.Data.Any())
                return NotFound("No data to export.");

            var fileBytes = ExcelHelper.ExportToExcel(results.Data, "FTO Summary Report");

            string fileName = $"FtoSummaryReport_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

    }
}
