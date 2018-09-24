using Logic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя не указано!")]
        [NameChecking (ErrorMessage = "Имя начинается не с А")]
        [MaxLength(length:20, ErrorMessage ="Очень длинная строка!")]
        [MinLength(2, ErrorMessage ="Слишком короткое имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Имя не указано!")]
        [MaxLength(length: 20, ErrorMessage = "Очень длинная строка!")]
        [EmailAddress(ErrorMessage = "Введите email!")]
        public string Email { get; set; }

        public List<Phone> Phones { get; set; }

        public Contact()
        {
                Phones = new List<Phone>();
        }
    }
}