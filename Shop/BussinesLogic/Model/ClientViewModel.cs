using ShopData.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Model
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Should be not empty")]
        [MaxLength(20, ErrorMessage = "Too long name")]
        public string Name { get; set; }

        public UserCategory UserCategory { get; set; }
    }
}
