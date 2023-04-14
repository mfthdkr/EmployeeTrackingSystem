using EmployeeTrackingSystem.CoreLayer.DTOs.Address;
using EmployeeTrackingSystem.CoreLayer.DTOs.Position;
using EmployeeTrackingSystem.MvcUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingSystem.MvcUI.Controllers
{
    public class AddressesController : Controller
    {
        private readonly AddressApiService _addressApiService;

        public AddressesController(AddressApiService addressApiService)
        {
            _addressApiService = addressApiService;
        }

        public IActionResult Create(int employeeId)
        {
            AddressDto dto = new AddressDto()
            {
                EmployeeId = employeeId,
            };
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddressDto dto)
        {
            if (ModelState.IsValid)
            {
                await _addressApiService.SaveAsync(dto);
                return RedirectToAction("Details", "Employees", new { id = dto.EmployeeId });
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var dto = await _addressApiService.GetByIdAsync(id);
            AddressDto response = new AddressDto
            {
               EmployeeId=dto.EmployeeId,
               City = dto.City,
               FullAddress = dto.FullAddress,
               Id = dto.Id,
            };
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AddressDto dto)
        {
            if (ModelState.IsValid)
            {
                await _addressApiService.UpdateAsync(dto);
                return RedirectToAction("Details", "Employees", new { id = dto.EmployeeId });
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _addressApiService.GetByIdAsync(id);
            await _addressApiService.RemoveAsync(id);
            return RedirectToAction("Details", "Employees", new { id = dto.EmployeeId });
        }
    }
}
