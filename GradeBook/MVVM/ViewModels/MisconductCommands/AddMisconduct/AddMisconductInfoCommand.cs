using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels.MisconductCommands.AddMisconduct
{
    public class AddMisconductInfoCommand : BaseCommand
    {
        public Misconduct Misconduct { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }    

        public override bool CanExecute(object parameter)
        {
            if (Misconduct == null) { return false; }
            if (String.IsNullOrEmpty(Misconduct.Information))
                return false;
            return true;
        }
        public override void Execute(object parameter)
        {
            Window window = parameter as Window;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(DatabaseHelper.connectionString))
            {
                sql.CreateTable<Misconduct>();
                sql.CreateTable<TSM>();
                sql.Insert(Misconduct);
                TSM tsm = new TSM
                {
                    IdMisconduct = Misconduct.Id,
                    IdStudent = Student.Id,
                    IdTeacher = Teacher.Id
                };
                sql.Insert(tsm);
            }
            window.Close();
        }
        public AddMisconductInfoCommand(Student student, Teacher teacher, Misconduct misconduct)
        {
            Student = student;
            Teacher = teacher;
            Misconduct = misconduct;
        }
    }
}
