namespace EmployeeTrackingSystem.CoreLayer.DTOs.Address
{
    public class AddressUpdateDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string FullAddress { get; set; }
        public int EmployeeId { get; set; }
    }
}
