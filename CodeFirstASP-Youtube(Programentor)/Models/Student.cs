using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstASP_Youtube_Programentor_.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Column("StudentName", TypeName ="varchar(100)")]
        [Required]
        public string Name { get; set; }
        [Column("StudentGender", TypeName = "varchar(20)")]
        [Required]
        public string Gender { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public string Standard { get; set; }
    }
}
