using EmployeeTrackingSystem.CoreLayer.DTOs.Department;
using EmployeeTrackingSystem.CoreLayer.Entities;
using EmployeeTrackingSystem.CoreLayer.Services;
using EmployeeTrackingSystem.WebAPI.Filter;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingSystem.WebAPI.Controllers
{
    public class DepartmentsController : CustomBaseController
    {
        private readonly IDepartmantService _departmantService;

        public DepartmentsController(IDepartmantService departmantService)
        {
            _departmantService = departmantService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _departmantService.GetAllAsync());
        }

        [ServiceFilter(typeof(NotFoundFilter<Department, DepartmentDto>))]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetSingleById(int id)
        {
            return CreateActionResult(await _departmantService.GetByIdAsync(id));
        }

        [ServiceFilter(typeof(NotFoundFilter<Department, DepartmentDto>))]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetSingleByIdWithPositions(int id)
        {
            return CreateActionResult(await _departmantService.GetSingleByIdWithPositions(id));
        }

        [ServiceFilter(typeof(NotFoundFilter<Department, DepartmentDto>))]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetSingleByIdWithEmployees(int id)
        {
            return CreateActionResult(await _departmantService.GetSingleByIdWithEmployees(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Save(DepartmentCreateDto dto)
        {
            return CreateActionResult(await _departmantService.AddAsync(dto));
        }
       
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(DepartmentUpdateDto dto)
        {
            return CreateActionResult(await _departmantService.UpdateAsync(dto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Department, DepartmentDto>))]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _departmantService.RemoveAsync(id));
        }

    }
}
