using EmployeeTrackingSystem.CoreLayer.DTOs.Common;

namespace EmployeeTrackingSystem.CoreLayer.DTOs.Employee
{
    public class EmployeeDto: BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public int? DepartmentId { get; set; }
        public int? PositionId { get; set; }

        // Details sayfası için
        public string? TCNumber { get; set; }
        public char? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthCity { get; set; }
        public DateTime? Indate { get; set; }
        public DateTime? OutDate { get; set; }
        public string? PhoneNumber1 { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? LevelOfEducation { get; set; }
    }
}
