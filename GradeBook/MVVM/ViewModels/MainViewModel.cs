using GradeBook.MVVM.ViewModels.Language;
using GradeBook.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public NavigationStore NavigationStore { get; }
        public LanguageViewModel LanguageViewModel { get; }
        public ViewModelBase CurrentViewModel => NavigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore nav) {
            LanguageViewModel = new LanguageViewModel();
            NavigationStore = nav;
            NavigationStore.CurrentViewModel = new LoginViewModel(LanguageViewModel, NavigationStore);
            NavigationStore.NavigationChanged += OnNavigationChanged;
        }

        private void OnNavigationChanged()
        {
            OnPropertyChanged("CurrentViewModel"); 
        }
    }
}
