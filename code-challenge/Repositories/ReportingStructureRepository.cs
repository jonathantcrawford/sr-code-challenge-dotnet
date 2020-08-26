using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using challenge.Data;

namespace challenge.Repositories
{
    public class ReportingStructureRespository : IReportingStructureRepository
    {
        private readonly EmployeeContext _employeeContext;
        private readonly ILogger<IReportingStructureRepository> _logger;

        public ReportingStructureRespository(ILogger<IReportingStructureRepository> logger, EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _logger = logger;
        }


        public ReportingStructure GetReportingStructureByEmployeeId(string id)
        {
            ReportingStructure reportingStructure = new ReportingStructure();
            reportingStructure.Employee = _employeeContext.GetById(id);
            reportingStructure.NumberOfReports = GetNumberOfReportsById(id);
            return reportingStructure;
        }

        private int GetNumberOfReportsById(string id)
        {
            int count = 0;
            Employee employee = _employeeContext.GetById(id);
            if (employee.DirectReports == null) return count;
            count = employee.DirectReports.Count;
            employee.DirectReports.ForEach(e => count += GetNumberOfReportsById(e.EmployeeId));
            return count;
        }

    }
}
