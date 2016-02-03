using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace UniversityManagementWebDotNet.Models.DAO
{
    public class Room
    {
        public int Id{set;get;}
        [Display(Name = "Room Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please give a name")]
        public string RoomName{set;get;}
        [Display(Name="Room Number")]
        [Required(AllowEmptyStrings = false,ErrorMessage = "Please give a room number")]
        public string RoomNumber{set;get;}
    }
}