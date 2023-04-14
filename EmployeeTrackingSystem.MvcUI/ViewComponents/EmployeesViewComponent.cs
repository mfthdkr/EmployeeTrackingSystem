using EmployeeTrackingSystem.CoreLayer.DTOs.Employee;
using EmployeeTrackingSystem.MvcUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingSystem.MvcUI.ViewComponents
{
    public class EmployeesViewComponent : ViewComponent
    {
        private readonly EmployeeApiService _employeeApiService;
        private readonly PositionApiService _positionApiService;
        private readonly DepartmentApiService _departmentApiService;

        public EmployeesViewComponent(EmployeeApiService employeeApiService, PositionApiService positionApiService, DepartmentApiService departmentApiService)
        {
            _employeeApiService = employeeApiService;
            _positionApiService = positionApiService;
            _departmentApiService = departmentApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int departmentId, int? positionId = null)
        {
            var result = await _employeeApiService.GetEmployeesWithDepartmentAndPositionByDepartment(departmentId);
            var employeesActive = result.Where(p => p.OutDate == null).ToList();
            ViewBag.DepartmentId = departmentId;
            if (positionId != null)
            {
                List<EmployeesWithDepartmentAndPositionDto> response;
                response = employeesActive.Where(p => p.PositionId == positionId).ToList();
                return View(response);
            }
            return View(employeesActive);
        }
    }
}
