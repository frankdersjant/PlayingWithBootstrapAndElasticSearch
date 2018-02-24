using AutoMapper;
using DataLayer;
using Domain.DomainModels.Persons;
using PlayingWithBootstrap.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace PlayingWithBootstrap.Controllers
{
    public class HomeController : Controller
    {
        private NotificationContext _context { get; set; }

        public HomeController(NotificationContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var result = (_context.Persons.Include(s => s.Skills)).ToList();
            var vm = Mapper.Map<List<Person>, List<PersonVM>>(result);

            return View(vm);
        }

        public ActionResult SearchPeople(string searchText)
        {
            var result = _context.Persons.Where
                (p =>
                     p.FirstName.ToLower().Contains(searchText.ToLower()) ||
                     p.LastName.ToLower().Contains(searchText.ToLower())
                 ).Include(s => s.Skills);

            return PartialView("_SearchPeople", result);
        }

    }
}