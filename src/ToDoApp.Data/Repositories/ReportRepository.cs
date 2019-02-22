using System.Collections.Generic;
using Dapper;
using Microsoft.Extensions.Configuration;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;

namespace ToDoApp.Data.Repositories
{
    internal class ReportRepository : RepositoryBase, Domain.Repositories.IReportRepository
    {
        public ReportRepository(IConfigurationRoot configuration) : base(configuration)
        {
        }

        public Report CreateReport(Report report)
        {
            report.Name = connection.QueryFirst<string>("exec report_sp_create @Id, @Name, @Path, @VirtualPath, @TypeName, @Size, @SizeSpecified, @Description, @HiddenSpecified, @CreationDate, @CreationDateSpecified, @ModifiedDate, @ModifiedDateSpecified, @CreatedBy, @ModifiedBy, @ItemMetadata", report);
            return report;
        }

        public IEnumerable<Report> List(ReportFilter reportFilter)
        {
            var result = connection.Query<Report>("exec report_sp_list", reportFilter);
            return result;
        }

        public Report GetByName(string name)
        {
            var result = connection.QueryFirstOrDefault<Report>("exec report_sp_get @Name", new { Name = name });
            return result;
        }

        public bool Update(Report report)
        {
            var affecteRows = connection.Execute("exec report_sp_update @Id, @Name, @Path, @VirtualPath, @TypeName, @Size, @SizeSpecified, @Description, @HiddenSpecified, @CreationDate, @CreationDateSpecified, @ModifiedDate, @ModifiedDateSpecified, @CreatedBy, @ModifiedBy, @ItemMetadata,", report);
            return affecteRows > 0;
        }

        public bool Delete(string name)
        {
            var affectedRows = connection.Execute("exec todo_sp_delete @Name", new { Name = name });
            return affectedRows > 0;
        }
    }
}


/*
        public string Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public object VirtualPath { get; set; }
        public string TypeName { get; set; }
        public int Size { get; set; }
        public bool SizeSpecified { get; set; }
        public object Description { get; set; }
        public bool HiddenSpecified { get; set; }
        public DateTime CreationDate { get; set; }
        public bool CreationDateSpecified { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool ModifiedDateSpecified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public object[] ItemMetadata { get; set; }
     
     
     */
