﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.Model
{
    public class TST
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int IdTeacher { get; set; }
        [Indexed]
        public int IdStudent { get; set; }
        [Indexed]
        public int IdTruancy { get; set; }
    }
}
