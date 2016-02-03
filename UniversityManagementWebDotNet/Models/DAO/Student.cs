using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace UniversityManagementWebDotNet.Models.DAO
{
    public class Student
    {
        public int Id { set; get; }
        [Display(Name = "University Id")]
        public string UniId { set; get; }
        [Display(Name = "Student Full Name")]
        public string Name { set; get; }
        [Display(Name = "Student Nick Name")]
        public string Nickname { set; get; }
        [Display(Name = "Student Password")]
        public string Password { set;get; }
        [Display(Name = "SSC Registration Number")]
        public string SscRegistration { set; get; }
        [Display(Name = "SSC Passying Year")]
        public string SscPassingYear { set; get; }
        [Display(Name = "SSC Board")]
        public string SscBoard { set; get; }
        [Display(Name = "SSC Result")]
        public double SscResult { set; get; }
        [Display(Name = "HSC Registration Number")]
        public string HscRegistration { set; get; }
        [Display(Name = "HSC Passying Year")]
        public string HscPassingYear { set; get; }
        [Display(Name = "HSC Board")]
        public string HscBoard { set; get; }
        [Display(Name = "HSC Result")]
        public double HscResult { set; get; }
        [Display(Name = "Fathers Voter Id")]
        public int FathersVoterId { set; get; }
        [Display(Name = "Fathers Name")]
        public string FathersName { set; get; }
        [Display(Name = "Fathers Designation")]
        public string FathersDegignation { set; get; }
        [Display(Name = "Fathers Contact Number")]
        public string FathersContactNumber { set; get; }
        [Display(Name = "Fathers Email")]
        public string FathersEmail { set; get; }
        [Display(Name = "Mothers Voter Id")]
        public int MothersVoterId { set; get; }
         [Display(Name = "Mothers Name")]
        public string MothersName { set; get; }
         [Display(Name = "Mothers Designation")]
        public string MothersDegignation { set; get; }
         [Display(Name = "Mothers Contact Number")]
        public string MothersContactNumber { set; get; }
        [Display(Name = "Mothers Email")]
        public string MothersEmail { set; get; }
        [NotMapped]
        public HttpPostedFileBase File { set; get; }
    }
}