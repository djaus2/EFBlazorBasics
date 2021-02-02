using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFBlazorBasics.Data
{
    public interface IHelperService
    {
        Task<List<Activity>> GetActivitys();
        Task<List<Helper>> GetHelpers();
        Task<List<Round>> GetRounds(); 
        Task AddSomeData();
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

        public async Task<List<Helper>> GetHelpers()
        {
            var list = await _context.Helpers.ToListAsync<Helper>();
            return list;
        }

        public async Task<List<Round>> GetRounds()
        {
            var list = await _context.Rounds.ToListAsync<Round>();
            return list;
        }

        public async Task AddActivitys(List<Activity> activitys)
        {
            _context.Activitys.AddRange(activitys);
            await _context.SaveChangesAsync();
        }

        string ActivitysJson = "[{\"Round\":{\"No\":1},\"Helper\":{\"Name\":\"John Marshall\"}, \"Task\":\"Shot Put\"},{ \"Round\":{ \"No\":2},\"Helper\":{ \"Name\":\"Sue Burrows\"},\"Task\":\"Marshalling\"},{ \"Round\":{ \"No\":3},\"Helper\":{ \"Name\":\"Jimmy Beans\"},\"Task\":\"Discus\"}]";
        public async Task AddSomeData()
        {
           var activitys = JsonConvert.DeserializeObject<List<Activity>>(ActivitysJson);
            await AddActivitys(activitys);
        }
    }
}
