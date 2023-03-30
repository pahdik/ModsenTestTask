using System.ComponentModel.DataAnnotations;

namespace Library.BLL.DTO
{
    public class BookUpdateDTO
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
    }
}
