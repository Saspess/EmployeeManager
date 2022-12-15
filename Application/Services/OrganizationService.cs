using Application.Exceptions;
using Application.Interfaces.Services;
using Application.Interfaces.UoW;
using Application.Models.Organization;
using Application.Services.Common;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class OrganizationService : BaseService, IOrganizationService
    {
        public OrganizationService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<OrganizationViewModel>> GetAllAsync()
        {
            var organizations = await unitOfWork.OrganizationRepository.GetAllAsync();
            var organizationsViewModels = mapper.Map<IEnumerable<OrganizationViewModel>>(organizations);

            return organizationsViewModels;
        }

        public async Task<OrganizationViewModel> GetByIdAsync(int id)
        {
            var organization = await unitOfWork.OrganizationRepository.GetByIdAsync(id);

            var organizationViewModels = mapper.Map<OrganizationViewModel>(organization);

            return organizationViewModels;
        }

        public async Task<OrganizationViewModel> GetByNameAsync(string name)
        {
            var organization = await unitOfWork.OrganizationRepository.GetByNameAsync(name);

            var organizationViewModel = mapper.Map<OrganizationViewModel>(organization);

            return organizationViewModel;
        }

        public async Task CreateAsync(OrganizationForCreationModel organizationForCreationModel)
        {
            if (organizationForCreationModel == null)
            {
                throw new ArgumentNullException(nameof(organizationForCreationModel));
            }

            var organizationAddress = mapper.Map<OrganizationAddress>(organizationForCreationModel);
            var createdOrganizationAddress = await unitOfWork.OrganizationAddressRepository.CreateAsync(organizationAddress);

            organizationForCreationModel.OrganizationAddressId = createdOrganizationAddress.Id;

            var organizationContact = mapper.Map<OrganizationContact>(organizationForCreationModel);
            var createdOrganizationContact = await unitOfWork.OrganizationContactRepository.CreateAsync(organizationContact);

            organizationForCreationModel.OrganizationContactId = createdOrganizationContact.Id;

            var organizationDataset = mapper.Map<OrganizationDataset>(organizationForCreationModel);
            var createdOrganizationDataset = await unitOfWork.OrganizationDatasetRepository.CreateAsync(organizationDataset);

            organizationForCreationModel.OrganizationDatasetId = createdOrganizationDataset.Id;

            var organization = mapper.Map<Organization>(organizationForCreationModel);
            await unitOfWork.OrganizationRepository.CreateAsync(organization);
        }

        public async Task UpdateAsync(OrganizationForUpdateModel organizationForUpdateModel)
        {
            var organizationAddress = mapper.Map<OrganizationAddress>(organizationForUpdateModel);
            await unitOfWork.OrganizationAddressRepository.UpdateAsync(organizationAddress);

            var organizationContact = mapper.Map<OrganizationContact>(organizationForUpdateModel);
            await unitOfWork.OrganizationContactRepository.UpdateAsync(organizationContact);

            var organizationDataset = mapper.Map<OrganizationDataset>(organizationForUpdateModel);
            await unitOfWork.OrganizationDatasetRepository.UpdateAsync(organizationDataset);

            var organization = mapper.Map<Organization>(organizationForUpdateModel);
            await unitOfWork.OrganizationRepository.UpdateAsync(organization);
        }

        public async Task DeleteAsync(int id)
        {
            var organization = await unitOfWork.OrganizationRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Организация не найдена!");

            var organizationDataset = await unitOfWork.OrganizationDatasetRepository.GetByIdAsync(organization.OrganizationDatasetId)
                ?? throw new NotFoundException("Информация об организации не найдены!"); ;

            var addressId = organizationDataset.OrganizationAddressId;
            var contactId = organizationDataset.OrganizationContactId;

            await unitOfWork.OrganizationAddressRepository.DeleteAsync(addressId);
            await unitOfWork.OrganizationContactRepository.DeleteAsync(contactId);
        }

        public async Task<OrganizationForUpdateModel> GetOrganizationModelAsync(int id)
        {
            var organization = await unitOfWork.OrganizationRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Организация не найдена!");

            var organizationForUpdateModel = mapper.Map<OrganizationForUpdateModel>(organization);

            return organizationForUpdateModel;
        }
    }
}
