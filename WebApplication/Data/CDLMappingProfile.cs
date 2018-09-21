using AutoMapper;
using WebApplication.Data.Entities;
using WebApplication.ViewModels;

namespace WebApplication.Data
{
    public class CDLMappingProfile : Profile
    {
        public CDLMappingProfile()
        {
            CreateMap<CustomerDriverLicense, LicenseViewModel>()
                //.ForMember(o => o.ID, ex => ex.MapFrom(o => o.ID))
                .ReverseMap();
        }
    }
}