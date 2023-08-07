using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.StudentCommands.UpdateStudent
{
    public class UpdateStudentCommand : BaseCommand
    {
        public ObservableCollection<Student> Students { get; set; }
        public Class SelectedClass { get; set; }
        public UpdateStudentCommand(ObservableCollection<Student> students)
        {
            Students = students;
        }
        public override bool CanExecute(object parameter)
        {
            object[] parameters = parameter as object[];
            Student SelectedStudent = parameters[0] as Student;
            if (SelectedStudent == null) return false;
            return true;
        }
        public override void Execute(object parameter)
        {
            object[] parameters = parameter as object[];
            Student SelectedStudent = parameters[0] as Student;
            SelectedClass = parameters[1] as Class;
            UpdateStudentWindow window = new UpdateStudentWindow
            {
                DataContext = new UpdateStudentWindowViewModel(SelectedStudent, SelectedClass)
            };
            window.ShowDialog();
            Students.Clear();
            foreach (Student student in DatabaseHelper.ReadData(SelectedClass))
                Students.Add(student);
        }
    }
}