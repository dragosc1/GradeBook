using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels.Commands
{
    public class RegisterCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            Teacher teacher = (Teacher)parameter;
            if (teacher != null)
            {
                if (!String.IsNullOrEmpty(teacher.Name) && !String.IsNullOrEmpty(teacher.Password))
                    return true;
                return false;
            }
            return false;
        }
        public override void Execute(object parameter)
        {
            Teacher teacher = (Teacher)parameter;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(DatabaseHelper.connectionString))
            {
                string password = parameter as string;
                sql.CreateTable<Teacher>();
                List<Teacher> result = sql.Table<Teacher>().Where(t => t.Name.ToLower().Equals(teacher.Name.ToLower()) && t.Password.Equals(teacher.Password)).ToList();
                if (result.Count == 0)
                {
                    sql.Insert(teacher);
                }
                else MessageBox.Show("You have already registered!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
