using EmployeeTrackingSystem.CoreLayer.DTOs.Common;
using EmployeeTrackingSystem.CoreLayer.DTOs.Department;

namespace EmployeeTrackingSystem.MvcUI.Services
{
    public class DepartmentApiService
    {
        private readonly HttpClient _httpClient;

        public DepartmentApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<DepartmentDto>>>("Departments/GetAll");
            return response.Data;
        }

        public async Task<DepartmentDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<DepartmentDto>>($"Departments/GetSingleById/{id}");
            return response.Data;
        }

        public async Task<DepartmentCreateDto> SaveAsync(DepartmentCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("Departments/Save", dto);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<DepartmentCreateDto>>();
            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(DepartmentDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("Departments/Update", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Departments/Remove/{id}");
            return response.IsSuccessStatusCode;
        }

        
    }
}
