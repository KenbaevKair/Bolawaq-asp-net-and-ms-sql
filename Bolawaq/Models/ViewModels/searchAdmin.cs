using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Bolawaq.Models.ViewModels
{
    public class searchAdmin
    {
        [Required(ErrorMessage = "Введите имя")]
        public string? AdminName { get; set; }

        [Required(ErrorMessage = "Выберите пароль")]
        public string? AdminPass { get; set; }
    }
}
