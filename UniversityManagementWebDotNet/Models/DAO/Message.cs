using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementWebDotNet.Models.DAO
{
    public class Message
    {
        public int Id { set; get; }
        public int OperatorId { set; get; }
        public string SenderId { set; get; }
        public string Messages { set; get; }
        public virtual Operator AOperator { set; get; }
    }
}