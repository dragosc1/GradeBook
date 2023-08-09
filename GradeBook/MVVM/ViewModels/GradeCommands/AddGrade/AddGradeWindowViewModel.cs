using GradeBook.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.GradeCommands.AddGrade
{
    public class AddGradeWindowViewModel : ViewModelBase
    {
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public AddGradeInfoCommand AddGradeInfoCommand { get; set; }
        public Grade Grade { get; set; }
        public AddGradeWindowViewModel(Student student, Teacher teacher)
        {
            Student = student;
            Teacher = teacher;
            AddGradeInfoCommand = new AddGradeInfoCommand(Student, Teacher);
            Grade = new Grade()
            {
                Date = System.DateTime.Now
            };
            Grade.GradePropertyChanged += OnGradePropertyChanged;
        }

        private void OnGradePropertyChanged(string property)
        {
            OnPropertyChanged(nameof(property));
        }
    }
}
