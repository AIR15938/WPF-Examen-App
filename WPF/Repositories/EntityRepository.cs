using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WPF.DataAccess;
using WPF.Model;

namespace WPF.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private AppDbContext _context;

        public EntityRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Entity entity)
        {
            _context.Entities.Add(entity);
        }

        public async Task <Entity> GetByIdAsync(int entityId)
        {              
           return await _context.Entities.SingleAsync(f => f.Id == entityId);            
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Remove(Entity entity)
        {
            _context.Entities.Remove(entity);

        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

    }
}
