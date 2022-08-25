using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Data.Services;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Movies.Data.Models;

namespace Movies.Web.Controllers
{
    public class MovieController : Controller
    {
        public MovieController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        MovieService movieService = new MovieService();
        // GET: MovieController
        public ActionResult Index(DataTable table)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            movieService.displayMovies(conStr, table);
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
            return View(new Movie());
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            movieService.Create(conStr, movie);
            return RedirectToAction("Index");
        }

        // GET: MovieController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id, Movie movie)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            movieService.Edit(conStr,id, movie);
            return View(movie);
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            movieService.Edit(conStr, movie);
            return RedirectToAction(nameof(Index));
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            string conStr = this.Configuration.GetConnectionString("MoviesDB");
            movieService.Delete(conStr, id);
            return RedirectToAction(nameof(Index));
        }
    }
}
