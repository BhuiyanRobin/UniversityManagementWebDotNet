using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementWebDotNet.Models.DAO
{
    public class Course
    {
        public int Id { set; get; }
        [Display(Name = "Course Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please give a Course Name")]
        public string CourseName { set; get; }
        [DisplayName("Course Code")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please give a Course code")]
        public string CourseCode { set; get; }
        [DisplayName("Course Credit")]
        public double CourseCredit { set; get; }
        


    }
}