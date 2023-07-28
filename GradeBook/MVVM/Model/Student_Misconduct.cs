using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.Model
{
    /// <summary>
    /// Associative table between student and misconduct
    /// </summary>
    [Table("Student_Misconduct")]
    public class Student_Misconduct
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Indexed]
        public int IdStudent { get; set; }
        [Indexed]
        public int IdMisconduct { get; set; }
    }
}
