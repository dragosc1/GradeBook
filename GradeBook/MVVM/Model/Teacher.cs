using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.Model
{
    /// <summary>
    /// This is the teacher model class
    /// </summary>
    [Table("Teacher")]
    public class Teacher
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public event Action<string> PropertyChanged;

        private string name;
        public string Name
        {
            get { return name; }
            set {
                name = value;
                OnTeacherPropertyChanged(nameof(Name));
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { 
                password = value;
                OnTeacherPropertyChanged(nameof(Password));
            }
        }

        private void OnTeacherPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(propName);
        }
    }
}
