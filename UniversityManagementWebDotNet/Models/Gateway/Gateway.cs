using System.Data;
using System.Data.Entity;
using System.Web.UI.WebControls;
using UniversityManagementWebDotNet.Models.DAO;

namespace UniversityManagementWebDotNet.Models.Gateway
{
    public class Gateway : DbContext
    {
        public Gateway() : base("connection")
        {

        }

        public DbSet<Student> Students { set; get; }
        public DbSet<Admin> Admins { set; get; }
        public DbSet<LogIn> Logins { set; get; }
        public DbSet<AdminLogIn> AdminLogIns { set; get; }
        public DbSet<WeekDays> Dayses { set; get; }
        public DbSet<Room> Rooms { set; get; }
        public DbSet<Course> Courses { set; get; }
        public DbSet<Semister> Semisters { set; get; }
        public DbSet<Faculty> Faculties { set; get; }
        public DbSet<TimeSlot> TimeSlots { set; get; }
        public DbSet<CourseAssign> CourseAssigns { set; get; }
        public DbSet<TakeCourse> TakeCourses { set; get; }
        public DbSet<Operator> Operators { set; get; }
        public DbSet<Message> Messages { set; get; }
        public DbSet<Result> Results { set; get; } 
    }
}