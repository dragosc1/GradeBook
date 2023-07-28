using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.Model
{
    /// <summary>
    /// Misconduct done by a student
    /// </summary>
    [Table("Misconduct")]
    public class Misconduct
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Information { get; set; }
    }
}
