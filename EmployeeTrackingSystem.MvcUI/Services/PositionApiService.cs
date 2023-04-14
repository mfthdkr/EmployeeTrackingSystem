using EmployeeTrackingSystem.CoreLayer.DTOs.Common;
using EmployeeTrackingSystem.CoreLayer.DTOs.Position;

namespace EmployeeTrackingSystem.MvcUI.Services
{
    public class PositionApiService
    {
        private readonly HttpClient _httpClient;

        public PositionApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PositionDto>> GetAllByDepartment(int departmentId)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<PositionDto>>>($"Positions/GetAllByDepartment/{departmentId}");
            return response.Data;
        }


        public async Task<PositionCreateDto> SaveAsync(PositionCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("Positions/Save", dto);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<PositionCreateDto>>();
            return responseBody.Data;
        }

        public async Task<PositionDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<PositionDto>>($"Positions/GetSingleById/{id}");
            return response.Data;
        }

        public async Task<bool> UpdateAsync(PositionUpdateDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("Positions/Update", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Positions/Remove/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
