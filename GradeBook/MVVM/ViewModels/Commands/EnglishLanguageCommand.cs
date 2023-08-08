using GradeBook.MVVM.ViewModels.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GradeBook.MVVM.ViewModels.Commands
{
    public class EnglishLanguageCommand : LanguageCommandBase
    {
        public override void Execute(object parameter)
        {
            SetLanguage("en-GB");
        }
    }
}
