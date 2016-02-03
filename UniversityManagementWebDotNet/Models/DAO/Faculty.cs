using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagementWebDotNet.Models.DAO
{
    public class Faculty
    {
        public int Id { set; get; }
        [DisplayName("Faculty Name")]
        [Required(AllowEmptyStrings = false,ErrorMessage = "Insert Faculty name")]
        public string FacultyName { set; get; }
        [DisplayName("Faculty Code")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Insert Faculty Code")]
        public string FacultyCode { set; get; }
        [DisplayName("Faculty Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Insert Faculty Email")]
        [DataType(DataType.EmailAddress)]
        public string FacultyEmail { set; get; }
        [DisplayName("Faculty Contact Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Insert Faculty Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public string FacultyContactNumber { set; get; }
        
    }
}