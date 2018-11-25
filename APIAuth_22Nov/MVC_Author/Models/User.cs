using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Author.Models
{
    public class User
    {
        public long UserId { get; set; }

        [Required(ErrorMessage ="Musthave field")]
        [StringLength(40)]
        [EmailAddress(ErrorMessage = "Enter email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Musthave field")]
        [StringLength(40)]
        public string Password { get; set; }
    }
}