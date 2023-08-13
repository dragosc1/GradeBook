using GradeBook.MVVM.Model;
using GradeBook.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.Commands
{
    public class StudentBackCommand : BaseCommand
    {
        public NavigationStore NavigationStore { get; set; }
        public Teacher Teacher { get; set; }
        public override void Execute(object parameter)
        {
            NavigationStore.CurrentViewModel = new TeacherViewModel(NavigationStore, Teacher);
        }

        public StudentBackCommand(NavigationStore nav, Teacher teacher)
        {
            NavigationStore = nav;
            Teacher = teacher;
        }
    }
}
