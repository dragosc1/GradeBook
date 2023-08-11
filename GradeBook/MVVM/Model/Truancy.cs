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
        private string information;

        public string Information
        {
            get { return information; }
            set { 
                information = value;
                OnTruancyPropertyChanged(nameof(Information));
            }
        }

        private void OnTruancyPropertyChanged(string prop)
        {
            TruancyPropertyChanged?.Invoke(prop);
        }
    }
}
