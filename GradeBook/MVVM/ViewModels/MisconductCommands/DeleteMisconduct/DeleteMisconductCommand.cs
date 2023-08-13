using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.MisconductCommands.DeleteMisconduct
{
    public class DeleteMisconductCommand : BaseCommand
    {
        public ObservableCollection<Misconduct> Misconducts { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }

        public override bool CanExecute(object parameter)
        {
            Misconduct misconduct = parameter as Misconduct;
            if (misconduct == null) return false;
            return true;
        }
        public override void Execute(object parameter)
        {
            Misconduct misconduct = parameter as Misconduct;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(DatabaseHelper.connectionString))
            {
                sql.CreateTable<Misconduct>();  
                sql.CreateTable<TSM>();
                TSM tsm = sql.Table<TSM>().Where(el => el.IdMisconduct == misconduct.Id && el.IdStudent == Student.Id && el.IdTeacher == Teacher.Id).ToList().FirstOrDefault();
                sql.Delete(tsm);
                sql.Delete(misconduct);
            }
            Misconducts.Clear();
            foreach (Misconduct m in DatabaseHelper.ReadDataMisconducts(Student, Teacher))
               Misconducts.Add(m); 
        }

        public DeleteMisconductCommand(ObservableCollection<Misconduct> misconducts, Student student, Teacher teacher)
        {
            Misconducts = misconducts;
            Student = student;  
            Teacher = teacher;
        }
    }
}
