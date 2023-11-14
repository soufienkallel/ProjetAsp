using Microsoft.AspNetCore.Mvc;
using ProjetAsp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ProjetAsp.Controllers
{
    public class FilmController : Controller
    {
        private readonly ApplicationContext context;
        private readonly IWebHostEnvironment hostingEnvironment;

        // GET: CategorieController
        public FilmController(ApplicationContext context, IWebHostEnvironment hostingEnvironment)
        {
            this.context = context;
            this.hostingEnvironment = hostingEnvironment;
            
        }

        // GET: FilmController
        public ActionResult Index()
        {
            List<Film> films = context.Films.ToList();
            return View(films);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = context.Categories.ToList();
            return View();
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        // FilmsController.cs
        [HttpPost]
        public async Task<IActionResult> Create(Film film, IFormFile file)
        {
            if (ModelState.IsValid) // Check if the model state is valid
            {
                try
                {
                    if (file != null && file.Length > 0)
                    {
                        var uploadsPath = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                        var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
                        var filePath = Path.Combine(uploadsPath, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        film.Image = uniqueFileName;
                    }

                    context.Films.Add(film);
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Log the exception for further investigation
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the film.");
                    ViewBag.Categories = context.Categories.ToList();
                    return View(film);
                }
            }

            // If ModelState is not valid, reload the ViewBag.Categories and return to the Create view
            ViewBag.Categories = context.Categories.ToList();
            return View(film);
        }



        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}