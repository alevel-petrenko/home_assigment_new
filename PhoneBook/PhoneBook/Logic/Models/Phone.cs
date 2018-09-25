using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Phone
    {
        public int Id { get; set; }

        public PhoneTypes Type { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Длина телефона должна быть от 7 до 15 символов")]
        public string Number { get; set; }
    }

    public enum PhoneTypes
    {
        Home=1,
        Mobile,
        Work
    }
}
