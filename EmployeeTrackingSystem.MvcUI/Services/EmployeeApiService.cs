using EmployeeTrackingSystem.CoreLayer.DTOs.Common;
using EmployeeTrackingSystem.CoreLayer.DTOs.Employee;

namespace EmployeeTrackingSystem.MvcUI.Services
{
    public class EmployeeApiService
    {
        private readonly HttpClient _httpClient;

        public EmployeeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeesWithDepartmentAndPositionDto>> GetEmployeesWithDepartmentAndPositionByDepartment(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<EmployeesWithDepartmentAndPositionDto>>>($"Employees/GetEmployeesWithDepartmentAndPositionByDepartment/{id}/");
            return response.Data;

        }

        public async Task<EmployeesWithDepartmentAndPositionDto> GetSingleByIdWithDepartmentAndPosition(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<EmployeesWithDepartmentAndPositionDto>>($"Employees/GetSingleByIdWithDepartmentAndPosition/{id}/");
            return response.Data;

        }

        public async Task<EmployeeCreateDto> SaveAsync(EmployeeCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("Employees/Save", dto);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<EmployeeCreateDto>>();
            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(EmployeeUpdateDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("Employees/Update", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Employees/Remove/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
