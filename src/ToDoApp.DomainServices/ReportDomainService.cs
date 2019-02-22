using System.Collections.Generic;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;
using ToDoApp.Domain.Repositories;
using ToDoApp.DomainServices.Interfaces;

namespace ToDoApp.DomainServices
{
    internal class ReportDomainService : IReportDomainService
    {
        private IReportRepository repository;

        public ReportDomainService(IReportRepository repository)
        {
            this.repository = repository;
        }

        public Report CreateReport(Report report)
        {
            return repository.CreateReport(report);
        }

        public IEnumerable<Report> List(ReportFilter reportFilter)
        {
            return repository.List(reportFilter);
        }

        public Report GetByName(string name)
        {
            return repository.GetByName(name);
        }

        public bool Update(Report report)
        {
            return repository.Update(report);
        }

        public bool Delete(string name)
        {
            return repository.Delete(name);
        }
    }
}

