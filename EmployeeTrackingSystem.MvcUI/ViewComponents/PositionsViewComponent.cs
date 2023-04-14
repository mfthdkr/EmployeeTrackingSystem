using EmployeeTrackingSystem.MvcUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingSystem.MvcUI.ViewComponents
{
    public class PositionsViewComponent : ViewComponent
    {
        private readonly PositionApiService _positionApiService;
        private readonly DepartmentApiService _departmentApiService;

        public PositionsViewComponent(PositionApiService positionApiService, DepartmentApiService departmentApiService)
        {
            _positionApiService = positionApiService;
            _departmentApiService = departmentApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int departmentId)
        {
            var result = await _positionApiService.GetAllByDepartment(departmentId);
            ViewBag.DepartmentId = departmentId;
            return View(result);
        }
    }
}
