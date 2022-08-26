using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Data.Models;
using Movies.Data.Services;
using System.Data;

namespace Movies.Web.Controllers
{
    public class CharacterController : Controller
    {
        public CharacterController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        CharacterService characterService = new CharacterService();
        // GET: MovieController
        public ActionResult Index(DataTable table)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            characterService.display(conStr, table);
            return View(table);
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View(new Character());
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Character character)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            characterService.Create(conStr, character);
            return RedirectToAction("Index");
        }

        // GET: MovieController/Edit/5
        [HttpGet]
        public ActionResult Edit(int MovieID, int ActorID, string CharacterName, Character character)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            characterService.Edit(conStr, MovieID, ActorID, CharacterName, character);
            return View(character);
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Character character)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            characterService.Edit(conStr, character);
            return RedirectToAction(nameof(Index));
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int MovieID, int ActorID, string CharacterName)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            characterService.Delete(conStr, MovieID, ActorID, CharacterName);
            return RedirectToAction(nameof(Index));
        }
    }
}
