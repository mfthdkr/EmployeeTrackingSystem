using EmployeeTrackingSystem.CoreLayer.UnitOfWorks;
using EmployeeTrackingSystem.DataAccessLayer.EntityFramework.Context;

namespace EmployeeTrackingSystem.DataAccessLayer.EntityFramework.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeTrackingSystemContext _context;

        public UnitOfWork(EmployeeTrackingSystemContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
