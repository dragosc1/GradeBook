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
        public Action<string> GradeChanged { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private double _value;
        public double Value
        {
            get { return _value; }
            set { 
                _value = value;
                OnGradeChanged(nameof(Value));
            }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { 
                date = value;
                OnGradeChanged(nameof(Date));
            }
        }

        private string information;

        public string Information
        {
            get { return information; }
            set { 
                information = value;
                OnGradeChanged(nameof(Information));
            }
        }

        private void OnGradeChanged(string v)
        {
            GradeChanged?.Invoke(v);
        }
    }
}
