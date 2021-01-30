using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFBlazorBasics.Data
{
    public interface IHelperService
    {
        Task<List<Activity>> GetActivitys();
    }

    public class HelperService : IHelperService
    {
        private readonly ApplicationDbContext _context;
        public HelperService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Activity>> GetActivitys()
        {
            var list = await _context.Activitys.Include(activity => activity.Helper).Include(activity => activity.Round).ToListAsync();
            return list;
        }
    }
}
