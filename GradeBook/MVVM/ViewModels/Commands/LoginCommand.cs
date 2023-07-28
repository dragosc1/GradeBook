using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels.Commands
{
    public class LoginCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            MessageBox.Show("Yeyyy");
        }
    }
}
