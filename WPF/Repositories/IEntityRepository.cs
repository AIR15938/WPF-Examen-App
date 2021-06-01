using System.Threading.Tasks;
using WPF.Model;

namespace WPF.Repositories
{
    public interface IEntityRepository
    {
        Task<Entity> GetByIdAsync(int entityId);
        Task SaveAsync();

        bool HasChanges();

        void Add(Entity entity);

        void Remove(Entity entity);
    }
}