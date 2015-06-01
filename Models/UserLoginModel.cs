using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ufight.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class UserLoginModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}