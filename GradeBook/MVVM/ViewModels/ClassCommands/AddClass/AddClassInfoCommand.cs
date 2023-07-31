using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels.ClassCommands.AddClass
{
    public class AddClassInfoCommand : BaseCommand
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
                if (!String.IsNullOrEmpty(classObj.Name) && classObj.Year > 0) {
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

                if (sql.Table<Class>().Where(c => c.Name == classObj.Name && c.Year == classObj.Year).Count() == 0)
                    sql.Insert(classObj);
                else classObj = sql.Table<Class>().Where(c => c.Name == classObj.Name && c.Year == classObj.Year).FirstOrDefault();
                Teacher_Class t_c = new Teacher_Class()
                {
                    IdClass = classObj.Id,
                    IdTeacher = teacher.Id
                };

                if (sql.Table<Teacher_Class>().Where(teach_c => teach_c.IdTeacher == teacher.Id && teach_c.IdClass == classObj.Id).Count() == 0)
                    sql.Insert(t_c);
            }
            window.Close();
        }

    }
}
