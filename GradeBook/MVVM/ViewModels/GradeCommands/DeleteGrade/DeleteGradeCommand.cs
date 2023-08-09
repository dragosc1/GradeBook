using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.GradeCommands.DeleteGrade
{
    public class DeleteGradeCommand : BaseCommand
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
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(DatabaseHelper.connectionString))
            {
                sql.CreateTable<Grade>();
                sql.Delete(grade);
            }
            Grades.Clear();
            foreach (Grade g in DatabaseHelper.ReadData(Student, Teacher))
                Grades.Add(g);
        }
        public DeleteGradeCommand(ObservableCollection<Grade> grades, Student student, Teacher teacher) {
            Grades = grades;
            Student = student;
            Teacher = teacher;
        }
    }
}
