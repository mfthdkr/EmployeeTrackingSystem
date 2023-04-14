namespace EmployeeTrackingSystem.CoreLayer.DTOs.Employee
{
    public class EmployeeCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public int? DepartmentId { get; set; }
        public int? PositionId { get; set; }
    }
}
