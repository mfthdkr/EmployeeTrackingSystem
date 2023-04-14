using EmployeeTrackingSystem.CoreLayer.DTOs.Address;
using EmployeeTrackingSystem.CoreLayer.DTOs.Common;
using EmployeeTrackingSystem.CoreLayer.DTOs.Position;

namespace EmployeeTrackingSystem.MvcUI.Services
{
    public class AddressApiService
    {
        private readonly HttpClient _httpClient;

        public AddressApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AddressDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<AddressDto>>($"Addresses/GetSingleById/{id}");
            return response.Data;
        }
        public async Task<List<AddressDto>> GetAddressesByEmployee(int employeeId)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<AddressDto>>>($"Addresses/GetAddressesByEmployee/{employeeId}");
            return response.Data;
        }

        public async Task<AddressDto> SaveAsync(AddressDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("Addresses/Save", dto);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<AddressDto>>();
            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(AddressDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("Addresses/Update", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Addresses/Remove/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
