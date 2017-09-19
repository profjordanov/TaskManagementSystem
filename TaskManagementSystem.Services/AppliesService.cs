using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TaskManagementSystem.Models.EntityModels;

namespace TaskManagementSystem.Services
{
    public class AppliesService : Service
    {
        public async Task<IEnumerable<Apply>> GetAllAppliesAsync()
        {
            IEnumerable<Apply> applies = await this.Context.Applies.ToListAsync();
            return applies;
        }

        public async Task<Apply> GetApplyAsync(int? id)
        {
            Apply apply = await this.Context.Applies.FindAsync(id);
            return apply;
        }
    }
}