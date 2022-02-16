namespace HR.LeaveManagement.Application.Persistance.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> IsExist(int id);
        Task UpdateAsync(T entity);
    }
}
