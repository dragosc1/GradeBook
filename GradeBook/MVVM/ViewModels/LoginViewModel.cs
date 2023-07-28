using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.Commands;
using GradeBook.MVVM.ViewModels.Helpers;
using GradeBook.MVVM.ViewModels.Language;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LanguageViewModel LanguageViewModel { get; set; }
        public LoginCommand LoginCommand { get; set; }
        public RegisterCommand RegisterCommand { get; set; }

        private Teacher teacher;

        public Teacher Teacher
        {
            get { return teacher; }
            set
            {
                teacher = value;
                OnPropertyChanged(nameof(Teacher));
            }
        }

        public LoginViewModel(LanguageViewModel lang)
        {
            LanguageViewModel = lang;
            LoginCommand = new LoginCommand();
            RegisterCommand = new RegisterCommand();
            Teacher = new Teacher();
        }
    }
}
