using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TallerMVCRazorChallenge.Models;
using TallerMVCRazorChallenge.Repository;

namespace TallerMVCRazorChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly TallerDbContext _context;

        public HomeController(TallerDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Cars.ToList());
        }
    }
}
