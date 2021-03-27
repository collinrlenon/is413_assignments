using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TopRestaurants.Models
{
    //Create model for the user form
    public class FormModel
    {
        // I've heard mixed messages on whether or not we need validation for this model.
        // I've added some, but just commented them out, incase it turns out that we actually did need some.

        //[Required]
        public string UserName { get; set; } //= "Joe";
        [Required(ErrorMessage = "Please enter a valid Restaurant name.")]
        public string RestaurantName { get; set; }
        //[Required]
        public string? FavDish { get; set; } //= "It's all tasty!";
        //[Required]
        [RegularExpression(@"\d{3}-\d{3}-\d{4}", ErrorMessage = "Please enter a valid phone number.")]
        public string? Phone { get; set; }
    }
}
