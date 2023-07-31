using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels.ClassCommands.UpdateClass
{
    public class UpdateClassInfoCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            object[] parameters = parameter as object[];
            if (parameters == null)
                return false;
            Class classObj = parameters[0] as Class;
            Teacher teacher = parameters[1] as Teacher;
            Window window = parameters[2] as Window;
            if (classObj != null)
                if (!String.IsNullOrEmpty(classObj.Name) && classObj.Year > 0)
                {
                    return true;
                }
                else return false;
            return false;
        }
        public override void Execute(object parameter)
        {
            object[] parameters = parameter as object[];
            if (parameters == null)
                return;
            Class classObj = parameters[0] as Class;
            Teacher teacher = parameters[1] as Teacher;
            Window window = parameters[2] as Window;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(DatabaseHelper.connectionString))
            {
                sql.CreateTable<Teacher_Class>();
                sql.CreateTable<Class>();
                sql.Update(classObj);
                sql.Update(sql.Table<Teacher_Class>().Where(t_c => t_c.IdClass == classObj.Id && t_c.IdTeacher == teacher.Id).FirstOrDefault()); 
            }
            window.Close();
        }
    }
}
