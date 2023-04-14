namespace EmployeeTrackingSystem.CoreLayer.Entities
{
    public class Address : BaseEntity
    {
        public string? City { get; set; }
        public string? FullAddress { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
