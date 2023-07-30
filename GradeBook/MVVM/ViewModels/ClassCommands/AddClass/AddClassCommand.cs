using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.ClassCommands.AddClass
{
    public class AddClassCommand : BaseCommand
    {
        public ObservableCollection<Class> Classes { get; set; }
        public Teacher Teacher { get; set; }
        public AddClassInfoCommand AddClassInfoCommand { get; set; }

        public AddClassCommand(ObservableCollection<Class> cls, Teacher teacher) {
            Classes = cls;
            Teacher = teacher;
        }

        public override void Execute(object parameter)
        {
            AddClassWindow window = new AddClassWindow()
            {
                DataContext = new AddClassWindowViewModel(Teacher)
            };
            window.ShowDialog();
            Classes.Clear();
            foreach (Class c in DatabaseHelper.ReadData(Teacher))
                Classes.Add(c);
        }
    }
}
