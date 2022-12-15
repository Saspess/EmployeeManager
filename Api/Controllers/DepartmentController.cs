using Application.DTOs;
using Application.Interfaces.ServiceManager;
using Application.Models.Department;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public DepartmentController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetByOrganizationId(int id)
        {
            var departments = await _serviceManager.DepartmentService.GetByOrganizationIdAsync(id);

            var departmentsDto = new DepartmentsDto(departments);

            return View("Index", departmentsDto);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var departments = await _serviceManager.DepartmentService.GetAllAsync();

            var departmentsDto = new DepartmentsDto(departments);

            return View(departmentsDto);
        }

        [HttpGet]
        public async Task<DepartmentViewModel> GetOrganizationByNameAsync(string name)
        {
            var department = await _serviceManager.DepartmentService.GetByNameAsync(name);

            return department;
        }

        public async Task<IActionResult> FindView(string name)
        {
            var department = await GetOrganizationByNameAsync(name);

            if (department == null) { return View("DepartmentNotFound"); }

            return View("GetDepartmentByNameAsync", department);
        }

        [HttpPost]
        [ActionName(nameof(CreateDepartmentAsync))]
        public async Task<IActionResult> CreateDepartmentAsync(DepartmentForCreationModel departmentForCreationModel)
        {

            if (!ModelState.IsValid)
            {
                return View("CreateDepartmentAsync", departmentForCreationModel);
            }

            await _serviceManager.DepartmentService.CreateAsync(departmentForCreationModel);

            return RedirectToAction("Index", departmentForCreationModel.OrganizationId);
        }

        public IActionResult CreateView()
        {
            return View("CreateDepartmentAsync");
        }

        [HttpPost]
        [ActionName(nameof(UpdateDepartmentAsync))]
        public async Task<IActionResult> UpdateDepartmentAsync(DepartmentForUpdateModel departmentForUpdateModel)
        {

            if (!ModelState.IsValid)
            {
                return View("UpdateDepartmentAsync", departmentForUpdateModel);
            }

            await _serviceManager.DepartmentService.UpdateAsync(departmentForUpdateModel);

            return Redirect("Index");
        }

        public async Task<IActionResult> UpdateView(int id)
        {
            var organizationForUpdateModel = await _serviceManager.DepartmentService.GetDepartmentModelAsync(id);

            return View("UpdateDepartmentAsync", organizationForUpdateModel);
        }

        [HttpDelete]
        [ActionName(nameof(DeleteDepartmentAsync))]
        public async Task DeleteDepartmentAsync(int id)
        {
            await _serviceManager.DepartmentService.DeleteAsync(id);
        }

        public async Task<IActionResult> DeleteView(int id)
        {
            await DeleteDepartmentAsync(id);

            return RedirectToAction("Index");
        }
    }
}
