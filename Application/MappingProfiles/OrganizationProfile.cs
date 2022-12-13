using Application.Helpers.MappingHelpers;
using Application.Models.Organization;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingProfiles
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Organization, OrganizationViewModel>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => $"{src.OrganizationDataset.OrganizationAddress.Street} {src.OrganizationDataset.OrganizationAddress.HouseNumber}{AddressChecker.Check(src.OrganizationDataset.OrganizationAddress.HouseCode)}, {src.OrganizationDataset.OrganizationAddress.City}"))
                .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.OrganizationDataset.DirectorName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.OrganizationDataset.OrganizationContact.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.OrganizationDataset.OrganizationContact.Email));

            CreateMap<OrganizationForCreationModel, OrganizationAddress>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<OrganizationForCreationModel, OrganizationContact>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<OrganizationForCreationModel, OrganizationDataset>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<OrganizationForCreationModel, Organization>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Organization, OrganizationForUpdateModel>()
                .ForMember(dest => dest.OrganizationAddressId, opt => opt.MapFrom(src => src.OrganizationDataset.OrganizationAddressId))
                .ForMember(dest => dest.OrganizationContactId, opt => opt.MapFrom(src => src.OrganizationDataset.OrganizationContactId))
                .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.OrganizationDataset.DirectorName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.OrganizationDataset.OrganizationContact.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.OrganizationDataset.OrganizationContact.PhoneNumber))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.OrganizationDataset.OrganizationAddress.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.OrganizationDataset.OrganizationAddress.Street))
                .ForMember(dest => dest.HouseNumber, opt => opt.MapFrom(src => src.OrganizationDataset.OrganizationAddress.HouseNumber))
                .ForMember(dest => dest.HouseCode, opt => opt.MapFrom(src => src.OrganizationDataset.OrganizationAddress.HouseCode));
            
            CreateMap<OrganizationForUpdateModel, OrganizationAddress>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrganizationAddressId));

            CreateMap<OrganizationForUpdateModel, OrganizationContact>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrganizationContactId));

            CreateMap<OrganizationForUpdateModel, OrganizationDataset>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrganizationDatasetId));

            CreateMap<OrganizationForUpdateModel, Organization>();
        }
    }
}
