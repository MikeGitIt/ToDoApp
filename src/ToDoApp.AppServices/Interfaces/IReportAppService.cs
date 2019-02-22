using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.AppServices.Dtos;

namespace ToDoApp.AppServices.Interfaces
{
    public interface IReportAppService
    {
        ReportDto CreateReport(ReportDto report);
        IEnumerable<ReportDto> List(ReportFilterDto reportFilter);
        ReportDto GetByName(string name);
        bool Update(ReportDto report);
        bool Delete(string name);
    }
}
