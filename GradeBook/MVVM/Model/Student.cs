using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.Model
{
    [Table("Student")]
    public  class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Average { get; set; }
        public int Absents { get; set; }
        public int ActivityGrade { get; set; }
    }
}
