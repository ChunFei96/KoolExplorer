using AutoMapper;
using Core.Domain.GovAPI;
using DAL.Entities;

namespace KoolExplorer.Mapper
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
                opt => opt.MapFrom(src => src.remarks));
                //.ForMember(dest =>
                //dest.LastUpdated,
                //opt => opt.MapFrom(src => src.last_updated)

            CreateMap<NetEnrolementRatioResponse, EnrolementRatio>()
                .ForMember(dest =>
                dest.EnrolementRate,
                opt => opt.MapFrom(src => src.total_net_enrolment_rate))
                .ForMember(dest =>
                dest.Sex,
                opt => opt.MapFrom(src => src.sex))
                .ForMember(dest =>
                dest.EducationLevel,
                opt => opt.MapFrom(src => src.level_of_education))
                .ForMember(dest =>
                dest.Year,
                opt => opt.MapFrom(src => src.year));

            CreateMap<MOEEnrolmentResponse, KindergartenEnrolement>()
               .ForMember(dest =>
               dest.EnrolementRate,
               opt => opt.MapFrom(src => src.enrolment))
               .ForMember(dest =>
               dest.Year,
               opt => opt.MapFrom(src => src.year));

            CreateMap<ListingOfCentresResponse, Centres>()
                .ForMember(dest =>
                dest.TPCode,
                opt => opt.MapFrom(src => src.tp_code))
                .ForMember(dest =>
                dest.Code,
                opt => opt.MapFrom(src => src.centre_code))
                .ForMember(dest =>
                dest.Name,
                opt => opt.MapFrom(src => src.centre_name))
                .ForMember(dest =>
                dest.OrganisationCode,
                opt => opt.MapFrom(src => src.organisation_code))
                .ForMember(dest =>
                dest.OrganisationDescription,
                opt => opt.MapFrom(src => src.organisation_description))
                .ForMember(dest =>
                dest.ServiceModel,
                opt => opt.MapFrom(src => src.service_model))
                .ForMember(dest =>
                dest.ContactNo,
                opt => opt.MapFrom(src => src.centre_contact_no))
                .ForMember(dest =>
                dest.Email,
                opt => opt.MapFrom(src => src.centre_email_address))
                .ForMember(dest =>
                dest.PostalCode,
                opt => opt.MapFrom(src => src.postal_code))
                .ForMember(dest =>
                dest.Address,
                opt => opt.MapFrom(src => src.centre_address))
                .ForMember(dest =>
                dest.Website,
                opt => opt.MapFrom(src => src.centre_website))
                .ForMember(dest =>
                dest.InfantVacancy,
                opt => opt.MapFrom(src => src.infant_vacancy))
                .ForMember(dest =>
                dest.PgVacancy,
                opt => opt.MapFrom(src => src.pg_vacancy))
                .ForMember(dest =>
                dest.N1Vacancy,
                opt => opt.MapFrom(src => src.n1_vacancy))
                .ForMember(dest =>
                dest.N2Vacancy,
                opt => opt.MapFrom(src => src.n2_vacancy))
                .ForMember(dest =>
                dest.K1Vacancy,
                opt => opt.MapFrom(src => src.k1_vacancy))
                .ForMember(dest =>
                dest.K2Vacancy,
                opt => opt.MapFrom(src => src.k2_vacancy))
                .ForMember(dest =>
                dest.FoodOffered,
                opt => opt.MapFrom(src => src.food_offered))
                .ForMember(dest =>
                dest.SecondLanguageOffered,
                opt => opt.MapFrom(src => src.second_language_offered))
                .ForMember(dest =>
                dest.SparkCertified,
                opt => opt.MapFrom(src => src.spark_certified))
                .ForMember(dest =>
                dest.WeekdayFullDay,
                opt => opt.MapFrom(src => src.weekday_full_day))
                .ForMember(dest =>
                dest.Saturday,
                opt => opt.MapFrom(src => src.saturday))
                .ForMember(dest =>
                dest.SchemeType,
                opt => opt.MapFrom(src => src.scheme_type))
                .ForMember(dest =>
                dest.ExtendedOperatingHours,
                opt => opt.MapFrom(src => src.extended_operating_hours))
                .ForMember(dest =>
                dest.ProvisionOfTransport,
                opt => opt.MapFrom(src => src.provision_of_transport))
                .ForMember(dest =>
                dest.GovernmentSubsidy,
                opt => opt.MapFrom(src => src.government_subsidy))
                .ForMember(dest =>
                dest.GstRegistration,
                opt => opt.MapFrom(src => src.gst_registration))
                //.ForMember(dest =>
                //dest.LastUpdated,
                //opt => opt.MapFrom(src => src.last_updated))
                .ForMember(dest =>
                dest.Remarks,
                opt => opt.MapFrom(src => src.remarks));

        }

    }
}
