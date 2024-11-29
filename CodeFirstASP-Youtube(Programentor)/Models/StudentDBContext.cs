using Microsoft.EntityFrameworkCore;

namespace CodeFirstASP_Youtube_Programentor_.Models
{
    public class StudentDBContext: DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Student> Students { get; set; } // ei name e table create korbe
    }
}
