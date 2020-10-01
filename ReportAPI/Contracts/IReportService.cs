using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportAPI.Contracts
{
    public interface IReportService
    {
        byte[] GenerateReportAsync(string reportName);
    }
}
