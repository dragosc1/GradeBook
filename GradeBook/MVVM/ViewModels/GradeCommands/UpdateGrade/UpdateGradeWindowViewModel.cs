using GradeBook.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.GradeCommands.UpdateGrade
{
    public class UpdateGradeWindowViewModel : ViewModelBase
    {
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public Grade Grade { get; set; }
        public UpdateGradeInfoCommand UpdateGradeInfoCommand { get; set; }
        public UpdateGradeWindowViewModel(Student student, Teacher teacher, Grade grade)
        {
            Student = student;
            Teacher = teacher;
            Grade = grade;
            UpdateGradeInfoCommand = new UpdateGradeInfoCommand(Student, Teacher, Grade);
        }
    }
}
