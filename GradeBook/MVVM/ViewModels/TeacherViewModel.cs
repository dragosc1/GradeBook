using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.ClassCommands.AddClass;
using GradeBook.MVVM.ViewModels.Helpers;
using GradeBook.Store;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels
{
    public class TeacherViewModel : ViewModelBase
    {
        public Teacher Teacher { get; set; }
        public NavigationStore NavigationStore { get; set; }
        public ObservableCollection<Class> Classes { get; set; }
        public AddClassCommand AddClassCommand { get; set; }
        public TeacherViewModel(NavigationStore nav, Teacher teacher) { 
            NavigationStore = nav;
            Teacher = teacher;
            Classes = new ObservableCollection<Class>(DatabaseHelper.ReadData(teacher));
            AddClassCommand = new AddClassCommand(Classes, teacher);
        }
    }
}
