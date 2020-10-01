using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReportAPI.Contracts;

namespace ReportAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        private IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("{reportName}")]
        public ActionResult Get(string reportName)
        {
            var returnString = _reportService.GenerateReportAsync(reportName);
            return File(returnString, System.Net.Mime.MediaTypeNames.Application.Octet, reportName + ".pdf");
        }
    }
}