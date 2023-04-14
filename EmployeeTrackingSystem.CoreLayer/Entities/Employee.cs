using System.ComponentModel.DataAnnotations;

namespace EmployeeTrackingSystem.CoreLayer.Entities
{
    public class Employee : BaseEntity
    {
        public Employee()
        {
            Addresses = new HashSet<Address>();
        }
       
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? TCNumber { get; set; }
        public char? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthCity { get; set; }
        public DateTime? Indate { get; set; }
        public DateTime? OutDate { get; set; }
        public string? PhoneNumber1 { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? LevelOfEducation { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int? PositionId { get; set; }
        public Position? Position { get; set; }
        public virtual ICollection<Address>? Addresses { get; set; }
    }
}
