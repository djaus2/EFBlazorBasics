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
        Task UpdateActivityTask(int ActivityId, string newTask);
        Task UpdateActivityHelper(int ActivityId, Helper helper);
        Task UpdateActivity(Activity activity);
        Task AddActivitys(List<Activity> activitys);
        Task AddActivity(Activity activity);
        //Task AddRounds(List<Round> rounds);
        //Task AddHelpers(List<Helper> helpers);
        Task DeleteHelper(int Id);
        Task DeleteRound(int Id);
        Task DeleteActivity(int Id);
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
            // Clear any records first
            if (_context.Rounds.Count() != 0)
                _context.Rounds.RemoveRange(_context.Rounds.ToList());
            if (_context.Activitys.Count() != 0)
                _context.Activitys.RemoveRange(_context.Activitys.ToList());
            if (_context.Helpers.Count() != 0)
                _context.Helpers.RemoveRange(_context.Helpers.ToList());
            await _context.SaveChangesAsync();
            // Reset seeds
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT('Rounds', RESEED, 0)");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT('Helpers', RESEED, 0)");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT('Activitys', RESEED, 0)");
           // Save all
            _context.Activitys.AddRange(activitys);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHelper(int Id)
        {
            var helperLst = from h in _context.Helpers where h.Id == Id select h;
            if (helperLst.Count() != 0)
            {
                _context.Helpers.Remove(helperLst.FirstOrDefault());
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteActivity(int Id)
        {
            var activityLst = from a in _context.Activitys where a.Id == Id select a;
            if (activityLst.Count() != 0)
            {
                _context.Activitys.Remove(activityLst.First());
                await _context.SaveChangesAsync();
            }
        }

        // Cascade Deletion
        public async Task DeleteRound(int Id)
        {
            var roundLst = _context.Rounds.Where(e => e.Id == Id).Include(e => e.Activitys);
            if (roundLst.Count() != 0)
            {
                _context.Rounds.Remove(roundLst.First());
                await _context.SaveChangesAsync();
            }
        }

        string ActivitysJson = "[{\"Round\":{\"No\":1},\"Helper\":{\"Name\":\"John Marshall\"}, \"Task\":\"Shot Put\"},{ \"Round\":{ \"No\":2},\"Helper\":{ \"Name\":\"Sue Burrows\"},\"Task\":\"Marshalling\"},{ \"Round\":{ \"No\":3},\"Helper\":{ \"Name\":\"Jimmy Beans\"},\"Task\":\"Discus\"}]";
        public async Task AddSomeData()
        {
           var activitys = JsonConvert.DeserializeObject<List<Activity>>(ActivitysJson);
            await AddActivitys(activitys);
        }

        public async Task AddActivity(Activity activity)
        {
             _context.Activitys.Add(activity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateActivityTask(int ActivityId, string newTask)
        {
            var activitys = await GetActivitys();
            var active = from a in activitys where a.Id == ActivityId select a;
            Activity activity = active.FirstOrDefault();
            if (activity != null)
            {
                activity.Task = newTask;
                _context.Activitys.Update(activity);
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task UpdateActivityHelper(int ActivityId, Helper helper)
        {
            var activitys = await GetActivitys();
            var active = from a in activitys where a.Id == ActivityId select a;
            Activity activity = active.FirstOrDefault();
            if (activity != null)
            {
                activity.Helper = helper;
                _context.Activitys.Update(activity);
                await _context.SaveChangesAsync();
            }

        }
        public async Task UpdateActivity(Activity activity)
        {
            if (activity != null)
            {
                _context.Activitys.Update(activity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
