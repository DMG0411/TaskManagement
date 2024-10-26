namespace Domain.Repositories
{
    public interface ITaskRepository
    {
        Task<Entities.Task> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
        Task<Guid> AddAsync(Entities.Task task);

        Task UpdateAsync(Entities.Task task);

        Task DeleteAsync(Guid id);

        Task<IEnumerable<Entities.Task>> GetAllAsync();
    }
}
