using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.AppServices.Dtos;
using ToDoApp.AppServices.Extensions;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;
using ToDoApp.DomainServices.Interfaces;

namespace ToDoApp.AppServices
{
    internal class ReportAppService : Interfaces.IReportAppService
    {
        private readonly IReportDomainService service;

        public ReportAppService(IReportDomainService service)
        {
            this.service = service;
        }
        public ReportDto CreateReport(ReportDto report)
        {
            var result = service.CreateReport(report.MapTo<Report>());
            return result.MapTo<ReportDto>();
        }

        public bool Delete(string name)
        {
            return service.Delete(name);
        }

        public ReportDto GetByName(string name)
        {
            return service.GetByName(name).MapTo<ReportDto>();
        }

        public IEnumerable<ReportDto> List(ReportFilterDto reportFilter)
        {
            return service.List(reportFilter.MapTo<ReportFilter>()).EnumerableTo<ReportDto>();
        }

        public bool Update(ReportDto report)
        {
            return service.Update(report.MapTo<Report>());
        }
    }
}
