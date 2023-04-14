using EmployeeTrackingSystem.CoreLayer.DTOs.Employee;

namespace EmployeeTrackingSystem.CoreLayer.DTOs.Position
{
    public class PositionWithEmployeesDto: PositionDto
    {
        public List<EmployeeDto> Employees { get; set; }
    }
}
