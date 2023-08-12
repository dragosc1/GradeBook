using GradeBook.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.TruancyCommands.AddTruancy
{
    public class AddTruancyWindowViewModel : ViewModelBase
    {
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public Truancy Truancy { get; set; }
        public AddTruancyInfoCommand AddTruancyInfoCommand { get; set; }
        public AddTruancyWindowViewModel(Student student, Teacher teacher)
        {
            Student = student;
            Teacher = teacher;
            Truancy = new Truancy()
            {
                Date = DateTime.Now
            };
            Truancy.TruancyPropertyChanged += OnTruancyPropertyChanged;
            AddTruancyInfoCommand = new AddTruancyInfoCommand(Student, Teacher);
        }

        private void OnTruancyPropertyChanged(string obj)
        {
            OnPropertyChanged(obj);
        }
    }
}