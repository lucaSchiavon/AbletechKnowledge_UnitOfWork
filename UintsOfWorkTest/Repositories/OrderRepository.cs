using UintsOfWorkTest.Data;
using UintsOfWorkTest.Entities;
using UintsOfWorkTest.Repositories.Base;

namespace UintsOfWorkTest.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context) { }
    }
}
