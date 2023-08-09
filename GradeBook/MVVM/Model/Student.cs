using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.Model
{
    /// <summary>
    /// This is the student model class
    /// </summary>
    [Table("Student")]
    public  class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int IdClass { get; set; }

        public event Action<string> StudentPropertyChanged;

        private string name;
        public string Name
        {
            get { return name; }
            set { 
                name = value;
                OnStudentPropertyChanged(nameof(Name));
            }
        }

        private void OnStudentPropertyChanged(string prop)
        {
            StudentPropertyChanged?.Invoke(prop);
        }
    }
}
