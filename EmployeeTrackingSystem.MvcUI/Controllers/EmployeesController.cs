using AutoMapper;
using EmployeeTrackingSystem.CoreLayer.DTOs.Employee;
using EmployeeTrackingSystem.MvcUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeTrackingSystem.MvcUI.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly EmployeeApiService _employeeApiService;
        private readonly PositionApiService _positionApiService;
        public EmployeesController(EmployeeApiService employeeApiService, PositionApiService positionApiService, IMapper mapper)
        {
            _employeeApiService = employeeApiService;
            _positionApiService = positionApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _employeeApiService.GetSingleByIdWithDepartmentAndPosition(id);
            ViewBag.EmployeeId = response.Id;
            return View(response);
        }

        public async Task<IActionResult> Create(int departmentId)
        {
            var employe = new EmployeeCreateDto();
            employe.DepartmentId = departmentId;
            var positions = await _positionApiService.GetAllByDepartment(departmentId);
            ViewBag.Positions = new SelectList(positions, "Id", "Name");
            return View(employe);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                if (dto.PositionId == 0)
                    dto.PositionId = null;
                await _employeeApiService.SaveAsync(dto);
                return RedirectToAction("Details", "Departments", new { id = dto.DepartmentId });
            }
            var employe = new EmployeeCreateDto();
            employe.DepartmentId = dto.DepartmentId;
            var positions = await _positionApiService.GetAllByDepartment(Convert.ToInt32(dto.DepartmentId));
            ViewBag.Positions = new SelectList(positions, "Id", "Name");
            return View(employe);
        }


        public async Task<IActionResult> Dismiss(int id)
        {
            var dto = _employeeApiService.GetSingleByIdWithDepartmentAndPosition(id).Result;
            var updateDto = _mapper.Map<EmployeeUpdateDto>(dto);
            updateDto.PositionId = null;
            await _employeeApiService.UpdateAsync(updateDto);
            return RedirectToAction("Details", "Departments", new { id = dto.DepartmentId });
        }

        public async Task<IActionResult> Assignment(int id)
        {
            var dto = await _employeeApiService.GetSingleByIdWithDepartmentAndPosition(id);
            ViewBag.DepartmentName = dto.Department.Name;
            var response = _mapper.Map<EmployeeUpdateDto>(dto);
            var positions = await _positionApiService.GetAllByDepartment(Convert.ToInt32(response.DepartmentId));
            ViewBag.Positions = new SelectList(positions, "Id", "Name");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Assignment(EmployeeUpdateDto requestDto)
        {
            var dto = await _employeeApiService.GetSingleByIdWithDepartmentAndPosition(requestDto.Id);
            var updateDto = _mapper.Map<EmployeeUpdateDto>(dto);
            updateDto.PositionId = requestDto.PositionId;
            await _employeeApiService.UpdateAsync(updateDto);
            return RedirectToAction("Details", "Departments", new { id = dto.DepartmentId });
        }

        public async Task<IActionResult> Fire(int id)
        {
            var dto = await _employeeApiService.GetSingleByIdWithDepartmentAndPosition(id);
            var updateDto = _mapper.Map<EmployeeUpdateDto>(dto);
            updateDto.OutDate = DateTime.Now;
            await _employeeApiService.UpdateAsync(updateDto);
            return RedirectToAction("Details", "Departments", new { id = dto.DepartmentId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _employeeApiService.GetSingleByIdWithDepartmentAndPosition(id);
            await _employeeApiService.RemoveAsync(id);
            return RedirectToAction("Details", "Departments", new { id = dto.DepartmentId });
        }

        public async Task<IActionResult> Update(int id)
        {
            var dto = await _employeeApiService.GetSingleByIdWithDepartmentAndPosition(id);
            ViewBag.DepartmentName = dto.Department.Name;
            var response = _mapper.Map<EmployeeUpdateDto>(dto);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EmployeeUpdateDto requestDto)
        {
            if (ModelState.IsValid)
            {   
                await _employeeApiService.UpdateAsync(requestDto);
                return RedirectToAction("Details", "Employees", new { id = requestDto.Id });
            }
            var dto = await _employeeApiService.GetSingleByIdWithDepartmentAndPosition(requestDto.Id);
            ViewBag.DepartmentName = dto.Department.Name;
            var response = _mapper.Map<EmployeeUpdateDto>(dto);
            return View(response);
        }
    }
}
