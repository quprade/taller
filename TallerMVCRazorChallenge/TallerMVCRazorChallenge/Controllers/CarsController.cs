using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using TallerMVCRazorChallenge.Models;
using TallerMVCRazorChallenge.Repository;

namespace TallerMVCRazorChallenge.Controllers
{
    public class CarsController : Controller
    {
        private readonly TallerDbContext _context;

        public CarsController(TallerDbContext context)
        {
            _context = context;
        }
        // GET: CarsController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: CarsController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection model)
        {
            try
            {
                Car car = new Car();

                car.Id = _context.Cars.ToList().Count() + 1; ;
                car.Make = model["Make"];
                car.Model = model["Model"];
                car.Year = model["Year"] != "" ? Convert.ToInt32(model["Year"]) : 0;
                car.Doors = model["Doors"] != "" ? Convert.ToInt32(model["Doors"]) : 0;
                car.Color = model["Color"];
                car.Price = model["Price"] != "" ? Convert.ToInt32(model["Price"]) : 0;

                _context.Cars.Add(car);
                _context.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController1/Edit/5
        public ActionResult Edit(int id)
        {
            var car = _context.Cars.Find(id);
            return View(car);
        }

        // POST: CarsController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection model)
        {
            try
            {
                var car = _context.Cars.Find(id);

                car.Id = id;
                car.Make = model["Make"];
                car.Model = model["Model"];
                car.Year = model["Year"] != "" ? Convert.ToInt32(model["Year"]) : 0;
                car.Doors = model["Doors"] != "" ? Convert.ToInt32(model["Doors"]) : 0;
                car.Color = model["Color"];
                car.Price = model["Price"] != "" ? Convert.ToInt32(model["Price"]) : 0;

                _context.Cars.Update(car);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController1/Delete/5
        public ActionResult Delete(int id)
        {
            var car = _context.Cars.Find(id);
            return View(car);
        }

        // POST: CarsController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var car = _context.Cars.Find(id);
                _context.Cars.Remove(car);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Guess(int id)
        {
            var car = _context.Cars.Find(id);
            return View(car);
        }
        [HttpGet]
        public bool GuessSearch(int id, int searchprice)
        {
            try
            {
                Int32 interval = 5000;

                var car = _context.Cars.Where(u => u.Id == id).ToList();
                if (car.Count == 0)
                    return false;

                if ((car[0].Price - interval) <= searchprice && (car[0].Price + interval) >= searchprice)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
