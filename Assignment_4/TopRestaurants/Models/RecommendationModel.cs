using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TopRestaurants.Models
{
    public class RecommendationModel
    {

        public RecommendationModel(int rank)
        {
            Rank = rank;
        }

        [Required]
        public int Rank { get; } //Assignment prompt said required
        [Required] 
        public string Name { get; set; } //Assignment prompt said required
        public string? FavDish { get; set; } = "It's all tasty!"; // Assignment prompt didn't say this was required, but needs a default value
        [Required] //Assignment prompt said required
        public string Address { get; set; }
        [RegularExpression(@"\d{3}-\d{3}-\d{4}", ErrorMessage = "Please use the correct format for the Phone number.")]
        public string? Phone { get; set; }  //[Required] Assignment prompt didn't say this was required
        public string? Website { get; set; } = "Coming soon."; //[Required] Assignment prompt didn't say this was required, but needs a default value

        public static RecommendationModel[] GetRestaurants()
        {
            RecommendationModel r1 = new RecommendationModel(1)
            {
                Name = "Taco Bell",
                Address = "321 Taco Ln, Provo, UT 84606",
                Phone = "801-881-8888",
                Website = "www.tacobell.com"
            };

            RecommendationModel r2 = new RecommendationModel(2)
            {
                Name = "JDawgs",
                FavDish = "Hot Dog",
                Address = "123 Hot Dog Ln, Provo, UT 84606",
                Phone = "901-991-9999"
            };

            RecommendationModel r3 = new RecommendationModel(3)
            {
                Name = "Panda Express",
                FavDish = "Sweet 'n Spicy Chicken",
                Address = "123 Panda Ln, Provo, UT 84606",
                Phone = "301-331-3333",
                Website = "www.pandaexpress.com"
            };

            RecommendationModel r4 = new RecommendationModel(4)
            {
                Name = "Saigon Cafe",
                Address = "123 Saigon Ln, Provo, UT 84606",
                Phone = "501-551-5555"
            };

            RecommendationModel r5 = new RecommendationModel(5)
            {
                Name = "Wendy's",
                FavDish = "4for4",
                Address = "123 Wendy Ln, Provo, UT 84606",
                Phone = "701-771-7777",
                Website = "www.wendys.com"
            };

            return new RecommendationModel[] { r1, r2, r3, r4, r5 };
        }
    }
}
