using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.Model
{
    public class Truancy
    {
        public Action<string> TruancyPropertyChanged;
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set {
                date = value;
                OnTruancyPropertyChanged(nameof(Date));
            }
        }

        private void OnTruancyPropertyChanged(string prop)
        {
            TruancyPropertyChanged?.Invoke(prop);
        }
    }
}
