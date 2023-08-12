using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.TruancyCommands.DeleteTruancy
{
    public class DeleteTruancyCommand : BaseCommand
    {
        public ObservableCollection<Truancy> Truancies { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }

        public override bool CanExecute(object parameter)
        {
            Truancy truancy = parameter as Truancy;
            if (truancy == null) return false;
            return true;
        }
        public override void Execute(object parameter)
        {
            Truancy truancy = parameter as Truancy;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(DatabaseHelper.connectionString))
            {
                sql.CreateTable<Truancy>();
                TST tst = sql.Table<TST>().Where(el => el.IdTruancy == truancy.Id && el.IdStudent == Student.Id && el.IdTeacher == Teacher.Id).ToList().FirstOrDefault();
                sql.Delete(tst);
                sql.Delete(truancy);
            }
            Truancies.Clear();
            foreach (Truancy t in DatabaseHelper.ReadDataTruancies(Student, Teacher))
                Truancies.Add(t);
        }
        public DeleteTruancyCommand(ObservableCollection<Truancy> truancies, Student student, Teacher teacher)
        {
            Truancies = truancies;
            Student = student;
            Teacher = teacher;
        }
    }
}
