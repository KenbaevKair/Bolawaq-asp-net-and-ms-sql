using System.ComponentModel.DataAnnotations;

namespace Bolawaq.Models.ViewModels
{
    
    public class infoBooking
    {

        public int Id { get; set; }

        public string? BookingIIN { get; set; }

      
        public string? BookingPurpose { get; set; }

      
        public DateTime? BookingDate { get; set; }

 
        public TimeSpan? BookingTime { get; set; }

        public string? BookingEmail { get; set; }
    }
}
