using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels.GradeCommands.AddGrade
{
    public class AddGradeInfoCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            object[] parameters = parameter as object[];
            if (parameters == null) return false;
            Grade grade = parameters[0] as Grade;
            if (grade == null) return false;
            if (String.IsNullOrEmpty(grade.Information) || grade.Value == 0)
                return false;
            return true;
        }
        public override void Execute(object parameter)
        {
            object[] parameters = parameter as object[];
            Grade grade = parameters[0] as Grade;
            Window window = parameters[1] as Window;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(DatabaseHelper.connectionString))
            {
                sql.CreateTable<Grade>();
                sql.Insert(grade);
                TSG tsg = new TSG
                {
                    IdGrade = grade.Id,
                    IdStudent = Student.Id,
                    IdTeacher = Teacher.Id
                };
                sql.CreateTable<TSG>();
                sql.Insert(tsg);
            }
            window.Close();
        }

        public Student Student { get; set; }
        public Teacher Teacher { get; set; }

        public AddGradeInfoCommand(Student student, Teacher teacher)
        {
            Student = student;
            Teacher = teacher;
        }
    }
}
