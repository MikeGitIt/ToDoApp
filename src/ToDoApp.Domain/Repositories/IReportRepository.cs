using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;

namespace ToDoApp.Domain.Repositories
{
    public interface IReportRepository
    {
        Report CreateReport(Report report);
        IEnumerable<Report> List(ReportFilter todoFilter);
        Report GetByName(string name);
        bool Update(Report report);
        bool Delete(string name);
    }
}
