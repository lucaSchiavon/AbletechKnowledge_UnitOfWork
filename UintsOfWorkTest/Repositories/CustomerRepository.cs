using UintsOfWorkTest.Data;
using UintsOfWorkTest.Entities;
using UintsOfWorkTest.Repositories.Base;

namespace UintsOfWorkTest.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context) { }
    }
}
