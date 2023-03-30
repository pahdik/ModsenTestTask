using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.DTO
{
    public class BookAddDTO
    {
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string AuthorName { get; set; }
    }
}
