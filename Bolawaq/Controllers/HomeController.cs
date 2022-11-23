using Bolawaq.Models;
using Bolawaq.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Bolawaq.data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bolawaq.Controllers
{
    
    public class HomeController : Controller
    {
        [HttpGet]

        public IActionResult Booking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Booking(AddBooking model)
        {
            if (ModelState.IsValid)
            {

                BolawaqContext _dbcontext = new BolawaqContext();

                var add = new Booking 
                {
                    Иин = model.BookingIIN,
                    Цель = model.BookingPurpose,
                    Дата = model.BookingDate,
                    Время = model.BookingTime,
                    Email = model.BookingEmail
                };

                await _dbcontext.Bookings.AddAsync(add);
                //Console.WriteLine(info);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction("Booking");
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}