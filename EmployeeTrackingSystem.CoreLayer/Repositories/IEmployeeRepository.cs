using EmployeeTrackingSystem.CoreLayer.Entities;

namespace EmployeeTrackingSystem.CoreLayer.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<List<Employee>> GetEmployeesWithDepartmentAndPositionByDepartment(int id);
        Task<List<Employee>> GetEmployeesWithDepartmentAndPosition(int id);
    }
}
