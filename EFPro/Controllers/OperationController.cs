using EFPro.Data;
using EFPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFPro.Controllers
{
    public class OperationController:Controller
    {
        private AppDbcontext _db;

        public OperationController(AppDbcontext db)
        {
            _db = db;
        }
        public IActionResult add()
        {
            var serieA = _db.leagues.Single(x => x.name == "seriA");
            var leag = new League { name = "seria1", country = "italy" };
            var leag2 = new League { name = "seria2", country = "italy" };
            var leag3= new League { name = "seria3", country = "italy" };
            var clb = new Club { league = serieA, name = "clubs" };
            _db.AddRange(leag,leag2,leag3,clb);
            var count= _db.SaveChanges();
            return Json(count);
        }
        public IActionResult get()
        {
            var serieA = _db.leagues.Single(x => x.name == "seriA");
            return Json($"{serieA}");
        }
        public IActionResult getall()
        {
            var leagues = _db.leagues.Where(x=>x.country=="italy").ToArray();
            var leagues2 = _db.leagues.Where(x => EF.Functions.Like(x.country,"%t%")).ToList().OrderByDescending(x=>x.id);
            return Json(leagues2);
        }
        public IActionResult del()
        {
            var league = _db.leagues.Where(x => x.id == 3).Single();
            _db.Remove(league);
            //_db.RemoveRange(leagues);
            var count=_db.SaveChanges();
            return Json(count);
        }
        public IActionResult edit()
        {
            var league = _db.leagues.Single(x=>x.id==7);
            league.name += "后添加部分";
            var count = _db.SaveChanges();
            return Json(count);
        }
        public IActionResult getpage()
        {
            var league = _db.leagues.Skip(2).Take(3).ToArray();
            return Json(league);
        }
        public IActionResult getconnet()
        {
            var clb = _db.clubs.Include(x => x.league)
                .Include(x=>x.players)
                .ThenInclude(y=>y.resume).ToArray();
            var clib2 = _db.clubs.Select(x=>new
            {
                x.id,
                League=x.league,
                x.name,
                Players=x.players.Where(p=>p.id>2)
            }).ToList();
            return Json(clib2);
        }
        public IActionResult modify()
        {
            var club = _db.clubs.Include(x => x.league).First();
            club.league.country = "Armyous";
            _db.Entry(club).State = EntityState.Modified;
            _db.SaveChanges();
            return Json(club);
        }
        public IActionResult sqlraw()
        {
            var league = _db.leagues.FromSqlRaw("select * from leagues").ToList();
            return Json(league);
        }
        public IActionResult sqlraw2()
        {
            var league = _db.leagues.FromSqlInterpolated($"select * from leagues where id>{6}")
                .ToList();
            return Json(league);
        }
        
    }
}
