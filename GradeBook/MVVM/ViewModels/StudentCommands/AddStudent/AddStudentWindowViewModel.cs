using GradeBook.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.StudentCommands.AddStudent
{
    public class AddStudentWindowViewModel : ViewModelBase
    {
        public Class SelectedClass { get; set; }
        public Student Student { get; set; }
        public AddStudentInfoCommand AddStudentInfoCommand { get; set; }
        public AddStudentWindowViewModel(Class selectedClass)
        {
            SelectedClass = selectedClass;
            Student = new Student();
            Student.StudentPropertyChanged += OnStudentPropertyChanged;
            AddStudentInfoCommand = new AddStudentInfoCommand();
        }

        private void OnStudentPropertyChanged(string obj)
        {
            OnPropertyChanged(obj);
        }
    }
}
