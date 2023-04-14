using EmployeeTrackingSystem.CoreLayer.Entities;
using EmployeeTrackingSystem.CoreLayer.Repositories;
using EmployeeTrackingSystem.DataAccessLayer.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTrackingSystem.DataAccessLayer.EntityFramework.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeTrackingSystemContext context) : base(context)
        {
        }

        public async Task<List<Employee>> GetEmployeesWithDepartmentAndPosition(int id)
        {   
            var result = await _context.Employees.Where(x => x.Id == id).Include(x => x.Department).Include(x => x.Position).ToListAsync();
            return result;
        }

        public async Task<List<Employee>> GetEmployeesWithDepartmentAndPositionByDepartment(int id)
        {   
            var result = await _context.Employees.Where(x => x.DepartmentId == id).Include(x => x.Department).Include(x => x.Position).ToListAsync();
            return result;
        }
    }
}
