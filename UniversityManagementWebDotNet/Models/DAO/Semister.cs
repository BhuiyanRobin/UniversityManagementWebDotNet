using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebDotNet.Models.DAO
{
    public class Semister
    {
        public int Id { set; get; }
        [DisplayName("Year")]
        [Required(AllowEmptyStrings = false,ErrorMessage = "Please insert Specific year")]
        public int Years { set; get; }
        [DisplayName("Semister Name")]
        [Required(AllowEmptyStrings = false,ErrorMessage = "Please give a specific Name")]
        public string SemistereName { set; get; }
    }
}