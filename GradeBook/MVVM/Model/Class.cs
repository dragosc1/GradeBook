using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.Model
{
    /// <summary>
    /// Student's class name and year of study (Ex: 9A, 10B) information
    /// </summary>
    [Table("Class")]
    public class Class
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public event Action<string> ClassPropertyChanged;

        private string name;

        public string Name
        {
            get { return name; }
            set { 
                name = value;
                OnClassPropertyChanged(nameof(Name));
            }
        }

        private int year;

        public int Year
        {
            get { return year; }
            set { 
                year = value;
                OnClassPropertyChanged(nameof(Year));
            }
        }

        private void OnClassPropertyChanged(string v)
        {
            ClassPropertyChanged?.Invoke(v);
        }
    }
}
