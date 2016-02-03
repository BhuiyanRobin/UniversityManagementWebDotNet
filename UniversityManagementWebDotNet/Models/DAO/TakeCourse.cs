using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UniversityManagementWebDotNet.Models.DAO
{
    public class TakeCourse
    {
        public int Id { set; get; }
        [DisplayName("Semister")]
        public int SemisterId { set; get; }
        [DisplayName("Student Id")]
        public string StudentId { set; get; }
        [DisplayName("Course Code")]
        public int CourseId { set; get; }
        public int Section { set; get; }
        public virtual Semister ASemister { set; get; }
        public virtual Course ACourse { set; get; }
    }
}