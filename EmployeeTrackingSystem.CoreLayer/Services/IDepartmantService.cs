using EmployeeTrackingSystem.CoreLayer.DTOs.Common;
using EmployeeTrackingSystem.CoreLayer.DTOs.Department;
using EmployeeTrackingSystem.CoreLayer.Entities;

namespace EmployeeTrackingSystem.CoreLayer.Services
{
    public interface IDepartmantService : IService<Department,DepartmentDto>
    {
        Task<CustomResponseDto<DepartmentCreateDto>> AddAsync(DepartmentCreateDto dto);

        Task<CustomResponseDto<DepartmentWithPositionDto>> GetSingleByIdWithPositions(int id);

        Task<CustomResponseDto<DepartmentWithEmployeesDto>> GetSingleByIdWithEmployees(int id);

        Task<CustomResponseDto<NoContentDto>> UpdateAsync(DepartmentUpdateDto dto);
    }
}
