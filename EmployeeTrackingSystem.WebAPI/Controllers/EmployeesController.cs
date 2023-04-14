using EmployeeTrackingSystem.CoreLayer.DTOs.Employee;
using EmployeeTrackingSystem.CoreLayer.Entities;
using EmployeeTrackingSystem.CoreLayer.Services;
using EmployeeTrackingSystem.WebAPI.Filter;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingSystem.WebAPI.Controllers
{
    public class EmployeesController : CustomBaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEmployeesActive()
        {
            return CreateActionResult(await _employeeService.Where(x => x.OutDate == null));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEmployeesNonActive()
        {
            return CreateActionResult(await _employeeService.Where(x => x.OutDate != null));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEmployeesActiveAndNonActive()
        {
            return CreateActionResult(await _employeeService.GetAllAsync());
        }

        [ServiceFilter(typeof(NotFoundFilter<Employee, EmployeeDto>))]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _employeeService.GetByIdAsync(id));
        }

        [ServiceFilter(typeof(NotFoundFilter<Employee, EmployeeDto>))]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetSingleByIdWithDepartmentAndPosition(int id)
        {
            var result = await _employeeService.GetSingleByIdWithDepartmentAndPosition(id);
            return CreateActionResult(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Save(EmployeeCreateDto employeeDto)
        {
            return CreateActionResult(await _employeeService.AddAsync(employeeDto));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(EmployeeUpdateDto productDto)
        {
            var result = await _employeeService.UpdateAsync(productDto);
            return CreateActionResult(result);
        }


        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _employeeService.RemoveEmployeeAsync(id));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveAll(List<int> ids)
        {
            return CreateActionResult(await _employeeService.RemoveRangeAsync(ids));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Any(int id)
        {
            return CreateActionResult(await _employeeService.AnyAsync(x => x.Id == id));
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetEmployeesWithDepartmentAndPositionByDepartment(int id)
        {
            var response = await _employeeService.GetEmployeesWithDepartmentAndPositionByDepartment(id);
            return CreateActionResult(response);
        }

        [HttpGet("[action]/{departmentId}")]
        public async Task<IActionResult> GetEmployeesByDepartmentId(int departmentId)
        {
            return CreateActionResult(await _employeeService.Where(x => x.DepartmentId == departmentId));
        }

        [HttpGet("[action]/{positionId}")]
        public async Task<IActionResult> GetEmployeesByPositonId(int positionId)
        {
            return CreateActionResult(await _employeeService.Where(x => x.PositionId == positionId));
        }

        
    }
}
