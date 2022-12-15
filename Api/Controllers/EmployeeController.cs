using Application.DTOs;
using Application.Interfaces.ServiceManager;
using Application.Models.Employee;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public EmployeeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetByDepartmentId(int id)
        {

            var employees = await _serviceManager.EmployeeService.GetByDepartmentIdAsync(id);

            var employeesDto = new EmployeesDto(employees);

            return View("Index", employeesDto);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var employees = await _serviceManager.EmployeeService.GetAllAsync();

            var employeesDto = new EmployeesDto(employees);

            return View(employeesDto);
        }

        [HttpPost]
        [ActionName(nameof(CreateEmployeeAsync))]
        public async Task<IActionResult> CreateEmployeeAsync(EmployeeForCreationModel employeeForCreationModel)
        {

            if (!ModelState.IsValid)
            {
                return View("CreateEmployeeAsync", employeeForCreationModel);
            }

            await _serviceManager.EmployeeService.CreateAsync(employeeForCreationModel);

            return RedirectToAction("Index", employeeForCreationModel.DepartmentId);
        }

        public IActionResult CreateView()
        {
            return View("CreateEmployeeAsync");
        }

        [HttpPost]
        [ActionName(nameof(UpdateEmployeeAsync))]
        public async Task<IActionResult> UpdateEmployeeAsync(EmployeeForUpdateModel employeeForUpdateModel)
        {

            if (!ModelState.IsValid)
            {
                return View("UpdateEmployeeAsync", employeeForUpdateModel);
            }

            await _serviceManager.EmployeeService.UpdateAsync(employeeForUpdateModel);

            return Redirect("Index");
        }

        public async Task<IActionResult> UpdateView(int id)
        {
            var employeeForUpdateModel = await _serviceManager.EmployeeService.GetEmployeeModelAsync(id);

            return View("UpdateEmployeeAsync", employeeForUpdateModel);
        }

        [HttpDelete]
        [ActionName(nameof(DeleteEmployeeAsync))]
        public async Task DeleteEmployeeAsync(int id)
        {
            await _serviceManager.EmployeeService.DeleteAsync(id);
        }

        public async Task<IActionResult> DeleteView(int id)
        {
            await DeleteEmployeeAsync(id);

            return RedirectToAction("Index");
        }
    }
}
