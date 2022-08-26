using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Data.Models;
using Movies.Data.Services;
using System.Data;

namespace Movies.Web.Controllers
{
    public class GenreController : Controller
    {
        public GenreController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        GenreService genreService = new GenreService();
        // GET: MovieController
        public ActionResult Index(DataTable table)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            genreService.display(conStr, table);
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
            return View(new Genre());
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            genreService.Create(conStr, genre);
            return RedirectToAction("Index");
        }

        // GET: MovieController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id, Genre genre)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            genreService.Edit(conStr, id, genre);
            return View(genre);
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            genreService.Edit(conStr, genre);
            return RedirectToAction(nameof(Index));
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            genreService.Delete(conStr, id);
            return RedirectToAction(nameof(Index));
        }
    }
}
