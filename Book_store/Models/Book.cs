using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_store.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; }
        [Required, Range(1, 10000)]
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        [NotMapped ]
        public IFormFile? ImageFile { get; set; }
    }
}
