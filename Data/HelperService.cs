﻿using Microsoft.EntityFrameworkCore;
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
        Task AddRounds(List<Round> rounds);
        Task AddHelpers(List<Helper> helpers);
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
            var list =  await _context.Helpers.ToListAsync<Helper>();
            return list;
        }

        public async Task<List<Round>> GetRounds()
        {
            var list =  await _context.Rounds.ToListAsync<Round>();
            return list;
        }

        public async Task AddRounds( List<Round> rounds)
        {
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT('Rounds', RESEED, 0)");
            _context.Rounds.AddRange(rounds);
            await _context.SaveChangesAsync();

        }

        public async Task AddHelpers(List<Helper> helpers)
        {
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT('Rounds', RESEED, 0)");
            _context.Helpers.AddRange(helpers);
            await _context.SaveChangesAsync();
        }

        public async Task AddActivitys(List<Activity> activitys)
        {
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT('Rounds', RESEED, 0)");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT('Rounds', RESEED, 0)");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT('Activitys', RESEED, 0)");
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


        string RoundsJson = "[{\"No\":1},{\"No\":2},{ \"No\":3}]";

        string HelpersJson = "[{\"Name\":\"John Marshall\"},{ \"Name\":\"Sue Burrows\"},{ \"Name\":\"Jimmy Beans\"}]";

        string ActivitysJson = "[{\"Round\":{\"No\":1},\"Helper\":{\"Name\":\"John Marshall\"}, \"Task\":\"Shot Put\"},{ \"Round\":{ \"No\":2},\"Helper\":{ \"Name\":\"Sue Burrows\"},\"Task\":\"Marshalling\"},{ \"Round\":{ \"No\":3},\"Helper\":{ \"Name\":\"Jimmy Beans\"},\"Task\":\"Discus\"}]";
        public async Task AddSomeData()
        {
            //var rounds = JsonConvert.DeserializeObject<List<Round>>(RoundsJson);
            //await AddRounds(rounds);

            //var helpers = JsonConvert.DeserializeObject<List<Helper>>(HelpersJson);
            //await AddHelpers(helpers);

           var activitys = JsonConvert.DeserializeObject<List<Activity>>(ActivitysJson);
            await AddActivitys(activitys);
        }
    }
}
