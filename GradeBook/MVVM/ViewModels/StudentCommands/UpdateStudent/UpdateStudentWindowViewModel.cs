using GradeBook.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels.StudentCommands.UpdateStudent
{
    public class UpdateStudentWindowViewModel : ViewModelBase
    {
        public Student SelectedStudent { get; set; }
        public Class SelectedClass { get; set; }
        public UpdateStudentInfoCommand UpdateStudentInfoCommand { get; set; }
        public UpdateStudentWindowViewModel(Student SS, Class SC)
        {
            SelectedStudent = SS;
            SelectedClass = SC;
            UpdateStudentInfoCommand = new UpdateStudentInfoCommand();
            SelectedStudent.StudentPropertyChanged += OnStudentPropertyChanged;
        }
        private void OnStudentPropertyChanged(string obj)
        {
            OnPropertyChanged(obj);
        }
    }
}
