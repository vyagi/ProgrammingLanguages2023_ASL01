using AspNetMvc.Models.SuperHeroes;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvc.Controllers
{
    public class SuperHeroController : Controller
    {
        public IActionResult Index()
        {
            var heroes = SuperHero.Heroes;

            return View(heroes);
        }

        public IActionResult Details(int id)
        {
            var hero = SuperHero.Heroes.First(x => x.Id == id);

            return View(hero);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SuperHeroCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingHeroes = SuperHero.Heroes;
            var maxId = existingHeroes.Max(x => x.Id);

            var newHero = new SuperHero(maxId + 1, model.Name, model.Age, model.Powers.Split(",").ToList());
            SuperHero.Heroes.Add(newHero);
            
            return RedirectToAction("Index");
        }
    }
}
