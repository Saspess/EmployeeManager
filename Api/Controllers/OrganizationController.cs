using Application.Interfaces.ServiceManager;
using Application.Models.Organization;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Application.ViewModels;

namespace Api.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public OrganizationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var organizations = await _serviceManager.OrganizationService.GetAllAsync();

            var organizationsDto = new OrganizationsDto(organizations);

            return View(organizationsDto);
        }

        [HttpGet]
        public async Task<OrganizationViewModel> GetOrganizationByNameAsync(string name)
        {
            var organization = await _serviceManager.OrganizationService.GetByNameAsync(name);

            return organization;
        }

        public async Task<IActionResult> FindView(string name)
        {
            var organization = await GetOrganizationByNameAsync(name);

            if (organization == null) { return View("OrganizationNotFound"); }

            return View("GetOrganizationByNameAsync", organization);
        }

        [HttpPost]
        [ActionName(nameof(CreateOrganizationAsync))]
        public async Task<IActionResult> CreateOrganizationAsync(OrganizationForCreationModel organizationForCreationModel)
        {

            if (!ModelState.IsValid)
            {
                return View("CreateOrganizationAsync", organizationForCreationModel);
            }

            await _serviceManager.OrganizationService.CreateAsync(organizationForCreationModel);

            return Redirect("Index");
        }

        public IActionResult CreateView()
        {
            return View("CreateOrganizationAsync");
        }

        [HttpPost]
        [ActionName(nameof(UpdateOrganizationAsync))]
        public async Task<IActionResult> UpdateOrganizationAsync(OrganizationForUpdateModel organizationForUpdateModel)
        {
            
            if (!ModelState.IsValid)
            {
                return View("UpdateOrganizationAsync", organizationForUpdateModel);
            }

            await _serviceManager.OrganizationService.UpdateAsync(organizationForUpdateModel);

            return Redirect("Index");
        }

        public async Task<IActionResult> UpdateView(int id)
        {
            var organizationForUpdateModel = await _serviceManager.OrganizationService.GetOrganizationModelAsync(id);

            return View("UpdateOrganizationAsync", organizationForUpdateModel);
        }

        [HttpDelete]
        [ActionName(nameof(DeleteOrganizationAsync))]
        public async Task DeleteOrganizationAsync(int id)
        {
            await _serviceManager.OrganizationService.DeleteAsync(id);
        }

        public async Task<IActionResult> DeleteView(int id)
        {
            await DeleteOrganizationAsync(id);

            return RedirectToAction("Index");
        }
    }
}
