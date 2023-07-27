using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.Model
{
    public class Misconduct
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Information { get; set; }
    }
}
