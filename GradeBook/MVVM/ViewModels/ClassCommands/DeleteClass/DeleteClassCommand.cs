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

namespace GradeBook.MVVM.ViewModels.ClassCommands.DeleteClass
{
    public class DeleteClassCommand : BaseCommand
    {
        public ObservableCollection<Class> Classes { get; set; }
        public Teacher Teacher { get; set; }
        public DeleteClassCommand(ObservableCollection<Class> cls, Teacher teacher) {
            Classes = cls;
            Teacher = teacher;
        }
        public override bool CanExecute(object parameter)
        {
            Class classObj = parameter as Class;
            if (classObj == null)
                return false;
            return true;
        }
        public override void Execute(object parameter)
        {
            Class classObj = parameter as Class;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(DatabaseHelper.connectionString))
            {
                sql.CreateTable<Class>();
                sql.CreateTable<Teacher>();
                sql.CreateTable<Teacher_Class>();
                sql.Delete(sql.Table<Teacher_Class>().Where(t_c => t_c.IdClass == classObj.Id && t_c.IdTeacher == Teacher.Id).FirstOrDefault());
            }
            Classes.Clear();
            foreach (Class c in DatabaseHelper.ReadData(Teacher))
                Classes.Add(c);
        }
    }
}
