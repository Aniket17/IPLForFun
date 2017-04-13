using IPLForFun.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IPLForFun.Services
{
    public class MatchesService
    {
        private ApplicationDbContext _ctx;
        public MatchesService(ApplicationDbContext db)
        {
            _ctx = db;
        }

        public List<Match> GetCurrentMatches(string userName)
        {
            return _ctx.Matches.Where(m => m.Date == DbFunctions.TruncateTime(DateTime.Now)).ToList();
        }
    }
}