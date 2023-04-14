using EmployeeTrackingSystem.CoreLayer.DTOs.Department;
using EmployeeTrackingSystem.CoreLayer.DTOs.Position;

namespace EmployeeTrackingSystem.CoreLayer.DTOs.Employee
{
    public class EmployeesWithDepartmentAndPositionDto : EmployeeDto
    {
        public DepartmentDto Department { get; set; }
        public PositionDto Position { get; set; }
    }
}
