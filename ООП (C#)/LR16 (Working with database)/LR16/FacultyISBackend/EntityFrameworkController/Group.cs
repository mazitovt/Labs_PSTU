using System.ComponentModel.DataAnnotations.Schema;

namespace FacultyISBackend.EntityFrameworkController
{
    [Table(("group"))]
    public class Group
    {
        [Column("group_id")]
        public int Id { get; set; }
        
        [Column("name")] 
        public string Name { get; set; } 
        
        [Column("year")]
        public int Year { get; set; }
    }
}
