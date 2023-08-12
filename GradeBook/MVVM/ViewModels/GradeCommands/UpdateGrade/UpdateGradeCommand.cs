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

namespace GradeBook.MVVM.ViewModels.GradeCommands.UpdateGrade
{
    public class UpdateGradeCommand : BaseCommand
    {
        public ObservableCollection<Grade> Grades { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }

        public override bool CanExecute(object parameter)
        {
            Grade grade = parameter as Grade;
            if (grade == null) return false;
            return true;
        }
        public override void Execute(object parameter)
        {
            Grade grade = parameter as Grade;
            UpdateGradeWindow window = new UpdateGradeWindow()
            {
                DataContext = new UpdateGradeWindowViewModel(Student, Teacher, grade)
            };
            window.ShowDialog();
            Grades.Clear();
            foreach (Grade g in DatabaseHelper.ReadDataGrades(Student, Teacher))
                Grades.Add(g);
        }
        public UpdateGradeCommand(ObservableCollection<Grade> grades, Student student, Teacher teacher)
        {
            Grades = grades;
            Student = student;  
            Teacher = teacher;
        }
    }
}
