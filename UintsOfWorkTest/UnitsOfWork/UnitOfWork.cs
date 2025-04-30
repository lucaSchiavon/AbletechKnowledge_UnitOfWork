using UintsOfWorkTest.Data;
using UintsOfWorkTest.Repositories;

namespace UintsOfWorkTest.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public ICustomerRepository Customers { get; }
        public IOrderRepository Orders { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Orders = new OrderRepository(_context);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync(); // Commits everything
        }

        public void Dispose()
        {
            _context.Dispose();
        }


     
    }
}
