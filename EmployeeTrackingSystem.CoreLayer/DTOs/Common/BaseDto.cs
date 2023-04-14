namespace EmployeeTrackingSystem.CoreLayer.DTOs.Common
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
