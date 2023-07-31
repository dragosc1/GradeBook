using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.ClassCommands.AddClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.ClassCommands.UpdateClass
{
    public class UpdateClassWindowViewModel : ViewModelBase
    {
        public UpdateClassInfoCommand UpdateClassInfoCommand { get; set; }
        public Class SelectedClass { get; set; }
        public Teacher Teacher { get; set; }
        public UpdateClassWindowViewModel(Teacher teacher, Class SC)
        {
            Teacher = teacher;
            UpdateClassInfoCommand = new UpdateClassInfoCommand();
            SelectedClass = SC;
            SelectedClass.ClassPropertyChanged += OnClassPropertyChanged;
        }

        private void OnClassPropertyChanged(string propName)
        {
            OnPropertyChanged(propName);
        }
    }
}
