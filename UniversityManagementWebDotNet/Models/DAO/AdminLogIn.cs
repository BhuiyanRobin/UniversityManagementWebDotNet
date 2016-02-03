using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebDotNet.Models.DAO
{
    public class AdminLogIn
    {
        public int Id { set; get; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please insert Your user name")]
        [DisplayName("Admin User Name")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Please input your password", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}