using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebDotNet.Models.DAO
{
    public class Operator
    {
        [Key]
        public int Id { set; get; }
        public int OperatorId { set; get; }
        public string Catagory { set; get; }
    }
}