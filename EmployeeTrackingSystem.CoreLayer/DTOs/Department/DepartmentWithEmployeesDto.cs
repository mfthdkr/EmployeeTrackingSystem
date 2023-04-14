using EmployeeTrackingSystem.CoreLayer.DTOs.Employee;

namespace EmployeeTrackingSystem.CoreLayer.DTOs.Department
{
    public class DepartmentWithEmployeesDto: DepartmentDto
    {
        public List<EmployeeDto> Employees { get; set; }
    }
}
