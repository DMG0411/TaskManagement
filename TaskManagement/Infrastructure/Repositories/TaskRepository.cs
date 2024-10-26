using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(Domain.Entities.Task task)
        {
            task.CreatedAt = DateTime.UtcNow;
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var task = _context.Tasks.Find(id);
            if(task == null)
            {
                throw new Exception("Task not found");
            }
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Domain.Entities.Task> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
            {
                throw new Exception("Task not found");
            }
            return task;
        }

        public async Task UpdateAsync(Domain.Entities.Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}
