using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels.MisconductCommands.UpdateMisconduct
{
    public class UpdateMisconductInfoCommand : BaseCommand
    {
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }

        public override bool CanExecute(object parameter)
        {
            object[] parameters = parameter as object[];
            if (parameters == null) return false;
            Misconduct misconduct = parameters[1] as Misconduct;
            if (misconduct == null) return false;
            if (String.IsNullOrEmpty(misconduct.Information)) return false;
            return true;
        }
        public override void Execute(object parameter)
        {
            object[] parameters = parameter as object[];
            Window window = parameters[0] as Window;
            Misconduct misconduct = parameters[1] as Misconduct;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(DatabaseHelper.connectionString))
            {
                sql.CreateTable<Misconduct>();
                sql.Update(misconduct);
            }
            window.Close();
        }
        public UpdateMisconductInfoCommand(Student student, Teacher teacher)
        {
            Student = student;
            Teacher = teacher;
        }
    }
}
