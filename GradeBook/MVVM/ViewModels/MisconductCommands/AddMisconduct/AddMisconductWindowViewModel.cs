using GradeBook.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.MisconductCommands.AddMisconduct
{
    public class AddMisconductWindowViewModel : ViewModelBase  
    {
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public Misconduct Misconduct { get; set; }
        public AddMisconductInfoCommand AddMisconductInfoCommand { get; set; }

        public AddMisconductWindowViewModel(Student student, Teacher teacher) {
            Student = student;
            Teacher = teacher;
            Misconduct = new Misconduct
            {
                Date = DateTime.Now
            };
            AddMisconductInfoCommand = new AddMisconductInfoCommand(Student, Teacher, Misconduct);
        }
    }
}
