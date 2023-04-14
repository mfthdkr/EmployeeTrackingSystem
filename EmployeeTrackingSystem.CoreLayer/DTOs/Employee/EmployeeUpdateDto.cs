using System.ComponentModel.DataAnnotations;

namespace EmployeeTrackingSystem.CoreLayer.DTOs.Employee
{
    public class EmployeeUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        [StringLength(11)]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "TC Kimlik Numarası 11 haneli sayısal karakter olmalı.")]
        public string? TCNumber { get; set; }
        public char? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthCity { get; set; }
        public DateTime? Indate { get; set; }
        public DateTime? OutDate { get; set; }
        [StringLength(10)]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Telefon numarasını başında sıfır olmadan 10 haneli olarak giriniz.")]
        public string? PhoneNumber1 { get; set; }
        [StringLength(10)]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Telefon numarasını başında sıfır olmadan 10 haneli olarak giriniz.")]
        public string? PhoneNumber2 { get; set; }
        public string? LevelOfEducation { get; set; }
        public bool? IsDeleted { get; set; } = false;

        public int? DepartmentId { get; set; }
        public int? PositionId { get; set; }

    }
}
