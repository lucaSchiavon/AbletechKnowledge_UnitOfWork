using UintsOfWorkTest.Repositories;

namespace UintsOfWorkTest.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        Task<int> CommitAsync();
    }
}
