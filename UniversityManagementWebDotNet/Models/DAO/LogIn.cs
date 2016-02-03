using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebDotNet.Models.DAO
{
    public class LogIn
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Please input User Name", AllowEmptyStrings = false)]
        [Display(Name = "User Name")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Please input your password", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        public string Category { set; get; }
    }
}