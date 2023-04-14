using EmployeeTrackingSystem.CoreLayer.DTOs.Position;
using EmployeeTrackingSystem.CoreLayer.Entities;
using EmployeeTrackingSystem.CoreLayer.Services;
using EmployeeTrackingSystem.WebAPI.Filter;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingSystem.WebAPI.Controllers
{
    public class PositionsController : CustomBaseController
    {
        private readonly IPositionService _positionService;

        public PositionsController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _positionService.GetAllAsync());
        }

        [HttpGet("[action]/{departmentId}")]
        public async Task<IActionResult> GetAllByDepartment(int departmentId)
        {
            return CreateActionResult(await _positionService.Where(d=>d.DepartmentId == departmentId));
        }

        [ServiceFilter(typeof(NotFoundFilter<Position, PositionDto>))]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetSingleById(int id)
        {
            return CreateActionResult(await _positionService.GetByIdAsync(id));
        }

        [ServiceFilter(typeof(NotFoundFilter<Position, PositionDto>))]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetSingleByIdWithEmployees(int id)
        {
            return CreateActionResult(await _positionService.GetSingleByIdWithEmployees(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Save(PositionCreateDto dto)
        {
            return CreateActionResult(await _positionService.AddAsync(dto));
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> Update(PositionUpdateDto dto)
        {
            return CreateActionResult(await _positionService.UpdateAsync(dto));
        }


        [ServiceFilter(typeof(NotFoundFilter<Position, PositionDto>))]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _positionService.RemovePositionAsync(id));
        }

        
    }
}
