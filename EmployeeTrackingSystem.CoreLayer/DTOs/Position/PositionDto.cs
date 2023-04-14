using EmployeeTrackingSystem.CoreLayer.DTOs.Common;

namespace EmployeeTrackingSystem.CoreLayer.DTOs.Position
{
    public class PositionDto: BaseDto
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
