using System.ComponentModel.DataAnnotations;

namespace EmployeeTrackingSystem.CoreLayer.Entities
{
    public class Department : BaseEntity
    {
        public Department()
        {
            Positions = new HashSet<Position>();
            Employees = new HashSet<Employee>();
        }
        
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public virtual ICollection<Position>? Positions { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }

    }
}
