using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.Model
{
    public class Teacher
    {
        [PrimaryKey, AutoIncrement, Unique]
        public string Name { get; set; }    
        public string Password { get; set; }
    }
}
