using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.Model
{
    /// <summary>
    /// Associative table between student and grade
    /// </summary>
    [Table("Sudent_Grade")]
    public class Student_Grade
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int IdStudent { get; set; }
        [Indexed]
        public int IdGrade { get; set; }
        [Indexed]
        public int IdTeacher { get; set; }
    }
}
