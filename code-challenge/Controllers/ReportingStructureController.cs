using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using challenge.Services;
using challenge.Models;

namespace challenge.Controllers
{
    [Route("api/reportingStructure")]
    public class ReportingStructureController : Controller
    {
        private readonly ILogger _logger;
        private readonly IReportingStructureService _reportingStructureService;

        public ReportingStructureController(ILogger<ReportingStructureController> logger, IReportingStructureService reportingStructureService)
        {
            _logger = logger;
            _reportingStructureService = reportingStructureService;
        }

        [HttpGet("{id}", Name = "getReportingStructureByEmployeeId")]
        public IActionResult GetEmployeeReportingStructureByEmployeeId(String id)
        {
            _logger.LogDebug($"Received reporting structure get request for employee '{id}'");

            var reportingStructure = _reportingStructureService.GetReportingStructureByEmployeeId(id);

            if (reportingStructure == null)
                return NotFound();

            return Ok(reportingStructure);
        }

    }
}