using EmployeeTrackingSystem.CoreLayer.DTOs.Common;

namespace EmployeeTrackingSystem.CoreLayer.DTOs.Address
{
    public class AddressDto: BaseDto
    {
        public DateTime? UpdatedDate { get; set; }
        public string? City { get; set; }
        public string? FullAddress { get; set; }
        public int? EmployeeId { get; set; }
    }
}
