using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebDotNet.Models.DAO
{
    public class CourseAssign
    {
        public int Id { set; get; }
        [DisplayName("Semister")]
        public int SemisterId { set; get; }

        [DisplayName("Course Code")]
        public int CourseId { set; get; }
        [DisplayName("Section")]
        public int Section { set; get; }
         [DisplayName("Time Slot")]
        public int TimeSlotId { set; get; }
         [DisplayName("Week day")] 
        public int WeekDaysId { set; get; }
         [DisplayName("Room Number")] 
        public int RoomId { set; get; }
         [DisplayName("Assign a Faculty Member")]
         [Required(AllowEmptyStrings = false, ErrorMessage = "Insert a faculty Code")]
        public int FacultyId { set; get; }
        
        public virtual Course ACourse { set; get; }
        public virtual WeekDays AWeekDaysS { set; get; }
        public virtual TimeSlot ATimeSlot { set; get; }
        public virtual Room ARoom { set; get; }
        public virtual Faculty AFaculty { set; get; }
        public virtual Semister ASemister { set; get; }
    }
}