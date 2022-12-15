using Application.Exceptions;
using Application.Interfaces.Services;
using Application.Interfaces.UoW;
using Application.Models.Department;
using Application.Services.Common;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public DepartmentService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<DepartmentViewModel>> GetAllAsync()
        {
            var departments = await unitOfWork.DepartmentRepository.GetAllAsync();
            var departmentsViewModels = mapper.Map<IEnumerable<DepartmentViewModel>>(departments);

            return departmentsViewModels;
        }

        public async Task<IEnumerable<DepartmentViewModel>> GetByOrganizationIdAsync(int id)
        {
            var departments = await unitOfWork.DepartmentRepository.GetByOrganizationIdAsync(id);
            var departmentsViewModels = mapper.Map<IEnumerable<DepartmentViewModel>>(departments);

            return departmentsViewModels;
        }

        public async Task<DepartmentViewModel> GetByIdAsync(int id)
        {
            var department = await unitOfWork.DepartmentRepository.GetByIdAsync(id);

            var departmentViewModel = mapper.Map<DepartmentViewModel>(department);

            return departmentViewModel;
        }

        public async Task<DepartmentViewModel> GetByNameAsync(string name)
        {
            var department = await unitOfWork.DepartmentRepository.GetByNameAsync(name);

            var departmentViewModel = mapper.Map<DepartmentViewModel>(department);

            return departmentViewModel;
        }

        public async Task CreateAsync(DepartmentForCreationModel departmentForCreationModel)
        {
            if (departmentForCreationModel == null)
            {
                throw new ArgumentNullException(nameof(departmentForCreationModel));
            }

            var departmentAddress = mapper.Map<DepartmentAddress>(departmentForCreationModel);
            var createdDepartmentAddress = await unitOfWork.DepartmentAddressRepository.CreateAsync(departmentAddress);

            departmentForCreationModel.DepartmentAddressId = createdDepartmentAddress.Id;

            var departmentDataset = mapper.Map<DepartmentDataset>(departmentForCreationModel);
            var createdDepartmentDataset = await unitOfWork.DepartmentDatasetRepository.CreateAsync(departmentDataset);

            departmentForCreationModel.DepartmentDatasetId = createdDepartmentDataset.Id;

            var organization = await unitOfWork.OrganizationRepository.GetByNameAsync(departmentForCreationModel.OrganizationName)
                ?? throw new NotFoundException("Организация не найдена!");

            departmentForCreationModel.OrganizationId = organization.Id;

            var department = mapper.Map<Department>(departmentForCreationModel);
            await unitOfWork.DepartmentRepository.CreateAsync(department);
        }

        public async Task UpdateAsync(DepartmentForUpdateModel departmentForUpdateModel)
        {
            var departmentAddress = mapper.Map<DepartmentAddress>(departmentForUpdateModel);
            await unitOfWork.DepartmentAddressRepository.UpdateAsync(departmentAddress);

            var departmentDataset = mapper.Map<DepartmentDataset>(departmentForUpdateModel);
            await unitOfWork.DepartmentDatasetRepository.UpdateAsync(departmentDataset);

            var department = mapper.Map<Department>(departmentForUpdateModel);
            await unitOfWork.DepartmentRepository.UpdateAsync(department);
        }

        public async Task DeleteAsync(int id)
        {
            var department = await unitOfWork.DepartmentRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Отдел не найден!");

            var departmentDataset = await unitOfWork.DepartmentDatasetRepository.GetByIdAsync(department.DepartmentDatasetId)
                ?? throw new NotFoundException("Информация об отделе не найдена!");

            var departmentAddress = await unitOfWork.DepartmentAddressRepository.GetByIdAsync(departmentDataset.DepartmentAddressId)
                ?? throw new NotFoundException("Адрес отдела не найден!");

            await unitOfWork.DepartmentAddressRepository.DeleteAsync(departmentAddress.Id);
        }

        public async Task<DepartmentForUpdateModel> GetDepartmentModelAsync(int id)
        {
            var department = await unitOfWork.DepartmentRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Отдел не найден!");

            var departmentForUpdateModel = mapper.Map<DepartmentForUpdateModel>(department);

            return departmentForUpdateModel;
        }
    }
}

