using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels.TruancyCommands.AddTruancy
{
    public class AddTruancyInfoCommand : BaseCommand
    {
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public override bool CanExecute(object parameter)
        {
            object[] parameters = parameter as object[];
            if (parameter == null) return false;
            Truancy truancy = parameters[0] as Truancy; 
            if (truancy == null) return false;
            return true;
        }
        public override void Execute(object parameter)
        {
            object[] parameters = parameter as object[];
            Truancy truancy = parameters[0] as Truancy;
            Window window = parameters[1] as Window;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(DatabaseHelper.connectionString))
            {
                sql.CreateTable<Truancy>();
                sql.CreateTable<TST>();
                sql.Insert(truancy);
                TST tst = new TST()
                {
                    IdStudent = Student.Id,
                    IdTeacher = Teacher.Id, 
                    IdTruancy = truancy.Id
                };
                sql.Insert(tst);
            }
            window.Close();
        }
        public AddTruancyInfoCommand(Student student, Teacher teacher)
        {
            Student = student;
            Teacher = teacher;
        }
    }
}
