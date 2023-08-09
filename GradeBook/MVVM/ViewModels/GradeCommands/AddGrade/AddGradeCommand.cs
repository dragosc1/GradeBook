using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels.GradeCommands.AddGrade
{
    public class AddGradeCommand : BaseCommand
    {
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public ObservableCollection<Grade> Grades { get; set; }
        public override void Execute(object parameter)
        {
            AddGradeWindow window = new AddGradeWindow
            {
                DataContext = new AddGradeWindowViewModel(Student, Teacher)
            };
            window.ShowDialog();
            Grades.Clear();
            foreach (Grade grade in DatabaseHelper.ReadData(Student, Teacher))
                Grades.Add(grade);
        }
        public AddGradeCommand(ObservableCollection<Grade> grades, Student student, Teacher teacher)
        {
            Grades = grades;
            Student = student;  
            Teacher = teacher;
        }
    }
}
