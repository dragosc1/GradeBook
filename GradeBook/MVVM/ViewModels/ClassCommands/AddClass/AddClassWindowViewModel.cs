using GradeBook.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.ClassCommands.AddClass
{
    public class AddClassWindowViewModel : ViewModelBase
    {
        public AddClassInfoCommand AddClassInfoCommand { get; set; }
        public Class Class { get; set; }
        public Teacher Teacher { get; set; }
        public AddClassWindowViewModel(Teacher teacher)
        {
            Teacher = teacher;
            AddClassInfoCommand = new AddClassInfoCommand();
            Class = new Class();
            Class.ClassPropertyChanged += OnClassPropertyChanged;
        }

        private void OnClassPropertyChanged(string propName)
        {
            OnPropertyChanged(propName);
        }
    }
}
