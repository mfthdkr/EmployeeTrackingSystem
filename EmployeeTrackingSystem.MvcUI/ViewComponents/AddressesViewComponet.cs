using EmployeeTrackingSystem.MvcUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingSystem.MvcUI.ViewComponents
{
    public class AddressesViewComponent: ViewComponent
    {
        private readonly AddressApiService _addressApiService;

        public AddressesViewComponent(AddressApiService addressApiService)
        {
            _addressApiService = addressApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int employeeId)
        {
            var result = await _addressApiService.GetAddressesByEmployee(employeeId);
            return View(result);
        }
    }
}
