using EmployeeTrackingSystem.CoreLayer.DTOs.Common;
using EmployeeTrackingSystem.CoreLayer.DTOs.Employee;
using EmployeeTrackingSystem.CoreLayer.Entities;

namespace EmployeeTrackingSystem.CoreLayer.Services
{
    public interface IEmployeeService: IService<Employee,EmployeeDto>
    {
        Task<CustomResponseDto<EmployeeCreateDto>> AddAsync(EmployeeCreateDto dto);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(EmployeeUpdateDto dto);
        Task<CustomResponseDto<List<EmployeesWithDepartmentAndPositionDto>>> GetEmployeesWithDepartmentAndPositionByDepartment(int id);

        Task<CustomResponseDto<EmployeesWithDepartmentAndPositionDto>> GetSingleByIdWithDepartmentAndPosition(int id);

        Task<CustomResponseDto<NoContentDto>> RemoveEmployeeAsync(int id);
    }
}
