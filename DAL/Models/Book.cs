using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Description { get; set; }
        [Required] 
        public string AuthorName { get; set; }
        [Required]
        public DateTime ReceivingTime { get; set; }
        [Required]
        public DateTime TimeToReturn { get; set; }

    }
}
