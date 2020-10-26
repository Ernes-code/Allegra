using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alegra.App.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(25)]
        public string Username { get; set; }
    }
}
