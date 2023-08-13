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

namespace GradeBook.MVVM.ViewModels.MisconductCommands.AddMisconduct
{
    public class AddMisconductCommand : BaseCommand
    {
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public ObservableCollection<Misconduct> Misconducts { get; set; }

        public override void Execute(object parameter)
        {
            AddMisconductWindow window = new AddMisconductWindow
            {
                DataContext = new AddMisconductWindowViewModel(Student, Teacher)
            }; 
            window.ShowDialog();
            Misconducts.Clear();
            foreach (Misconduct misconduct in DatabaseHelper.ReadDataMisconducts(Student, Teacher))
                Misconducts.Add(misconduct);
        }   
        public AddMisconductCommand(ObservableCollection<Misconduct> misconducts, Student student, Teacher teacher)
        {
            Misconducts = misconducts;
            Student = student;
            Teacher = teacher;
        }
    }
}
