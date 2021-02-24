using AutoMapper;
using Core.Domain.GovAPI;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoolExplorer
{
    public class GovAPIMapper : Profile
    {
        public GovAPIMapper()
        {
            CreateMap<GetListingOfCentreServicesResponse, CentreServices>()
                .ForMember(dest =>
                dest.Code,
                opt => opt.MapFrom(src => src.centre_code))
                .ForMember(dest =>
                dest.Name,
                opt => opt.MapFrom(src => src.centre_name))
                .ForMember(dest =>
                dest.Level,
                opt => opt.MapFrom(src => src.levels_offered))
                .ForMember(dest =>
                dest.Service,
                opt => opt.MapFrom(src => src.type_of_service))
                .ForMember(dest =>
                dest.Citizenship,
                opt => opt.MapFrom(src => src.type_of_citizenship))
                .ForMember(dest =>
                dest.Licence,
                opt => opt.MapFrom(src => src.class_of_licence))
                .ForMember(dest =>
                dest.Fee,
                opt => opt.MapFrom(src => src.fees))
                .ForMember(dest =>
                dest.Remark,
                opt => opt.MapFrom(src => src.remarks))
                .ForMember(dest =>
                dest.LastUpdated,
                opt => opt.MapFrom(src => src.last_updated));

            CreateMap<GetListingOfCentreServicesResponse, KoolExplorer.Model.GovAPI.GetListingOfCentreServicesResponse>();
        }
       
    }
}
