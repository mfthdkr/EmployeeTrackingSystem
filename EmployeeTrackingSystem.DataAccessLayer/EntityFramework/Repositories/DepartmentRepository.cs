using EmployeeTrackingSystem.CoreLayer.Entities;
using EmployeeTrackingSystem.CoreLayer.Repositories;
using EmployeeTrackingSystem.DataAccessLayer.EntityFramework.Context;

namespace EmployeeTrackingSystem.DataAccessLayer.EntityFramework.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EmployeeTrackingSystemContext context) : base(context)
        {
        }
    }
}
