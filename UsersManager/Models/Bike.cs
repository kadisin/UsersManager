using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace UsersManager.Models
{
    public class Bike
    {
        [BindNever]
        public int BikeId { get; set; }

        [Required(ErrorMessage = "Please enter name of bike")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter descrption")]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        public User User { get; set; } = default!;
    }
}
