using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.Model
{
    /// <summary>
    /// Student's grade given by the teacher
    /// </summary>
    [Table("Grade")]
    public class Grade
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }  
    }
}
