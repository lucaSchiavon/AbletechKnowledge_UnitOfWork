namespace UintsOfWorkTest.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Remove(T entity);
    }
}
