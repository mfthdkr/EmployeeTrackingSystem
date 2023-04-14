using EmployeeTrackingSystem.CoreLayer.Entities;
using EmployeeTrackingSystem.CoreLayer.Repositories;
using EmployeeTrackingSystem.DataAccessLayer.EntityFramework.Context;

namespace EmployeeTrackingSystem.DataAccessLayer.EntityFramework.Repositories
{
    public class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        public PositionRepository(EmployeeTrackingSystemContext context) : base(context)
        {
        }
    }
}
