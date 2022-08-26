using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Data.Models;
using Movies.Data.Services;
using System.Data;

namespace Movies.Web.Controllers
{
    public class ActorController : Controller
    {
        public ActorController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        ActorService actorService = new ActorService();
        // GET: MovieController
        public ActionResult Index(DataTable table)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            actorService.display(conStr, table);
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
            return View(new Actor());
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Actor actor)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            actorService.Create(conStr, actor);
            return RedirectToAction("Index");
        }

        // GET: MovieController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id, Actor actor)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            actorService.Edit(conStr, id, actor);
            return View(actor);
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Actor actor)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            actorService.Edit(conStr, actor);
            return RedirectToAction(nameof(Index));
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            actorService.Delete(conStr, id);
            return RedirectToAction(nameof(Index));
        }
    }
}
