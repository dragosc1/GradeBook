using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.MisconductCommands.AddMisconduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.MisconductCommands.UpdateMisconduct
{
    public class UpdateMisconductWindowViewModel : ViewModelBase
    {
        public Misconduct Misconduct { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public UpdateMisconductInfoCommand UpdateMisconductInfoCommand { get; set; }

        public UpdateMisconductWindowViewModel(Misconduct misconduct, Student student, Teacher teacher) { 
            Misconduct = misconduct;
            Student = student;
            Teacher = teacher;
            Misconduct.MisconductPropertyChanged += OnMisconductPropertyChanged;
            UpdateMisconductInfoCommand = new UpdateMisconductInfoCommand(Student, Teacher);
        }

        private void OnMisconductPropertyChanged(string prop)
        {
            OnPropertyChanged(prop);
        }
    }
}
