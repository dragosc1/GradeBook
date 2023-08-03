using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.StudentCommands.DeleteStudent
{
    public class DeleteStudentCommand : BaseCommand
    {
        public ObservableCollection<Student> Students { get; set; }

        public override bool CanExecute(object parameter)
        {
            object[] parameters = parameter as object[];
            Student student = parameters[1] as Student;
            if (student == null) return false;
            return true;
        }

        public override void Execute(object parameter)
        {
            object[] parameters = parameter as object[];
            Class SelectedClass = parameters[0] as Class;
            Student student = parameters[1] as Student;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(DatabaseHelper.connectionString)) { 
                sql.CreateTable<Student>();
                sql.Delete(student);
            }
            Students.Clear();
            foreach (Student st in DatabaseHelper.ReadData(SelectedClass))
                Students.Add(st);
        }

        public DeleteStudentCommand(ObservableCollection<Student> students) {
            Students = students;
        }
    }
}
