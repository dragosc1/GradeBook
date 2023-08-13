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
        public Action<String> MisconductPropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        private string information;
        public string Information
        {
            get { return information; }
            set { 
                information = value;
                OnMisconductPropertyChanged(nameof(Information));
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { 
                date = value;
                OnMisconductPropertyChanged(nameof(Date));
            }
        }

        private void OnMisconductPropertyChanged(string prop)
        {
            MisconductPropertyChanged?.Invoke(prop);
        }
    }
}
