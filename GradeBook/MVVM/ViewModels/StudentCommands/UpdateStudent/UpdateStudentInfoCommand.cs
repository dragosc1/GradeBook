using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels.StudentCommands.UpdateStudent
{
    public class UpdateStudentInfoCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            object[] parameters = parameter as object[];
            if (parameters == null) return false;
            Student student = parameters[1] as Student;
            if (student == null) return false;
            if (String.IsNullOrEmpty(student.Name)) return false;
            return true;
        }
        public override void Execute(object parameter)
        {
            object[] parameters = parameter as object[];
            Student SelectedStudent = parameters[1] as Student;
            Window window = parameters[2] as Window;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(DatabaseHelper.connectionString))
            {
                sql.CreateTable<Student>();
                sql.Update(SelectedStudent);
            }
            window.Close();
        }
    }
}
