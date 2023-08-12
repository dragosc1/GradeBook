using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.Model
{
    /// <summary>
    /// Associative table between teacher, student and misconduct
    /// </summary>
    [Table("TSM")]
    public class TSM
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int IdTeacher { get; set; }
        [Indexed]
        public int IdStudent { get; set; }
        [Indexed]
        public int IdMisconduct { get; set; }
    }
}
