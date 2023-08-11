using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels.GradeCommands.UpdateGrade
{
    public class UpdateGradeInfoCommand : BaseCommand
    {
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public Grade Grade { get; set; }

        public override bool CanExecute(object parameter)
        {
            if (Grade.Value < 0 || String.IsNullOrEmpty(Grade.Information))
                return false;
            return true;
        }
        public override void Execute(object parameter)
        {
            Window window = parameter as Window;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(DatabaseHelper.connectionString))
            {
                sql.CreateTable<Grade>();
                sql.Update(Grade);
            }
            window.Close();
        }
        public UpdateGradeInfoCommand(Student student, Teacher teacher, Grade grade)
        {
            Student = student;
            Teacher = teacher;
            Grade = grade;
        }
    }
}
