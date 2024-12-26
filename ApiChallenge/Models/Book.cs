using System.ComponentModel.DataAnnotations;

namespace ApiChallenge.Models
{
    public class Book
    {
        public int id { get; set; }
        [Required]
        public string titre { get; set; }
        [Required]
        public string auteur { get; set; }
        [Required]
        public string isbn { get; set; }
        [Required]
        public double prix { get; set; }
    }
}
