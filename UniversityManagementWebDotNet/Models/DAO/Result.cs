using System;

namespace UniversityManagementWebDotNet.Models.DAO
{
    public class Result
    {
        public int Id { set; get; }
        public int StudentId { set; get; }
        public string SubjectCode{ set; get; }
        public double Gpa { set; get; }
    }
}