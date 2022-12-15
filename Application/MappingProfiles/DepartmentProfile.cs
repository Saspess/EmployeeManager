using AutoMapper;
using Domain.Entities;
using Application.ViewModels;
using Application.Helpers.MappingHelpers;
using Application.Models.Department;

namespace Api.MappingProfiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentViewModel>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => $"{src.DepartmentDataset.DepartmentAddress.Street} {src.DepartmentDataset.DepartmentAddress.HouseNumber}{AddressChecker.Check(src.DepartmentDataset.DepartmentAddress.HouseCode)}, {src.DepartmentDataset.DepartmentAddress.City}"))
                .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.DepartmentDataset.DirectorName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.DepartmentDataset.PhoneNumber));

            CreateMap<DepartmentForCreationModel, DepartmentAddress>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<DepartmentForCreationModel, DepartmentDataset>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<DepartmentForCreationModel, Department>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Department, DepartmentForUpdateModel>()
                .ForMember(dest => dest.DepartmentAddressId, opt => opt.MapFrom(src => src.DepartmentDataset.DepartmentAddressId))
                .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.DepartmentDataset.DirectorName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.DepartmentDataset.PhoneNumber))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.DepartmentDataset.DepartmentAddress.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.DepartmentDataset.DepartmentAddress.Street))
                .ForMember(dest => dest.HouseNumber, opt => opt.MapFrom(src => src.DepartmentDataset.DepartmentAddress.HouseNumber))
                .ForMember(dest => dest.HouseCode, opt => opt.MapFrom(src => src.DepartmentDataset.DepartmentAddress.HouseCode));

            CreateMap<DepartmentForUpdateModel, DepartmentAddress>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DepartmentAddressId));

            CreateMap<DepartmentForUpdateModel, DepartmentDataset>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DepartmentDatasetId));

            CreateMap<DepartmentForUpdateModel, Department>();
        }
    }
}
