using Application.Exceptions;
using Application.Interfaces.Services;
using Application.Interfaces.UoW;
using Application.Models.Employee;
using Application.Services.Common;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        public EmployeeService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAllAsync()
        {
            var employees = await unitOfWork.EmployeeRepository.GetAllAsync();
            var employeesViewModels = mapper.Map<IEnumerable<EmployeeViewModel>>(employees);

            return employeesViewModels;
        }
        
        public async Task<IEnumerable<EmployeeViewModel>> GetByDepartmentIdAsync(int id)
        {
            var employees = await unitOfWork.EmployeeRepository.GetByDepartmentIdAsync(id);
            var employeesViewModels = mapper.Map<IEnumerable<EmployeeViewModel>>(employees);

            return employeesViewModels;
        }

        public async Task CreateAsync(EmployeeForCreationModel employeeForCreationModel)
        {
            if (employeeForCreationModel == null)
            {
                throw new ArgumentNullException(nameof(employeeForCreationModel));
            }

            var employeeAddress = mapper.Map<EmployeeAddress>(employeeForCreationModel);
            var createdEmployeeAddress = await unitOfWork.EmployeeAddressRepository.CreateAsync(employeeAddress);

            employeeForCreationModel.EmployeeAddressId = createdEmployeeAddress.Id;

            var education = mapper.Map<Education>(employeeForCreationModel);
            var createdEducation = await unitOfWork.EducationRepository.CreateAsync(education);

            employeeForCreationModel.EducationId = createdEducation.Id;

            var employeeDataset = mapper.Map<EmployeeDataset>(employeeForCreationModel);
            var createdEmployeeDataset = await unitOfWork.EmployeeDatasetRepository.CreateAsync(employeeDataset);

            employeeForCreationModel.EmployeeDatasetId = createdEmployeeDataset.Id;

            var position = mapper.Map<Position>(employeeForCreationModel);
            var createdPosition = await unitOfWork.PositionRepository.CreateAsync(position);

            employeeForCreationModel.PositionId = createdPosition.Id;

            var department = await unitOfWork.DepartmentRepository.GetByNameAsync(employeeForCreationModel.DepartmentName)
                ?? throw new NotFoundException("Отдел не найден!");

            employeeForCreationModel.DepartmentId = department.Id;

            var employee = mapper.Map<Employee>(employeeForCreationModel);
            await unitOfWork.EmployeeRepository.CreateAsync(employee);
        }

        public async Task UpdateAsync(EmployeeForUpdateModel employeeForUpdateModel)
        {
            var employeeAddress = mapper.Map<EmployeeAddress>(employeeForUpdateModel);
            await unitOfWork.EmployeeAddressRepository.UpdateAsync(employeeAddress);

            var education = mapper.Map<Education>(employeeForUpdateModel);
            await unitOfWork.EducationRepository.UpdateAsync(education);

            var employeeDataset = mapper.Map<EmployeeDataset>(employeeForUpdateModel);
            await unitOfWork.EmployeeDatasetRepository.UpdateAsync(employeeDataset);

            var position = mapper.Map<Position>(employeeForUpdateModel);
            await unitOfWork.PositionRepository.UpdateAsync(position);

            var employee = mapper.Map<Employee>(employeeForUpdateModel);
            await unitOfWork.EmployeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await unitOfWork.EmployeeRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Сотрудник не найден!");

            var employeeDataset = await unitOfWork.EmployeeDatasetRepository.GetByIdAsync(employee.EmployeeDatasetId)
                ?? throw new NotFoundException("Информация о сотруднике не найдена!");

            var employeeAddress = await unitOfWork.EmployeeAddressRepository.GetByIdAsync(employeeDataset.EmployeeAddressId)
                ?? throw new NotFoundException("Адрес сотрудника не найден!");

            var education = await unitOfWork.EducationRepository.GetByIdAsync(employeeDataset.EducationId)
                ?? throw new NotFoundException("Информация об образовании не найдена!");

            var position = await unitOfWork.PositionRepository.GetByIdAsync(employee.PositionId)
                ?? throw new NotFoundException("Должность не найдена!");

            await unitOfWork.EmployeeAddressRepository.DeleteAsync(employeeAddress.Id);
            await unitOfWork.EducationRepository.DeleteAsync(education.Id);
            await unitOfWork.PositionRepository.DeleteAsync(position.Id);
        }

        public async Task<EmployeeForUpdateModel> GetEmployeeModelAsync(int id)
        {
            var employee = await unitOfWork.EmployeeRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Сотрудник не найден!");

            var employeeForUpdateModel = mapper.Map<EmployeeForUpdateModel>(employee);

            return employeeForUpdateModel;
        }
    }
}
