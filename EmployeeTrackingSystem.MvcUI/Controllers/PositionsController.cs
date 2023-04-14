using EmployeeTrackingSystem.CoreLayer.DTOs.Position;
using EmployeeTrackingSystem.MvcUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingSystem.MvcUI.Controllers
{
    public class PositionsController : Controller
    {
        private readonly PositionApiService _positionApiService;
        private readonly DepartmentApiService _departmentApiService;

        public PositionsController(PositionApiService positionApiService, DepartmentApiService departmentApiService)
        {
            _positionApiService = positionApiService;
            _departmentApiService = departmentApiService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _positionApiService.GetByIdAsync(id);
            var department = await _departmentApiService.GetByIdAsync(result.DepartmentId);
            ViewBag.DeparmentName = department.Name;
            return View(result);
        }

        public IActionResult Create(int departmentId)
        {
            PositionCreateDto dto = new PositionCreateDto()
            {
                DepartmentId = departmentId,
            };
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PositionCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _positionApiService.SaveAsync(dto);
                return RedirectToAction("Details", "Departments", new { id = dto.DepartmentId });
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var dto = await _positionApiService.GetByIdAsync(id);
            PositionUpdateDto response = new PositionUpdateDto
            {
                DepartmentId = dto.DepartmentId,
                Id = dto.Id,
                Name = dto.Name,
            };
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PositionUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _positionApiService.UpdateAsync(dto);
                return RedirectToAction("Details", "Departments", new { id = dto.DepartmentId });
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _positionApiService.GetByIdAsync(id);
            await _positionApiService.RemoveAsync(id);
            return RedirectToAction("Details", "Departments", new { id = dto.DepartmentId });
        }

        
    }
}
