using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebDotNet.Models.DAO
{
    public class WeekDays
    {
        public int Id { set; get; }
        [Display(Name = "Week day Name")]
        [Required(AllowEmptyStrings = false,ErrorMessage = "Insert a day of Week")]
        public string Name { set; get; }
        [Display(Name = "Weekday Code")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Insert code")]
        public string Code { set; get; }
    }
}