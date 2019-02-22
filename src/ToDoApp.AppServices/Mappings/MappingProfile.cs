namespace ToDoApp.AppServices.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Dtos.TodoDto, Domain.Entities.Todo>().ReverseMap();
            CreateMap<Dtos.TodoFilterDto, Domain.Filters.TodoFilter>().ReverseMap();
            CreateMap<Dtos.ReportDto, Domain.Entities.Report>().ReverseMap();
            CreateMap<Dtos.ReportFilterDto, Domain.Filters.ReportFilter>().ReverseMap();
        }
    }
}
