using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LanguageViewModel LanguageViewModel { get; set; }
        public SubmitCommand SubmitCommand { get; set; }
        public LoginViewModel(LanguageViewModel lang) {
            LanguageViewModel = lang;
            SubmitCommand = new SubmitCommand();
        }
    }
}
