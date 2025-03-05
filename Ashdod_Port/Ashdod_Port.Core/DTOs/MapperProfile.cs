using Ashdod_Port.Core.DTOs;
using Ashdod_Port.Core.Entities;
using AutoMapper;

namespace Clean.Core.DTOs
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ImporterDTO, Importer>().ReverseMap();
            CreateMap<SupplierDTO, Supplier>().ReverseMap();
            CreateMap<ContainerDTO, Container>().ReverseMap();

        }
    }
}
