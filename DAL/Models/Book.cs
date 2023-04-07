using System.ComponentModel.DataAnnotations;

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
