namespace EmployeeTrackingSystem.CoreLayer.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
