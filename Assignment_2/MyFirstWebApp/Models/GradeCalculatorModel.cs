using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Models
{
    //Model to help run the calculator
    public class GradeCalculatorModel
    {
        //Setting validation within the model
        [Range(0, 100, ErrorMessage = "The grade you entered must be between 0 and 100")]
        public int assignments { get; set; }
        [Range(0, 100, ErrorMessage = "The grade you entered must be between 0 and 100")]
        public int grpproj { get; set; }
        [Range(0, 100, ErrorMessage = "The grade you entered must be between 0 and 100")]
        public int quizzes { get; set; }
        [Range(0, 100, ErrorMessage = "The grade you entered must be between 0 and 100")]
        public int exams { get; set; }
        [Range(0, 100, ErrorMessage = "The grade you entered must be between 0 and 100")]
        public int intex { get; set; }
    }
}
