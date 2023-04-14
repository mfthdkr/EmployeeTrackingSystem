using EmployeeTrackingSystem.CoreLayer.DTOs.Common;
using EmployeeTrackingSystem.CoreLayer.DTOs.Position;
using EmployeeTrackingSystem.CoreLayer.Entities;

namespace EmployeeTrackingSystem.CoreLayer.Services
{
    public interface IPositionService: IService<Position,PositionDto>
    {
        Task<CustomResponseDto<PositionWithEmployeesDto>> GetSingleByIdWithEmployees(int id);

        Task<CustomResponseDto<PositionCreateDto>> AddAsync(PositionCreateDto dto);

        Task<CustomResponseDto<NoContentDto>> UpdateAsync(PositionUpdateDto dto);

        Task<CustomResponseDto<NoContentDto>> RemovePositionAsync(int id);
    }
}
