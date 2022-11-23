using Bolawaq.data;
using Bolawaq.Models;
using Bolawaq.Models.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Bolawaq.Controllers
{
    [Route("Admin/Cms")]
    public class CmsController : Controller
    {

        


        [HttpGet]
        public async Task<IActionResult> Cms() {
            BolawaqContext _dbcontext = new BolawaqContext();
            var bookinginfo = await _dbcontext.GetAll();
            return View(bookinginfo); 
        }



        [HttpPost]

        public async Task<IActionResult> PDF()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BolawaqContext _dbcontext = new BolawaqContext();
                var bookinginfo = await _dbcontext.Bookings.ToListAsync();

                Document document = new Document(PageSize.A4,25,25,30,30);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();


                PdfPTable table = new PdfPTable(6);

                
                Font font = FontFactory.GetFont("./fonts/DejaVuSans.ttf", "cp1251", BaseFont.EMBEDDED, 9);

                Console.WriteLine(font);

                PdfPCell cell1 = new PdfPCell(new Phrase("НОМЕР ТАЛОНА", font));
                table.AddCell(cell1);
                PdfPCell cell2 = new PdfPCell(new Phrase("ЦЕЛЬ ПОСЕЩЕНИЯ", font));
                table.AddCell(cell2);
                PdfPCell cell3 = new PdfPCell(new Phrase("ИИН", font));
                table.AddCell(cell3);
                PdfPCell cell4 = new PdfPCell(new Phrase("ДАТА БРОНИРОВАНИЯ", font));
                table.AddCell(cell4);
                PdfPCell cell5 = new PdfPCell(new Phrase("ВРЕМЯ БРОНИРОВАНИЯ", font));
                table.AddCell(cell5);
                PdfPCell cell6 = new PdfPCell(new Phrase("EMAIL", font));
                table.AddCell(cell6);

                foreach (var booking in bookinginfo)
                {
                    PdfPCell cell_1 = new PdfPCell(new Phrase(booking.Id.ToString()));
                    cell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell_1);

                    PdfPCell cell_2 = new PdfPCell(new Phrase(booking.Цель, font));
                    cell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell_2);

                    PdfPCell cell_3 = new PdfPCell(new Phrase(booking.Иин.ToString()));
                    cell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell_3);

                    PdfPCell cell_4 = new PdfPCell(new Phrase(booking.Дата.Value.ToShortDateString().ToString()));
                    cell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell_4);

                    PdfPCell cell_5 = new PdfPCell(new Phrase(booking.Время.Value.TotalHours.ToString()+":00"));
                    cell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell_5);

                    PdfPCell cell_6 = new PdfPCell(new Phrase(booking.Email.ToString()));
                    cell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell_6);

                }
                document.Add(table);
                document.Close();
                writer.Close();
                var constant = ms.ToArray();
                return File(constant, "application/vnd", "booking.pdf");

            }
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
