using System.ComponentModel.DataAnnotations;

namespace EmployeeTrackingSystem.CoreLayer.Entities
{
    public class Position : BaseEntity
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }
       
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }

    }
}
