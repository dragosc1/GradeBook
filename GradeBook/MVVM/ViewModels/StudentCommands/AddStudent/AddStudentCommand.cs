using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels.StudentCommands.AddStudent
{
    public class AddStudentCommand : BaseCommand
    {
        ObservableCollection<Student> Students;

        public override bool CanExecute(object parameter)
        {
            Class SelectedClass = parameter as Class;
            if (SelectedClass == null) return false;
            return true;
        }

        public override void Execute(object parameter)
        {
            Class SelectedClass = parameter as Class;
            AddStudentWindow window = new AddStudentWindow
            {
                DataContext = new AddStudentWindowViewModel(SelectedClass)
            };
            window.ShowDialog();
            Students.Clear();
            foreach (Student student in DatabaseHelper.ReadData(SelectedClass))
                Students.Add(student);
        }

        public AddStudentCommand(ObservableCollection<Student> students)
        {
            Students = students;
        }
    }
}
