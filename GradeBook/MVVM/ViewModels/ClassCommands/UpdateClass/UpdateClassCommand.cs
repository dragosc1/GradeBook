using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.ClassCommands.AddClass;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.ClassCommands.UpdateClass
{
    public class UpdateClassCommand : BaseCommand
    {
        public ObservableCollection<Class> Classes { get; set; }
        public Teacher Teacher { get; set; }
        public AddClassInfoCommand AddClassInfoCommand { get; set; }
        public Class SelectedClass { get; set; }
        public UpdateClassCommand(ObservableCollection<Class> cls, Teacher teacher)
        {
            Classes = cls;
            Teacher = teacher;
        }
        public override bool CanExecute(object parameter)
        {
            SelectedClass = parameter as Class;
            if (SelectedClass == null)
            {
                return false;
            }
            return true;
        }
        public override void Execute(object parameter)
        {
            SelectedClass = parameter as Class;
            UpdateClassWindow window = new UpdateClassWindow()
            {
                DataContext = new UpdateClassWindowViewModel(Teacher, SelectedClass)
            };
            window.ShowDialog();
            Classes.Clear();
            foreach (Class c in DatabaseHelper.ReadData(Teacher))
                Classes.Add(c);
        }
    }
}
