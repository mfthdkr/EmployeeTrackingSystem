using EmployeeTrackingSystem.CoreLayer.Entities;
using EmployeeTrackingSystem.CoreLayer.Repositories;
using EmployeeTrackingSystem.DataAccessLayer.EntityFramework.Context;

namespace EmployeeTrackingSystem.DataAccessLayer.EntityFramework.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(EmployeeTrackingSystemContext context) : base(context)
        {
        }
    }
}
