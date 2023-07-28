using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.Model
{
    /// <summary>
    /// Associative table between teacher and class
    /// </summary>
    [Table("Teacher_Class")]
    public class Teacher_Class
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int IdTeacher { get; set; }
        [Indexed]
        public int IdClass { get; set; }
    }
}
