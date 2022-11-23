using Bolawaq.data;
using Bolawaq.Models;
using Bolawaq.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Bolawaq.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {

        [HttpGet]
        public IActionResult Admin()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Admin(searchAdmin model)
        {
            if (ModelState.IsValid)
            {

                BolawaqContext _dbcontext = new BolawaqContext();

                var find = new Admin
                {
                    Name = model.AdminName,
                    Password = model.AdminPass
                };

                var user = await _dbcontext.Admins.ToListAsync();

                foreach (var a in user) {
                    if (a.Name == find.Name && a.Password == find.Password)
                    {
                        Console.WriteLine(find.Name + "  " + find.Password);
                        return RedirectToAction("Cms");
                    }
                }
            }
            return RedirectToAction("Admin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
