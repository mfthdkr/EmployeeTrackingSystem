using EmployeeTrackingSystem.BusinessLayer.Services;
using EmployeeTrackingSystem.CoreLayer.DTOs.Address;
using EmployeeTrackingSystem.CoreLayer.DTOs.Position;
using EmployeeTrackingSystem.CoreLayer.Entities;
using EmployeeTrackingSystem.CoreLayer.Services;
using EmployeeTrackingSystem.WebAPI.Filter;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingSystem.WebAPI.Controllers
{
    public class AddressesController : CustomBaseController
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [ServiceFilter(typeof(NotFoundFilter<Address, AddressDto>))]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetSingleById(int id)
        {
            return CreateActionResult(await _addressService.GetByIdAsync(id));
        }

        [HttpGet("[action]/{employeeId}")]
        public async Task<IActionResult> GetAddressesByEmployee(int employeeId)
        {
            var result = await _addressService.Where(a => a.EmployeeId == employeeId);
            return CreateActionResult(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Save(AddressDto dto)
        {
            return CreateActionResult(await _addressService.AddAsync(dto));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(AddressDto dto)
        {
            return CreateActionResult(await _addressService.UpdateAsync(dto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Address, AddressDto>))]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _addressService.RemoveAsync(id));
        }
    }
}
