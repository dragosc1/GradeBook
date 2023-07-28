using GradeBook.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.Store
{
    public class NavigationStore
    {
        public event Action NavigationChanged;

        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnNavigationChanged();
            }
        }
        private void OnNavigationChanged()
        {
            NavigationChanged?.Invoke();
        }
    }
}
