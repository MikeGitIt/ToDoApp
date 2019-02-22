using System.Collections.Generic;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;

namespace ToDoApp.DomainServices.Interfaces
{
    public interface IReportDomainService
    {
        Report CreateReport(Report report);
        IEnumerable<Report> List(ReportFilter todoFilter);
        Report GetByName(string name);
        bool Update(Report report);
        bool Delete(string name);
    }
}
