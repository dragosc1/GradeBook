﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.Model
{
    [Table("Sudent_grade")]
    public class Student_Grade
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int IdStudent { get; set; }
        [Indexed]
        public int IdGrade { get; set; }
    }
}
