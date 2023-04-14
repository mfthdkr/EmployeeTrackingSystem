using EmployeeTrackingSystem.CoreLayer.DTOs.Position;

namespace EmployeeTrackingSystem.CoreLayer.DTOs.Department
{
    public class DepartmentWithPositionDto: DepartmentDto
    {
        public List<PositionDto> Positions { get; set; }
    }
}
