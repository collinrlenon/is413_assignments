using MovieCollection.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class Movies
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [ValidationModel]
        public string Title { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        public string Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool? Edited { get; set; }

        public string LentTo { get; set; }

        [StringLength(25)]
        [DataType(DataType.Text)]
        public string Notes { get; set; }
    }
}
