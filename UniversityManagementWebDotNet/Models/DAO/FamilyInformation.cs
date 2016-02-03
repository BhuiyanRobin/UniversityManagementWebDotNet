namespace UniversityManagementWebDotNet.Models.DAO
{
    public class FamilyInformation
    {
        public int Id { set; get; }
        public int FathersVoterId{set;get;}
        public string FathersName { set; get; }
        public string FathersDegignation { set; get; }
        public string FathersContactNumber { set; get; }
        public string FathersEmail { set; get; }
        public int MothersVoterId { set; get; }
        public string MothersName { set; get; }
        public string MothersDegignation { set; get; }
        public string MothersContactNumber { set; get; }
        public string MothersEmail { set; get; }
        public string Name { set; get; }
        public string Organization { set; get; }
        public string Designation { set; get; }
        public string Email { set; get; }
        public string ContactNumber { set; get; }
        
    }
}