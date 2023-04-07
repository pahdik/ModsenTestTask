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
        [StringLength(20, MinimumLength = 3)]
        public string ISBN { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Genre { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 7)]
        public string Description { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string AuthorName { get; set; }
    }
}
