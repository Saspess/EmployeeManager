using AutoMapper;
using Application.ViewModels;
using Domain.Entities;
using Application.Helpers.MappingHelpers;
using Application.Models.Employee;

namespace Application.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => $"{src.EmployeeDataset.EmployeeAddress.Street} {src.EmployeeDataset.EmployeeAddress.HouseNumber}{AddressChecker.Check(src.EmployeeDataset.EmployeeAddress.HouseCode)}{AddressChecker.Check(src.EmployeeDataset.EmployeeAddress.FlatNumber)}, {src.EmployeeDataset.EmployeeAddress.City}"))
                .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Position.Salary))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.EmployeeDataset.PhoneNumber))
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.EmployeeDataset.Birthday))
                .ForMember(dest => dest.Education, opt => opt.MapFrom(src => $"{src.EmployeeDataset.Education.InstitutionName}, {src.EmployeeDataset.Education.StartYear} - {src.EmployeeDataset.Education.EndYear}"));

            CreateMap<EmployeeForCreationModel, EmployeeAddress>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<EmployeeForCreationModel, EmployeeDataset>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<EmployeeForCreationModel, Education>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<EmployeeForCreationModel, Position>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.PositionName));

            CreateMap<EmployeeForCreationModel, Employee>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Employee, EmployeeForUpdateModel>()
                .ForMember(dest => dest.EmployeeAddressId, opt => opt.MapFrom(src => src.EmployeeDataset.EmployeeAddressId))
                .ForMember(dest => dest.EducationId, opt => opt.MapFrom(src => src.EmployeeDataset.EducationId))
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.EmployeeDataset.Birthday))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.EmployeeDataset.PhoneNumber))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.EmployeeDataset.EmployeeAddress.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.EmployeeDataset.EmployeeAddress.Street))
                .ForMember(dest => dest.HouseNumber, opt => opt.MapFrom(src => src.EmployeeDataset.EmployeeAddress.HouseNumber))
                .ForMember(dest => dest.FlatNumber, opt => opt.MapFrom(src => src.EmployeeDataset.EmployeeAddress.FlatNumber))
                .ForMember(dest => dest.HouseCode, opt => opt.MapFrom(src => src.EmployeeDataset.EmployeeAddress.HouseCode))
                .ForMember(dest => dest.InstitutionName, opt => opt.MapFrom(src => src.EmployeeDataset.Education.InstitutionName))
                .ForMember(dest => dest.StartYear, opt => opt.MapFrom(src => src.EmployeeDataset.Education.StartYear))
                .ForMember(dest => dest.EndYear, opt => opt.MapFrom(src => src.EmployeeDataset.Education.EndYear))
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position.Name))
                .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Position.Salary));

            CreateMap<EmployeeForUpdateModel, EmployeeAddress>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EmployeeAddressId));

            CreateMap<EmployeeForUpdateModel, EmployeeDataset>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EmployeeDatasetId));

            CreateMap<EmployeeForUpdateModel, Education>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EducationId));

            CreateMap<EmployeeForUpdateModel, Position>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PositionId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.PositionName));

            CreateMap<EmployeeForUpdateModel, Employee>();
        }
    }
}
