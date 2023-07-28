using GradeBook.MVVM.ViewModels;
using GradeBook.Store;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore _currentNavigation = new NavigationStore();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_currentNavigation)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
