using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.AppServices.Dtos
{
    public class ReportDto
    {
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
    }
}
