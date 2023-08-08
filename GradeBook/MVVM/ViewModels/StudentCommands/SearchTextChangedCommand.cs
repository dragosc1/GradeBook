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

namespace GradeBook.MVVM.ViewModels.StudentCommands
{
    public class SearchTextChangedCommand : BaseCommand
    {
        public ObservableCollection<Student> Students { get; set; }
        public string Filter { get; set; }
        public override void Execute(object parameter)
        {
            object[] parameters = parameter as object[];    
            Class SelectedClass = parameters[0] as Class;
            string Filter = parameters[1] as string;
            Students.Clear();
            foreach (Student student in DatabaseHelper.ReadData(SelectedClass, Filter)) 
                Students.Add(student);
        }
        public SearchTextChangedCommand(ObservableCollection<Student> students) {
            Students = students;
        }
    }
}
