using AutoMapper;
using EmployeeTrackingSystem.CoreLayer.DTOs.Address;
using EmployeeTrackingSystem.CoreLayer.DTOs.Department;
using EmployeeTrackingSystem.CoreLayer.DTOs.Employee;
using EmployeeTrackingSystem.CoreLayer.DTOs.Position;
using EmployeeTrackingSystem.CoreLayer.Entities;

namespace EmployeeTrackingSystem.BusinessLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {   
            // Employees
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();
            CreateMap<Employee, EmployeesWithDepartmentAndPositionDto>().ReverseMap();

            // Departments
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, DepartmentCreateDto>().ReverseMap();
            CreateMap<Department, DepartmentUpdateDto>().ReverseMap();
            CreateMap<Department, DepartmentWithPositionDto>().ReverseMap();
            CreateMap<Department, DepartmentWithEmployeesDto>().ReverseMap();

            // Address
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, AddressCreateDto>().ReverseMap();
            CreateMap<Address, AddressUpdateDto>().ReverseMap();

            // Positions
            CreateMap<Position, PositionDto>().ReverseMap();
            CreateMap<Position, PositionCreateDto>().ReverseMap();
            CreateMap<Position, PositionUpdateDto>().ReverseMap();
            CreateMap<Position, PositionWithEmployeesDto>().ReverseMap();
        }
    }
}
