using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ufight.Models
{
    public class FighterModel
    {
        [Required(ErrorMessage = "Veld mag niet leeg zijn", AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Veld mag niet leeg zijn", AllowEmptyStrings = false)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Veld mag niet leeg zijn", AllowEmptyStrings = false)]
        public string FighterName { get; set; }
        public byte Available { get; set; }
         [Required(ErrorMessage = "Veld mag niet leeg zijn", AllowEmptyStrings = false)]
        public int WeightClass { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int UserId { get; set; }
        public string Photo { get; set; }
        public string Record { get; set; }
        public string Title { get; set; }
        public int Fights { get; set; }

    }
}