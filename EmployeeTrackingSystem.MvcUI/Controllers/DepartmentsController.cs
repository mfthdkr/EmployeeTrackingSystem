using EmployeeTrackingSystem.CoreLayer.DTOs.Department;
using EmployeeTrackingSystem.MvcUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingSystem.MvcUI.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly DepartmentApiService _departmentApiService;

        public DepartmentsController(DepartmentApiService departmentApiService)
        {
            _departmentApiService = departmentApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _departmentApiService.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _departmentApiService.GetByIdAsync(id);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _departmentApiService.SaveAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _departmentApiService.GetByIdAsync(id);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(DepartmentDto dto)
        {
            if (ModelState.IsValid)
            {
                await _departmentApiService.UpdateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _departmentApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
