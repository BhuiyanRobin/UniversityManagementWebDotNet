using System.ComponentModel.DataAnnotations;

namespace UniversityManagementWebDotNet.Models.DAO
{
    public class Admin
    {
        public int Id{set;get;}
        [Display(Name = "University Id")]
        public string UniId { set; get; }
        public string Name { set; get; }
        [Display(Name = "Nick Name")]
        public string Nickname { set; get; }
        [Display(Name = "User Name")]
        public string UserName { set; get; }
        public string Password { set; get; }
    }
}