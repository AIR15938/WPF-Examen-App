using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPF.DataAccess;
using WPF.Model;

namespace WPF.Repositories
{
    public class NavigationRepository : INavigationRepository
    {
        private Func<AppDbContext> _contextCreator;

        public NavigationRepository(Func<AppDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetEntityAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Entities.AsNoTracking()
                  .Select(f =>
                  new LookupItem
                  {
                      Id = f.Id,
                      DisplayMember = f.Name
                  })
                  .ToListAsync();
            }
        }
    }
}
