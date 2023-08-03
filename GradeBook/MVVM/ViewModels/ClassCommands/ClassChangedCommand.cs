using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.ClassCommands
{
    public class ClassChangedCommand : BaseCommand
    {

        public ObservableCollection<Student> Students { get; set; }
        public override void Execute(object parameter)
        {
            Class SelectedClass = parameter as Class;
            Students.Clear();
            foreach (Student student in DatabaseHelper.ReadData(SelectedClass)) {
                Students.Add(student);
            }
        }

        public ClassChangedCommand(ObservableCollection<Student> students)
        {
            Students = students;
        }
    }
}
