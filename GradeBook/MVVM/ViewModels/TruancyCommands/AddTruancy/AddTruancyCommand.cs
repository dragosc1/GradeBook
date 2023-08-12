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

namespace GradeBook.MVVM.ViewModels.TruancyCommands.AddTruancy
{
    public class AddTruancyCommand : BaseCommand
    {
        public ObservableCollection<Truancy> Truancies { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; } 
        public override void Execute(object parameter)
        {
            AddTruancyWindow window = new AddTruancyWindow()
            {
                DataContext = new AddTruancyWindowViewModel(Student, Teacher)
            };
            window.ShowDialog();
            Truancies.Clear();
            foreach (Truancy truancy in DatabaseHelper.ReadDataTruancies(Student, Teacher))
            {
                Truancies.Add(truancy);
            }
        }
        public AddTruancyCommand(ObservableCollection<Truancy> truancies, Student student, Teacher teacher)
        {
            Truancies = truancies;
            Student = student;
            Teacher = teacher;
        }
    }
}
