using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Bolawaq.Models.ViewModels
{
    public class AddBooking
    {
        [Required(ErrorMessage = "Введите ИИН")]
        [MaxLength(12,ErrorMessage = "12max")]
        [MinLength(12, ErrorMessage = "12min")]
        public string? BookingIIN { get; set; }

        [Required(ErrorMessage = "Выберите цель")]
        public string? BookingPurpose { get; set; }

        [Required(ErrorMessage = "Выберите дату")]
        public DateTime? BookingDate { get; set; }

        [Required(ErrorMessage = "Выберите время")]
        public TimeSpan? BookingTime { get; set; }

        [Required(ErrorMessage = "Введите почту")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"
            , ErrorMessage = "Данная почта не соответствует требованием")]
        public string? BookingEmail { get; set; }


    }
}
