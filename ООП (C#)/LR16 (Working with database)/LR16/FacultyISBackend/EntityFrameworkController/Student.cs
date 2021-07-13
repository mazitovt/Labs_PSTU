using System.ComponentModel.DataAnnotations.Schema;

namespace FacultyISBackend.EntityFrameworkController
{
    [Table("student")]
    public class Student
    {
        [Column("student_id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("rating")]
        public double Rating { get; set; }
        [Column("group_id")]
        public int GroupId { get; set; }
    }
}
