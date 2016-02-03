using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebGrease;

namespace UniversityManagementWebDotNet.Models.DAO
{
    public class TimeSlot
    {
        public int Id { set; get; }
        [Display(Name="Time Form")]
        [Required(AllowEmptyStrings = false,ErrorMessage = "Insert class strating time")]
        [DataType(DataType.Time)]
        public TimeSpan TimeForm { set; get; }
        [Display(Name = "Time To")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Insert class Ending time")]
        [DataType(DataType.Time)]
        public TimeSpan TimeTo { set; get; }
    }
}