using AutoMapper;
using Core.Domain.Form;
using DAL.Entities;
using DAL.Entities.Form;

namespace KoolExplorer.Mapper
{
    public class FormMapper : Profile
    {
        public FormMapper()
        {
            CreateMap<AdmissionModel, ApplicationForm>()
                 .ForMember(dest =>
                dest.Id,
                opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest =>
                dest.ApplicationStatus,
                opt => opt.MapFrom(src => src.ApplicationStatus))
                .ForMember(dest =>
                dest.generalInformationItems,
                opt => opt.MapFrom(src => src.GeneralInformationViewModel))
            .ForMember(dest =>
                dest.parentParticularItems,
                opt => opt.MapFrom(src => src.ParentsParticularsViewModel))
            .ForMember(dest =>
                dest.childParticularItems,
                opt => opt.MapFrom(src => src.ChildsParticularsViewModel))
            .ReverseMap(); ;
            CreateMap<GeneralInformationViewModel, GeneralInformationItems>()
                 // General Information
                 .ForMember(dest =>
                dest.Id,
                opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest =>
                dest.Area,
                opt => opt.MapFrom(src => src.Area))
                 .ForMember(dest =>
                dest.District,
                opt => opt.MapFrom(src => src.District))
                 .ForMember(dest =>
                dest.PreSchool,
                opt => opt.MapFrom(src => src.PreSchool))
                 .ForMember(dest =>
                dest.Programme,
                opt => opt.MapFrom(src => src.Programme))
                 .ForMember(dest =>
                dest.StartPeriod,
                opt => opt.MapFrom(src => src.StartPeriod))
                 .ReverseMap();
            
                // Parents Particulars
                CreateMap<ParentsParticularsViewModel, ParentParticularItems>()
                .ForMember(dest =>
                dest.Id,
                opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest =>
                dest.ParentName1,
                opt => opt.MapFrom(src => src.Name1))
                 .ForMember(dest =>
                dest.PassportNo1,
                opt => opt.MapFrom(src => src.PassportNo1))
                 .ForMember(dest =>
                dest.MobileNo1,
                opt => opt.MapFrom(src => src.MobileNo1))
                 .ForMember(dest =>
                dest.Email1,
                opt => opt.MapFrom(src => src.Email1))
                 .ForMember(dest =>
                dest.ParentName2,
                opt => opt.MapFrom(src => src.Name2))
                 .ForMember(dest =>
                dest.PassportNo2,
                opt => opt.MapFrom(src => src.PassportNo2))
                 .ForMember(dest =>
                dest.MobileNo2,
                opt => opt.MapFrom(src => src.MobileNo2))
                 .ForMember(dest =>
                dest.Email2,
                opt => opt.MapFrom(src => src.Email2))
                 .ForMember(dest =>
                dest.HomeTelNo,
                opt => opt.MapFrom(src => src.HomeTelNo))
                 .ForMember(dest =>
                dest.StreetName,
                opt => opt.MapFrom(src => src.StreetName))
                 .ForMember(dest =>
                dest.BlockNo,
                opt => opt.MapFrom(src => src.BlockNo))
                 .ForMember(dest =>
                dest.FloorNo,
                opt => opt.MapFrom(src => src.FloorNo))
                 .ForMember(dest =>
                dest.BuildingName,
                opt => opt.MapFrom(src => src.BuildingName))
                 .ForMember(dest =>
                dest.PostalCode,
                opt => opt.MapFrom(src => src.PostalCode))
                 .ForMember(dest =>
                dest.HouseholdIncome,
                opt => opt.MapFrom(src => src.HouseholdIncome))
                 .ReverseMap();
                // Childs Particulars
                CreateMap<ChildsParticularsViewModel, ChildParticularItems>()
                .ForMember(dest =>
                dest.Id,
                opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest =>
                dest.ChildName,
                opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest =>
                dest.Citizenship,
                opt => opt.MapFrom(src => src.Citizenship))
                 .ForMember(dest =>
                dest.Race,
                opt => opt.MapFrom(src => src.Race))
                 .ForMember(dest =>
                dest.DOB,
                opt => opt.MapFrom(src => src.BirthCertNo))
                  .ForMember(dest =>
                dest.BirthCerNo,
                opt => opt.MapFrom(src => src.DOB))
                  .ForMember(dest =>
                dest.Gender,
                opt => opt.MapFrom(src => src.Gender))
                  .ReverseMap();




            //CreateMap<ApplicationForm, AdmissionModel>()
            //    .ForMember(dest =>
            //    dest.GeneralInformationViewModel,
            //    opt => opt.MapFrom(src => src.generalInformationItems))
            //.ForMember(dest =>
            //    dest.ParentsParticularsViewModel,
            //    opt => opt.MapFrom(src => src.parentParticularItems))
            //.ForMember(dest =>
            //    dest.ChildsParticularsViewModel,
            //    opt => opt.MapFrom(src => src.childParticularItems))
            //.ReverseMap(); ;
            //CreateMap<GeneralInformationItems, GeneralInformationViewModel>()
            //     // General Information
            //     .ForMember(dest =>
            //    dest.Area,
            //    opt => opt.MapFrom(src => src.Area))
            //     .ForMember(dest =>
            //    dest.District,
            //    opt => opt.MapFrom(src => src.District))
            //     .ForMember(dest =>
            //    dest.PreSchool,
            //    opt => opt.MapFrom(src => src.PreSchool))
            //     .ForMember(dest =>
            //    dest.Programme,
            //    opt => opt.MapFrom(src => src.Programme))
            //     .ForMember(dest =>
            //    dest.ProgrammeTime,
            //    opt => opt.MapFrom(src => src.ProgrammeTime))
            //     .ForMember(dest =>
            //    dest.StartPeriod,
            //    opt => opt.MapFrom(src => src.StartPeriod))
            //     .ReverseMap();

            //// Parents Particulars
            //CreateMap<ParentParticularItems, ParentsParticularsViewModel>()
            // .ForMember(dest =>
            //dest.Name1,
            //opt => opt.MapFrom(src => src.ParentName1))
            // .ForMember(dest =>
            //dest.PassportNo1,
            //opt => opt.MapFrom(src => src.PassportNo1))
            // .ForMember(dest =>
            //dest.MobileNo1,
            //opt => opt.MapFrom(src => src.MobileNo1))
            // .ForMember(dest =>
            //dest.Email1,
            //opt => opt.MapFrom(src => src.Email1))
            // .ForMember(dest =>
            //dest.Name2,
            //opt => opt.MapFrom(src => src.ParentName2))
            // .ForMember(dest =>
            //dest.PassportNo2,
            //opt => opt.MapFrom(src => src.PassportNo2))
            // .ForMember(dest =>
            //dest.MobileNo2,
            //opt => opt.MapFrom(src => src.MobileNo2))
            // .ForMember(dest =>
            //dest.Email2,
            //opt => opt.MapFrom(src => src.Email2))
            // .ForMember(dest =>
            //dest.HomeTelNo,
            //opt => opt.MapFrom(src => src.HomeTelNo))
            // .ForMember(dest =>
            //dest.StreetName,
            //opt => opt.MapFrom(src => src.StreetName))
            // .ForMember(dest =>
            //dest.BlockNo,
            //opt => opt.MapFrom(src => src.BlockNo))
            // .ForMember(dest =>
            //dest.FloorNo,
            //opt => opt.MapFrom(src => src.FloorNo))
            // .ForMember(dest =>
            //dest.BuildingName,
            //opt => opt.MapFrom(src => src.BuildingName))
            // .ForMember(dest =>
            //dest.PostalCode,
            //opt => opt.MapFrom(src => src.PostalCode))
            // .ForMember(dest =>
            //dest.HouseholdIncome,
            //opt => opt.MapFrom(src => src.HouseholdIncome))
            // .ReverseMap();
            //// Childs Particulars
            //CreateMap<ChildParticularItems, ChildsParticularsViewModel>()
            // .ForMember(dest =>
            //dest.Name,
            //opt => opt.MapFrom(src => src.ChildName))
            // .ForMember(dest =>
            //dest.Citizenship,
            //opt => opt.MapFrom(src => src.Citizenship))
            // .ForMember(dest =>
            //dest.Race,
            //opt => opt.MapFrom(src => src.Race))
            // .ForMember(dest =>
            //dest.BirthCertNo,
            //opt => opt.MapFrom(src => src.DOB))
            //  .ForMember(dest =>
            //dest.DOB,
            //opt => opt.MapFrom(src => src.DOB))
            //  .ForMember(dest =>
            //dest.Gender,
            //opt => opt.MapFrom(src => src.Gender))
            //  .ReverseMap();
        }
    }
}
