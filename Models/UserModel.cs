using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ufight.Models
{
    /// <summary>
    /// Use this model for registration and view user account
    /// </summary>
    public class UserModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage="Veld mag niet leeg zijn",AllowEmptyStrings = false)]
        public string UserName { get; set; }
        public DateTime RegDate { get; set; }
         [Required(ErrorMessage = "Veld mag niet leeg zijn", AllowEmptyStrings = false)]
        public string Email { get; set; }
        public int Role { get; set; }
         [Required(ErrorMessage = "Veld mag niet leeg zijn", AllowEmptyStrings = false)]
        public string SportSchool { get; set; }
        public string StraatNaam { get; set; }
        public string Plaats { get; set; }
        public string Land { get; set; }
        public string PostCode { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}