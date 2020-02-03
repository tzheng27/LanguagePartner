using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguagePartner.Models;
using Microsoft.AspNetCore.Authorization;
using LanguagePartner.Models.DataContext;

namespace LanguagePartner.Controllers
{
    public class HomeController : Controller
    {
        private readonly LearnerDataContext _db;

        public HomeController(LearnerDataContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("{key}")]
        public IActionResult Profile(string key)
        {
            //var learner = _db.Learners.FirstOrDefault(x => x.Key == key);
         
            //if (learner == null)
            //{
            //    return RedirectToAction("Create", "Home");
            //}
            //return View(learner);
            return RedirectToAction("Create", "Home");
        }

        //[Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult Create(Learner learner)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            learner.UpdatedTime = DateTime.Now;

            _db.Learners.Add(learner);
            _db.SaveChanges();

            return RedirectToAction("Profile", "Home", new
            {
                key = learner.Key
            });
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}