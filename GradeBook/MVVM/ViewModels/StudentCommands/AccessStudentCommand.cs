using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.StudentCommands
{
    public class AccessStudentCommand : BaseCommand
    {
        public Teacher Teacher { get; set; }
        public NavigationStore NavigationStore { get; set; }
        public override bool CanExecute(object parameter)
        {
            Student SelectedStudent = parameter as Student;
            if (SelectedStudent == null) { return false; }
            return true;
        }
        public override void Execute(object parameter)
        {
            Student SelectedStudent = parameter as Student;
            NavigationStore.CurrentViewModel = new StudentViewModel(NavigationStore, SelectedStudent, Teacher);
        }
        public AccessStudentCommand(NavigationStore nav, Teacher teacher)
        {
            NavigationStore = nav;
            Teacher = teacher;
        }
    }
}
