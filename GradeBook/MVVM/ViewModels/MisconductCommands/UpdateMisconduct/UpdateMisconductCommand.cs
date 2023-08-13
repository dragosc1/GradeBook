using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using GradeBook.MVVM.ViewModels.MisconductCommands.AddMisconduct;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.MisconductCommands.UpdateMisconduct
{
    public class UpdateMisconductCommand : BaseCommand
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
            UpdateMisconductWindow window = new UpdateMisconductWindow
            {
                DataContext = new UpdateMisconductWindowViewModel(misconduct, Student, Teacher)
            };
            window.ShowDialog();
            Misconducts.Clear();
            foreach (Misconduct m in DatabaseHelper.ReadDataMisconducts(Student, Teacher))
                Misconducts.Add(m);
        }
        public UpdateMisconductCommand(ObservableCollection<Misconduct> misconducts, Student student, Teacher teacher)
        {
            Misconducts = misconducts;
            Student = student;
            Teacher = teacher;
        }
    }
}
