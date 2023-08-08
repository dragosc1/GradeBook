using GradeBook.MVVM.Model;
using GradeBook.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        public NavigationStore NavigationStore { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public StudentViewModel(NavigationStore nav, Student student, Teacher teacher)
        {
            NavigationStore = nav;
            Student = student;
            Teacher = teacher;
        }
    }
}
