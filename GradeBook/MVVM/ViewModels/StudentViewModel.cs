using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.GradeCommands.AddGrade;
using GradeBook.MVVM.ViewModels.Helpers;
using GradeBook.Store;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Grade> Grades { get; set; }
        public AddGradeCommand AddGradeCommand { get; set; } 
        
        public StudentViewModel(NavigationStore nav, Student student, Teacher teacher)
        {
            NavigationStore = nav;
            Student = student;
            Teacher = teacher;
            Grades = new ObservableCollection<Grade>();
            foreach (Grade grade in DatabaseHelper.ReadData(Student, Teacher)) {
                Grades.Add(grade);
            }
            AddGradeCommand = new AddGradeCommand(Grades, Student, Teacher);
        }
    }
}
