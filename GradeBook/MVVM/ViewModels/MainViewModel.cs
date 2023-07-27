using GradeBook.MVVM.ViewModels.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }
        public LanguageViewModel LanguageViewModel { get; }

        public MainViewModel() {
            LanguageViewModel = new LanguageViewModel();
            CurrentViewModel = new LoginViewModel(LanguageViewModel);
        }
    }
}
