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
    public class ClassSearchTextChangedCommand : BaseCommand
    {
        public ObservableCollection<Class> Classes { get; set; }
        public Teacher Teacher { get; set; }

        public override void Execute(object parameter)
        {
            string Filter = parameter as string;
            Classes.Clear();
            foreach (Class c in DatabaseHelper.ReadData(Teacher, Filter))
                Classes.Add(c);
        }
        public ClassSearchTextChangedCommand(Teacher teacher, ObservableCollection<Class> classes)
        {
            Teacher = teacher;
            Classes = classes;
        }
    }
}
