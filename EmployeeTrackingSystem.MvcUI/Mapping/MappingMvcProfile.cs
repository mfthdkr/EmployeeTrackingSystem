using AutoMapper;
using EmployeeTrackingSystem.CoreLayer.DTOs.Employee;

namespace EmployeeTrackingSystem.MvcUI.Mapping
{
    public class MappingMvcProfile: Profile
    {
        public MappingMvcProfile()
        {
            // Employees
            CreateMap<EmployeeUpdateDto, EmployeesWithDepartmentAndPositionDto>().ReverseMap();
        }
        
    }
}
