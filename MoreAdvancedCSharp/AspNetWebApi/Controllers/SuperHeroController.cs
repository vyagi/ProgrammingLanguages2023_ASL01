using AspNetWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public List<SuperHero> Get()
        {
            return SuperHero.Heroes;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var superHero = SuperHero.Heroes.FirstOrDefault(x => x.Id == id);

            if (superHero == null)
            {
                return NotFound();
            }

            return Ok(superHero);
        }

        [HttpPost]
        public IActionResult Post(SuperHeroCreate newHero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hero = new SuperHero(SuperHero.Heroes.Max(x => x.Id) + 1, newHero.Name, newHero.Age,
                newHero.Powers.Split(",").ToList());

            SuperHero.Heroes.Add(hero);

            return Ok(hero);
        }

        [HttpPut]
        public IActionResult Put(SuperHeroUpdate updatedHero)
        {
            var heroToUpdate = SuperHero.Heroes.FirstOrDefault(x => x.Id == updatedHero.Id);

            if (heroToUpdate == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            heroToUpdate.Age = updatedHero.Age;
            heroToUpdate.Powers = updatedHero.Powers.Split(",").ToList();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var superHero = SuperHero.Heroes.FirstOrDefault(x => x.Id == id);

            if (superHero != null) 
                SuperHero.Heroes.Remove(superHero);

            return Ok();
        }
    }
}
