using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels.StudentCommands.AddStudent
{
    public class AddStudentInfoCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            object[] parameters = parameter as object[];
            if (parameters == null)
                return false;
            Student student = parameters[1] as Student;
            if (student == null) return false;
            if (String.IsNullOrEmpty(student.Name))
                return false;
            return true;
        }
        public override void Execute(object parameter)
        {
            object[] parameters = parameter as object[];
            Class SelectedClass = parameters[0] as Class;
            Student student = parameters[1] as Student;
            Window window = parameters[2] as Window;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(DatabaseHelper.connectionString))
            {
                sql.CreateTable<Student>();
                student.IdClass = SelectedClass.Id;
                if (sql.Table<Student>().Where(st => st.IdClass == SelectedClass.Id && st.Name == student.Name).Count() == 0)
                    sql.Insert(student);
            }
            window.Close();
        }
    }
}
