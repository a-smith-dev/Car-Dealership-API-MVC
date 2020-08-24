using System.ComponentModel.DataAnnotations;

namespace CarDealershipMVC.Models
{
    public class Car
    {
        public int CarId { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Color { get; set; }
    }
}
